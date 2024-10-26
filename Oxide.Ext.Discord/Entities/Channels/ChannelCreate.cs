using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/guild#create-guild-channel-json-params">Guild Channel Create Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ChannelCreate : IDiscordValidation
    {
        /// <summary>
        /// The name of the channel (1-100 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// the type of channel <see cref="ChannelType"/>
        /// </summary>
        [JsonProperty("type")]
        public ChannelType Type { get; set; }
        
        /// <summary>
        /// The channel topic
        /// (0-4096 characters for GUILD_FORUM &amp; GUILD_MEDIA Channels)
        /// (0-1024 characters for all others)
        /// </summary>
        [JsonProperty("topic")]        
        public string Topic { get; set; }
                
        /// <summary>
        /// The bitrate (in bits) of the voice channel
        /// 8000 to 96000 (128000 for VIP servers)
        /// </summary>
        [JsonProperty("bitrate")]
        public int? Bitrate { get; set; }
                
        /// <summary>
        /// The user limit of the voice channel
        /// 0 refers to no limit, 1 to 99 refers to a user limit
        /// </summary>
        [JsonProperty("user_limit")]
        public int? UserLimit { get; set; }
                
        /// <summary>
        /// Amount of seconds a user has to wait before sending another message (0-21600);
        /// bots, as well as users with the permission manage_messages or manage_channel, are unaffected
        /// </summary>
        [JsonProperty("rate_limit_per_user")]
        public int? RateLimitPerUser { get; set; }
                
        /// <summary>
        /// Sorting position of the channel
        /// </summary>
        [JsonProperty("position")]
        public int? Position { get; set; }
                
        /// <summary>
        /// Explicit permission overwrites for members and roles <see cref="Overwrite"/>
        /// </summary>
        [JsonProperty("permission_overwrites")]
        public List<Overwrite> PermissionOverwrites { get; set; }
                
        /// <summary>
        /// ID of the parent category for a channel (each parent category can contain up to 50 channels)
        /// </summary>
        [JsonProperty("parent_id")]
        public Snowflake? ParentId { get; set; }
        
        /// <summary>
        /// Whether the channel is nsfw
        /// </summary>
        [JsonProperty("nsfw")]
        public bool? Nsfw { get; set; }
        
        /// <summary>
        /// The default duration that the clients use (not the API) for newly created threads in the channel, in minutes, to automatically archive the thread after recent activity
        /// </summary>
        [JsonProperty("default_auto_archive_duration")]
        public int DefaultAutoArchiveDuration { get; set; }
        
        /// <summary>
        /// Emoji to show in the add reaction button on a thread in a `GUILD_FORUM` or `GUILD_MEDIA` channel
        /// </summary>
        [JsonProperty("default_reaction_emoji")]
        public DefaultReaction DefaultReactionEmoji { get; set; }
        
        /// <summary>
        /// Set of tags that can be used in a `GUILD_FORUM` or GUILD_MEDIA channel
        /// </summary>
        [JsonProperty("available_tags")]
        public List<ForumTag> AvailableTags { get; set; }
        
        /// <summary>
        /// The default <see cref="SortOrderType"/> used to order posts in `GUILD_FORUM` or `GUILD_MEDIA` channels
        /// </summary>
        [JsonProperty("default_sort_order")]
        public SortOrderType? DefaultSortOrder { get; set; }

        /// <summary>
        /// The default <see cref="ForumLayoutTypes"/> used to display posts in GUILD_FORUM channels.
        /// Defaults to <see cref="ForumLayoutTypes.NotSet"/>, which indicates a layout view has not been set by a channel admin
        /// </summary>
        [JsonProperty("default_forum_layout")]
        public ForumLayoutTypes? DefaultForumLayout { get; set; }
        
        /// <summary>
        /// The initial rate_limit_per_user to set on newly created threads in a channel. this field is copied to the thread at creation time and does not live update.
        /// </summary>
        [JsonProperty("default_thread_rate_limit_per_user")]
        public int? DefaultThreadRateLimitPerUser { get; set; }
        
        /// <inheritdoc/>
        public void Validate()
        {
            InvalidChannelException.ThrowIfInvalidName(Name, false);
            InvalidChannelException.ThrowIfInvalidTopic(Topic, Type, true);
            InvalidChannelException.ThrowIfInvalidUserLimit(UserLimit);
            InvalidChannelException.ThrowIfInvalidRateLimitPerUser(RateLimitPerUser);
            InvalidChannelException.ThrowIfInvalidBitRate(Bitrate);
            InvalidChannelException.ThrowIfInvalidParentId(ParentId);
        }
    }
}