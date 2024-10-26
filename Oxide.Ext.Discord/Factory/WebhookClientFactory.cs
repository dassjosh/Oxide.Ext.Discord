using System;
using System.Collections.Generic;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Connections;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Factory
{
    internal sealed class WebhookClientFactory : Singleton<WebhookClientFactory>
    {
        /// <summary>
        /// List of active bots by bot API key
        /// </summary>
        private readonly Hash<string, WebhookClient> _activeWebhooks = new();
        
        public IEnumerable<WebhookClient> Clients => _activeWebhooks.Values;
        
        private WebhookClientFactory() {}

        /// <summary>
        /// Gets or creates a new bot client for the given discord client
        /// </summary>
        /// <param name="client">Client to use for creating / loading the bot client</param>
        /// <param name="connection">Connection for the webhook</param>
        /// <returns>Bot client that is created or already exists</returns>
        public WebhookClient InitializeWebhookClient(DiscordClient client, WebhookConnection connection)
        {
            try
            {
                WebhookClient bot = _activeWebhooks[connection.WebhookToken];
                if (bot == null)
                {
                    DiscordExtension.GlobalLogger.Debug($"{nameof(WebhookClientFactory)}.{nameof(InitializeWebhookClient)} Creating new ${nameof(WebhookClient)}");
                    bot = new WebhookClient(connection);
                    _activeWebhooks[connection.WebhookToken] = bot;
                }
                
                DiscordExtension.GlobalLogger.Debug($"{nameof(WebhookClientFactory)}.{nameof(InitializeWebhookClient)} Adding {{0}} client to webhook {{1}}", client.PluginName, connection.WebhookId);
                return bot;
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception($"{nameof(WebhookClientFactory)}.{nameof(InitializeWebhookClient)} An error occured adding {{0}} client", client.PluginName, ex);
                return null;
            }
        }

        public void RemoveWebhook(WebhookClient client)
        {
            _activeWebhooks.Remove(client.Connection.WebhookToken);
        }

        public void UpdateLogLevel()
        {
            foreach (WebhookClient client in _activeWebhooks.Values)
            {
                client.UpdateLogLevel(DiscordLoggerFactory.Instance.GetLogLevel());
            }
        }
    }
}