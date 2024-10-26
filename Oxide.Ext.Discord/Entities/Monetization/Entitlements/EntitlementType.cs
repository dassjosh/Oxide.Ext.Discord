namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/monetization/entitlements#entitlement-object-entitlement-types">Entitlement Types</a>
    /// </summary>
    public enum EntitlementType
    {
        /// <summary>
        /// Entitlement was purchased by user  
        /// </summary>
        Purchase = 1,
        
        /// <summary>
        /// Entitlement for Discord Nitro subscription
        /// </summary>
        PremiumSubscription = 2,
        
        /// <summary>
        /// Entitlement was gifted by developer
        /// </summary>
        DeveloperGift = 3,
        
        /// <summary>
        /// Entitlement was purchased by a dev in application test mode
        /// </summary>
        TestModePurchase = 4,
        
        /// <summary>
        /// Entitlement was granted when the SKU was free
        /// </summary>
        FreePurchase = 5,
        
        /// <summary>
        /// Entitlement was claimed by user for free as a Nitro Subscriber
        /// </summary>
        UserGift = 6,
        
        /// <summary>
        /// Entitlement was purchased as an app subscription
        /// </summary>
        PremiumPurchase = 7,
        
        /// <summary>
        /// Entitlement was purchased as an app subscription
        /// </summary>
        ApplicationSubscription = 8
    }
}