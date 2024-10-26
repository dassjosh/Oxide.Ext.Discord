using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/poll#poll-object-poll-object-structure">Discord Poll</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordPoll
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
        /// The time when the poll ends.
        /// </summary>
        [JsonProperty("expiry")]
        public DateTimeOffset? Expiry { get; set; }
        
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
        
        /// <summary>
        ///	The results of the poll
        /// </summary>
        [JsonProperty("results")]
        public PollResults Results { get; set; }
    }
}