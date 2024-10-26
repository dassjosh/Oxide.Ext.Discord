using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/teams#data-models-membership-state-enum">Membership State Enum</a>
    /// </summary>
    public enum TeamMembershipState : byte
    {
        /// <summary>
        /// If the user has been invited
        /// </summary>
        [DiscordEnum("INVITED")]
        Invited = 1,
        
        /// <summary>
        /// If the is part of the team
        /// </summary>
        [DiscordEnum("ACCEPTED")]
        Accepted = 2
    }
}