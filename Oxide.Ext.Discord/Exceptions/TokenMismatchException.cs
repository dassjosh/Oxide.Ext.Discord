using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Connections;
using Oxide.Ext.Discord.Factory;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents a bot token mismatch
    /// </summary>
    public class TokenMismatchException : BaseDiscordException
    {
        private TokenMismatchException(string message) : base(message) { }

        internal static void ThrowIfMismatchedToken(DiscordClient client, BotConnection expected)
        {
            if (client.Connection.ApiToken != expected.ApiToken)
            {
                BotTokenData token = BotTokenFactory.Instance.CreateFromClient(client);
                throw new TokenMismatchException($"Failed to add client for plugin {client.PluginName}. Token {token.HiddenToken} does not match BotClient {expected.HiddenToken}");
            }
        }
    }
}