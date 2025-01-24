using System.Text.RegularExpressions;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in discord sound data
    /// </summary>
    public class InvalidSoundDataException : BaseDiscordException
    {
        private InvalidSoundDataException(string message) : base(message) { }

        internal static void ThrowIfInvalidBase64String(Match match, string sound)
        {
            if (!match.Success || match.Groups.Count != 2)
            {
                throw new InvalidSoundDataException($"'{sound}' is not valid. Please make sure it's in the following format: https://discord.com/developers/docs/reference#sound-data");
            }
        }

        internal static void ThrowIfInvalidSoundBytes(byte[] sound)
        {
            if (sound == null || sound.Length == 0)
            {
                throw new InvalidSoundDataException("Sound Byte[] cannot be null or empty");
            }
        }
        
        internal static void ThrowIfInvalidSoundData(DiscordSoundData sound)
        {
            if (!sound.IsValid)
            {
                throw new InvalidSoundDataException("SoundData is not a valid sound");
            }
        }
        
        internal static void ThrowIfInvalidSoundData(DiscordSoundData? sound)
        {
            if (sound.HasValue)
            {
                ThrowIfInvalidSoundData(sound.Value);
            }
        }
    }
}