using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#get-guild-prune-count">Guild Prune Count Response</a>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#begin-guild-prune">Guild Prune Begin Response</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GuildPruneResult
    {
        /// <summary>
        /// Number of members pruned
        /// </summary>
        [JsonProperty("pruned")]
        public int Pruned { get; set; }
    }
}