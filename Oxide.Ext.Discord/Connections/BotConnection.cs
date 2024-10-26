using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Connections
{
    /// <summary>
    /// Bot Connection Settings
    /// </summary>
    public class BotConnection
    {
        /// <summary>
        /// API token for the bot
        /// </summary>
        public string ApiToken { get; set; }
        
        /// <summary>
        /// Intents that your bot needs to work
        /// See <see cref="GatewayIntents"/>
        /// </summary>
        public GatewayIntents Intents { get; set; }
        
        /// <summary>
        /// Discord Extension Logging Level.
        /// See <see cref="DiscordLogLevel"/>
        /// </summary>
        public DiscordLogLevel LogLevel { get; set; }

        /// <summary>
        /// Hidden Bot Token. Used when needing to display the token.
        /// </summary>
        public string HiddenToken => Token?.HiddenToken ?? "Unknown Token";
        
        /// <summary>
        /// Application ID of the Bot Token
        /// </summary>
        public Snowflake ApplicationId => Token?.ApplicationId ?? default(Snowflake);

        private BotTokenData Token { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public BotConnection() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public BotConnection(string apiToken, GatewayIntents intents = GatewayIntents.None)
        {
            ApiToken = apiToken;
            Intents = intents;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public BotConnection(string apiToken, GatewayIntents intents = GatewayIntents.None, DiscordLogLevel logLevel = DiscordLogLevel.Info) : this(apiToken, intents)
        {
            ApiToken = apiToken;
            Intents = intents;
            LogLevel = logLevel;
        }

        internal BotConnection(BotConnection connection) : this(connection.ApiToken, connection.Intents)
        {
            Token = connection.Token;
        }

        internal void Initialize(DiscordClient client)
        {
            Token ??= BotTokenFactory.Instance.CreateFromClient(client);
        }

        /// <summary>
        /// Returns if the settings have the given intents
        /// </summary>
        /// <param name="intents">Intents to be compared against</param>
        /// <returns>True if settings have the given intents; False otherwise</returns>
        public bool HasIntents(GatewayIntents intents) => (Intents & intents) == intents;

        /// <summary>
        /// Returns if the settings have any intent specified
        /// </summary>
        /// <param name="intents">Intents to compare against</param>
        /// <returns>True if settings have at least one of the given intents</returns>
        public bool HasAnyIntent(GatewayIntents intents) => (Intents & intents) != 0;
    }
}