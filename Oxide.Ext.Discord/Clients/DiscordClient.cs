using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Connections;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Clients
{
    /// <summary>
    /// Represents the object a plugin uses to connect to discord
    /// </summary>
    public class DiscordClient
    {
        /// <summary>
        /// Which plugin is the owner of this client
        /// </summary>
        public Plugin Plugin { get; private set; }

        /// <summary>
        /// The ID of the plugin
        /// </summary>
        public readonly PluginId PluginId;
        
        /// <summary>
        /// The full plugin name including author and version
        /// </summary>
        public readonly string PluginName;
        
        /// <summary>
        /// The bot client that is unique to the Token used
        /// </summary>
        public BotClient Bot { get; private set; }
    
        private readonly List<WebhookClient> _webhooks = new();

        /// <summary>
        /// Webhook clients for this DiscordClient
        /// </summary>
        public readonly IReadOnlyList<WebhookClient> Webhooks;
    
        public JsonSerializerSettings JsonSettings => Bot?.JsonSettings ?? DiscordJson.Settings;
        
        /// <summary>
        /// Settings used to connect to discord and configure the extension
        /// </summary>
        internal BotConnection Connection { get; private set; }

        internal ILogger Logger;

        internal PluginSetup PluginSetup { get; private set; }

        /// <summary>
        /// Constructor for a discord client
        /// </summary>
        /// <param name="plugin">Plugin that will own this discord client</param>
        internal DiscordClient(Plugin plugin)
        {
            Plugin = plugin;
            PluginExt.OnPluginLoaded(Plugin);
            PluginId = plugin.Id();
            PluginName = plugin.FullName();
            Webhooks = new ReadOnlyCollection<WebhookClient>(_webhooks);
            BaseDiscordLibrary.ProcessPluginLoaded(this);
        }
        
        /// <summary>
        /// Starts a connection to discord with the given apiKey and intents
        /// </summary>
        /// <param name="apiKey">API key for the connecting bot</param>
        /// <param name="intents">Intents the bot needs to function</param>
        public void Connect(string apiKey, GatewayIntents intents) => Connect(new BotConnection(apiKey, intents));

        /// <summary>
        /// Starts a connection to discord with the given discord settings
        /// </summary>
        /// <param name="connection">Discord connection settings</param>
        public void Connect(BotConnection connection)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            Logger ??= DiscordLoggerFactory.Instance.CreateExtensionLogger(connection.LogLevel);
            
            if (string.IsNullOrEmpty(Connection.ApiToken))
            {
                Logger.Error("API Token is null or empty!");
                return;
            }

            if (!string.IsNullOrEmpty(DiscordExtension.TestVersion))
            {
                Logger.Warning("Using Discord Test Version: {0}", DiscordExtension.FullExtensionVersion);
            }

            Logger.Debug($"{nameof(DiscordClient)}.{nameof(Connect)} Bot connect for {{0}}", Plugin.FullName());

            Connection.Initialize(this);
            PluginSetup = new PluginSetup(Plugin, Logger);
            BaseDiscordLibrary.ProcessBotConnection(this);
            Bot = BotClientFactory.Instance.InitializeBotClient(this, Connection);
            Bot.AddClient(this);
        }

        /// <summary>
        /// Connect to the webhook
        /// </summary>
        /// <param name="webhookUrl">Webhook URL to connect to</param>
        public WebhookClient Connect(string webhookUrl) => Connect(new WebhookConnection(webhookUrl));
        
        /// <summary>
        /// Connect to the webhook
        /// </summary>
        /// <param name="connection">Webhook connection to connect to</param>
        public WebhookClient Connect(WebhookConnection connection)
        {
            Logger ??= DiscordLoggerFactory.Instance.CreateExtensionLogger(connection.LogLevel);
        
            if (string.IsNullOrEmpty(connection.WebhookUrl) || !connection.WebhookUrl.StartsWith("https://discord.com/api/webhooks/"))
            {
                Logger.Debug("Skipping Webhook connect. Webhook URL is null, empty, or invalid: {0}", connection.WebhookUrl);
                return null;
            }
        
            if (string.IsNullOrEmpty(connection.WebhookToken))
            {
                Logger.Error("Failed to parse Webhook token from webhook URL: {0}", connection.WebhookUrl);
                return null;
            }
        
            if (connection.WebhookId == default)
            {
                Logger.Error("Failed to parse webhook ID from webhook URL: {0}", connection.WebhookUrl);
                return null;
            }
        
            if (!string.IsNullOrEmpty(DiscordExtension.TestVersion))
            {
                Logger.Warning("Using Discord Test Version: {0}", DiscordExtension.FullExtensionVersion);
            }
            
            Logger.Debug($"{nameof(DiscordClient)}.{nameof(Connect)} Webhook connect for {{0}}", Plugin.FullName());
            
            WebhookClient client = WebhookClientFactory.Instance.InitializeWebhookClient(this, connection);
            client.AddClient(this);
            _webhooks.Add(client);
            return client;
        }

        /// <summary>
        /// Disconnects this client from discord
        /// </summary>
        public void Disconnect()
        {
            Bot?.RemoveClient(this);
            Bot = null;
            for (int index = _webhooks.Count - 1; index >= 0; index--)
            {
                WebhookClient client = _webhooks[index];
                client.RemoveClient(this);
                _webhooks.RemoveAt(index);
            }
        }

        /// <summary>
        /// Returns if the client is connected to a bot / webhook and if the bot / webhook is initialized
        /// </summary>
        /// <returns></returns>
        public bool IsConnected() => Bot?.Initialized ?? _webhooks.Any(w => w.Initialized);

        #region Websocket Commands
        /// <summary>
        /// Used to request guild members from discord for a specific guild
        /// </summary>
        /// <param name="request">Request for guild members</param>
        public void RequestGuildMembers(GuildMembersRequestCommand request) => Bot?.SendWebSocketCommand(this, GatewayCommandCode.RequestGuildMembers, request);

        /// <summary>
        /// Used to update the voice state for the bot
        /// </summary>
        /// <param name="voiceState"></param>
        public void UpdateVoiceState(UpdateVoiceStatusCommand voiceState) => Bot?.SendWebSocketCommand(this, GatewayCommandCode.VoiceStateUpdate, voiceState);

        /// <summary>
        /// Used to update the bot status in discord
        /// </summary>
        /// <param name="presenceUpdate"></param>
        public void UpdateStatus(UpdatePresenceCommand presenceUpdate) => Bot?.SendWebSocketCommand(this, GatewayCommandCode.PresenceUpdate, presenceUpdate);
        #endregion
        
        internal void UpdateLogLevel()
        {
            Logger.UpdateLogLevel(DiscordLoggerFactory.Instance.GetLogLevel(Connection.LogLevel));
        }
        
        internal void CloseClient()
        {
            try
            {
                DiscordExtension.GlobalLogger.Debug($"{nameof(DiscordClient)}.{nameof(CloseClient)} Closing DiscordClient for plugin {{0}}", PluginName);
                Disconnect();
            }
            catch (Exception ex)
            {
                Logger.Exception($"Failed to close the {nameof(DiscordClient)} for {{0}}", PluginName, ex);
            }
            finally
            {
                DiscordClientFactory.Instance.RemoveClient(this);
                
                // ReSharper disable once SuspiciousTypeConversion.Global
                if (Plugin is {IsLoaded: true} and IDiscordPlugin discordPlugin)
                {
                    discordPlugin.Client = null;
                }
                
                Plugin = null;
                PluginSetup = null;
            }
        }
    }
}