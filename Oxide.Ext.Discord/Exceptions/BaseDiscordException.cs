using System;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents a base discord extension
    /// </summary>
    public abstract class BaseDiscordException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseDiscordException() {}
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        protected BaseDiscordException(string message) : base($"Discord Extension Exception ({DiscordExtension.FullExtensionVersion}): {message}")
        {
            
        }
    }
}