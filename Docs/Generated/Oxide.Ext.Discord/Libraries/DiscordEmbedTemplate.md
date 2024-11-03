# DiscordEmbedTemplate class

Discord Template for embed

```csharp
public class DiscordEmbedTemplate : IBulkTemplate<DiscordEmbed>
```

## Public Members

| name | description |
| --- | --- |
| [DiscordEmbedTemplate](#discordembedtemplate-constructor)() | Constructor |
| [DiscordEmbedTemplate](#discordembedtemplate-constructor)(…) | Constructor |
| [Color](#color-property) { get; set; } | The Hex Color for the embed |
| [Description](#description-property) { get; set; } | The description of the embed |
| [Enabled](#enabled-property) { get; set; } | If this embed is enabled |
| [Fields](#fields-property) { get; set; } | Fields for the embed |
| [Footer](#footer-property) { get; set; } | Footer for the embed |
| [ImageUrl](#imageurl-property) { get; set; } | Image URL to show in the embed |
| [ThumbnailUrl](#thumbnailurl-property) { get; set; } | Thumbnail url to show in the embed |
| [TimeStamp](#timestamp-property) { get; set; } | Show timestamp in the embed |
| [Title](#title-property) { get; set; } | The Tile for the embed |
| [Url](#url-property) { get; set; } | This Title Url for the embed |
| [VideoUrl](#videourl-property) { get; set; } | Video url to show in the embed |
| [ToEntity](#toentity-method)(…) | Converts the template to a [`DiscordEmbed`](../Entities/DiscordEmbed.md) |
| [ToEntityBulk](#toentitybulk-method)(…) |  |

## See Also

* interface [IBulkTemplate&lt;T&gt;](../Interfaces/IBulkTemplate%7BT%7D.md)
* class [DiscordEmbed](../Entities/DiscordEmbed.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordEmbedTemplate.cs](../../../../Oxide.Ext.Discord/Libraries/DiscordEmbedTemplate.cs)
   
   
# ToEntity method

Converts the template to a [`DiscordEmbed`](../Entities/DiscordEmbed.md)

```csharp
public DiscordEmbed ToEntity(PlaceholderData data = null, DiscordEmbed embed = null)
```

| parameter | description |
| --- | --- |
| data | Data to use |
| embed | Initial embed to use |

## See Also

* class [DiscordEmbed](../Entities/DiscordEmbed.md)
* class [PlaceholderData](./PlaceholderData.md)
* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ToEntityBulk method

```csharp
public IPromise<List<DiscordEmbed>> ToEntityBulk(List<PlaceholderData> data)
```

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordEmbed](../Entities/DiscordEmbed.md)
* class [PlaceholderData](./PlaceholderData.md)
* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordEmbedTemplate constructor (1 of 2)

Constructor

```csharp
public DiscordEmbedTemplate()
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# DiscordEmbedTemplate constructor (2 of 2)

Constructor

```csharp
public DiscordEmbedTemplate(string title, string description, string titleUrl = "")
```

| parameter | description |
| --- | --- |
| title |  |
| description |  |
| titleUrl |  |

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Enabled property

If this embed is enabled

```csharp
public bool Enabled { get; set; }
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Title property

The Tile for the embed

```csharp
public string Title { get; set; }
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Url property

This Title Url for the embed

```csharp
public string Url { get; set; }
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description property

The description of the embed

```csharp
public string Description { get; set; }
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Color property

The Hex Color for the embed

```csharp
public string Color { get; set; }
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ImageUrl property

Image URL to show in the embed

```csharp
public string ImageUrl { get; set; }
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ThumbnailUrl property

Thumbnail url to show in the embed

```csharp
public string ThumbnailUrl { get; set; }
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# VideoUrl property

Video url to show in the embed

```csharp
public string VideoUrl { get; set; }
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TimeStamp property

Show timestamp in the embed

```csharp
public bool TimeStamp { get; set; }
```

## See Also

* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Fields property

Fields for the embed

```csharp
public List<DiscordEmbedFieldTemplate> Fields { get; set; }
```

## See Also

* class [DiscordEmbedFieldTemplate](./DiscordEmbedFieldTemplate.md)
* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Footer property

Footer for the embed

```csharp
public EmbedFooterTemplate Footer { get; set; }
```

## See Also

* class [EmbedFooterTemplate](./EmbedFooterTemplate.md)
* class [DiscordEmbedTemplate](./DiscordEmbedTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
