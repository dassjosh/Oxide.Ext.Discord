using System;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exception when a user has blocked receving messages from a bot
    /// </summary>
    public class BlockedUserException : BaseDiscordException
    {
        /// <summary>
        /// User who has blocked messages
        /// </summary>
        public readonly DiscordUser User;
        
        /// <summary>
        /// Time until we try sending a message again
        /// </summary>
        public readonly DateTime BlockedUntil;

        internal BlockedUserException(DiscordUser user, DateTime blockedUntil)
        {
            User = user;
            BlockedUntil = blockedUntil;
        }
    }
}