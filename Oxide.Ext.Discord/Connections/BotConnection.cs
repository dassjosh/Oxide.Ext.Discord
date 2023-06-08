﻿using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Entities.Gateway;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Connections
{
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
        /// See <see cref="LogLevel"/>
        /// </summary>
        public DiscordLogLevel LogLevel { get; set; }

        public string HiddenToken => Token?.HiddenToken ?? "Unknown Token";
        public Snowflake ApplicationId => Token?.ApplicationId ?? default(Snowflake);

        internal BotTokenData Token { get; set; }
        
        public BotConnection() { }

        public BotConnection(string apiToken, GatewayIntents intents = GatewayIntents.None, DiscordLogLevel logLevel = DiscordLogLevel.Info)
        {
            ApiToken = apiToken;
            Intents = intents;
            LogLevel = logLevel;
        }

        internal BotConnection(BotConnection connection) : this(connection.ApiToken, connection.Intents, connection.LogLevel)
        {
            Token = connection.Token;
        }

        internal void Initialize(DiscordClient client)
        {
            if (Token == null)
            {
                Token = BotTokenFactory.Instance.CreateFromClient(client);
            }
        }

        /// <summary>
        /// Returns if the settings has the given intents
        /// </summary>
        /// <param name="intents">Intents to be compared against</param>
        /// <returns>True if settings has the given intents; False otherwise</returns>
        public bool HasIntents(GatewayIntents intents) => (Intents & intents) == intents;

        /// <summary>
        /// Returns if the settings has any intent specified
        /// </summary>
        /// <param name="intents">Intents to compare against</param>
        /// <returns>True if settings has at least one of the given intents</returns>
        public bool HasAnyIntent(GatewayIntents intents) => (Intents & intents) != 0;
    }
}