using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/application#application-object-application-integration-type-configuration-object">Application Integration Type Configuration</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApplicationIntegrationTypeConfiguration
    {
        /// <summary>
        /// Install params for each installation context's default in-app authorization link
        /// </summary>
        [JsonProperty("oauth2_install_params")]
        public InstallParams Oauth2InstallParams { get; set; }
    }
}