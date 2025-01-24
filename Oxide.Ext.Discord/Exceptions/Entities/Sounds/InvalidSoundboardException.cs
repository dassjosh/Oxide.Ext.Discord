using System.Runtime.CompilerServices;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in discord sound data
    /// </summary>
    public class InvalidSoundboardException : BaseDiscordException
    {
        private InvalidSoundboardException(string message) : base(message) { }

        internal static void ThrowIfInvalidName(string name, [CallerArgumentExpression("name")] string paramName = null)
        {
            const int MinLength = 2;
            const int MaxLength = 32;

            if (string.IsNullOrEmpty(name) || name.Length is < MinLength or > MaxLength)
            {
                throw new InvalidSoundboardException($"{paramName} must be between {MinLength} and {MaxLength} characters. Actual {name?.Length ?? 0} characters");
            }
        }
        
        internal static void ThrowIfInvalidVolume(double? volume, [CallerArgumentExpression("volume")] string paramName = null)
        {
            const int MinVolume = 0;
            const int MaxVolume = 1;

            if (volume is < MinVolume or > MaxVolume)
            {
                throw new InvalidSoundboardException($"{paramName} must be between {MinVolume} and {MaxVolume}. Actual {volume} characters");
            }
        }

        internal static void ThrowIfInvalidSoundData(DiscordSoundData sound)
        {
            InvalidSoundDataException.ThrowIfInvalidSoundData(sound);
        }

        internal static void ThrowIfInvalidSoundSize(DiscordSoundData sound)
        {
            if (sound.Sound.GetFileSize(DiscordFileSize.KiloBytes) > 512)
            {
                throw new InvalidSoundboardException("Soundboard sounds must be less or equal to 512kb in size");
            }
        }
    }
}