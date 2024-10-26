using Oxide.Ext.Discord.Connections;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Rest;

namespace Oxide.Ext.Discord.Clients
{
    /// <summary>
    /// A client that can connect to a webhook
    /// </summary>
    public class WebhookClient : BaseClient, IDebugLoggable
    {
        /// <summary>
        /// Webhook that has been connected to
        /// </summary>
        public DiscordWebhook Webhook { get; private set; }

        internal readonly WebhookConnection Connection;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">Connection for the webhook</param>
        public WebhookClient(WebhookConnection connection)
        {
            Connection = connection;
            Rest = RestHandler.Global;
            Webhook = new DiscordWebhook
            {
                Id = connection.WebhookId,
                Token = connection.WebhookToken,
                Client = this
            };
            Initialized = true;
        }

        internal override void HandleConnect()
        {
            DiscordWebhook.GetWebhookWithToken(_clients[0], this, Connection.WebhookId, Connection.WebhookToken)
                .Then(webhook =>
                {
                    Webhook = webhook;
                    Webhook.Client = this;
                })
                .Catch(ex => Logger.Exception("An error occured connecting the webhook", ex));
        }

        ///<inheritdoc/>
        public override void AddClient(DiscordClient client)
        {
            if (!_clients.Contains(client))
            {
                base.AddClient(client);
            }
        }

        internal override void HandleShutdown()
        {
            Logger.Debug($"{nameof(WebhookClient)}.{nameof(HandleShutdown)} Shutting down the webhook");
            WebhookClientFactory.Instance.RemoveWebhook(this);
            Rest = null;
            Initialized = false;
        }
        
        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendField("Webhook ID", Connection.WebhookId);
            logger.AppendField("Initialized", Initialized);
            logger.AppendFieldEnum("Log Level", Logger.LogLevel);
            logger.AppendField("Plugins", GetClientPluginList());
        }
    }
}