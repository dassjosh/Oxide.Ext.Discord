# DiscordWebhook class

Represents [Webhook Structure](https://discord.com/developers/docs/resources/webhook#webhook-object)

```csharp
public class DiscordWebhook
```

## Public Members

| name | description |
| --- | --- |
| [DiscordWebhook](#discordwebhook-constructor)() | The default constructor. |
| [ApplicationId](#applicationid-property) { get; set; } | The bot/OAuth2 application that created this webhook |
| [Avatar](#avatar-property) { get; set; } | the default user avatar hash of the webhook |
| [ChannelId](#channelid-property) { get; set; } | The channel id this webhook is for, if any |
| [GuildId](#guildid-property) { get; set; } | The guild id this webhook is for, if any |
| [Id](#id-property) { get; set; } | The id of the webhook |
| [Name](#name-property) { get; set; } | The default name of the webhook |
| [SourceChannel](#sourcechannel-property) { get; set; } | The channel that this webhook is following (returned for Channel Follower Webhooks) |
| [SourceGuild](#sourceguild-property) { get; set; } | The guild of the channel that this webhook is following (returned for Channel Follower Webhooks) |
| [Token](#token-property) { get; set; } | The secure token of the webhook returned for Incoming Webhooks |
| [Type](#type-property) { get; set; } | The type of the webhook See [`WebhookType`](./WebhookType.md) |
| [User](#user-property) { get; set; } | The user this webhook was created by not returned when getting a webhook with its token |
| [DeleteWebhook](#deletewebhook-method)(…) | Delete a webhook permanently. Requires the MANAGE_WEBHOOKS permission. See [Delete Webhook](https://discord.com/developers/docs/resources/webhook#delete-webhook) |
| [DeleteWebhookMessage](#deletewebhookmessage-method)(…) | Deletes a message that was created by the webhook. |
| [DeleteWebhookWithToken](#deletewebhookwithtoken-method)(…) | Delete a webhook permanently. Does not require authentication. See [Delete Webhook with Token](https://discord.com/developers/docs/resources/webhook#delete-webhook-with-token) |
| [EditWebhook](#editwebhook-method)(…) | Modify a webhook. Requires the MANAGE_WEBHOOKS permission. See [Modify Webhook](https://discord.com/developers/docs/resources/webhook#modify-webhook) |
| [EditWebhookMessage](#editwebhookmessage-method)(…) | Edits a previously-sent webhook message from the same token. See [Edit Webhook Message](https://discord.com/developers/docs/resources/webhook#edit-webhook-message) |
| [EditWebhookMessageGlobalTemplate](#editwebhookmessageglobaltemplate-method)(…) | Edit a message from a webhook using a global message template |
| [EditWebhookMessageTemplate](#editwebhookmessagetemplate-method)(…) | Edit a message from a webhook using a localized message template |
| [ExecuteWebhook](#executewebhook-method-1-of-2)(…) | Executes a webhook See [Execute Webhook](https://discord.com/developers/docs/resources/webhook#execute-webhook) (2 methods) |
| [ExecuteWebhookGlobalTemplate](#executewebhookglobaltemplate-method)(…) | Send a message to a webhook using a global message template |
| [ExecuteWebhookTemplate](#executewebhooktemplate-method)(…) | Send a message to a webhook using a localized message template |
| [ExecuteWebhookWithMessage](#executewebhookwithmessage-method-1-of-2)(…) | Executes a webhook See [Execute Webhook](https://discord.com/developers/docs/resources/webhook#execute-webhook) (2 methods) |
| [GetWebhookMessage](#getwebhookmessage-method)(…) | Gets a previously-sent webhook message from the same token. See [Edit Webhook Message](https://discord.com/developers/docs/resources/webhook#get-webhook-message) |
| [ModifyWebhookWithToken](#modifywebhookwithtoken-method)(…) | Modify a webhook. Requires the MANAGE_WEBHOOKS permission. See [Modify Webhook with Token](https://discord.com/developers/docs/resources/webhook#modify-webhook-with-token) |
| static [CreateWebhook](#createwebhook-method)(…) | Create a new webhook. Requires the MANAGE_WEBHOOKS permission. See [Create Webhook](https://discord.com/developers/docs/resources/webhook#create-webhook) |
| static [GetChannelWebhooks](#getchannelwebhooks-method)(…) | Returns a list of channel webhook. See [Get Channel Webhooks](https://discord.com/developers/docs/resources/webhook#get-channel-webhooks) |
| static [GetGuildWebhooks](#getguildwebhooks-method)(…) | Returns a list of guild webhooks See [Get Guild Webhooks](https://discord.com/developers/docs/resources/webhook#get-guild-webhooks) |
| static [GetWebhook](#getwebhook-method)(…) | Returns the webhook with the given webhook ID See [Get Webhook](https://discord.com/developers/docs/resources/webhook#get-webhook) |
| static [GetWebhookWithToken](#getwebhookwithtoken-method)(…) | Returns the webhook with the given ID &amp; Token This call does not required authentication No user is returned in webhook object See [Get Webhook with Token](https://discord.com/developers/docs/resources/webhook#get-webhook-with-token) |
| static [GetWebhookWithUrl](#getwebhookwithurl-method)(…) | Returns the webhook with the given ID &amp; Token This call does not required authentication No user is returned in webhook object See [Get Webhook with Token](https://discord.com/developers/docs/resources/webhook#get-webhook-with-token) |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordWebhook.cs](../../../../Oxide.Ext.Discord/Entities/DiscordWebhook.cs)
   
   
# CreateWebhook method

Create a new webhook. Requires the MANAGE_WEBHOOKS permission. See [Create Webhook](https://discord.com/developers/docs/resources/webhook#create-webhook)

```csharp
public static IPromise<DiscordWebhook> CreateWebhook(DiscordClient client, Snowflake channelId, 
    WebhookCreate create)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| channelId | Channel ID for the webhook |
| create | Webhook create request |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [WebhookCreate](./WebhookCreate.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetChannelWebhooks method

Returns a list of channel webhook. See [Get Channel Webhooks](https://discord.com/developers/docs/resources/webhook#get-channel-webhooks)

```csharp
public static IPromise<List<DiscordWebhook>> GetChannelWebhooks(DiscordClient client, 
    Snowflake channelId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| channelId | Channel ID to get webhooks for |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetGuildWebhooks method

Returns a list of guild webhooks See [Get Guild Webhooks](https://discord.com/developers/docs/resources/webhook#get-guild-webhooks)

```csharp
public static IPromise<List<DiscordWebhook>> GetGuildWebhooks(DiscordClient client, 
    Snowflake guildId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild ID to get webhooks for |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetWebhook method

Returns the webhook with the given webhook ID See [Get Webhook](https://discord.com/developers/docs/resources/webhook#get-webhook)

```csharp
public static IPromise<DiscordWebhook> GetWebhook(DiscordClient client, Snowflake webhookId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| webhookId | Webhook ID to get |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetWebhookWithToken method

Returns the webhook with the given ID &amp; Token This call does not required authentication No user is returned in webhook object See [Get Webhook with Token](https://discord.com/developers/docs/resources/webhook#get-webhook-with-token)

```csharp
public static IPromise<DiscordWebhook> GetWebhookWithToken(DiscordClient client, 
    Snowflake webhookId, string webhookToken)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| webhookId | Webhook ID to get |
| webhookToken | Webhook Token |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetWebhookWithUrl method

Returns the webhook with the given ID &amp; Token This call does not required authentication No user is returned in webhook object See [Get Webhook with Token](https://discord.com/developers/docs/resources/webhook#get-webhook-with-token)

```csharp
public static IPromise<DiscordWebhook> GetWebhookWithUrl(DiscordClient client, string webhookUrl)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| webhookUrl | Returns the webhook for the specified URL |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditWebhook method

Modify a webhook. Requires the MANAGE_WEBHOOKS permission. See [Modify Webhook](https://discord.com/developers/docs/resources/webhook#modify-webhook)

```csharp
public IPromise<DiscordWebhook> EditWebhook(DiscordClient client, WebhookEdit edit)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| edit | Edit request for the webhook |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [WebhookEdit](./WebhookEdit.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ModifyWebhookWithToken method

Modify a webhook. Requires the MANAGE_WEBHOOKS permission. See [Modify Webhook with Token](https://discord.com/developers/docs/resources/webhook#modify-webhook-with-token)

```csharp
public IPromise<DiscordWebhook> ModifyWebhookWithToken(DiscordClient client, WebhookEdit edit)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| edit | Edit request for the webhook |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [WebhookEdit](./WebhookEdit.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteWebhook method

Delete a webhook permanently. Requires the MANAGE_WEBHOOKS permission. See [Delete Webhook](https://discord.com/developers/docs/resources/webhook#delete-webhook)

```csharp
public IPromise DeleteWebhook(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteWebhookWithToken method

Delete a webhook permanently. Does not require authentication. See [Delete Webhook with Token](https://discord.com/developers/docs/resources/webhook#delete-webhook-with-token)

```csharp
public IPromise DeleteWebhookWithToken(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ExecuteWebhook method (1 of 2)

Executes a webhook See [Execute Webhook](https://discord.com/developers/docs/resources/webhook#execute-webhook)

```csharp
public IPromise ExecuteWebhook(DiscordClient client, WebhookCreateMessage message, 
    WebhookExecuteParams executeParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| message | Message data |
| executeParams | Webhook execution parameters |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* class [WebhookExecuteParams](./WebhookExecuteParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ExecuteWebhook method (2 of 2)

Executes a webhook See [Execute Webhook](https://discord.com/developers/docs/resources/webhook#execute-webhook)

```csharp
public IPromise ExecuteWebhook(DiscordClient client, WebhookMessageBuilder builder, 
    WebhookExecuteParams executeParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| builder | Builder for the message |
| executeParams | Webhook execution parameters |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [WebhookMessageBuilder](../Builders/WebhookMessageBuilder.md)
* class [WebhookExecuteParams](./WebhookExecuteParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ExecuteWebhookWithMessage method (1 of 2)

Executes a webhook See [Execute Webhook](https://discord.com/developers/docs/resources/webhook#execute-webhook)

```csharp
public IPromise<DiscordMessage> ExecuteWebhookWithMessage(DiscordClient client, 
    WebhookCreateMessage message, WebhookExecuteParams executeParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| message | Message data |
| executeParams | Webhook execution parameters |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* class [WebhookExecuteParams](./WebhookExecuteParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ExecuteWebhookWithMessage method (2 of 2)

Executes a webhook See [Execute Webhook](https://discord.com/developers/docs/resources/webhook#execute-webhook)

```csharp
public IPromise<DiscordMessage> ExecuteWebhookWithMessage(DiscordClient client, 
    WebhookMessageBuilder builder, WebhookExecuteParams executeParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| builder | Builder for the message |
| executeParams | Webhook execution parameters |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [WebhookMessageBuilder](../Builders/WebhookMessageBuilder.md)
* class [WebhookExecuteParams](./WebhookExecuteParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ExecuteWebhookGlobalTemplate method

Send a message to a webhook using a global message template

```csharp
public IPromise<DiscordMessage> ExecuteWebhookGlobalTemplate(DiscordClient client, 
    TemplateKey templateName, WebhookCreateMessage message = null, 
    PlaceholderData placeholders = null, WebhookExecuteParams executeParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| templateName | Template Name |
| message | Message to use (optional) |
| placeholders | Placeholders to apply (optional) |
| executeParams | Webhook execution parameters |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [TemplateKey](../Libraries/TemplateKey.md)
* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* class [PlaceholderData](../Libraries/PlaceholderData.md)
* class [WebhookExecuteParams](./WebhookExecuteParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ExecuteWebhookTemplate method

Send a message to a webhook using a localized message template

```csharp
public IPromise<DiscordMessage> ExecuteWebhookTemplate(DiscordClient client, 
    TemplateKey templateName, string language = "en", WebhookCreateMessage message = null, 
    PlaceholderData placeholders = null, WebhookExecuteParams executeParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| templateName | Template Name |
| language | Oxide language to use |
| message | Message to use (optional) |
| placeholders | Placeholders to apply (optional) |
| executeParams | Webhook execution parameters |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [TemplateKey](../Libraries/TemplateKey.md)
* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* class [PlaceholderData](../Libraries/PlaceholderData.md)
* class [WebhookExecuteParams](./WebhookExecuteParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetWebhookMessage method

Gets a previously-sent webhook message from the same token. See [Edit Webhook Message](https://discord.com/developers/docs/resources/webhook#get-webhook-message)

```csharp
public IPromise<DiscordMessage> GetWebhookMessage(DiscordClient client, Snowflake messageId, 
    WebhookMessageParams messageParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | Message ID to get |
| messageParams | Message Params |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [WebhookMessageParams](./WebhookMessageParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditWebhookMessage method

Edits a previously-sent webhook message from the same token. See [Edit Webhook Message](https://discord.com/developers/docs/resources/webhook#edit-webhook-message)

```csharp
public IPromise<DiscordMessage> EditWebhookMessage(DiscordClient client, Snowflake messageId, 
    WebhookEditMessage message, WebhookMessageParams messageParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | Message ID to edit |
| messageParams | Message Params |
| message | The updated message |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [WebhookEditMessage](./WebhookEditMessage.md)
* class [WebhookMessageParams](./WebhookMessageParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditWebhookMessageGlobalTemplate method

Edit a message from a webhook using a global message template

```csharp
public IPromise<DiscordMessage> EditWebhookMessageGlobalTemplate(DiscordClient client, 
    Snowflake messageId, Plugin plugin, TemplateKey templateName, 
    WebhookEditMessage message = null, PlaceholderData placeholders = null, 
    WebhookMessageParams messageParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | Message ID of the message to edit |
| plugin | Plugin for the template |
| templateName | Template Name |
| message | Message to use (optional) |
| placeholders | Placeholders to apply (optional) |
| messageParams | Message Params |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* struct [TemplateKey](../Libraries/TemplateKey.md)
* class [WebhookEditMessage](./WebhookEditMessage.md)
* class [PlaceholderData](../Libraries/PlaceholderData.md)
* class [WebhookMessageParams](./WebhookMessageParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditWebhookMessageTemplate method

Edit a message from a webhook using a localized message template

```csharp
public IPromise<DiscordMessage> EditWebhookMessageTemplate(DiscordClient client, 
    Snowflake messageId, Plugin plugin, TemplateKey templateName, string language = "en", 
    WebhookEditMessage message = null, PlaceholderData placeholders = null, 
    WebhookMessageParams messageParams = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | Message ID of the message to edit |
| plugin | Plugin for the template |
| templateName | Template Name |
| language | Oxide language to use |
| message | Message to use (optional) |
| placeholders | Placeholders to apply (optional) |
| messageParams | Message Params |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* struct [TemplateKey](../Libraries/TemplateKey.md)
* class [WebhookEditMessage](./WebhookEditMessage.md)
* class [PlaceholderData](../Libraries/PlaceholderData.md)
* class [WebhookMessageParams](./WebhookMessageParams.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteWebhookMessage method

Deletes a message that was created by the webhook.

```csharp
public IPromise DeleteWebhookMessage(DiscordClient client, Snowflake messageId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | Message ID to delete |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordWebhook constructor

The default constructor.

```csharp
public DiscordWebhook()
```

## See Also

* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

The id of the webhook

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Type property

The type of the webhook See [`WebhookType`](./WebhookType.md)

```csharp
public WebhookType Type { get; set; }
```

## See Also

* enum [WebhookType](./WebhookType.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildId property

The guild id this webhook is for, if any

```csharp
public Snowflake? GuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ChannelId property

The channel id this webhook is for, if any

```csharp
public Snowflake? ChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# User property

The user this webhook was created by not returned when getting a webhook with its token

```csharp
public DiscordUser User { get; set; }
```

## See Also

* class [DiscordUser](./DiscordUser.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

The default name of the webhook

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Avatar property

the default user avatar hash of the webhook

```csharp
public string Avatar { get; set; }
```

## See Also

* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Token property

The secure token of the webhook returned for Incoming Webhooks

```csharp
public string Token { get; set; }
```

## See Also

* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApplicationId property

The bot/OAuth2 application that created this webhook

```csharp
public Snowflake ApplicationId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SourceGuild property

The guild of the channel that this webhook is following (returned for Channel Follower Webhooks)

```csharp
public DiscordGuild SourceGuild { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SourceChannel property

The channel that this webhook is following (returned for Channel Follower Webhooks)

```csharp
public Snowflake SourceChannel { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordWebhook](./DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
