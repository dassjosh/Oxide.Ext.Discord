using System;
using System.Collections.Generic;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Connections;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Factory
{
    internal sealed class BotClientFactory : Singleton<BotClientFactory>
    {
        /// <summary>
        /// List of active bots by bot API key
        /// </summary>
        private readonly Hash<string, BotClient> _activeBots = new();
        private readonly Hash<Snowflake, BotClient> _applicationBots = new();
        
        public IEnumerable<BotClient> Clients => _activeBots.Values;
        
        private BotClientFactory() {}

        /// <summary>
        /// Gets or creates a new bot client for the given discord client
        /// </summary>
        /// <param name="client">Client to use for creating / loading the bot client</param>
        /// <param name="connection">Connection for the bot</param>
        /// <returns>Bot client that is created or already exists</returns>
        public BotClient InitializeBotClient(DiscordClient client, BotConnection connection)
        {
            try
            {
                BotClient bot = _activeBots[connection.ApiToken];
                if (bot == null)
                {
                    DiscordExtension.GlobalLogger.Debug($"{nameof(BotClientFactory)}.{nameof(InitializeBotClient)} Creating new BotClient");
                    bot = new BotClient(connection);
                    _activeBots[connection.ApiToken] = bot;
                    _applicationBots[connection.ApplicationId] = bot;
                }
                
                DiscordExtension.GlobalLogger.Debug($"{nameof(BotClientFactory)}.{nameof(InitializeBotClient)} Adding {{0}} client to bot {{1}}", client.PluginName, bot.BotUser?.FullUserName);
                return bot;
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception($"{nameof(BotClientFactory)}.{nameof(InitializeBotClient)} An error occured adding {{0}} client", client.PluginName, ex);
                return null;
            }
        }

        internal BotClient GetByApplicationId(Snowflake appId)
        {
            return _applicationBots[appId];
        }

        public void RemoveBot(BotClient bot)
        {
            _activeBots.Remove(bot.Connection.ApiToken);
        }

        public void ResetAllWebSockets()
        {
            foreach (BotClient client in _activeBots.Values)
            {
                client.ResetWebSocket();
            }
        }
        
        public void ReconnectAllWebSockets()
        {
            foreach (BotClient client in _activeBots.Values)
            {
                client.WebSocket.Disconnect(true, true, true);
            }
        }

        public void ResetAllRestApis()
        {
            foreach (BotClient client in _activeBots.Values)
            {
                client.ResetRestApi();
            }
        }

        public void UpdateLogLevel()
        {
            foreach (BotClient client in _activeBots.Values)
            {
                client.UpdateLogLevel(DiscordLoggerFactory.Instance.GetLogLevel());
            }
        }
    }
}