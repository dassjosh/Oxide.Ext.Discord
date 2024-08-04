# GuildChannelUpdate class

Represents a [Guild Channel Update Structure](https://discord.com/developers/docs/resources/channel#modify-channel-json-params-guild-channel)

```csharp
public class GuildChannelUpdate
```

## Public Members

| name | description |
| --- | --- |
| [GuildChannelUpdate](#guildchannelupdate-constructor)() | The default constructor. |
| [AvailableTags](#availabletags-property) { get; set; } | The set of tags that can be used in a GUILD_FORUM or GUILD_MEDIA channel |
| [Bitrate](#bitrate-property) { get; set; } | The bitrate (in bits) of the voice channel 8000 to 96000 (128000 for VIP servers) |
| [DefaultAutoArchiveDuration](#defaultautoarchiveduration-property) { get; set; } | The default duration for newly created threads in the channel, in minutes, to automatically archive the thread after recent activity |
| [DefaultReactionEmoji](#defaultreactionemoji-property) { get; set; } | The emoji to show in the add reaction button on a thread in a GUILD_FORUM or GUILD_MEDIA channel |
| [DefaultThreadRateLimitPerUser](#defaultthreadratelimitperuser-property) { get; set; } | The initial rate_limit_per_user to set on newly created threads in a channel. this field is copied to the thread at creation time and does not live update. |
| [Name](#name-property) { get; set; } | The name of the channel (1-100 characters) |
| [Nsfw](#nsfw-property) { get; set; } | Whether the channel is nsfw |
| [ParentId](#parentid-property) { get; set; } | ID of the parent category for a channel (each parent category can contain up to 50 channels) |
| [PermissionOverwrites](#permissionoverwrites-property) { get; set; } | Explicit permission overwrites for members and roles [`Overwrite`](./Overwrite.md) |
| [Position](#position-property) { get; set; } | The position of the channel in the left-hand listing |
| [RateLimitPerUser](#ratelimitperuser-property) { get; set; } | Amount of seconds a user has to wait before sending another message (0-21600); bots, as well as users with the permission manage_messages or manage_channel, are unaffected |
| [RtcRegion](#rtcregion-property) { get; set; } | Channel voice region id, automatic when set to null |
| [Topic](#topic-property) { get; set; } | The channel topic (0-1024 characters) |
| [Type](#type-property) { get; set; } | the type of channel See [`ChannelType`](./ChannelType.md) |
| [UserLimit](#userlimit-property) { get; set; } | The user limit of the voice channel |
| [VideoQualityMode](#videoqualitymode-property) { get; set; } | The camera video quality mode of the voice channel |
| [Validate](#validate-method)() |  |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [GuildChannelUpdate.cs](../../../../Oxide.Ext.Discord/Entities/GuildChannelUpdate.cs)
   
   
# Validate method

```csharp
public void Validate()
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildChannelUpdate constructor

The default constructor.

```csharp
public GuildChannelUpdate()
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

The name of the channel (1-100 characters)

```csharp
public string Name { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Type property

the type of channel See [`ChannelType`](./ChannelType.md)

```csharp
public ChannelType Type { get; set; }
```

## See Also

* enum [ChannelType](./ChannelType.md)
* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Position property

The position of the channel in the left-hand listing

```csharp
public int? Position { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Topic property

The channel topic (0-1024 characters)

```csharp
public string Topic { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Nsfw property

Whether the channel is nsfw

```csharp
public bool? Nsfw { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RateLimitPerUser property

Amount of seconds a user has to wait before sending another message (0-21600); bots, as well as users with the permission manage_messages or manage_channel, are unaffected

```csharp
public int? RateLimitPerUser { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Bitrate property

The bitrate (in bits) of the voice channel 8000 to 96000 (128000 for VIP servers)

```csharp
public int? Bitrate { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UserLimit property

The user limit of the voice channel

```csharp
public int? UserLimit { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PermissionOverwrites property

Explicit permission overwrites for members and roles [`Overwrite`](./Overwrite.md)

```csharp
public List<Overwrite> PermissionOverwrites { get; set; }
```

## See Also

* class [Overwrite](./Overwrite.md)
* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ParentId property

ID of the parent category for a channel (each parent category can contain up to 50 channels)

```csharp
public Snowflake? ParentId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RtcRegion property

Channel voice region id, automatic when set to null

```csharp
public string RtcRegion { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# VideoQualityMode property

The camera video quality mode of the voice channel

```csharp
public VideoQualityMode? VideoQualityMode { get; set; }
```

## See Also

* enum [VideoQualityMode](./VideoQualityMode.md)
* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DefaultAutoArchiveDuration property

The default duration for newly created threads in the channel, in minutes, to automatically archive the thread after recent activity

```csharp
public int? DefaultAutoArchiveDuration { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AvailableTags property

The set of tags that can be used in a GUILD_FORUM or GUILD_MEDIA channel

```csharp
public List<ForumTag> AvailableTags { get; set; }
```

## See Also

* class [ForumTag](./ForumTag.md)
* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DefaultReactionEmoji property

The emoji to show in the add reaction button on a thread in a GUILD_FORUM or GUILD_MEDIA channel

```csharp
public DefaultReaction DefaultReactionEmoji { get; set; }
```

## See Also

* class [DefaultReaction](./DefaultReaction.md)
* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DefaultThreadRateLimitPerUser property

The initial rate_limit_per_user to set on newly created threads in a channel. this field is copied to the thread at creation time and does not live update.

```csharp
public int? DefaultThreadRateLimitPerUser { get; set; }
```

## See Also

* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
