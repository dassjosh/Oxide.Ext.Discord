using System;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/user#user-object-user-flags">User Flags</a>
    /// </summary>
    [Flags]
    public enum UserFlags
    {
        /// <summary>
        /// Default value for flags, when none are given to an account.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag given to users who are a Discord employee
        /// </summary>
        Staff = 1 << 0,
        
        /// <summary>
        /// Flag given to users who are owners of a partnered Discord server
        /// </summary>
        Partner = 1 << 1,
        
        /// <summary>
        /// Flag given to users who are HypeSquad Events Member
        /// </summary>
        HypeSquad = 1 << 2,
        
        /// <summary>
        /// Flag given to users who have participated in the 𝐁ug report program and are level 1.
        /// </summary>
        BugHunterLevel1 = 1 << 3,
        
        /// <summary>
        /// Flag given to users who are in the HypeSquad House of Bravery.
        /// </summary>
        HypeSquadOnlineHouse1 = 1 << 6,
        
        /// <summary>
        /// Flag given to users who are in the HypeSquad House of Brilliance.
        /// </summary>
        HypeSquadOnlineHouse2 = 1 << 7,
        
        /// <summary>
        /// Flag given to users who are in the HypeSquad House of Balance.
        /// </summary>
        HypeSquadOnlineHouse3 = 1 << 8,
        
        /// <summary>
        /// Flag given to users who subscribed to Nitro before games were added.
        /// </summary>
        PremiumEarlySupporter = 1 << 9,
        
        /// <summary>
        /// Flag given to users who are part of a team.
        /// </summary>
        TeamPseudoUser = 1 << 10,

        /// <summary>
        /// Flag given to users who have participated in the 𝐁ug report program and are level 2.
        /// </summary>
        BugHunterLevel2 = 1 << 14,
        
        /// <summary>
        /// Flag given to users who are verified bots.
        /// </summary>
        VerifiedBot = 1 << 16,
        
        /// <summary>
        /// Flag given to users that developed bots and early verified their accounts.
        /// </summary>
        VerifiedDeveloper = 1 << 17,
        
        /// <summary>
        /// Flag given to users that are Moderator Programs Alumni
        /// </summary>
        CertifiedModerator = 1 << 18,
        
        /// <summary>
        /// User is a Bot uses only HTTP interactions and is shown in the online member list
        /// </summary>
        BotHttpInteractions = 1 << 19,
        
        /// <summary>
        /// User is an <a href="https://support-dev.discord.com/hc/articles/10113997751447">Active Developer</a>
        /// </summary>
        ActiveDeveloper = 1 << 22,
    }
}