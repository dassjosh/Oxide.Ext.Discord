using Newtonsoft.Json;

namespace uMod.Ext.Discord.Gateway
{
    class Connect
    {
        [JsonProperty("v")]
        public static int Version { get; } = 6;

        [JsonProperty("encoding")]
        public static string Encoding { get; } = "json";

        [JsonProperty("compress")]
        public static string Compress { get; } = string.Empty;
        
        public static string Serialize() => $"v={Version}&encoding={Encoding}";
    }
}
