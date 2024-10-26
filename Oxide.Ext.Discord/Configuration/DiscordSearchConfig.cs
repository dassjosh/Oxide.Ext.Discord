using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Configuration
{
    internal class DiscordSearchConfig
    {
        [JsonProperty("Enable Player Name Trie Search (High Performance / High Memory Usage)")]
        public bool EnablePlayerNameSearchTrie { get; set; }
    }
}