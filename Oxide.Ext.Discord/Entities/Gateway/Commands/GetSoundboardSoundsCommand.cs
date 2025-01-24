using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#update-voice-state">Update Voice State</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetSoundboardSoundsCommand
    {
        /// <summary>
        /// IDs of the guilds to get soundboard sounds for
        /// </summary>
        [JsonProperty("guild_ids")]
        public List<Snowflake> GuildIds { get; set; }
    }
}