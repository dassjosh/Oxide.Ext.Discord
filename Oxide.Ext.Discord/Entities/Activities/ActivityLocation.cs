using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/application#get-application-activity-instance-activity-location-object">Activity Location</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ActivityLocation
    {
        /// <summary>
        /// The unique identifier for the location
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    
        /// <summary>
        /// Enum describing kind of location
        /// </summary>
        [JsonProperty("kind")]
        public ActivityLocationKind Kind { get; set; }
    
        /// <summary>
        /// The ID of the Channel
        /// </summary>
        [JsonProperty("channel_id")]
        public Snowflake ChannelId { get; set; }
    
        /// <summary>
        /// The ID of the Guild
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake? GuildId { get; set; }
    
    }
}