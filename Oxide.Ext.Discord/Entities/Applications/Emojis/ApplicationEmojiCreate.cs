using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/emoji#create-application-emoji-json-params">Application Emoji Create Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApplicationEmojiCreate : IDiscordValidation
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

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidEmojiException.ThrowIfInvalidName(Name, false);
            InvalidEmojiException.ThrowIfInvalidImageData(ImageData);
        }
    }
}