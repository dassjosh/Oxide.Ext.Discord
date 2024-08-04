# GuildUpdate class

Represents [Update Guild Structure](https://discord.com/developers/docs/resources/guild#modify-guild)

```csharp
public class GuildUpdate
```

## Public Members

| name | description |
| --- | --- |
| [GuildUpdate](#guildupdate-constructor)() | The default constructor. |
| [AfkChannelId](#afkchannelid-property) { get; set; } | ID of afk channel |
| [AfkTimeout](#afktimeout-property) { get; set; } | Afk timeout in seconds Can be set to: null, 60, 300, 900, 1800, 3600 |
| [Banner](#banner-property) { get; set; } | Image for the guild banner (when the server has the BANNER feature; can be animated gif when the server has the ANIMATED_BANNER feature) |
| [DefaultMessageNotifications](#defaultmessagenotifications-property) { get; set; } | Default message notification level |
| [Description](#description-property) { get; set; } | The description for the guild |
| [DiscoverySplash](#discoverysplash-property) { get; set; } | Image for the guild discovery splash (when the server has the DISCOVERABLE feature) |
| [ExplicitContentFilter](#explicitcontentfilter-property) { get; set; } | Explicit content filter level |
| [Features](#features-property) { get; set; } | Enabled guild features |
| [Icon](#icon-property) { get; set; } | Base64 128x128 image for the guild icon |
| [Name](#name-property) { get; set; } | Name of the guild (2-100 characters) |
| [OwnerId](#ownerid-property) { get; set; } | User id to transfer guild ownership to (must be owner) |
| [PreferredLocale](#preferredlocale-property) { get; set; } | The preferred locale of a Community guild used in server discovery and notices from Discord; defaults to "en-US" |
| [PremiumProgressBarEnabled](#premiumprogressbarenabled-property) { get; set; } | Whether the guild's boost progress bar should be enabled |
| [PublicUpdatesChannelId](#publicupdateschannelid-property) { get; set; } | The id of the channel where admins and moderators of Community guilds receive notices from Discord |
| [Region](#region-property) { get; set; } | Voice region id |
| [RulesChannelId](#ruleschannelid-property) { get; set; } | The id of the channel where Community guilds display rules and/or guidelines |
| [SafetyAlertsChannelId](#safetyalertschannelid-property) { get; set; } | The id of the channel where admins and moderators of Community guilds receive safety alerts from Discord |
| [Splash](#splash-property) { get; set; } | Image for the guild splash (when the server has the INVITE_SPLASH feature) |
| [SystemChannelFlags](#systemchannelflags-property) { get; set; } | System channel flags |
| [SystemChannelId](#systemchannelid-property) { get; set; } | The id of the channel where guild notices such as welcome messages and boost events are posted |
| [VerificationLevel](#verificationlevel-property) { get; set; } | Verification level |
| [Validate](#validate-method)() |  |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [GuildUpdate.cs](../../../../Oxide.Ext.Discord/Entities/GuildUpdate.cs)
   
   
# Validate method

```csharp
public void Validate()
```

## See Also

* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildUpdate constructor

The default constructor.

```csharp
public GuildUpdate()
```

## See Also

* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

Name of the guild (2-100 characters)

```csharp
public string Name { get; set; }
```

## See Also

* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Region property

Voice region id

```csharp
[Obsolete("Deprecated in Discord API")]
public string Region { get; set; }
```

## See Also

* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# VerificationLevel property

Verification level

```csharp
public GuildVerificationLevel? VerificationLevel { get; set; }
```

## See Also

* enum [GuildVerificationLevel](./GuildVerificationLevel.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DefaultMessageNotifications property

Default message notification level

```csharp
public DefaultNotificationLevel? DefaultMessageNotifications { get; set; }
```

## See Also

* enum [DefaultNotificationLevel](./DefaultNotificationLevel.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ExplicitContentFilter property

Explicit content filter level

```csharp
public ExplicitContentFilterLevel? ExplicitContentFilter { get; set; }
```

## See Also

* enum [ExplicitContentFilterLevel](./ExplicitContentFilterLevel.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AfkChannelId property

ID of afk channel

```csharp
public Snowflake? AfkChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AfkTimeout property

Afk timeout in seconds Can be set to: null, 60, 300, 900, 1800, 3600

```csharp
public int? AfkTimeout { get; set; }
```

## See Also

* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Icon property

Base64 128x128 image for the guild icon

```csharp
public DiscordImageData? Icon { get; set; }
```

## See Also

* struct [DiscordImageData](./DiscordImageData.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OwnerId property

User id to transfer guild ownership to (must be owner)

```csharp
public Snowflake? OwnerId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Splash property

Image for the guild splash (when the server has the INVITE_SPLASH feature)

```csharp
public DiscordImageData? Splash { get; set; }
```

## See Also

* struct [DiscordImageData](./DiscordImageData.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscoverySplash property

Image for the guild discovery splash (when the server has the DISCOVERABLE feature)

```csharp
public DiscordImageData? DiscoverySplash { get; set; }
```

## See Also

* struct [DiscordImageData](./DiscordImageData.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Banner property

Image for the guild banner (when the server has the BANNER feature; can be animated gif when the server has the ANIMATED_BANNER feature)

```csharp
public DiscordImageData? Banner { get; set; }
```

## See Also

* struct [DiscordImageData](./DiscordImageData.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SystemChannelId property

The id of the channel where guild notices such as welcome messages and boost events are posted

```csharp
public Snowflake? SystemChannelId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SystemChannelFlags property

System channel flags

```csharp
public SystemChannelFlags? SystemChannelFlags { get; set; }
```

## See Also

* enum [SystemChannelFlags](./SystemChannelFlags.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RulesChannelId property

The id of the channel where Community guilds display rules and/or guidelines

```csharp
public SystemChannelFlags? RulesChannelId { get; set; }
```

## See Also

* enum [SystemChannelFlags](./SystemChannelFlags.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PublicUpdatesChannelId property

The id of the channel where admins and moderators of Community guilds receive notices from Discord

```csharp
public SystemChannelFlags? PublicUpdatesChannelId { get; set; }
```

## See Also

* enum [SystemChannelFlags](./SystemChannelFlags.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PreferredLocale property

The preferred locale of a Community guild used in server discovery and notices from Discord; defaults to "en-US"

```csharp
public string PreferredLocale { get; set; }
```

## See Also

* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Features property

Enabled guild features

```csharp
public List<GuildFeatures> Features { get; set; }
```

## See Also

* enum [GuildFeatures](./GuildFeatures.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description property

The description for the guild

```csharp
public string Description { get; set; }
```

## See Also

* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PremiumProgressBarEnabled property

Whether the guild's boost progress bar should be enabled

```csharp
public bool? PremiumProgressBarEnabled { get; set; }
```

## See Also

* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# SafetyAlertsChannelId property

The id of the channel where admins and moderators of Community guilds receive safety alerts from Discord

```csharp
public SystemChannelFlags? SafetyAlertsChannelId { get; set; }
```

## See Also

* enum [SystemChannelFlags](./SystemChannelFlags.md)
* class [GuildUpdate](./GuildUpdate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
