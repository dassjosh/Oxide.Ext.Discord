# TeamMember class

Represents [Team Members Object](https://discord.com/developers/docs/topics/teams#data-models-team-members-object)

```csharp
public class TeamMember
```

## Public Members

| name | description |
| --- | --- |
| [TeamMember](#teammember-constructor)() | The default constructor. |
| [MembershipState](#membershipstate-property) { get; set; } | The user's membership state on the team |
| [Permissions](#permissions-property) { get; set; } | The teams permissions Will always be ["*"] |
| [TeamId](#teamid-property) { get; set; } | The id of the parent team of which they are a member |
| [User](#user-property) { get; set; } | The avatar, discriminator, id, and username of the user |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [TeamMember.cs](../../../../Oxide.Ext.Discord/Entities/TeamMember.cs)
   
   
# TeamMember constructor

The default constructor.

```csharp
public TeamMember()
```

## See Also

* class [TeamMember](./TeamMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MembershipState property

The user's membership state on the team

```csharp
public TeamMembershipState MembershipState { get; set; }
```

## See Also

* enum [TeamMembershipState](./TeamMembershipState.md)
* class [TeamMember](./TeamMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Permissions property

The teams permissions Will always be ["*"]

```csharp
public List<string> Permissions { get; set; }
```

## See Also

* class [TeamMember](./TeamMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TeamId property

The id of the parent team of which they are a member

```csharp
public Snowflake TeamId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [TeamMember](./TeamMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# User property

The avatar, discriminator, id, and username of the user

```csharp
public DiscordUser User { get; set; }
```

## See Also

* class [DiscordUser](./DiscordUser.md)
* class [TeamMember](./TeamMember.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->