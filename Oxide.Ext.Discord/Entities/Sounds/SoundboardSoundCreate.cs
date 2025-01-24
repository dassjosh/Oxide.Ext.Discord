using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/soundboard#create-guild-soundboard-sound-json-params">Soundboard Create Request</a> in Discord
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SoundboardSoundCreate : IDiscordValidation
    {
        /// <summary>
        /// Name of the soundboard sound (2-32 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Mp3 or ogg sound data
        /// </summary>
        [JsonProperty("sound")]
        public DiscordSoundData Sound { get; set; }
        
        /// <summary>
        /// Volume of the soundboard sound, from 0 to 1, defaults to 1
        /// </summary>
        [JsonProperty("volume")]
        public double? Volume { get; set; }
        
        /// <summary>
        /// ID of the custom emoji for the soundboard sound
        /// </summary>
        [JsonProperty("emoji_id")]
        public Snowflake? EmojiId { get; set; }
        
        /// <summary>
        /// Unicode character of a standard emoji for the soundboard sound
        /// </summary>
        [JsonProperty("emoji_name")]
        public string EmojiName { get; set; }

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidSoundboardException.ThrowIfInvalidName(Name);
            InvalidSoundboardException.ThrowIfInvalidVolume(Volume);
            InvalidSoundboardException.ThrowIfInvalidSoundData(Sound);
            InvalidSoundboardException.ThrowIfInvalidSoundSize(Sound);
        }
    }
}