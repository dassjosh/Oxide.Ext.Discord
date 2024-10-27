using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sound-delete-guild-soundboard-sound-delete-event-fields">Guild Soundboard Sound Delete</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SoundboardDeletedEvent
    {
        /// <summary>
        /// ID of the sound that was deleted
        /// </summary>
        [JsonProperty("sound_id")]
        public Snowflake SoundId { get; set; }
        
        /// <summary>
        /// ID of the guild the sound was in
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake GuildId { get; set; }
    }
}