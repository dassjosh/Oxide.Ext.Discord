# DiscordCommandLocalizations.RegisterCommandLocalizationAsync method

Registers Application Command Localization for a given language

```csharp
public IPromise RegisterCommandLocalizationAsync(Plugin plugin, string fileNameSuffix, 
    DiscordCommandLocalization localization, TemplateVersion version, TemplateVersion minVersion, 
    string language = "en")
```

| parameter | description |
| --- | --- |
| plugin | Plugin the for the command localization |
| fileNameSuffix | Suffix to be applied to the localization. IE DiscordExtension.{suffix}.json (optional) |
| localization | Localization to register |
| version | Version of the template |
| minVersion | Min supported registered version |
| language | Language to register |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException |  |

## See Also

* interface [IPromise](../../../../Interfaces/Promises/IPromise.md)
* class [DiscordCommandLocalization](../DiscordCommandLocalization.md)
* struct [TemplateVersion](../../TemplateVersion.md)
* class [DiscordCommandLocalizations](../DiscordCommandLocalizations.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Commands](../DiscordCommandLocalizations.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->