namespace Oxide.Ext.Discord.Rest
{
    /// <summary>
    /// Options the the REST request
    /// </summary>
    public struct RequestOptions
    {
        /// <summary>
        /// If the request should ignore global rate limits
        /// </summary>
        public readonly bool IgnoreRateLimit;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ignoreRateLimit"></param>
        public RequestOptions(bool ignoreRateLimit)
        {
            IgnoreRateLimit = ignoreRateLimit;
        }

        /// <summary>
        /// The request should ignore rate limits
        /// </summary>
        /// <returns></returns>
        public static RequestOptions SkipRateLimit() => new(true);
    }
}