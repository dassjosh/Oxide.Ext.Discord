# IdentifyCommand class

Represents [Identify](https://discord.com/developers/docs/topics/gateway#identify) Command

```csharp
public class IdentifyCommand
```

## Public Members

| name | description |
| --- | --- |
| [IdentifyCommand](#identifycommand-constructor)() | The default constructor. |
| [Intents](#intents-property) { get; set; } | The Gateway Intents you wish to receive See [Gateway Intents](https://discord.com/developers/docs/topics/gateway#gateway-intents) See [`GatewayIntents`](./GatewayIntents.md) |
| [Compress](#compress-field) | Whether this connection supports compression of packets |
| [LargeThreshold](#largethreshold-field) | Value between 50 and 250, total number of members where the gateway will stop sending offline members in the guild member list |
| [PresenceUpdate](#presenceupdate-field) | Presence structure for initial presence information |
| [Properties](#properties-field) | Connection properties |
| [Shard](#shard-field) | Used for Guild Sharding See [Guild Sharding](https://discord.com/developers/docs/topics/gateway#sharding) |
| [Token](#token-field) | Authentication token |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [IdentifyCommand.cs](../../../../Oxide.Ext.Discord/Entities/IdentifyCommand.cs)
   
   
# IdentifyCommand constructor

The default constructor.

```csharp
public IdentifyCommand()
```

## See Also

* class [IdentifyCommand](./IdentifyCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Intents property

The Gateway Intents you wish to receive See [Gateway Intents](https://discord.com/developers/docs/topics/gateway#gateway-intents) See [`GatewayIntents`](./GatewayIntents.md)

```csharp
public GatewayIntents Intents { get; set; }
```

## See Also

* enum [GatewayIntents](./GatewayIntents.md)
* class [IdentifyCommand](./IdentifyCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Token field

Authentication token

```csharp
public string Token;
```

## See Also

* class [IdentifyCommand](./IdentifyCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Properties field

Connection properties

```csharp
public ConnectionProperties Properties;
```

## See Also

* class [ConnectionProperties](./ConnectionProperties.md)
* class [IdentifyCommand](./IdentifyCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Compress field

Whether this connection supports compression of packets

```csharp
public bool? Compress;
```

## See Also

* class [IdentifyCommand](./IdentifyCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LargeThreshold field

Value between 50 and 250, total number of members where the gateway will stop sending offline members in the guild member list

```csharp
public int? LargeThreshold;
```

## See Also

* class [IdentifyCommand](./IdentifyCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Shard field

Used for Guild Sharding See [Guild Sharding](https://discord.com/developers/docs/topics/gateway#sharding)

```csharp
public List<int> Shard;
```

## See Also

* class [IdentifyCommand](./IdentifyCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PresenceUpdate field

Presence structure for initial presence information

```csharp
public UpdatePresenceCommand PresenceUpdate;
```

## See Also

* class [UpdatePresenceCommand](./UpdatePresenceCommand.md)
* class [IdentifyCommand](./IdentifyCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
