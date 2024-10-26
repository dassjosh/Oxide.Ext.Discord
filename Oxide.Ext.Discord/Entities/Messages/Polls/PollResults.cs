using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/poll#poll-results-object">Discord Poll Results</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PollResults
    {
        /// <summary>
        /// Whether the votes have been precisely counted
        /// </summary>
        [JsonProperty("is_finalized")]
        public bool IsFinalized { get; set; }
        
        /// <summary>
        /// The counts for each answer
        /// </summary>
        [JsonProperty("answer_counts")]
        public List<PollAnswerCount> AnswerCounts { get; set; }
    }
}