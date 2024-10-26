using Newtonsoft.Json;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#allowed-mentions-object-allowed-mention-types">Allowed Mention Types</a> for a message
    /// </summary>
    [JsonConverter(typeof(DiscordEnumConverter))]
    public enum AllowedMentionTypes : byte
    {
        /// <summary>
        /// Discord Extension doesn't currently support this allowed mention type.
        /// </summary>
        Unknown,
        
        /// <summary>
        /// Controls role mentions
        /// </summary>
        [DiscordEnum("roles")] 
        Roles,
        
        /// <summary>
        /// 	Controls user mentions
        /// </summary>
        [DiscordEnum("users")] 
        Users,
        
        /// <summary>
        /// Controls @everyone and @here mentions
        /// </summary>
        [DiscordEnum("everyone")] 
        Everyone,
    }
}