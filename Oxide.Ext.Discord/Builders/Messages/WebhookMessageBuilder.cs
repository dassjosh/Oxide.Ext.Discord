using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Represents a builder for <see cref="WebhookMessageBuilder"/>
    /// </summary>
    public class WebhookMessageBuilder : BaseWebhookMessageBuilder<WebhookCreateMessage, WebhookMessageBuilder>
    {
        /// <summary>
        /// Constructor for creating a new WebhookCreateMessage
        /// </summary>
        public WebhookMessageBuilder() : this(new WebhookCreateMessage()) { }
        
        /// <summary>
        /// Constructor for using an existing WebhookCreateMessage
        /// </summary>
        /// <param name="message">Message to use</param>
        public WebhookMessageBuilder(WebhookCreateMessage message) : base(message) { }
    }
}