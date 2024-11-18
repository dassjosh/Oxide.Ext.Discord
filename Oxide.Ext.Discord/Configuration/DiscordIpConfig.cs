using System.ComponentModel;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Configuration
{
    /// <summary>
    /// IP data config
    /// </summary>
    internal class DiscordIpConfig
    {
        [DefaultValue(true)]
        [JsonProperty("Enabled")]
        public bool Enabled { get; set; }
        
        /// <summary>
        /// How many days to store IP data
        /// </summary>
        [JsonProperty("Save IP Data Duration (Days)")]
        public float StoreIpDuration { get; set; }
        
        /// <summary>
        /// How many days to store IP data
        /// </summary>
        [JsonProperty("Unknown Country Emoji")]
        public string UnknownCountryEmoji { get; set; }
    }
}