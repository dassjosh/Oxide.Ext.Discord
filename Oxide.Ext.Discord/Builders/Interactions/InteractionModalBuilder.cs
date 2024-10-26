using System.Collections.Generic;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Builds a Modal Interaction Response Message
    /// </summary>
    public class InteractionModalBuilder
    {
        private readonly InteractionModalMessage _message;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="interaction">Interaction this build is for</param>
        public InteractionModalBuilder(DiscordInteraction interaction) : this(interaction, new InteractionModalMessage()) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="interaction">Interaction this build is for</param>
        /// <param name="message">Starting <see cref="InteractionAutoCompleteMessage"/></param>
        public InteractionModalBuilder(DiscordInteraction interaction, InteractionModalMessage message)
        {
            InteractionResponseBuilderException.ThrowIfInteractionIsAutoComplete(interaction.Type);
            InteractionResponseBuilderException.ThrowIfInteractionIsModalSubmit(interaction.Type);
            _message = message;
            _message.Components ??= new List<ActionRowComponent>();
        }
        
        /// <summary>
        /// Adds a custom ID for the modal
        /// </summary>
        /// <param name="customId">Custom ID for the modal</param>
        public InteractionModalBuilder AddModalCustomId(string customId)
        {
            InvalidMessageComponentException.ThrowIfInvalidCustomId(customId);
            _message.CustomId = customId;
            return this;
        }
        
        /// <summary>
        /// Adds a custom ID for the modal
        /// </summary>
        /// <param name="title">Title for the Modal</param>
        public InteractionModalBuilder AddModalTitle(string title)
        {
            InvalidMessageComponentException.ThrowIfInvalidModalTitle(title);
            _message.Title = title;
            return this;
        }

        /// <summary>
        /// Adds a select menu to a new action row
        /// </summary>
        /// <param name="customId">Unique ID for the select menu</param>
        /// <param name="label">Label for the input text</param>
        /// <param name="style">Style of the Input Text</param>
        /// <param name="value">Default value for the Input Text</param>
        /// <param name="required">Is the Input Text Required to be filled out</param>
        /// <param name="placeholder">Text to display if no value is selected yet</param>
        /// <param name="minLength">The min number of options you must select</param>
        /// <param name="maxLength">The max number of options you can select</param>
        /// <returns><see cref="MessageComponentBuilder"/></returns>
        public InteractionModalBuilder AddInputText(string customId, string label, InputTextStyles style, string value = null, bool? required = null, string placeholder = null, int? minLength = null, int? maxLength = null)
        {
            InvalidMessageComponentException.ThrowIfInvalidCustomId(customId);
            InvalidMessageComponentException.ThrowIfInvalidTextInputLabel(label);
            InvalidMessageComponentException.ThrowIfInvalidTextInputValue(value);
            InvalidMessageComponentException.ThrowIfInvalidTextInputLength(minLength, maxLength);
            InvalidMessageComponentException.ThrowIfInvalidMaxActionRows(_message.Components.Count);
            
            _message.Components.Add(new ActionRowComponent
            {
                Components =
                {
                    new InputTextComponent
                    {
                        CustomId = customId,
                        Label = label,
                        Style = style,
                        Value = value,
                        Required = required,
                        Placeholder = placeholder,
                        MinLength = minLength,
                        MaxLength = maxLength,
                    }
                }
            });

            return this;
        }

        /// <summary>
        /// Returns a built Modal Response Message
        /// </summary>
        /// <returns><see cref="InteractionModalMessage"/></returns>
        public InteractionModalMessage Build()
        {
            return _message;
        }
    }
}