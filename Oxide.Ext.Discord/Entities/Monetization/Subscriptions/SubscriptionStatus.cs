namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents a <a href="https://discord.com/developers/docs/resources/subscription#subscription-statuses">Subscription Statuses</a>
/// </summary>
public enum SubscriptionStatus
{
    /// <summary>
    /// Subscription is active and scheduled to renew.
    /// </summary>
    Active,
    
    /// <summary>
    /// Subscription is active but will not renew.
    /// </summary>
    Ending,
    
    /// <summary>
    /// Subscription is inactive and not being charged.
    /// </summary>
    Inactive,
}