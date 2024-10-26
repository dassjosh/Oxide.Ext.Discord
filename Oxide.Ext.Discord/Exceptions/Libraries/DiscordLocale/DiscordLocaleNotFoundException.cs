using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exception thrown when Discord Locale is not found
    /// </summary>
    public class DiscordLocaleNotFoundException : BaseDiscordException
    {
        private DiscordLocaleNotFoundException(string message) : base(message) { }
        
        internal static DiscordLocaleNotFoundException NotFound(ServerLocale id) => new($"Failed to find discord locale for server locale '{id.Id}'");
        internal static void ThrowNotFound(ServerLocale id) => throw NotFound(id);
    }
}