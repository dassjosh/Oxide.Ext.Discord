using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Callbacks;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents a Base Registered Application Command
    /// </summary>
    internal abstract class BaseAppCommand : IDebugLoggable
    {
        internal readonly Snowflake AppId;
        internal readonly AppCommandId CommandId;
        internal readonly string PluginName;
        private readonly PluginId _pluginId;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="plugin">Plugin for the command</param>
        /// <param name="appId">ID of the <see cref="DiscordApplication"/> for the command</param>
        /// <param name="commandId">Command ID for the command</param>
        /// <param name="logger">Logger for the command</param>
        protected BaseAppCommand(Plugin plugin, Snowflake appId, AppCommandId commandId, ILogger logger)
        {
            PluginName = plugin.FullName();
            _pluginId = plugin.Id();
            AppId = appId;
            CommandId = commandId;
            _logger = logger;
        }

        public void HandleCommand(DiscordInteraction interaction)
        {
            if (ThreadEx.IsMain)
            {
                HandleCommandInternal(interaction);
            }
            else
            {
                AppCommandCallback.Start(this, interaction);
            }
        }

        internal void HandleCommandInternal(DiscordInteraction interaction)
        {
            try
            {
                RunCommand(interaction);
            }
            catch (Exception ex)
            {
                _logger.Exception(GetExceptionMessage(), ex);
            }
        }

        public bool IsForPlugin(PluginId id) => _pluginId == id;

        protected abstract string GetCommandType();

        protected abstract string GetExceptionMessage();

        protected abstract void RunCommand(DiscordInteraction interaction);

        public virtual void LogDebug(DebugLogger logger)
        {
            logger.AppendField("Type", GetCommandType());
            logger.AppendField("Plugin", PluginName);
            logger.AppendField("Command", CommandId.ToString());
        }
    }
}