# BaseMessageTemplateLibrary&lt;TTemplate&gt; class

Library for Discord Message templates

```csharp
public abstract class BaseMessageTemplateLibrary<TTemplate> : BaseTemplateLibrary<TTemplate>
    where TTemplate : class, new()
```

## Public Members

| name | description |
| --- | --- |
| [GetGlobalTemplate](#getglobaltemplate-method)(…) | Returns a global message template for the plugin with the given name |
| [GetLocalizedTemplate](#getlocalizedtemplate-method-1-of-2)(…) | Returns a message template for a given language (2 methods) |
| [GetPlayerTemplate](#getplayertemplate-method-1-of-2)(…) | Returns a message template for a given IPlayer player (2 methods) |
| [RegisterGlobalTemplateAsync](#registerglobaltemplateasync-method)(…) | Registers a global message template Global Message templates cannot be localized |
| [RegisterLocalizedTemplateAsync](#registerlocalizedtemplateasync-method)(…) | Registers a message template with the given name and language |

## Protected Members

| name | description |
| --- | --- |
| [BaseMessageTemplateLibrary](#basemessagetemplatelibrary&amp;lt;ttemplate&amp;gt;-constructor)(…) | Constructor |
| override [OnPluginUnloaded](#onpluginunloaded-method)(…) |  |

## See Also

* class [BaseTemplateLibrary&lt;TTemplate&gt;](./BaseTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [BaseMessageTemplateLibrary.cs](../../../../Oxide.Ext.Discord/Libraries/BaseMessageTemplateLibrary.cs)
   
   
# RegisterGlobalTemplateAsync method

Registers a global message template Global Message templates cannot be localized

```csharp
public IPromise<TTemplate> RegisterGlobalTemplateAsync(Plugin plugin, TemplateKey templateName, 
    TTemplate template, TemplateVersion version, TemplateVersion minVersion)
```

| parameter | description |
| --- | --- |
| plugin | Plugin the template is for |
| templateName | Unique name of the template |
| template | Template to register |
| version | Version of the template |
| minVersion | Min supported version for this template |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException |  |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* struct [TemplateKey](./TemplateKey.md)
* struct [TemplateVersion](./TemplateVersion.md)
* class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./BaseMessageTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RegisterLocalizedTemplateAsync method

Registers a message template with the given name and language

```csharp
public IPromise<TTemplate> RegisterLocalizedTemplateAsync(Plugin plugin, TemplateKey templateName, 
    TTemplate template, TemplateVersion version, TemplateVersion minVersion, string language = "en")
```

| parameter | description |
| --- | --- |
| plugin | Plugin the [`DiscordMessageTemplate`](./DiscordMessageTemplate.md) is for |
| templateName | Name of the [`DiscordMessageTemplate`](./DiscordMessageTemplate.md) |
| template | Template to be registered |
| version | Version of the template |
| minVersion | The minimum supported template version. If an existing template exists and it's version is &gt;= the minimum supported version then we will use that template. If an existing template exists and it's version is &lt; the min supported version. The existing version is backed up and a new template is created |
| language | Language for the template |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException |  |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/IPromise%7BTPromised%7D.md)
* struct [TemplateKey](./TemplateKey.md)
* struct [TemplateVersion](./TemplateVersion.md)
* class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./BaseMessageTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetGlobalTemplate method

Returns a global message template for the plugin with the given name

```csharp
public TTemplate GetGlobalTemplate(Plugin plugin, TemplateKey templateName)
```

| parameter | description |
| --- | --- |
| plugin | Plugin the template is for |
| templateName | Name of the template |

## Return Value

[`DiscordMessageTemplate`](./DiscordMessageTemplate.md)

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException |  |

## See Also

* struct [TemplateKey](./TemplateKey.md)
* class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./BaseMessageTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetPlayerTemplate method (1 of 2)

Returns a message template for a given IPlayer player

```csharp
public TTemplate GetPlayerTemplate(Plugin plugin, TemplateKey templateName, IPlayer player)
```

| parameter | description |
| --- | --- |
| plugin | Plugin the template is for |
| templateName | Name of the template |
| player | IPlayer for the template |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | Thrown if Plugin is null or name / language is null or empty |

## See Also

* struct [TemplateKey](./TemplateKey.md)
* class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./BaseMessageTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# GetPlayerTemplate method (2 of 2)

Returns a message template for a given IPlayer player

```csharp
public TTemplate GetPlayerTemplate(Plugin plugin, TemplateKey templateName, string playerId)
```

| parameter | description |
| --- | --- |
| plugin | Plugin the template is for |
| templateName | Name of the template |
| playerId | Player ID for the template |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | Thrown if Plugin is null or name / language is null or empty |

## See Also

* struct [TemplateKey](./TemplateKey.md)
* class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./BaseMessageTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetLocalizedTemplate method (1 of 2)

Returns a message template for a given language

```csharp
public TTemplate GetLocalizedTemplate(Plugin plugin, TemplateKey templateName, 
    DiscordInteraction interaction)
```

| parameter | description |
| --- | --- |
| plugin | Plugin the template is for |
| templateName | Name of the template |
| interaction | Interaction to get the template for |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | Thrown if Plugin is null or name / language is null or empty |

## See Also

* struct [TemplateKey](./TemplateKey.md)
* class [DiscordInteraction](../Entities/DiscordInteraction.md)
* class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./BaseMessageTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# GetLocalizedTemplate method (2 of 2)

Returns a message template for a given language

```csharp
public TTemplate GetLocalizedTemplate(Plugin plugin, TemplateKey templateName, 
    string language = "en")
```

| parameter | description |
| --- | --- |
| plugin | Plugin the template is for |
| templateName | Name of the template |
| language | Oxide language of the template |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | Thrown if Plugin is null or name / language is null or empty |

## See Also

* struct [TemplateKey](./TemplateKey.md)
* class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./BaseMessageTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OnPluginUnloaded method

```csharp
protected override void OnPluginUnloaded(Plugin plugin)
```

## See Also

* class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./BaseMessageTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BaseMessageTemplateLibrary&lt;TTemplate&gt; constructor

Constructor

```csharp
protected BaseMessageTemplateLibrary(TemplateType type, ILogger logger)
```

| parameter | description |
| --- | --- |
| type |  |
| logger |  |

## See Also

* enum [TemplateType](./TemplateType.md)
* interface [ILogger](../Interfaces/ILogger.md)
* class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./BaseMessageTemplateLibrary%7BTTemplate%7D.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
