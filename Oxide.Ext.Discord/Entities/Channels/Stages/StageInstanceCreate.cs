using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a> href="https://discord.com/developers/docs/resources/stage-instance#create-stage-instance-json-params">Stage Instance Create Structure</a>
    /// </summary>
    public class StageInstanceCreate
    {
        /// <summary>
        /// The id of the Stage channel
        /// </summary>
        [JsonProperty("channel_id")]
        public Snowflake ChannelId { get; set; }
        
        /// <summary>
        /// The topic of the Stage instance (1-120 characters)
        /// </summary>
        [JsonProperty("topic")]
        public string Topic { get; set; }
        
        /// <summary>
        /// The privacy level of the Stage instance (default GUILD_ONLY)
        /// </summary>
        [JsonProperty("privacy_level")]
        public PrivacyLevel PrivacyLevel { get; set; }
        
        /// <summary>
        /// Notify @everyone that a Stage instance has started
        /// The stage moderator must have the MENTION_EVERYONE permission for this notification to be sent.
        /// </summary>
        [JsonProperty("send_start_notification")]
        public bool SendStartNotification { get; set; }
        
        /// <summary>
        /// The guild scheduled event associated with this Stage instance  
        /// </summary>
        [JsonProperty("guild_scheduled_event_id")]
        public Snowflake GuildScheduledEventId { get; set; }
    }
}