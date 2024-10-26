using Newtonsoft.Json;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#select-menu-object-select-default-value-structure">Select Menus Default Value Type</a> within discord.
    /// </summary>
    [JsonConverter(typeof(DiscordEnumConverter))]
    public enum SelectMenuDefaultValueType
    {
        /// <summary>
        /// Select Menu Default Value Type is User
        /// </summary>
        [DiscordEnum("user")]
        User,
        
        /// <summary>
        /// Select Menu Default Value Type is Role
        /// </summary>
        [DiscordEnum("role")]
        Role,
        
        /// <summary>
        /// Select Menu Default Value Type is Channel
        /// </summary>
        [DiscordEnum("channel")]
        Channel
    }
}