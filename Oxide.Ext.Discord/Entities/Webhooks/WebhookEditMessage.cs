using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/webhook#edit-webhook-message-jsonform-params">Webhook Edit Message Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WebhookEditMessage : IFileAttachments, IDiscordValidation, IDiscordMessageTemplate
    {
        /// <summary>
        /// The message contents (up to 2000 characters)
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
        
        /// <summary>
        /// Embedded rich content (Up to 10 embeds)
        /// </summary>
        [JsonProperty("embeds")]
        public List<DiscordEmbed> Embeds { get; set; }
        
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
        /// Adds a new embed to the list of embed to send
        /// </summary>
        /// <param name="embed">Embed to add</param>
        /// <returns>This</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if more than 10 embeds are added in a send as that is the discord limit</exception>
        public WebhookEditMessage AddEmbed(DiscordEmbed embed)
        {
            if (Embeds == null) Embeds = new List<DiscordEmbed>();
            if (Embeds.Count >= 10) throw new IndexOutOfRangeException("Only 10 embed are allowed per message");

            Embeds.Add(embed);
            return this;
        }

        /// <summary>
        /// Adds an attachment to the message
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <param name="data">byte[] of the attachment</param>
        /// <param name="contentType">Attachment content type</param>
        /// <param name="description">Description for the attachment</param>
        /// <param name="title">Title of the attachment</param>
        public void AddAttachment(string filename, byte[] data, string contentType, string description = null, string title = null)
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
            Attachments.Add(new MessageAttachment {Id = new Snowflake((ulong)FileAttachments.Count), Filename = filename, Description = description, Title = title});
        }

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidMessageException.ThrowIfInvalidContent(Content);
        }
    }
}