using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Rest;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Clients
{
    /// <summary>
    /// BaseClient that can connect to discord
    /// </summary>
    public abstract class BaseClient
    {
        /// <summary>
        /// Rest handler for all discord API calls
        /// </summary>
        public RestHandler Rest { get; protected set; }
        
        /// <summary>
        /// If the connection is initialized and not disconnected
        /// </summary>
        public bool Initialized { get; protected set; }
    
        internal readonly ILogger Logger;

        /// <summary>
        /// List of all clients using this client
        /// </summary>
        protected readonly List<DiscordClient> _clients = new();
        
        /// <summary>
        /// List of all clients that are using this bot client
        /// </summary>
        public readonly IReadOnlyList<DiscordClient> Clients;

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseClient()
        {
            Logger = DiscordLoggerFactory.Instance.CreateExtensionLogger();
            Clients = new ReadOnlyCollection<DiscordClient>(_clients);
            Initialized = true;
        }
        
        internal abstract void HandleConnect();
        internal abstract void HandleShutdown();
    
        internal virtual void HandleAlreadyConnected(DiscordClient client) {}
        
        /// <summary>
        /// Returns the list of plugins for this bot
        /// </summary>
        /// <returns></returns>
        public string GetClientPluginList()
        {
            ValueStringBuilder sb = new();
            for (int index = 0; index < _clients.Count; index++)
            {
                DiscordClient client = _clients[index];
                if (index != 0)
                {
                    sb.Append(",");
                }
                
                sb.Append('[');
                sb.Append(client.PluginName);
                sb.Append(']');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Add a <see cref="DiscordClient"/> to this bot / webhook client
        /// </summary>
        /// <param name="client">Client to add</param>
        /// <returns>True if this is the initial setup of the client; false otherwise</returns>
        /// <exception cref="Exception">Thrown if <see cref="DiscordClient"/> already has been added to this bot / webhook client</exception>
        public virtual void AddClient(DiscordClient client)
        {
            _clients.Add(client);

            Logger.Debug($"{nameof(BaseClient)}.{nameof(AddClient)} Add client for plugin {{0}}", client.Plugin.Title);

            if (_clients.Count == 1)
            {
                Logger.Debug($"{nameof(BaseClient)}.{nameof(AddClient)} Clients.Count == 1 connecting");
                HandleConnect();
                return;
            }

            HandleAlreadyConnected(client);
        }
        
        /// <summary>
        /// Removes the <see cref="DiscordClient"/> from this bot / webhook client
        /// </summary>
        /// <param name="client">Client to remove</param>
        /// <returns>returns true if the client is shutting down; false otherwise</returns>
        public virtual bool RemoveClient(DiscordClient client)
        {
            Logger.Debug($"{nameof(BaseClient)}.{nameof(RemoveClient)} Removing Client {{0}}", client.PluginName);
            _clients.Remove(client);
            Rest.OnClientClosed(client);

            if (_clients.Count == 0)
            {
                HandleShutdown();
                return true;
            }

            return false;
        }
        
        internal void UpdateLogLevel(DiscordLogLevel level)
        {
            Logger.UpdateLogLevel(level);
            Logger.Debug($"{nameof(BaseClient)}.{nameof(UpdateLogLevel)} Updating log level from: {{0}} to: {{1}}", Logger.LogLevel, level);
        }

        internal void ShutdownRest()
        {
            try
            {
                Rest?.Shutdown();
            }
            catch (Exception ex)
            {
                Logger.Exception($"{nameof(WebhookClient)}.{nameof(ShutdownRest)} An error occured shutting down the bot rest client.", ex);
            }
            finally
            {
                Rest = null;
            }
        }
    }
}