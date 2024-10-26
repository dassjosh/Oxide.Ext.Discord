using System;
using System.Linq;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Factory
{
    /// <summary>
    /// Factory for creating <see cref="DiscordClient"/>
    /// </summary>
    public sealed class DiscordClientFactory : Singleton<DiscordClientFactory>
    {
        private readonly Hash<PluginId, DiscordClient> _clients = new();

        private DiscordClientFactory() { }
        
        #region Client Handling
        /// <summary>
        /// Creates the client for the given plugin. If one already exists, the existing one is returned
        /// </summary>
        /// <param name="plugin">Plugin the client is for</param>
        /// <returns>DiscordClient for plugin</returns>
        /// <exception cref="ArgumentNullException">Thrown is plugin is null</exception>
        public DiscordClient CreateClient(Plugin plugin)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            OnPluginUnloaded(plugin);

            // ReSharper disable once SuspiciousTypeConversion.Global
            if (plugin is not IDiscordPlugin discordPlugin)
            {
                return null;
            }

            DiscordClient client = _clients[plugin.Id()];
            if (client == null)
            {
                DiscordExtension.GlobalLogger.Debug($"{nameof(DiscordClient)}.{nameof(CreateClient)} Creating DiscordClient for plugin {{0}}", plugin.FullName());
                client = new DiscordClient(plugin);
                _clients[plugin.Id()] = client;
            }

            discordPlugin.Client = client;
            DiscordHook.CallPluginHook(client.Plugin, DiscordExtHooks.OnDiscordClientCreated);
            return client;
        }

        /// <summary>
        /// Gets the client for the given plugin
        /// </summary>
        /// <param name="plugin">Plugin to get the client for</param>
        /// <returns>Discord client for the plugin</returns>
        public DiscordClient GetClient(Plugin plugin)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            return GetClient(plugin.Id());
        }
        
        /// <summary>
        /// Gets the client for the given plugin
        /// </summary>
        /// <param name="pluginId">Plugin to get the client for</param>
        /// <returns>Discord client for the plugin</returns>
        private DiscordClient GetClient(PluginId pluginId)
        {
            return _clients[pluginId];
        }

        /// <summary>
        /// Gets the client for the given plugin name
        /// </summary>
        /// <param name="pluginName">Plugin Name to get the client for</param>
        /// <returns>Discord client for the plugin name</returns>
        public DiscordClient GetClient(string pluginName)
        {
            if (pluginName == null) throw new ArgumentNullException(nameof(pluginName));
            return GetClient(new PluginId(pluginName));
        }
        #endregion
        
        #region Plugin Handling
        internal void OnPluginLoaded(Plugin plugin)
        {
            if (!plugin.IsCorePlugin)
            {
                CreateClient(plugin);
                DiscordPluginCache.Instance.OnPluginLoaded(plugin);
            }
        }

        internal void OnPluginUnloaded(Plugin plugin)
        {
            if (plugin.IsCorePlugin || DiscordExtension.IsShuttingDown)
            {
                return;
            }

            DiscordClient client = _clients[plugin.Id()];
            if (client != null)
            {
                client.CloseClient();
                BaseDiscordLibrary.ProcessPluginUnloaded(plugin);
            }

            PluginExt.OnPluginUnloaded(plugin);
            DiscordPluginCache.Instance.OnPluginUnloaded(plugin);
        }

        internal void RemoveClient(DiscordClient client)
        {
            _clients.Remove(client.PluginId);
        }

        internal void OnShutdown()
        {
            foreach (DiscordClient client in _clients.Values.ToList())
            {
                client.CloseClient();
            }
        }
        #endregion

        internal void UpdateLogLevel()
        {
            foreach (DiscordClient client in _clients.Values)
            {
                client.UpdateLogLevel();
            }
        }
    }
}