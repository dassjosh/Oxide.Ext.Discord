# DiscordWebhook.EditWebhookMessageGlobalTemplate method

Edit a message from a webhook using a global message template

```csharp
public IPromise<DiscordMessage> EditWebhookMessageGlobalTemplate(DiscordClient client, 
    Snowflake messageId, Plugin plugin, string templateName, DiscordMessage message = null, 
    PlaceholderData placeholders = null, WebhookMessageParams messageParams = null)
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

* interface [IPromise&lt;TPromised&gt;](../../../Interfaces/Promises/IPromise-1.md)
* class [DiscordMessage](../../Messages/DiscordMessage.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* struct [Snowflake](../../Snowflake.md)
* class [PlaceholderData](../../../Libraries/Placeholders/PlaceholderData.md)
* class [WebhookMessageParams](../WebhookMessageParams.md)
* class [DiscordWebhook](../DiscordWebhook.md)
* namespace [Oxide.Ext.Discord.Entities.Webhooks](../DiscordWebhook.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->