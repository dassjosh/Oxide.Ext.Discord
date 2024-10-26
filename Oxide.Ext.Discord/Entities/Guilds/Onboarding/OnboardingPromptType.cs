using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-onboarding-object-prompt-types">Prompt Types</a>
    /// </summary>
    public enum OnboardingPromptType : byte
    {
        /// <summary>
        /// Multiple Choice Prompt Type
        /// </summary>
        [DiscordEnum("MULTIPLE_CHOICE")]
        MultipleChoice = 0,
        
        /// <summary>
        /// Dropdown Prompt Type
        /// </summary>
        [DiscordEnum("DROPDOWN")]
        Dropdown = 1,
    }
}