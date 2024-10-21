using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Libraries;

internal class AutoCompleteCommand : BaseAppCommand
{
    private readonly Action<DiscordInteraction, InteractionDataOption> _callback;
        
    public AutoCompleteCommand(Plugin plugin, Snowflake appId, AppCommandId command,  Action<DiscordInteraction, InteractionDataOption> callback, ILogger logger) : base(plugin, appId, command, logger)
    {
        _callback = callback;
    }
        
    protected override string GetCommandType() => "AutoComplete Command";
        
    protected override void RunCommand(DiscordInteraction interaction) => _callback(interaction, interaction.Focused);

    protected override string GetExceptionMessage() => $"An error occured during callback. Plugin: {PluginName} Method: {_callback.Method.DeclaringType?.Name}.{_callback.Method.Name}";
}