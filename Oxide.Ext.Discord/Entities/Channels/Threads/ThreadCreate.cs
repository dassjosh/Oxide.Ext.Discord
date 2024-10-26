using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#start-thread-without-message-json-params">Thread Create Structure</a> within Discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ThreadCreate : IDiscordValidation
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
        /// The type of thread to create
        /// Can only be GuildNewsThread, GuildPublicThread, or GuildPrivateThread
        /// </summary>
        [JsonProperty("type")]
        public ChannelType Type { get; set; }
        
        /// <summary>
        /// Whether non-moderators can add other non-moderators to a thread; only available when creating a private thread
        /// </summary>
        [JsonProperty("invitable")]
        public bool? Invitable { get; set; }
        
        /// <summary>
        /// Amount of seconds a user has to wait before sending another message (0-21600)
        /// </summary>
        [JsonProperty("rate_limit_per_user")]
        public int? RateLimitPerUser { get; set; }

        /// <summary>
        /// Validates the Thread Forum Create
        /// </summary>
        public void Validate()
        {
            InvalidChannelException.ThrowIfInvalidName(Name, false);
            InvalidChannelException.ThrowIfInvalidRateLimitPerUser(RateLimitPerUser);
            InvalidThreadException.ThrowIfInvalidAutoArchiveDuration(AutoArchiveDuration);
            InvalidThreadException.ThrowIfInvalidChannelType(Type);
        }
    }
}