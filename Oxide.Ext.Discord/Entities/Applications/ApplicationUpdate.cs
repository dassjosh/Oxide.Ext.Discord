using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/application#edit-current-application-json-params">Edit Application Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApplicationUpdate
    {
        /// <summary>
        /// Default custom authorization URL for the app, if enabled
        /// </summary>
        [JsonProperty("custom_install_url")]
        public string CustomInstallUrl { get; set; } 
        
        /// <summary>
        /// Description of the app
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Role connection verification URL for the app
        /// </summary>
        [JsonProperty("role_connections_verification_url")]
        public string RoleConnectionsVerificationUrl { get; set; } 
        
        /// <summary>
        /// Settings for the application's default in-app authorization link, if enabled
        /// </summary>
        [JsonProperty("install_params")]
        public InstallParams InstallParams { get; set; } 
        
        /// <summary>
        /// Default scopes and permissions for each supported installation context.
        /// </summary>
        [JsonProperty("integration_types_config")]
        public Hash<ApplicationIntegrationType, ApplicationIntegrationTypeConfiguration> IntegrationTypesConfig { get; set; }
        
        /// <summary>
        /// App's public flags
        /// </summary>
        [JsonProperty("flags")]
        public ApplicationFlags? Flags { get; set; }
        
        /// <summary>
        /// Icon for the app
        /// </summary>
        [JsonProperty("icon")]
        public DiscordImageData? Icon { get; set; }
        
        /// <summary>
        /// Default rich presence invite cover image for the app
        /// </summary>
        [JsonProperty("cover_image")]
        public DiscordImageData? CoverImage { get; set; }
        
        /// <summary>
        /// Interactions endpoint URL for the app
        /// </summary>
        [JsonProperty("interactions_endpoint_url")]
        public string InteractionsEndpointUrl { get; set; } 
        
        /// <summary>
        /// List of tags describing the content and functionality of the app (max of 20 characters per tag). Max of 5 tags.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; } 
    }
}