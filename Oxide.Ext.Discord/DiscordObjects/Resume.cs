using Newtonsoft.Json;

namespace uMod.Ext.Discord.DiscordObjects
{
    public class Resume
    {
        [JsonProperty("token")]
        public string Token;

        [JsonProperty("session_id")]
        public string SessionID;

        [JsonProperty("seq")]
        public int Sequence;
    }
}
