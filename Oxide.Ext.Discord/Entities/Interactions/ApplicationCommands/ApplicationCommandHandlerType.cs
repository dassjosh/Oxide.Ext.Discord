using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/interactions/application-commands#application-command-object-entry-point-command-handler-types">Entry Point Command Handler Types</a>
/// </summary>
public enum ApplicationCommandHandlerType : byte
{
    /// <summary>
    /// The app handles the interaction using an interaction token   
    /// </summary>
    [DiscordEnum("APP_HANDLER")]
    AppHandler = 1,
    
    /// <summary>
    /// Discord handles the interaction by launching an Activity and sending a follow-up message without coordinating with the app  
    /// </summary>
    [DiscordEnum("DISCORD_LAUNCH_ACTIVITY")]
    DiscordLaunchActivity = 2,
}