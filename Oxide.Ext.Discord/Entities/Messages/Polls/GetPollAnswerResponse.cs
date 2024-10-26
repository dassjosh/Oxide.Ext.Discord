using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/poll#get-answer-voters-response-body">Get Poll Answers Response</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetPollAnswerResponse
    {
        /// <summary>
        /// Users who voted for this answer
        /// </summary>
        [JsonProperty("users")]
        public List<DiscordUser> Users { get; set; } 
    }
}