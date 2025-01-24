# DiscordFormatting class

Represents [Message text formatting options](https://discord.com/developers/docs/reference#message-formatting-formats)

```csharp
public static class DiscordFormatting
```

## Public Members

| name | description |
| --- | --- |
| static [BlockQuoteMultiLine](#blockquotemultiline-method)(…) | Will display the message in multiline block quote |
| static [BlockQuoteSingleLine](#blockquotesingleline-method)(…) | Will display the message in single line block quote |
| static [Bold](#bold-method)(…) | Will display the message in bold |
| static [CodeBlockLanguage](#codeblocklanguage-method)(…) | Will display a multiline code bloc with the specified language |
| static [CodeBlockMultiLine](#codeblockmultiline-method)(…) | Will display the message as a multiline code block |
| static [CodeBlockOneLine](#codeblockoneline-method)(…) | Will display the message as a one-line code block |
| static [CustomEmojiDataString](#customemojidatastring-method)(…) | Returns formatting string for custom emoji to be used in a url |
| static [CustomEmojiMessageString](#customemojimessagestring-method)(…) | Returns formatting string for custom emoji to be used in a message |
| static [EmojiMessageString](#emojimessagestring-method)(…) | Return the emoji string for a message |
| static [GuildNavigation](#guildnavigation-method)(…) | Guild Navigation Format |
| static [Header1](#header1-method)(…) | Creates a Big Header |
| static [Header2](#header2-method)(…) | Creates a Medium Header |
| static [Header3](#header3-method)(…) | Creates a Small Header |
| static [Italics](#italics-method)(…) | Will display the message in italics |
| static [ItalicsBold](#italicsbold-method)(…) | Will display the message in italics and bold |
| static [LinkedRoles](#linkedroles-method)(…) | Linked Roles |
| static [List](#list-method)(…) | Creates a list item for the given message |
| static [MaskLink](#masklink-method)(…) | Creates a clickable link displayed as the mask text |
| static [MentionApplicationCommand](#mentionapplicationcommand-method)(…) | Mention the Application command |
| static [MentionApplicationCommandCustom](#mentionapplicationcommandcustom-method)(…) | Mention the application command using a custom command string |
| static [MentionChannel](#mentionchannel-method)(…) | Mention the channel with the given ID |
| static [MentionRole](#mentionrole-method)(…) | Mention the role with the given ID |
| static [MentionUser](#mentionuser-method)(…) | Mention the user with the given user ID |
| static [NumberedList](#numberedlist-method)(…) | Creates a list item for the given message |
| static [Spoiler](#spoiler-method)(…) | Will display the text as a spoiler |
| static [Strikethrough](#strikethrough-method)(…) | Will display the message with a strikethrough |
| static [Underline](#underline-method)(…) | Will display the message in underline |
| static [UnderlineBold](#underlinebold-method)(…) | Will display the message in underline and bold |
| static [UnderlineBoldItalics](#underlinebolditalics-method)(…) | Will display the message in underline and bold and italics |
| static [UnderlineItalics](#underlineitalics-method)(…) | Will display the message in underline and italics |
| static [UnixTimestamp](#unixtimestamp-method-1-of-2)(…) | Displays a timestamp (2 methods) |

## See Also

* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordFormatting.cs](../../../../Oxide.Ext.Discord/Helpers/DiscordFormatting.cs)
   
   
# MentionUser method

Mention the user with the given user ID

```csharp
public static string MentionUser(Snowflake userId)
```

| parameter | description |
| --- | --- |
| userId | User ID to mention |

## Return Value

Mention user formatted string

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MentionChannel method

Mention the channel with the given ID

```csharp
public static string MentionChannel(Snowflake channelId)
```

| parameter | description |
| --- | --- |
| channelId | Channel ID to mention |

## Return Value

Mention channel formatted string

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MentionRole method

Mention the role with the given ID

```csharp
public static string MentionRole(Snowflake roleId)
```

| parameter | description |
| --- | --- |
| roleId | Role ID to mention |

## Return Value

Mention role formatted string

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MentionApplicationCommand method

Mention the Application command

```csharp
public static string MentionApplicationCommand(Snowflake commandId, string name, 
    string subCommand = null, string group = null)
```

| parameter | description |
| --- | --- |
| commandId | Application Command ID |
| name | Name of the command |
| subCommand | Sub Command Name (Optional) |
| group | Sub Command Group (Optional) |

## Return Value

Mentions the application command

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MentionApplicationCommandCustom method

Mention the application command using a custom command string

```csharp
public static string MentionApplicationCommandCustom(Snowflake commandId, string command)
```

| parameter | description |
| --- | --- |
| commandId | Application Command ID |
| command | Custom Command String |

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EmojiMessageString method

Return the emoji string for a message

```csharp
public static string EmojiMessageString(DiscordEmoji emoji)
```

| parameter | description |
| --- | --- |
| emoji | Emoji to create as a string |

## Return Value

Emoji message string

## See Also

* class [DiscordEmoji](../Entities/DiscordEmoji.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CustomEmojiMessageString method

Returns formatting string for custom emoji to be used in a message

```csharp
public static string CustomEmojiMessageString(Snowflake id, string name, bool animated)
```

| parameter | description |
| --- | --- |
| name | Name of the custom emoji |
| id | ID of the custom emoji |
| animated | If the emoji is animated |

## Return Value

Custom emoji formatted string

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CustomEmojiDataString method

Returns formatting string for custom emoji to be used in a url

```csharp
public static string CustomEmojiDataString(Snowflake id, string name, bool animated)
```

| parameter | description |
| --- | --- |
| name | Name of the custom emoji |
| id | ID of the custom emoji |
| animated | If the emoji is animated |

## Return Value

Custom emoji formatted string

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UnixTimestamp method (1 of 2)

Displays a timestamp

```csharp
public static string UnixTimestamp(DateTimeOffset time, 
    TimestampStyles style = TimestampStyles.ShortDateTime)
```

| parameter | description |
| --- | --- |
| time | Time to display |
| style | Style of the timestamp |

## See Also

* enum [TimestampStyles](./TimestampStyles.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# UnixTimestamp method (2 of 2)

Displays a timestamp

```csharp
public static string UnixTimestamp(long timestamp, 
    TimestampStyles style = TimestampStyles.ShortDateTime)
```

| parameter | description |
| --- | --- |
| timestamp | UNIX Timestamp |
| style | Display style for the timestamp |

## See Also

* enum [TimestampStyles](./TimestampStyles.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildNavigation method

Guild Navigation Format

```csharp
public static string GuildNavigation(GuildNavigationType type)
```

| parameter | description |
| --- | --- |
| type | Type to navigate to |

## Return Value

string with navigation to the navigation type

## See Also

* enum [GuildNavigationType](../Entities/GuildNavigationType.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LinkedRoles method

Linked Roles

```csharp
public static string LinkedRoles(Snowflake roleId)
```

| parameter | description |
| --- | --- |
| roleId | Linked role ID |

## Return Value

string with navigation to the navigation type

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Italics method

Will display the message in italics

```csharp
public static string Italics(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make italics |

## Return Value

Italics formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Bold method

Will display the message in bold

```csharp
public static string Bold(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make bold |

## Return Value

Bold formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ItalicsBold method

Will display the message in italics and bold

```csharp
public static string ItalicsBold(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make italics and bold |

## Return Value

Bold and Italics formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Underline method

Will display the message in underline

```csharp
public static string Underline(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make underline |

## Return Value

Underline formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UnderlineItalics method

Will display the message in underline and italics

```csharp
public static string UnderlineItalics(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make underline and italics |

## Return Value

Underline and Italics formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UnderlineBold method

Will display the message in underline and bold

```csharp
public static string UnderlineBold(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make underline and bold |

## Return Value

Underline and bold formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# UnderlineBoldItalics method

Will display the message in underline and bold and italics

```csharp
public static string UnderlineBoldItalics(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make underline and bold and italics |

## Return Value

Underline and Bold and Italics formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Strikethrough method

Will display the message with a strikethrough

```csharp
public static string Strikethrough(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make strikethrough |

## Return Value

Strikethrough formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CodeBlockOneLine method

Will display the message as a one-line code block

```csharp
public static string CodeBlockOneLine(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make code block |

## Return Value

Code block formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CodeBlockMultiLine method

Will display the message as a multiline code block

```csharp
public static string CodeBlockMultiLine(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make multiline code block |

## Return Value

Code block formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# CodeBlockLanguage method

Will display a multiline code bloc with the specified language

```csharp
public static string CodeBlockLanguage(string message, string language)
```

| parameter | description |
| --- | --- |
| message | Message to make code block with language |
| language | Language to display the code block as |

## Return Value

Language code block formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BlockQuoteSingleLine method

Will display the message in single line block quote

```csharp
public static string BlockQuoteSingleLine(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make block quote |

## Return Value

Block Quote formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BlockQuoteMultiLine method

Will display the message in multiline block quote

```csharp
public static string BlockQuoteMultiLine(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make block quote |

## Return Value

Multiline block quote formatted message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Spoiler method

Will display the text as a spoiler

```csharp
public static string Spoiler(string message)
```

| parameter | description |
| --- | --- |
| message | Message to make Spoiler |

## Return Value

Spoiler message

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Header1 method

Creates a Big Header

```csharp
public static string Header1(string header)
```

| parameter | description |
| --- | --- |
| header | text for the header |

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Header2 method

Creates a Medium Header

```csharp
public static string Header2(string header)
```

| parameter | description |
| --- | --- |
| header | text for the header |

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Header3 method

Creates a Small Header

```csharp
public static string Header3(string header)
```

| parameter | description |
| --- | --- |
| header | text for the header |

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# MaskLink method

Creates a clickable link displayed as the mask text

```csharp
public static string MaskLink(string mask, string url)
```

| parameter | description |
| --- | --- |
| mask | Text to display the link as |
| url | Url for the link |

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# List method

Creates a list item for the given message

```csharp
public static string List(string message, bool indent)
```

| parameter | description |
| --- | --- |
| message | Text for the list |
| indent | If the list should be indented a level |

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# NumberedList method

Creates a list item for the given message

```csharp
public static string NumberedList(string message, int number, bool indent)
```

| parameter | description |
| --- | --- |
| message | Text for the list |
| number | Number to display |
| indent | If the list should be indented a level |

## See Also

* class [DiscordFormatting](./DiscordFormatting.md)
* namespace [Oxide.Ext.Discord.Helpers](./HelpersNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
