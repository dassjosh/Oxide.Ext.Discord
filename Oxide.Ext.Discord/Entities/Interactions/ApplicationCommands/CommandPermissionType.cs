using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/application-commands#application-command-permissions-object-application-command-permission-type">ApplicationCommandPermissionType</a>
    /// </summary>
    public enum CommandPermissionType : byte
    {
        /// <summary>
        /// This permissions uses Role ID
        /// </summary>
        [DiscordEnum("ROLE")]
        Role = 1,
        
        /// <summary>
        /// This permission uses User ID
        /// </summary>
        [DiscordEnum("USER")]
        User = 2,
        
        /// <summary>
        /// This permission uses Channel ID
        /// </summary>
        [DiscordEnum("CHANNEL")]
        Channel = 3
    }
}