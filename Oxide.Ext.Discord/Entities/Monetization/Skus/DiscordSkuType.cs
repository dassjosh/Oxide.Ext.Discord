namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/monetization/skus#sku-object-sku-types">Discord SKU Types</a>
    /// </summary>
    public enum DiscordSkuType
    {
        /// <summary>
        /// Durable one-time purchase
        /// </summary>
        Durable = 2,

        /// <summary>
        /// Consumable one-time purchase
        /// </summary>
        Consumable = 3,

        /// <summary>
        /// Represents a recurring subscription
        /// </summary>
        Subscription = 5,

        /// <summary>
        /// System-generated group for each SUBSCRIPTION SKU created
        /// </summary>
        SubscriptionGroup = 6
    }
}