using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Base Template for Message Components
    /// </summary>
    public abstract class BaseComponentTemplate
    {
        /// <summary>
        /// If the component should be added to the message
        /// </summary>
        [JsonProperty("Show Component")]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Type of the component
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("Type")]
        public MessageComponentType Type { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        protected BaseComponentTemplate() { }
        
        /// <summary>
        /// Represents a base Message Component Template
        /// </summary>
        /// <param name="type"></param>
        protected BaseComponentTemplate(MessageComponentType type)
        {
            Type = type;
        }

        /// <summary>
        /// Returns the built component
        /// </summary>
        /// <param name="data"><see cref="PlaceholderData"/> to use</param>
        /// <returns>Component</returns>
        public abstract BaseComponent ToComponent(PlaceholderData data);
    }
}