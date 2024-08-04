# DiscordClient class

Represents the object a plugin uses to connects to discord

```csharp
public class DiscordClient
```

## Public Members

| name | description |
| --- | --- |
| [Bot](#bot-property) { get; } | The bot client that is unique to the Token used |
| [Plugin](#plugin-property) { get; } | Which plugin is the owner of this client |
| readonly [PluginId](#pluginid-field) | The ID of the plugin |
| readonly [PluginName](#pluginname-field) | The full plugin name including author and version |
| [Connect](#connect-method-1-of-2)(…) | Starts a connection to discord with the given apiKey and intents (2 methods) |
| [Disconnect](#disconnect-method)() | Disconnects this client from discord |
| [IsConnected](#isconnected-method)() | Returns if the client is connected to a bot and if the bot is initialized |
| [RequestGuildMembers](#requestguildmembers-method)(…) | Used to request guild members from discord for a specific guild |
| [UpdateStatus](#updatestatus-method)(…) | Used to update the bots status in discord |
| [UpdateVoiceState](#updatevoicestate-method)(…) | Used to update the voice state for the bot |

## See Also

* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordClient.cs](../../../../Oxide.Ext.Discord/Clients/DiscordClient.cs)
   
   
# Connect method (1 of 2)

Starts a connection to discord with the given discord settings

```csharp
public void Connect(BotConnection connection)
```

| parameter | description |
| --- | --- |
| connection | Discord connection settings |

## See Also

* class [BotConnection](../Connections/BotConnection.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Connect method (2 of 2)

Starts a connection to discord with the given apiKey and intents

```csharp
public void Connect(string apiKey, GatewayIntents intents)
```

| parameter | description |
| --- | --- |
| apiKey | API key for the connecting bot |
| intents | Intents the bot needs in order to function |

## See Also

* enum [GatewayIntents](../Entities/GatewayIntents.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Disconnect method

Disconnects this client from discord

```csharp
public void Disconnect()
```

## See Also

* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsConnected method

Returns if the client is connected to a bot and if the bot is initialized

```csharp
public bool IsConnected()
```

## See Also

* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RequestGuildMembers method

Used to request guild members from discord for a specific guild

```csharp
public void RequestGuildMembers(GuildMembersRequestCommand request)
```

| parameter | description |
| --- | --- |
| request | Request for guild members |

## See Also

* class [GuildMembersRequestCommand](../Entities/GuildMembersRequestCommand.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UpdateVoiceState method

Used to update the voice state for the bot

```csharp
public void UpdateVoiceState(UpdateVoiceStatusCommand voiceState)
```

| parameter | description |
| --- | --- |
| voiceState |  |

## See Also

* class [UpdateVoiceStatusCommand](../Entities/UpdateVoiceStatusCommand.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UpdateStatus method

Used to update the bots status in discord

```csharp
public void UpdateStatus(UpdatePresenceCommand presenceUpdate)
```

| parameter | description |
| --- | --- |
| presenceUpdate |  |

## See Also

* class [UpdatePresenceCommand](../Entities/UpdatePresenceCommand.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Plugin property

Which plugin is the owner of this client

```csharp
public Plugin Plugin { get; }
```

## See Also

* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Bot property

The bot client that is unique to the Token used

```csharp
public BotClient Bot { get; }
```

## See Also

* class [BotClient](./BotClient.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PluginId field

The ID of the plugin

```csharp
public readonly PluginId PluginId;
```

## See Also

* struct [PluginId](../Plugins/PluginId.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PluginName field

The full plugin name including author and version

```csharp
public readonly string PluginName;
```

## See Also

* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
