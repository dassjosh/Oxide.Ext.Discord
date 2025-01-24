# GuildMember class

Represents [Guild Member Structure](https://discord.com/developers/docs/resources/guild#guild-member-object-guild-member-structure)

```csharp
public class GuildMember : ISnowflakeEntity
```

## Public Members

| name | description |
| --- | --- |
| [GuildMember](#guildmember-constructor)() | The default constructor. |
| [Avatar](#avatar-property) { get; set; } | The member's guild avatar hash |
| [AvatarDecoration](#avatardecoration-property) { get; set; } | Data for the member's guild avatar decoration |
| [Banner](#banner-property) { get; set; } | The member's guild banner hash |
| [CommunicationDisabledUntil](#communicationdisableduntil-property) { get; set; } | When the user's timeout will expire and the user will be able to communicate in the guild again, null or a time in the past if the user is not timed out |
| [Deaf](#deaf-property) { get; set; } | Whether the user is deafened in voice channels |
| [DisplayName](#displayname-property) { get; } | Returns the display name show for the user in a guild |
| [Flags](#flags-property) { get; set; } | Flags for the GuildMember |
| [HasLeftGuild](#hasleftguild-property) { get; } | Returns if the [`GuildMember`](./GuildMember.md) has left the [`DiscordGuild`](./DiscordGuild.md) it belongs to |
| [Id](#id-property) { get; } | Id for guild member |
| [IsBot](#isbot-property) { get; } | Returns if the GuildMember is a bot |
| [JoinedAt](#joinedat-property) { get; set; } | When the user joined the guild |
| [Mute](#mute-property) { get; set; } | Whether the user is muted in voice channels |
| [Nickname](#nickname-property) { get; set; } | This users guild nickname |
| [NickNameLastUpdated](#nicknamelastupdated-property) { get; } | When the Nickname was last updated UTC. Null if we haven't seen a nickname update yet |
| [Pending](#pending-property) { get; set; } | Whether the user has not yet passed the guild's Membership Screening requirements |
| [Permissions](#permissions-property) { get; set; } | Total permissions of the member in the channel, including overrides, returned when in the interaction object |
| [PremiumSince](#premiumsince-property) { get; set; } | When the user started boosting the guild |
| [Roles](#roles-property) { get; set; } | List of member roles |
| [User](#user-property) { get; set; } | The user this guild member represents |
| [HasRole](#hasrole-method-1-of-2)(…) | Returns if member has the given role (2 methods) |

## See Also

* interface [ISnowflakeEntity](../Interfaces/ISnowflakeEntity.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [GuildMember.cs](../../../../Oxide.Ext.Discord/Entities/GuildMember.cs)
   
   
# HasRole method (1 of 2)

Returns if member has the given role

```csharp
public bool HasRole(DiscordRole role)
```

| parameter | description |
| --- | --- |
| role | Role to check |

## Return Value

Return true if has role; False otherwise;

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | Thrown if role is null |

## See Also

* class [DiscordRole](./DiscordRole.md)
* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# HasRole method (2 of 2)

Returns if member has the given role

```csharp
public bool HasRole(Snowflake roleId)
```

| parameter | description |
| --- | --- |
| roleId | Role ID to check |

## Return Value

Return true if has role; False otherwise;

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildMember constructor

The default constructor.

```csharp
public GuildMember()
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

Id for guild member

```csharp
public Snowflake Id { get; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# User property

The user this guild member represents

```csharp
public DiscordUser User { get; set; }
```

## See Also

* class [DiscordUser](./DiscordUser.md)
* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Nickname property

This users guild nickname

```csharp
public string Nickname { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Avatar property

The member's guild avatar hash

```csharp
public string Avatar { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Banner property

The member's guild banner hash

```csharp
public string Banner { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Roles property

List of member roles

```csharp
public List<Snowflake> Roles { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# JoinedAt property

When the user joined the guild

```csharp
public DateTime? JoinedAt { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# PremiumSince property

When the user started boosting the guild

```csharp
public DateTime? PremiumSince { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Permissions property

Total permissions of the member in the channel, including overrides, returned when in the interaction object

```csharp
public PermissionFlags? Permissions { get; set; }
```

## See Also

* enum [PermissionFlags](./PermissionFlags.md)
* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Deaf property

Whether the user is deafened in voice channels

```csharp
public bool Deaf { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Mute property

Whether the user is muted in voice channels

```csharp
public bool Mute { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Flags property

Flags for the GuildMember

```csharp
public GuildMemberFlags Flags { get; set; }
```

## See Also

* enum [GuildMemberFlags](./GuildMemberFlags.md)
* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Pending property

Whether the user has not yet passed the guild's Membership Screening requirements

```csharp
public bool? Pending { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CommunicationDisabledUntil property

When the user's timeout will expire and the user will be able to communicate in the guild again, null or a time in the past if the user is not timed out

```csharp
public DateTime? CommunicationDisabledUntil { get; set; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AvatarDecoration property

Data for the member's guild avatar decoration

```csharp
public AvatarDecorationData AvatarDecoration { get; set; }
```

## See Also

* class [AvatarDecorationData](./AvatarDecorationData.md)
* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# NickNameLastUpdated property

When the Nickname was last updated UTC. Null if we haven't seen a nickname update yet

```csharp
public DateTime? NickNameLastUpdated { get; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# HasLeftGuild property

Returns if the [`GuildMember`](./GuildMember.md) has left the [`DiscordGuild`](./DiscordGuild.md) it belongs to

```csharp
public bool HasLeftGuild { get; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DisplayName property

Returns the display name show for the user in a guild

```csharp
public string DisplayName { get; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsBot property

Returns if the GuildMember is a bot

```csharp
public bool IsBot { get; }
```

## See Also

* class [GuildMember](./GuildMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
