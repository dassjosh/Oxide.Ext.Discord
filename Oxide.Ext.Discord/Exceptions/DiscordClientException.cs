using Oxide.Ext.Discord.Clients;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exceptions for the <see cref="DiscordClient"/>
    /// </summary>
    public class DiscordClientException : BaseDiscordException
    {
        private DiscordClientException(string message) : base(message) {}

        internal static DiscordClientException NotConnected() => new("DiscordClient is not connected.");
    }
}