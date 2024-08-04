# ApplicationCommandBuilder class

Builder to use when building application commands

```csharp
public class ApplicationCommandBuilder
```

## Public Members

| name | description |
| --- | --- |
| [ApplicationCommandBuilder](#applicationcommandbuilder-constructor-1-of-2)(…) | Creates a new Application Command Builder (2 constructors) |
| readonly [CommandName](#commandname-field) | The Name of the command |
| [AddDefaultPermissions](#adddefaultpermissions-method)(…) | Adds default command permissions |
| [AddDescriptionLocalization](#adddescriptionlocalization-method)(…) | Adds Application Command Description Localizations |
| [AddDescriptionLocalizations](#adddescriptionlocalizations-method)(…) | Adds command description localizations for a given plugin and lang key |
| [AddNameLocalization](#addnamelocalization-method)(…) | Adds Application Command Name Localizations |
| [AddNameLocalizations](#addnamelocalizations-method)(…) | Adds command name localizations for a given plugin and lang key |
| [AddOption](#addoption-method)(…) | Adds a command option. |
| [AddSubCommand](#addsubcommand-method)(…) | Adds a sub command to the root command |
| [AddSubCommandGroup](#addsubcommandgroup-method)(…) | Creates a new SubCommandGroup SubCommandGroups contain subcommands Your root command can only contain |
| [AllowInDirectMessages](#allowindirectmessages-method)(…) | Allows the command to be used in a direct message |
| [Build](#build-method)() | Returns the created command |
| [BuildCommandLocalization](#buildcommandlocalization-method)(…) | Returns a built [`DiscordCommandLocalization`](../Libraries/DiscordCommandLocalization.md) using the provided name / descriptions as the default |

## See Also

* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [ApplicationCommandBuilder.cs](../../../../Oxide.Ext.Discord/Builders/ApplicationCommandBuilder.cs)
   
   
# AddDefaultPermissions method

Adds default command permissions

```csharp
public ApplicationCommandBuilder AddDefaultPermissions(PermissionFlags permissions)
```

| parameter | description |
| --- | --- |
| permissions | Default Permissions for the command |

## See Also

* enum [PermissionFlags](../Entities/PermissionFlags.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AllowInDirectMessages method

Allows the command to be used in a direct message

```csharp
public ApplicationCommandBuilder AllowInDirectMessages(bool allow)
```

| parameter | description |
| --- | --- |
| allow | Allows a command to be used in a direct message |

## See Also

* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddNameLocalizations method

Adds command name localizations for a given plugin and lang key

```csharp
[Obsolete("AddNameLocalizations(Plugin plugin, string langKey) has been deprecated and will be removed in the future. Please use AddNameLocalization(string name, string lang) instead")]
public ApplicationCommandBuilder AddNameLocalizations(Plugin plugin, string langKey)
```

| parameter | description |
| --- | --- |
| plugin | Plugin containing the localizations |
| langKey | Lang Key containing the localized text |

## See Also

* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddNameLocalization method

Adds Application Command Name Localizations

```csharp
public ApplicationCommandBuilder AddNameLocalization(string name, ServerLocale serverLocale)
```

| parameter | description |
| --- | --- |
| name | Localized name value |
| serverLocale | Oxide lang the value is in |

## Return Value

This

## See Also

* struct [ServerLocale](../Libraries/ServerLocale.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddDescriptionLocalizations method

Adds command description localizations for a given plugin and lang key

```csharp
[Obsolete("AddDescriptionLocalizations(Plugin plugin, string langKey) has been deprecated and will be removed in the future. Please use AddDescriptionLocalization(string name, string lang) instead")]
public ApplicationCommandBuilder AddDescriptionLocalizations(Plugin plugin, string langKey)
```

| parameter | description |
| --- | --- |
| plugin | Plugin containing the localizations |
| langKey | Lang Key containing the localized text |

## See Also

* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddDescriptionLocalization method

Adds Application Command Description Localizations

```csharp
public ApplicationCommandBuilder AddDescriptionLocalization(string description, 
    ServerLocale serverLocale)
```

| parameter | description |
| --- | --- |
| description | Localized description value |
| serverLocale | Oxide lang the value is in |

## Return Value

This

## See Also

* struct [ServerLocale](../Libraries/ServerLocale.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddSubCommandGroup method

Creates a new SubCommandGroup SubCommandGroups contain subcommands Your root command can only contain

```csharp
public ApplicationCommandBuilder AddSubCommandGroup(string name, string description, 
    Action<ApplicationCommandGroupBuilder> builder)
```

| parameter | description |
| --- | --- |
| name | Name of the command |
| description | Description of the command |
| builder | Callback with the [`ApplicationCommandGroupBuilder`](./ApplicationCommandGroupBuilder.md) |

## Return Value

this

## Exceptions

| exception | condition |
| --- | --- |
| Exception | Thrown if trying to add a subcommand group to |

## See Also

* class [ApplicationCommandGroupBuilder](./ApplicationCommandGroupBuilder.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddSubCommand method

Adds a sub command to the root command

```csharp
public ApplicationCommandBuilder AddSubCommand(string name, string description, 
    Action<ApplicationSubCommandBuilder> builder = null)
```

| parameter | description |
| --- | --- |
| name | Name of the sub command |
| description | Description for the sub command |
| builder | Callback with the [`ApplicationSubCommandBuilder`](./ApplicationSubCommandBuilder.md)"/&gt; |

## Return Value

this

## Exceptions

| exception | condition |
| --- | --- |
| Exception | Thrown if previous type was not SubCommand or Creation type is not ChatInput |

## See Also

* class [ApplicationSubCommandBuilder](./ApplicationSubCommandBuilder.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddOption method

Adds a command option.

```csharp
public ApplicationCommandBuilder AddOption(CommandOptionType type, string name, string description, 
    Action<ApplicationCommandOptionBuilder> builder = null)
```

| parameter | description |
| --- | --- |
| type | The type of option. Cannot be SubCommand or SubCommandGroup |
| name | Name of the option |
| description | Description for the option |
| builder | Callback with the [`ApplicationCommandOptionBuilder`](./ApplicationCommandOptionBuilder.md) |

## Return Value

this

## See Also

* enum [CommandOptionType](../Entities/CommandOptionType.md)
* class [ApplicationCommandOptionBuilder](./ApplicationCommandOptionBuilder.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Build method

Returns the created command

```csharp
public CommandCreate Build()
```

## See Also

* class [CommandCreate](../Entities/CommandCreate.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BuildCommandLocalization method

Returns a built [`DiscordCommandLocalization`](../Libraries/DiscordCommandLocalization.md) using the provided name / descriptions as the default

```csharp
public DiscordCommandLocalization BuildCommandLocalization(string lang = "en")
```

## See Also

* class [DiscordCommandLocalization](../Libraries/DiscordCommandLocalization.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApplicationCommandBuilder constructor (1 of 2)

Creates a new Application Command Builder

```csharp
public ApplicationCommandBuilder(string name, string description, ApplicationCommandType type)
```

| parameter | description |
| --- | --- |
| name | Name of the command |
| description | Description of the command |
| type | Command type |

## See Also

* enum [ApplicationCommandType](../Entities/ApplicationCommandType.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ApplicationCommandBuilder constructor (2 of 2)

Creates a new Application Command Builder

```csharp
public ApplicationCommandBuilder(string name, string description, ApplicationCommandType type, 
    ServerLocale defaultLanguage)
```

| parameter | description |
| --- | --- |
| name | Name of the command |
| description | Description of the command |
| type | Command type |
| defaultLanguage | Language the application command is being created in |

## See Also

* enum [ApplicationCommandType](../Entities/ApplicationCommandType.md)
* struct [ServerLocale](../Libraries/ServerLocale.md)
* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CommandName field

The Name of the command

```csharp
public readonly string CommandName;
```

## See Also

* class [ApplicationCommandBuilder](./ApplicationCommandBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
