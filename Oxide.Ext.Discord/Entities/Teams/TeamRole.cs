using Newtonsoft.Json;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/teams#team-member-roles-team-member-role-types">Team Role Types</a>
    /// </summary>
    [JsonConverter(typeof(DiscordEnumConverter))]
    public enum TeamRole : byte
    {
        /// <summary>
        /// Owners are the most permissible role, and can take destructive, irreversible actions like deleting team-owned apps or the team itself. Teams are limited to 1 owner.
        /// </summary>
        [DiscordEnum("")]
        Owner,
        
        /// <summary>
        /// Admins have similar access as owners, except they cannot take destructive actions on the team or team-owned apps.
        /// </summary>
        [DiscordEnum("admin")]
        Admin,
        
        /// <summary>
        /// Developers can access information about team-owned apps, like the client secret or public key. They can also take limited actions on team-owned apps, like configuring interaction endpoints or resetting the bot token. Members with the Developer role cannot manage the team or its members, or take destructive actions on team-owned apps.
        /// </summary>
        [DiscordEnum("developer")]
        Developer,
        
        /// <summary>
        /// Read-only members can access information about a team and any team-owned apps. Some examples include getting the IDs of applications and exporting payout records.
        /// </summary>
        [DiscordEnum("read_only")]
        ReadOnly
    }
}