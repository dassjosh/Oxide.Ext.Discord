using Newtonsoft.Json;

namespace uMod.Ext.Discord.DiscordEvents
{
    public class Hello
    {
        [JsonProperty("heartbeat_interval")]
        public int HeartbeatInterval;

        [JsonProperty("_trace")]
        public string[] Trace;
    }
}
