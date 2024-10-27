using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/reference#image-data">Discord Sound Data</a>
    /// </summary>
    [JsonConverter(typeof(DiscordSoundDataConverter))]
    public readonly struct DiscordSoundData
    {
        /// <summary>
        /// Format for the sound
        /// </summary>
        public readonly DiscordSoundFormat Format;
        
        /// <summary>
        /// Sound Data
        /// </summary>
        public readonly byte[] Sound;
        
        /// <summary>
        /// Returns if this struct has a valid sound
        /// </summary>
        /// <returns></returns>
        public bool IsValid => Sound != null && Sound.Length != 0;
        
        private static readonly Regex SoundDataRegex = new(@"^data:image\/(mp3|ogg){1};base64,([A-Za-z\d+\/]+)$", RegexOptions.Compiled);
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sound">Sound data</param>
        public DiscordSoundData(byte[] sound)
        {
            InvalidSoundDataException.ThrowIfInvalidSoundBytes(sound);
            Format = GetFormat(sound);
            Sound = sound;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stream">Sound data</param>
        public DiscordSoundData(Stream stream)
        {
            MemoryStream memoryStream = DiscordPool.Internal.GetMemoryStream();
            stream.CopyToPooled(memoryStream);
            byte[] sound = memoryStream.ToArray();
            Format = GetFormat(sound);
            Sound = sound;
            DiscordPool.Internal.FreeMemoryStream(memoryStream);
        }
        
        /// <summary>
        /// Constructor from the discord image data format
        /// </summary>
        /// <param name="sound">string base64 image</param>
        /// <exception cref="InvalidImageDataException">Thrown if the sound is not a valid base64 sound string</exception>
        public DiscordSoundData(string sound)
        {
            Match match = SoundDataRegex.Match(sound);
            InvalidImageDataException.ThrowIfInvalidBase64String(match, sound);
            Format = Enum.Parse<DiscordSoundFormat>(match.Groups[0].Value, true);
            Sound = Convert.FromBase64String(match.Groups[1].Value);
        }
        
        private static DiscordSoundFormat GetFormat(byte[] sound)
        {
            if (sound.StartsWith(FileFormats.Mp3))
            {
                return DiscordSoundFormat.Mp3;
            }

            if (sound.StartsWith(FileFormats.Ogg))
            {
                return DiscordSoundFormat.Ogg;
            }

            throw new InvalidImageDataException("Image does not appear to be a support image of type GIF, PNG, or JPEG");
        }
        
        /// <summary>
        /// Returns the Base64 Image string for the image.
        /// </summary>
        /// <returns></returns>
        public string GetBase64Sound()
        {
            ValueStringBuilder sb = new();
            sb.Append("data:audio/");
            sb.Append(EnumCache<DiscordSoundFormat>.Instance.ToLower(Format));
            sb.Append(";base64,");
            sb.Append(Convert.ToBase64String(Sound));
            return sb.ToString();
        }
    }
}