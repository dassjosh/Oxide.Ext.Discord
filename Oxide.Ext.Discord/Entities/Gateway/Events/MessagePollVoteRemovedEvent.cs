using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway-events#message-poll-vote-remove">Message Poll Vote Removed Event</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessagePollVoteRemovedEvent
    {
        /// <summary>
        /// ID of the user
        /// </summary>
        [JsonProperty("user_id")]
        public Snowflake UserId { get; set; }

        /// <summary>
        /// The id of the channel
        /// </summary>
        [JsonProperty("channel_id")]
        public Snowflake ChannelId { get; set; }
        
        /// <summary>
        /// ID of the message
        /// </summary>
        [JsonProperty("message_id")]
        public Snowflake MessageId { get; set; }
        
        /// <summary>
        /// ID of the guild
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake? GuildId { get; set; }
        
        /// <summary>
        /// ID of the answer
        /// </summary>
        [JsonProperty("answer_id")]
        public int AnswerId { get; set; }
    }
}