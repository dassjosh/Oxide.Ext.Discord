using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/application#install-params-object">Install Params Structure</a>
    /// </summary>
    public class InstallParams
    {
        /// <summary>
        /// Scopes to add the application to the server with
        /// </summary>
        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; } 
        
        /// <summary>
        /// Permissions to request for the bot role
        /// </summary>
        [JsonProperty("permissions")]
        public string Permissions { get; set; } 
    }
}