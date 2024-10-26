using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/application-commands#bulk-overwrite-guild-application-commands-bulk-application-command-json-params">Bulk Overwrite Guild Application Commands</a>
    /// </summary>
    public class CommandBulkOverwrite
    {
        /// <summary>
        /// ID of command, if known
        /// </summary>
        [JsonProperty("id")]
        public Snowflake? Id { get; set; }
        
        /// <summary>
        /// 1-32 lowercase character name matching ^[\w-]{1,32}$
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Localization dictionary for the name field. Values follow the same restrictions as name
        /// </summary>
        [JsonProperty("name_localizations")]
        public Hash<string, string> NameLocalizations { get; set; }
        
        /// <summary>
        /// Description of the command (1-100 characters)
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Localization dictionary for the description field. Values follow the same restrictions as description
        /// </summary>
        [JsonProperty("description_localizations")]
        public Hash<string, string> DescriptionLocalizations { get; set; }
        
        /// <summary>
        /// The parameters for the command
        /// See <see cref="CommandOption"/>
        /// </summary>
        [JsonProperty("options")]
        public List<CommandOption> Options { get; set; }
        
        /// <summary>
        /// Set of permissions represented as a bit set
        /// </summary>
        [JsonProperty("default_member_permissions")]
        [JsonConverter(typeof(PermissionFlagsStringConverter))]
        public PermissionFlags DefaultMemberPermissions { get; set; }
        
        /// <summary>
        /// Indicates whether the command is available in DMs with the app, only for globally-scoped commands. By default, commands are visible.
        /// </summary>
        [JsonProperty("dm_permission")]
        public bool? DmPermission { get; set; }
        
        /// <summary>
        /// Whether the command is enabled by default when the app is added to a guild
        /// </summary>
        [JsonProperty("default_permission")]
        public bool? DefaultPermissions { get; set; }
        
        /// <summary>
        /// Indicates whether the command is age-restricted
        /// </summary>
        [JsonProperty("nsfw")]
        public bool? Nsfw { get; set; }
    }
}