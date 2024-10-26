using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/guild#modify-current-user-voice-state-json-params">Modify Current User Voice State</a>
    /// </summary>
    public class GuildCurrentUserVoiceStateUpdate : IDiscordValidation
    {
        /// <summary>
        /// The id of the channel the user is currently in
        /// </summary>
        [JsonProperty("channel_id")]
        public Snowflake? ChannelId { get; set; }
        
        /// <summary>
        /// Toggles the user's suppress state
        /// </summary>
        [JsonProperty("suppress")]
        public bool Suppress { get; set; }
        
        /// <summary>
        /// Sets the user's request to speak
        /// </summary>
        [JsonProperty("request_to_speak_timestamp")]
        public DateTime RequestToSpeakTimestamp { get; set; }

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidSnowflakeException.ThrowIfInvalid(ChannelId);
        }
    }
}