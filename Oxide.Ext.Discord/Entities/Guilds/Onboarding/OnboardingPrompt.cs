using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-onboarding-object-onboarding-prompt-structure">Onboarding Prompt Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OnboardingPrompt
    {
        /// <summary>
        /// ID of the prompt
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// Type of prompt
        /// </summary>
        [JsonProperty("type")]
        public OnboardingPromptType Type { get; set; }
        
        /// <summary>
        /// Options available within the prompt
        /// </summary>
        [JsonProperty("options")]
        public List<OnboardingPromptOption> Options { get; set; }
        
        /// <summary>
        /// Title of the prompt
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Indicates whether users are limited to selecting one option for the prompt
        /// </summary>
        [JsonProperty("single_select")]
        public bool SingleSelect { get; set; }
        
        /// <summary>
        /// Indicates whether the prompt is required before a user completes the onboarding flow
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }
        
        /// <summary>
        /// Indicates whether the prompt is present in the onboarding flow.
        /// If false, the prompt will only appear in the Channels and Roles tab
        /// </summary>
        [JsonProperty("in_onboarding")]
        public bool InOnboarding { get; set; }
    }
}