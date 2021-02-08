using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using uMod.Ext.Discord.DiscordObjects;
using uMod.Ext.Discord.Logging;
using Time = uMod.Ext.Discord.Helpers.Time;

namespace uMod.Ext.Discord.REST
{
    public class Request
    {
        public RequestMethod Method { get; }

        public string Route { get; }

        public string RequestUrl => UrlBase + Route;

        public Dictionary<string, string> Headers { get; }

        public object Data { get; }

        public RestResponse Response { get; private set; }

        public Action<RestResponse> Callback { get; }

        public DateTime? StartTime { get; private set; }

        public bool InProgress { get; set; }

        private Bucket _bucket;

        private byte _retries;
        
        private const string UrlBase = "https://discordapp.com/api";
        
        private const int RequestMaxLength = 15;

        private readonly ILogger _logger;
        
        private static readonly JsonSerializerSettings DefaultSerializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public Request(RequestMethod method, string route, Dictionary<string, string> headers, object data, Action<RestResponse> callback, ILogger logger)
        {
            this.Method = method;
            this.Route = route;
            this.Headers = headers;
            this.Data = data;
            this.Callback = callback;
            _logger = logger;
        }

        public void Fire(Bucket bucket)
        {
            _bucket = bucket;
            InProgress = true;
            StartTime = DateTime.UtcNow;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(RequestUrl);
            req.Method = Method.ToString();
            req.ContentType = "application/json";
            req.UserAgent = $"DiscordBot (https://github.com/Trickyyy/Oxide.Ext.Discord, {DiscordExtension.GetExtensionVersion})";
            req.Timeout = RequestMaxLength * 1000;
            req.ContentLength = 0;

            if (Headers != null)
            {
                foreach (KeyValuePair<string,string> header in Headers)
                {
                    req.Headers.Add(header.Key, header.Value);
                }
            }
            
            try
            {
                //Can timeout while writing request data
                if (Data != null)
                {
                    WriteRequestData(req, Data);
                }

                using (HttpWebResponse response = req.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        ParseResponse(response);
                    }
                }

                Callback?.Invoke(Response);
                Close();
            }
            catch (WebException ex)
            {
                using (HttpWebResponse httpResponse = ex.Response as HttpWebResponse)
                {
                    if (httpResponse == null)
                    {
                        bucket.ErrorResendDelayUntil = Time.TimeSinceEpoch() + 1;
                        Close(false);
                        _logger.Exception($"A web request exception occured (internal error) [RETRY={_retries}/3].\nRequest URL: [{Method.ToString()}] {req.RequestUri}", ex);
                        return;
                    }

                    string message = ParseResponse(ex.Response);

                    bool isRateLimit = (int) httpResponse.StatusCode == 429;
                    if (isRateLimit)
                    {
                        _logger.Warning($"Discord rate limit reached. (Rate limit info: remaining: Route:{req.RequestUri}, {bucket.RateLimitRemaining}, limit: {bucket.RateLimit}, reset: {bucket.RateLimitReset}, time now: {Time.TimeSinceEpoch()}");
                    }
                    else
                    {
                        DiscordApiError apiError = Response.ParseData<DiscordApiError>();
                        if (!string.IsNullOrEmpty(apiError.Code))
                        {
                            _logger.Error($"Discord has returned error Code: {apiError.Code}: {apiError.Message}, {req.RequestUri} (code {httpResponse.StatusCode})");
                        }
                        else
                        {
                            _logger.Error($"An error occured whilst submitting a request to {req.RequestUri} (code {httpResponse.StatusCode}): {message}");
                        }
                    }

                    Close(!isRateLimit);
                }
            }
            catch (Exception ex)
            {
                _logger.Exception("Request callback raised an exception", ex);
                Close();
            }
        }

        public void Close(bool remove = true)
        {
            _retries += 1;
            if (remove || _retries >= 3)
            {
                lock (_bucket)
                {
                    _bucket.Remove(this);
                }
            }
            else
            {
                InProgress = false;
                StartTime = null;
            }
        }

        public bool HasTimedOut()
        {
            if (!InProgress || StartTime == null)
            {
                return false;
            }

            return (DateTime.UtcNow - StartTime.Value).TotalSeconds > RequestMaxLength;
        }

        private void WriteRequestData(HttpWebRequest request, object data)
        {
            string contents = JsonConvert.SerializeObject(data, DefaultSerializerSettings);

            byte[] bytes = Encoding.UTF8.GetBytes(contents);
            request.ContentLength = bytes.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            
        }

        private string ParseResponse(WebResponse response)
        {
            using (Stream stream = response.GetResponseStream())
            {
                if (stream == null)
                {
                    return null;
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    string message = reader.ReadToEnd().Trim();
                    Response = new RestResponse(message);

                    ParseHeaders(response.Headers, Response);

                    return message;
                }
            }
        }

        private void ParseHeaders(WebHeaderCollection headers, RestResponse response)
        {
            string globalRetryAfterHeader = headers.Get("Retry-After");
            string isGlobalRateLimitHeader = headers.Get("X-RateLimit-Global");

            if (!string.IsNullOrEmpty(globalRetryAfterHeader) &&
                !string.IsNullOrEmpty(isGlobalRateLimitHeader) &&
                int.TryParse(globalRetryAfterHeader, out int globalRetryAfter) &&
                bool.TryParse(isGlobalRateLimitHeader, out bool isGlobalRateLimit) &&
                isGlobalRateLimit)
            {
                RateLimit limit = response.ParseData<RateLimit>();
                if (limit.global)
                {
                    _bucket.Handler.RateLimit.ReachedRateLimit(globalRetryAfter);
                }
            }

            string bucketLimitHeader = headers.Get("X-RateLimit-Limit");
            string bucketRemainingHeader = headers.Get("X-RateLimit-Remaining");
            string bucketResetAfterHeader = headers.Get("X-RateLimit-Reset-After");
            string bucketNameHeader = headers.Get("X-RateLimit-Bucket");

            if (!string.IsNullOrEmpty(bucketLimitHeader) &&
                int.TryParse(bucketLimitHeader, out int bucketLimit))
            {
                _bucket.RateLimit = bucketLimit;
            }

            if (!string.IsNullOrEmpty(bucketRemainingHeader) &&
                int.TryParse(bucketRemainingHeader, out int bucketRemaining))
            {
                _bucket.RateLimitRemaining = bucketRemaining;
            }

            double timeSince = Time.TimeSinceEpoch();
            if (!string.IsNullOrEmpty(bucketResetAfterHeader) &&
                double.TryParse(bucketResetAfterHeader, out double bucketResetAfter))
            {
                double resetTime = timeSince + bucketResetAfter;
                if (resetTime > _bucket.RateLimitReset)
                {
                    _bucket.RateLimitReset = resetTime;
                }
            }
            
            _logger.Debug($"Method: {Method} Route: {Route} Internal Bucket Id: {_bucket.BucketId} Limit: {_bucket.RateLimit} Remaining: {_bucket.RateLimitRemaining} Reset: {_bucket.RateLimitReset} Time: {Time.TimeSinceEpoch()} Bucket: {bucketNameHeader}");
        }
    }
}
