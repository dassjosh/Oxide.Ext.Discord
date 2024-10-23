using System;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in guild stickers
    /// </summary>
    public class InvalidGuildStickerException : BaseDiscordException
    {
        private InvalidGuildStickerException(string message) : base(message) { }
        
        internal static void ThrowIfInvalidName(string name, bool allowNullOrEmpty)
        {
            if (!allowNullOrEmpty && string.IsNullOrEmpty(name) || name.Length < 2)
            {
                throw new InvalidGuildStickerException("Name cannot be less than 2 character");
            }
            
            if (name.Length > 30)
            {
                throw new InvalidGuildStickerException("Name cannot be more than 30 characters");
            }
        }
        
        internal static void ThrowIfInvalidDescription(string description, bool allowNullOrEmpty)
        {
            if (!allowNullOrEmpty && string.IsNullOrEmpty(description) || description.Length < 2)
            {
                throw new InvalidGuildStickerException("Description cannot be less than 2 character");
            }
            
            if (description.Length > 100)
            {
                throw new InvalidGuildStickerException("Description cannot be more than 100 characters");
            }
        }
        
        internal static void ThrowIfNotGuildType(StickerType type, string message)
        {
            if (type != StickerType.Guild)
            {
                throw new InvalidGuildStickerException(message);
            }
        }
        
        internal static void ThrowIfMoreThanOneImage(int count)
        {
            if (count != 0)
            {
                throw new InvalidGuildStickerException("Can only add one sticker at a time");
            }
        }
        
        internal static void ThrowIfImageTooLarge(byte[] sticker)
        {
            const int MaxStickerSizeKb = 512;
            if (sticker.Length > MaxStickerSizeKb * 1024)
            {
                throw new InvalidGuildStickerException($"sticker image size cannot be larger than {MaxStickerSizeKb}KB");
            }
        }
        
        internal static void ThrowIfInvalidFileExtension(string fileName)
        {
            if (!fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                && !fileName.EndsWith(".apng", StringComparison.OrdinalIgnoreCase)
                && !fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase)
                && !fileName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidGuildStickerException("Sticker can only be of type png, apng, gif, or lottie json");
            }
        }
    }
}