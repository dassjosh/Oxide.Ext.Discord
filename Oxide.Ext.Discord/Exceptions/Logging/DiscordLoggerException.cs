using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exceptions for the <see cref="DiscordClient"/>
    /// </summary>
    public class DiscordLoggerException : BaseDiscordException
    {
        private DiscordLoggerException(string message) : base(message) {}

        internal static void ThrowIfShutdown(DiscordLogHandler handler)
        {
            if (handler.IsShutdown)
            {
                throw new DiscordLoggerException("Cannot log into a logger that has been shutdown!");
            }
        }
    }
}