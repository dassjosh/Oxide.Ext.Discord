# DiscordSku class

Represents a [SKU Structure](https://discord.com/developers/docs/monetization/skus#sku-object-sku-structure)

```csharp
public class DiscordSku
```

## Public Members

| name | description |
| --- | --- |
| [DiscordSku](#discordsku-constructor)() | The default constructor. |
| [ApplicationId](#applicationid-property) { get; set; } | ID of the parent application |
| [Flags](#flags-property) { get; set; } | SKU flags combined as a bitfield |
| [Id](#id-property) { get; set; } | ID of SKU |
| [Name](#name-property) { get; set; } | Customer-facing name of your premium offering |
| [Slug](#slug-property) { get; set; } | System-generated URL slug based on the SKU's name |
| [Type](#type-property) { get; set; } | Type of SKU |
| [GetSkuSubscription](#getskusubscription-method)(…) | Returns all SKUs for a given application. Because of how our SKU and subscription systems work, you will see two SKUs for your premium offering. |
| [GetSkuSubscriptions](#getskusubscriptions-method)(…) | Returns all SKUs for a given application. Because of how our SKU and subscription systems work, you will see two SKUs for your premium offering. |
| static [GetSkus](#getskus-method)(…) | Returns all SKUs for a given application. Because of how our SKU and subscription systems work, you will see two SKUs for your premium offering. |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordSku.cs](../../../../Oxide.Ext.Discord/Entities/DiscordSku.cs)
   
   
# GetSkus method

Returns all SKUs for a given application. Because of how our SKU and subscription systems work, you will see two SKUs for your premium offering.

```csharp
public static IPromise<List<DiscordSku>> GetSkus(DiscordClient client, Snowflake applicationId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| applicationId | Application ID to get SKU's for |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetSkuSubscriptions method

Returns all SKUs for a given application. Because of how our SKU and subscription systems work, you will see two SKUs for your premium offering.

```csharp
public IPromise<List<DiscordSubscription>> GetSkuSubscriptions(DiscordClient client, 
    GetSkuSubscriptionsQueryString query = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| query | Query for the request |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordSubscription](./DiscordSubscription.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [GetSkuSubscriptionsQueryString](./GetSkuSubscriptionsQueryString.md)
* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetSkuSubscription method

Returns all SKUs for a given application. Because of how our SKU and subscription systems work, you will see two SKUs for your premium offering.

```csharp
public IPromise<DiscordSubscription> GetSkuSubscription(DiscordClient client, 
    Snowflake subscriptionId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| subscriptionId | ID of the subscription |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordSubscription](./DiscordSubscription.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordSku constructor

The default constructor.

```csharp
public DiscordSku()
```

## See Also

* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

ID of SKU

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Type property

Type of SKU

```csharp
public DiscordSkuType Type { get; set; }
```

## See Also

* enum [DiscordSkuType](./DiscordSkuType.md)
* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApplicationId property

ID of the parent application

```csharp
public Snowflake ApplicationId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

Customer-facing name of your premium offering

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Slug property

System-generated URL slug based on the SKU's name

```csharp
public string Slug { get; set; }
```

## See Also

* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Flags property

SKU flags combined as a bitfield

```csharp
public SkuFlags Flags { get; set; }
```

## See Also

* enum [SkuFlags](./SkuFlags.md)
* class [DiscordSku](./DiscordSku.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
