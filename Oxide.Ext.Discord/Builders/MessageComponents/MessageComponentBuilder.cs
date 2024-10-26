using System;
using System.Collections.Generic;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Builder for Message Components
    /// </summary>
    public class MessageComponentBuilder
    {
        private readonly List<ActionRowComponent> _components = new();
        private ActionRowComponent _current;
        
        /// <summary>
        /// Creates a new MessageComponentBuilder
        /// </summary>
        public MessageComponentBuilder()
        {
            _current = new ActionRowComponent();
            _components.Add(_current);
        }

        /// <summary>
        /// Adds an action button to the current action row
        /// </summary>
        /// <param name="style">Button Style <a href="https://discord.com/developers/docs/interactions/message-components#button-object-button-styles">Button Styles</a></param>
        /// <param name="label">The text of the button</param>
        /// <param name="customId">The unique id of the button. Used to identify which button was clicked</param>
        /// <param name="disabled">If this button is disabled</param>
        /// <param name="addToNewRow">Should the button be added to a new row</param>
        /// <param name="emoji">Emoji to display with the button</param>
        /// <returns><see cref="MessageComponentBuilder"/></returns>
        /// <exception cref="Exception">
        ///     Throw if the button style is a link or if the button goes outside the max number of action rows
        /// </exception>
        public MessageComponentBuilder AddActionButton(ButtonStyle style, string label, string customId, bool disabled = false, bool addToNewRow = false, DiscordEmoji emoji = null)
        {
            InvalidMessageComponentException.ThrowIfInvalidButtonLabel(label);
            MessageComponentBuilderException.ThrowIfInvalidActionButtonStyle(style);
            InvalidMessageComponentException.ThrowIfInvalidCustomId(customId);

            UpdateActionRow<ButtonComponent>(addToNewRow);
            _current.Components.Add(new ButtonComponent
            {
                Style = style,
                Label = label,
                CustomId = customId,
                Disabled = disabled,
                Emoji = emoji
            });
            return this;
        }
        
        /// <summary>
        /// Adds a dummy button that doesn't do anything
        /// </summary>
        /// <param name="label">The text of the button</param>
        /// <param name="disabled">If this button is disabled</param>
        /// <returns><see cref="MessageComponentBuilder"/></returns>
        /// <exception cref="Exception"> Throw if the button goes outside the max number of action rows</exception>
        public MessageComponentBuilder AddDummyButton(string label, bool disabled = true)
        {
            return AddActionButton(ButtonStyle.Secondary, label, $"DUMMY_{_components.Count * 5 + _current.Components.Count}", disabled);
        }

        /// <summary>
        /// Adds a link button to the current action row
        /// </summary>
        /// <param name="label">Text on the button</param>
        /// <param name="url">URL for the button</param>
        /// <param name="disabled">if the button should be disabled</param>
        /// <param name="addToNewRow">Show the button be added to a new row</param>
        /// <param name="emoji">Emoji to display on the button</param>
        /// <returns><see cref="MessageComponentBuilder"/></returns>
        /// <exception cref="Exception">Thrown if the button goes outside the max number of action rows</exception>
        public MessageComponentBuilder AddLinkButton(string label, string url, bool disabled = false, bool addToNewRow = false, DiscordEmoji emoji = null)
        {
            InvalidMessageComponentException.ThrowIfInvalidButtonUrl(url);
            
            UpdateActionRow<ButtonComponent>(addToNewRow);
            _current.Components.Add(new ButtonComponent
            {
                Style = ButtonStyle.Link,
                Label = label,
                Url = url,
                Disabled = disabled,
                Emoji = emoji
            });
            return this;
        }

        /// <summary>
        /// Adds a select menu to a new action row
        /// </summary>
        /// <param name="type">Select Menu Message Component Type</param>
        /// <param name="customId">Unique ID for the select menu</param>
        /// <param name="placeholder">Text to display if no value is selected yet</param>
        /// <param name="minValues">The min number of options you must select</param>
        /// <param name="maxValues">The max number of options you can select</param>
        /// <param name="disabled">If the select menu should be disabled</param>
        /// <returns><see cref="SelectMenuComponentBuilder"/></returns>
        public SelectMenuComponentBuilder AddSelectMenu(MessageComponentType type, string customId, string placeholder, int minValues = 1, int maxValues = 1, bool disabled = false)
        {
            InvalidMessageComponentException.ThrowIfInvalidCustomId(customId);
            InvalidSelectMenuComponentException.ThrowIfInvalidSelectMenuPlaceholder(placeholder);
            InvalidSelectMenuComponentException.ThrowIfInvalidSelectMenuMinValues(minValues);
            InvalidSelectMenuComponentException.ThrowIfInvalidSelectMenuMaxValues(maxValues);
            InvalidSelectMenuComponentException.ThrowIfInvalidSelectMenuValueRange(minValues, maxValues);
            
            UpdateActionRow<BaseSelectMenuComponent>(false);

            BaseSelectMenuComponent select = type switch
            {
                MessageComponentType.StringSelect => new StringSelectComponent(),
                MessageComponentType.UserSelect => new UserSelectComponent(),
                MessageComponentType.RoleSelect => new RoleSelectComponent(),
                MessageComponentType.MentionableSelect => new MentionableSelectComponent(),
                MessageComponentType.ChannelSelect => new ChannelSelectComponent(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            select.CustomId = customId;
            select.Placeholder = placeholder;
            select.MinValues = minValues;
            select.MaxValues = maxValues;
            select.Disabled = disabled;
            
            _current.Components.Add(select);
            return new SelectMenuComponentBuilder(select, this);
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
        public MessageComponentBuilder AddInputText(string customId, string label, InputTextStyles style, string value = null, bool? required = null, string placeholder = null, int? minLength = null, int? maxLength = null)
        {
            InvalidMessageComponentException.ThrowIfInvalidCustomId(customId);
            InvalidMessageComponentException.ThrowIfInvalidTextInputLabel(label);
            InvalidMessageComponentException.ThrowIfInvalidTextInputValue(value);
            InvalidMessageComponentException.ThrowIfInvalidTextInputLength(minLength, maxLength);

            UpdateActionRow<InputTextComponent>(false);
            InputTextComponent menu = new()
            {
                CustomId = customId,
                Label = label,
                Style = style,
                Value = value,
                Required = required,
                Placeholder = placeholder,
                MinLength = minLength,
                MaxLength = maxLength,
            };
            _current.Components.Add(menu);
            return this;
        }

        private void UpdateActionRow<T>(bool forceRow) where T : BaseComponent
        {
            if (_current.Components.Count == 0)
            {
                return;
            }

            //5 buttons allowed per row
            if (!forceRow && typeof(T) == typeof(ButtonComponent) && _current.Components.Count < 5)
            {
                return;
            }

            //All other components are only 1 per action row, so add a new row.
            _current = new ActionRowComponent();
            _components.Add(_current);
            InvalidMessageComponentException.ThrowIfInvalidMaxActionRows(_components.Count);
        }

        /// <summary>
        /// Returns the built action rows
        /// </summary>
        /// <returns></returns>
        public List<ActionRowComponent> Build()
        {
            return _components;
        }
    }
}