using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/poll#poll-results-object-poll-answer-count-object-structure">Discord Poll Answer Count</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PollAnswerCount
    {
        /// <summary>
        /// The answer_id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// The number of votes for this answer
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        
        /// <summary>
        /// Whether the current user voted for this answer
        /// </summary>
        [JsonProperty("me_voted")]
        public bool MeVoted { get; set; }
    }
}