namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/application#application-object-application-integration-types">Application Integration Types</a>
    /// </summary>
    public enum ApplicationIntegrationType
    {
        /// <summary>
        /// App is installable to servers
        /// </summary>
        GuildInstall = 0,
        
        /// <summary>
        /// App is installable to users
        /// </summary>
        UserInstall = 1
    }
}