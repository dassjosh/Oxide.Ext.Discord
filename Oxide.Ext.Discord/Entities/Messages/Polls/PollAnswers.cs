using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/poll#poll-answer-object">Discord Poll Answers</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PollAnswers
    {
        /// <summary>
        /// The ID of the answer
        /// </summary>
        [JsonProperty("answer_id")]
        public int AnswerId { get; set; }
        
        /// <summary>
        /// The data of the answer
        /// </summary>
        [JsonProperty("poll_media")]
        public PollMedia PollMedia { get; set; }
    }
}