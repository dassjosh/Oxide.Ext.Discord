using Newtonsoft.Json;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/application#get-application-activity-instance-activity-location-kind-enum">Activity Location Kind Enum</a>
    /// </summary>
    [JsonConverter(typeof(DiscordEnumConverter))]
    public enum ActivityLocationKind
    {
        /// <summary>
        /// The Location is a Guild Channel
        /// </summary>
        [DiscordEnum("gc")]
        GuildChannel,
    
        /// <summary>
        /// The Location is a Private Channel, such as a DM or GDM
        /// </summary>
        [DiscordEnum("pc")]
        PrivateChannel
    }
}