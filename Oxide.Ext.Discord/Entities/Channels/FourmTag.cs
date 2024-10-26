using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#forum-tag-object">Forum Tag Structure</a>
    /// An object that represents a tag that is able to be applied to a thread in a `GUILD_FORUM` or `GUILD_MEDIA` channel.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ForumTag : ISnowflakeEntity, IDiscordValidation
    {
        /// <summary>
        /// The id of the tag
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// The name of the tag (0-20 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Whether this tag can only be added to or removed from threads by a member with the MANAGE_THREADS permission
        /// </summary>
        [JsonProperty("moderated")]
        public bool Moderated { get; set; }
        
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

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidForumTagException.ThrowIfInvalidName(Name);
        }
    }
}