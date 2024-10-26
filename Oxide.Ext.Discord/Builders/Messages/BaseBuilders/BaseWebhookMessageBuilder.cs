using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Represents a builder for <see cref="WebhookCreateMessage"/>
    /// </summary>
    /// <typeparam name="TMessage">Type of the message</typeparam>
    /// <typeparam name="TBuilder">Type of the builder</typeparam>
    public abstract class BaseWebhookMessageBuilder<TMessage, TBuilder> : BaseChannelMessageBuilder<TMessage, TBuilder>
        where TMessage : WebhookCreateMessage
        where TBuilder : BaseChannelMessageBuilder<TMessage, TBuilder>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message being created</param>
        protected BaseWebhookMessageBuilder(TMessage message) : base(message) { }
        
        /// <summary>
        /// Adds a custom username for the sender
        /// </summary>
        /// <param name="userName">Username to be displayed as the sender</param>
        /// <returns>This</returns>
        public TBuilder AddUserName(string userName)
        {
            InvalidUserException.ThrowIfInvalidUserName(userName);
            Message.Username = userName;
            return Builder;
        }
        
        /// <summary>
        /// Adds a custom avatar url for the sender
        /// </summary>
        /// <param name="avatarUrl">Avatar URL to be displayed for the sender</param>
        /// <returns>This</returns>
        public TBuilder AddAvatarUrl(string avatarUrl)
        {
            Message.AvatarUrl = avatarUrl;
            return Builder;
        }
    }
}