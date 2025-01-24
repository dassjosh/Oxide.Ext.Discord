# DiscordSoundboardSound class

Represents [Soundboard](https://discord.com/developers/docs/resources/soundboard#soundboard-sound-object) in Discord

```csharp
public class DiscordSoundboardSound : ISnowflakeEntity
```

## Public Members

| name | description |
| --- | --- |
| [DiscordSoundboardSound](#discordsoundboardsound-constructor)() | The default constructor. |
| [Available](#available-property) { get; set; } | Whether this sound can be used, may be false due to loss of Server Boosts |
| [EmojiId](#emojiid-property) { get; set; } | ID of this sound's custom emoji |
| [EmojiName](#emojiname-property) { get; set; } | Unicode character of this sound's standard emoji |
| [GuildId](#guildid-property) { get; set; } | ID of the guild this sound is in |
| [Id](#id-property) { get; } | ID of the sound |
| [Name](#name-property) { get; set; } | Name of this sound |
| [SoundId](#soundid-property) { get; set; } | ID of this sound |
| [User](#user-property) { get; set; } | User who created this sound |
| [Volume](#volume-property) { get; set; } | Volume of this sound, from 0 to 1 |
| [Delete](#delete-method)(…) | Returns a list of soundboard sound objects that can be used by all users. See [List Default Soundboard Sounds](https://discord.com/developers/docs/resources/soundboard#list-default-soundboard-sounds) |
| [Edit](#edit-method)(…) | Returns a list of soundboard sound objects that can be used by all users. See [List Default Soundboard Sounds](https://discord.com/developers/docs/resources/soundboard#list-default-soundboard-sounds) |
| static [GetDefaultSounds](#getdefaultsounds-method)(…) | Returns a list of soundboard sound objects that can be used by all users. See [List Default Soundboard Sounds](https://discord.com/developers/docs/resources/soundboard#list-default-soundboard-sounds) |

## See Also

* interface [ISnowflakeEntity](../Interfaces/ISnowflakeEntity.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordSoundboardSound.cs](../../../../Oxide.Ext.Discord/Entities/DiscordSoundboardSound.cs)
   
   
# GetDefaultSounds method

Returns a list of soundboard sound objects that can be used by all users. See [List Default Soundboard Sounds](https://discord.com/developers/docs/resources/soundboard#list-default-soundboard-sounds)

```csharp
public static IPromise<List<DiscordSoundboardSound>> GetDefaultSounds(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Edit method

Returns a list of soundboard sound objects that can be used by all users. See [List Default Soundboard Sounds](https://discord.com/developers/docs/resources/soundboard#list-default-soundboard-sounds)

```csharp
public IPromise<DiscordSoundboardSound> Edit(DiscordClient client, SoundboardSoundUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Update to apply |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [SoundboardSoundUpdate](./SoundboardSoundUpdate.md)
* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Delete method

Returns a list of soundboard sound objects that can be used by all users. See [List Default Soundboard Sounds](https://discord.com/developers/docs/resources/soundboard#list-default-soundboard-sounds)

```csharp
public IPromise Delete(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordSoundboardSound constructor

The default constructor.

```csharp
public DiscordSoundboardSound()
```

## See Also

* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

ID of the sound

```csharp
public Snowflake Id { get; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

Name of this sound

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SoundId property

ID of this sound

```csharp
public Snowflake SoundId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Volume property

Volume of this sound, from 0 to 1

```csharp
public double Volume { get; set; }
```

## See Also

* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EmojiId property

ID of this sound's custom emoji

```csharp
public Snowflake? EmojiId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EmojiName property

Unicode character of this sound's standard emoji

```csharp
public string EmojiName { get; set; }
```

## See Also

* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildId property

ID of the guild this sound is in

```csharp
public Snowflake GuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Available property

Whether this sound can be used, may be false due to loss of Server Boosts

```csharp
public bool Available { get; set; }
```

## See Also

* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# User property

User who created this sound

```csharp
public DiscordUser User { get; set; }
```

## See Also

* class [DiscordUser](./DiscordUser.md)
* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
