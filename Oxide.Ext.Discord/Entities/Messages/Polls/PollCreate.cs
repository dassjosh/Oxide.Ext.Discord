using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/poll#poll-create-request-object-poll-create-request-object-structure">Discord Poll Create</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PollCreate
    {
        /// <summary>
        /// The question of the poll. Only text is supported.
        /// </summary>
        [JsonProperty("question")]
        public PollMedia Question { get; set; }
        
        /// <summary>
        /// Each of the answers available in the poll.
        /// </summary>
        [JsonProperty("answers")]
        public List<PollAnswers> Answers { get; set; }
        
        /// <summary>
        /// Number of hours the poll should be open for, up to 32 days
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }
        
        /// <summary>
        ///	Whether a user can select multiple answers
        /// </summary>
        [JsonProperty("allow_multiselect")]
        public bool AllowMultiselect { get; set; }
        
        /// <summary>
        ///	The layout type of the poll
        /// </summary>
        [JsonProperty("layout_type")]
        public PollLayoutType LayoutType { get; set; }
    }
}