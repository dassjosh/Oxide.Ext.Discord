namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#integration-object-integration-expire-behaviors">Integration Expire Behaviors</a>
    /// </summary>
    public enum IntegrationExpireBehaviors : byte
    {
        /// <summary>
        /// Remove the role when integration expires
        /// </summary>
        RemoveRole = 0,
        
        /// <summary>
        /// Kick when integration expires
        /// </summary>
        Kick = 1
    }
}