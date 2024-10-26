using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/guild#modify-user-voice-state-json-params">Modify User Voice State</a>
    /// </summary>
    public class GuildUserVoiceStateUpdate : IDiscordValidation
    {
        /// <summary>
        /// The id of the channel the user is currently in
        /// </summary>
        [JsonProperty("channel_id")]
        public Snowflake ChannelId { get; set; }
        
        /// <summary>
        /// Toggles the user's suppress state
        /// </summary>
        [JsonProperty("suppress")]
        public bool Suppress { get; set; }

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidSnowflakeException.ThrowIfInvalid(ChannelId);
        }
    }
}