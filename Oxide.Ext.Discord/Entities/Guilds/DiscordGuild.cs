using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-object">Guild Structure</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class DiscordGuild : ISnowflakeEntity
{
    #region Discord Fields
    /// <summary>
    /// Guild id
    /// </summary>
    [JsonProperty("id")]
    public Snowflake Id { get; set; }
        
    /// <summary>
    /// Name of the guild (2-100 characters)
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
        
    /// <summary>
    /// Base64 128x128 image for the guild icon
    /// </summary>
    [JsonProperty("icon")]        
    public string Icon { get; set; }
        
    /// <summary>
    /// Icon hash
    /// </summary>
    [JsonProperty("icon_Hash")]
    public string IconHash { get; set; }
        
    /// <summary>
    /// Splash hash
    /// </summary>
    [JsonProperty("splash")]
    public string Splash { get; set; }

    /// <summary>
    /// Discovery splash hash
    /// Only present for guilds with the "DISCOVERABLE" feature
    /// </summary>
    [JsonProperty("discovery_splash")]
    public string DiscoverySplash { get; set; }
  
    /// <summary>
    /// True if the user is the owner of the guild
    /// </summary>
    [JsonProperty("owner")]
    public bool? Owner { get; set; }
        
    /// <summary>
    /// ID of owner
    /// </summary>
    [JsonProperty("owner_id")]
    public Snowflake OwnerId { get; set; }

    /// <summary>
    /// Total permissions for the user in the guild (excludes overrides)
    /// </summary>
    [JsonProperty("permissions")]
    public string Permissions { get; set; }

    /// <summary>
    /// ID of afk channel
    /// </summary>
    [JsonProperty("afk_channel_id")]
    public Snowflake? AfkChannelId { get; set; }
        
    /// <summary>
    /// Afk timeout in seconds
    /// </summary>
    [JsonProperty("afk_timeout")]
    public int? AfkTimeout { get; set; }
  
    /// <summary>
    /// True if the server widget is enabled
    /// </summary>
    [JsonProperty("widget_enabled")]
    public bool? WidgetEnabled { get; set; }
  
    /// <summary>
    /// The channel id that the widget will generate an invite to, or null if set to no invite
    /// </summary>
    [JsonProperty("widget_channel_id")]
    public Snowflake? WidgetChannelId { get; set; }
        
    /// <summary>
    /// Verification level
    /// </summary>
    [JsonProperty("verification_level")]
    public GuildVerificationLevel? VerificationLevel { get; set; }
        
    /// <summary>
    /// Default message notification level
    /// </summary>
    [JsonProperty("default_message_notifications")]
    public DefaultNotificationLevel? DefaultMessageNotifications { get; set; }
        
    /// <summary>
    /// Explicit content filter level
    /// </summary>
    [JsonProperty("explicit_content_filter")]
    public ExplicitContentFilterLevel? ExplicitContentFilter { get; set; }

    /// <summary>
    /// Roles in the guild
    /// </summary>
    [JsonConverter(typeof(HashListConverter<DiscordRole>))]
    [JsonProperty("roles")]
    public Hash<Snowflake, DiscordRole> Roles { get; set; }

    /// <summary>
    /// Custom guild emojis
    /// </summary>
    [JsonConverter(typeof(HashListConverter<DiscordEmoji>))]
    [JsonProperty("emojis")]

    public Hash<Snowflake, DiscordEmoji> Emojis { get; set; }

    /// <summary>
    /// Enabled guild features
    /// See <see cref="GuildFeatures"/>
    /// </summary>
    [JsonProperty("features")]
    public List<GuildFeatures> Features { get; set; }
  
    /// <summary>
    /// Required MFA level for the guild
    /// See <see cref="GuildMfaLevel"/>
    /// </summary>
    [JsonProperty("mfa_level")]
    public GuildMfaLevel? MfaLevel { get; set; }
  
    /// <summary>
    /// Application id of the guild creator if it is bot-created
    /// </summary>
    [JsonProperty("application_id")]
    public Snowflake? ApplicationId { get; set; }
        
    /// <summary>
    /// The id of the channel where guild notices such as welcome messages and boost events are posted
    /// </summary>
    [JsonProperty("system_channel_id")]
    public Snowflake? SystemChannelId { get; set; }
        
    /// <summary>
    /// System channel flags
    /// See <see cref="Entities.SystemChannelFlags"/>
    /// </summary>
    [JsonProperty("system_channel_flags")]
    public SystemChannelFlags SystemChannelFlags { get; set; }

    /// <summary>
    /// The id of the channel where Community guilds can display rules and/or guidelines
    /// </summary>
    [JsonProperty("rules_channel_id")]
    public Snowflake? RulesChannelId { get; set; }
        
    /// <summary>
    /// When this guild was joined at
    /// </summary>
    [JsonProperty("joined_at")]
    public DateTime? JoinedAt { get; set; }
  
    /// <summary>
    /// True if this is considered a large guild
    /// </summary>
    [JsonProperty("large")]
    public bool? Large { get; set; }
  
    /// <summary>
    /// True if this guild is unavailable due to an outage
    /// </summary>
    [JsonProperty("unavailable")]
    public bool? Unavailable { get; set; }
  
    /// <summary>
    /// Total number of members in this guild
    /// </summary>
    [JsonProperty("member_count")]
    public int? MemberCount { get; set; }

    /// <summary>
    /// States of members currently in voice channels; lacks the guild_id key
    /// </summary>
    [JsonConverter(typeof(HashListConverter<VoiceState>))]
    [JsonProperty("voice_states")]
    public Hash<Snowflake, VoiceState> VoiceStates { get; set; }

    /// <summary>
    /// Users in the guild
    /// </summary>
    [JsonConverter(typeof(HashListConverter<GuildMember>))]
    [JsonProperty("members")]
    public Hash<Snowflake, GuildMember> Members { get; set; }

    /// <summary>
    /// Channels in the guild
    /// </summary>
    [JsonConverter(typeof(HashListConverter<DiscordChannel>))]
    [JsonProperty("channels")]
    public Hash<Snowflake, DiscordChannel> Channels { get; set; }

    /// <summary>
    /// All active threads in the guild that current user has permission to view
    /// </summary>
    [JsonConverter(typeof(HashListConverter<DiscordChannel>))]
    [JsonProperty("threads")]
    public Hash<Snowflake, DiscordChannel> Threads { get; set; }

    /// <summary>
    /// Presences of the members in the guild
    /// will only include non-offline members if the size is greater than large threshold
    /// </summary>
    [JsonProperty("presences")]
    public List<PresenceUpdatedEvent> Presences { get; set; }
  
    /// <summary>
    /// The maximum number of presences for the guild (the default value, currently 25000, is in effect when null is returned)
    /// </summary>
    [JsonProperty("max_presences")]
    public int? MaxPresences { get; set; }
  
    /// <summary>
    /// The maximum number of members for the guild
    /// </summary>
    [JsonProperty("max_members")]
    public int? MaxMembers { get; set; }
  
    /// <summary>
    /// The vanity url code for the guild
    /// </summary>
    [JsonProperty("vanity_url_code")]
    public string VanityUrlCode { get; set; }
  
    /// <summary>
    /// The description of a guild
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }
        
    /// <summary>
    /// Banner hash
    /// </summary>
    [JsonProperty("banner")]
    public string Banner { get; set; }

    /// <summary>
    /// Premium tier (Server Boost level)
    /// </summary>
    [JsonProperty("premium_tier")]
    public GuildPremiumTier? PremiumTier { get; set; }
  
    /// <summary>
    /// The number of boosts this guild currently has
    /// </summary>
    [JsonProperty("premium_subscription_count")]
    public int? PremiumSubscriptionCount { get; set; }

    /// <summary>
    /// The preferred locale of a Community guild
    /// Used in server discovery and notices from Discord
    /// Defaults to "en-US"
    /// </summary>
    [JsonProperty("preferred_locale")]
    public string PreferredLocale { get; set; }
        
    /// <summary>
    /// The maximum amount of users in a video channel
    /// </summary>
    [JsonProperty("public_updates_channel_id")]
    public Snowflake? PublicUpdatesChannelId { get; set; }
        
    /// <summary>
    /// The maximum amount of users in a stage video channel
    /// </summary>
    [JsonProperty("max_stage_video_channel_users")]
    public int? MaxStageVideoChannelUsers { get; set; }
        
    /// <summary>
    /// The maximum amount of users in a video channel
    /// </summary>
    [JsonProperty("max_video_channel_users")]
    public int? MaxVideoChannelUsers { get; set; }
        
    /// <summary>
    /// Approximate number of members in this guild
    /// </summary>
    [JsonProperty("approximate_member_count")]
    public int? ApproximateMemberCount { get; set; }
        
    /// <summary>
    /// Approximate number of non-offline members in this guild
    /// </summary>
    [JsonProperty("approximate_presence_count")]
    public int? ApproximatePresenceCount { get; set; }
        
    /// <summary>
    /// The welcome screen of a Community guild
    /// Shown to new members, returned in an Invite's guild object
    /// </summary>
    [JsonProperty("welcome_screen")]
    public GuildWelcomeScreen WelcomeScreen { get; set; }
        
    /// <summary>
    /// Guild NSFW level
    /// <a href="https://support.discord.com/hc/en-us/articles/1500005389362-NSFW-Server-Designation">NSFW Information</a>
    /// </summary>
    [JsonProperty("nsfw_level")]
    public GuildNsfwLevel NsfwLevel { get; set; }

    /// <summary>
    /// Stage instances in the guild
    /// <see cref="StageInstance"/>
    /// </summary>
    [JsonConverter(typeof(HashListConverter<StageInstance>))]
    [JsonProperty("stage_instances")]
    public Hash<Snowflake, StageInstance> StageInstances { get; set; }

    /// <summary>
    /// Custom guild stickers
    /// <see cref="DiscordSticker"/>
    /// </summary>
    [JsonConverter(typeof(HashListConverter<DiscordSticker>))]
    [JsonProperty("stickers")]
    public Hash<Snowflake, DiscordSticker> Stickers { get; set; }
        
    /// <summary>
    /// The scheduled events in the guild
    /// <see cref="DiscordSticker"/>
    /// </summary>
    [JsonConverter(typeof(HashListConverter<GuildScheduledEvent>))]
    [JsonProperty("guild_scheduled_events")]
    public Hash<Snowflake, GuildScheduledEvent> ScheduledEvents { get; set; }        
        
    /// <summary>
    /// The scheduled events in the guild
    /// </summary>
    [JsonProperty("premium_progress_bar_enabled")]
    public bool PremiumProgressBarEnabled { get; set; }
        
    /// <summary>
    /// The ID of the channel where admins and moderators of Community guilds receive safety alerts from Discord
    /// </summary>
    [JsonProperty("safety_alerts_channel_id")]
    public Snowflake? SafetyAlertsChannelId { get; set; }
    #endregion

    #region Extension Fields
    /// <summary>
    /// Returns true if all guild members have been loaded
    /// </summary>
    public bool HasLoadedAllMembers { get; internal set; }

    /// <summary>
    /// Members who have left the guild
    /// This list will contain members who have left the guild since the initial bot connection
    /// </summary>
    public Hash<Snowflake, GuildMember> LeftMembers { get; } = new();
    #endregion

    #region Helper Properties
    /// <summary>
    /// Returns if the guild is available to use
    /// </summary>
    public bool IsAvailable => Unavailable.HasValue && !Unavailable.Value;

    /// <summary>
    /// Returns the guild Icon Url
    /// </summary>
    public string IconUrl => DiscordCdn.GetGuildIconUrl(Id, Icon);
        
    /// <summary>
    /// Returns the Guilds Splash Url
    /// </summary>
    public string SplashUrl => DiscordCdn.GetGuildSplashUrl(Id, Splash);
        
    /// <summary>
    /// Returns the guilds Discovery Splash
    /// </summary>
    public string DiscoverySplashUrl => DiscordCdn.GetGuildDiscoverySplashUrl(Id, DiscoverySplash);
        
    /// <summary>
    /// Return the guilds Banner Url
    /// </summary>
    public string BannerUrl => DiscordCdn.GetGuildBannerUrl(Id, Banner);

    /// <summary>
    /// Returns the everyone role for the guild.
    /// </summary>
    public DiscordRole EveryoneRole => Roles[Id];
    #endregion

    #region Helper Methods
    /// <summary>
    /// Returns a channel with the given name (Case Insensitive)
    /// </summary>
    /// <param name="name">Name of the channel</param>
    /// <returns>Channel with the given name; Null otherwise</returns>
    public DiscordChannel GetChannel(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

        foreach (DiscordChannel channel in Channels.Values)
        {
            if (channel.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return channel;
            }
        }

        return null;
    }

    /// <summary>
    /// Returns the <see cref="DiscordGuild"/> channel or thread by ID
    /// </summary>
    /// <param name="id">ID of the thread of channel</param>
    /// <returns><see cref="DiscordChannel"/></returns>
    public DiscordChannel GetChannel(Snowflake id)
    {
        return Channels[id] ?? Threads[id];
    }

    /// <summary>
    /// Returns the parent channel for a channel if it exists
    /// </summary>
    /// <param name="channel">Channel to find the parent for</param>
    /// <returns>Parent channel for the given channel; null otherwise</returns>
    public DiscordChannel GetParentChannel(DiscordChannel channel)
    {
        if (!channel.ParentId.HasValue || !channel.ParentId.Value.IsValid())
        {
            return null;
        }

        return Channels[channel.ParentId.Value];
    }

    /// <summary>
    /// Returns a Role with the given name (Case Insensitive)
    /// </summary>
    /// <param name="name">Name of the role</param>
    /// <returns>Role with the given name; Null otherwise</returns>
    public DiscordRole GetRole(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

        foreach (DiscordRole role in Roles.Values)
        {
            if (role.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return role;
            }
        }

        return null;
    }

    /// <summary>
    /// Returns the booster role for the guild if it exists
    /// </summary>
    /// <returns>Booster role; null otherwise</returns>
    public DiscordRole GetBoosterRole()
    {
        foreach (DiscordRole role in Roles.Values)
        {
            if (role.IsBoosterRole())
            {
                return role;
            }
        }

        return null;
    }
        
    /// <summary>
    /// Returns a GuildMember with the given username (Case Insensitive)
    /// </summary>
    /// <param name="userName">Username of the GuildMember</param>
    /// <returns>GuildMember with the given username; Null otherwise</returns>
    public GuildMember GetMember(string userName)
    {
        if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
            
        foreach (GuildMember member in Members.Values)
        {
            if (member.User.Username.Equals(userName, StringComparison.OrdinalIgnoreCase))
            {
                return member;
            }
        }
                
        return null;
    }

    /// <summary>
    /// Returns the  <see cref="GuildMember"/> for the given <see cref="Snowflake"/> User ID including members who are no longer in the guild
    /// Left members only include <see cref="GuildMember"/>s who have left the guild since the bot was connected
    /// </summary>
    /// <param name="userId">User ID of the guild member to get</param>
    /// <param name="includeLeft">If we should include guild members who have left the guild</param>
    /// <returns><see cref="GuildMember"/> For the UserId </returns>
    public GuildMember GetMember(Snowflake userId, bool includeLeft = false)
    {
        return Members[userId] ?? (includeLeft ? LeftMembers[userId] : null);
    }
        
    /// <summary>
    /// Finds guild emoji by name
    /// </summary>
    /// <param name="name">Name of the emoji</param>
    /// <returns>Emoji if found; null otherwise</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public DiscordEmoji GetEmoji(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

        foreach (DiscordEmoji emoji in Emojis.Values)
        {
            if (emoji.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return emoji;
            }
        }

        return null;
    }
        
    /// <summary>
    /// Returns the user permissions for the given user ID
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public PermissionFlags GetUserPermissions(Snowflake userId)
    {
        GuildMember member = Members[userId];
        if (member == null)
        {
            return PermissionFlags.None;
        }
            
        PermissionFlags permissions = EveryoneRole.Permissions;

        for (int index = 0; index < member.Roles.Count; index++)
        {
            DiscordRole role = Roles[member.Roles[index]];
            if (role != null)
            {
                permissions |= role.Permissions;
            }
        }

        if ((permissions & PermissionFlags.Administrator) == PermissionFlags.Administrator)
        {
            return PermissionFlags.All;
        }

        return permissions;
    }
    #endregion

    #region API Methods
    /// <summary>
    /// Create a new guild.
    /// See <a href="https://discord.com/developers/docs/resources/guild#create-guild">Create Guild</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="create">Guild Create Object</param>
    public static IPromise<DiscordGuild> Create(DiscordClient client, GuildCreate create)
    {
        if (create == null) throw new ArgumentNullException(nameof(create));
        return client.Bot.Rest.Post<DiscordGuild>(client,"guilds", create);
    }

    /// <summary>
    /// Returns the guild object for the given id
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild">Get Guild</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="guildId">Guild ID to lookup</param>
    public static IPromise<DiscordGuild> Get(DiscordClient client, Snowflake guildId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(guildId);
        return client.Bot.Rest.Get<DiscordGuild>(client,$"guilds/{guildId}");
    }
        
    /// <summary>
    /// Returns the guild preview object for the given id.
    /// If the user is not in the guild, then the guild must be Discoverable.
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="guildId">Guild ID to get preview for</param>
    public static IPromise<GuildPreview> GetGuildPreview(DiscordClient client, Snowflake guildId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(guildId);
        return client.Bot.Rest.Get<GuildPreview>(client,$"guilds/{guildId}/preview");
    }

    /// <summary>
    /// Modify a guild's settings.
    /// Requires the MANAGE_GUILD permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-guild">Modify Guild</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="update">Update to be applied to the guild</param>
    public IPromise<DiscordGuild> Edit(DiscordClient client, GuildUpdate update)
    {
        return client.Bot.Rest.Patch<DiscordGuild>(client,$"guilds/{Id}", update);
    }

    /// <summary>
    /// Delete a guild permanently.
    /// User must be owner
    /// See <a href="https://discord.com/developers/docs/resources/guild#delete-guild">Delete Guild</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise Delete(DiscordClient client)
    {
        return client.Bot.Rest.Delete(client,$"guilds/{Id}");
    }

    /// <summary>
    /// Returns a list of guild channel objects.
    /// Does not include threads
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-channels">Get Guild Channels</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<List<DiscordChannel>> GetChannels(DiscordClient client)
    {
        return client.Bot.Rest.Get<List<DiscordChannel>>(client,$"guilds/{Id}/channels");
    }

    /// <summary>
    /// Create a new channel object for the guild.
    /// Requires the MANAGE_CHANNELS permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#create-guild-channel">Create Guild Channel</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="channel">Channel to create</param>
    public IPromise<DiscordChannel> CreateChannel(DiscordClient client, ChannelCreate channel)
    {
        return client.Bot.Rest.Post<DiscordChannel>(client,$"guilds/{Id}/channels", channel);
    }

    /// <summary>
    /// Modify the positions of a set of channel objects for the guild.
    /// Requires MANAGE_CHANNELS permission.
    /// Only channels to be modified are required, with the minimum being a swap between at least two channels.
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-guild-channel-positions">Modify Guild Channel Positions</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="positions">List new channel positions for each channel</param>
    public IPromise<List<GuildChannelPosition>> EditChannelPositions(DiscordClient client, List<GuildChannelPosition> positions)
    {
        return client.Bot.Rest.Patch<List<GuildChannelPosition>>(client,$"guilds/{Id}/channels", positions);
    }

    /// <summary>
    /// Returns all active threads in the guild, including public and private threads. Threads are ordered by their id, in descending order.
    /// See <a href="https://discord.com/developers/docs/resources/guild#list-active-threads">List Active Threads</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<ThreadList> ListActiveThreads(DiscordClient client)
    {
        return client.Bot.Rest.Get<ThreadList>(client,$"guilds/{Id}/threads/active");
    }
        
    /// <summary>
    /// Returns a guild member object for the specified user.
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-member">Get Guild Member</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">UserID to get guild member for</param>
    public IPromise<GuildMember> GetMember(DiscordClient client, Snowflake userId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        return client.Bot.Rest.Get<GuildMember>(client,$"guilds/{Id}/members/{userId}");
    }

    /// <summary>
    /// Returns a list of guild member objects that are members of the guild.
    /// In the future, this endpoint will be restricted in line with our Privileged Intents
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="list">Query string request for the list</param>
    public IPromise<List<GuildMember>> Listembers(DiscordClient client, GuildListMembers list = null)
    {
        return client.Bot.Rest.Get<List<GuildMember>>(client,$"guilds/{Id}/members{list?.ToQueryString()}");
    }

    /// <summary>
    /// Searches for guild members by username or nickname
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="search">Username or nickname to match</param>
    public IPromise<List<GuildMember>> SearchMembers(DiscordClient client, GuildSearchMembers search)
    {
        if (search == null) throw new ArgumentNullException(nameof(search));
        return client.Bot.Rest.Get<List<GuildMember>>(client,$"guilds/{Id}/members/search{search.ToQueryString()}");
    }

    /// <summary>
    /// Adds a user to the guild, provided you have a valid oauth2 access token for the user with the guilds.join scope. 
    /// See <a href="https://discord.com/developers/docs/resources/guild#add-guild-member">Add Guild Member</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID of the user to add</param>
    /// <param name="member">Member to copy from</param>
    public IPromise<GuildMember> AddMember(DiscordClient client, Snowflake userId, GuildMemberAdd member)
    {
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        return client.Bot.Rest.Put<GuildMember>(client,$"guilds/{Id}/members/{userId}", member);
    }

    /// <summary>
    /// Modify attributes of a guild member
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-guild-member">Modify Guild Member</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID of the user to update</param>
    /// <param name="update">Changes to make to the user</param>
    public IPromise<GuildMember> EditMember(DiscordClient client, Snowflake userId, GuildMemberUpdate update)
    {
        if (update == null) throw new ArgumentNullException(nameof(update));
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        return client.Bot.Rest.Patch<GuildMember>(client,$"guilds/{Id}/members/{userId}", update);
    }
        
    /// <summary>
    /// Modify attributes of a guild member
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-guild-member">Modify Guild Member</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID of the user to update</param>
    /// <param name="nick">Nickname for the user</param>
    public IPromise<GuildMember> EditMemberNick(DiscordClient client, Snowflake userId, string nick)
    {
        GuildMemberUpdate update = new()
        {
            Nick = nick
        };
            
        return EditMember(client, userId, update);
    }
        
    /// <summary>
    /// Modifies the current members nickname in the guild
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-current-member">Modify Current Member</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="nick">New members nickname (1-32 characters)</param>
    public IPromise<GuildMember> EditCurrentMember(DiscordClient client, string nick)
    {
        InvalidGuildMemberException.ThrowIfInvalidNickname(nick);

        Dictionary<string, object> data = new()
        {
            ["nick"] = nick
        };
            
        return client.Bot.Rest.Patch<GuildMember>(client,$"guilds/{Id}/members/@me", data);
    }

    /// <summary>
    /// Adds a role to a guild member.
    /// Requires the MANAGE_ROLES permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#add-guild-member-role">Add Guild Member Role</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="user">User to add role to</param>
    /// <param name="role">Role to add</param>
    public IPromise AddMemberRole(DiscordClient client, DiscordUser user, DiscordRole role) => AddMemberRole(client, user.Id, role.Id);

    /// <summary>
    /// Adds a role to a guild member.
    /// Requires the MANAGE_ROLES permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#add-guild-member-role">Add Guild Member Role</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID to add role to</param>
    /// <param name="roleId">Role ID to add</param>
    public IPromise AddMemberRole(DiscordClient client, Snowflake userId, Snowflake roleId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        InvalidSnowflakeException.ThrowIfInvalid(roleId);
        return client.Bot.Rest.Put(client,$"guilds/{Id}/members/{userId}/roles/{roleId}", null);
    }

    /// <summary>
    /// Removes a role from a guild member.
    /// Requires the MANAGE_ROLES permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#remove-guild-member-role">Remove Guild Member Role</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="user">User to remove role form</param>
    /// <param name="role">Role to remove</param>
    public IPromise RemoveMemberRole(DiscordClient client, DiscordUser user, DiscordRole role) => RemoveMemberRole(client, user.Id, role.Id);

    /// <summary>
    /// Removes a role from a guild member.
    /// Requires the MANAGE_ROLES permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#remove-guild-member-role">Remove Guild Member Role</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID to remove role form</param>
    /// <param name="roleId">Role ID to remove</param>
    public IPromise RemoveMemberRole(DiscordClient client, Snowflake userId, Snowflake roleId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        InvalidSnowflakeException.ThrowIfInvalid(roleId);
        return client.Bot.Rest.Delete(client,$"guilds/{Id}/members/{userId}/roles/{roleId}");
    }

    /// <summary>
    /// Remove a member from a guild.
    /// Requires KICK_MEMBERS permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#remove-guild-member">Remove Guild Member</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="member">Guild Member to remove</param>
    public IPromise RemoveMember(DiscordClient client, GuildMember member) => RemoveMember(client, member.User.Id);

    /// <summary>
    /// Remove a member from a guild.
    /// Requires KICK_MEMBERS permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#remove-guild-member">Remove Guild Member</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID of the user to remove</param>
    public IPromise RemoveMember(DiscordClient client, Snowflake userId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        return client.Bot.Rest.Delete(client,$"guilds/{Id}/members/{userId}");
    }

    /// <summary>
    /// Returns a list of ban objects for the users banned from this guild.
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-bans">Get Guild Bans</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="request">Request params for retrieving guild bans</param>
    public IPromise<List<GuildBan>> GetBans(DiscordClient client, GuildBansRequest request = null)
    {
        return client.Bot.Rest.Get<List<GuildBan>>(client,$"guilds/{Id}/bans{request?.ToQueryString()}");
    }

    /// <summary>
    /// Returns a guild ban for a specific user
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-ban">Get Guild Ban</a>
    /// Returns 404 if not found
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID to get guild ban for</param>
    public IPromise<GuildBan> GetBan(DiscordClient client, Snowflake userId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        return client.Bot.Rest.Get<GuildBan>(client,$"guilds/{Id}/bans/{userId}");
    }

    /// <summary>
    /// Create a guild ban, and optionally delete previous messages sent by the banned user.
    /// Requires the BAN_MEMBERS permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#create-guild-ban">Create Guild Ban</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="member">Guild Member to ban</param>
    /// <param name="ban">User ban information</param>
    public IPromise CreateBan(DiscordClient client, GuildMember member, GuildBanCreate ban) => CreateBan(client, member.User.Id, ban);

    /// <summary>
    /// Create a guild ban, and optionally delete previous messages sent by the banned user.
    /// Requires the BAN_MEMBERS permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#create-guild-ban">Create Guild Ban</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID to ban</param>
    /// <param name="ban">User ban information</param>
    public IPromise CreateBan(DiscordClient client, Snowflake userId, GuildBanCreate ban)
    {
        if (ban == null) throw new ArgumentNullException(nameof(ban));
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        return client.Bot.Rest.Put(client,$"guilds/{Id}/bans/{userId}", ban);
    }

    /// <summary>
    /// Remove the ban for a user.
    /// Requires the BAN_MEMBERS permissions.
    /// See <a href="https://discord.com/developers/docs/resources/guild#remove-guild-ban">Remove Guild Ban</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID of the user to unban</param>
    public IPromise RemoveBan(DiscordClient client, Snowflake userId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        return client.Bot.Rest.Delete(client,$"guilds/{Id}/bans/{userId}");
    }

    /// <summary>
    /// Returns a list of role objects for the guild.
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-roles">Get Guild Roles</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<List<DiscordRole>> GetRoles(DiscordClient client)
    {
        return client.Bot.Rest.Get<List<DiscordRole>>(client,$"guilds/{Id}/roles");
    }

    /// <summary>
    /// Create a new role for the guild.
    /// Requires the MANAGE_ROLES permission.
    /// Returns the new role object on success.
    /// See <a href="https://discord.com/developers/docs/resources/guild#create-guild-role">Create Guild Role</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="role">New role to create</param>
    public IPromise<DiscordRole> CreateRole(DiscordClient client, DiscordRole role)
    {
        if (role == null) throw new ArgumentNullException(nameof(role));
        return client.Bot.Rest.Post<DiscordRole>(client,$"guilds/{Id}/roles", role);
    }

    /// <summary>
    /// Modify the positions of a set of role objects for the guild.
    /// Requires the MANAGE_ROLES permission.
    /// Returns a list of all of the guild's role objects on success.
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-guild-role-positions">Modify Guild Role Positions</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="positions">List of role with updated positions</param>
    public IPromise<List<DiscordRole>> EditRolePositions(DiscordClient client, List<GuildRolePosition> positions)
    {
        if (positions == null) throw new ArgumentNullException(nameof(positions));
        return client.Bot.Rest.Patch<List<DiscordRole>>(client,$"guilds/{Id}/roles", positions);
    }

    /// <summary>
    /// Modify a guild role.
    /// Requires the MANAGE_ROLES permission.
    /// Returns the updated role on success.
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-guild-role">Modify Guild Role</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="role">Role to update</param>
    public IPromise<DiscordRole> EditRole(DiscordClient client, DiscordRole role) => EditRole(client, role.Id, role);

    /// <summary>
    /// Modify a guild role.
    /// Requires the MANAGE_ROLES permission.
    /// Returns the updated role on success.
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-guild-role">Modify Guild Role</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="roleId">Role ID to update</param>
    /// <param name="role">Role to update</param>
    public IPromise<DiscordRole> EditRole(DiscordClient client, Snowflake roleId, DiscordRole role)
    {
        if (role == null) throw new ArgumentNullException(nameof(role));
        InvalidSnowflakeException.ThrowIfInvalid(roleId);
        return client.Bot.Rest.Patch<DiscordRole>(client,$"guilds/{Id}/roles/{roleId}", role);
    }
        
    /// <summary>
    /// Modify a guild's MFA level.
    /// Requires guild ownership.
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-guild-mfa-level">Modify Guild MFA Level</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="level"><see cref="GuildUpdateMfaLevel"/> to set</param>
    public IPromise EditMfaLevel(DiscordClient client, GuildUpdateMfaLevel level)
    {
        return client.Bot.Rest.Post(client,$"guilds/{Id}/mfa/", level);
    }

    /// <summary>
    /// Delete a guild role.
    /// Requires the MANAGE_ROLES permission
    /// See <a href="https://discord.com/developers/docs/resources/guild#delete-guild-role">Delete Guild Role</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="role">Role to Delete</param>
    public IPromise DeleteRole(DiscordClient client, DiscordRole role) => DeleteRole(client, role.Id);

    /// <summary>
    /// Delete a guild role.
    /// Requires the MANAGE_ROLES permission
    /// See <a href="https://discord.com/developers/docs/resources/guild#delete-guild-role">Delete Guild Role</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="roleId">Role ID to Delete</param>
    public IPromise DeleteRole(DiscordClient client, Snowflake roleId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(roleId);
        return client.Bot.Rest.Delete(client,$"guilds/{Id}/roles/{roleId}");
    }

    /// <summary>
    /// Returns an object with one 'pruned' key indicating the number of members that would be removed in a prune operation.
    /// Requires the KICK_MEMBERS permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-prune-count">Get Guild Prune Count</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="prune">Prune get request</param>
    public IPromise<GuildPruneResult> GetPruneCount(DiscordClient client, GuildPruneGet prune)
    {
        if (prune == null) throw new ArgumentNullException(nameof(prune));
        return client.Bot.Rest.Get<GuildPruneResult>(client, $"guilds/{Id}/prune?{prune.ToQueryString()}");
    }

    /// <summary>
    /// Begin a prune operation.
    /// Requires the KICK_MEMBERS permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#begin-guild-prune">Begin Guild Prune</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="prune">Prune begin request</param>
    public IPromise<GuildPruneResult> BeginPrune(DiscordClient client, GuildPruneBegin prune)
    {
        if (prune == null) throw new ArgumentNullException(nameof(prune));
        return client.Bot.Rest.Post<GuildPruneResult>(client, $"guilds/{Id}/prune?{prune.ToQueryString()}", null);
    }

    /// <summary>
    /// Returns a list of voice region objects for the guild.
    /// Unlike the similar /voice route, this returns VIP servers when the guild is VIP-enabled.
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-voice-regions">Get Guild Voice Regions</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<List<VoiceRegion>> GetVoiceRegions(DiscordClient client)
    {
        return client.Bot.Rest.Get<List<VoiceRegion>>(client,$"guilds/{Id}/regions");
    }

    /// <summary>
    /// Returns a list of invite objects (with invite metadata) for the guild.
    /// Requires the MANAGE_GUILD permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-invites">Get Guild Invites</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<List<InviteMetadata>> GetInvites(DiscordClient client)
    {
        return client.Bot.Rest.Get<List<InviteMetadata>>(client,$"guilds/{Id}/invites");
    }

    /// <summary>
    /// Returns a list of integration objects for the guild.
    /// Requires the MANAGE_GUILD permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-integrations">Get Guild Integrations</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<List<Integration>> GetIntegrations(DiscordClient client)
    {
        return client.Bot.Rest.Get<List<Integration>>(client,$"guilds/{Id}/integrations");
    }

    /// <summary>
    /// Delete the attached integration object for the guild.
    /// Deletes any associated webhooks and kicks the associated bot if there is one.
    /// Requires the MANAGE_GUILD permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#delete-guild-integration">Delete Guild Integration</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="integration">Integration to delete</param>
    public IPromise DeleteIntegration(DiscordClient client, Integration integration) => DeleteIntegration(client, integration.Id);

    /// <summary>
    /// Delete the attached integration object for the guild.
    /// Deletes any associated webhooks and kicks the associated bot if there is one.
    /// Requires the MANAGE_GUILD permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#delete-guild-integration">Delete Guild Integration</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="integrationId">Integration ID to delete</param>
    public IPromise DeleteIntegration(DiscordClient client, Snowflake integrationId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(integrationId);
        return client.Bot.Rest.Delete(client,$"guilds/{Id}/integrations/{integrationId}");
    }

    /// <summary>
    /// Returns a guild widget object.
    /// Requires the MANAGE_GUILD permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-widget-settings">Get Guild Widget Settings</a>
    /// </summary>
    /// <param name="client">client to use</param>
    public IPromise<GuildWidgetSettings> GetWidgetSettings(DiscordClient client)
    {
        return client.Bot.Rest.Get<GuildWidgetSettings>(client,$"guilds/{Id}/widget");
    }
        
    /// <summary>
    /// Modify a guild widget object for the guild.
    /// Requires the MANAGE_GUILD permission.
    /// See <a href="https://discord.com/developers/docs/resources/guild#modify-guild-widget">Modify Guild Widget</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="widget">Updated widget</param>
    public IPromise<GuildWidget> EditWidget(DiscordClient client, GuildWidget widget)
    {
        if (widget == null) throw new ArgumentNullException(nameof(widget));
        return client.Bot.Rest.Patch<GuildWidget>(client,$"guilds/{Id}/widget", widget);
    }

    /// <summary>
    /// Returns the widget for the guild.
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-widget">Get Guild Widget</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<GuildWidget> GetWidget(DiscordClient client)
    {
        return client.Bot.Rest.Get<GuildWidget>(client,$"guilds/{Id}/widget.json");
    }

    /// <summary>
    /// Returns the Welcome Screen object for the guild.
    /// Requires the `MANAGE_GUILD` permission.
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<GuildWelcomeScreen> GetWelcomeScreen(DiscordClient client)
    {
        return client.Bot.Rest.Get<GuildWelcomeScreen>(client,$"guilds/{Id}/welcome-screen");
    }

    /// <summary>
    /// Modify the guild's Welcome Screen.
    /// Requires the MANAGE_GUILD permission.
    /// Returns the updated Welcome Screen object.
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="update">Update to be made to the welcome screen</param>
    public IPromise<GuildWelcomeScreen> EditWelcomeScreen(DiscordClient client, WelcomeScreenUpdate update)
    {
        if (update == null) throw new ArgumentNullException(nameof(update));
        return client.Bot.Rest.Patch<GuildWelcomeScreen>(client,$"guilds/{Id}/welcome-screen", update);
    }

    /// <summary>
    /// Returns a partial invite object for guilds with that feature enabled.
    /// Requires the MANAGE_GUILD permission.
    /// Code will be null if a vanity url for the guild is not set.
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<InviteMetadata> GetVanityUrl(DiscordClient client)
    {
        return client.Bot.Rest.Get<InviteMetadata>(client,$"guilds/{Id}/vanity-url");
    }
        
    /// <summary>
    /// Returns a list of emoji objects for the given guild.
    /// See <a href="https://discord.com/developers/docs/resources/emoji#list-guild-emojis">List Guild Emojis</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<List<DiscordEmoji>> ListEmojis(DiscordClient client)
    {
        return client.Bot.Rest.Get<List<DiscordEmoji>>(client,$"guilds/{Id}/emojis");
    }
        
    /// <summary>
    /// Returns an emoji object for the given guild and emoji IDs.
    /// See <a href="https://discord.com/developers/docs/resources/emoji#get-guild-emoji">Get Guild Emoji</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="emojiId">Emoji to lookup</param>
    public IPromise<DiscordEmoji> GetEmoji(DiscordClient client, Snowflake emojiId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(emojiId);
        return client.Bot.Rest.Get<DiscordEmoji>(client,$"guilds/{Id}/emojis/{emojiId}");
    }
        
    /// <summary>
    /// Create a new emoji for the guild.
    /// Requires the MANAGE_EMOJIS permission.
    /// Returns the new emoji object on success.
    /// See <a href="https://discord.com/developers/docs/resources/emoji#create-guild-emoji">Create Guild Emoji</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="emoji">Emoji to create</param>
    public IPromise<DiscordEmoji> CreateEmoji(DiscordClient client, EmojiCreate emoji)
    {
        if (emoji == null) throw new ArgumentNullException(nameof(emoji));
        return client.Bot.Rest.Post<DiscordEmoji>(client,$"guilds/{Id}/emojis", emoji);
    }
        
    /// <summary>
    /// Modify the given emoji.
    /// Requires the MANAGE_EMOJIS permission.
    /// Returns the updated emoji object on success.
    /// See <a href="https://discord.com/developers/docs/resources/emoji#modify-guild-emoji">Modify Guild Emoji</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="emojiId">Emoji ID to update</param>
    /// <param name="emoji">Emoji update</param>
    public IPromise<DiscordEmoji> EditEmoji(DiscordClient client, Snowflake emojiId, EmojiUpdate emoji)
    {
        if (emoji == null) throw new ArgumentNullException(nameof(emoji));
        InvalidSnowflakeException.ThrowIfInvalid(emojiId);
        return client.Bot.Rest.Patch<DiscordEmoji>(client,$"guilds/{Id}/emojis/{emojiId}", emoji);
    }
        
    /// <summary>
    /// Delete the given emoji.
    /// Requires the MANAGE_EMOJIS permission.
    /// See <a href="https://discord.com/developers/docs/resources/emoji#delete-guild-emoji">Delete Guild Emoji</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="emojiId">Emoji ID to delete</param>
    public IPromise DeleteEmoji(DiscordClient client, Snowflake emojiId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(emojiId);
        return client.Bot.Rest.Delete(client,$"guilds/{Id}/emojis/{emojiId}");
    }
    
    /// <summary>
    /// Get Current User Voice State
    /// See <a href="https://discord.com/developers/docs/resources/voice#get-user-voice-state">Get Current User Voice State</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<VoiceState> GetCurrentUserVoiceState(DiscordClient client)
    {
        return client.Bot.Rest.Get<VoiceState>(client,$"guilds/{Id}/voice-states/@me");
    }

    /// <summary>
    /// Get Current User Voice State
    /// See <a href="https://discord.com/developers/docs/resources/voice#get-user-voice-state">Get User Voice State</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User ID to get the voice state for</param>
    public IPromise<VoiceState> GetUserVoiceState(DiscordClient client, Snowflake userId)
    {
        return client.Bot.Rest.Get<VoiceState>(client,$"guilds/{Id}/voice-states/{userId}");
    }

    /// <summary>
    /// Modifies the current user's voice state.
    /// See <a href="https://discord.com/developers/docs/resources/voice#modify-current-user-voice-state">Update Current User Voice State</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="update">Update to the guild voice state</param>
    public IPromise EditCurrentUserVoiceState(DiscordClient client, GuildCurrentUserVoiceStateUpdate update)
    {
        if (update == null) throw new ArgumentNullException(nameof(update));
        return client.Bot.Rest.Patch(client,$"guilds/{Id}/voice-states/@me", update);
    }

    /// <summary>
    /// Modifies another user's voice state.
    /// See <a href="https://discord.com/developers/docs/resources/voice#modify-user-voice-state">Update Users Voice State</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="userId">User to modify</param>
    /// <param name="update">Update to the guild voice state</param>
    public IPromise EditUserVoiceState(DiscordClient client, Snowflake userId, GuildUserVoiceStateUpdate update)
    {
        if (update == null) throw new ArgumentNullException(nameof(update));
        InvalidSnowflakeException.ThrowIfInvalid(userId);
        return client.Bot.Rest.Patch(client,$"guilds/{Id}/voice-states/{userId}", update);
    }
        
    /// <summary>
    /// Returns an array of sticker objects for the given guild.
    /// Includes user fields if the bot has the MANAGE_EMOJIS_AND_STICKERS permission.
    /// See <a href="https://discord.com/developers/docs/resources/sticker#list-guild-stickers">List Guild Stickers</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<List<DiscordSticker>> ListStickers(DiscordClient client)
    {
        return client.Bot.Rest.Get<List<DiscordSticker>>(client,$"guilds/{Id}/stickers");
    }
        
    /// <summary>
    /// Returns a sticker object for the given guild and sticker IDs.
    /// Includes the user field if the bot has the MANAGE_EMOJIS_AND_STICKERS permission.
    /// See <a href="https://discord.com/developers/docs/resources/sticker#get-guild-sticker">Get Guild Sticker</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="stickerId">ID of the sticker to get</param>
    public IPromise<DiscordSticker> GetSticker(DiscordClient client, Snowflake stickerId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(stickerId);
        return client.Bot.Rest.Get<DiscordSticker>(client,$"guilds/{Id}/stickers/{stickerId}");
    }
        
    /// <summary>
    /// Create a new sticker for the guild.
    /// Requires the MANAGE_EMOJIS_AND_STICKERS permission.
    /// Returns the new sticker object on success.
    /// See <a href="https://discord.com/developers/docs/resources/sticker#create-guild-sticker">Create Guild Sticker</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="sticker">Sticker to create</param>
    public IPromise<DiscordSticker> CreateSticker(DiscordClient client, GuildStickerCreate sticker)
    {
        if (sticker == null) throw new ArgumentNullException(nameof(sticker));
        return client.Bot.Rest.Post<DiscordSticker>(client,$"guilds/{Id}/stickers", sticker);
    }
        
    /// <summary>
    /// Modify the given sticker.
    /// Requires the MANAGE_EMOJIS_AND_STICKERS permission.
    /// Returns the updated sticker object on success.
    /// See <a href="https://discord.com/developers/docs/resources/sticker#modify-guild-sticker">Modify Guild Sticker</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="sticker">Sticker to modify</param>
    public IPromise<DiscordSticker> EditSticker(DiscordClient client, DiscordSticker sticker)
    {
        if (sticker == null) throw new ArgumentNullException(nameof(sticker));
        return client.Bot.Rest.Patch<DiscordSticker>(client,$"guilds/{Id}/stickers/{sticker.Id}", sticker);
    }
        
    /// <summary>
    /// Delete the given sticker.
    /// Requires the MANAGE_EMOJIS_AND_STICKERS permission.
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="stickerId">ID of the sticker to delete</param>
    /// See <a href="https://discord.com/developers/docs/resources/sticker#delete-guild-sticker">Delete Guild Sticker</a>
    public IPromise DeleteSticker(DiscordClient client, Snowflake stickerId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(stickerId);
        return client.Bot.Rest.Delete(client,$"guilds/{Id}/stickers/{stickerId}");
    }
        
    /// <inheritdoc cref="AutoModRule.GetAll"/>
    public IPromise<List<AutoModRule>> ListAutoModRules(DiscordClient client) 
        => AutoModRule.GetAll(client, Id);

    /// <inheritdoc cref="AutoModRule.Get"/>
    public IPromise<AutoModRule> GetAutoModRule(DiscordClient client, Snowflake ruleId) 
        => AutoModRule.Get(client, Id, ruleId);

    /// <inheritdoc cref="AutoModRule.Create"/>
    public IPromise<AutoModRule> CreateAutoModRule(DiscordClient client, AutoModRuleCreate create)
        => AutoModRule.Create(client, Id, create);
        
    /// <summary>
    /// Returns the <see cref="GuildOnboarding"/> for the guild.
    /// </summary>
    /// <param name="client">Client to use</param>
    /// See <a href="https://discord.com/developers/docs/resources/guild#get-guild-onboarding">Get Guild Onboarding</a>
    public IPromise<GuildOnboarding> GetOnboarding(DiscordClient client)
    {
        return client.Bot.Rest.Get<GuildOnboarding>(client,$"guilds/{Id}/onboarding");
    }

    /// <summary>
    /// Modifies the onboarding configuration of the guild.
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="update">Update for the guild onboarding</param>
    /// See <a href="">Modify Guild Onboarding</a>
    public IPromise<GuildOnboarding> EditOnboarding(DiscordClient client, GuildOnboardingUpdate update)
    {
        return client.Bot.Rest.Put<GuildOnboarding>(client,$"guilds/{Id}/onboarding", update);
    }
    #endregion

    #region Entity Update Methods
    internal DiscordGuild Edit(DiscordGuild updatedGuild)
    {
        DiscordGuild previous = (DiscordGuild)MemberwiseClone();
        if (updatedGuild.Name != null)
            Name = updatedGuild.Name;
        if (updatedGuild.Icon != null)
            Icon = updatedGuild.Icon;
        if (updatedGuild.IconHash != null)
            IconHash = updatedGuild.IconHash;
        if (updatedGuild.Splash != null)
            Splash = updatedGuild.Splash;
        if (updatedGuild.DiscoverySplash != null)
            DiscoverySplash = updatedGuild.DiscoverySplash;
        if(updatedGuild.OwnerId.IsValid()) 
            OwnerId = updatedGuild.OwnerId;
        if (updatedGuild.AfkChannelId != null)
            AfkChannelId = updatedGuild.AfkChannelId;
        if (updatedGuild.AfkTimeout != null)
            AfkTimeout = updatedGuild.AfkTimeout;
        if (updatedGuild.WidgetEnabled != null)
            WidgetEnabled = updatedGuild.WidgetEnabled;
        if (updatedGuild.WidgetChannelId != null)
            WidgetChannelId = updatedGuild.WidgetChannelId;
        VerificationLevel = updatedGuild.VerificationLevel;
        DefaultMessageNotifications = updatedGuild.DefaultMessageNotifications;
        ExplicitContentFilter = updatedGuild.ExplicitContentFilter;
        if (updatedGuild.Roles != null)
            Roles = updatedGuild.Roles;
        if (updatedGuild.Emojis != null)
            Emojis = updatedGuild.Emojis;
        if (updatedGuild.Features != null)
            Features = updatedGuild.Features;
        if (updatedGuild.MfaLevel != null)
            MfaLevel = updatedGuild.MfaLevel;
        if (updatedGuild.ApplicationId != null)
            ApplicationId = updatedGuild.ApplicationId;
        if (updatedGuild.SystemChannelId != null)
            SystemChannelId = updatedGuild.SystemChannelId;
        SystemChannelFlags = updatedGuild.SystemChannelFlags;
        if (RulesChannelId != null)
            RulesChannelId = updatedGuild.RulesChannelId;
        if (updatedGuild.JoinedAt != null)
            JoinedAt = updatedGuild.JoinedAt;
        if (updatedGuild.Large != null)
            Large = updatedGuild.Large;
        if (updatedGuild.Unavailable != null && (!Unavailable.HasValue || Unavailable.Value))
            Unavailable = updatedGuild.Unavailable;
        if (updatedGuild.MemberCount != null)
            MemberCount = updatedGuild.MemberCount;
        if (updatedGuild.VoiceStates != null)
            VoiceStates = updatedGuild.VoiceStates;
        if (updatedGuild.Members != null)
            Members = updatedGuild.Members;
        if (updatedGuild.Channels != null)
            Channels = updatedGuild.Channels;
        if (updatedGuild.Threads != null)
            Threads = updatedGuild.Threads;
        if (updatedGuild.Presences != null)
            Presences = updatedGuild.Presences;
        if (updatedGuild.MaxPresences != null)
            MaxPresences = updatedGuild.MaxPresences;
        if (updatedGuild.MaxMembers != null)
            MaxMembers = updatedGuild.MaxMembers;
        if (updatedGuild.VanityUrlCode != null)
            VanityUrlCode = updatedGuild.VanityUrlCode;
        if (updatedGuild.Description != null)
            Description = updatedGuild.Description;
        if (updatedGuild.Banner != null)
            Banner = updatedGuild.Banner;
        if (updatedGuild.PremiumTier != null)
            PremiumTier = updatedGuild.PremiumTier;
        if (updatedGuild.PremiumSubscriptionCount != null)
            PremiumSubscriptionCount = updatedGuild.PremiumSubscriptionCount;
        if (updatedGuild.PreferredLocale != null)
            PreferredLocale = updatedGuild.PreferredLocale;
        if (updatedGuild.PublicUpdatesChannelId != null)
            PublicUpdatesChannelId = updatedGuild.PublicUpdatesChannelId;
        if (updatedGuild.MaxVideoChannelUsers != null)
            MaxVideoChannelUsers = updatedGuild.MaxVideoChannelUsers;
        if (updatedGuild.ApproximateMemberCount != null)
            ApproximateMemberCount = updatedGuild.ApproximateMemberCount;
        if (updatedGuild.ApproximatePresenceCount != null)
            ApproximatePresenceCount = updatedGuild.ApproximatePresenceCount;
        if (updatedGuild.WelcomeScreen != null)
            WelcomeScreen = updatedGuild.WelcomeScreen;
        NsfwLevel = updatedGuild.NsfwLevel;
        if (updatedGuild.StageInstances != null)
            StageInstances = updatedGuild.StageInstances;
        if (updatedGuild.Stickers != null)
            Stickers = updatedGuild.Stickers;
        if (updatedGuild.ScheduledEvents != null)
            ScheduledEvents = updatedGuild.ScheduledEvents;
        PremiumProgressBarEnabled = updatedGuild.PremiumProgressBarEnabled;
        if (updatedGuild.SafetyAlertsChannelId != null)
            SafetyAlertsChannelId = updatedGuild.SafetyAlertsChannelId;
        return previous;
    }
    #endregion
}