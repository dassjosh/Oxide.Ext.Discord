namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an invalid discord color
    /// </summary>
    public class InvalidDiscordColorException : BaseDiscordException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        private InvalidDiscordColorException(string message) : base(message)
        {
            
        }

        internal static void ThrowIfInvalidColor(uint color)
        {
            if (color > 0xFFFFFF)
            {
                throw new InvalidDiscordColorException($"Color '{color}' is greater than the max color of 0xFFFFFF");
            }
        }

        internal static void ThrowIfOutOfColorRange(string color, int value)
        {
            if (value < 0 || value > byte.MaxValue)
            {
                throw new InvalidDiscordColorException($"{color} must be between 0 - 255");
            }
        }
        
        internal static void ThrowIfOutOfColorRange(string color, uint value)
        {
            if (value > byte.MaxValue)
            {
                throw new InvalidDiscordColorException($"{color} must be between 0 - 255");
            }
        }
        
        internal static void ThrowIfOutOfColorRange(string color, float value)
        {
            if (value < 0f || value > 1f)
            {
                throw new InvalidDiscordColorException($"{color} must be between 0 - 255");
            }
        }
    }
}