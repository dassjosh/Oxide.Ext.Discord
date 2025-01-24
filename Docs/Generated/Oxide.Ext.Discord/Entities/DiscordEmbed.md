# DiscordEmbed class

Represents [Embed Structure](https://discord.com/developers/docs/resources/channel#embed-object)

```csharp
public class DiscordEmbed
```

## Public Members

| name | description |
| --- | --- |
| [DiscordEmbed](#discordembed-constructor)() | The default constructor. |
| [Author](#author-property) { get; set; } | Author information [`EmbedAuthor`](./EmbedAuthor.md) |
| [Color](#color-property) { get; set; } | Color code of the embed |
| [Description](#description-property) { get; set; } | Description of embed |
| [Fields](#fields-property) { get; set; } | Fields information [`EmbedField`](./EmbedField.md) |
| [Footer](#footer-property) { get; set; } | Footer information [`EmbedFooter`](./EmbedFooter.md) |
| [Image](#image-property) { get; set; } | Image information [`EmbedImage`](./EmbedImage.md) |
| [Provider](#provider-property) { get; set; } | Provider information [`EmbedProvider`](./EmbedProvider.md) |
| [Thumbnail](#thumbnail-property) { get; set; } | Thumbnail information [`EmbedThumbnail`](./EmbedThumbnail.md) |
| [Timestamp](#timestamp-property) { get; set; } | Timestamp of embed content |
| [Title](#title-property) { get; set; } | Title of embed |
| [Type](#type-property) { get; set; } | Type of embed (always "rich" for webhook embeds) |
| [Url](#url-property) { get; set; } | Url of embed |
| [Video](#video-property) { get; set; } | Video information [`EmbedVideo`](./EmbedVideo.md) |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordEmbed.cs](../../../../Oxide.Ext.Discord/Entities/DiscordEmbed.cs)
   
   
# DiscordEmbed constructor

The default constructor.

```csharp
public DiscordEmbed()
```

## See Also

* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Title property

Title of embed

```csharp
public string Title { get; set; }
```

## See Also

* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Type property

Type of embed (always "rich" for webhook embeds)

```csharp
public EmbedType Type { get; set; }
```

## See Also

* enum [EmbedType](./EmbedType.md)
* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description property

Description of embed

```csharp
public string Description { get; set; }
```

## See Also

* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Url property

Url of embed

```csharp
public string Url { get; set; }
```

## See Also

* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Timestamp property

Timestamp of embed content

```csharp
public DateTime? Timestamp { get; set; }
```

## See Also

* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Color property

Color code of the embed

```csharp
public DiscordColor? Color { get; set; }
```

## See Also

* struct [DiscordColor](./DiscordColor.md)
* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Footer property

Footer information [`EmbedFooter`](./EmbedFooter.md)

```csharp
public EmbedFooter Footer { get; set; }
```

## See Also

* class [EmbedFooter](./EmbedFooter.md)
* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Image property

Image information [`EmbedImage`](./EmbedImage.md)

```csharp
public EmbedImage Image { get; set; }
```

## See Also

* class [EmbedImage](./EmbedImage.md)
* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Thumbnail property

Thumbnail information [`EmbedThumbnail`](./EmbedThumbnail.md)

```csharp
public EmbedThumbnail Thumbnail { get; set; }
```

## See Also

* class [EmbedThumbnail](./EmbedThumbnail.md)
* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Video property

Video information [`EmbedVideo`](./EmbedVideo.md)

```csharp
public EmbedVideo Video { get; set; }
```

## See Also

* class [EmbedVideo](./EmbedVideo.md)
* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Provider property

Provider information [`EmbedProvider`](./EmbedProvider.md)

```csharp
public EmbedProvider Provider { get; set; }
```

## See Also

* class [EmbedProvider](./EmbedProvider.md)
* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Author property

Author information [`EmbedAuthor`](./EmbedAuthor.md)

```csharp
public EmbedAuthor Author { get; set; }
```

## See Also

* class [EmbedAuthor](./EmbedAuthor.md)
* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Fields property

Fields information [`EmbedField`](./EmbedField.md)

```csharp
public List<EmbedField> Fields { get; set; }
```

## See Also

* class [EmbedField](./EmbedField.md)
* class [DiscordEmbed](./DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
