using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/application-role-connection-metadata#application-role-connection-metadata-object-application-role-connection-metadata-structure">Application Role Connection Metadata Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApplicationRoleConnectionMetadata : IDiscordValidation
    {
        /// <summary>
        /// Type of metadata value
        /// </summary>
        [JsonProperty("type")]
        public ApplicationRoleConnectionMetadataType Type { get; set; }
        
        /// <summary>
        /// Dictionary key for the metadata field (must be a-z, 0-9, or _ characters; 1-50 characters)
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }
        
        /// <summary>
        /// Name of the metadata field (1-100 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Translations of the name
        /// </summary>
        [JsonProperty("name_localizations")]
        public Hash<string, string> NameLocalizations { get; set; }
        
        /// <summary>
        /// Description of the metadata field (1-200 characters)
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Translations of the description
        /// </summary>
        [JsonProperty("description_localizations")]
        public Hash<string, string> DescriptionLocalizations { get; set; }

        ///<inheritdoc/>
        public void Validate()
        {
            ApplicationRoleConnectionMetadataException.ThrowIfInvalidKeyException(Key);
            ApplicationRoleConnectionMetadataException.ThrowIfInvalidNameException(Name);
            ApplicationRoleConnectionMetadataException.ThrowIfInvalidDescriptionException(Description);
        }
    }
}