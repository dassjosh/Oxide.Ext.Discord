# SendSoundboardSound class

Represents [Send Soundboard Sound Request](https://discord.com/developers/docs/resources/soundboard#send-soundboard-sound-json-params) in Discord

```csharp
public class SendSoundboardSound
```

## Public Members

| name | description |
| --- | --- |
| [SendSoundboardSound](#sendsoundboardsound-constructor)() | Constructor |
| [SendSoundboardSound](#sendsoundboardsound-constructor)(…) | Constructor |
| [SoundId](#soundid-property) { get; set; } | Id of the soundboard sound to play |
| [SourceGuildId](#sourceguildid-property) { get; set; } | Id of the guild the soundboard sound is from, required to play sounds from different servers |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [SendSoundboardSound.cs](../../../../Oxide.Ext.Discord/Entities/SendSoundboardSound.cs)
   
   
# SendSoundboardSound constructor (1 of 2)

Constructor

```csharp
public SendSoundboardSound()
```

## See Also

* class [SendSoundboardSound](./SendSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# SendSoundboardSound constructor (2 of 2)

Constructor

```csharp
public SendSoundboardSound(DiscordSoundboardSound sound)
```

| parameter | description |
| --- | --- |
| sound | Sound to send |

## See Also

* class [DiscordSoundboardSound](./DiscordSoundboardSound.md)
* class [SendSoundboardSound](./SendSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SoundId property

Id of the soundboard sound to play

```csharp
public Snowflake SoundId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [SendSoundboardSound](./SendSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SourceGuildId property

Id of the guild the soundboard sound is from, required to play sounds from different servers

```csharp
public Snowflake? SourceGuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [SendSoundboardSound](./SendSoundboardSound.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
