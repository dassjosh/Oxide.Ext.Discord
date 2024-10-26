using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#ready">Ready</a>
    /// The ready event is dispatched when a client has completed the initial handshake with the gateway (for new sessions)
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GatewayReadyEvent
    {
        /// <summary>
        /// Gateway version
        /// See <a href="https://discord.com/developers/docs/topics/gateway#gateways-gateway-versions">Gateway Version</a>
        /// </summary>
        [JsonProperty("v")]
        public int Version { get; set; }
        
        /// <summary>
        /// Information about the user including email
        /// See <see cref="DiscordUser"/>
        /// </summary>
        [JsonProperty("user")]
        public DiscordUser User { get; set; }

        /// <summary>
        /// The guilds the user is in
        /// </summary>
        [JsonProperty("guilds")]
        [JsonConverter(typeof(HashListConverter<DiscordGuild>))]
        public Hash<Snowflake, DiscordGuild> Guilds { get; set; }

        /// <summary>
        /// Used for resuming connections
        /// </summary>
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
        
        /// <summary>
        /// Websocket URL to use when resuming the session
        /// </summary>
        [JsonProperty("resume_gateway_url")]
        public string ResumeSessionUrl { get; set; }

        /// <summary>
        /// The shard information associated with this session, if sent when identifying
        /// </summary>
        [JsonProperty("shard")]
        public List<int> Shard { get; set; }
        
        /// <summary>
        /// Contains id and flags
        /// See <see cref="DiscordApplication"/>
        /// </summary>
        [JsonProperty("application")]
        public DiscordApplication Application { get; set; }
    }
}