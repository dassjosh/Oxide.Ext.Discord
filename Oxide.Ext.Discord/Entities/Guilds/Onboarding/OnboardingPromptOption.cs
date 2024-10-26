using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-onboarding-object-prompt-option-structure">Prompt Option Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OnboardingPromptOption
    {
        /// <summary>
        /// ID of the prompt option
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// IDs for channels a member is added to when the option is selected
        /// </summary>
        [JsonProperty("channel_ids")]
        public List<Snowflake> ChannelIds { get; set; }
        
        /// <summary>
        /// IDs for roles assigned to a member when the option is selected
        /// </summary>
        [JsonProperty("role_ids")]
        public List<Snowflake> RoleIds { get; set; }
        
        /// <summary>
        /// Emoji of the option
        /// </summary>
        [JsonProperty("emoji")]
        public DiscordEmoji Emoji { get; set; }
        
        /// <summary>
        /// Title of the option
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Description of the option
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}