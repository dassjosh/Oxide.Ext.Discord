using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Configuration;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Rest
{
    /// <summary>
    /// Represent a Discord API request
    /// </summary>
    public class RequestHandler : BasePoolable, IDebugLoggable
    {
        internal BaseRequest Request;
        
        private RequestResponse _response;
        private CancellationToken _token;
        private ILogger _logger;
        private readonly Func<ValueTask> _runner;

        /// <summary>
        /// Constructor
        /// </summary>
        public RequestHandler()
        {
            _runner = RunRequest;
        }

        /// <summary>
        /// Creates a new <see cref="RequestHandler"/>
        /// </summary>
        /// <param name="request">Request to be handled by this handler</param>
        public static RequestHandler CreateRequest(BaseRequest request)
        {
            RequestHandler handler = request.PluginPool.Get<RequestHandler>();
            handler.Init(request, request.Client.Logger);
            return handler;
        }
        
        private void Init(BaseRequest request, ILogger logger)
        {
            Request = request;
            _token = Request.Source.Token;
            _logger = logger;
        }

        /// <summary>
        /// Starts the Request
        /// </summary>
        public void StartRequest()
        {
            if (Request.Status == RequestStatus.InQueue)
            {
                Request.Status = RequestStatus.Started;
                Task.Run(_runner, _token);
            }
        }
        
        private async ValueTask RunRequest()
        {
            AdjustableSemaphore semaphore = null;
            try
            {
                Bucket bucket = Request.Bucket;
                BucketId bucketId = bucket.Id;
                semaphore = bucket.ActiveRequestsSemaphore;
                Request.Status = RequestStatus.PendingBucket;
            
                _logger.Debug("Waiting for bucket availability Bucket ID: {0} Request ID: {1}", bucket.Id, Request.Id);
                
                await semaphore.WaitOneAsync().ConfigureAwait(false);
                bucket = Request.Bucket;
                if (bucketId != bucket.Id)
                {
                    _logger.Debug("Bucket ID Changed. Waiting for bucket availability again for ID: {0} Old Bucket ID: {1} New Bucket ID: {2}", Request.Id, bucketId, bucket.Id);
                    semaphore.Release();
                    semaphore = bucket.ActiveRequestsSemaphore;
                    await semaphore.WaitOneAsync().ConfigureAwait(false);
                }

                _logger.Debug("Request started for Bucket ID: {0} Request ID: {1}", bucket.Id, Request.Id);
                _response = await FireRequest().ConfigureAwait(false);
                if (_response != null)
                {
                    Request.OnRequestCompleted(this, _response);
                }
                
                _logger.Debug("Request callback completed successfully for Bucket ID: {0} Request ID: {1}", bucket.Id, Request.Id);
            }
            catch (Exception ex)
            {
                _logger.Exception("Request callback threw exception for Bucket ID: {0} Request ID: {1}", Request.Id, Request.Id, ex);
            }
            finally
            {
                semaphore?.Release();
            }
            
            Dispose();
        }
        
        /// <summary>
        /// Fires the request off
        /// </summary>
        private ValueTask<RequestResponse> FireRequest()
        {
            try
            {
                return FireRequestInternal();
            }
            catch (Exception ex)
            {
                return RequestResponse.CreateExceptionResponse(GetResponseError(RequestErrorType.Generic, DiscordLogLevel.Exception).WithException(ex), null, RequestCompletedStatus.ErrorFatal);
            }
        }
        
        private async ValueTask<RequestResponse> FireRequestInternal()
        {
            _logger.Verbose($"{nameof(RequestHandler)}.{nameof(FireRequestInternal)} Starting REST Request. Request ID: {{0}} Method: {{1}} Url: {{2}}", Request.Id, Request.Method, Request.Route);

            RequestResponse response = null;
            byte retries = 0;
            while(CanSendRequest(response, retries)) 
            {
                response?.Dispose();
                Request.Status = RequestStatus.PendingStart;
                await Request.WaitUntilRequestCanStart(_token).ConfigureAwait(false);
                await Request.Bucket.WaitUntilBucketAvailable(this, _token).ConfigureAwait(false);
                Request.Status = RequestStatus.InProgress;
                
                if (Request.IsCancelled)
                {
                    _logger.Verbose($"{nameof(RequestHandler)}.{nameof(FireRequestInternal)} Cancel REST Request. Request ID: {{0}} Method: {{1}} Url: {{2}}", Request.Id, Request.Method, Request.Route);
                    return await RequestResponse.CreateCancelledResponse().ConfigureAwait(false);
                }

                response = await SendRequest(_token).ConfigureAwait(false);
                
                //Request was canceled
                if (response == null)
                {
                    return null;
                }
                
                Request.Bucket.UpdateRateLimits(this, response);
                
                switch (response.Status)
                {
                    case RequestCompletedStatus.Success:
                    case RequestCompletedStatus.Cancelled:
                    case RequestCompletedStatus.ErrorFatal:
                        return response;
                }

                if (response.Code == DiscordHttpStatusCode.BadRequest)
                {
                    return response;
                }
                
                retries++;
            }
            
            return response;
        }

        private bool CanSendRequest(RequestResponse response, byte retries)
        {
            if (retries >= DiscordConfig.Instance.Rest.ApiRateLimitRetries)
            {
                return false;
            }
            
            if (response != null && response.Code != DiscordHttpStatusCode.TooManyRequests)
            {
                return retries < DiscordConfig.Instance.Rest.ApiErrorRetries;
            }
            
            return true;
        }

        private async ValueTask<RequestResponse> SendRequest(CancellationToken token)
        {
            try
            {
                using HttpRequestMessage request = CreateRequest();
                using HttpResponseMessage webResponse = await Request.HttpClient.SendAsync(request, token).ConfigureAwait(false);
                if (token.IsCancellationRequested)
                {
                    return null;
                }
                        
                if (webResponse.IsSuccessStatusCode)
                {
                    return await RequestResponse.CreateSuccessResponse(webResponse).ConfigureAwait(false);
                }

                return await HandleWebException(request, webResponse).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return await RequestResponse.CreateCancelledResponse().ConfigureAwait(false);
            }
            catch (JsonSerializationException ex)
            {
                return await RequestResponse.CreateExceptionResponse(GetResponseError(RequestErrorType.Serialization, DiscordLogLevel.Error).WithException(ex), null, RequestCompletedStatus.ErrorFatal).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await RequestResponse.CreateExceptionResponse(GetResponseError(RequestErrorType.Generic, DiscordLogLevel.Error).WithException(ex), null, RequestCompletedStatus.ErrorFatal).ConfigureAwait(false);
            }
        }

        private async ValueTask<RequestResponse> HandleWebException(HttpRequestMessage request, HttpResponseMessage webResponse)
        {
            RequestResponse response;
            
            if (Request.Client.Logger.IsLogging(DiscordLogLevel.Verbose))
            {
                string content = request.Content != null ? await request.Content.ReadAsStringAsync().ConfigureAwait(false) : "No Content";
                Request.Client.Logger.Verbose("Web Exception Occured. Request ID: {0} Plugin: {1} Method: {2} Route: {3} HTTP Code: {4}\nBody:\n{5}", 
                    Request.Id, Request.Client.PluginName, Request.Method, Request.Route, webResponse.StatusCode, content);
            }
            
            DiscordHttpStatusCode statusCode = (DiscordHttpStatusCode)webResponse.StatusCode;
            if (statusCode == DiscordHttpStatusCode.TooManyRequests)
            {
                response = await RequestResponse.CreateExceptionResponse(await GetResponseError(RequestErrorType.RateLimit, DiscordLogLevel.Warning).WithRequest(request).ConfigureAwait(false), webResponse, RequestCompletedStatus.ErrorRetry).ConfigureAwait(false);
            }
            else
            {
                response = await RequestResponse.CreateExceptionResponse(await GetResponseError(RequestErrorType.GenericWeb, DiscordLogLevel.Error).WithRequest(request).ConfigureAwait(false), webResponse, RequestCompletedStatus.ErrorFatal).ConfigureAwait(false);
            }
            
            Request.OnRequestErrored();

            if (Request.Client.Logger.IsLogging(DiscordLogLevel.Verbose))
            {
                string content = request.Content != null ? await request.Content.ReadAsStringAsync().ConfigureAwait(false) : "No Content";
                Request.Client.Logger.Verbose("Web Exception Occured. Type: {0} Request ID: {1} Plugin: {2} Method: {3} Route: {4} HTTP Code: {5}\nBody:\n{6}", 
                    response.Error?.ErrorType, Request.Id, Request.Client.PluginName, Request.Method, Request.Route, response.Code, content);
            }

            return response;
        }

        private HttpRequestMessage CreateRequest()
        {
            HttpRequestMessage request = new(DiscordHttpMethods.GetMethod(Request.Method), Request.Route);
            CreateContent(request);
            return request;
        }
        
        private void CreateContent(HttpRequestMessage request)
        {
            object data = Request.Data;
            switch (data)
            {
                case null:
                    return;
                case IFileAttachments {FileAttachments: not null} attachments when attachments.FileAttachments.Count != 0:
                {
                    MultipartFormDataContent content = new();

                    HttpContent json = GetJsonContent(data);
                    content.Add(json, "payload_json");

                    for (int index = 0; index < attachments.FileAttachments.Count; index++)
                    {
                        MessageFileAttachment fileAttachment = attachments.FileAttachments[index];
                        ByteArrayContent file = new(fileAttachment.Data);
                        content.Add(file, FileAttachmentCache.Instance.GetName(index), fileAttachment.FileName);
                        file.Headers.ContentType = MediaTypeHeaderCache.Instance.Get(fileAttachment.ContentType);
                    }

                    request.Content = content;
                    break;
                }

                default:
                    request.Content = GetJsonContent(data);
                    break;
            }

        }

        private StringContent GetJsonContent(object data)
        {
            string json = JsonConvert.SerializeObject(data, Request.Client.JsonSettings);
            _logger.Verbose($"{nameof(RequestHandler)}.{nameof(GetJsonContent)} Data: {{0}}", json);
            StringContent content = new(json);
            content.Headers.ContentType = MediaTypeHeaderCache.Instance.Get("application/json");
            return content;
        }

        /// <summary>
        /// Aborts a currently running request
        /// </summary>
        public void Abort()
        {
            Request.Client.Logger.Debug($"{nameof(RequestHandler)}.{nameof(Abort)} Abort Request Bucket ID: {{0}} Request ID: {{1}} Plugin: {{2}} Method: {{3}} Route: {{4}}", Request.Bucket.Id, Request.Id, Request.Client.PluginName, Request.Method, Request.Route);
            Request.Abort();
        }

        private ResponseError GetResponseError(RequestErrorType type, DiscordLogLevel log) => new(Request, type, log);

        /// <inheritdoc/>
        protected override void EnterPool()
        {
            Request.Dispose();
            _response?.Dispose();
            Request = null;
            _response = null;
            _logger = null;
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            Request.LogDebug(logger);
        }
    }
}