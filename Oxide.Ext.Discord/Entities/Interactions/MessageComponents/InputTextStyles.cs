namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#input-text-styles">Input Text Styles</a> within discord.
    /// </summary>
    public enum InputTextStyles : byte
    {
        /// <summary>
        /// Single-line input
        /// </summary>
        Short = 1,
        
        /// <summary>
        /// Multi-line input
        /// </summary>
        Paragraph = 2
    }
}