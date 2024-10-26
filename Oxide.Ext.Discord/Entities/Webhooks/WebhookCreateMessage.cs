using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/webhook#execute-webhook-jsonform-params">Webhook Create Message</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WebhookCreateMessage : MessageCreate
    {
        /// <summary>
        /// Override the default username of the webhook
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Override the default avatar of the webhook
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        
        /// <summary>
        /// Name of thread to create
        /// Requires the webhook channel to be a forum channel
        /// </summary>
        [JsonProperty("thread_name")]
        public string ThreadName { get; set; }
        
        /// <summary>
        /// Array of tag ids to apply to the thread
        /// requires the webhook channel to be a forum or media channel
        /// </summary>
        [JsonProperty("applied_tags")]
        public List<Snowflake> AppliedTags { get; set; }

        /// <inheritdoc/>
        protected override void ValidateFlags()
        {
            InvalidMessageException.ThrowIfInvalidFlags(Flags, MessageFlags.SuppressEmbeds | MessageFlags.SuppressNotifications, "Invalid Message Flags Used for Webhook Message. Only supported flags are MessageFlags.SuppressEmbeds and MessageFlags.SuppressNotifications");
        }
    }
}