
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Configuration
{
    /// <summary>
    /// Represents Discord Extension Bot Config
    /// </summary>
    internal class DiscordBotConfig
    {
        [JsonProperty("Automatically Apply Gateway Intents")]
        public bool AutomaticallyApplyGatewayIntents { get; set; }
    }
}