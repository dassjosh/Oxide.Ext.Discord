using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/reference#image-data">Discord Image Data</a>
    /// </summary>
    [JsonConverter(typeof(DiscordImageDataConverter))]
    public readonly struct DiscordImageData
    {
        /// <summary>
        /// The type of image
        /// </summary>
        public readonly DiscordImageFormat Type;
        
        /// <summary>
        /// The image data
        /// </summary>
        public readonly byte[] Image;

        private static readonly Regex ImageDataRegex = new(@"^data:image\/(jpeg|png|gif){1};base64,([A-Za-z\d+\/]+)$", RegexOptions.Compiled);
        private static readonly byte[] Gif = Encoding.UTF8.GetBytes("GIF");
        private static readonly byte[] Png = {137, 80, 78, 71};
        private static readonly byte[] Jpeg = {255, 216, 255, 224};
        private static readonly byte[] Jpeg2 = {255, 216, 255, 225};

        private const double KiloBytes = 1024;
        private const double MegaBytes = KiloBytes * 1024;
        private const double Gigabytes = MegaBytes * 1024;
        
        /// <summary>
        /// Constructor from a byte[] of the image
        /// </summary>
        /// <param name="image">Image bytes</param>
        public DiscordImageData(byte[] image)
        {
            InvalidImageDataException.ThrowIfInvalidImageBytes(image);
            Type = GetType(image);
            Image = image;
        }

        /// <summary>
        /// Creates DiscordImageData from a stream
        /// </summary>
        /// <param name="stream"></param>
        public DiscordImageData(Stream stream)
        {
            MemoryStream memoryStream = DiscordPool.Internal.GetMemoryStream();
            stream.CopyToPooled(memoryStream);
            byte[] image = memoryStream.ToArray();
            Type = GetType(image);
            Image = image;
            DiscordPool.Internal.FreeMemoryStream(memoryStream);
        }

        /// <summary>
        /// Constructor from the discord image data format
        /// </summary>
        /// <param name="image">string base64 image</param>
        /// <exception cref="InvalidImageDataException">Thrown if the image is not a valid base64 image string</exception>
        public DiscordImageData(string image)
        {
            Match match = ImageDataRegex.Match(image);
            InvalidImageDataException.ThrowIfInvalidBase64String(match, image);
            Type = (DiscordImageFormat)Enum.Parse(typeof(DiscordImageFormat), match.Groups[0].Value, true);
            Image = Convert.FromBase64String(match.Groups[1].Value);
        }
        
        /// <summary>
        /// Returns the Base64 Image string for the image.
        /// </summary>
        /// <returns></returns>
        public string GetBase64Image()
        {
            ValueStringBuilder sb = new();
            sb.Append("data:image/");
            sb.Append(EnumCache<DiscordImageFormat>.Instance.ToLower(Type));
            sb.Append(";base64,");
            sb.Append(Convert.ToBase64String(Image));
            return sb.ToString();
        }

        /// <summary>
        /// Returns the image size in the given format
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public double GetImageSize(DiscordImageSize size)
        {
            return size switch
            {
                DiscordImageSize.Bytes => Image.Length,
                DiscordImageSize.KiloBytes => Image.Length / KiloBytes,
                DiscordImageSize.MegaBytes => Image.Length / MegaBytes,
                DiscordImageSize.GigaBytes => Image.Length / Gigabytes,
                _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
            };
        }

        /// <summary>
        /// Returns if this struct has a valid image
        /// </summary>
        /// <returns></returns>
        public bool IsValid() => Image != null && Image.Length != 0;

        /// <summary>
        /// Returns the type of image for the given bytes[]
        /// </summary>
        /// <param name="image">byte[] of the image</param>
        /// <returns></returns>
        /// <exception cref="InvalidImageDataException">Thrown if the byte[] image is not a valid supported type</exception>
        private static DiscordImageFormat GetType(byte[] image)
        {
            byte first = image[0];
            if (first == Gif[0] && StartsWith(Gif, image))
            {
                return DiscordImageFormat.Gif;
            }

            if (first == Png[0] && StartsWith(Png, image))
            {
                return DiscordImageFormat.Png;
            }

            if (first == Jpeg[0] && StartsWith(Jpeg, image) || StartsWith(Jpeg2, image))
            {
                return DiscordImageFormat.Jpg;
            }

            throw new InvalidImageDataException("Image does not appear to be a support image of type GIF, PNG, or JPEG");
        }

        private static bool StartsWith(byte[] type, byte[] image)
        {
            for (int index = 1; index < type.Length; index++)
            {
                if (type[index] != image[index])
                {
                    return false;
                }
            }

            return true;
        }
    }
}