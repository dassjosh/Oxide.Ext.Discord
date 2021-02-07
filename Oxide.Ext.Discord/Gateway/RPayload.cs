using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace uMod.Ext.Discord.Gateway
{
    public class RPayload
    {
        [JsonProperty("op")]
        public ReceiveOpCode OpCode { get; set; }
        
        [JsonProperty("t")]
        public string EventName { get; set; }

        [JsonProperty("d")]
        public object Data { get; set; }

        [JsonProperty("s")]
        public int? Sequence { get; set; }

        [JsonIgnore]
        public JObject EventData => Data as JObject;
        
        [JsonIgnore]
        public JToken TokenData => Data as JToken;
    }
}
