using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#message-reaction-add">Message Reaction Add</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageReactionAddedEvent
    {
        /// <summary>
        /// The id of the user
        /// </summary>
        [JsonProperty("user_id")]
        public Snowflake UserId { get; set; }

        /// <summary>
        /// The id of the channel
        /// </summary>
        [JsonProperty("channel_id")]
        public Snowflake ChannelId { get; set; }

        /// <summary>
        /// The id of the message
        /// </summary>
        [JsonProperty("message_id")]
        public Snowflake MessageId { get; set; }
        
        /// <summary>
        /// The id of the guild
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake? GuildId { get; set; }
        
        /// <summary>
        /// The member who reacted if this happened in a guild
        /// </summary>
        [JsonProperty("member")]
        public GuildMember Member { get; set; }

        /// <summary>
        /// The emoji used to react
        /// </summary>
        [JsonProperty("emoji")]
        public DiscordEmoji Emoji { get; set; }
        
        /// <summary>
        /// ID of the user who authored the message which was reacted to
        /// </summary>
        [JsonProperty("message_author_id")]
        public Snowflake? MessageAuthorId { get; set; }
        
        /// <summary>
        /// True if this is a super-reaction 
        /// </summary>
        [JsonProperty("burst")]
        public bool Burst { get; set; }
        
        /// <summary>
        /// Colors used for super-reaction animation
        /// </summary>
        [JsonProperty("burst_colors")]
        public List<DiscordColor> BurstColors { get; set; }
        
        /// <summary>
        /// The type of the reaction
        /// </summary>
        [JsonProperty("type")]
        public ReactionType Type { get; set; }
    }
}