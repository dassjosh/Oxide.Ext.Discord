namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/channel#message-reference-types">Message Reference Type</a>
    /// </summary>
    public enum MessageReferenceType
    {
        /// <summary>
        /// A standard reference used by replies.
        /// </summary>
        Default = 0,
        
        /// <summary>
        /// Reference used to point to a message at a point in time.
        /// </summary>
        Forward = 1
    }
}