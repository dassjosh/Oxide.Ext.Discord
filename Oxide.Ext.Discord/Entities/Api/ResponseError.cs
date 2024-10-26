using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oxide.Core.Libraries;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Configuration;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Rest;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Error object that is returned to the caller when a request fails
    /// </summary>
    public class ResponseError : BaseDiscordException
    {
        /// <summary>
        /// ID of the request
        /// </summary>
        public readonly Snowflake RequestId;
        
        /// <summary>
        /// The request method that was called
        /// </summary>
        public readonly RequestMethod RequestMethod;

        /// <summary>
        /// The exception from the request
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// The URI that was called
        /// </summary>
        public readonly string Url;

        /// <summary>
        /// What data was passed to the request
        /// </summary>
        public readonly object RequestData;

        /// <summary>
        /// HTTP Content Type for the request
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// <see cref="DateTimeOffset"/> when the error occured
        /// </summary>
        public readonly DateTimeOffset ErrorDate;

        /// <summary>
        /// The string contents of the request
        /// </summary>
        public string StringContents { get; private set; }

        /// <summary>
        /// HTTP Status code
        /// </summary>
        public DiscordHttpStatusCode HttpStatusCode { get; private set; }

        /// <summary>
        /// If discord returned an error this will contain that error message
        /// </summary>
        public ResponseErrorMessage DiscordError { get; private set; }

        /// <summary>
        /// Full string response if we received one
        /// </summary>
        public string ResponseMessage { get; private set; }
        
        /// <summary>
        /// If error was a rate limit the message from the rate limit
        /// </summary>
        public string RateLimitMessage { get; private set; }
        
        /// <summary>
        /// If error was a rate limit the code from the rate limit
        /// </summary>
        public int? RateLimitCode { get; private set; }
        
        internal RequestErrorType ErrorType { get; private set; }

        private DiscordLogLevel _logLevel;
        private readonly DiscordClient _client;
        private readonly Bucket _bucket;

        /// <summary>
        /// Should we display the error message
        /// </summary>
        private bool _showErrorMessage = true;

        /// <summary>
        /// Creates a new rest error
        /// </summary>
        /// <param name="request">Request the error is for</param>
        /// <param name="type"><see cref="RequestErrorType"/> of the error</param>
        /// <param name="log"><see cref="DiscordLogLevel"/> log level of the error</param>
        internal ResponseError(BaseRequest request, RequestErrorType type, DiscordLogLevel log)
        {
            RequestId = request.Id;
            _client = request.Client;
            _bucket = request.Bucket;
            Url = request.Route;
            RequestMethod = request.Method;
            RequestData = request.Data;
            ErrorDate = DateTimeOffset.UtcNow;
            ErrorType = type;
            _logLevel = log;
        }

        internal async ValueTask<ResponseError> WithRequest(HttpRequestMessage request)
        {
            if (request.Content != null)
            {
                ContentType = request.Content.Headers.ContentType.ToString();
                StringContents = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            else
            {
                ContentType = "No Content";
                StringContents = "No Content";
            }

            return this;
        }

        internal ResponseError WithException(Exception ex)
        {
            Exception = ex;
            return this;
        }

        /// <summary>
        /// Suppresses the error message from being logged
        /// </summary>
        public void SuppressErrorMessage()
        {
            _showErrorMessage = false;
        }

        /// <summary>
        /// Sets the HTTP Response data
        /// </summary>
        /// <param name="code">HTTP Response Code</param>
        /// <param name="content">HTTP Response Body Stream</param>
        internal void SetResponse(DiscordHttpStatusCode code, string content)
        {
            HttpStatusCode = code;
            if (content.Length == 0)
            {
                return;
            }

            ResponseMessage = content;
            if (string.IsNullOrEmpty(ResponseMessage) || ResponseMessage[0] != '{')
            {
                return;
            }
            
            DiscordError = JsonConvert.DeserializeObject<ResponseErrorMessage>(content, _client.JsonSettings);
            if (DiscordError == null)
            {
                return;
            }
            
            ErrorType = RequestErrorType.ApiError;
            _logLevel = DiscordLogLevel.Error;
        }

        internal void SetRateLimitResponse(string message, int? code)
        {
            RateLimitMessage = message;
            RateLimitCode = code;
        }

        /// <summary>
        /// Performs the error logging for the request
        /// </summary>
        internal void LogError()
        {
            if (!_client.Logger.IsLogging(_logLevel))
            {
                return;
            }

            if (DiscordError != null && DiscordConfig.Instance.Logging.HideDiscordErrorCodes.Contains(DiscordError.Code))
            {
                return;
            }

            switch (ErrorType)
            {
                case RequestErrorType.Internal:
                    _client.Logger.Error("Rest Request Exception (Internal Error) Plugin: {0} ID: {1} Request URL: [{2}] {3}", _client.PluginName, RequestId, RequestMethod, Url);
                    break;
                
                case RequestErrorType.RateLimit:
                    _client.Logger.Warning("Rest Request Exception (Rate Limit) Plugin: {0} ID: {1} Request URL: [{2}] {3} Content-Type: {4} Remaining: {5} Limit: {6} Reset At: {7} Current Time: {8} Code: {9} Message: {10}",
                        _client.PluginName, RequestId, RequestMethod, Url, ContentType, _bucket.Remaining, _bucket.Limit, _bucket.ResetAt, ErrorDate, RateLimitCode, RateLimitMessage);
                    break;

                case RequestErrorType.ApiError:
                    if (_showErrorMessage)
                    {
                        _client.Logger.Error("Rest Request Exception (Discord API Error). Plugin: {0} ID: {1} Request URL: [{2}] {3} Content-Type: {4} Http Response Code: {5} Discord Error Code: {6} Discord Error: {7}\nDiscord Errors: {8}Request Body:\n{9}",
                            _client.PluginName, RequestId, RequestMethod, Url, ContentType, HttpStatusCode, DiscordError.Code, DiscordError.Message, DiscordError.Errors, StringContents ?? "No Contents");
                    }
                    break;

                case RequestErrorType.GenericWeb:
                    _client.Logger.Error("Rest Request Exception (Web Error). Plugin: {0} ID: {1} Request URL: [{2}] {3} Content-Type: {4} Http Response Code: {5} Message: {6}", _client.PluginName, RequestId, RequestMethod, Url, ContentType, HttpStatusCode, ResponseMessage);
                    break;

                case RequestErrorType.Serialization:
                    _client.Logger.Exception("Rest Request Exception (JSON Serialization). Plugin: {0} ID: {1} Method: {2} URL: {3} Data Type: {4}", _client.PluginName, RequestId, RequestMethod, Url, RequestData?.GetType().GetRealTypeName() ?? "None", Exception);
                    break;

                case RequestErrorType.Generic:
                    _client.Logger.Exception("Rest Request Exception (Generic Error). Plugin: {0} ID: {1} Method: {2} URL: {3} Data Type: {4}", _client.PluginName, RequestId, RequestMethod, Url, RequestData?.GetType().GetRealTypeName() ?? "None", Exception);
                    break;
            }
        }
    }
}