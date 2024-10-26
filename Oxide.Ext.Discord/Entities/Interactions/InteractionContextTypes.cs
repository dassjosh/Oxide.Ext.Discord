namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-context-types">Interaction Context Types</a>
    /// </summary>
    public enum InteractionContextTypes
    {
        /// <summary>
        /// Interaction can be used within servers
        /// </summary>
        Guild = 0,
        
        /// <summary>
        /// Interaction can be used within DMs with the app's bot user
        /// </summary>
        BotDm = 1,
        
        /// <summary>
        /// Interaction can be used within Group DMs and DMs other than the app's bot user
        /// </summary>
        PrivateChannel = 2
    }
}