using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception for channel threads
    /// </summary>
    public class InvalidThreadException : BaseDiscordException
    {
        private InvalidThreadException(string message) : base(message) { }

        internal static void ThrowIfInvalidAutoArchiveDuration(int? autoArchiveDuration)
        {
            if (!autoArchiveDuration.HasValue)
            {
                return;
            }
            
            switch (autoArchiveDuration.Value)
            {
                case 60:
                case 1440:
                case 4320:
                case 10080:
                    break;
                default:
                    throw new InvalidThreadException("AutoArchiveDuration must be one of 60, 1440, 4320, or 10080");
            }
        }

        internal static void ThrowIfInvalidChannelType(ChannelType type)
        {
            switch (type)
            {
                case ChannelType.GuildNewsThread:
                case ChannelType.GuildPublicThread:
                case ChannelType.GuildPrivateThread:
                    break;
                
                default:
                    throw new InvalidThreadException("Type must be one of GuildNewsThread, GuildPublicThread, or GuildPrivateThread");
            }
        }

        internal static void ThrowIfInvalidForumCreateMessage(MessageCreate create)
        {
            if (create == null)
            {
                throw new InvalidThreadException("Message cannot be null for ThreadForumCreate");
            }
        }
    }
}