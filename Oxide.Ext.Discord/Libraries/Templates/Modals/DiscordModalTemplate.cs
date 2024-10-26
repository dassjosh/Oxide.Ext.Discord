using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Template used for Modal Message Component
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordModalTemplate
    {
        /// <summary>
        /// Title of the modal
        /// </summary>
        [JsonProperty("Modal Title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Title of the modal
        /// </summary>
        [JsonProperty("Modal ID")]
        public string CustomId { get; set; }

        /// <summary>
        /// Components of the Modal
        /// </summary>
        [JsonConverter(typeof(TemplateComponentsConverter))]
        [JsonProperty("Modal Components")]
        public List<BaseComponentTemplate> Components { get; set; } = new();
        
        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public DiscordModalTemplate() {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="customId"></param>
        public DiscordModalTemplate(string title, string customId)
        {
            Title = title;
            CustomId = customId;
        }
        
        /// <summary>
        /// Converts the template to a <see cref="InteractionModalMessage"/>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="modal"></param>
        /// <returns></returns>
        public InteractionModalMessage ToModal(PlaceholderData data = null, InteractionModalMessage modal = null)
        {
            modal ??= new InteractionModalMessage();
            
            data?.IncrementDepth();

            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            
            modal.Title = placeholders.ProcessPlaceholders(Title, data);
            modal.CustomId = placeholders.ProcessPlaceholders(CustomId, data);
            modal.Components = new List<ActionRowComponent>();

            for (int index = 0; index < Components.Count; index++)
            {
                BaseComponentTemplate component = Components[index];
                if (component is InputTextTemplate input && input.Visible)
                {
                    InvalidMessageComponentException.ThrowIfInvalidMaxActionRows(modal.Components.Count);
                    modal.Components.Add(new ActionRowComponent
                    {
                        Components = { input.ToComponent(data) }
                    });
                }
            }
            
            data?.DecrementDepth();
            data?.AutoDispose();

            return modal;
        }
    }
}