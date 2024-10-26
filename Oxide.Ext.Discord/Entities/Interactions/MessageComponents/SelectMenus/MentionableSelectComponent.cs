using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#select-menus">Select Menus Component</a> within discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MentionableSelectComponent : BaseSelectMenuComponent
    {
        /// <summary>
        /// Select Menu Component Constructor
        /// </summary>
        public MentionableSelectComponent() : base(MessageComponentType.MentionableSelect) { }
    }
}