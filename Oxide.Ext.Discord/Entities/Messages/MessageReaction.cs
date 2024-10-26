using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#reaction-object">Reaction Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageReaction
    {
        /// <summary>
        /// Total number of times this emoji has been used to react (including super reacts)
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        
        /// <summary>
        /// Reaction Count Details
        /// </summary>
        [JsonProperty("count_details")]
        public ReactionCountDetails CountDetails { get; set; }

        /// <summary>
        /// Whether the current user reacted using this emoji
        /// </summary>
        [JsonProperty("me")]
        public bool Me { get; set; }
        
        /// <summary>
        /// Whether the current user super-reacted using this emoji
        /// </summary>
        [JsonProperty("me_burst")]
        public bool MeBurst { get; set; }

        /// <summary>
        /// Emoji information
        /// <see cref="DiscordEmoji"/>
        /// </summary>
        [JsonProperty("emoji")]
        public DiscordEmoji Emoji { get; set; }
        
        /// <summary>
        /// HEX colors used for super reaction
        /// TODO: Find out the array type
        /// </summary>
        [JsonProperty("burst_colors")]
        public object[] BurstColors { get; set; }
    }
}