namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Use to control which webhook execute url to call
    /// </summary>
    public enum WebhookSendType : byte
    {
        /// <summary>
        /// Webhook is for Discord
        /// </summary>
        Discord,
        
        /// <summary>
        /// Webhook is for slack
        /// </summary>
        Slack,
        
        /// <summary>
        /// Webhook is for github
        /// </summary>
        Github
    }
}