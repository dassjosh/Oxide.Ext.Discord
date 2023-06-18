# GuildChannelUpdate class

Represents a [Guild Channel Update Structure](https://discord.com/developers/docs/resources/channel#modify-channel-json-params-guild-channel)

```csharp
public class GuildChannelUpdate
```

## Public Members

| name | description |
| --- | --- |
| [GuildChannelUpdate](GuildChannelUpdate/GuildChannelUpdate.md)() | The default constructor. |
| [AvailableTags](GuildChannelUpdate/AvailableTags.md) { get; set; } | The set of tags that can be used in a GUILD_FORUM channel |
| [Bitrate](GuildChannelUpdate/Bitrate.md) { get; set; } | The bitrate (in bits) of the voice channel 8000 to 96000 (128000 for VIP servers) |
| [DefaultAutoArchiveDuration](GuildChannelUpdate/DefaultAutoArchiveDuration.md) { get; set; } | The default duration for newly created threads in the channel, in minutes, to automatically archive the thread after recent activity |
| [DefaultReactionEmoji](GuildChannelUpdate/DefaultReactionEmoji.md) { get; set; } | The emoji to show in the add reaction button on a thread in a GUILD_FORUM channel |
| [DefaultThreadRateLimitPerUser](GuildChannelUpdate/DefaultThreadRateLimitPerUser.md) { get; set; } | The initial rate_limit_per_user to set on newly created threads in a channel. this field is copied to the thread at creation time and does not live update. |
| [Name](GuildChannelUpdate/Name.md) { get; set; } | The name of the channel (1-100 characters) |
| [Nsfw](GuildChannelUpdate/Nsfw.md) { get; set; } | Whether the channel is nsfw |
| [ParentId](GuildChannelUpdate/ParentId.md) { get; set; } | ID of the parent category for a channel (each parent category can contain up to 50 channels) |
| [PermissionOverwrites](GuildChannelUpdate/PermissionOverwrites.md) { get; set; } | Explicit permission overwrites for members and roles [`Overwrite`](./Overwrite.md) |
| [Position](GuildChannelUpdate/Position.md) { get; set; } | The position of the channel in the left-hand listing |
| [RateLimitPerUser](GuildChannelUpdate/RateLimitPerUser.md) { get; set; } | Amount of seconds a user has to wait before sending another message (0-21600); bots, as well as users with the permission manage_messages or manage_channel, are unaffected |
| [RtcRegion](GuildChannelUpdate/RtcRegion.md) { get; set; } | Channel voice region id, automatic when set to null |
| [Topic](GuildChannelUpdate/Topic.md) { get; set; } | The channel topic (0-1024 characters) |
| [Type](GuildChannelUpdate/Type.md) { get; set; } | the type of channel See [`ChannelType`](./ChannelType.md) |
| [UserLimit](GuildChannelUpdate/UserLimit.md) { get; set; } | The user limit of the voice channel |
| [VideoQualityMode](GuildChannelUpdate/VideoQualityMode.md) { get; set; } | The camera video quality mode of the voice channel |
| [Validate](GuildChannelUpdate/Validate.md)() |  |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [GuildChannelUpdate.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Channels/GuildChannelUpdate.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->