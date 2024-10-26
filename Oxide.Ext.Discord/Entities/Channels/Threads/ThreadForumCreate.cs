using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#start-thread-in-forum-channel-jsonform-params">Start Thread in Forum Channel</a> Structure
    /// </summary>
    public class ThreadForumCreate : IFileAttachments
    {
        /// <summary>
        /// 1-100 character thread name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } 
        
        /// <summary>
        /// Duration in minutes to automatically archive the thread after recent activity, can be set to: 60, 1440, 4320, 10080
        /// </summary>
        [JsonProperty("auto_archive_duration")]
        public int? AutoArchiveDuration { get; set; }

        /// <summary>
        /// Amount of seconds a user has to wait before sending another message (0-21600)
        /// </summary>
        [JsonProperty("rate_limit_per_user")]
        public int? RateLimitPerUser { get; set; }
        
        /// <summary>
        /// Contents of the first message in the forum thread
        /// </summary>
        [JsonProperty("message")]
        public MessageCreate Message { get; set; }
        
        /// <summary>
        /// The IDs of the set of tags that have been applied to a thread in a GUILD_FORUM or GUILD_MEDIA channel
        /// </summary>
        [JsonProperty("applied_tags")]
        public List<Snowflake> AppliedTags { get; set; }
        
        /// <summary>
        /// Attachments for a discord message
        /// </summary>
        public List<MessageFileAttachment> FileAttachments { get; set; }
        
        /// <summary>
        /// Attachments for the message
        /// </summary>
        [JsonProperty("attachments")]
        public List<MessageAttachment> Attachments { get; set; }

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
        
        /// <summary>
        /// Validates the Thread Forum Create
        /// </summary>
        public void Validate()
        {
            InvalidChannelException.ThrowIfInvalidName(Name, false);
            InvalidChannelException.ThrowIfInvalidRateLimitPerUser(RateLimitPerUser);
            InvalidThreadException.ThrowIfInvalidAutoArchiveDuration(AutoArchiveDuration);
            InvalidThreadException.ThrowIfInvalidForumCreateMessage(Message);
            Message.Validate();
        }
    }
}