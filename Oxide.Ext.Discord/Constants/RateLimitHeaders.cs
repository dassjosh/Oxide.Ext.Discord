namespace Oxide.Ext.Discord.Constants
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/rate-limits#header-format">Header Format</a>
    /// </summary>
    public static class RateLimitHeaders
    {
        /// <summary>
        /// The number of seconds to wait before submitting another request.
        /// </summary>
        public const string RetryAfter = "Retry-After";
        
        /// <summary>
        /// Returned only on HTTP 429 responses if the rate limit encountered is the global rate limit (not per-route)
        /// </summary>
        public const string IsGlobal = "X-RateLimit-Global";
        
        /// <summary>
        /// A unique string denoting the rate limit being encountered (non-inclusive of top-level resources in the path)
        /// </summary>
        public const string BucketId = "X-RateLimit-Bucket";
        
        /// <summary>
        /// The number of requests that can be made
        /// </summary>
        public const string BucketLimit = "X-RateLimit-Limit";
        
        /// <summary>
        /// The number of remaining requests that can be made
        /// </summary>
        public const string BucketRemaining = "X-RateLimit-Remaining";
        
        /// <summary>
        /// Total time (in seconds) of when the current rate limit bucket will reset. Can have decimals to match previous millisecond rate-limit precision
        /// </summary>
        public const string BucketResetAfter = "X-RateLimit-Reset-After";
        
        /// <summary>
        /// Epoch time (seconds since 00:00:00 UTC on January 1, 1970) at which the rate limit resets
        /// </summary>
        public const string BucketReset = "X-RateLimit-Reset";
        
        /// <summary>
        /// Scope of the rate limit
        /// </summary>
        public const string Scope = "X-RateLimit-Scope";
    }
}