using System;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/application#application-object-application-flags">Application Flags</a>
    /// </summary>
    [Flags]
    public enum ApplicationFlags
    {
        /// <summary>
        /// This application has no flags
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Indicates if an app uses the Auto Moderation API
        /// </summary>
        ApplicationAutoModerationRuleCreateBadge = 1 << 6,
        
        /// <summary>
        /// Intent required for bots in 100 or more servers to receive presence_update events
        /// </summary>
        GatewayPresence = 1 << 12,
        
        /// <summary>
        /// Intent required for bots in under 100 servers to receive presence_update events, found in Bot Settings
        /// </summary>
        GatewayPresenceLimited = 1 << 13,
        
        /// <summary>
        /// Intent required for bots in 100 or more servers to receive member-related events like guild_member_add.
        /// See list of member-related events under GUILD_MEMBERS
        /// </summary>
        GatewayGuildMembers = 1 << 14,
        
        /// <summary>
        /// Intent required for bots in under 100 servers to receive member-related events like guild_member_add, found in Bot Settings.
        /// See list of member-related events under GUILD_MEMBERS
        /// </summary>
        GatewayGuildMembersLimited = 1 << 15,
        
        /// <summary>
        /// Indicates unusual growth of an app that prevents verification
        /// </summary>
        VerificationPendingGuildLimit = 1 << 16,
        
        /// <summary>
        /// Indicates if an app is embedded within the Discord client (currently unavailable publicly)
        /// </summary>
        Embedded = 1 << 17,
        
        /// <summary>
        /// Intent required for bots in 100 or more servers to receive message content
        /// </summary>
        GatewayMessageContent = 1 << 18,
        
        /// <summary>
        /// Intent required for bots in under 100 servers to receive message content, found in Bot Settings
        /// </summary>
        GatewayMessageContentLimited = 1 << 19,
        
        /// <summary>
        /// Indicates if an app has registered global application commands
        /// </summary>
        ApplicationCommandBadge = 1 << 23,
    }
}