using System;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a rate limit for rest requests
    /// </summary>
    public class RestRateLimit : BaseRateLimit
    {
        private DateTimeOffset _retryAfter;

        /// <summary>
        /// Constructor for RestRateLimit
        /// </summary>
        public RestRateLimit(ILogger logger) : base(50, 1 * 1000L, logger) { }
        
        /// <summary>
        /// Called if we receive a header notifying us of hitting the rate limit
        /// </summary>
        /// <param name="retryAfter">How long until we should retry API request again</param>
        public void ReachedRateLimit(DateTimeOffset retryAfter)
        {
            NumRequests = MaxRequests;
            _retryAfter = retryAfter;
        }

        ///<inheritdoc/>
        protected override void OnRateLimitReset()
        {
            if (NumRequests > 0)
            {
                Logger.Debug($"{nameof(RestRateLimit)}.{nameof(OnRateLimitReset)} Num Requests: {{0}} Reached Rate Limit: {{1}}", NumRequests, HasReachedRateLimit);
            }
        }

        /// <summary>
        /// Returns how long until the current rate limit period will expire
        /// </summary>
        public override DateTimeOffset NextReset()
        {
            DateTimeOffset nextReset = base.NextReset();
            return nextReset > _retryAfter ? nextReset : _retryAfter;
        }
        
        /// <summary>
        /// Called when an API request is fired
        /// </summary>
        public void FiredRequest()
        {
            FiredRequestInternal();
        }
    }
}