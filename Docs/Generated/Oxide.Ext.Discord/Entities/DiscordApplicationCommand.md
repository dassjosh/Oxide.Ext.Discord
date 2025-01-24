# DiscordApplicationCommand class

Represents [ApplicationCommand](https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-structure)

```csharp
public class DiscordApplicationCommand
```

## Public Members

| name | description |
| --- | --- |
| [DiscordApplicationCommand](#discordapplicationcommand-constructor)() | The default constructor. |
| [ApplicationId](#applicationid-property) { get; set; } | ID of the parent application |
| [Contexts](#contexts-property) { get; set; } | Interaction context(s) where the command can be used, only for globally-scoped commands. By default, all interaction context types included for new commands.. |
| [DefaultMemberPermissions](#defaultmemberpermissions-property) { get; set; } | Set of permissions represented as a bit set |
| [Description](#description-property) { get; set; } | Description of the command (1-100 characters) |
| [DescriptionLocalizations](#descriptionlocalizations-property) { get; set; } | Localization dictionary for the description field. Values follow the same restrictions as description |
| [DmPermission](#dmpermission-property) { get; set; } | Indicates whether the command is available in DMs with the app, only for globally-scoped commands. By default, commands are visible. |
| [GuildId](#guildid-property) { get; set; } | Guild ID of the command, if not global |
| [Handler](#handler-property) { get; set; } | Determines whether the interaction is handled by the app's interactions handler or by Discord |
| [Id](#id-property) { get; set; } | Unique id of the command |
| [IntegrationTypes](#integrationtypes-property) { get; set; } | Installation context(s) where the command is available, only for globally-scoped commands. Defaults to GUILD_INSTALL (0) |
| [Mention](#mention-property) { get; } | Mention the [`DiscordApplicationCommand`](./DiscordApplicationCommand.md) |
| [Name](#name-property) { get; set; } | 1-32 lowercase character name matching ^[\w-]{1,32}$ |
| [NameLocalizations](#namelocalizations-property) { get; set; } | Localization dictionary for the name field. Values follow the same restrictions as name |
| [Nsfw](#nsfw-property) { get; set; } | Indicates whether the command is age-restricted |
| [Options](#options-property) { get; set; } | The parameters for the command See [`CommandOption`](./CommandOption.md) |
| [Type](#type-property) { get; set; } | The type of command, defaults to 1 |
| [Version](#version-property) { get; set; } | Auto incrementing version identifier updated during substantial record changes |
| [Delete](#delete-method)(…) | Deletes a command See [Delete Global Application Command](https://discord.com/developers/docs/interactions/application-commands#delete-global-application-command) See [Delete Guild Application Command](https://discord.com/developers/docs/interactions/application-commands#delete-guild-application-command) |
| [Edit](#edit-method)(…) | Edit a command. Updates will be available in all guilds after 1 hour. See [Edit Global Application Command](https://discord.com/developers/docs/interactions/application-commands#edit-global-application-command) See [Edit Guild Application Command](https://discord.com/developers/docs/interactions/application-commands#edit-guild-application-command) |
| [EditPermissions](#editpermissions-method)(…) | Edits command permissions for a specific command for your application in a guild. Warning: This endpoint will overwrite existing permissions for the command in that guild Warning: Deleting or renaming a command will permanently delete all permissions for that command See [Edit Application Command Permissions](https://discord.com/developers/docs/interactions/application-commands#edit-application-command-permissions) |
| [GetPermissions](#getpermissions-method)(…) | Fetches command permissions for a specific command for your application in a guild. Returns a [`GuildCommandPermissions`](./GuildCommandPermissions.md) object. See [Get Application Command Permissions](https://discord.com/developers/docs/interactions/application-commands#get-application-command-permissions) |
| [MentionCustom](#mentioncustom-method)(…) | Mention the [`DiscordApplicationCommand`](./DiscordApplicationCommand.md) using a custom command string |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordApplicationCommand.cs](../../../../Oxide.Ext.Discord/Entities/DiscordApplicationCommand.cs)
   
   
# MentionCustom method

Mention the [`DiscordApplicationCommand`](./DiscordApplicationCommand.md) using a custom command string

```csharp
public string MentionCustom(string command)
```

| parameter | description |
| --- | --- |
| command | Custom commands string |

## Return Value

Mentioned Custom Command string

## See Also

* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Edit method

Edit a command. Updates will be available in all guilds after 1 hour. See [Edit Global Application Command](https://discord.com/developers/docs/interactions/application-commands#edit-global-application-command) See [Edit Guild Application Command](https://discord.com/developers/docs/interactions/application-commands#edit-guild-application-command)

```csharp
public IPromise<DiscordApplicationCommand> Edit(DiscordClient client, CommandUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Command Update |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [CommandUpdate](./CommandUpdate.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Delete method

Deletes a command See [Delete Global Application Command](https://discord.com/developers/docs/interactions/application-commands#delete-global-application-command) See [Delete Guild Application Command](https://discord.com/developers/docs/interactions/application-commands#delete-guild-application-command)

```csharp
public IPromise Delete(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetPermissions method

Fetches command permissions for a specific command for your application in a guild. Returns a [`GuildCommandPermissions`](./GuildCommandPermissions.md) object. See [Get Application Command Permissions](https://discord.com/developers/docs/interactions/application-commands#get-application-command-permissions)

```csharp
public IPromise<GuildCommandPermissions> GetPermissions(DiscordClient client, Snowflake guildId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild ID of the guild to get permissions for |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildCommandPermissions](./GuildCommandPermissions.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditPermissions method

Edits command permissions for a specific command for your application in a guild. Warning: This endpoint will overwrite existing permissions for the command in that guild Warning: Deleting or renaming a command will permanently delete all permissions for that command See [Edit Application Command Permissions](https://discord.com/developers/docs/interactions/application-commands#edit-application-command-permissions)

```csharp
public IPromise EditPermissions(DiscordClient client, Snowflake guildId, 
    CommandUpdatePermissions permissions)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild ID of the guild to edit permissions for |
| permissions | List of permissions for the command |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [CommandUpdatePermissions](./CommandUpdatePermissions.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordApplicationCommand constructor

The default constructor.

```csharp
public DiscordApplicationCommand()
```

## See Also

* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

Unique id of the command

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Type property

The type of command, defaults to 1

```csharp
public ApplicationCommandType? Type { get; set; }
```

## See Also

* enum [ApplicationCommandType](./ApplicationCommandType.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApplicationId property

ID of the parent application

```csharp
public Snowflake ApplicationId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildId property

Guild ID of the command, if not global

```csharp
public Snowflake? GuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

1-32 lowercase character name matching ^[\w-]{1,32}$

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# NameLocalizations property

Localization dictionary for the name field. Values follow the same restrictions as name

```csharp
public Hash<string, string> NameLocalizations { get; set; }
```

## See Also

* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description property

Description of the command (1-100 characters)

```csharp
public string Description { get; set; }
```

## See Also

* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DescriptionLocalizations property

Localization dictionary for the description field. Values follow the same restrictions as description

```csharp
public Hash<string, string> DescriptionLocalizations { get; set; }
```

## See Also

* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Options property

The parameters for the command See [`CommandOption`](./CommandOption.md)

```csharp
public List<CommandOption> Options { get; set; }
```

## See Also

* class [CommandOption](./CommandOption.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DefaultMemberPermissions property

Set of permissions represented as a bit set

```csharp
public PermissionFlags DefaultMemberPermissions { get; set; }
```

## See Also

* enum [PermissionFlags](./PermissionFlags.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DmPermission property

Indicates whether the command is available in DMs with the app, only for globally-scoped commands. By default, commands are visible.

```csharp
public bool? DmPermission { get; set; }
```

## See Also

* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Nsfw property

Indicates whether the command is age-restricted

```csharp
public bool? Nsfw { get; set; }
```

## See Also

* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IntegrationTypes property

Installation context(s) where the command is available, only for globally-scoped commands. Defaults to GUILD_INSTALL (0)

```csharp
public List<ApplicationIntegrationType> IntegrationTypes { get; set; }
```

## See Also

* enum [ApplicationIntegrationType](./ApplicationIntegrationType.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Contexts property

Interaction context(s) where the command can be used, only for globally-scoped commands. By default, all interaction context types included for new commands..

```csharp
public List<InteractionContextTypes> Contexts { get; set; }
```

## See Also

* enum [InteractionContextTypes](./InteractionContextTypes.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Version property

Auto incrementing version identifier updated during substantial record changes

```csharp
public Snowflake Version { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Handler property

Determines whether the interaction is handled by the app's interactions handler or by Discord

```csharp
public ApplicationCommandHandlerType Handler { get; set; }
```

## See Also

* enum [ApplicationCommandHandlerType](./ApplicationCommandHandlerType.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Mention property

Mention the [`DiscordApplicationCommand`](./DiscordApplicationCommand.md)

```csharp
public string Mention { get; }
```

## See Also

* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
