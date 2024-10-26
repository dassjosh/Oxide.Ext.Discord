using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#message-call-object">Message Call Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageCall
    {
        /// <summary>
        /// Array of user ids that participated in the call
        /// </summary>
        [JsonProperty("participants")]
        public List<Snowflake> Participants { get; set; }
        
        /// <summary>
        /// Time when call ended   
        /// </summary>
        [JsonProperty("ended_timestamp")]
        public DateTimeOffset? EndedTimestamp { get; set; }
    }
}