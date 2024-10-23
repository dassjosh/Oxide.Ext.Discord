﻿namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents Discord User <a href="https://discord.com/developers/docs/resources/user#user-object-premium-types">Premium Types</a>
    /// </summary>
    public enum UserPremiumType : byte
    {
        /// <summary>
        /// User has no premium
        /// </summary>
        None = 0,
        
        /// <summary>
        /// User has nitro classic premium
        /// </summary>
        NitroClassic = 1,
        
        /// <summary>
        /// User has nitro premium
        /// </summary>
        Nitro = 2,
        
        /// <summary>
        /// User has nitro basic
        /// </summary>
        NitroBasic = 3
    }
}