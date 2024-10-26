using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#edit-message-jsonform-params">Message Update Structure</a> sent in a channel within Discord..
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageUpdate : IFileAttachments, IDiscordValidation, IDiscordMessageTemplate
    {
        /// <summary>
        /// Contents of the message up to 2000 characters
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
        
        /// <summary>
        /// Up to 10 rich embeds (up to 6000 characters)
        /// </summary>
        [JsonProperty("embeds")]
        public List<DiscordEmbed> Embeds { get; set; }
        
        /// <summary>
        /// Edit the flags of a message (only SUPPRESS_EMBEDS can currently be set/unset)
        /// </summary>
        [JsonProperty("flags")]
        public MessageFlags? Flags { get; set; }
        
        /// <summary>
        /// Allowed mentions for the message
        /// </summary>
        [JsonProperty("allowed_mentions")]
        public AllowedMentions AllowedMentions { get; set; }
        
        /// <summary>
        /// Components to include with the message
        /// </summary>
        [JsonProperty("components")]
        public List<ActionRowComponent> Components { get; set; }

        /// <summary>
        /// Attachments for the message
        /// </summary>
        [JsonProperty("attachments")]
        public List<MessageAttachment> Attachments { get; set; }
        
        /// <summary>
        /// Attachments for a discord message
        /// </summary>
        public List<MessageFileAttachment> FileAttachments { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MessageUpdate() { }

        /// <summary>
        /// Constructor for message to be edited
        /// Only sets the Attachments field
        /// </summary>
        /// <param name="message"></param>
        public MessageUpdate(DiscordMessage message)
        {
            Attachments = message.Attachments?.Values.ToList();
        }
        
        /// <summary>
        /// Adds an attachment to the message
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <param name="data">byte[] of the attachment</param>
        /// <param name="contentType">Attachment content type</param>
        /// <param name="description">Description for the attachment</param>
        public void AddAttachment(string filename, byte[] data, string contentType, string description = null)
        {
            InvalidFileNameException.ThrowIfInvalid(filename);
            InvalidMessageException.ThrowIfInvalidAttachmentDescription(description);

            if (FileAttachments == null)
            {
                FileAttachments = new List<MessageFileAttachment>();
            }

            if (Attachments == null)
            {
                Attachments = new List<MessageAttachment>();
            }

            FileAttachments.Add(new MessageFileAttachment(filename, data, contentType));
            Attachments.Add(new MessageAttachment {Id = new Snowflake((ulong)FileAttachments.Count), Filename = filename, Description = description});
        }
        
        ///<inheritdoc/>
        public void Validate()
        {
            InvalidMessageException.ThrowIfInvalidContent(Content);
            InvalidMessageException.ThrowIfInvalidFlags(Flags, MessageFlags.SuppressEmbeds, "Invalid Message Flags Used for Channel Message. Only supported flags are MessageFlags.SuppressEmbeds");
        }
    }
}