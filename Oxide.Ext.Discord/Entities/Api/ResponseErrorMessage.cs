using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents an <a href="https://discord.com/developers/docs/reference#error-messages">error from the discord API</a> 
    /// </summary>
    public class ResponseErrorMessage
    {
        /// <summary>
        /// Error code from the discord API
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
        
        /// <summary>
        /// Error message from the discord API
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        
        /// <summary>
        /// An JObject containing the errors that occured
        /// </summary>
        [JsonProperty("errors")]
        public JObject Errors { get; set; }
    }
}