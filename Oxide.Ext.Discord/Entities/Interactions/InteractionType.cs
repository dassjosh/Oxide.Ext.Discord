namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-type">InteractionType</a>
    /// </summary>
    public enum InteractionType : byte
    {
        /// <summary>
        /// The interaction is a ping
        /// </summary>
        Ping = 1,
        
        /// <summary>
        /// The interaction is a user using a command
        /// </summary>
        ApplicationCommand = 2,
        
        /// <summary>
        /// The interaction is a message component
        /// </summary>
        MessageComponent = 3,
        
        /// <summary>
        /// The interaction is a application command autocomplete
        /// </summary>
        ApplicationCommandAutoComplete = 4,
        
        /// <summary>
        /// The interaction is a modal
        /// </summary>
        ModalSubmit = 5
    }
}