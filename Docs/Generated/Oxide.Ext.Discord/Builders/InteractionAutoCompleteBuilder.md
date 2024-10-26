# InteractionAutoCompleteBuilder class

Builder for Auto Complete Interaction

```csharp
public class InteractionAutoCompleteBuilder
```

## Public Members

| name | description |
| --- | --- |
| [InteractionAutoCompleteBuilder](#interactionautocompletebuilder-constructor)(…) | Constructor |
| [Count](#count-property) { get; } | Number of added choices |
| [AddAllOnlineFirstPlayers](#addallonlinefirstplayers-method)(…) | Adds Online Players to the list first If there is still space add Offline Players |
| [AddAllPlayers](#addallplayers-method)(…) | Adds Any Player to the list |
| [AddAllPlugins](#addallplugins-method)(…) | Adds a list of all plugins in the oxide/plugins folder. Includes loaded and unloaded. |
| [AddByPlayerId](#addbyplayerid-method)(…) | Adds a player by player ID to the list |
| [AddChoice](#addchoice-method-1-of-3)(…) | Adds a [`CommandOptionChoice`](../Entities/CommandOptionChoice.md) to the response (3 methods) |
| [AddChoices](#addchoices-method)(…) | Adds a collection of [`CommandOptionChoice`](../Entities/CommandOptionChoice.md) to the response |
| [AddGroups](#addgroups-method)(…) | Adds Oxide Groups to the AutoComplete |
| [AddGroupsWithoutPermission](#addgroupswithoutpermission-method)(…) | Adds The List of Groups that have this permission |
| [AddGroupsWithoutPlayer](#addgroupswithoutplayer-method)(…) | Adds The List of Groups that playerId has |
| [AddGroupsWithPermission](#addgroupswithpermission-method)(…) | Adds The List of Groups that have this permission |
| [AddGroupsWithPlayer](#addgroupswithplayer-method)(…) | Adds The List of Groups that playerId has |
| [AddLoadablePlugins](#addloadableplugins-method)(…) | Adds a list of plugins that can be loaded |
| [AddLoadedPlugins](#addloadedplugins-method)(…) | Adds a list of plugins that are currently loaded |
| [AddOfflinePlayers](#addofflineplayers-method)(…) | Adds Online Players to the list |
| [AddOnlinePlayers](#addonlineplayers-method)(…) | Adds Online Players to the list |
| [AddPermissions](#addpermissions-method)(…) | Adds Oxide Permissions to the AutoComplete |
| [AddPermissionsInGroup](#addpermissionsingroup-method)(…) | Adds List of Permissions that are in the given group |
| [AddPermissionsNotInGroup](#addpermissionsnotingroup-method)(…) | Adds a List of Permissions that are not in a given group |
| [AddPermissionsPlayerIn](#addpermissionsplayerin-method)(…) | Adds The List of Permissions that playerId has |
| [AddPermissionsPlayerNotIn](#addpermissionsplayernotin-method)(…) | Adds The List of Permissions that playerId does not have |
| [AddPlayerList](#addplayerlist-method-1-of-2)(…) | Add a custom list of players that are filtered by player name or player ID (2 methods) |
| [Build](#build-method)() | Returns the built message |
| [CanAddChoice](#canaddchoice-method)() | Returns if the Auto Complete can add any more choices |

## See Also

* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [InteractionAutoCompleteBuilder.cs](../../../../Oxide.Ext.Discord/Builders/InteractionAutoCompleteBuilder.cs)
   
   
# AddChoice method (1 of 3)

Adds a [`CommandOptionChoice`](../Entities/CommandOptionChoice.md) to the response

```csharp
public InteractionAutoCompleteBuilder AddChoice(CommandOptionChoice choice)
```

| parameter | description |
| --- | --- |
| choice | Choice to be added |

## Return Value

This

## See Also

* class [CommandOptionChoice](../Entities/CommandOptionChoice.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AddChoice method (2 of 3)

Adds a [`CommandOptionChoice`](../Entities/CommandOptionChoice.md) to the response

```csharp
public InteractionAutoCompleteBuilder AddChoice(string name, object value)
```

| parameter | description |
| --- | --- |
| name | Name of the choice |
| value | Value of the choice |

## Return Value

This

## See Also

* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AddChoice method (3 of 3)

Adds a [`CommandOptionChoice`](../Entities/CommandOptionChoice.md) to the response

```csharp
public InteractionAutoCompleteBuilder AddChoice(string name, object value, Plugin plugin, 
    string langKey)
```

| parameter | description |
| --- | --- |
| name | Name of the choice |
| value | Value of the choice |
| plugin | Plugin to lookup the langkey for |
| langKey | Lang key for the name |

## Return Value

This

## See Also

* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddChoices method

Adds a collection of [`CommandOptionChoice`](../Entities/CommandOptionChoice.md) to the response

```csharp
public InteractionAutoCompleteBuilder AddChoices(ICollection<CommandOptionChoice> choices)
```

| parameter | description |
| --- | --- |
| choices | Choices to be added |

## Return Value

This

## See Also

* class [CommandOptionChoice](../Entities/CommandOptionChoice.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CanAddChoice method

Returns if the Auto Complete can add any more choices

```csharp
public bool CanAddChoice()
```

## See Also

* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Build method

Returns the built message

```csharp
public InteractionAutoCompleteMessage Build()
```

## Return Value

[`InteractionAutoCompleteMessage`](../Entities/InteractionAutoCompleteMessage.md)

## See Also

* class [InteractionAutoCompleteMessage](../Entities/InteractionAutoCompleteMessage.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddGroups method

Adds Oxide Groups to the AutoComplete

```csharp
public void AddGroups(string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddPermissions method

Adds Oxide Permissions to the AutoComplete

```csharp
public void AddPermissions(string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddGroupsWithPermission method

Adds The List of Groups that have this permission

```csharp
public void AddGroupsWithPermission(string permission, string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| permission | Permission to get groups for |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddGroupsWithoutPermission method

Adds The List of Groups that have this permission

```csharp
public void AddGroupsWithoutPermission(string permission, string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| permission | Permission to get groups for |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddPermissionsInGroup method

Adds List of Permissions that are in the given group

```csharp
public void AddPermissionsInGroup(string group, string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| group | Group to get permissions for |
| filter | Permission filter |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddPermissionsNotInGroup method

Adds a List of Permissions that are not in a given group

```csharp
public void AddPermissionsNotInGroup(string group, string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| group | Group that doesn't have the permissions |
| filter | Permission filter |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddGroupsWithPlayer method

Adds The List of Groups that playerId has

```csharp
public void AddGroupsWithPlayer(string playerId, string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| playerId | Player ID to get groups for |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddGroupsWithoutPlayer method

Adds The List of Groups that playerId has

```csharp
public void AddGroupsWithoutPlayer(string playerId, string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| playerId | Player ID to get groups for |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddPermissionsPlayerIn method

Adds The List of Permissions that playerId has

```csharp
public void AddPermissionsPlayerIn(string playerId, string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| playerId | Player ID to get permissions for |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddPermissionsPlayerNotIn method

Adds The List of Permissions that playerId does not have

```csharp
public void AddPermissionsPlayerNotIn(string playerId, string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| playerId | Player ID to get permissions for |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddOnlinePlayers method

Adds Online Players to the list

```csharp
public void AddOnlinePlayers(string filter = null, PlayerNameFormatter formatter = null)
```

| parameter | description |
| --- | --- |
| filter | String to filter by |
| formatter | Formatter for the player name |

## See Also

* class [PlayerNameFormatter](./PlayerNameFormatter.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddOfflinePlayers method

Adds Online Players to the list

```csharp
public void AddOfflinePlayers(string filter = null, PlayerNameFormatter formatter = null)
```

| parameter | description |
| --- | --- |
| filter | String to filter by |
| formatter | Formatter for the player name |

## See Also

* class [PlayerNameFormatter](./PlayerNameFormatter.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddAllOnlineFirstPlayers method

Adds Online Players to the list first If there is still space add Offline Players

```csharp
public void AddAllOnlineFirstPlayers(string filter = null, PlayerNameFormatter formatter = null)
```

| parameter | description |
| --- | --- |
| filter | String to filter by |
| formatter | Formatter for the player name |

## See Also

* class [PlayerNameFormatter](./PlayerNameFormatter.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddAllPlayers method

Adds Any Player to the list

```csharp
public void AddAllPlayers(string filter = null, PlayerNameFormatter formatter = null)
```

| parameter | description |
| --- | --- |
| filter | String to filter by |
| formatter | Formatter for the player name |

## See Also

* class [PlayerNameFormatter](./PlayerNameFormatter.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddPlayerList method (1 of 2)

Adds a list of players from a custom list

```csharp
public void AddPlayerList(IEnumerable<IPlayer> list, PlayerNameFormatter formatter, 
    HashSet<string> addedList)
```

| parameter | description |
| --- | --- |
| list | Custom list of players |
| formatter | Formatter for the player name |
| addedList | List of already added players |

## See Also

* class [PlayerNameFormatter](./PlayerNameFormatter.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# AddPlayerList method (2 of 2)

Add a custom list of players that are filtered by player name or player ID

```csharp
public void AddPlayerList(string filter, IEnumerable<IPlayer> list, PlayerNameFormatter formatter, 
    HashSet<string> addedList = null, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.Contains)
```

| parameter | description |
| --- | --- |
| filter | Filter to filter by |
| list | Custom list of players |
| formatter | Formatter for the player name |
| addedList | List of already added players |
| search | Mode to match on player name |

## See Also

* class [PlayerNameFormatter](./PlayerNameFormatter.md)
* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddByPlayerId method

Adds a player by player ID to the list

```csharp
public void AddByPlayerId(string playerId, PlayerNameFormatter formatter = null)
```

| parameter | description |
| --- | --- |
| playerId | Player ID to add |
| formatter | Formatter for the player name |

## See Also

* class [PlayerNameFormatter](./PlayerNameFormatter.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddLoadablePlugins method

Adds a list of plugins that can be loaded

```csharp
public void AddLoadablePlugins(string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddAllPlugins method

Adds a list of all plugins in the oxide/plugins folder. Includes loaded and unloaded.

```csharp
public void AddAllPlugins(string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AddLoadedPlugins method

Adds a list of plugins that are currently loaded

```csharp
public void AddLoadedPlugins(string filter = null, 
    StringComparison comparison = StringComparison.OrdinalIgnoreCase, 
    AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
```

| parameter | description |
| --- | --- |
| filter | String to filter by |
| comparison | StringComparison to use |
| search | [`AutoCompleteSearchMode`](./AutoCompleteSearchMode.md) Filter search mode |

## See Also

* enum [AutoCompleteSearchMode](./AutoCompleteSearchMode.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# InteractionAutoCompleteBuilder constructor

Constructor

```csharp
public InteractionAutoCompleteBuilder(DiscordInteraction interaction, 
    InteractionAutoCompleteMessage message = null)
```

| parameter | description |
| --- | --- |
| interaction | Interaction this build is for |
| message | Starting [`InteractionAutoCompleteMessage`](../Entities/InteractionAutoCompleteMessage.md) |

## See Also

* class [DiscordInteraction](../Entities/DiscordInteraction.md)
* class [InteractionAutoCompleteMessage](../Entities/InteractionAutoCompleteMessage.md)
* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Count property

Number of added choices

```csharp
public int Count { get; }
```

## See Also

* class [InteractionAutoCompleteBuilder](./InteractionAutoCompleteBuilder.md)
* namespace [Oxide.Ext.Discord.Builders](./BuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
