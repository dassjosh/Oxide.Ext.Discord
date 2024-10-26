using System.Text.RegularExpressions;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Error thrown when an emoji string fails validation
    /// </summary>
    public class InvalidEmojiException : BaseDiscordException
    {
        /// <summary>
        /// Regex emoji validation matching discord emoji formatting standards
        /// </summary>
        public static readonly Regex EmojiValidation = new("^.+:[0-9]+$", RegexOptions.Compiled);
        
        private InvalidEmojiException(string emojiValue, string validationError) : base($"'{emojiValue}' failed emoji validation with error: {validationError}") { }

        private InvalidEmojiException(string message) : base(message) { }

        internal static void ThrowIfInvalidEmojiString(string emoji)
        {
            if (string.IsNullOrEmpty(emoji))
            {
                throw new InvalidEmojiException(emoji, "Emoji string cannot be null or empty.");
            }

            if (emoji.Length == 2 && !char.IsSurrogatePair(emoji[0], emoji[1]))
            {
                throw new InvalidEmojiException(emoji, "Emoji of length 2 must be a surrogate pair");
            }

            if (emoji.Length > 2 && !EmojiValidation.IsMatch(emoji))
            {
                throw new InvalidEmojiException(emoji, "Emoji string is not in the correct format.\n" +
                                                       "If using a normal emoji please use the unicode character for that emoji.\n" +
                                                       "If using a custom emoji the format must be emojiName:emojiId\n" +
                                                       "If using a custom animated emoji the format must be a:emojiName:emojiId");
            }
        }
        
        internal static void ThrowIfInvalidName(string name, bool allowNullOrEmpty)
        {
            if (!allowNullOrEmpty && string.IsNullOrEmpty(name))
            {
                throw new InvalidEmojiException("Name cannot be less than 1 character");
            }
        }
        
        internal static void ThrowIfInvalidImageData(DiscordImageData image)
        {
            const int MaxSize = 256;
            
            if (!image.IsValid())
            {
                throw new InvalidEmojiException("ImageData is required");
            }

            if (image.GetImageSize(DiscordImageSize.KiloBytes) > MaxSize)
            {
                throw new InvalidEmojiException($"ImageData cannot be more than {MaxSize} kilobytes");
            }
        }
        
        internal static void ThrowIfInvalidImageData(DiscordImageData? image)
        {
            if (image.HasValue)
            {
                ThrowIfInvalidImageData(image.Value);
            }
        }
    }
}