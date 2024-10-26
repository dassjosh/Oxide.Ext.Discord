using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Libraries
{
    internal class AppCommand : BaseAppCommand
    {
        private readonly Action<DiscordInteraction, InteractionDataParsed> _callback;

        public AppCommand(Plugin plugin, Snowflake appId, AppCommandId command, Action<DiscordInteraction, InteractionDataParsed> callback, ILogger logger) : base(plugin, appId, command, logger)
        {
            _callback = callback;
        }
        
        protected override string GetCommandType() => "Application Command";
        
        protected override void RunCommand(DiscordInteraction interaction) => _callback(interaction, interaction.Parsed);

        protected override string GetExceptionMessage() => $"An error occured during callback. Plugin: {PluginName} Method: {_callback.Method.DeclaringType?.Name}.{_callback.Method.Name}";

        public override void LogDebug(DebugLogger logger)
        {
            base.LogDebug(logger);
            logger.AppendMethod("Callback", _callback.Method);
        }
    }
}