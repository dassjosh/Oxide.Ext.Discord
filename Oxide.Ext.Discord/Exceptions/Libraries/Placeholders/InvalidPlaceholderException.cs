using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exception thrown if <see cref="PlaceholderKey"/> is not valid
    /// </summary>
    public class InvalidPlaceholderException : BaseDiscordException
    {
        private InvalidPlaceholderException(string message) : base(message) { }

        internal static void ThrowIfInvalid(PlaceholderKey key)
        {
            if (!key.IsValid)
            {
                throw new InvalidPlaceholderException("PlaceholderKey is not valid");
            }
        }
    }
}