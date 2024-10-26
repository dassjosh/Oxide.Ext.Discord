using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#buttons">Button Component</a> within discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ButtonComponent : BaseInteractableComponent
    {
        /// <summary>
        /// Style for the button component
        /// </summary>
        [JsonProperty("style")]
        public ButtonStyle Style { get; set; }

        /// <summary>
        /// Text that appears on the button
        /// Max 80 characters
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Emoji on the component
        /// </summary>
        [JsonProperty("emoji")]
        public DiscordEmoji Emoji { get; set; }

        /// <summary>
        /// Identifier for a purchasable SKU, only available when using premium-style buttons
        /// </summary>
        [JsonProperty("sku_id")]
        public Snowflake? SkuId { get; set; }
        
        /// <summary>
        /// URL for link-style buttons
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Whether the button is disabled
        /// Default false
        /// </summary>
        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }

        /// <summary>
        /// Constructor for button
        /// Sets type to button
        /// </summary>
        public ButtonComponent()
        {
            Type = MessageComponentType.Button;
        }

        ///<inheritdoc />
        public override void Validate()
        {
            base.Validate();
            InvalidMessageComponentException.ThrowIfInvalidButtonLabel(Label);
            if (Style == ButtonStyle.Link)
            {
                InvalidMessageComponentException.ThrowIfInvalidButtonUrl(Url);
            }
        }
    }
}