namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#onboarding-mode">Guild Onboarding Mode Structure</a>
    /// </summary>
    public enum GuildOnboardingMode
    {
        /// <summary>
        /// Counts only Default Channels towards constraints
        /// </summary>
        OnboardingDefault = 0,
        
        /// <summary>
        /// Counts Default Channels and Questions towards constraints
        /// </summary>
        OnboardingAdvanced = 1
    }
}