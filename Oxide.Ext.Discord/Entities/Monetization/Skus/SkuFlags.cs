using System;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/monetization/skus#sku-object-sku-flags">Discord SKU Flags</a>
    /// </summary>
    [Flags]
    public enum SkuFlags
    {
        /// <summary>
        /// No Sku Flags
        /// </summary>
        None = 0,
        
        /// <summary>
        /// SKU is available for purchase
        /// </summary>
        Available = 1 << 2,
        
        /// <summary>
        /// Recurring SKU that can be purchased by a user and applied to a single server. Grants access to every user in that server.
        /// </summary>
        GuildSubscription = 1 << 7,
        
        /// <summary>
        /// Recurring SKU purchased by a user for themselves. Grants access to the purchasing user in every server.
        /// </summary>
        UserSubscription = 1 << 8,
    }
}