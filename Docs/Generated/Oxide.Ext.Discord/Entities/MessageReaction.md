# MessageReaction class

Represents a [Reaction Structure](https://discord.com/developers/docs/resources/channel#reaction-object)

```csharp
public class MessageReaction
```

## Public Members

| name | description |
| --- | --- |
| [MessageReaction](#messagereaction-constructor)() | The default constructor. |
| [BurstColors](#burstcolors-property) { get; set; } | HEX colors used for super reaction TODO: Find out the array type |
| [Count](#count-property) { get; set; } | Total number of times this emoji has been used to react (including super reacts) |
| [CountDetails](#countdetails-property) { get; set; } | Reaction Count Details |
| [Emoji](#emoji-property) { get; set; } | Emoji information [`DiscordEmoji`](./DiscordEmoji.md) |
| [Me](#me-property) { get; set; } | Whether the current user reacted using this emoji |
| [MeBurst](#meburst-property) { get; set; } | Whether the current user super-reacted using this emoji |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [MessageReaction.cs](../../../../Oxide.Ext.Discord/Entities/MessageReaction.cs)
   
   
# MessageReaction constructor

The default constructor.

```csharp
public MessageReaction()
```

## See Also

* class [MessageReaction](./MessageReaction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Count property

Total number of times this emoji has been used to react (including super reacts)

```csharp
public int Count { get; set; }
```

## See Also

* class [MessageReaction](./MessageReaction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CountDetails property

Reaction Count Details

```csharp
public ReactionCountDetails CountDetails { get; set; }
```

## See Also

* class [ReactionCountDetails](./ReactionCountDetails.md)
* class [MessageReaction](./MessageReaction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Me property

Whether the current user reacted using this emoji

```csharp
public bool Me { get; set; }
```

## See Also

* class [MessageReaction](./MessageReaction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MeBurst property

Whether the current user super-reacted using this emoji

```csharp
public bool MeBurst { get; set; }
```

## See Also

* class [MessageReaction](./MessageReaction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Emoji property

Emoji information [`DiscordEmoji`](./DiscordEmoji.md)

```csharp
public DiscordEmoji Emoji { get; set; }
```

## See Also

* class [DiscordEmoji](./DiscordEmoji.md)
* class [MessageReaction](./MessageReaction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BurstColors property

HEX colors used for super reaction TODO: Find out the array type

```csharp
public object[] BurstColors { get; set; }
```

## See Also

* class [MessageReaction](./MessageReaction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
