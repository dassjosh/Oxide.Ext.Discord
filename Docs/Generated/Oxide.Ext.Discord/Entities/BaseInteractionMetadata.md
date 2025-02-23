# BaseInteractionMetadata class

Represents a [Message Call Structure](https://discord.com/developers/docs/resources/channel#message-call-object)

```csharp
public class BaseInteractionMetadata
```

## Public Members

| name | description |
| --- | --- |
| [BaseInteractionMetadata](#baseinteractionmetadata-constructor)() | The default constructor. |
| [AuthorizingIntegrationOwners](#authorizingintegrationowners-property) { get; set; } | IDs for installation context(s) related to an interaction. Details in Authorizing Integration Owners Object |
| [Id](#id-property) { get; set; } | ID of the interaction |
| [OriginalResponseMessageId](#originalresponsemessageid-property) { get; set; } | ID of the original response message, present only on follow-up messages |
| [Type](#type-property) { get; set; } | Type of interaction |
| [User](#user-property) { get; set; } | User who triggered the interaction |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [BaseInteractionMetadata.cs](../../../../Oxide.Ext.Discord/Entities/BaseInteractionMetadata.cs)
   
   
# BaseInteractionMetadata constructor

The default constructor.

```csharp
public BaseInteractionMetadata()
```

## See Also

* class [BaseInteractionMetadata](./BaseInteractionMetadata.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

ID of the interaction

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [BaseInteractionMetadata](./BaseInteractionMetadata.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Type property

Type of interaction

```csharp
public InteractionType Type { get; set; }
```

## See Also

* enum [InteractionType](./InteractionType.md)
* class [BaseInteractionMetadata](./BaseInteractionMetadata.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# User property

User who triggered the interaction

```csharp
public DiscordUser User { get; set; }
```

## See Also

* class [DiscordUser](./DiscordUser.md)
* class [BaseInteractionMetadata](./BaseInteractionMetadata.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AuthorizingIntegrationOwners property

IDs for installation context(s) related to an interaction. Details in Authorizing Integration Owners Object

```csharp
public Hash<ApplicationIntegrationType, Snowflake> AuthorizingIntegrationOwners { get; set; }
```

## See Also

* enum [ApplicationIntegrationType](./ApplicationIntegrationType.md)
* struct [Snowflake](./Snowflake.md)
* class [BaseInteractionMetadata](./BaseInteractionMetadata.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OriginalResponseMessageId property

ID of the original response message, present only on follow-up messages

```csharp
public Snowflake? OriginalResponseMessageId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [BaseInteractionMetadata](./BaseInteractionMetadata.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
