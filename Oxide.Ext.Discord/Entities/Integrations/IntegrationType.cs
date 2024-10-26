using Newtonsoft.Json;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents Integrations types
    /// </summary>
    [JsonConverter(typeof(DiscordEnumConverter))]
    public enum IntegrationType : byte
    {
        /// <summary>
        /// Integration is for twitch
        /// </summary>
        [DiscordEnum("twitch")] 
        Twitch,
        
        /// <summary>
        /// Integration is for youtube
        /// </summary>
        [DiscordEnum("youtube")] 
        Youtube,
        
        /// <summary>
        /// integration is for discord
        /// </summary>
        [DiscordEnum("discord")] 
        Discord,
        
        /// <summary>
        /// integration is for guild subscription
        /// </summary>
        [DiscordEnum("guild_subscription")] 
        GuildSubscription
    }
}