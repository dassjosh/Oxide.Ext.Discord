using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an invalid message
    /// </summary>
    public class InvalidMessageException : BaseDiscordException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        private InvalidMessageException(string message) : base(message)
        {
            
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="create">Message Create that caused the error</param>
        private InvalidMessageException(string message, BaseMessageCreate create) : base($"{message}\nBody:{JsonConvert.SerializeObject(create, Formatting.Indented)}")
        {
            
        }

        internal static void ThrowIfMissingRequiredField(BaseMessageCreate create)
        {
            if (string.IsNullOrEmpty(create.Content) 
                && (create.Embeds == null || create.Embeds.Count == 0) 
                && (create.FileAttachments == null || create.FileAttachments.Count == 0)
                && (create.StickerIds == null || create.StickerIds.Count == 0)
                && (create.Components == null || create.Components.Count == 0 || create.Components[0].Components.Count == 0)
                && create.Poll == null)
            {
                throw new InvalidMessageException("Discord Messages require either Content, An Embed, A Sticker, A Message Component, A File, or a Poll", create);
            }
        }
        
        internal static void ThrowIfInvalidContent(string content)
        {
            if (content != null && content.Length > 2000)
            {
                throw new InvalidMessageException("Content cannot be more than 2000 characters");
            }
        }

        internal static void ThrowIfMaxStickers(int? count)
        {
            if (count > 3)
            {
                throw new InvalidMessageException("Cannot have more than 3 stickers");
            }
        }

        internal static void ThrowIfInvalidFlags(MessageFlags? flags, MessageFlags allowedFlags, string message)
        {
            if (flags.HasValue && (flags & ~allowedFlags) != 0)
            {
                throw new InvalidMessageException(message);
            }
        }
        
        internal static void ThrowIfInvalidAttachmentDescription(string description)
        {
            if (!string.IsNullOrEmpty(description) && description.Length > 1024)
            {
                throw new InvalidMessageException("Message attachment description cannot be more than 1024 characters");
            }
        }

        internal static void ThrowIfCantBeDeleted(DiscordMessage message)
        {
            switch (message.Type)
            {
                case MessageType.RecipientAdd:
                case MessageType.RecipientRemove:
                case MessageType.Call:
                case MessageType.ChannelNameChange:
                case MessageType.ChannelIconChange:
                case MessageType.GuildDiscoveryDisqualified:
                case MessageType.GuildDiscoveryRequalified:
                case MessageType.GuildDiscoveryGracePeriodInitialWarning:
                case MessageType.GuildDiscoveryGracePeriodFinalWarning:
                case MessageType.ThreadStarterMessage:
                    throw new InvalidMessageException($"This message cannot be deleted because it is of type {message.Type}");
            }
        }
    }
}