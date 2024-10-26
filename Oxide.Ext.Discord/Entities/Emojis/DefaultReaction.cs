using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/channel#followed-channel-object">Default Reaction Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DefaultReaction
    {
        /// <summary>
        /// The id of a guild's custom emoji
        /// </summary>
        [JsonProperty("emoji_id")]
        public Snowflake? EmojiId { get; set; }

        /// <summary>
        /// The unicode character of the emoji
        /// </summary>
        [JsonProperty("emoji_name")]
        public string EmojiName { get; set; }
    }
}