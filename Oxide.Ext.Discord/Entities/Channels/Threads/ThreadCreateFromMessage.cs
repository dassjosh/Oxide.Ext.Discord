using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#start-thread-from-message-json-params">Thread Create From Message</a> Structure
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ThreadCreateFromMessage : IDiscordValidation
    {
        /// <summary>
        /// 1-100 character thread name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } 
        
        /// <summary>
        /// Duration in minutes to automatically archive the thread after recent activity, can be set to: 60, 1440, 4320, 10080
        /// </summary>
        [JsonProperty("auto_archive_duration")]
        public int? AutoArchiveDuration { get; set; }

        /// <summary>
        /// Amount of seconds a user has to wait before sending another message (0-21600)
        /// </summary>
        [JsonProperty("rate_limit_per_user")]
        public int? RateLimitPerUser { get; set; }
        
        ///<inheritdoc/>
        public void Validate()
        {
            InvalidChannelException.ThrowIfInvalidName(Name, false);
            InvalidChannelException.ThrowIfInvalidRateLimitPerUser(RateLimitPerUser);
            InvalidThreadException.ThrowIfInvalidAutoArchiveDuration(AutoArchiveDuration);
        }
    }
}