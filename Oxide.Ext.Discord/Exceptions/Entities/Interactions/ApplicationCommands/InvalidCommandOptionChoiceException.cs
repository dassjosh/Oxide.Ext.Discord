using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an error in application command option choice
    /// </summary>
    public class InvalidCommandOptionChoiceException : BaseDiscordException
    {
        private InvalidCommandOptionChoiceException(string message) : base(message) { }
        
        internal static void ThrowIfMaxChoices(int count)
        {
            const int MaxChoices = 25;
            
            if (count > MaxChoices)
            {
                throw new InvalidCommandOptionChoiceException($"Cannot have more than {MaxChoices} Command Option Choices");
            }
        }

        internal static void ThrowIfInvalidName(string name, bool allowNullOrEmpty)
        {
            const int MaxLength = 100;
            
            if (!allowNullOrEmpty && string.IsNullOrEmpty(name))
            {
                throw new InvalidCommandOptionChoiceException("Name cannot be less than 1 character");
            }
            
            if (name.Length > MaxLength)
            {
                throw new InvalidCommandOptionChoiceException($"Name cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidStringValue(string value)
        {
            const int MaxLength = 100;
            
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidCommandOptionChoiceException("Value cannot be less than 1 character");
            }
            
            if (value.Length > MaxLength)
            {
                throw new InvalidCommandOptionChoiceException($"Value cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidType(CommandOptionType value, CommandOptionType expected)
        {
            if (value != expected)
            {
                throw new InvalidCommandOptionChoiceException($"Cannot add a {value} choice type to type: {expected}");
            }
        }
    }
}