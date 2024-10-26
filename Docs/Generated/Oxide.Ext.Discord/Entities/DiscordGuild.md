# DiscordGuild class

Represents [Guild Structure](https://discord.com/developers/docs/resources/guild#guild-object)

```csharp
public class DiscordGuild : ISnowflakeEntity
```

## Public Members

| name | description |
| --- | --- |
| [DiscordGuild](#discordguild-constructor)() | The default constructor. |
| [AfkChannelId](#afkchannelid-property) { get; set; } | ID of afk channel |
| [AfkTimeout](#afktimeout-property) { get; set; } | Afk timeout in seconds |
| [ApplicationId](#applicationid-property) { get; set; } | Application id of the guild creator if it is bot-created |
| [ApproximateMemberCount](#approximatemembercount-property) { get; set; } | Approximate number of members in this guild |
| [ApproximatePresenceCount](#approximatepresencecount-property) { get; set; } | Approximate number of non-offline members in this guild |
| [Banner](#banner-property) { get; set; } | Banner hash |
| [BannerUrl](#bannerurl-property) { get; } | Return the guilds Banner Url |
| [Channels](#channels-property) { get; set; } | Channels in the guild |
| [DefaultMessageNotifications](#defaultmessagenotifications-property) { get; set; } | Default message notification level |
| [Description](#description-property) { get; set; } | The description of a guild |
| [DiscoverySplash](#discoverysplash-property) { get; set; } | Discovery splash hash Only present for guilds with the "DISCOVERABLE" feature |
| [DiscoverySplashUrl](#discoverysplashurl-property) { get; } | Returns the guilds Discovery Splash |
| [Emojis](#emojis-property) { get; set; } | Custom guild emojis |
| [EveryoneRole](#everyonerole-property) { get; } | Returns the everyone role for the guild. |
| [ExplicitContentFilter](#explicitcontentfilter-property) { get; set; } | Explicit content filter level |
| [Features](#features-property) { get; set; } | Enabled guild features See [`GuildFeatures`](./GuildFeatures.md) |
| [HasLoadedAllMembers](#hasloadedallmembers-property) { get; } | Returns true if all guild members have been loaded |
| [Icon](#icon-property) { get; set; } | Base64 128x128 image for the guild icon |
| [IconHash](#iconhash-property) { get; set; } | Icon hash |
| [IconUrl](#iconurl-property) { get; } | Returns the guild Icon Url |
| [Id](#id-property) { get; set; } | Guild id |
| [IsAvailable](#isavailable-property) { get; } | Returns if the guild is available to use |
| [JoinedAt](#joinedat-property) { get; set; } | When this guild was joined at |
| [Large](#large-property) { get; set; } | True if this is considered a large guild |
| [LeftMembers](#leftmembers-property) { get; } | Members who have left the guild This list will contain members who have left the guild since the initial bot connection |
| [MaxMembers](#maxmembers-property) { get; set; } | The maximum number of members for the guild |
| [MaxPresences](#maxpresences-property) { get; set; } | The maximum number of presences for the guild (the default value, currently 25000, is in effect when null is returned) |
| [MaxStageVideoChannelUsers](#maxstagevideochannelusers-property) { get; set; } | The maximum amount of users in a stage video channel |
| [MaxVideoChannelUsers](#maxvideochannelusers-property) { get; set; } | The maximum amount of users in a video channel |
| [MemberCount](#membercount-property) { get; set; } | Total number of members in this guild |
| [Members](#members-property) { get; set; } | Users in the guild |
| [MfaLevel](#mfalevel-property) { get; set; } | Required MFA level for the guild See [`GuildMfaLevel`](./GuildMfaLevel.md) |
| [Name](#name-property) { get; set; } | Name of the guild (2-100 characters) |
| [NsfwLevel](#nsfwlevel-property) { get; set; } | Guild NSFW level [NSFW Information](https://support.discord.com/hc/en-us/articles/1500005389362-NSFW-Server-Designation) |
| [Owner](#owner-property) { get; set; } | True if the user is the owner of the guild |
| [OwnerId](#ownerid-property) { get; set; } | ID of owner |
| [Permissions](#permissions-property) { get; set; } | Total permissions for the user in the guild (excludes overrides) |
| [PreferredLocale](#preferredlocale-property) { get; set; } | The preferred locale of a Community guild Used in server discovery and notices from Discord Defaults to "en-US" |
| [PremiumProgressBarEnabled](#premiumprogressbarenabled-property) { get; set; } | The scheduled events in the guild |
| [PremiumSubscriptionCount](#premiumsubscriptioncount-property) { get; set; } | The number of boosts this guild currently has |
| [PremiumTier](#premiumtier-property) { get; set; } | Premium tier (Server Boost level) |
| [Presences](#presences-property) { get; set; } | Presences of the members in the guild will only include non-offline members if the size is greater than large threshold |
| [PublicUpdatesChannelId](#publicupdateschannelid-property) { get; set; } | The maximum amount of users in a video channel |
| [Roles](#roles-property) { get; set; } | Roles in the guild |
| [RulesChannelId](#ruleschannelid-property) { get; set; } | The id of the channel where Community guilds can display rules and/or guidelines |
| [SafetyAlertsChannelId](#safetyalertschannelid-property) { get; set; } | The ID of the channel where admins and moderators of Community guilds receive safety alerts from Discord |
| [ScheduledEvents](#scheduledevents-property) { get; set; } | The scheduled events in the guild [`DiscordSticker`](./DiscordSticker.md) |
| [Splash](#splash-property) { get; set; } | Splash hash |
| [SplashUrl](#splashurl-property) { get; } | Returns the Guilds Splash Url |
| [StageInstances](#stageinstances-property) { get; set; } | Stage instances in the guild [`StageInstance`](./StageInstance.md) |
| [Stickers](#stickers-property) { get; set; } | Custom guild stickers [`DiscordSticker`](./DiscordSticker.md) |
| [SystemChannelFlags](#systemchannelflags-property) { get; set; } | System channel flags See [`SystemChannelFlags`](./SystemChannelFlags.md) |
| [SystemChannelId](#systemchannelid-property) { get; set; } | The id of the channel where guild notices such as welcome messages and boost events are posted |
| [Threads](#threads-property) { get; set; } | All active threads in the guild that current user has permission to view |
| [Unavailable](#unavailable-property) { get; set; } | True if this guild is unavailable due to an outage |
| [VanityUrlCode](#vanityurlcode-property) { get; set; } | The vanity url code for the guild |
| [VerificationLevel](#verificationlevel-property) { get; set; } | Verification level |
| [VoiceStates](#voicestates-property) { get; set; } | States of members currently in voice channels; lacks the guild_id key |
| [WelcomeScreen](#welcomescreen-property) { get; set; } | The welcome screen of a Community guild Shown to new members, returned in an Invite's guild object |
| [WidgetChannelId](#widgetchannelid-property) { get; set; } | The channel id that the widget will generate an invite to, or null if set to no invite |
| [WidgetEnabled](#widgetenabled-property) { get; set; } | True if the server widget is enabled |
| [AddMember](#addmember-method)(…) | Adds a user to the guild, provided you have a valid oauth2 access token for the user with the guilds.join scope. See [Add Guild Member](https://discord.com/developers/docs/resources/guild#add-guild-member) |
| [AddMemberRole](#addmemberrole-method-1-of-2)(…) | Adds a role to a guild member. Requires the MANAGE_ROLES permission. See [Add Guild Member Role](https://discord.com/developers/docs/resources/guild#add-guild-member-role) (2 methods) |
| [BeginPrune](#beginprune-method)(…) | Begin a prune operation. Requires the KICK_MEMBERS permission. See [Begin Guild Prune](https://discord.com/developers/docs/resources/guild#begin-guild-prune) |
| [CreateAutoModRule](#createautomodrule-method)(…) |  |
| [CreateBan](#createban-method-1-of-2)(…) | Create a guild ban, and optionally delete previous messages sent by the banned user. Requires the BAN_MEMBERS permission. See [Create Guild Ban](https://discord.com/developers/docs/resources/guild#create-guild-ban) (2 methods) |
| [CreateChannel](#createchannel-method)(…) | Create a new channel object for the guild. Requires the MANAGE_CHANNELS permission. See [Create Guild Channel](https://discord.com/developers/docs/resources/guild#create-guild-channel) |
| [CreateEmoji](#createemoji-method)(…) | Create a new emoji for the guild. Requires the MANAGE_EMOJIS permission. Returns the new emoji object on success. See [Create Guild Emoji](https://discord.com/developers/docs/resources/emoji#create-guild-emoji) |
| [CreateRole](#createrole-method)(…) | Create a new role for the guild. Requires the MANAGE_ROLES permission. Returns the new role object on success. See [Create Guild Role](https://discord.com/developers/docs/resources/guild#create-guild-role) |
| [CreateSticker](#createsticker-method)(…) | Create a new sticker for the guild. Requires the MANAGE_EMOJIS_AND_STICKERS permission. Returns the new sticker object on success. See [Create Guild Sticker](https://discord.com/developers/docs/resources/sticker#create-guild-sticker) |
| [Delete](#delete-method)(…) | Delete a guild permanently. User must be owner See [Delete Guild](https://discord.com/developers/docs/resources/guild#delete-guild) |
| [DeleteEmoji](#deleteemoji-method)(…) | Delete the given emoji. Requires the MANAGE_EMOJIS permission. See [Delete Guild Emoji](https://discord.com/developers/docs/resources/emoji#delete-guild-emoji) |
| [DeleteIntegration](#deleteintegration-method-1-of-2)(…) | Delete the attached integration object for the guild. Deletes any associated webhooks and kicks the associated bot if there is one. Requires the MANAGE_GUILD permission. See [Delete Guild Integration](https://discord.com/developers/docs/resources/guild#delete-guild-integration) (2 methods) |
| [DeleteRole](#deleterole-method-1-of-2)(…) | Delete a guild role. Requires the MANAGE_ROLES permission See [Delete Guild Role](https://discord.com/developers/docs/resources/guild#delete-guild-role) (2 methods) |
| [DeleteSticker](#deletesticker-method)(…) | Delete the given sticker. Requires the MANAGE_EMOJIS_AND_STICKERS permission. |
| [Edit](#edit-method)(…) | Modify a guild's settings. Requires the MANAGE_GUILD permission. See [Modify Guild](https://discord.com/developers/docs/resources/guild#modify-guild) |
| [EditChannelPositions](#editchannelpositions-method)(…) | Modify the positions of a set of channel objects for the guild. Requires MANAGE_CHANNELS permission. Only channels to be modified are required, with the minimum being a swap between at least two channels. See [Modify Guild Channel Positions](https://discord.com/developers/docs/resources/guild#modify-guild-channel-positions) |
| [EditCurrentMember](#editcurrentmember-method)(…) | Modifies the current members nickname in the guild See [Modify Current Member](https://discord.com/developers/docs/resources/guild#modify-current-member) |
| [EditCurrentUserVoiceState](#editcurrentuservoicestate-method)(…) | Modifies the current user's voice state. See [Update Current User Voice State](https://discord.com/developers/docs/resources/guild#modify-current-user-voice-state) |
| [EditEmoji](#editemoji-method)(…) | Modify the given emoji. Requires the MANAGE_EMOJIS permission. Returns the updated emoji object on success. See [Modify Guild Emoji](https://discord.com/developers/docs/resources/emoji#modify-guild-emoji) |
| [EditMember](#editmember-method)(…) | Modify attributes of a guild member See [Modify Guild Member](https://discord.com/developers/docs/resources/guild#modify-guild-member) |
| [EditMemberNick](#editmembernick-method)(…) | Modify attributes of a guild member See [Modify Guild Member](https://discord.com/developers/docs/resources/guild#modify-guild-member) |
| [EditMfaLevel](#editmfalevel-method)(…) | Modify a guild's MFA level. Requires guild ownership. See [Modify Guild MFA Level](https://discord.com/developers/docs/resources/guild#modify-guild-mfa-level) |
| [EditOnboarding](#editonboarding-method)(…) | Modifies the onboarding configuration of the guild. |
| [EditRole](#editrole-method-1-of-2)(…) | Modify a guild role. Requires the MANAGE_ROLES permission. Returns the updated role on success. See [Modify Guild Role](https://discord.com/developers/docs/resources/guild#modify-guild-role) (2 methods) |
| [EditRolePositions](#editrolepositions-method)(…) | Modify the positions of a set of role objects for the guild. Requires the MANAGE_ROLES permission. Returns a list of all of the guild's role objects on success. See [Modify Guild Role Positions](https://discord.com/developers/docs/resources/guild#modify-guild-role-positions) |
| [EditSticker](#editsticker-method)(…) | Modify the given sticker. Requires the MANAGE_EMOJIS_AND_STICKERS permission. Returns the updated sticker object on success. See [Modify Guild Sticker](https://discord.com/developers/docs/resources/sticker#modify-guild-sticker) |
| [EditUserVoiceState](#edituservoicestate-method)(…) | Modifies another user's voice state. See [Update Users Voice State](https://discord.com/developers/docs/resources/guild#modify-user-voice-state) |
| [EditWelcomeScreen](#editwelcomescreen-method)(…) | Modify the guild's Welcome Screen. Requires the MANAGE_GUILD permission. Returns the updated Welcome Screen object. |
| [EditWidget](#editwidget-method)(…) | Modify a guild widget object for the guild. Requires the MANAGE_GUILD permission. See [Modify Guild Widget](https://discord.com/developers/docs/resources/guild#modify-guild-widget) |
| [GetAutoModRule](#getautomodrule-method)(…) |  |
| [GetBan](#getban-method)(…) | Returns a guild ban for a specific user See [Get Guild Ban](https://discord.com/developers/docs/resources/guild#get-guild-ban) Returns 404 if not found |
| [GetBans](#getbans-method)(…) | Returns a list of ban objects for the users banned from this guild. See [Get Guild Bans](https://discord.com/developers/docs/resources/guild#get-guild-bans) |
| [GetBoosterRole](#getboosterrole-method)() | Returns the booster role for the guild if it exists |
| [GetChannel](#getchannel-method-1-of-2)(…) | Returns a channel with the given name (Case Insensitive) (2 methods) |
| [GetChannels](#getchannels-method)(…) | Returns a list of guild channel objects. Does not include threads See [Get Guild Channels](https://discord.com/developers/docs/resources/guild#get-guild-channels) |
| [GetEmoji](#getemoji-method-1-of-2)(…) | Finds guild emoji by name (2 methods) |
| [GetIntegrations](#getintegrations-method)(…) | Returns a list of integration objects for the guild. Requires the MANAGE_GUILD permission. See [Get Guild Integrations](https://discord.com/developers/docs/resources/guild#get-guild-integrations) |
| [GetInvites](#getinvites-method)(…) | Returns a list of invite objects (with invite metadata) for the guild. Requires the MANAGE_GUILD permission. See [Get Guild Invites](https://discord.com/developers/docs/resources/guild#get-guild-invites) |
| [GetMember](#getmember-method-1-of-3)(…) | Returns a GuildMember with the given username (Case Insensitive) (3 methods) |
| [GetOnboarding](#getonboarding-method)(…) | Returns the [`GuildOnboarding`](./GuildOnboarding.md) for the guild. |
| [GetParentChannel](#getparentchannel-method)(…) | Returns the parent channel for a channel if it exists |
| [GetPruneCount](#getprunecount-method)(…) | Returns an object with one 'pruned' key indicating the number of members that would be removed in a prune operation. Requires the KICK_MEMBERS permission. See [Get Guild Prune Count](https://discord.com/developers/docs/resources/guild#get-guild-prune-count) |
| [GetRole](#getrole-method)(…) | Returns a Role with the given name (Case Insensitive) |
| [GetRoles](#getroles-method)(…) | Returns a list of role objects for the guild. See [Get Guild Roles](https://discord.com/developers/docs/resources/guild#get-guild-roles) |
| [GetSticker](#getsticker-method)(…) | Returns a sticker object for the given guild and sticker IDs. Includes the user field if the bot has the MANAGE_EMOJIS_AND_STICKERS permission. See [Get Guild Sticker](https://discord.com/developers/docs/resources/sticker#get-guild-sticker) |
| [GetUserPermissions](#getuserpermissions-method)(…) | Returns the user permissions for the given user ID |
| [GetVanityUrl](#getvanityurl-method)(…) | Returns a partial invite object for guilds with that feature enabled. Requires the MANAGE_GUILD permission. Code will be null if a vanity url for the guild is not set. |
| [GetVoiceRegions](#getvoiceregions-method)(…) | Returns a list of voice region objects for the guild. Unlike the similar /voice route, this returns VIP servers when the guild is VIP-enabled. See [Get Guild Voice Regions](https://discord.com/developers/docs/resources/guild#get-guild-voice-regions) |
| [GetWelcomeScreen](#getwelcomescreen-method)(…) | Returns the Welcome Screen object for the guild. Requires the `MANAGE_GUILD` permission. |
| [GetWidget](#getwidget-method)(…) | Returns the widget for the guild. See [Get Guild Widget](https://discord.com/developers/docs/resources/guild#get-guild-widget) |
| [GetWidgetSettings](#getwidgetsettings-method)(…) | Returns a guild widget object. Requires the MANAGE_GUILD permission. See [Get Guild Widget Settings](https://discord.com/developers/docs/resources/guild#get-guild-widget-settings) |
| [ListActiveThreads](#listactivethreads-method)(…) | Returns all active threads in the guild, including public and private threads. Threads are ordered by their id, in descending order. See [List Active Threads](https://discord.com/developers/docs/resources/guild#list-active-threads) |
| [ListAutoModRules](#listautomodrules-method)(…) |  |
| [ListEmojis](#listemojis-method)(…) | Returns a list of emoji objects for the given guild. See [List Guild Emojis](https://discord.com/developers/docs/resources/emoji#list-guild-emojis) |
| [ListMembers](#listmembers-method)(…) | Returns a list of guild member objects that are members of the guild. In the future, this endpoint will be restricted in line with our Privileged Intents |
| [ListStickers](#liststickers-method)(…) | Returns an array of sticker objects for the given guild. Includes user fields if the bot has the MANAGE_EMOJIS_AND_STICKERS permission. See [List Guild Stickers](https://discord.com/developers/docs/resources/sticker#list-guild-stickers) |
| [RemoveBan](#removeban-method)(…) | Remove the ban for a user. Requires the BAN_MEMBERS permissions. See [Remove Guild Ban](https://discord.com/developers/docs/resources/guild#remove-guild-ban) |
| [RemoveMember](#removemember-method-1-of-2)(…) | Remove a member from a guild. Requires KICK_MEMBERS permission. See [Remove Guild Member](https://discord.com/developers/docs/resources/guild#remove-guild-member) (2 methods) |
| [RemoveMemberRole](#removememberrole-method-1-of-2)(…) | Removes a role from a guild member. Requires the MANAGE_ROLES permission. See [Remove Guild Member Role](https://discord.com/developers/docs/resources/guild#remove-guild-member-role) (2 methods) |
| [SearchMembers](#searchmembers-method)(…) | Searches for guild members by username or nickname |
| static [Create](#create-method)(…) | Create a new guild. See [Create Guild](https://discord.com/developers/docs/resources/guild#create-guild) |
| static [Get](#get-method)(…) | Returns the guild object for the given id See [Get Guild](https://discord.com/developers/docs/resources/guild#get-guild) |
| static [GetGuildPreview](#getguildpreview-method)(…) | Returns the guild preview object for the given id. If the user is not in the guild, then the guild must be Discoverable. |

## See Also

* interface [ISnowflakeEntity](../Interfaces/ISnowflakeEntity.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordGuild.cs](../../../../Oxide.Ext.Discord/Entities/DiscordGuild.cs)
   
   
# GetChannel method (1 of 2)

Returns the [`DiscordGuild`](./DiscordGuild.md) channel or thread by ID

```csharp
public DiscordChannel GetChannel(Snowflake id)
```

| parameter | description |
| --- | --- |
| id | ID of the thread of channel |

## Return Value

[`DiscordChannel`](./DiscordChannel.md)

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# GetChannel method (2 of 2)

Returns a channel with the given name (Case Insensitive)

```csharp
public DiscordChannel GetChannel(string name)
```

| parameter | description |
| --- | --- |
| name | Name of the channel |

## Return Value

Channel with the given name; Null otherwise

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetParentChannel method

Returns the parent channel for a channel if it exists

```csharp
public DiscordChannel GetParentChannel(DiscordChannel channel)
```

| parameter | description |
| --- | --- |
| channel | Channel to find the parent for |

## Return Value

Parent channel for the given channel; null otherwise

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetRole method

Returns a Role with the given name (Case Insensitive)

```csharp
public DiscordRole GetRole(string name)
```

| parameter | description |
| --- | --- |
| name | Name of the role |

## Return Value

Role with the given name; Null otherwise

## See Also

* class [DiscordRole](./DiscordRole.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetBoosterRole method

Returns the booster role for the guild if it exists

```csharp
public DiscordRole GetBoosterRole()
```

## Return Value

Booster role; null otherwise

## See Also

* class [DiscordRole](./DiscordRole.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetMember method (1 of 3)

Returns a GuildMember with the given username (Case Insensitive)

```csharp
public GuildMember GetMember(string userName)
```

| parameter | description |
| --- | --- |
| userName | Username of the GuildMember |

## Return Value

GuildMember with the given username; Null otherwise

## See Also

* class [GuildMember](./GuildMember.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# GetMember method (2 of 3)

Returns a guild member object for the specified user. See [Get Guild Member](https://discord.com/developers/docs/resources/guild#get-guild-member)

```csharp
public IPromise<GuildMember> GetMember(DiscordClient client, Snowflake userId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | UserID to get guild member for |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# GetMember method (3 of 3)

Returns the [`GuildMember`](./GuildMember.md) for the given [`Snowflake`](./Snowflake.md) User ID including members who are no longer in the guild Left members only include [`GuildMember`](./GuildMember.md)s who have left the guild since the bot was connected

```csharp
public GuildMember GetMember(Snowflake userId, bool includeLeft = false)
```

| parameter | description |
| --- | --- |
| userId | User ID of the guild member to get |
| includeLeft | If we should include guild members who have left the guild |

## Return Value

[`GuildMember`](./GuildMember.md) For the UserId

## See Also

* class [GuildMember](./GuildMember.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetEmoji method (1 of 2)

Finds guild emoji by name

```csharp
public DiscordEmoji GetEmoji(string name)
```

| parameter | description |
| --- | --- |
| name | Name of the emoji |

## Return Value

Emoji if found; null otherwise

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException |  |

## See Also

* class [DiscordEmoji](./DiscordEmoji.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# GetEmoji method (2 of 2)

Returns an emoji object for the given guild and emoji IDs. See [Get Guild Emoji](https://discord.com/developers/docs/resources/emoji#get-guild-emoji)

```csharp
public IPromise<DiscordEmoji> GetEmoji(DiscordClient client, Snowflake emojiId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| emojiId | Emoji to lookup |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordEmoji](./DiscordEmoji.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetUserPermissions method

Returns the user permissions for the given user ID

```csharp
public PermissionFlags GetUserPermissions(Snowflake userId)
```

| parameter | description |
| --- | --- |
| userId |  |

## See Also

* enum [PermissionFlags](./PermissionFlags.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Create method

Create a new guild. See [Create Guild](https://discord.com/developers/docs/resources/guild#create-guild)

```csharp
public static IPromise<DiscordGuild> Create(DiscordClient client, GuildCreate create)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| create | Guild Create Object |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildCreate](./GuildCreate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Get method

Returns the guild object for the given id See [Get Guild](https://discord.com/developers/docs/resources/guild#get-guild)

```csharp
public static IPromise<DiscordGuild> Get(DiscordClient client, Snowflake guildId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild ID to lookup |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetGuildPreview method

Returns the guild preview object for the given id. If the user is not in the guild, then the guild must be Discoverable.

```csharp
public static IPromise<GuildPreview> GetGuildPreview(DiscordClient client, Snowflake guildId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild ID to get preview for |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildPreview](./GuildPreview.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Edit method

Modify a guild's settings. Requires the MANAGE_GUILD permission. See [Modify Guild](https://discord.com/developers/docs/resources/guild#modify-guild)

```csharp
public IPromise<DiscordGuild> Edit(DiscordClient client, GuildUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Update to be applied to the guild |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildUpdate](./GuildUpdate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Delete method

Delete a guild permanently. User must be owner See [Delete Guild](https://discord.com/developers/docs/resources/guild#delete-guild)

```csharp
public IPromise Delete(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetChannels method

Returns a list of guild channel objects. Does not include threads See [Get Guild Channels](https://discord.com/developers/docs/resources/guild#get-guild-channels)

```csharp
public IPromise<List<DiscordChannel>> GetChannels(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordChannel](./DiscordChannel.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateChannel method

Create a new channel object for the guild. Requires the MANAGE_CHANNELS permission. See [Create Guild Channel](https://discord.com/developers/docs/resources/guild#create-guild-channel)

```csharp
public IPromise<DiscordChannel> CreateChannel(DiscordClient client, ChannelCreate channel)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| channel | Channel to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordChannel](./DiscordChannel.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [ChannelCreate](./ChannelCreate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditChannelPositions method

Modify the positions of a set of channel objects for the guild. Requires MANAGE_CHANNELS permission. Only channels to be modified are required, with the minimum being a swap between at least two channels. See [Modify Guild Channel Positions](https://discord.com/developers/docs/resources/guild#modify-guild-channel-positions)

```csharp
public IPromise<List<GuildChannelPosition>> EditChannelPositions(DiscordClient client, 
    List<GuildChannelPosition> positions)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| positions | List new channel positions for each channel |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildChannelPosition](./GuildChannelPosition.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ListActiveThreads method

Returns all active threads in the guild, including public and private threads. Threads are ordered by their id, in descending order. See [List Active Threads](https://discord.com/developers/docs/resources/guild#list-active-threads)

```csharp
public IPromise<ThreadList> ListActiveThreads(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [ThreadList](./ThreadList.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ListMembers method

Returns a list of guild member objects that are members of the guild. In the future, this endpoint will be restricted in line with our Privileged Intents

```csharp
public IPromise<List<GuildMember>> ListMembers(DiscordClient client, GuildListMembers list = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| list | Query string request for the list |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildListMembers](./GuildListMembers.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SearchMembers method

Searches for guild members by username or nickname

```csharp
public IPromise<List<GuildMember>> SearchMembers(DiscordClient client, GuildSearchMembers search)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| search | Username or nickname to match |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildSearchMembers](./GuildSearchMembers.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddMember method

Adds a user to the guild, provided you have a valid oauth2 access token for the user with the guilds.join scope. See [Add Guild Member](https://discord.com/developers/docs/resources/guild#add-guild-member)

```csharp
public IPromise<GuildMember> AddMember(DiscordClient client, Snowflake userId, 
    GuildMemberAdd member)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID of the user to add |
| member | Member to copy from |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [GuildMemberAdd](./GuildMemberAdd.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditMember method

Modify attributes of a guild member See [Modify Guild Member](https://discord.com/developers/docs/resources/guild#modify-guild-member)

```csharp
public IPromise<GuildMember> EditMember(DiscordClient client, Snowflake userId, 
    GuildMemberUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID of the user to update |
| update | Changes to make to the user |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [GuildMemberUpdate](./GuildMemberUpdate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditMemberNick method

Modify attributes of a guild member See [Modify Guild Member](https://discord.com/developers/docs/resources/guild#modify-guild-member)

```csharp
public IPromise<GuildMember> EditMemberNick(DiscordClient client, Snowflake userId, string nick)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID of the user to update |
| nick | Nickname for the user |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditCurrentMember method

Modifies the current members nickname in the guild See [Modify Current Member](https://discord.com/developers/docs/resources/guild#modify-current-member)

```csharp
public IPromise<GuildMember> EditCurrentMember(DiscordClient client, string nick)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| nick | New members nickname (1-32 characters) |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddMemberRole method (1 of 2)

Adds a role to a guild member. Requires the MANAGE_ROLES permission. See [Add Guild Member Role](https://discord.com/developers/docs/resources/guild#add-guild-member-role)

```csharp
public IPromise AddMemberRole(DiscordClient client, DiscordUser user, DiscordRole role)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| user | User to add role to |
| role | Role to add |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordUser](./DiscordUser.md)
* class [DiscordRole](./DiscordRole.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AddMemberRole method (2 of 2)

Adds a role to a guild member. Requires the MANAGE_ROLES permission. See [Add Guild Member Role](https://discord.com/developers/docs/resources/guild#add-guild-member-role)

```csharp
public IPromise AddMemberRole(DiscordClient client, Snowflake userId, Snowflake roleId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID to add role to |
| roleId | Role ID to add |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RemoveMemberRole method (1 of 2)

Removes a role from a guild member. Requires the MANAGE_ROLES permission. See [Remove Guild Member Role](https://discord.com/developers/docs/resources/guild#remove-guild-member-role)

```csharp
public IPromise RemoveMemberRole(DiscordClient client, DiscordUser user, DiscordRole role)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| user | User to remove role form |
| role | Role to remove |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordUser](./DiscordUser.md)
* class [DiscordRole](./DiscordRole.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# RemoveMemberRole method (2 of 2)

Removes a role from a guild member. Requires the MANAGE_ROLES permission. See [Remove Guild Member Role](https://discord.com/developers/docs/resources/guild#remove-guild-member-role)

```csharp
public IPromise RemoveMemberRole(DiscordClient client, Snowflake userId, Snowflake roleId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID to remove role form |
| roleId | Role ID to remove |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RemoveMember method (1 of 2)

Remove a member from a guild. Requires KICK_MEMBERS permission. See [Remove Guild Member](https://discord.com/developers/docs/resources/guild#remove-guild-member)

```csharp
public IPromise RemoveMember(DiscordClient client, GuildMember member)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| member | Guild Member to remove |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# RemoveMember method (2 of 2)

Remove a member from a guild. Requires KICK_MEMBERS permission. See [Remove Guild Member](https://discord.com/developers/docs/resources/guild#remove-guild-member)

```csharp
public IPromise RemoveMember(DiscordClient client, Snowflake userId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID of the user to remove |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetBans method

Returns a list of ban objects for the users banned from this guild. See [Get Guild Bans](https://discord.com/developers/docs/resources/guild#get-guild-bans)

```csharp
public IPromise<List<GuildBan>> GetBans(DiscordClient client, GuildBansRequest request = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| request | Request params for retrieving guild bans |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildBan](./GuildBan.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildBansRequest](./GuildBansRequest.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetBan method

Returns a guild ban for a specific user See [Get Guild Ban](https://discord.com/developers/docs/resources/guild#get-guild-ban) Returns 404 if not found

```csharp
public IPromise<GuildBan> GetBan(DiscordClient client, Snowflake userId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID to get guild ban for |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildBan](./GuildBan.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateBan method (1 of 2)

Create a guild ban, and optionally delete previous messages sent by the banned user. Requires the BAN_MEMBERS permission. See [Create Guild Ban](https://discord.com/developers/docs/resources/guild#create-guild-ban)

```csharp
public IPromise CreateBan(DiscordClient client, GuildMember member, GuildBanCreate ban)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| member | Guild Member to ban |
| ban | User ban information |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildMember](./GuildMember.md)
* class [GuildBanCreate](./GuildBanCreate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# CreateBan method (2 of 2)

Create a guild ban, and optionally delete previous messages sent by the banned user. Requires the BAN_MEMBERS permission. See [Create Guild Ban](https://discord.com/developers/docs/resources/guild#create-guild-ban)

```csharp
public IPromise CreateBan(DiscordClient client, Snowflake userId, GuildBanCreate ban)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID to ban |
| ban | User ban information |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [GuildBanCreate](./GuildBanCreate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RemoveBan method

Remove the ban for a user. Requires the BAN_MEMBERS permissions. See [Remove Guild Ban](https://discord.com/developers/docs/resources/guild#remove-guild-ban)

```csharp
public IPromise RemoveBan(DiscordClient client, Snowflake userId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID of the user to unban |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetRoles method

Returns a list of role objects for the guild. See [Get Guild Roles](https://discord.com/developers/docs/resources/guild#get-guild-roles)

```csharp
public IPromise<List<DiscordRole>> GetRoles(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordRole](./DiscordRole.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateRole method

Create a new role for the guild. Requires the MANAGE_ROLES permission. Returns the new role object on success. See [Create Guild Role](https://discord.com/developers/docs/resources/guild#create-guild-role)

```csharp
public IPromise<DiscordRole> CreateRole(DiscordClient client, DiscordRole role)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| role | New role to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordRole](./DiscordRole.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditRolePositions method

Modify the positions of a set of role objects for the guild. Requires the MANAGE_ROLES permission. Returns a list of all of the guild's role objects on success. See [Modify Guild Role Positions](https://discord.com/developers/docs/resources/guild#modify-guild-role-positions)

```csharp
public IPromise<List<DiscordRole>> EditRolePositions(DiscordClient client, 
    List<GuildRolePosition> positions)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| positions | List of role with updated positions |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordRole](./DiscordRole.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildRolePosition](./GuildRolePosition.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditRole method (1 of 2)

Modify a guild role. Requires the MANAGE_ROLES permission. Returns the updated role on success. See [Modify Guild Role](https://discord.com/developers/docs/resources/guild#modify-guild-role)

```csharp
public IPromise<DiscordRole> EditRole(DiscordClient client, DiscordRole role)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| role | Role to update |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordRole](./DiscordRole.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# EditRole method (2 of 2)

Modify a guild role. Requires the MANAGE_ROLES permission. Returns the updated role on success. See [Modify Guild Role](https://discord.com/developers/docs/resources/guild#modify-guild-role)

```csharp
public IPromise<DiscordRole> EditRole(DiscordClient client, Snowflake roleId, DiscordRole role)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| roleId | Role ID to update |
| role | Role to update |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordRole](./DiscordRole.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditMfaLevel method

Modify a guild's MFA level. Requires guild ownership. See [Modify Guild MFA Level](https://discord.com/developers/docs/resources/guild#modify-guild-mfa-level)

```csharp
public IPromise EditMfaLevel(DiscordClient client, GuildUpdateMfaLevel level)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| level | [`GuildUpdateMfaLevel`](./GuildUpdateMfaLevel.md) to set |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildUpdateMfaLevel](./GuildUpdateMfaLevel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteRole method (1 of 2)

Delete a guild role. Requires the MANAGE_ROLES permission See [Delete Guild Role](https://discord.com/developers/docs/resources/guild#delete-guild-role)

```csharp
public IPromise DeleteRole(DiscordClient client, DiscordRole role)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| role | Role to Delete |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordRole](./DiscordRole.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DeleteRole method (2 of 2)

Delete a guild role. Requires the MANAGE_ROLES permission See [Delete Guild Role](https://discord.com/developers/docs/resources/guild#delete-guild-role)

```csharp
public IPromise DeleteRole(DiscordClient client, Snowflake roleId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| roleId | Role ID to Delete |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetPruneCount method

Returns an object with one 'pruned' key indicating the number of members that would be removed in a prune operation. Requires the KICK_MEMBERS permission. See [Get Guild Prune Count](https://discord.com/developers/docs/resources/guild#get-guild-prune-count)

```csharp
public IPromise<GuildPruneResult> GetPruneCount(DiscordClient client, GuildPruneGet prune)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| prune | Prune get request |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildPruneResult](./GuildPruneResult.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildPruneGet](./GuildPruneGet.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BeginPrune method

Begin a prune operation. Requires the KICK_MEMBERS permission. See [Begin Guild Prune](https://discord.com/developers/docs/resources/guild#begin-guild-prune)

```csharp
public IPromise<GuildPruneResult> BeginPrune(DiscordClient client, GuildPruneBegin prune)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| prune | Prune begin request |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildPruneResult](./GuildPruneResult.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildPruneBegin](./GuildPruneBegin.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetVoiceRegions method

Returns a list of voice region objects for the guild. Unlike the similar /voice route, this returns VIP servers when the guild is VIP-enabled. See [Get Guild Voice Regions](https://discord.com/developers/docs/resources/guild#get-guild-voice-regions)

```csharp
public IPromise<List<VoiceRegion>> GetVoiceRegions(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [VoiceRegion](./VoiceRegion.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetInvites method

Returns a list of invite objects (with invite metadata) for the guild. Requires the MANAGE_GUILD permission. See [Get Guild Invites](https://discord.com/developers/docs/resources/guild#get-guild-invites)

```csharp
public IPromise<List<InviteMetadata>> GetInvites(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [InviteMetadata](./InviteMetadata.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetIntegrations method

Returns a list of integration objects for the guild. Requires the MANAGE_GUILD permission. See [Get Guild Integrations](https://discord.com/developers/docs/resources/guild#get-guild-integrations)

```csharp
public IPromise<List<Integration>> GetIntegrations(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [Integration](./Integration.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteIntegration method (1 of 2)

Delete the attached integration object for the guild. Deletes any associated webhooks and kicks the associated bot if there is one. Requires the MANAGE_GUILD permission. See [Delete Guild Integration](https://discord.com/developers/docs/resources/guild#delete-guild-integration)

```csharp
public IPromise DeleteIntegration(DiscordClient client, Integration integration)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| integration | Integration to delete |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [Integration](./Integration.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DeleteIntegration method (2 of 2)

Delete the attached integration object for the guild. Deletes any associated webhooks and kicks the associated bot if there is one. Requires the MANAGE_GUILD permission. See [Delete Guild Integration](https://discord.com/developers/docs/resources/guild#delete-guild-integration)

```csharp
public IPromise DeleteIntegration(DiscordClient client, Snowflake integrationId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| integrationId | Integration ID to delete |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetWidgetSettings method

Returns a guild widget object. Requires the MANAGE_GUILD permission. See [Get Guild Widget Settings](https://discord.com/developers/docs/resources/guild#get-guild-widget-settings)

```csharp
public IPromise<GuildWidgetSettings> GetWidgetSettings(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildWidgetSettings](./GuildWidgetSettings.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditWidget method

Modify a guild widget object for the guild. Requires the MANAGE_GUILD permission. See [Modify Guild Widget](https://discord.com/developers/docs/resources/guild#modify-guild-widget)

```csharp
public IPromise<GuildWidget> EditWidget(DiscordClient client, GuildWidget widget)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| widget | Updated widget |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildWidget](./GuildWidget.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetWidget method

Returns the widget for the guild. See [Get Guild Widget](https://discord.com/developers/docs/resources/guild#get-guild-widget)

```csharp
public IPromise<GuildWidget> GetWidget(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildWidget](./GuildWidget.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetWelcomeScreen method

Returns the Welcome Screen object for the guild. Requires the `MANAGE_GUILD` permission.

```csharp
public IPromise<GuildWelcomeScreen> GetWelcomeScreen(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildWelcomeScreen](./GuildWelcomeScreen.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditWelcomeScreen method

Modify the guild's Welcome Screen. Requires the MANAGE_GUILD permission. Returns the updated Welcome Screen object.

```csharp
public IPromise<GuildWelcomeScreen> EditWelcomeScreen(DiscordClient client, 
    WelcomeScreenUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Update to be made to the welcome screen |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildWelcomeScreen](./GuildWelcomeScreen.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [WelcomeScreenUpdate](./WelcomeScreenUpdate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetVanityUrl method

Returns a partial invite object for guilds with that feature enabled. Requires the MANAGE_GUILD permission. Code will be null if a vanity url for the guild is not set.

```csharp
public IPromise<InviteMetadata> GetVanityUrl(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [InviteMetadata](./InviteMetadata.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ListEmojis method

Returns a list of emoji objects for the given guild. See [List Guild Emojis](https://discord.com/developers/docs/resources/emoji#list-guild-emojis)

```csharp
public IPromise<List<DiscordEmoji>> ListEmojis(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordEmoji](./DiscordEmoji.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateEmoji method

Create a new emoji for the guild. Requires the MANAGE_EMOJIS permission. Returns the new emoji object on success. See [Create Guild Emoji](https://discord.com/developers/docs/resources/emoji#create-guild-emoji)

```csharp
public IPromise<DiscordEmoji> CreateEmoji(DiscordClient client, EmojiCreate emoji)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| emoji | Emoji to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordEmoji](./DiscordEmoji.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [EmojiCreate](./EmojiCreate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditEmoji method

Modify the given emoji. Requires the MANAGE_EMOJIS permission. Returns the updated emoji object on success. See [Modify Guild Emoji](https://discord.com/developers/docs/resources/emoji#modify-guild-emoji)

```csharp
public IPromise<DiscordEmoji> EditEmoji(DiscordClient client, Snowflake emojiId, EmojiUpdate emoji)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| emojiId | Emoji ID to update |
| emoji | Emoji update |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordEmoji](./DiscordEmoji.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [EmojiUpdate](./EmojiUpdate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteEmoji method

Delete the given emoji. Requires the MANAGE_EMOJIS permission. See [Delete Guild Emoji](https://discord.com/developers/docs/resources/emoji#delete-guild-emoji)

```csharp
public IPromise DeleteEmoji(DiscordClient client, Snowflake emojiId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| emojiId | Emoji ID to delete |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditCurrentUserVoiceState method

Modifies the current user's voice state. See [Update Current User Voice State](https://discord.com/developers/docs/resources/guild#modify-current-user-voice-state)

```csharp
public IPromise EditCurrentUserVoiceState(DiscordClient client, 
    GuildCurrentUserVoiceStateUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Update to the guild voice state |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildCurrentUserVoiceStateUpdate](./GuildCurrentUserVoiceStateUpdate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditUserVoiceState method

Modifies another user's voice state. See [Update Users Voice State](https://discord.com/developers/docs/resources/guild#modify-user-voice-state)

```csharp
public IPromise EditUserVoiceState(DiscordClient client, Snowflake userId, 
    GuildUserVoiceStateUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User to modify |
| update | Update to the guild voice state |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [GuildUserVoiceStateUpdate](./GuildUserVoiceStateUpdate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ListStickers method

Returns an array of sticker objects for the given guild. Includes user fields if the bot has the MANAGE_EMOJIS_AND_STICKERS permission. See [List Guild Stickers](https://discord.com/developers/docs/resources/sticker#list-guild-stickers)

```csharp
public IPromise<List<DiscordSticker>> ListStickers(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordSticker](./DiscordSticker.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetSticker method

Returns a sticker object for the given guild and sticker IDs. Includes the user field if the bot has the MANAGE_EMOJIS_AND_STICKERS permission. See [Get Guild Sticker](https://discord.com/developers/docs/resources/sticker#get-guild-sticker)

```csharp
public IPromise<DiscordSticker> GetSticker(DiscordClient client, Snowflake stickerId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| stickerId | ID of the sticker to get |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordSticker](./DiscordSticker.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateSticker method

Create a new sticker for the guild. Requires the MANAGE_EMOJIS_AND_STICKERS permission. Returns the new sticker object on success. See [Create Guild Sticker](https://discord.com/developers/docs/resources/sticker#create-guild-sticker)

```csharp
public IPromise<DiscordSticker> CreateSticker(DiscordClient client, GuildStickerCreate sticker)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| sticker | Sticker to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordSticker](./DiscordSticker.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildStickerCreate](./GuildStickerCreate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditSticker method

Modify the given sticker. Requires the MANAGE_EMOJIS_AND_STICKERS permission. Returns the updated sticker object on success. See [Modify Guild Sticker](https://discord.com/developers/docs/resources/sticker#modify-guild-sticker)

```csharp
public IPromise<DiscordSticker> EditSticker(DiscordClient client, DiscordSticker sticker)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| sticker | Sticker to modify |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordSticker](./DiscordSticker.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteSticker method

Delete the given sticker. Requires the MANAGE_EMOJIS_AND_STICKERS permission.

```csharp
public IPromise DeleteSticker(DiscordClient client, Snowflake stickerId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| stickerId | ID of the sticker to delete |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ListAutoModRules method

```csharp
public IPromise<List<AutoModRule>> ListAutoModRules(DiscordClient client)
```

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [AutoModRule](./AutoModRule.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetAutoModRule method

```csharp
public IPromise<AutoModRule> GetAutoModRule(DiscordClient client, Snowflake ruleId)
```

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [AutoModRule](./AutoModRule.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateAutoModRule method

```csharp
public IPromise<AutoModRule> CreateAutoModRule(DiscordClient client, AutoModRuleCreate create)
```

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [AutoModRule](./AutoModRule.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [AutoModRuleCreate](./AutoModRuleCreate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetOnboarding method

Returns the [`GuildOnboarding`](./GuildOnboarding.md) for the guild.

```csharp
public IPromise<GuildOnboarding> GetOnboarding(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildOnboarding](./GuildOnboarding.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditOnboarding method

Modifies the onboarding configuration of the guild.

```csharp
public IPromise<GuildOnboarding> EditOnboarding(DiscordClient client, GuildOnboardingUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Update for the guild onboarding |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildOnboarding](./GuildOnboarding.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GuildOnboardingUpdate](./GuildOnboardingUpdate.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordGuild constructor

The default constructor.

```csharp
public DiscordGuild()
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

Guild id

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

Name of the guild (2-100 characters)

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Icon property

Base64 128x128 image for the guild icon

```csharp
public string Icon { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IconHash property

Icon hash

```csharp
public string IconHash { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Splash property

Splash hash

```csharp
public string Splash { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscoverySplash property

Discovery splash hash Only present for guilds with the "DISCOVERABLE" feature

```csharp
public string DiscoverySplash { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Owner property

True if the user is the owner of the guild

```csharp
public bool? Owner { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OwnerId property

ID of owner

```csharp
public Snowflake OwnerId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Permissions property

Total permissions for the user in the guild (excludes overrides)

```csharp
public string Permissions { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AfkChannelId property

ID of afk channel

```csharp
public Snowflake? AfkChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AfkTimeout property

Afk timeout in seconds

```csharp
public int? AfkTimeout { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# WidgetEnabled property

True if the server widget is enabled

```csharp
public bool? WidgetEnabled { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# WidgetChannelId property

The channel id that the widget will generate an invite to, or null if set to no invite

```csharp
public Snowflake? WidgetChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# VerificationLevel property

Verification level

```csharp
public GuildVerificationLevel? VerificationLevel { get; set; }
```

## See Also

* enum [GuildVerificationLevel](./GuildVerificationLevel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DefaultMessageNotifications property

Default message notification level

```csharp
public DefaultNotificationLevel? DefaultMessageNotifications { get; set; }
```

## See Also

* enum [DefaultNotificationLevel](./DefaultNotificationLevel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ExplicitContentFilter property

Explicit content filter level

```csharp
public ExplicitContentFilterLevel? ExplicitContentFilter { get; set; }
```

## See Also

* enum [ExplicitContentFilterLevel](./ExplicitContentFilterLevel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Roles property

Roles in the guild

```csharp
public Hash<Snowflake, DiscordRole> Roles { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordRole](./DiscordRole.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Emojis property

Custom guild emojis

```csharp
public Hash<Snowflake, DiscordEmoji> Emojis { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordEmoji](./DiscordEmoji.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Features property

Enabled guild features See [`GuildFeatures`](./GuildFeatures.md)

```csharp
public List<GuildFeatures> Features { get; set; }
```

## See Also

* enum [GuildFeatures](./GuildFeatures.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MfaLevel property

Required MFA level for the guild See [`GuildMfaLevel`](./GuildMfaLevel.md)

```csharp
public GuildMfaLevel? MfaLevel { get; set; }
```

## See Also

* enum [GuildMfaLevel](./GuildMfaLevel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApplicationId property

Application id of the guild creator if it is bot-created

```csharp
public Snowflake? ApplicationId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SystemChannelId property

The id of the channel where guild notices such as welcome messages and boost events are posted

```csharp
public Snowflake? SystemChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SystemChannelFlags property

System channel flags See [`SystemChannelFlags`](./SystemChannelFlags.md)

```csharp
public SystemChannelFlags SystemChannelFlags { get; set; }
```

## See Also

* enum [SystemChannelFlags](./SystemChannelFlags.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RulesChannelId property

The id of the channel where Community guilds can display rules and/or guidelines

```csharp
public Snowflake? RulesChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# JoinedAt property

When this guild was joined at

```csharp
public DateTime? JoinedAt { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Large property

True if this is considered a large guild

```csharp
public bool? Large { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Unavailable property

True if this guild is unavailable due to an outage

```csharp
public bool? Unavailable { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MemberCount property

Total number of members in this guild

```csharp
public int? MemberCount { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# VoiceStates property

States of members currently in voice channels; lacks the guild_id key

```csharp
public Hash<Snowflake, VoiceState> VoiceStates { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [VoiceState](./VoiceState.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Members property

Users in the guild

```csharp
public Hash<Snowflake, GuildMember> Members { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Channels property

Channels in the guild

```csharp
public Hash<Snowflake, DiscordChannel> Channels { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Threads property

All active threads in the guild that current user has permission to view

```csharp
public Hash<Snowflake, DiscordChannel> Threads { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Presences property

Presences of the members in the guild will only include non-offline members if the size is greater than large threshold

```csharp
public List<PresenceUpdatedEvent> Presences { get; set; }
```

## See Also

* class [PresenceUpdatedEvent](./PresenceUpdatedEvent.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MaxPresences property

The maximum number of presences for the guild (the default value, currently 25000, is in effect when null is returned)

```csharp
public int? MaxPresences { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MaxMembers property

The maximum number of members for the guild

```csharp
public int? MaxMembers { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# VanityUrlCode property

The vanity url code for the guild

```csharp
public string VanityUrlCode { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description property

The description of a guild

```csharp
public string Description { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Banner property

Banner hash

```csharp
public string Banner { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PremiumTier property

Premium tier (Server Boost level)

```csharp
public GuildPremiumTier? PremiumTier { get; set; }
```

## See Also

* enum [GuildPremiumTier](./GuildPremiumTier.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PremiumSubscriptionCount property

The number of boosts this guild currently has

```csharp
public int? PremiumSubscriptionCount { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PreferredLocale property

The preferred locale of a Community guild Used in server discovery and notices from Discord Defaults to "en-US"

```csharp
public string PreferredLocale { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PublicUpdatesChannelId property

The maximum amount of users in a video channel

```csharp
public Snowflake? PublicUpdatesChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MaxStageVideoChannelUsers property

The maximum amount of users in a stage video channel

```csharp
public int? MaxStageVideoChannelUsers { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MaxVideoChannelUsers property

The maximum amount of users in a video channel

```csharp
public int? MaxVideoChannelUsers { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApproximateMemberCount property

Approximate number of members in this guild

```csharp
public int? ApproximateMemberCount { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApproximatePresenceCount property

Approximate number of non-offline members in this guild

```csharp
public int? ApproximatePresenceCount { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# WelcomeScreen property

The welcome screen of a Community guild Shown to new members, returned in an Invite's guild object

```csharp
public GuildWelcomeScreen WelcomeScreen { get; set; }
```

## See Also

* class [GuildWelcomeScreen](./GuildWelcomeScreen.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# NsfwLevel property

Guild NSFW level [NSFW Information](https://support.discord.com/hc/en-us/articles/1500005389362-NSFW-Server-Designation)

```csharp
public GuildNsfwLevel NsfwLevel { get; set; }
```

## See Also

* enum [GuildNsfwLevel](./GuildNsfwLevel.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# StageInstances property

Stage instances in the guild [`StageInstance`](./StageInstance.md)

```csharp
public Hash<Snowflake, StageInstance> StageInstances { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [StageInstance](./StageInstance.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Stickers property

Custom guild stickers [`DiscordSticker`](./DiscordSticker.md)

```csharp
public Hash<Snowflake, DiscordSticker> Stickers { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordSticker](./DiscordSticker.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ScheduledEvents property

The scheduled events in the guild [`DiscordSticker`](./DiscordSticker.md)

```csharp
public Hash<Snowflake, GuildScheduledEvent> ScheduledEvents { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PremiumProgressBarEnabled property

The scheduled events in the guild

```csharp
public bool PremiumProgressBarEnabled { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SafetyAlertsChannelId property

The ID of the channel where admins and moderators of Community guilds receive safety alerts from Discord

```csharp
public Snowflake? SafetyAlertsChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# HasLoadedAllMembers property

Returns true if all guild members have been loaded

```csharp
public bool HasLoadedAllMembers { get; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LeftMembers property

Members who have left the guild This list will contain members who have left the guild since the initial bot connection

```csharp
public Hash<Snowflake, GuildMember> LeftMembers { get; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildMember](./GuildMember.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsAvailable property

Returns if the guild is available to use

```csharp
public bool IsAvailable { get; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IconUrl property

Returns the guild Icon Url

```csharp
public string IconUrl { get; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SplashUrl property

Returns the Guilds Splash Url

```csharp
public string SplashUrl { get; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscoverySplashUrl property

Returns the guilds Discovery Splash

```csharp
public string DiscoverySplashUrl { get; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BannerUrl property

Return the guilds Banner Url

```csharp
public string BannerUrl { get; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EveryoneRole property

Returns the everyone role for the guild.

```csharp
public DiscordRole EveryoneRole { get; }
```

## See Also

* class [DiscordRole](./DiscordRole.md)
* class [DiscordGuild](./DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
