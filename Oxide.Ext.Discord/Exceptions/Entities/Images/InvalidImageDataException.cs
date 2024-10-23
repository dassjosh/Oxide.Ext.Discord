using System.Text.RegularExpressions;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in discord image data
    /// </summary>
    public class InvalidImageDataException : BaseDiscordException
    {
        internal InvalidImageDataException(string message) : base(message) { }

        internal static void ThrowIfInvalidBase64String(Match match, string image)
        {
            if (!match.Success || match.Groups.Count != 2)
            {
                throw new InvalidImageDataException($"'{image}' is not valid. Please make sure it's in the following format: https://discord.com/developers/docs/reference#image-data");
            }
        }

        internal static void ThrowIfInvalidImageBytes(byte[] image)
        {
            if (image == null || image.Length == 0)
            {
                throw new InvalidImageDataException("Image Byte[] cannot be null or empty");
            }
        }
        
        internal static void ThrowIfInvalidImageData(DiscordImageData image)
        {
            if (!image.IsValid())
            {
                throw new InvalidImageDataException("ImageData is not a valid image");
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