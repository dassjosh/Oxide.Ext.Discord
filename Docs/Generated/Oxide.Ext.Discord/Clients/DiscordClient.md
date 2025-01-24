# DiscordClient class

Represents the object a plugin uses to connect to discord

```csharp
public class DiscordClient
```

## Public Members

| name | description |
| --- | --- |
| [Bot](#bot-property) { get; } | The bot client that is unique to the Token used |
| [JsonSettings](#jsonsettings-property) { get; } | Json settings for the discord client |
| [Plugin](#plugin-property) { get; } | Which plugin is the owner of this client |
| readonly [PluginId](#pluginid-field) | The ID of the plugin |
| readonly [PluginName](#pluginname-field) | The full plugin name including author and version |
| readonly [Webhooks](#webhooks-field) | Webhook clients for this DiscordClient |
| [Connect](#connect-method-1-of-4)(…) | Starts a connection to discord with the given apiKey and intents (4 methods) |
| [Disconnect](#disconnect-method)() | Disconnects this client from discord |
| [GetSoundboardSounds](#getsoundboardsounds-method)(…) | Request the list of soundboard sounds for the given guilds |
| [IsConnected](#isconnected-method)() | Returns if the client is connected to a bot / webhook and if the bot / webhook is initialized |
| [RequestGuildMembers](#requestguildmembers-method)(…) | Used to request guild members from discord for a specific guild |
| [UpdateStatus](#updatestatus-method)(…) | Used to update the bot status in discord |
| [UpdateVoiceState](#updatevoicestate-method)(…) | Used to update the voice state for the bot |

## See Also

* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordClient.cs](../../../../Oxide.Ext.Discord/Clients/DiscordClient.cs)
   
   
# Connect method (1 of 4)

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

# Connect method (2 of 4)

Connect to the webhook

```csharp
public WebhookClient Connect(string webhookUrl)
```

| parameter | description |
| --- | --- |
| webhookUrl | Webhook URL to connect to |

## See Also

* class [WebhookClient](./WebhookClient.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Connect method (3 of 4)

Connect to the webhook

```csharp
public WebhookClient Connect(WebhookConnection connection)
```

| parameter | description |
| --- | --- |
| connection | Webhook connection to connect to |

## See Also

* class [WebhookClient](./WebhookClient.md)
* class [WebhookConnection](../Connections/WebhookConnection.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# Connect method (4 of 4)

Starts a connection to discord with the given apiKey and intents

```csharp
public void Connect(string apiKey, GatewayIntents intents)
```

| parameter | description |
| --- | --- |
| apiKey | API key for the connecting bot |
| intents | Intents the bot needs to function |

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

Returns if the client is connected to a bot / webhook and if the bot / webhook is initialized

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

Used to update the bot status in discord

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
   
   
# GetSoundboardSounds method

Request the list of soundboard sounds for the given guilds

```csharp
public void GetSoundboardSounds(GetSoundboardSoundsCommand request)
```

| parameter | description |
| --- | --- |
| request |  |

## See Also

* class [GetSoundboardSoundsCommand](../Entities/GetSoundboardSoundsCommand.md)
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
   
   
# JsonSettings property

Json settings for the discord client

```csharp
public JsonSerializerSettings JsonSettings { get; }
```

## See Also

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
   
   
# Webhooks field

Webhook clients for this DiscordClient

```csharp
public readonly IReadOnlyList<WebhookClient> Webhooks;
```

## See Also

* class [WebhookClient](./WebhookClient.md)
* class [DiscordClient](./DiscordClient.md)
* namespace [Oxide.Ext.Discord.Clients](./ClientsNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
