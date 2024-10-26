using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception for select menu components
    /// </summary>
    public class InvalidSelectMenuComponentException : BaseDiscordException
    {
        private InvalidSelectMenuComponentException(string message) : base(message) { }
        
        internal static void ThrowIfInvalidSelectMenuPlaceholder(string placeholder)
        {
            const int MaxLength = 150;
            
            if (!string.IsNullOrEmpty(placeholder) && placeholder.Length > MaxLength)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Placeholder cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidSelectMenuMinValues(int? minValues)
        {
            const int MinMinValues = 0;
            const int MaxMinValues = 25;
            
            if (!minValues.HasValue)
            {
                return;
            }
            
            if (minValues < MinMinValues)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Min Values cannot be less than {MinMinValues}");
            }
            
            if (minValues > MaxMinValues)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Min Values cannot be more than {MaxMinValues}");
            }
        }
        
        internal static void ThrowIfInvalidSelectMenuMaxValues(int? maxValues)
        {
            const int MaxMaxValues = 25;
            
            if (maxValues > MaxMaxValues)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Max Values cannot be more than {MaxMaxValues}");
            }
        }

        internal static void ThrowIfInvalidSelectMenuValueRange(int? minValues, int? maxValues)
        {
            if (!minValues.HasValue && !maxValues.HasValue)
            {
                return;
            }
            
            if (maxValues < minValues)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Max Values {maxValues} cannot be less min values {minValues}");
            }
        }
        
        internal static void ThrowIfInvalidSelectMenuOptionLabel(string label)
        {
            const int MaxLength = 100;
            
            if (string.IsNullOrEmpty(label))
            {
                throw new InvalidSelectMenuComponentException("Select Menu Option Label cannot be less than 1 character");
            }
            
            if (label.Length > MaxLength)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Option Label cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidSelectMenuOptionValue(string value)
        {
            const int MaxLength = 100;
            
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidSelectMenuComponentException("Select Menu Option Value cannot be less than 1 character");
            }
            
            if (value.Length > MaxLength)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Option Value cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidSelectMenuOptionDescription(string description)
        {
            const int MaxLength = 100;
            
            if (!string.IsNullOrEmpty(description) && description.Length > MaxLength)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Option Description cannot be more than {MaxLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidSelectMenuOptionCount(int count)
        {
            const int MaxOptions = 25;
            
            if (count > MaxOptions)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Option Count cannot be more than {MaxOptions}");
            }
        }

        internal static void ThrowIfInvalidComponentType(MessageComponentType type)
        {
            switch (type)
            {
                case MessageComponentType.ActionRow:
                case MessageComponentType.Button:
                case MessageComponentType.StringSelect:
                case MessageComponentType.InputText:
                    throw new InvalidSelectMenuComponentException($"'{type}' is not a valid type for a SelectMenu.");
            }
        }
        
        internal static void ThrowIfTypeCantAddOptions(MessageComponentType type)
        {
            if (type != MessageComponentType.StringSelect)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Type '{type}' is not allowed to add Options. Options can only be added on {nameof(MessageComponentType)}{MessageComponentType.StringSelect}");
            }
        }
        
        internal static void ThrowIfTypeCantAddChannelTypes(MessageComponentType type)
        {
            if (type != MessageComponentType.ChannelSelect)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Type '{type}' is not allowed to add Channel Types. Channel Types can only be added on {nameof(MessageComponentType)}{MessageComponentType.ChannelSelect}");
            }
        }
        
        internal static void ThrowIfCantAddDefaultValue(MessageComponentType type)
        {
            if (type != MessageComponentType.ChannelSelect && type != MessageComponentType.RoleSelect && type != MessageComponentType.UserSelect)
            {
                throw new InvalidSelectMenuComponentException($"Select Menu Default Value can only be used on {nameof(MessageComponentType)}{MessageComponentType.ChannelSelect} or {nameof(MessageComponentType)}{MessageComponentType.RoleSelect} or {nameof(MessageComponentType)}{MessageComponentType.UserSelect}");
            }
        }
    }
}