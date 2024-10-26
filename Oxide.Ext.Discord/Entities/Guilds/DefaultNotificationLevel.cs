using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-object-default-message-notification-level">Default Message Notification Level</a>
    /// </summary>
    public enum DefaultNotificationLevel : byte
    {
        /// <summary>
        /// Notify for all guild messages
        /// </summary>
        [DiscordEnum("ALL_MESSAGES")]
        AllMessages = 0,
        
        /// <summary>
        /// Notify for only mentions
        /// </summary>
        [DiscordEnum("ONLY_MENTIONS")]
        OnlyMentions = 1
    }
}