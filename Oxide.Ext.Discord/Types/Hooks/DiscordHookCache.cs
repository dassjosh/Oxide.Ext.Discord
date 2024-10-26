using System.Collections.Generic;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Connections;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Types
{
    internal class DiscordHookCache
    {
        private readonly Hash<string, List<Plugin>> _hookCache = new();
        private readonly ILogger _logger;

        internal DiscordHookCache(ILogger logger)
        {
            _logger = logger;
        }

        internal void AddPlugin(DiscordClient client, List<string> hooks)
        {
            for (int index = 0; index < hooks.Count; index++)
            {
                string hook = hooks[index];
                AddPluginHook(client, hook);
            }
        }

        private void AddPluginHook(DiscordClient client, string hook)
        {
            BotConnection connection = client.Connection;
            GatewayIntents intent = DiscordExtHooks.HookGatewayIntent[hook];
            if (intent != GatewayIntents.None && !connection.HasAnyIntent(intent))
            {
                _logger.Warning("{0} is trying to add hook {1} which requires one of the following GatewayIntents \"{2}\", but only specified \"{3}\" intents " +
                                "This hook will not work correctly until it is corrected. " +
                                "Please contact the plugin author {4} with this message.", client.PluginName, hook, EnumCache<GatewayIntents>.Instance.ToString(intent), EnumCache<GatewayIntents>.Instance.ToString(connection.Intents), client.Plugin?.Author);
            }

            List<Plugin> hooks = _hookCache[hook];
            if (hooks == null)
            {
                hooks = new List<Plugin>();
                _hookCache[hook] = hooks;
            }

            if (!hooks.Contains(client.Plugin))
            {
                hooks.Add(client.Plugin);
            }
        }

        internal void RemovePlugin(Plugin plugin)
        {
            List<string> hooksToRemove = DiscordPool.Internal.GetList<string>();
            foreach (KeyValuePair<string, List<Plugin>> cache in _hookCache)
            {
                if (cache.Value.Remove(plugin) && cache.Value.Count == 0)
                {
                    hooksToRemove.Add(cache.Key);
                }
            }

            for (int index = 0; index < hooksToRemove.Count; index++)
            {
                _hookCache.Remove(hooksToRemove[index]);
            }
            
            DiscordPool.Internal.FreeList(hooksToRemove);
        }

        internal bool TryGetHook(string hook, out List<Plugin> plugins)
        {
            return _hookCache.TryGetValue(hook, out plugins);
        }
    }
}