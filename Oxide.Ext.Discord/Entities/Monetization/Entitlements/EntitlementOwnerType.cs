namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/monetization/entitlements#create-test-entitlement-json-params">Entitlement Owner Types</a>
    /// </summary>
    public enum EntitlementOwnerType
    {
        /// <summary>
        /// Subscription is a Guild Subscription
        /// </summary>
        GuidSubscription = 1,
        
        /// <summary>
        /// Subscription is a User Subscription
        /// </summary>
        UserSubscription = 2
    }
}