namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/sticker#sticker-types">Sticker Types</a>
    /// </summary>
    public enum StickerType : byte
    {
        /// <summary>
        /// An official sticker in a pack
        /// </summary>
        Standard = 1,
        
        /// <summary>
        /// A sticker uploaded to a guild for the guild's members
        /// </summary>
        Guild = 2
    }
}