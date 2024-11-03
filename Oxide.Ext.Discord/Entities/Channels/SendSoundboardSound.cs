using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/soundboard#send-soundboard-sound-json-params">Send Soundboard Sound Request</a> in Discord
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SendSoundboardSound
    {
        /// <summary>
        /// Id of the soundboard sound to play
        /// </summary>
        [JsonProperty("sound_id")]
        public Snowflake SoundId { get; set; }
        
        /// <summary>
        /// Id of the guild the soundboard sound is from, required to play sounds from different servers
        /// </summary>
        [JsonProperty("source_guild_id")]
        public Snowflake? SourceGuildId { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public SendSoundboardSound() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sound">Sound to send</param>
        public SendSoundboardSound(DiscordSoundboardSound sound)
        {
            SoundId = sound.SoundId;
            SourceGuildId = sound.GuildId;
        }
    }
}