# DiscordInteraction class

Represents [Interaction Structure](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-structure)

```csharp
public class DiscordInteraction
```

## Public Members

| name | description |
| --- | --- |
| [DiscordInteraction](#discordinteraction-constructor)() | The default constructor. |
| [ApplicationId](#applicationid-property) { get; set; } | ID of the application this interaction is for |
| [AppPermissions](#apppermissions-property) { get; set; } | Bitwise set of permissions the app has in the source location of the interaction |
| [AuthorizingIntegrationOwners](#authorizingintegrationowners-property) { get; set; } | Mapping of installation contexts that the interaction was authorized for to related user or guild IDs |
| [Channel](#channel-property) { get; set; } | Channel that the interaction was sent from |
| [ChannelId](#channelid-property) { get; set; } | Channel that the interaction was sent from |
| [Contexts](#contexts-property) { get; set; } | Context where the interaction was triggered from |
| [Data](#data-property) { get; set; } | Interaction data payload See [`InteractionData`](./InteractionData.md) |
| [Entitlements](#entitlements-property) { get; set; } | For monetized apps, any entitlements for the invoking user, representing access to premium SKUs |
| [Focused](#focused-property) { get; } | Returns the Focused option for Auto Complete |
| [Guild](#guild-property) { get; set; } | Guild that the interaction was sent from |
| [GuildId](#guildid-property) { get; set; } | Guild that the interaction was sent from |
| [GuildLocale](#guildlocale-property) { get; set; } | The guild's preferred locale, if invoked in a guild [Discord Locale Values](https://discord.com/developers/docs/dispatch/field-values#predefined-field-values-accepted-locales) |
| [Id](#id-property) { get; set; } | Id of the interaction |
| [Locale](#locale-property) { get; set; } | The selected language of the invoking user [Discord Locale Values](https://discord.com/developers/docs/dispatch/field-values#predefined-field-values-accepted-locales) |
| [Member](#member-property) { get; set; } | Guild member data for the invoking user, including permissions |
| [Message](#message-property) { get; set; } | For components, the message they were attached to |
| [Parsed](#parsed-property) { get; } | Returns the interaction parsed args to make it easier to process that interaction. |
| [Token](#token-property) { get; set; } | Continuation token for responding to the interaction Interaction tokens are valid for 15 minutes and can be used to send followup messages but you must send an initial response within 3 seconds of receiving the event. If the 3 second deadline is exceeded, the token will be invalidated. |
| [Type](#type-property) { get; set; } | The type of interaction See [`InteractionType`](./InteractionType.md) |
| [User](#user-property) { get; } | User object. If in DM then DM user else GuildMember.User |
| [Version](#version-property) { get; set; } | Read-only property, always 1 |
| readonly [CreatedDate](#createddate-field) | The UTC DateTime this interaction was created |
| [CreateFollowUpMessage](#createfollowupmessage-method-1-of-2)(…) | Create a followup message for an Interaction See [Create Followup Message](https://discord.com/developers/docs/interactions/receiving-and-responding#create-followup-message) (2 methods) |
| [CreateFollowUpTemplateResponse](#createfollowuptemplateresponse-method)(…) | Creates a interaction follow up message response from a message template |
| [CreateModalResponse](#createmodalresponse-method)(…) | Creates a interaction modal response from a modal template |
| [CreateResponse](#createresponse-method-1-of-7)(…) | Create a response to an Interaction from the gateway. See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response) (7 methods) |
| [CreateResponseWithCallback](#createresponsewithcallback-method)(…) | Create a response to an Interaction from the gateway. See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response) |
| [CreateTemplateResponse](#createtemplateresponse-method)(…) | Creates a interaction message response from a message template |
| [DefferResponse](#defferresponse-method)(…) | Creates a response indicating that: for application commands there will be an update in the future for message component commands that you have acknowledged the command and there may be an update in the future See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response) |
| [DeleteFollowUpMessage](#deletefollowupmessage-method)(…) | Deletes a followup message for an Interaction See [Delete Followup Message](https://discord.com/developers/docs/interactions/receiving-and-responding#delete-followup-message) |
| [DeleteOriginalResponse](#deleteoriginalresponse-method)(…) | Deletes the initial Interaction response See [Delete Original Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#delete-original-interaction-response) |
| [EditFollowUpMessage](#editfollowupmessage-method)(…) | Edits a followup message for an Interaction See [Edit Followup Message](https://discord.com/developers/docs/interactions/receiving-and-responding#edit-followup-message) |
| [EditOriginalResponse](#editoriginalresponse-method)(…) | Edits the initial Interaction response See [Edit Original Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#edit-original-interaction-response) |
| [EditTemplateOriginalResponse](#edittemplateoriginalresponse-method)(…) | Edit a interaction response with a message template |
| [GetAutoCompleteBuilder](#getautocompletebuilder-method)() | Returns a [`InteractionAutoCompleteBuilder`](../Builders/InteractionAutoCompleteBuilder.md) for this interaction |
| [GetFollowupBuilder](#getfollowupbuilder-method)() | Returns a [`InteractionFollowupBuilder`](../Builders/InteractionFollowupBuilder.md) for this interaction |
| [GetFollowUpMessage](#getfollowupmessage-method)(…) | Get a followup message for an Interaction See [Get Followup Message](https://discord.com/developers/docs/interactions/receiving-and-responding#get-followup-message) |
| [GetLangMessage](#getlangmessage-method-1-of-2)(…) | Returns a localized string for this interaction (2 methods) |
| [GetModalBuilder](#getmodalbuilder-method)() | Returns a [`InteractionAutoCompleteBuilder`](../Builders/InteractionAutoCompleteBuilder.md) for this interaction |
| [GetOriginalResponse](#getoriginalresponse-method)(…) | Gets the initial Interaction response See [Get Original Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#get-original-interaction-response) |
| [GetResponseBuilder](#getresponsebuilder-method)() | Returns a [`InteractionResponseBuilder`](../Builders/InteractionResponseBuilder.md) for this interaction |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordInteraction.cs](../../../../Oxide.Ext.Discord/Entities/DiscordInteraction.cs)
   
   
# GetLangMessage method (1 of 2)

Returns a localized string for this interaction

```csharp
public string GetLangMessage(Plugin plugin, string langKey)
```

| parameter | description |
| --- | --- |
| plugin | Plugin the localization is for |
| langKey | Lang Key to return |

## Return Value

Localized string if it is found; Empty string otherwise

## See Also

* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# GetLangMessage method (2 of 2)

Returns a localized string for this interaction

```csharp
public string GetLangMessage(Plugin plugin, string langKey, params object[] args)
```

| parameter | description |
| --- | --- |
| plugin | Plugin the localization is for |
| langKey | Lang Key to return |
| args | Localization args |

## Return Value

Localized string if it is found; Empty string otherwise

## See Also

* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetResponseBuilder method

Returns a [`InteractionResponseBuilder`](../Builders/InteractionResponseBuilder.md) for this interaction

```csharp
public InteractionResponseBuilder GetResponseBuilder()
```

## See Also

* class [InteractionResponseBuilder](../Builders/InteractionResponseBuilder.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetFollowupBuilder method

Returns a [`InteractionFollowupBuilder`](../Builders/InteractionFollowupBuilder.md) for this interaction

```csharp
public InteractionFollowupBuilder GetFollowupBuilder()
```

## See Also

* class [InteractionFollowupBuilder](../Builders/InteractionFollowupBuilder.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetAutoCompleteBuilder method

Returns a [`InteractionAutoCompleteBuilder`](../Builders/InteractionAutoCompleteBuilder.md) for this interaction

```csharp
public InteractionAutoCompleteBuilder GetAutoCompleteBuilder()
```

## See Also

* class [InteractionAutoCompleteBuilder](../Builders/InteractionAutoCompleteBuilder.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetModalBuilder method

Returns a [`InteractionAutoCompleteBuilder`](../Builders/InteractionAutoCompleteBuilder.md) for this interaction

```csharp
public InteractionModalBuilder GetModalBuilder()
```

## See Also

* class [InteractionModalBuilder](../Builders/InteractionModalBuilder.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateResponse method (1 of 7)

Create a response to an Interaction from the gateway. See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response)

```csharp
public IPromise CreateResponse(DiscordClient client, BaseInteractionResponse response)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| response | Response to respond with |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [BaseInteractionResponse](./BaseInteractionResponse.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# CreateResponse method (2 of 7)

Create a Auto Complete response to an Interaction See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response)

```csharp
public IPromise CreateResponse(DiscordClient client, InteractionAutoCompleteBuilder builder)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| builder | Auto Complete Builder for this response |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [InteractionAutoCompleteBuilder](../Builders/InteractionAutoCompleteBuilder.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# CreateResponse method (3 of 7)

Create a Auto Complete response to an Interaction See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response)

```csharp
public IPromise CreateResponse(DiscordClient client, InteractionAutoCompleteMessage message)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| message | Message for this response |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [InteractionAutoCompleteMessage](./InteractionAutoCompleteMessage.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# CreateResponse method (4 of 7)

Create a Modal response to an Interaction See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response)

```csharp
public IPromise CreateResponse(DiscordClient client, InteractionModalBuilder builder)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| builder | Modal Builder for this response |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [InteractionModalBuilder](../Builders/InteractionModalBuilder.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# CreateResponse method (5 of 7)

Create a Modal response to an Interaction See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response)

```csharp
public IPromise CreateResponse(DiscordClient client, InteractionModalMessage message)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| message | Message for this response |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [InteractionModalMessage](./InteractionModalMessage.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# CreateResponse method (6 of 7)

Create a response to an Interaction from the gateway. See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response)

```csharp
public IPromise CreateResponse(DiscordClient client, InteractionResponseType type, 
    InteractionCallbackData response = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| type | Type of the interaction response |
| response | Interaction Callback Message Data |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* enum [InteractionResponseType](./InteractionResponseType.md)
* class [InteractionCallbackData](./InteractionCallbackData.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# CreateResponse method (7 of 7)

Create a response to an Interaction from the gateway. See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response)

```csharp
public IPromise CreateResponse(DiscordClient client, InteractionResponseType type, 
    InteractionResponseBuilder builder)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| type | Type of the interaction response |
| builder | Builder for this response |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* enum [InteractionResponseType](./InteractionResponseType.md)
* class [InteractionResponseBuilder](../Builders/InteractionResponseBuilder.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateResponseWithCallback method

Create a response to an Interaction from the gateway. See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response)

```csharp
public IPromise<InteractionCallbackResponse> CreateResponseWithCallback(DiscordClient client, 
    BaseInteractionResponse response)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| response | Response to respond with |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [InteractionCallbackResponse](./InteractionCallbackResponse.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [BaseInteractionResponse](./BaseInteractionResponse.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateTemplateResponse method

Creates a interaction message response from a message template

```csharp
public IPromise CreateTemplateResponse(DiscordClient client, InteractionResponseType type, 
    TemplateKey templateName, InteractionCallbackData message = null, 
    PlaceholderData placeholders = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| type | Response type for the interaction |
| templateName | Name of the template |
| message | Message to send (optional) |
| placeholders | Placeholders to apply (optional) |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | Thrown if plugin or templateName is null |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* enum [InteractionResponseType](./InteractionResponseType.md)
* struct [TemplateKey](../Libraries/TemplateKey.md)
* class [InteractionCallbackData](./InteractionCallbackData.md)
* class [PlaceholderData](../Libraries/PlaceholderData.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateModalResponse method

Creates a interaction modal response from a modal template

```csharp
public IPromise CreateModalResponse(DiscordClient client, TemplateKey templateName, 
    InteractionModalMessage message = null, PlaceholderData placeholders = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| templateName |  |
| message | Message to use (optional) |
| placeholders | Placeholders to apply (optional) |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException |  |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [TemplateKey](../Libraries/TemplateKey.md)
* class [InteractionModalMessage](./InteractionModalMessage.md)
* class [PlaceholderData](../Libraries/PlaceholderData.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DefferResponse method

Creates a response indicating that: for application commands there will be an update in the future for message component commands that you have acknowledged the command and there may be an update in the future See [Create Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response)

```csharp
public IPromise DefferResponse(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetOriginalResponse method

Gets the initial Interaction response See [Get Original Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#get-original-interaction-response)

```csharp
public IPromise<DiscordMessage> GetOriginalResponse(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditOriginalResponse method

Edits the initial Interaction response See [Edit Original Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#edit-original-interaction-response)

```csharp
public IPromise<DiscordMessage> EditOriginalResponse(DiscordClient client, MessageUpdate message)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| message | Updated message |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [MessageUpdate](./MessageUpdate.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditTemplateOriginalResponse method

Edit a interaction response with a message template

```csharp
public IPromise<DiscordMessage> EditTemplateOriginalResponse(DiscordClient client, 
    TemplateKey templateName, MessageUpdate message = null, PlaceholderData placeholders = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| templateName | Template Name |
| message | Message to use (optional) |
| placeholders | Placeholders to apply (optional) |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException |  |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [TemplateKey](../Libraries/TemplateKey.md)
* class [MessageUpdate](./MessageUpdate.md)
* class [PlaceholderData](../Libraries/PlaceholderData.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteOriginalResponse method

Deletes the initial Interaction response See [Delete Original Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#delete-original-interaction-response)

```csharp
public IPromise DeleteOriginalResponse(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateFollowUpMessage method (1 of 2)

Create a followup message for an Interaction See [Create Followup Message](https://discord.com/developers/docs/interactions/receiving-and-responding#create-followup-message)

```csharp
public IPromise<DiscordMessage> CreateFollowUpMessage(DiscordClient client, 
    CommandFollowupCreate message)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| message | Message to follow up with |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [CommandFollowupCreate](./CommandFollowupCreate.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# CreateFollowUpMessage method (2 of 2)

Create a followup message for an Interaction See [Create Followup Message](https://discord.com/developers/docs/interactions/receiving-and-responding#create-followup-message)

```csharp
public IPromise<DiscordMessage> CreateFollowUpMessage(DiscordClient client, 
    InteractionFollowupBuilder builder)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| builder | Builder for the follow up |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [InteractionFollowupBuilder](../Builders/InteractionFollowupBuilder.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateFollowUpTemplateResponse method

Creates a interaction follow up message response from a message template

```csharp
public IPromise<DiscordMessage> CreateFollowUpTemplateResponse(DiscordClient client, 
    TemplateKey templateName, CommandFollowupCreate message = null, 
    PlaceholderData placeholders = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| templateName | Name of the template |
| message | Message to send (optional) |
| placeholders | Placeholders to apply (optional) |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | Thrown if plugin or templateName is null |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [TemplateKey](../Libraries/TemplateKey.md)
* class [CommandFollowupCreate](./CommandFollowupCreate.md)
* class [PlaceholderData](../Libraries/PlaceholderData.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetFollowUpMessage method

Get a followup message for an Interaction See [Get Followup Message](https://discord.com/developers/docs/interactions/receiving-and-responding#get-followup-message)

```csharp
public IPromise<DiscordMessage> GetFollowUpMessage(DiscordClient client, Snowflake messageId, 
    CommandFollowupUpdate edit)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | Message ID of the follow up message |
| edit | Updated message |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [CommandFollowupUpdate](./CommandFollowupUpdate.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditFollowUpMessage method

Edits a followup message for an Interaction See [Edit Followup Message](https://discord.com/developers/docs/interactions/receiving-and-responding#edit-followup-message)

```csharp
public IPromise<DiscordMessage> EditFollowUpMessage(DiscordClient client, Snowflake messageId, 
    CommandFollowupUpdate edit)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | Message ID of the follow up message |
| edit | Updated message |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [CommandFollowupUpdate](./CommandFollowupUpdate.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteFollowUpMessage method

Deletes a followup message for an Interaction See [Delete Followup Message](https://discord.com/developers/docs/interactions/receiving-and-responding#delete-followup-message)

```csharp
public IPromise DeleteFollowUpMessage(DiscordClient client, Snowflake messageId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | Message ID to delete |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordInteraction constructor

The default constructor.

```csharp
public DiscordInteraction()
```

## See Also

* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

Id of the interaction

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApplicationId property

ID of the application this interaction is for

```csharp
public Snowflake ApplicationId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Type property

The type of interaction See [`InteractionType`](./InteractionType.md)

```csharp
public InteractionType Type { get; set; }
```

## See Also

* enum [InteractionType](./InteractionType.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Data property

Interaction data payload See [`InteractionData`](./InteractionData.md)

```csharp
public InteractionData Data { get; set; }
```

## See Also

* class [InteractionData](./InteractionData.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Guild property

Guild that the interaction was sent from

```csharp
public DiscordGuild Guild { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildId property

Guild that the interaction was sent from

```csharp
public Snowflake? GuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Channel property

Channel that the interaction was sent from

```csharp
public DiscordChannel Channel { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ChannelId property

Channel that the interaction was sent from

```csharp
public Snowflake? ChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Member property

Guild member data for the invoking user, including permissions

```csharp
public GuildMember Member { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# User property

User object. If in DM then DM user else GuildMember.User

```csharp
public DiscordUser User { get; }
```

## See Also

* class [DiscordUser](./DiscordUser.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Token property

Continuation token for responding to the interaction Interaction tokens are valid for 15 minutes and can be used to send followup messages but you must send an initial response within 3 seconds of receiving the event. If the 3 second deadline is exceeded, the token will be invalidated.

```csharp
public string Token { get; set; }
```

## See Also

* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Version property

Read-only property, always 1

```csharp
public int Version { get; set; }
```

## See Also

* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Message property

For components, the message they were attached to

```csharp
public DiscordMessage Message { get; set; }
```

## See Also

* class [DiscordMessage](./DiscordMessage.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppPermissions property

Bitwise set of permissions the app has in the source location of the interaction

```csharp
public PermissionFlags? AppPermissions { get; set; }
```

## See Also

* enum [PermissionFlags](./PermissionFlags.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Locale property

The selected language of the invoking user [Discord Locale Values](https://discord.com/developers/docs/dispatch/field-values#predefined-field-values-accepted-locales)

```csharp
public DiscordLocale Locale { get; set; }
```

## See Also

* struct [DiscordLocale](../Libraries/DiscordLocale.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildLocale property

The guild's preferred locale, if invoked in a guild [Discord Locale Values](https://discord.com/developers/docs/dispatch/field-values#predefined-field-values-accepted-locales)

```csharp
public DiscordLocale? GuildLocale { get; set; }
```

## See Also

* struct [DiscordLocale](../Libraries/DiscordLocale.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Entitlements property

For monetized apps, any entitlements for the invoking user, representing access to premium SKUs

```csharp
public List<DiscordEntitlement> Entitlements { get; set; }
```

## See Also

* class [DiscordEntitlement](./DiscordEntitlement.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AuthorizingIntegrationOwners property

Mapping of installation contexts that the interaction was authorized for to related user or guild IDs

```csharp
public Hash<ApplicationIntegrationType, Snowflake> AuthorizingIntegrationOwners { get; set; }
```

## See Also

* enum [ApplicationIntegrationType](./ApplicationIntegrationType.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Contexts property

Context where the interaction was triggered from

```csharp
public List<InteractionContextTypes> Contexts { get; set; }
```

## See Also

* enum [InteractionContextTypes](./InteractionContextTypes.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Parsed property

Returns the interaction parsed args to make it easier to process that interaction.

```csharp
public InteractionDataParsed Parsed { get; }
```

## See Also

* class [InteractionDataParsed](./InteractionDataParsed.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Focused property

Returns the Focused option for Auto Complete

```csharp
public InteractionDataOption Focused { get; }
```

## See Also

* class [InteractionDataOption](./InteractionDataOption.md)
* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreatedDate field

The UTC DateTime this interaction was created

```csharp
public readonly DateTime CreatedDate;
```

## See Also

* class [DiscordInteraction](./DiscordInteraction.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
