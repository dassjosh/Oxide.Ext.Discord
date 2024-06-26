# RolePlaceholders class

[`DiscordRole`](../Entities/DiscordRole.md) placeholders

```csharp
public static class RolePlaceholders
```

## Public Members

| name | description |
| --- | --- |
| static [Icon](#icon-method)(…) | [`Icon`](../Entities/DiscordRole.md#icon-property) placeholder |
| static [Id](#id-method)(…) | [`Id`](../Entities/DiscordRole.md#id-property) placeholder |
| static [Mention](#mention-method)(…) | [`Mention`](../Entities/DiscordRole.md#mention-property) placeholder |
| static [Name](#name-method)(…) | [`Name`](../Entities/DiscordRole.md#name-property) placeholder |
| static [RegisterPlaceholders](#registerplaceholders-method)(…) | Registers placeholders for the given plugin. |

## See Also

* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [RolePlaceholders.cs](../../../../Oxide.Ext.Discord/Libraries/RolePlaceholders.cs)
   
   
# Id method

[`Id`](../Entities/DiscordRole.md#id-property) placeholder

```csharp
public static Snowflake Id(DiscordRole role)
```

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordRole](../Entities/DiscordRole.md)
* class [RolePlaceholders](./RolePlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name method

[`Name`](../Entities/DiscordRole.md#name-property) placeholder

```csharp
public static string Name(DiscordRole role)
```

## See Also

* class [DiscordRole](../Entities/DiscordRole.md)
* class [RolePlaceholders](./RolePlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Mention method

[`Mention`](../Entities/DiscordRole.md#mention-property) placeholder

```csharp
public static string Mention(DiscordRole role)
```

## See Also

* class [DiscordRole](../Entities/DiscordRole.md)
* class [RolePlaceholders](./RolePlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Icon method

[`Icon`](../Entities/DiscordRole.md#icon-property) placeholder

```csharp
public static string Icon(DiscordRole role)
```

## See Also

* class [DiscordRole](../Entities/DiscordRole.md)
* class [RolePlaceholders](./RolePlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RegisterPlaceholders method

Registers placeholders for the given plugin.

```csharp
public static void RegisterPlaceholders(Plugin plugin, RoleKeys keys, PlaceholderDataKey dataKey)
```

| parameter | description |
| --- | --- |
| plugin | Plugin to register placeholders for |
| keys | Prefix to use for the placeholders |
| dataKey | Data key in [`PlaceholderData`](./PlaceholderData.md) |

## See Also

* class [RoleKeys](./RoleKeys.md)
* struct [PlaceholderDataKey](./PlaceholderDataKey.md)
* class [RolePlaceholders](./RolePlaceholders.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
