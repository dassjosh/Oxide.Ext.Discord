using System;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/permissions#role-flags">Role Flags</a>
    /// </summary>
    [Flags]
    public enum RoleFlags
    {
        /// <summary>
        /// No Role Flags
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Role can be selected by members in an onboarding
        /// </summary>
        InPrompt = 1 << 0
    }
}