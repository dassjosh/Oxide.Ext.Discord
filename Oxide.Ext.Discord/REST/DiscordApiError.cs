using Newtonsoft.Json;

namespace uMod.Ext.Discord.REST
{
    public class DiscordApiError
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}