using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Configuration
{
    /// <summary>
    /// Discord User Config
    /// </summary>
    internal class DiscordUsersConfig
    {
        /// <summary>
        /// How long to block DM's after we receive a 50007 Discord API Error code
        /// </summary>
        [JsonProperty("Direct Message Blocked Duration (Hours)")]
        public float DmBlockedDuration { get; set; }
    }
}