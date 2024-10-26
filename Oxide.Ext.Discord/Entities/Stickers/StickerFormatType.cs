using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/sticker#sticker-format-types">Sticker Format Types</a>
    /// </summary>
    public enum StickerFormatType : byte
    {
        /// <summary>
        /// Sticker format type PNG
        /// </summary>
        [DiscordEnum("PNG")]
        Png = 1,
        
        /// <summary>
        /// Sticker format type APNG
        /// </summary>
        [DiscordEnum("APNG")]
        Apng = 2,
        
        /// <summary>
        /// Sticker format type LOTTIE
        /// </summary>
        [DiscordEnum("LOTTIE")]
        Lottie = 3,
        
        /// <summary>
        /// Sticker format type GIF
        /// </summary>
        [DiscordEnum("GIF")]
        Gif = 4
    }
}