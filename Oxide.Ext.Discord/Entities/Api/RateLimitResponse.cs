using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Rest;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a rate limit response from an API request
    /// </summary>
    public class RateLimitResponse : BasePoolable
    {
        /// <summary>
        /// The Bucket ID of the rate limit
        /// </summary>
        public BucketId BucketId;
        
        /// <summary>
        /// If we hit the global rate limit with this request
        /// </summary>
        public bool IsGlobalRateLimit;
        
        /// <summary>
        /// The date time when this bucket will reset
        /// </summary>
        public DateTimeOffset ResetAt;
        
        /// <summary>
        /// The number of request for this bucket
        /// </summary>
        public int Limit;
        
        /// <summary>
        /// The number of remaining requests for this bucket
        /// </summary>
        public int Remaining;

        /// <summary>
        /// The scope the rate limit is for
        /// </summary>
        public string Scope;

        /// <summary>
        /// Rate Limit Message
        /// </summary>
        public string Message;

        /// <summary>
        /// Rate Limit Code
        /// </summary>
        public int? Code;

        /// <summary>
        /// Initialize the RateLimitResponse
        /// </summary>
        /// <param name="headers">Headers for the rate limit</param>
        /// <param name="code">Http code for the request</param>
        /// <param name="content">Request response content</param>
        public void Init(HttpResponseHeaders headers, DiscordHttpStatusCode code, string content)
        {
            IsGlobalRateLimit = headers.GetBool(RateLimitHeaders.IsGlobal);
            Scope = headers.Get(RateLimitHeaders.Scope);
            if (IsGlobalRateLimit)
            {
                ResetAt = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(headers.GetDouble(RateLimitHeaders.RetryAfter));
                return;
            }

            BucketId = headers.GetBucketId(RateLimitHeaders.BucketId);
            if (!BucketId.IsValid)
            {
                return;
            }
            
            Limit = headers.GetInt(RateLimitHeaders.BucketLimit);
            Remaining =  headers.GetInt(RateLimitHeaders.BucketRemaining);
            ResetAt = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(headers.GetDouble(RateLimitHeaders.BucketResetAfter));

            if (code == DiscordHttpStatusCode.TooManyRequests && !string.IsNullOrEmpty(content) && content[0] == '{')
            {
                RateLimitContent rateContent = DiscordPool.Internal.Get<RateLimitContent>();
                JsonConvert.PopulateObject(content, rateContent);
                Message = rateContent.Message;
                Code = rateContent.Code;
                DiscordPool.Internal.Free(rateContent);
            }

            //DiscordExtension.GlobalLogger.Debug("Headers:\n{0}", headers.ToString());
        }

        ///<inheritdoc/>
        protected override void EnterPool()
        {
            BucketId = default;
            IsGlobalRateLimit = false;
            ResetAt = default;
            Limit = 0;
            Remaining = 0;
            Scope = null;
            Message = null;
            Code = null;
        }
    }
}