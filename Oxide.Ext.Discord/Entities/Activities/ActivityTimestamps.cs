using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#activity-object-activity-timestamps">Activity Timestamps</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ActivityTimestamps
    {
        /// <summary>
        /// Unix time (in milliseconds) of when the activity started
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }
        
        /// <summary>
        /// Unix time (in milliseconds) of when the activity ends
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }
    }
}