using System;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Player Name Formatting options for <see cref="PlayerNameFormatter"/>
    /// </summary>
    [Flags]
    public enum PlayerDisplayNameMode : sbyte
    {
        /// <summary>
        /// Defaults search options
        /// </summary>
        Default = 0,
        
        /// <summary>
        /// Include Clan Name in search
        /// </summary>
        Clan = 1 << 0,
        
        /// <summary>
        /// Include Player ID
        /// </summary>
        PlayerId = 1 << 1,

        /// <summary>
        /// All display name options
        /// </summary>
        All = Default | Clan | PlayerId
    }
}