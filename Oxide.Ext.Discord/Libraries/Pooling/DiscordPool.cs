using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Discord Pool Library
    /// </summary>
    public class DiscordPool : BaseDiscordLibrary<DiscordPool>, IDebugLoggable
    {
        private readonly Hash<PluginId, DiscordPluginPool> _pluginPools = new();
        internal static DiscordPluginPool Internal;
        private readonly ILogger _logger;
        
        internal DiscordPool(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Returns an existing <see cref="DiscordPluginPool"/> for the given plugin or returns a new one
        /// </summary>
        /// <param name="plugin">The pool the plugin is for</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if the plugin is null</exception>
        public DiscordPluginPool GetOrCreate(Plugin plugin)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            return CreatePoolInternal(plugin);
        }
        
        internal void CreateInternal(Plugin plugin)
        {
            Internal = CreatePoolInternal(plugin);
            Internal.SetSettings(PoolSettings.CreateInternal());
        }
        
        private DiscordPluginPool CreatePoolInternal(Plugin plugin)
        {
            PluginId id = plugin.Id();
            DiscordPluginPool pool = _pluginPools[id];
            if (pool == null)
            {
                pool = new DiscordPluginPool(plugin);
                _pluginPools[id] = pool;
            }

            return pool;
        }

        ///<inheritdoc/>
        protected override void OnPluginLoaded(DiscordClient client)
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (client.Plugin is IDiscordPool pool)
            {
                pool.Pool = GetOrCreate(client.Plugin);
            }
        }

        ///<inheritdoc/>
        protected override void OnPluginUnloaded(Plugin plugin)
        {
            PluginId id = plugin.Id();
            DiscordPluginPool pool = _pluginPools[id];
            if (pool != null)
            {
                pool.OnPluginUnloaded();
                _pluginPools.Remove(id);
            }
        }

        internal void Clear()
        {
            foreach (DiscordPluginPool pool in _pluginPools.Values)
            {
                pool.Clear();
            }
        }
        
        internal void Wipe()
        {
            foreach (DiscordPluginPool pool in _pluginPools.Values)
            {
                pool.Wipe();
            }
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendObject("Internal", Internal);
            foreach (DiscordPluginPool pool in _pluginPools.Values)
            {
                if (pool != Internal)
                {
                    logger.AppendObject(pool.PluginName, pool);
                }
            }
        }
    }
}