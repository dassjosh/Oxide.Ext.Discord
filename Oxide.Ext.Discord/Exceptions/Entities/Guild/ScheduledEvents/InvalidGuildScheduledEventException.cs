namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in guild scheduled events
    /// </summary>
    public class InvalidGuildScheduledEventException : BaseDiscordException
    {
        private InvalidGuildScheduledEventException(string message) : base(message) { }
        
        internal static void ThrowIfInvalidName(string name, bool allowNullOrEmpty)
        {
            const int MaxLength = 100;
            
            if (!allowNullOrEmpty && string.IsNullOrEmpty(name))
            {
                throw new InvalidGuildScheduledEventException($"Name cannot be less than 1 character");
            }
            
            if (name.Length > MaxLength)
            {
                throw new InvalidGuildScheduledEventException($"Name cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidDescription(string description)
        {
            const int MaxLength = 1000;
            
            if (!string.IsNullOrEmpty(description) && description.Length > MaxLength)
            {
                throw new InvalidGuildScheduledEventException($"Description cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidLocation(string location)
        {
            const int MaxLength = 100;
            
            if (!string.IsNullOrEmpty(location) && location.Length > 100)
            {
                throw new InvalidGuildScheduledEventException($"Location cannot be more than {MaxLength} characters");
            }
        }
    }
}