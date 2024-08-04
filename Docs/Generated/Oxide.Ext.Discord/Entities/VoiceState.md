# VoiceState class

Represents [Voice State Structure](https://discord.com/developers/docs/resources/voice#voice-state-object)

```csharp
public class VoiceState : ISnowflakeEntity
```

## Public Members

| name | description |
| --- | --- |
| [VoiceState](#voicestate-constructor)() | The default constructor. |
| [ChannelId](#channelid-property) { get; set; } | The channel id this user is connected to |
| [Deaf](#deaf-property) { get; set; } | Whether this user is deafened by the server |
| [GuildId](#guildid-property) { get; set; } | The guild id this voice state is for |
| [Id](#id-property) { get; } | User ID for the voice state |
| [Member](#member-property) { get; set; } | The guild member this voice state is for |
| [Mute](#mute-property) { get; set; } | Whether this user is muted by the server |
| [RequestToSpeakTimestamp](#requesttospeaktimestamp-property) { get; set; } | Whether this user is muted by the current user |
| [SelfDeaf](#selfdeaf-property) { get; set; } | Whether this user is locally deafened |
| [SelfMute](#selfmute-property) { get; set; } | Whether this user is locally muted |
| [SelfStream](#selfstream-property) { get; set; } | Whether this user is streaming using "Go Live" |
| [SelfVideo](#selfvideo-property) { get; set; } | Whether this user's camera is enabled |
| [SessionId](#sessionid-property) { get; set; } | The session id for this voice state |
| [Suppress](#suppress-property) { get; set; } | whether this user's permission to speak is denied |
| [UserId](#userid-property) { get; set; } | The user id this voice state is for |

## See Also

* interface [ISnowflakeEntity](../Interfaces/ISnowflakeEntity.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [VoiceState.cs](../../../../Oxide.Ext.Discord/Entities/VoiceState.cs)
   
   
# VoiceState constructor

The default constructor.

```csharp
public VoiceState()
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

User ID for the voice state

```csharp
public Snowflake Id { get; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildId property

The guild id this voice state is for

```csharp
public Snowflake? GuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ChannelId property

The channel id this user is connected to

```csharp
public Snowflake? ChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UserId property

The user id this voice state is for

```csharp
public Snowflake UserId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Member property

The guild member this voice state is for

```csharp
public GuildMember Member { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SessionId property

The session id for this voice state

```csharp
public string SessionId { get; set; }
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Deaf property

Whether this user is deafened by the server

```csharp
public bool Deaf { get; set; }
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Mute property

Whether this user is muted by the server

```csharp
public bool Mute { get; set; }
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SelfDeaf property

Whether this user is locally deafened

```csharp
public bool SelfDeaf { get; set; }
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SelfMute property

Whether this user is locally muted

```csharp
public bool SelfMute { get; set; }
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SelfStream property

Whether this user is streaming using "Go Live"

```csharp
public bool? SelfStream { get; set; }
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SelfVideo property

Whether this user's camera is enabled

```csharp
public bool SelfVideo { get; set; }
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Suppress property

whether this user's permission to speak is denied

```csharp
public bool Suppress { get; set; }
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RequestToSpeakTimestamp property

Whether this user is muted by the current user

```csharp
public DateTime? RequestToSpeakTimestamp { get; set; }
```

## See Also

* class [VoiceState](./VoiceState.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
