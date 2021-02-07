using Newtonsoft.Json;

namespace uMod.Ext.Discord.DiscordObjects
{
    public class Game
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public ActivityType Type { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
