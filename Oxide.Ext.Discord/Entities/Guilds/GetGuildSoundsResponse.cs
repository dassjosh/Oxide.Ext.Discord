using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/soundboard#list-guild-soundboard-sounds-response-structure">Get Guild Sounds Response</a> in Discord
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetGuildSoundsResponse
    {
        /// <summary>
        /// Soundboard sounds for the guild
        /// </summary>
        [JsonProperty("items")]
        public List<DiscordSoundboardSound> Items { get; set; }
    }
}