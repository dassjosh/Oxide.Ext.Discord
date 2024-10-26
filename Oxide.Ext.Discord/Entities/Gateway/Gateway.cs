using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents Discord Gatway Connection Url
    /// See <a href="https://discord.com/developers/docs/topics/gateway#get-gateway">Get Gateway</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class Gateway
    {
        /// <summary>
        /// Gatway URL to use
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        
        /// <summary>
        /// Saved Gateway URL
        /// Example: wss://gateway.discord.gg/?v=8&amp;encoding=json
        /// </summary>
        public static string WebsocketUrl { get; private set; }
        
        public static DateTime LastUpdate { get; private set; }

        internal static readonly List<int> Shard = new() {0, 1};
        internal static readonly ConnectionProperties Properties = new();

        /// <summary>
        /// Returns an object with a single valid WSS URL, which the client can use for Connecting.
        /// Clients should cache this value and only call this endpoint to retrieve a new URL if they are unable to properly establish a connection using the cached version of the URL.
        /// See <a href="https://discord.com/developers/docs/topics/gateway#get-gateway">Get Gateway</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        private static IPromise<Gateway> GetGateway(BotClient client)
        {
            return client.Rest.Get<Gateway>(client.GetFirstClient(),"gateway");
        }

        public static IPromise<Gateway> UpdateGatewayUrl(BotClient client)
        {
            return GetGateway(client).Then(gateway =>
            {
                WebsocketUrl = $"{gateway.Url}/?{DiscordEndpoints.Websocket.WebsocketArgs}";
                LastUpdate = DateTime.UtcNow;
                client.Logger.Debug($"{nameof(Gateway)}.{nameof(UpdateGatewayUrl)} Updated Gateway Url: {{0}}", WebsocketUrl);
            });
        }
    }
}