using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/voice#voice-region-object">Voice Region Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class VoiceRegion
    {
        /// <summary>
        /// Unique ID for the region
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }

        /// <summary>
        /// Name of the region
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// True for a single server that is closest to the current user's client
        /// </summary>
        [JsonProperty("optimal")]
        public bool Optimal { get; set; }

        /// <summary>
        /// Whether this is a deprecated voice region (avoid switching to these)
        /// </summary>
        [JsonProperty("deprecated")]
        public bool Deprecated { get; set; }

        /// <summary>
        /// Whether this is a custom voice region (used for events/etc)
        /// </summary>
        [JsonProperty("custom")]
        public bool Custom { get; set; }

        /// <summary>
        /// Returns an array of voice region objects that can be used when creating servers.
        /// See <a href="https://discord.com/developers/docs/resources/voice#list-voice-regions">List Voice Regions</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public static IPromise<List<VoiceRegion>> ListVoiceRegions(DiscordClient client)
        {
            return client.Bot.Rest.Get<List<VoiceRegion>>(client,"voice/regions");
        }
    }
}