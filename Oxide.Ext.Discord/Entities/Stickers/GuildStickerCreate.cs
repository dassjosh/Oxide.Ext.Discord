using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/sticker#sticker-pack-object">Sticker Pack Object</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GuildStickerCreate : IFileAttachments, IDiscordValidation 
    {
        /// <summary>
        /// Name of the sticker (2-30 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Description of the sticker (empty or 2-100 characters)
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Autocomplete/suggestion tags for the sticker (max 200 characters)
        /// Each tag should be seperated by a command and space IE ', ' 
        /// </summary>
        [JsonProperty("tags")]
        public string Tags { get; set; }
        
        /// <summary>
        /// Sticker image attachment
        /// </summary>
        public List<MessageFileAttachment> FileAttachments { get; set; }

        /// <summary>
        /// Adds the sticker for guild sticker create
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="contentType">Content type of the file</param>
        /// <param name="sticker">sticker image bytes</param>
        /// <exception cref="Exception">
        /// Throw if more than 1 sticker is added.
        /// Thrown if the data is more than 500KB
        /// Thrown if the file extension is not .png, .apng, .gif, or .json
        /// </exception>
        public void AddSticker(string fileName, string contentType, byte[] sticker)
        {
            if (FileAttachments == null)
            {
                FileAttachments = new List<MessageFileAttachment>();
            }
            
            InvalidGuildStickerException.ThrowIfMoreThanOneImage(FileAttachments.Count);
            InvalidGuildStickerException.ThrowIfImageTooLarge(sticker);
            InvalidGuildStickerException.ThrowIfInvalidFileExtension(fileName);

            FileAttachments.Add(new MessageFileAttachment(fileName, sticker, contentType));
        }

        /// <inheritdoc/>
        public void Validate()
        {
            InvalidGuildStickerException.ThrowIfInvalidName(Name, false);
            InvalidGuildStickerException.ThrowIfInvalidDescription(Description, false);
        }
    }
}