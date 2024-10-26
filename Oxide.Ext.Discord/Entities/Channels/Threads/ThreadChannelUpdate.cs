using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#modify-channel-json-params-thread">Thread Channel Update Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ThreadChannelUpdate : IDiscordValidation
    {
        /// <summary>
        /// The name of the channel (1-100 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether the channel is archived
        /// </summary>
        [JsonProperty("archived")]
        public bool Archived { get; set; }
        
        /// <summary>
        /// Duration in minutes to automatically archive the thread after recent activity
        /// Can be set to: 60, 1440, 4320, 10080
        /// </summary>
        [JsonProperty("auto_archive_duration")]
        public int AutoArchiveDuration { get; set; }
        
        /// <summary>
        /// Whether the thread is locked
        /// When a thread is locked, only users with MANAGE_THREADS can unarchive it
        /// </summary>
        [JsonProperty("locked")]
        public bool Locked { get; set; }
        
        /// <summary>
        /// Whether non-moderators can add other non-moderators to a thread
        /// Only available on private threads
        /// </summary>
        [JsonProperty("invitable")]
        public bool Invitable { get; set; }
        
        /// <summary>
        /// Amount of seconds a user has to wait before sending another message (0-21600)
        /// Bots and users with the permission manage_messages, manage_thread, or manage_channel, are unaffected
        /// </summary>
        [JsonProperty("rate_limit_per_user")]
        public int? RateLimitPerUser { get; set; }
        
        /// <summary>
        /// Channel flags combined as a bitfield; PINNED can only be set for threads in forum channels
        /// </summary>
        [JsonProperty("flags")]
        public ChannelFlags? Flags { get; set; }
        
        /// <summary>
        /// The IDs of the set of tags that have been applied to a thread in a GUILD_FORUM or GUILD_MEDIA channel
        /// </summary>
        [JsonProperty("applied_tags")]
        public List<Snowflake> AppliedTags { get; set; }

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidChannelException.ThrowIfInvalidName(Name, true);
            InvalidChannelException.ThrowIfInvalidRateLimitPerUser(RateLimitPerUser);
            InvalidThreadException.ThrowIfInvalidAutoArchiveDuration(AutoArchiveDuration);
        }
    }
}