using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an error in application command option
    /// </summary>
    public class InvalidCommandOptionException : BaseDiscordException
    {
        private InvalidCommandOptionException(string message) : base(message) { }
        
        internal static void ThrowIfInvalidName(string name, bool allowNullOrEmpty)
        {
            const int MaxLength = 32;
            
            if (!allowNullOrEmpty && string.IsNullOrEmpty(name))
            {
                throw new InvalidCommandOptionException("Name cannot be less than 1 character");
            }
            
            if (name.Length > MaxLength)
            {
                throw new InvalidCommandOptionException($"Name cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidDescription(string description, bool allowNullOrEmpty)
        {
            const int MaxLength = 100;
            
            if (!allowNullOrEmpty && string.IsNullOrEmpty(description))
            {
                throw new InvalidCommandOptionException("Description cannot be less than 1 character");
            }
            
            if (description.Length > MaxLength)
            {
                throw new InvalidCommandOptionException($"Description cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidType(CommandOptionType type)
        {
            if (type == CommandOptionType.SubCommand || type == CommandOptionType.SubCommandGroup)
            {
                throw new InvalidCommandOptionException($"{type} is not allowed to be used here. Valid types are any non command type.");
            }
        }
        
        internal static void ThrowIfInvalidMinIntegerType(CommandOptionType type)
        {
            if (type != CommandOptionType.Integer && type != CommandOptionType.Number)
            {
                throw new InvalidCommandOptionException("Can only set min value for Integer or Number Type");
            }
        }
        
        internal static void ThrowIfInvalidMinNumberType(CommandOptionType type)
        {
            if (type != CommandOptionType.Number)
            {
                throw new InvalidCommandOptionException("Can only set min value for Number Type");
            }
        }
        
        internal static void ThrowIfInvalidMaxIntegerType(CommandOptionType type)
        {
            if (type != CommandOptionType.Integer && type != CommandOptionType.Number)
            {
                throw new InvalidCommandOptionException("Can only set max value for Integer or Number Type");
            }
        }
        
        internal static void ThrowIfInvalidMaxNumberType(CommandOptionType type)
        {
            if (type != CommandOptionType.Number)
            {
                throw new InvalidCommandOptionException("Can only set max value for Number Type");
            }
        }
        
        internal static void ThrowIfInvalidMinLengthType(CommandOptionType type)
        {
            if (type != CommandOptionType.String)
            {
                throw new InvalidCommandOptionException("Can only set min length for string Type");
            }
        }
        
        internal static void ThrowIfInvalidMaxLengthType(CommandOptionType type)
        {
            if (type != CommandOptionType.String)
            {
                throw new InvalidCommandOptionException("Can only set max length for string Type");
            }
        }
        
        internal static void ThrowIfInvalidMinLength(int minLength)
        {
            const int MinLength = 0;
            const int MaxLength = 6000;
            
            if (minLength < MinLength)
            {
                throw new InvalidCommandOptionException($"Min length cannot be less than {MinLength}");
            }

            if (minLength > MaxLength)
            {
                throw new InvalidCommandOptionException($"Min length cannot be more than {MaxLength}");
            }
        }
        
        internal static void ThrowIfInvalidMaxLength(int maxLength)
        {
            const int MinLength = 1;
            const int MaxLength = 6000;
            
            if (maxLength < MinLength)
            {
                throw new InvalidCommandOptionException($"Max length cannot be less than {MinLength}");
            }

            if (maxLength > MaxLength)
            {
                throw new InvalidCommandOptionException($"Max length cannot be more than {MaxLength}");
            }
        }
        
        internal static void ThrowIfInvalidChannelType(CommandOptionType type)
        {
            if (type != CommandOptionType.Channel)
            {
                throw new InvalidCommandOptionException("Can only set ChannelTypes for CommandOptionType.Channel");
            }
        }
    }
}