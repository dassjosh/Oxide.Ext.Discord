using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/events/gateway-events#soundboard-sounds-soundboard-sounds-event-fields">Soundboard Sounds Event Fields</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GetGuildSoundboardSoundsEvent
    {
        /// <summary>
        /// The guild's soundboard sounds
        /// </summary>
        [JsonProperty("soundboard_sounds")]
        public List<DiscordSoundboardSound> SoundboardSounds { get; set; }
        
        /// <summary>
        /// ID of the guild the sound was in
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake GuildId { get; set; }
    }
}