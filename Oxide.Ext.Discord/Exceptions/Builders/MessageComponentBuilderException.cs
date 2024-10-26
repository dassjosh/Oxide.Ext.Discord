using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in Message Component Builder
    /// </summary>
    public class MessageComponentBuilderException : BaseDiscordException
    {
        private MessageComponentBuilderException(string message) : base(message) { }
        
        internal static void ThrowIfInvalidActionButtonStyle(ButtonStyle style)
        {
            if (style == ButtonStyle.Link)
            {
                throw new MessageComponentBuilderException($"Cannot add link button as action button. Please use {nameof(MessageComponentBuilder.AddLinkButton)} instead");
            }
        }
    }
}