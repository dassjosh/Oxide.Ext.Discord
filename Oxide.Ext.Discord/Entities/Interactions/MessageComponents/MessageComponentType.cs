namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#component-types">Message Component Type</a> within Discord..
    /// </summary>
    public enum MessageComponentType : byte
    {
        /// <summary>
        /// Container for other components
        /// </summary>
        ActionRow = 1,
        
        /// <summary>
        /// Clickable button
        /// </summary>
        Button = 2,
        
        /// <summary>
        /// Select menu for picking from defined text options
        /// </summary>
        StringSelect = 3,
        
        /// <summary>
        /// Text box for inserting written responses
        /// </summary>
        InputText = 4,
        
        /// <summary>
        /// Select menu for users
        /// </summary>
        UserSelect = 5,
        
        /// <summary>
        /// Select menu for roles
        /// </summary>
        RoleSelect = 6,
        
        /// <summary>
        /// Select menu for mentionables (users and roles)
        /// </summary>
        MentionableSelect = 7,
        
        /// <summary>
        /// Select menu for channels
        /// </summary>
        ChannelSelect = 8,
    }
}