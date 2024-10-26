using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-action-object">Auto Mod Action</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AutoModAction
    {
        /// <summary>
        /// Type of <see cref="AutoModActionType"/>
        /// </summary>
        [JsonProperty("type")]
        public AutoModActionType Type { get; set; }
        
        /// <summary>
        /// Additional metadata needed during execution for this specific action type
        /// </summary>
        [JsonProperty("metadata")]
        public AutoModActionMetadata Metadata { get; set; }
    }
}