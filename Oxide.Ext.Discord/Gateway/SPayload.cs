using Newtonsoft.Json;

namespace uMod.Ext.Discord.Gateway
{
    public class SPayload
    {
        [JsonProperty("op")]
        public SendOpCode OpCode;

        [JsonProperty("d")]
        public object Payload;
    }
}
