using System.Collections.Generic;
using Oxide.Core.Libraries;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents the base class for Discord Libraries
    /// </summary>
    public abstract class BaseDiscordLibrary : Library
    {
        private static readonly List<BaseDiscordLibrary> Libraries = new();
        private static readonly HashSet<PluginId> LoadedPlugins = new();
        private static readonly HashSet<PluginId> BotConnectedPlugins = new();

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseDiscordLibrary()
        {
            Libraries.Add(this);
        }

        internal static void ProcessPluginLoaded(DiscordClient client)
        {
            if (LoadedPlugins.Add(client.PluginId))
            {
                for (int index = 0; index < Libraries.Count; index++)
                {
                    BaseDiscordLibrary library = Libraries[index];
                    library.OnPluginLoaded(client);
                }
            }
        }

        internal static void ProcessBotConnection(DiscordClient client)
        {
            if (BotConnectedPlugins.Add(client.PluginId))
            {
                for (int index = 0; index < Libraries.Count; index++)
                {
                    BaseDiscordLibrary library = Libraries[index];
                    library.OnClientBotConnect(client);
                }
            }
        }
        
        internal static void ProcessPluginUnloaded(Plugin plugin)
        {
            for (int index = 0; index < Libraries.Count; index++)
            {
                BaseDiscordLibrary library = Libraries[index];
                library.OnPluginUnloaded(plugin);
            }
            PluginId pluginId = plugin.Id();
            LoadedPlugins.Remove(pluginId);
            BotConnectedPlugins.Remove(pluginId);
        }

        /// <summary>
        /// Called on the library when a plugin is loaded
        /// </summary>
        /// <param name="client">Client for the loaded plugin</param>
        protected virtual void OnPluginLoaded(DiscordClient client) {}

        /// <summary>
        /// Called on the library when a plugin is loaded
        /// </summary>
        /// <param name="client">Client for the connecting bot</param>
        protected virtual void OnClientBotConnect(DiscordClient client) {}
        
        /// <summary>
        /// Called on the library when a plugin is unloaded
        /// </summary>
        /// <param name="plugin">Plugin that was unloaded</param>
        protected virtual void OnPluginUnloaded(Plugin plugin) {}
    }
}