using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sounds-update-guild-soundboard-sounds-update-event-fields">Guild Soundboard Sounds Update</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SoundboardSoundsUpdatedEvent
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