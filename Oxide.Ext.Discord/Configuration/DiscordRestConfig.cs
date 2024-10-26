using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Configuration
{
    /// <summary>
    /// Discord Rest Config
    /// </summary>
    internal class DiscordRestConfig
    {
        /// <summary>
        /// How many retries for API request errors
        /// </summary>
        [JsonProperty("API Error Request Retries")]
        public int ApiErrorRetries { get; set; }
        
        /// <summary>
        /// How many retries for API request rate limit errors
        /// </summary>
        [JsonProperty("API Rate Limit Request Retries")]
        public int ApiRateLimitRetries { get; set; }
    }
}