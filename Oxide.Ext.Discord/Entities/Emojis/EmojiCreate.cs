using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/emoji#create-guild-emoji-json-params">Emoji Create Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class EmojiCreate : IDiscordValidation
    {
        /// <summary>
        /// Emoji name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The 128x128 emoji image
        /// Emojis and animated emojis have a maximum file size of 256kb.
        /// Attempting to upload an emoji larger than this limit will fail and return 400 Bad Request
        /// </summary>
        [JsonProperty("image")]
        public DiscordImageData ImageData { get; set; }
        
        /// <summary>
        /// Roles this emoji is whitelisted to
        /// </summary>
        [JsonProperty("roles")]
        public List<Snowflake> Roles { get; set; }

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidEmojiException.ThrowIfInvalidName(Name, false);
            InvalidEmojiException.ThrowIfInvalidImageData(ImageData);
        }
    }
}