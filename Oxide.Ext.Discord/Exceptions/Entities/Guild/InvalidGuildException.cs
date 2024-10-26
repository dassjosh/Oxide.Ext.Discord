using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in guild
    /// </summary>
    public class InvalidGuildException : BaseDiscordException
    {
        private InvalidGuildException(string message) : base(message) { }
        
        internal static void ThrowIfInvalidName(string name, bool allowNullOrEmpty)
        {
            const int MinLength = 2;
            const int MaxLength = 100;
            
            if (!allowNullOrEmpty && (string.IsNullOrEmpty(name) || name.Length < MinLength))
            {
                throw new InvalidGuildException($"{nameof(GuildCreate)}.{nameof(GuildCreate.Name)} cannot be less than {MinLength} character");
            }
            
            if (name.Length > MaxLength)
            {
                throw new InvalidGuildException($"{nameof(GuildCreate)}.{nameof(GuildCreate.Name)} cannot be more than {MaxLength} characters");
            }
        }
    }
}