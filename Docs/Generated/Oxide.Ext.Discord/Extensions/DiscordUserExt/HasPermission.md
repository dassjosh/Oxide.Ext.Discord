# DiscordUserExt.HasPermission method

Return if the discord user has the given oxide permission. If the user is not linked this will return false

```csharp
public static bool HasPermission(this DiscordUser user, string permission)
```

| parameter | description |
| --- | --- |
| user | User to check for permission |
| permission | Permission to check for |

## Return Value

True if use is linked and has permission; False otherwise

## See Also

* class [DiscordUser](../../Entities/Users/DiscordUser.md)
* class [DiscordUserExt](../DiscordUserExt.md)
* namespace [Oxide.Ext.Discord.Extensions](../DiscordUserExt.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->