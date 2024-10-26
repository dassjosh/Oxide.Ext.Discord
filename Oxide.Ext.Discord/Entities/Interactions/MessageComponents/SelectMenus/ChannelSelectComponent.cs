using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#select-menus">Select Menus Component</a> within discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ChannelSelectComponent : BaseSelectMenuComponent
    {
        /// <summary>
        /// List of channel types to include in the channel select component
        /// </summary>
        [JsonProperty("channel_types")]
        public List<ChannelType> ChannelTypes { get; set; } = new();

        /// <summary>
        /// Select Menu Component Constructor
        /// </summary>
        public ChannelSelectComponent() : base(MessageComponentType.ChannelSelect) { }
    }
}