using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#reaction-count-details-object">Reaction Count Details Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ReactionCountDetails
    {
        /// <summary>
        /// Count of super reactions
        /// </summary>
        [JsonProperty("burst")]
        public int Burst { get; set; }
        
        /// <summary>
        /// Count of normal reactions
        /// </summary>
        [JsonProperty("normal")]
        public int Normal { get; set; }
    }
}