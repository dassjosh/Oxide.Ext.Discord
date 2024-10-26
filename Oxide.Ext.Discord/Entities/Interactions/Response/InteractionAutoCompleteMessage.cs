using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Interaction Auto Complete Response Message
    /// </summary>
    public class InteractionAutoCompleteMessage
    {
        /// <summary>
        /// Autocomplete choices (max of 25 choices)
        /// </summary>
        [JsonProperty("choices")]
        public List<CommandOptionChoice> Choices { get; set; }
    }
}