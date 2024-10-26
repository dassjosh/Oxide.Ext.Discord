using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents a template for select menus
    /// </summary>
    public class SelectMenuTemplate : BaseComponentTemplate
    {
        /// <summary>
        /// Command for the Select Menu
        /// </summary>
        [JsonProperty("Select Menu ID")]
        public string CustomId { get; set; } = string.Empty;
        
        /// <summary>
        /// Custom placeholder text if nothing is selected
        /// Max 150 characters
        /// </summary>
        [JsonProperty("Select Menu Placeholder Text")]
        public string Placeholder { get; set; }
        
        /// <summary>
        /// The choices in the select
        /// Max 25 options
        /// </summary>
        [JsonProperty("Select Menu Options")]
        public List<SelectMenuOptionTemplate> Options { get; set; }

        /// <summary>
        /// <see cref="MessageComponentType.ChannelSelect"/> <see cref="ChannelType"/> to show
        /// Max 25 options
        /// </summary>
        [JsonProperty("Select Menu Channel Types")]
        public List<ChannelType> ChannelTypes { get; set; } = new();

        /// <summary>
        /// the minimum number of items that must be chosen
        /// Default 1, Min 0, Max 25
        /// </summary>
        [JsonProperty("Select Menu Min Selected Values")]
        public int MinValues { get; set; } = 1;

        /// <summary>
        /// the maximum  number of items that must be chosen
        /// Default 1, Min 0, Max 25
        /// </summary>
        [JsonProperty("Select Menu Max Selected Values")]
        public int MaxValues { get; set; } = 1;

        /// <summary>
        /// If the Button is enabled
        /// </summary>
        [JsonProperty("Select Menu Enabled")]
        public bool Enabled { get; set; } = true;


        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public SelectMenuTemplate() { }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        public SelectMenuTemplate(MessageComponentType type) : base(type)
        {
            InvalidSelectMenuComponentException.ThrowIfInvalidComponentType(type);
        }

        ///<inheritdoc/>
        public override BaseComponent ToComponent(PlaceholderData data)
        {
            data?.IncrementDepth();
            BaseSelectMenuComponent component;
            switch (Type)
            {
                case MessageComponentType.StringSelect:
                    StringSelectComponent text = new();
                    component = text;
                    if (Options != null)
                    {
                        for (int index = 0; index < Options.Count; index++)
                        {
                            text.Options.Add(Options[index].ToOption(data));
                        }
                    }
                    break;
                
                case MessageComponentType.UserSelect:
                    component = new UserSelectComponent();
                    break;
                
                case MessageComponentType.RoleSelect:
                    component = new RoleSelectComponent();
                    break;
                
                case MessageComponentType.MentionableSelect:
                    component = new MentionableSelectComponent();
                    break;
                
                case MessageComponentType.ChannelSelect:
                    ChannelSelectComponent channel = new();
                    component = channel;
                    channel.ChannelTypes = ChannelTypes = ChannelTypes != null && ChannelTypes.Count != 0 ? ChannelTypes : null;
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }

            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            component.CustomId = placeholders.ProcessPlaceholders(CustomId, data);
            component.Placeholder = placeholders.ProcessPlaceholders(Placeholder, data);
            component.MinValues = MinValues;
            component.MaxValues = MaxValues;
            component.Disabled = !Enabled;
            
            data?.DecrementDepth();
            data?.AutoDispose();
            
            return component;
        }

        private bool ShouldSerializeOptions() => Type == MessageComponentType.StringSelect;
        private bool ShouldSerializeChannelTypes() => Type == MessageComponentType.ChannelSelect;
    }
}