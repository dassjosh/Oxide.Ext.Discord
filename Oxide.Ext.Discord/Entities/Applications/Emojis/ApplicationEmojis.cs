using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/emoji#list-application-emojis">Application Emojis</a>
    /// </summary>
    public class ApplicationEmojis
    {
        /// <summary>
        /// List of application emojis
        /// </summary>
        [JsonProperty("items")]
        public List<DiscordEmoji> Items { get; set; }
    }
}