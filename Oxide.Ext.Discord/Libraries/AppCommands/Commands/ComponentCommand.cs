using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Libraries
{
    internal class ComponentCommand : BaseAppCommand
    {
        private readonly Action<DiscordInteraction> _callback;
        
        public ComponentCommand(Plugin plugin, Snowflake appId, AppCommandId customId, Action<DiscordInteraction> callback, ILogger logger) : base(plugin, appId, customId, logger)
        {
            _callback = callback;
        }

        protected override string GetCommandType() => "Component Command";

        protected override void RunCommand(DiscordInteraction interaction) => _callback(interaction);

        protected override string GetExceptionMessage() => $"An error occured during callback. Plugin: {PluginName} Method: {_callback.Method.DeclaringType?.Name}.{_callback.Method.Name}";

        public bool IsForCommand(AppCommandId id) => id.Command.StartsWith(CommandId.Command);

        public override void LogDebug(DebugLogger logger)
        {
            base.LogDebug(logger);
            logger.AppendField("Command Name", CommandId.Command);
        }
    }
}