using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Json;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;
using UserData = Oxide.Ext.Discord.Data.UserData;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a guild or DM <a href="https://discord.com/developers/docs/resources/channel#channel-object">Channel Structure</a> within Discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordChannel : ISnowflakeEntity, IDebugLoggable
    {
        /// <summary>
        /// The ID of this channel
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// the type of channel <see cref="ChannelType"/>
        /// </summary>
        [JsonProperty("type")]
        public ChannelType Type { get; set; }
        
        /// <summary>
        /// the ID of the guild
        /// Warning: May be missing for some channel objects received over gateway guild dispatches
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake? GuildId { get; set; }
        
        /// <summary>
        /// Sorting position of the channel
        /// </summary>
        [JsonProperty("position")]
        public int? Position { get; set; }
        
        /// <summary>
        /// Explicit permission overwrites for members and roles <see cref="Overwrite"/>
        /// </summary>
        [JsonConverter(typeof(HashListConverter<Overwrite>))]
        [JsonProperty("permission_overwrites")]
        public Hash<Snowflake, Overwrite> PermissionOverwrites { get; set; }
        
        /// <summary>
        /// The name of the channel (1-100 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The channel topic (0-1024 characters)
        /// </summary>
        [JsonProperty("topic")]        
        public string Topic { get; set; }
        
        /// <summary>
        /// Whether the channel is nsfw
        /// </summary>
        [JsonProperty("nsfw")]
        public bool? Nsfw { get; set; }
        
        /// <summary>
        /// The id of the last message sent in this channel (or thread for GUILD_FORUM or GUILD_MEDIA channels)
        /// May not point to an existing or valid message or thread
        /// </summary>
        [JsonProperty("last_message_id")]        
        public Snowflake? LastMessageId { get; set; }
        
        /// <summary>
        /// The bitrate (in bits) of the voice channel
        /// </summary>
        [JsonProperty("bitrate")]
        public int? Bitrate { get; set; }
        
        /// <summary>
        /// The user limit of the voice channel
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
        /// The recipients of the DM
        /// </summary>
        [JsonConverter(typeof(HashListConverter<DiscordUser>))]
        [JsonProperty("recipients")]
        public Hash<Snowflake, DiscordUser> Recipients { get; set; }
        
        /// <summary>
        /// icon hash of the group DM  
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        /// <summary>
        /// ID of the DM creator
        /// </summary>
        [JsonProperty("owner_id")]
        public Snowflake? OwnerId { get; set; }
        
        /// <summary>
        /// Application id of the group DM creator if it is bot-created
        /// </summary>
        [JsonProperty("application_id")]
        public Snowflake? ApplicationId { get; set; }
        
        /// <summary>
        /// For group DM channels: whether the channel is managed by an application via the `gdm.join` OAuth2 scope
        /// </summary>
        [JsonProperty("managed")]
        public bool? Managed { get; set; }
        
        /// <summary>
        /// ID of the parent category for a channel (each parent category can contain up to 50 channels)
        /// </summary>
        [JsonProperty("parent_id")]
        public Snowflake? ParentId { get; set; }
        
        /// <summary>
        /// When the last pinned message was pinned.
        /// This may be null in events such as GUILD_CREATE when a message is not pinned.
        /// </summary>
        [JsonProperty("last_pin_timestamp")]
        public DateTime? LastPinTimestamp { get; set; }
        
        /// <summary>
        /// Voice region id for the voice channel, automatic when set to null
        /// </summary>
        [JsonProperty("rtc_region")]
        public string RtcRegion { get; set; }
        
        /// <summary>
        /// The camera video quality mode of the voice channel
        /// 1 when not present
        /// </summary>
        [JsonProperty("video_quality_mode")]
        public VideoQualityMode? VideoQualityMode { get; set; }
        
        /// <summary>
        /// umber of messages (not including the initial messages or deleted messages) in a thread (if the thread was created before July 1, 2022, it stops counting at 50)
        /// </summary>
        [JsonProperty("message_count")]
        public int? MessageCount { get; set; }
        
        /// <summary>
        /// An approximate count of users in a thread, stops counting at 50
        /// </summary>
        [JsonProperty("member_count")]
        public int? MemberCount { get; set; }
        
        /// <summary>
        /// Thread-specific fields not needed by other channels
        /// </summary>
        [JsonProperty("thread_metadata")]
        public ThreadMetadata ThreadMetadata { get; set; }
        
        /// <summary>
        /// Thread member object for the current user, if they have joined the thread, only included on certain API endpoints
        /// </summary>
        [JsonProperty("member")]
        public ThreadMember Member { get; set; }
        
        /// <summary>
        /// Default duration for newly created threads, in minutes, to automatically archive the thread after recent activity, can be set to: 60, 1440, 4320, 10080
        /// </summary>
        [JsonProperty("default_auto_archive_duration")]
        public int? DefaultAutoArchiveDuration { get; set; }
        
        /// <summary>
        /// Default duration for newly created threads, in minutes, to automatically archive the thread after recent activity, can be set to: 60, 1440, 4320, 10080
        /// </summary>
        [JsonProperty("permissions")]
        public string Permissions { get; set; }
        
        /// <summary>
        /// Flags for this channel
        /// </summary>
        [JsonProperty("flags")]
        public ChannelFlags? Flags { get; set; }
        
        /// <summary>
        /// Number of messages ever sent in a thread, it's similar to message_count on message creation, but will not decrement the number when a message is deleted
        /// </summary>
        [JsonProperty("total_message_sent")]
        public int? TotalMessageSent { get; set; }

        private Hash<Snowflake, ThreadMember> _threadMembers;
        
        /// <summary>
        /// The set of tags that can be used in a GUILD_FORUM or GUILD_MEDIA channel
        /// Limited to 20
        /// </summary>
        [JsonProperty("available_tags")]
        public List<ForumTag> AvailableTags { get; set; }
        
        /// <summary>
        /// The IDs of the set of tags that have been applied to a thread in a GUILD_FORUM or GUILD_MEDIA channel
        /// </summary>
        [JsonProperty("applied_tags")]
        public List<Snowflake> AppliedTags { get; set; }
        
        /// <summary>
        /// The emoji to show in the add reaction button on a thread in a GUILD_FORUM or GUILD_MEDIA channel
        /// </summary>
        [JsonProperty("default_reaction_emoji")]
        public DefaultReaction DefaultReactionEmoji { get; set; }
        
        /// <summary>
        /// The initial rate_limit_per_user to set on newly created threads in a channel. this field is copied to the thread at creation time and does not live update.
        /// </summary>
        [JsonProperty("default_thread_rate_limit_per_user")]
        public int? DefaultThreadRateLimitPerUser { get; set; }
        
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
        /// List of thread members if channel is thread; Null Otherwise.
        /// </summary>
        public Hash<Snowflake, ThreadMember> ThreadMembers
        {
            get
            {
                if (_threadMembers != null)
                {
                    return _threadMembers;
                }

                InvalidChannelException.ThrowIfNotThread(this, "Cannot get ThreadMembers for a non thread channel");

                return _threadMembers = new Hash<Snowflake, ThreadMember>();
            }
        }

        internal UserData UserData { get; set; }

        /// <summary>
        /// Returns a string to mention this channel in a message
        /// </summary>
        public string Mention => DiscordFormatting.MentionChannel(Id);
        
        /// <summary>
        /// Returns the Icon URL for the given channel
        /// </summary>
        public string IconUrl => !string.IsNullOrEmpty(Icon) ? DiscordCdn.GetChannelIcon(Id, Icon) : null;

        /// <summary>
        /// Returns if the channel is a guild channel
        /// </summary>
        /// <returns></returns>
        public bool IsGuildChannel()
        {
            return Type == ChannelType.GuildCategory
                   || Type == ChannelType.GuildDirectory
                   || Type == ChannelType.GuildForum
                   || Type == ChannelType.GuildNews
                   || Type == ChannelType.GuildText
                   || Type == ChannelType.GuildVoice
                   || Type == ChannelType.GuildNewsThread
                   || Type == ChannelType.GuildPrivateThread
                   || Type == ChannelType.GuildPublicThread
                   || Type == ChannelType.GuildStageVoice;
        }

        /// <summary>
        /// Returns if a channel is a DM channel
        /// </summary>
        /// <returns></returns>
        public bool IsDmChannel()
        {
            return Type == ChannelType.Dm || Type == ChannelType.GroupDm;
        }

        /// <summary>
        /// Returns if a channel is a thread channel
        /// </summary>
        /// <returns></returns>
        public bool IsThreadChannel()
        {
            return Type == ChannelType.GuildNewsThread || Type == ChannelType.GuildPrivateThread || Type == ChannelType.GuildPublicThread;
        }

        /// <summary>
        /// Create a new channel object for the guild.
        /// Requires the MANAGE_CHANNELS permission.
        /// See <a href="https://discord.com/developers/docs/resources/guild#create-guild-channel">Create Guild Channel</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="guildId">Guild to create the channel in</param>
        /// <param name="channel">Channel to create</param>
        public static IPromise<DiscordChannel> Create(DiscordClient client, Snowflake guildId, ChannelCreate channel)
        {
            InvalidSnowflakeException.ThrowIfInvalid(guildId);
            return client.Bot.Rest.Post<DiscordChannel>(client,$"guilds/{guildId}/channels", channel);
        }

        /// <summary>
        /// Get a channel by ID
        /// See <a href="https://discord.com/developers/docs/resources/channel#get-channel">Get Channel</a>
        /// If the channel is a thread, a thread member object is included in the returned result.
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="channelId">ID of the channel to get</param>
        public static IPromise<DiscordChannel> Get(DiscordClient client, Snowflake channelId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(channelId);
            return client.Bot.Rest.Get<DiscordChannel>(client,$"channels/{channelId}");
        }
        
        /// <summary>
        /// Update a group dm channel's settings.
        /// See <a href="https://discord.com/developers/docs/resources/channel#modify-channel">Modify Channel</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="update">Update to be made to the channel. All fields are optional</param>
        public IPromise<DiscordChannel> EditGroupDmChannel(DiscordClient client, GroupDmChannelUpdate update)
        {
            if (update == null) throw new ArgumentNullException(nameof(update));
            return client.Bot.Rest.Patch<DiscordChannel>(client,$"channels/{Id}", update);
        }

        /// <summary>
        /// Update a guild channel's settings.
        /// Requires the MANAGE_CHANNELS permission for the guild.
        /// See <a href="https://discord.com/developers/docs/resources/channel#modify-channel">Modify Channel</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="update">Update to be made to the channel. All fields are optional</param>
        public IPromise<DiscordChannel> EditGuildChannel(DiscordClient client, GuildChannelUpdate update)
        {
            if (update == null) throw new ArgumentNullException(nameof(update));
            return client.Bot.Rest.Patch<DiscordChannel>(client,$"channels/{Id}", update);
        }
        
        /// <summary>
        /// Update a thread channel's settings.
        /// Requires the MANAGE_THREADS permission for the guild.
        /// See <a href="https://discord.com/developers/docs/resources/channel#modify-channel">Modify Channel</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="update">Update to be made to the channel. All fields are optional</param>
        public IPromise<DiscordChannel> EditThreadChannel(DiscordClient client, ThreadChannelUpdate update)
        {
            if (update == null) throw new ArgumentNullException(nameof(update));
            return client.Bot.Rest.Patch<DiscordChannel>(client,$"channels/{Id}", update);
        }

        /// <summary>
        /// Delete a channel, or close a private message.
        /// Requires the MANAGE_CHANNELS or MANAGE_THREADS permission for the guild depending on the channel type.
        /// See <a href="https://discord.com/developers/docs/resources/channel#deleteclose-channel">Delete/Close Channel</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise<DiscordChannel> Delete(DiscordClient client)
        {
            return client.Bot.Rest.Delete<DiscordChannel>(client,$"channels/{Id}");
        }

        /// <summary>
        /// Returns the messages for a channel.
        /// If operating on a guild channel, this endpoint requires the VIEW_CHANNEL permission to be present on the current user.
        /// If the current user is missing the 'READ_MESSAGE_HISTORY' permission in the channel then this will return no messages (since they cannot read the message history).
        /// See <a href="https://discord.com/developers/docs/resources/channel#get-channel-messages">Get Channel Messages</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="request">Optional request filters</param>
        public IPromise<List<DiscordMessage>> GetMessages(DiscordClient client, ChannelMessagesRequest request = null)
        {
            return client.Bot.Rest.Get<List<DiscordMessage>>(client,$"channels/{Id}/messages{request?.ToQueryString()}");
        }
        
        /// <summary>
        /// Returns a specific message in the channel.
        /// If operating on a guild channel, this endpoint requires the 'READ_MESSAGE_HISTORY' permission to be present on the current user.
        /// See <a href="https://discord.com/developers/docs/resources/channel#get-channel-message">Get Channel Messages</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID of the message</param>
        public IPromise<DiscordMessage> GetMessage(DiscordClient client, Snowflake messageId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(messageId);
            return client.Bot.Rest.Get<DiscordMessage>(client,$"channels/{Id}/messages/{messageId}");
        }

        /// <summary>
        /// Post a message to a guild text or DM channel.
        /// If operating on a guild channel, this endpoint requires the SEND_MESSAGES permission to be present on the current user.
        /// If the tts field is set to true, the SEND_TTS_MESSAGES permission is required for the message to be spoken.
        /// See <a href="https://discord.com/developers/docs/resources/channel#create-message">Create Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="message">Message to be created</param>
        public IPromise<DiscordMessage> CreateMessage(DiscordClient client, MessageCreate message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            DateTime? blockedUntil = UserData?.GetBlockedUntil();
            if (!blockedUntil.HasValue)
            {
                IPromise<DiscordMessage> response = client.Bot.Rest.Post<DiscordMessage>(client, $"channels/{Id}/messages", message);
                if (UserData != null)
                {
                    response.Catch<ResponseError>(ex => UserData.ProcessError(client, ex));
                }
                return response;
            }
            
            DiscordUser user = UserData.GetUser();
            client.Logger.Debug("Blocking CreateMessage. User {0} ({1}) is DM blocked until {2}.", user.FullUserName, user.Id, blockedUntil.Value);
            return Promise<DiscordMessage>.Rejected(new BlockedUserException(user, blockedUntil.Value));
        }

        /// <summary>
        /// Post a message to a guild text or DM channel.
        /// If operating on a guild channel, this endpoint requires the SEND_MESSAGES permission to be present on the current user.
        /// If the tts field is set to true, the SEND_TTS_MESSAGES permission is required for the message to be spoken.
        /// See <a href="https://discord.com/developers/docs/resources/channel#create-message">Create Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="message">Content of the message</param>
        public IPromise<DiscordMessage> CreateMessage(DiscordClient client, string message)
        {
            MessageCreate createMessage = new()
            {
                Content = message
            };

            return CreateMessage(client, createMessage);
        }

        /// <summary>
        /// Post a message to a guild text or DM channel.
        /// If operating on a guild channel, this endpoint requires the SEND_MESSAGES permission to be present on the current user.
        /// If the tts field is set to true, the SEND_TTS_MESSAGES permission is required for the message to be spoken.
        /// See <a href="https://discord.com/developers/docs/resources/channel#create-message">Create Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="embed">Embed to be send in the message</param>
        public IPromise<DiscordMessage> CreateMessage(DiscordClient client, DiscordEmbed embed)
        {
            MessageCreate createMessage = new()
            {
                Embeds = new List<DiscordEmbed> {embed}
            };

            return CreateMessage(client, createMessage);
        }
        
        /// <summary>
        /// Post a message to a guild text or DM channel.
        /// If operating on a guild channel, this endpoint requires the SEND_MESSAGES permission to be present on the current user.
        /// If the tts field is set to true, the SEND_TTS_MESSAGES permission is required for the message to be spoken.
        /// See <a href="https://discord.com/developers/docs/resources/channel#create-message">Create Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="embeds">Embeds to be send in the message</param>
        public IPromise<DiscordMessage> CreateMessage(DiscordClient client, List<DiscordEmbed> embeds)
        {
            MessageCreate createMessage = new()
            {
                Embeds = embeds
            };

            return CreateMessage(client, createMessage);
        }

        /// <summary>
        /// Creates a message in a text channel using a global message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="templateName">Template name</param>
        /// <param name="message">message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        public IPromise<DiscordMessage> CreateGlobalTemplateMessage(DiscordClient client, TemplateKey templateName, MessageCreate message = null, PlaceholderData placeholders = null)
        {
            MessageCreate template = DiscordExtension.DiscordMessageTemplates.GetGlobalTemplate(client.Plugin, templateName).ToMessage(placeholders, message);
            return CreateMessage(client, template);
        }

        /// <summary>
        /// Creates a message in a text channel using a localized message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="templateName">Template name</param>
        /// <param name="language">Oxide language for the template</param>
        /// <param name="message">message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        public IPromise<DiscordMessage> CreateTemplateMessage(DiscordClient client, TemplateKey templateName, string language = DiscordLocales.DefaultServerLanguage, MessageCreate message = null, PlaceholderData placeholders = null)
        {
            MessageCreate template = DiscordExtension.DiscordMessageTemplates.GetLocalizedTemplate(client.Plugin, templateName, language).ToMessage(placeholders, message);
            return CreateMessage(client, template);
        }

        /// <summary>
        /// Delete multiple messages in a single request.
        /// This endpoint can only be used on guild channels and requires the MANAGE_MESSAGES permission.
        /// See <a href="https://discord.com/developers/docs/resources/channel#bulk-delete-messages">Bulk Delete Messages</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageIds">Collect of message ids to delete (Between 2 - 100)</param>
        public IPromise BulkDeleteMessages(DiscordClient client, ICollection<Snowflake> messageIds)
        {
            if (messageIds.Count < 2) throw new ArgumentOutOfRangeException(nameof(messageIds), "Cannot delete less than 2 messages");
            if (messageIds.Count > 100) throw new ArgumentOutOfRangeException(nameof(messageIds), "Cannot delete more than 100 messages");

            Dictionary<string, ICollection<Snowflake>> data = new()
            {
                ["messages"] = messageIds 
            };

            return client.Bot.Rest.Post(client,$"channels/{Id}/messages/bulk-delete", data);
        }

        /// <summary>
        /// Edit the channel permission overwrites for a user or role in a channel.
        /// Only usable for guild channels.
        /// Requires the MANAGE_ROLES permission.
        /// See <a href="https://discord.com/developers/docs/resources/channel#edit-channel-permissions">Edit Channel Permissions</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="overwrite">Overwrite to edit with changes</param>
        public IPromise EditPermissions(DiscordClient client, Overwrite overwrite)
        {
            if (overwrite == null) throw new ArgumentNullException(nameof(overwrite));
            InvalidSnowflakeException.ThrowIfInvalid(overwrite.Id);
            return client.Bot.Rest.Put(client,$"channels/{Id}/permissions/{overwrite.Id}", overwrite);
        }

        /// <summary>
        /// Delete a channel permission overwrite for a user or role in a channel.
        /// Only usable for guild channels.
        /// Requires the MANAGE_ROLES permission.
        /// See <a href="https://discord.com/developers/docs/resources/channel#delete-channel-permission">Delete Channel Permission</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="overwrite">Overwrite to delete</param>
        public IPromise DeletePermission(DiscordClient client, Overwrite overwrite) => DeletePermission(client, overwrite.Id);

        /// <summary>
        /// Delete a channel permission overwrite for a user or role in a channel.
        /// Only usable for guild channels.
        /// Requires the MANAGE_ROLES permission.
        /// See <a href="https://discord.com/developers/docs/resources/channel#delete-channel-permission">Delete Channel Permission</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="overwriteId">Overwrite ID to delete</param>
        public IPromise DeletePermission(DiscordClient client, Snowflake overwriteId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(overwriteId);
            return client.Bot.Rest.Delete(client,$"channels/{Id}/permissions/{overwriteId}");
        }
        
        /// <summary>
        /// Returns a list of invite objects (with invite metadata) for the channel.
        /// Only usable for guild channels.
        /// Requires the MANAGE_CHANNELS permission.
        /// See <a href="https://discord.com/developers/docs/resources/channel#get-channel-invites">Get Channel Invites</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <exception cref="Exception">Thrown when the channel type is Dm or GroupDm</exception>
        public IPromise<List<DiscordInvite>> GetInvites(DiscordClient client)
        {
            InvalidChannelException.ThrowIfNotGuildChannel(this, "You can only get channel invites for guild channels");
            return client.Bot.Rest.Get<List<DiscordInvite>>(client,$"channels/{Id}/invites");
        }

        /// <summary>
        /// Create a new invite object for the channel.
        /// Only usable for guild channels.
        /// Requires the CREATE_INSTANT_INVITE permission.
        /// See <a href="https://discord.com/developers/docs/resources/channel#create-channel-invite">Create Channel Invite</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="invite">Invite to create</param>
        public IPromise<DiscordInvite> CreateInvite(DiscordClient client, ChannelInvite invite)
        {
            if (invite == null) throw new ArgumentNullException(nameof(invite));
            return client.Bot.Rest.Post<DiscordInvite>(client,$"channels/{Id}/invites", invite);
        }

        /// <summary>
        /// Follow a News Channel to send messages to a target channel.
        /// Requires the MANAGE_WEBHOOKS permission in the target channel.
        /// See <a href="https://discord.com/developers/docs/resources/channel#follow-announcement-channel">Follow Announcement Channel</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="webhookChannelId">ID of target channel</param>
        public IPromise<FollowedChannel> FollowNewsChannel(DiscordClient client, Snowflake webhookChannelId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(webhookChannelId);
            return client.Bot.Rest.Post<FollowedChannel>(client,$"channels/{Id}/followers?webhook_channel_id={webhookChannelId}", null);
        }

        /// <summary>
        /// Post a typing indicator for the specified channel.
        /// Generally bots should not implement this route. However, if a bot is responding to a command and expects the computation to take a few seconds, this endpoint may be called to let the user know that the bot is processing their message.
        /// See <a href="https://discord.com/developers/docs/resources/channel#trigger-typing-indicator">Trigger Typing Indicator</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise TriggerTypingIndicator(DiscordClient client)
        {
            return client.Bot.Rest.Post(client,$"channels/{Id}/typing", null);
        }

        /// <summary>
        /// Returns all pinned messages in the channel
        /// See <a href="https://discord.com/developers/docs/resources/channel#get-pinned-messages">Get Pinned Messages</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise<List<DiscordMessage>> GetPinnedMessages(DiscordClient client)
        {
            return client.Bot.Rest.Get<List<DiscordMessage>>(client,$"channels/{Id}/pins");
        }

        /// <summary>
        /// Adds a recipient to a Group DM using their access token
        /// See <a href="https://discord.com/developers/docs/resources/channel#group-dm-add-recipient">Group DM Add Recipient</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="user">User to add</param>
        /// <param name="accessToken">Users access token</param>
        public IPromise GroupDmAddRecipient(DiscordClient client, DiscordUser user, string accessToken) => GroupDmAddRecipient(client, user.Id, accessToken, user.Username);
        
        /// <summary>
        /// Adds a recipient to a Group DM using their access token
        /// See <a href="https://discord.com/developers/docs/resources/channel#group-dm-add-recipient">Group DM Add Recipient</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="userId">User to add</param>
        /// <param name="accessToken">Users access token</param>
        /// <param name="nick">User nickname</param>
        public IPromise GroupDmAddRecipient(DiscordClient client, Snowflake userId, string accessToken, string nick)
        {
            InvalidSnowflakeException.ThrowIfInvalid(userId);
            Dictionary<string, string> data = new()
            {
                ["access_token"] = accessToken,
                ["nick"] = nick
            };

            return client.Bot.Rest.Put(client,$"channels/{Id}/recipients/{userId}", data);
        }
        
        /// <summary>
        /// Removes a recipient from a Group DM
        /// See <a href="https://discord.com/developers/docs/resources/channel#group-dm-remove-recipient">Group DM Remove Recipient</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="userId">User ID to remove</param>
        public IPromise GroupDmRemoveRecipient(DiscordClient client, Snowflake userId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(userId);
            return client.Bot.Rest.Delete(client,$"channels/{Id}/recipients/{userId}");
        }

        /// <summary>
        /// Creates a new public thread from a message
        /// See <a href="https://discord.com/developers/docs/resources/channel#start-thread-from-message">Start Thread with Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">ID of the message to start the thread from</param>
        /// <param name="create">Data to use when creating the thread</param>
        public IPromise<DiscordChannel> StartThreadFromMessage(DiscordClient client, Snowflake messageId, ThreadCreateFromMessage create)
        {
            InvalidSnowflakeException.ThrowIfInvalid(messageId);
            return client.Bot.Rest.Post<DiscordChannel>(client,$"channels/{Id}/messages/{messageId}/threads", create);
        }
        
        /// <summary>
        /// Creates a new thread that is not connected to an existing message. The created thread is always a GUILD_PRIVATE_THREAD
        /// See <a href="https://discord.com/developers/docs/resources/channel#start-thread-without-message">Start Thread without Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="create">Data to use when creating the thread</param>
        public IPromise<DiscordChannel> StartThreadWithoutMessage(DiscordClient client, ThreadCreate create)
        {
            if (create == null) throw new ArgumentNullException(nameof(create));
            return client.Bot.Rest.Post<DiscordChannel>(client,$"channels/{Id}/threads", create);
        }
        
        /// <summary>
        /// Creates a new thread in a forum channel, and sends a message within the created thread. Returns a channel, with a nested message object
        /// See <a href="https://discord.com/developers/docs/resources/channel#start-thread-in-forum-channel">Start Thread in Forum Channel</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="create">Data to use when creating the thread</param>
        public IPromise<DiscordChannel> StartThreadInForumChannel(DiscordClient client, ThreadForumCreate create)
        {
            if (create == null) throw new ArgumentNullException(nameof(create));
            return client.Bot.Rest.Post<DiscordChannel>(client,$"channels/{Id}/threads", create);
        }
        
        /// <summary>
        /// Adds the bot to the thread. Also requires the thread is not archived.
        /// See <a href="https://discord.com/developers/docs/resources/channel#join-thread">Join Thread</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise JoinThread(DiscordClient client)
        {
            return client.Bot.Rest.Put(client,$"channels/{Id}/thread-members/@me", null);
        }

        /// <summary>
        /// Adds another user to a thread.
        /// Requires the ability to send messages in the thread. Also requires the thread is not archived.
        /// See <a href="https://discord.com/developers/docs/resources/channel#add-thread-member">Add Thread Member</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="userId">ID of the user to thread</param>
        public IPromise AddThreadMember(DiscordClient client, Snowflake userId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(userId);
            return client.Bot.Rest.Put(client, $"channels/{Id}/thread-members/{userId}", null);
        }
        
        /// <summary>
        /// Removes the bot from the thread. Also requires the thread is not archived.
        /// See <a href="https://discord.com/developers/docs/resources/channel#leave-thread">Leave Thread</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise LeaveThread(DiscordClient client)
        {
            return client.Bot.Rest.Delete(client,$"channels/{Id}/thread-members/@me");
        }
        
        /// <summary>
        /// Removes another user from a thread.
        /// Requires the MANAGE_THREADS permission or that you are the creator of the thread. Also requires the thread is not archived.
        /// See <a href="https://discord.com/developers/docs/resources/channel#remove-thread-member">Remove Thread Member</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="userId">ID of the user to thread</param>
        public IPromise RemoveThreadMember(DiscordClient client, Snowflake userId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(userId);
            return client.Bot.Rest.Delete(client, $"channels/{Id}/thread-members/{userId}");
        }

        /// <summary>
        /// Returns a thread member object for the specified user if they are a member of the thread
        /// returns a 404 response otherwise.
        /// See <a href="https://discord.com/developers/docs/resources/channel#get-thread-member">Remove Thread Member</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="userId">ID of the user to thread</param>
        /// <param name="request">Query String Arguments</param>
        public IPromise<ThreadMember> GetThreadMember(DiscordClient client, Snowflake userId, GetThreadMember request = null)
        {
            InvalidSnowflakeException.ThrowIfInvalid(userId);
            return client.Bot.Rest.Get<ThreadMember>(client,$"channels/{Id}/thread-members/{userId}{request?.ToQueryString()}");
        }

        /// <summary>
        /// Returns array of thread members objects that are members of the thread.
        /// This endpoint is restricted according to whether the GUILD_MEMBERS Privileged Intent is enabled for your application.
        /// See <a href="https://discord.com/developers/docs/resources/channel#list-thread-members">List Thread Members</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="request">Query string for the List Thread Members</param>
        public IPromise<List<ThreadMember>> ListThreadMembers(DiscordClient client, ListThreadMembers request = null)
        {
            return client.Bot.Rest.Get<List<ThreadMember>>(client,$"channels/{Id}/thread-members{request?.ToQueryString()}");
        }

        /// <summary>
        /// Returns archived threads in the channel that are public.
        /// When called on a GUILD_TEXT channel, returns threads of type GUILD_PUBLIC_THREAD. When called on a GUILD_NEWS channel returns threads of type GUILD_NEWS_THREAD. Threads are ordered by archive_timestamp, in descending order.
        /// Requires the READ_MESSAGE_HISTORY permission.
        /// See <a href="https://discord.com/developers/docs/resources/channel#list-public-archived-threads">List Public Archived Threads</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="request">The options to use when looking up the archived threads</param>
        public IPromise<ThreadList> ListPublicArchivedThreads(DiscordClient client, ThreadArchivedLookup request = null)
        {
            return client.Bot.Rest.Get<ThreadList>(client,$"channels/{Id}/threads/archived/public{request?.ToQueryString()}");
        }
        
        /// <summary>
        /// Returns archived threads in the channel that are of type GUILD_PRIVATE_THREAD.
        /// Threads are ordered by archive_timestamp, in descending order.
        /// Requires both the READ_MESSAGE_HISTORY and MANAGE_THREADS permissions.
        /// See <a href="https://discord.com/developers/docs/resources/channel#list-private-archived-threads">List Private Archived Threads</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="request">The options to use when looking up the archived threads</param>
        public IPromise<ThreadList> ListPrivateArchivedThreads(DiscordClient client, ThreadArchivedLookup request = null)
        {
            return client.Bot.Rest.Get<ThreadList>(client,$"channels/{Id}/threads/archived/public{request?.ToQueryString()}");
        }
        
        /// <summary>
        /// Returns archived threads in the channel that are of type GUILD_PRIVATE_THREAD, and the user has joined.
        /// Threads are ordered by their id, in descending order.
        /// Requires the READ_MESSAGE_HISTORY permission.
        /// See <a href="https://discord.com/developers/docs/resources/channel#list-joined-private-archived-threads">List Joined Private Archived Threads</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="lookup">The options to use when looking up the archived threads</param>
        public IPromise<ThreadList> ListJoinedPrivateArchivedThreads(DiscordClient client, ThreadArchivedLookup lookup = null)
        {
            return client.Bot.Rest.Get<ThreadList>(client,$"channels/{Id}/users/@me/threads/archived/private{lookup?.ToQueryString()}");
        }

        /// <summary>
        /// Gets the stage instance associated with the Stage channel, if it exists.
        /// See <a href="https://discord.com/developers/docs/resources/stage-instance#get-stage-instance">Get Stage Instance</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise<StageInstance> GetStageInstance(DiscordClient client)
        {
            return client.Bot.Rest.Get<StageInstance>(client,$"stage-instances/{Id}");
        }

        internal DiscordChannel Update(DiscordChannel channel)
        {
            DiscordChannel previous = (DiscordChannel)MemberwiseClone();

            Type = channel.Type;

            if (channel.Position != null)
                Position = channel.Position;

            if (channel.PermissionOverwrites != null)
                PermissionOverwrites = channel.PermissionOverwrites;

            if (channel.Name != null)
                Name = channel.Name;

            if (channel.Topic != null)
                Topic = channel.Topic;

            if (channel.Nsfw != null)
                Nsfw = channel.Nsfw;
            
            if (channel.Bitrate != null)
                Bitrate = channel.Bitrate;

            if (channel.UserLimit != null)
                UserLimit = channel.UserLimit;

            if (channel.RateLimitPerUser != null)
                RateLimitPerUser = channel.RateLimitPerUser;

            if (channel.Icon != null)
                Icon = channel.Icon;

            if (channel.OwnerId != null)
                OwnerId = channel.OwnerId;

            if (channel.ApplicationId != null)
                ApplicationId = channel.ApplicationId;
            
            if (channel.LastPinTimestamp != null)
                LastPinTimestamp = channel.LastPinTimestamp;
            
            if (channel.VideoQualityMode != null)
                VideoQualityMode = channel.VideoQualityMode;
            
            if (channel.MessageCount != null)
                MessageCount = channel.MessageCount;
            
            if (channel.MemberCount != null)
                MemberCount = channel.MemberCount;
            
            if (channel.ThreadMetadata != null)
                ThreadMetadata = channel.ThreadMetadata;
            
            if (channel.Member != null)
                Member = channel.Member;
            
            if (channel.DefaultAutoArchiveDuration != null)
                DefaultAutoArchiveDuration = channel.DefaultAutoArchiveDuration;
            
            if (channel.Permissions != null)
                Permissions = channel.Permissions;

            ParentId = channel.ParentId;

            if (channel.Flags.HasValue)
                Flags = Flags;

            return previous;
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendField("ID", Id);
            logger.AppendField("Name", Name);
            logger.AppendFieldEnum("Type", Type);
        }
    }
}