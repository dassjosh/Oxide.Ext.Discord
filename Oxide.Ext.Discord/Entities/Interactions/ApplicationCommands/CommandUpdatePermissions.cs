using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/application-commands#edit-application-command-permissions-json-params">Edit Application Command Permissions</a>
    /// </summary>
    public class CommandUpdatePermissions
    {
        /// <summary>
        /// Permissions for the command in the guild
        /// </summary>
        [JsonProperty("permissions")]
        public List<CommandPermissions> Permissions { get; set; }
    }
}