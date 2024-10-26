# DiscordStickerPack class

Represents a [Sticker Pack Object](https://discord.com/developers/docs/resources/sticker#sticker-pack-object)

```csharp
public class DiscordStickerPack
```

## Public Members

| name | description |
| --- | --- |
| [DiscordStickerPack](#discordstickerpack-constructor)() | The default constructor. |
| [BannerAssetId](#bannerassetid-property) { get; set; } | ID of the sticker pack's banner image |
| [CoverStickerId](#coverstickerid-property) { get; set; } | ID of a sticker in the pack which is shown as the pack's icon |
| [Description](#description-property) { get; set; } | Description of the sticker pack |
| [Id](#id-property) { get; set; } | ID of the sticker pack |
| [Name](#name-property) { get; set; } | Name of the sticker pack |
| [SkuId](#skuid-property) { get; set; } | ID of the pack's SKU |
| [Stickers](#stickers-property) { get; set; } | The stickers in the pack |
| static [GetStickerPack](#getstickerpack-method)(…) | Returns a sticker pack object for the given sticker pack ID. See [List Nitro Sticker Packs](https://discord.com/developers/docs/resources/sticker#get-sticker-pack) |
| static [GetStickerPacks](#getstickerpacks-method)(…) | Returns the list of sticker packs available to Nitro subscribers. See [List Nitro Sticker Packs](https://discord.com/developers/docs/resources/sticker#list-nitro-sticker-packs) |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordStickerPack.cs](../../../../Oxide.Ext.Discord/Entities/DiscordStickerPack.cs)
   
   
# GetStickerPack method

Returns a sticker pack object for the given sticker pack ID. See [List Nitro Sticker Packs](https://discord.com/developers/docs/resources/sticker#get-sticker-pack)

```csharp
public static IPromise<DiscordStickerPack> GetStickerPack(DiscordClient client, Snowflake packId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| packId | ID of the pack |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetStickerPacks method

Returns the list of sticker packs available to Nitro subscribers. See [List Nitro Sticker Packs](https://discord.com/developers/docs/resources/sticker#list-nitro-sticker-packs)

```csharp
public static IPromise<List<DiscordStickerPack>> GetStickerPacks(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordStickerPack constructor

The default constructor.

```csharp
public DiscordStickerPack()
```

## See Also

* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

ID of the sticker pack

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Stickers property

The stickers in the pack

```csharp
public List<DiscordSticker> Stickers { get; set; }
```

## See Also

* class [DiscordSticker](./DiscordSticker.md)
* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

Name of the sticker pack

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SkuId property

ID of the pack's SKU

```csharp
public Snowflake SkuId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CoverStickerId property

ID of a sticker in the pack which is shown as the pack's icon

```csharp
public Snowflake? CoverStickerId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description property

Description of the sticker pack

```csharp
public string Description { get; set; }
```

## See Also

* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BannerAssetId property

ID of the sticker pack's banner image

```csharp
public Snowflake? BannerAssetId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordStickerPack](./DiscordStickerPack.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
