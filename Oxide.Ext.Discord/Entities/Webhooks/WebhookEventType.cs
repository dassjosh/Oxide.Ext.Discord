namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/application#application-event-webhook-status">Webhook event type</a>
    /// </summary>
    public enum WebhookEventType
    {
        /// <summary>
        /// Webhook events are disabled by developer 
        /// </summary>
        Disabled = 1,
        
        /// <summary>
        /// Webhook events are enabled by developer  
        /// </summary>
        Enabled = 2,
        
        /// <summary>
        /// Webhook events are disabled by Discord, usually do to inactivity
        /// </summary>
        DisabledByDiscord = 3
    }
}