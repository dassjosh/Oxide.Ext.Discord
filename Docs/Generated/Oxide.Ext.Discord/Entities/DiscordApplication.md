# DiscordApplication class

Represents [Application Structure](https://discord.com/developers/docs/resources/application#application-object)

```csharp
public class DiscordApplication : IDebugLoggable
```

## Public Members

| name | description |
| --- | --- |
| [DiscordApplication](#discordapplication-constructor)() | The default constructor. |
| [ApproximateGuildCount](#approximateguildcount-property) { get; set; } | An approximate count of the app's guild membership. |
| [ApproximateUserInstallCount](#approximateuserinstallcount-property) { get; set; } | Approximate count of users that have installed the app |
| [Bot](#bot-property) { get; set; } | Partial user object for the bot user associated with the app |
| [BotPublic](#botpublic-property) { get; set; } | When false only app owner can join the app's bot to guilds |
| [BotRequireCodeGrant](#botrequirecodegrant-property) { get; set; } | When true the app's bot will only join upon completion of the full oauth2 code grant flow |
| [CoverImage](#coverimage-property) { get; set; } | If this application is a game sold on Discord, this field will be the hash of the image on store embeds |
| [CustomInstallUrl](#custominstallurl-property) { get; set; } | The application's default custom authorization link, if enabled |
| [Description](#description-property) { get; set; } | Description of the app |
| [Flags](#flags-property) { get; set; } | App's public flags |
| [GetApplicationCoverUrl](#getapplicationcoverurl-property) { get; } | Returns the URL for the application cover |
| [GetApplicationIconUrl](#getapplicationiconurl-property) { get; } | Returns the URL for the applications Icon |
| [Guild](#guild-property) { get; set; } | Partial Guild for the application |
| [GuildId](#guildid-property) { get; set; } | Guild associated with the app. For example, a developer support server. |
| [Icon](#icon-property) { get; set; } | Icon hash of the app |
| [Id](#id-property) { get; set; } | ID of the app |
| [InstallParams](#installparams-property) { get; set; } | Settings for the application's default in-app authorization link, if enabled |
| [IntegrationTypesConfig](#integrationtypesconfig-property) { get; set; } | Default scopes and permissions for each supported installation context |
| [InteractionsEndpointUrl](#interactionsendpointurl-property) { get; set; } | Interactions endpoint URL for the app |
| [Name](#name-property) { get; set; } | Name of the app |
| [Owner](#owner-property) { get; set; } | Partial user object containing info on the owner of the application |
| [PrimarySkuId](#primaryskuid-property) { get; set; } | If this application is a game sold on Discord, this field will be the id of the "Game SKU" that is created, if exists |
| [PrivacyPolicyUrl](#privacypolicyurl-property) { get; set; } | URL of the app's privacy policy |
| [RedirectUris](#redirecturis-property) { get; set; } | Array of redirect URIs for the app |
| [RoleConnectionsVerificationUrl](#roleconnectionsverificationurl-property) { get; set; } | Role connection verification URL for the app |
| [RpcOrigins](#rpcorigins-property) { get; set; } | List of RPC origin URLs, if RPC is enabled |
| [Slug](#slug-property) { get; set; } | If this application is a game sold on Discord, this field will be the URL slug that links to the store page |
| [Tags](#tags-property) { get; set; } | Up to 5 tags describing the content and functionality of the application |
| [Team](#team-property) { get; set; } | If the application belongs to a team, this will be a list of the members of that team |
| [TermsOfServiceUrl](#termsofserviceurl-property) { get; set; } | URL of the app's terms of service |
| [Verify](#verify-property) { get; set; } | Hex encoded key for verification in interactions and the GameSDK's GetTicket |
| [BulkOverwriteGlobalCommands](#bulkoverwriteglobalcommands-method)(…) | Takes a list of application commands, overwriting existing commands that are registered globally for this application. Updates will be available in all guilds after 1 hour. See [Bulk Overwrite Global Application Commands](https://discord.com/developers/docs/interactions/application-commands#bulk-overwrite-global-application-commands) |
| [CreateApplicationEmoji](#createapplicationemoji-method)(…) | Creates a new application emoji |
| [CreateGlobalCommand](#createglobalcommand-method)(…) | Create a new global command. New global commands will be available in all guilds after 1 hour. Note: Creating a command with the same name as an existing command for your application will overwrite the old command. See [Create Global Application Command](https://discord.com/developers/docs/interactions/application-commands#create-global-application-command) |
| [CreateGuildCommand](#createguildcommand-method)(…) | Create a new guild command. New guild commands will be available in the guild immediately. See [Create Guild Application Command](https://discord.com/developers/docs/interactions/application-commands#create-guild-application-command) |
| [DeleteApplicationEmoji](#deleteapplicationemoji-method)(…) | Deletes an application emoji |
| [Edit](#edit-method)(…) | Edit properties of the app associated with the requesting bot user. Only properties that are passed will be updated. |
| [EditRoleConnectionMetadata](#editroleconnectionmetadata-method)(…) | Updates and returns a list of application role connection metadata objects for the given application. See [Update Application Role Connection Metadata Records](https://discord.com/developers/docs/resources/application-role-connection-metadata#update-application-role-connection-metadata-records) |
| [GetAllCommands](#getallcommands-method)(…) | Returns all commands registered to this application |
| [GetApplicationActivityInstance](#getapplicationactivityinstance-method)(…) | Deletes an application emoji |
| [GetApplicationEmoji](#getapplicationemoji-method)(…) | Return an application emoji by ID |
| [GetApplicationEmojis](#getapplicationemojis-method)(…) | Returns the list of all application emojis |
| [GetGlobalCommand](#getglobalcommand-method)(…) | Fetch global command by ID See [Get Global Application Command](https://discord.com/developers/docs/interactions/application-commands#get-global-application-command) |
| [GetGlobalCommands](#getglobalcommands-method)(…) | Fetch all of the global commands for your application. Returns a list of ApplicationCommand. See [Get Global Application Commands](https://discord.com/developers/docs/interactions/application-commands#get-global-application-commands)Client to useInclude Command Localizations |
| [GetGuildCommand](#getguildcommand-method)(…) | Get guild command by Id See [Get Guild Application Command](https://discord.com/developers/docs/interactions/application-commands#get-guild-application-command) |
| [GetGuildCommandPermissions](#getguildcommandpermissions-method)(…) | Fetches command permissions for all commands for your application in a guild. Returns an array of GuildApplicationCommandPermissions objects. See [Get Guild Application Command Permissions](https://discord.com/developers/docs/interactions/application-commands#get-guild-application-command-permissions) |
| [GetGuildCommands](#getguildcommands-method)(…) | Fetch all of the guild commands for your application for a specific guild. See [Get Guild Application Commands](https://discord.com/developers/docs/interactions/application-commands#get-guild-application-commands) |
| [GetRoleConnectionMetadata](#getroleconnectionmetadata-method)(…) | Returns a list of application role connection metadata objects for the given application. See [Get Application Role Connection Metadata Records](https://discord.com/developers/docs/resources/application-role-connection-metadata#get-application-role-connection-metadata-records) |
| [HasAnyApplicationFlags](#hasanyapplicationflags-method)(…) | Returns if the given application has any of the passed in application flags If [`Flags`](#flags-property) is null false is returned |
| [HasApplicationFlag](#hasapplicationflag-method)(…) | Returns if the given application has the passed in application flag If [`Flags`](#flags-property) is null false is returned |
| [LogDebug](#logdebug-method)(…) |  |
| [UpdateApplicationEmoji](#updateapplicationemoji-method)(…) | Updates an existing application emoji |
| static [Get](#get-method)(…) | Returns the current users application See [Get Current Application]() |

## See Also

* interface [IDebugLoggable](../Interfaces/IDebugLoggable.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordApplication.cs](../../../../Oxide.Ext.Discord/Entities/DiscordApplication.cs)
   
   
# HasApplicationFlag method

Returns if the given application has the passed in application flag If [`Flags`](#flags-property) is null false is returned

```csharp
public bool HasApplicationFlag(ApplicationFlags flag)
```

| parameter | description |
| --- | --- |
| flag | Flag to compare against |

## Return Value

True of application has flag; False Otherwise

## See Also

* enum [ApplicationFlags](./ApplicationFlags.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# HasAnyApplicationFlags method

Returns if the given application has any of the passed in application flags If [`Flags`](#flags-property) is null false is returned

```csharp
public bool HasAnyApplicationFlags(ApplicationFlags flag)
```

| parameter | description |
| --- | --- |
| flag | Flag to compare against |

## Return Value

True of application has flag; False Otherwise

## See Also

* enum [ApplicationFlags](./ApplicationFlags.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Get method

Returns the current users application See [Get Current Application]()

```csharp
public static IPromise<DiscordApplication> Get(DiscordClient client)
```

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Edit method

Edit properties of the app associated with the requesting bot user. Only properties that are passed will be updated.

```csharp
public IPromise<DiscordApplication> Edit(DiscordClient client, ApplicationUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Update to apply |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [ApplicationUpdate](./ApplicationUpdate.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetGlobalCommands method

Fetch all of the global commands for your application. Returns a list of ApplicationCommand. See [Get Global Application Commands](https://discord.com/developers/docs/interactions/application-commands#get-global-application-commands)Client to useInclude Command Localizations

```csharp
public IPromise<List<DiscordApplicationCommand>> GetGlobalCommands(DiscordClient client, 
    bool withLocalizations = false)
```

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetGlobalCommand method

Fetch global command by ID See [Get Global Application Command](https://discord.com/developers/docs/interactions/application-commands#get-global-application-command)

```csharp
public IPromise<DiscordApplicationCommand> GetGlobalCommand(DiscordClient client, 
    Snowflake commandId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| commandId | ID of command to get |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateGlobalCommand method

Create a new global command. New global commands will be available in all guilds after 1 hour. Note: Creating a command with the same name as an existing command for your application will overwrite the old command. See [Create Global Application Command](https://discord.com/developers/docs/interactions/application-commands#create-global-application-command)

```csharp
public IPromise<DiscordApplicationCommand> CreateGlobalCommand(DiscordClient client, 
    CommandCreate create)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| create | Command to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [CommandCreate](./CommandCreate.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BulkOverwriteGlobalCommands method

Takes a list of application commands, overwriting existing commands that are registered globally for this application. Updates will be available in all guilds after 1 hour. See [Bulk Overwrite Global Application Commands](https://discord.com/developers/docs/interactions/application-commands#bulk-overwrite-global-application-commands)

```csharp
public IPromise<List<DiscordApplicationCommand>> BulkOverwriteGlobalCommands(DiscordClient client, 
    List<CommandBulkOverwrite> commands)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| commands | List of commands to overwrite |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [CommandBulkOverwrite](./CommandBulkOverwrite.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetGuildCommands method

Fetch all of the guild commands for your application for a specific guild. See [Get Guild Application Commands](https://discord.com/developers/docs/interactions/application-commands#get-guild-application-commands)

```csharp
public IPromise<List<DiscordApplicationCommand>> GetGuildCommands(DiscordClient client, 
    Snowflake guildId, bool withLocalizations = false)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | ID of the guild to get commands for |
| withLocalizations | Include Command Localizations |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetGuildCommand method

Get guild command by Id See [Get Guild Application Command](https://discord.com/developers/docs/interactions/application-commands#get-guild-application-command)

```csharp
public IPromise<DiscordApplicationCommand> GetGuildCommand(DiscordClient client, Snowflake guildId, 
    Snowflake commandId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | ID of the guild to get commands for |
| commandId | ID of the command to get |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateGuildCommand method

Create a new guild command. New guild commands will be available in the guild immediately. See [Create Guild Application Command](https://discord.com/developers/docs/interactions/application-commands#create-guild-application-command)

```csharp
public IPromise<DiscordApplicationCommand> CreateGuildCommand(DiscordClient client, 
    Snowflake guildId, CommandCreate create)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild ID to create the command in |
| create | Command to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [CommandCreate](./CommandCreate.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetGuildCommandPermissions method

Fetches command permissions for all commands for your application in a guild. Returns an array of GuildApplicationCommandPermissions objects. See [Get Guild Application Command Permissions](https://discord.com/developers/docs/interactions/application-commands#get-guild-application-command-permissions)

```csharp
public IPromise<List<GuildCommandPermissions>> GetGuildCommandPermissions(DiscordClient client, 
    Snowflake guildId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild ID to get the permissions from |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [GuildCommandPermissions](./GuildCommandPermissions.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetAllCommands method

Returns all commands registered to this application

```csharp
public IPromise<List<DiscordApplicationCommand>> GetAllCommands(DiscordClient client, 
    bool withLocalizations = false)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| withLocalizations | Should the response include localizations |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordApplicationCommand](./DiscordApplicationCommand.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetRoleConnectionMetadata method

Returns a list of application role connection metadata objects for the given application. See [Get Application Role Connection Metadata Records](https://discord.com/developers/docs/resources/application-role-connection-metadata#get-application-role-connection-metadata-records)

```csharp
public IPromise<List<ApplicationRoleConnectionMetadata>> GetRoleConnectionMetadata(
    DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [ApplicationRoleConnectionMetadata](./ApplicationRoleConnectionMetadata.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EditRoleConnectionMetadata method

Updates and returns a list of application role connection metadata objects for the given application. See [Update Application Role Connection Metadata Records](https://discord.com/developers/docs/resources/application-role-connection-metadata#update-application-role-connection-metadata-records)

```csharp
public IPromise<List<ApplicationRoleConnectionMetadata>> EditRoleConnectionMetadata(
    DiscordClient client, List<ApplicationRoleConnectionMetadata> records)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| records | The records to update on the application |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [ApplicationRoleConnectionMetadata](./ApplicationRoleConnectionMetadata.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetApplicationEmojis method

Returns the list of all application emojis

```csharp
public IPromise<ApplicationEmojis> GetApplicationEmojis(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [ApplicationEmojis](./ApplicationEmojis.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetApplicationEmoji method

Return an application emoji by ID

```csharp
public IPromise<DiscordEmoji> GetApplicationEmoji(DiscordClient client, Snowflake emojiId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| emojiId | ID of the emoji |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordEmoji](./DiscordEmoji.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CreateApplicationEmoji method

Creates a new application emoji

```csharp
public IPromise<DiscordEmoji> CreateApplicationEmoji(DiscordClient client, 
    ApplicationEmojiCreate create)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| create | Emoji to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordEmoji](./DiscordEmoji.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [ApplicationEmojiCreate](./ApplicationEmojiCreate.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UpdateApplicationEmoji method

Updates an existing application emoji

```csharp
public IPromise<DiscordEmoji> UpdateApplicationEmoji(DiscordClient client, Snowflake emojiId, 
    ApplicationEmojiUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| emojiId | ID of the emoji to update |
| update | Update to the application emoji |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [DiscordEmoji](./DiscordEmoji.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [ApplicationEmojiUpdate](./ApplicationEmojiUpdate.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DeleteApplicationEmoji method

Deletes an application emoji

```csharp
public IPromise DeleteApplicationEmoji(DiscordClient client, Snowflake emojiId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| emojiId | ID of the emoji to delete |

## See Also

* interface [IPromise](../Interfaces/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](./Snowflake.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetApplicationActivityInstance method

Deletes an application emoji

```csharp
public IPromise<ActivityInstance> GetApplicationActivityInstance(DiscordClient client, 
    string instanceId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| instanceId | Instance ID of the activity |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* class [ActivityInstance](./ActivityInstance.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LogDebug method

```csharp
public void LogDebug(DebugLogger logger)
```

## See Also

* class [DebugLogger](../Logging/DebugLogger.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordApplication constructor

The default constructor.

```csharp
public DiscordApplication()
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

ID of the app

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

Name of the app

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Icon property

Icon hash of the app

```csharp
public string Icon { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Description property

Description of the app

```csharp
public string Description { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RpcOrigins property

List of RPC origin URLs, if RPC is enabled

```csharp
public List<string> RpcOrigins { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BotPublic property

When false only app owner can join the app's bot to guilds

```csharp
public bool BotPublic { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BotRequireCodeGrant property

When true the app's bot will only join upon completion of the full oauth2 code grant flow

```csharp
public bool BotRequireCodeGrant { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Bot property

Partial user object for the bot user associated with the app

```csharp
public DiscordUser Bot { get; set; }
```

## See Also

* class [DiscordUser](./DiscordUser.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TermsOfServiceUrl property

URL of the app's terms of service

```csharp
public string TermsOfServiceUrl { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PrivacyPolicyUrl property

URL of the app's privacy policy

```csharp
public string PrivacyPolicyUrl { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Owner property

Partial user object containing info on the owner of the application

```csharp
public DiscordUser Owner { get; set; }
```

## See Also

* class [DiscordUser](./DiscordUser.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Verify property

Hex encoded key for verification in interactions and the GameSDK's GetTicket

```csharp
public string Verify { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Team property

If the application belongs to a team, this will be a list of the members of that team

```csharp
public DiscordTeam Team { get; set; }
```

## See Also

* class [DiscordTeam](./DiscordTeam.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildId property

Guild associated with the app. For example, a developer support server.

```csharp
public Snowflake? GuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Guild property

Partial Guild for the application

```csharp
public DiscordGuild Guild { get; set; }
```

## See Also

* class [DiscordGuild](./DiscordGuild.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PrimarySkuId property

If this application is a game sold on Discord, this field will be the id of the "Game SKU" that is created, if exists

```csharp
public string PrimarySkuId { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Slug property

If this application is a game sold on Discord, this field will be the URL slug that links to the store page

```csharp
public string Slug { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CoverImage property

If this application is a game sold on Discord, this field will be the hash of the image on store embeds

```csharp
public string CoverImage { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Flags property

App's public flags

```csharp
public ApplicationFlags? Flags { get; set; }
```

## See Also

* enum [ApplicationFlags](./ApplicationFlags.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApproximateGuildCount property

An approximate count of the app's guild membership.

```csharp
public int? ApproximateGuildCount { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ApproximateUserInstallCount property

Approximate count of users that have installed the app

```csharp
public int? ApproximateUserInstallCount { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RedirectUris property

Array of redirect URIs for the app

```csharp
public List<string> RedirectUris { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# InteractionsEndpointUrl property

Interactions endpoint URL for the app

```csharp
public string InteractionsEndpointUrl { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RoleConnectionsVerificationUrl property

Role connection verification URL for the app

```csharp
public string RoleConnectionsVerificationUrl { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Tags property

Up to 5 tags describing the content and functionality of the application

```csharp
public List<string> Tags { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# InstallParams property

Settings for the application's default in-app authorization link, if enabled

```csharp
public InstallParams InstallParams { get; set; }
```

## See Also

* class [InstallParams](./InstallParams.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IntegrationTypesConfig property

Default scopes and permissions for each supported installation context

```csharp
public Hash<ApplicationIntegrationType, ApplicationIntegrationTypeConfiguration> 
    IntegrationTypesConfig { get; set; }
```

## See Also

* enum [ApplicationIntegrationType](./ApplicationIntegrationType.md)
* class [ApplicationIntegrationTypeConfiguration](./ApplicationIntegrationTypeConfiguration.md)
* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CustomInstallUrl property

The application's default custom authorization link, if enabled

```csharp
public string CustomInstallUrl { get; set; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetApplicationIconUrl property

Returns the URL for the applications Icon

```csharp
public string GetApplicationIconUrl { get; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetApplicationCoverUrl property

Returns the URL for the application cover

```csharp
public string GetApplicationCoverUrl { get; }
```

## See Also

* class [DiscordApplication](./DiscordApplication.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
