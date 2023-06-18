# DiscordGuild.CreateBan method (1 of 2)

Create a guild ban, and optionally delete previous messages sent by the banned user. Requires the BAN_MEMBERS permission. See [Create Guild Ban](https://discord.com/developers/docs/resources/guild#create-guild-ban)

```csharp
public IPromise CreateBan(DiscordClient client, GuildMember member, GuildBanCreate ban)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| member | Guild Member to ban |
| ban | User ban information |

## See Also

* interface [IPromise](../../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* class [GuildMember](../GuildMember.md)
* class [GuildBanCreate](../GuildBanCreate.md)
* class [DiscordGuild](../DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds](../DiscordGuild.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

---

# DiscordGuild.CreateBan method (2 of 2)

Create a guild ban, and optionally delete previous messages sent by the banned user. Requires the BAN_MEMBERS permission. See [Create Guild Ban](https://discord.com/developers/docs/resources/guild#create-guild-ban)

```csharp
public IPromise CreateBan(DiscordClient client, Snowflake userId, GuildBanCreate ban)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID to ban |
| ban | User ban information |

## See Also

* interface [IPromise](../../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* struct [Snowflake](../../Snowflake.md)
* class [GuildBanCreate](../GuildBanCreate.md)
* class [DiscordGuild](../DiscordGuild.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds](../DiscordGuild.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->