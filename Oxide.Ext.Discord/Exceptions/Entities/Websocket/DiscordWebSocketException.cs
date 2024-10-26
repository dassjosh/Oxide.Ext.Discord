namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception that occured with the websocket
    /// </summary>
    public class DiscordWebSocketException : BaseDiscordException
    {
        internal DiscordWebSocketException(string message) : base(message) { }
    }
}