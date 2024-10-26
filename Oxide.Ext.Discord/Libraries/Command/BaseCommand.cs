using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Sourced from Command.cs of OxideMod (https://github.com/OxideMod/Oxide.Rust/blob/develop/src/Libraries/Command.cs#L76)
    /// </summary>
    internal abstract class BaseCommand : IDebugLoggable
    {
        internal readonly string Name;
        private readonly string _hook;
        internal Plugin Plugin;

        protected BaseCommand(Plugin plugin, string name, string hook)
        {
            Name = name;
            _hook = hook;
            Plugin = plugin;
        }
        
        public void HandleCommand(DiscordMessage message, string name, string[] args)
        {
            DiscordHook.CallPluginHook(Plugin, _hook, message, name, args);
        }

        /// <summary>
        /// Returns if a command can run.
        /// They can only run for the client that they were created for.
        /// </summary>
        /// <param name="client">Client to compare against</param>
        /// <returns>True if same bot client; false otherwise</returns>
        public bool CanRun(BotClient client)
        {
            return client != null && DiscordClientFactory.Instance.GetClient(Plugin)?.Bot == client;
        }

        public abstract bool CanHandle(DiscordMessage message, DiscordChannel channel);
        public abstract void LogDebug(DebugLogger logger);

        internal void OnRemoved()
        {
            Plugin = null;
        }
    }
}