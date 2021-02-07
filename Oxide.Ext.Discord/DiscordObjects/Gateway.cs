using System;
using Newtonsoft.Json;

namespace uMod.Ext.Discord.DiscordObjects
{
    class Gateway
    {
        [JsonProperty("url")]
        public string URL { get; private set; }
        
        public static string WebSocketUrl { get; set; }

        public static void GetGateway(DiscordClient client, Action<Gateway> callback)
        {
            client.REST.DoRequest("/gateway", REST.RequestMethod.GET, null, callback);
        }
    }
}
