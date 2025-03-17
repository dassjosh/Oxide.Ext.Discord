# EmojiCache class

Cached Emoji Data

```csharp
public sealed class EmojiCache : Singleton<EmojiCache>
```

## Public Members

| name | description |
| --- | --- |
| readonly [EmojiRegex](#emojiregex-field) | Regex for unicode emoji characters |
| readonly [EmojiToTextOrDefault](#emojitotextordefault-field) | Regex MatchEvaluator for emoji to text or matched value |
| readonly [TextRegex](#textregex-field) | Regex for discord :emoji: strings |
| readonly [TextToEmojiOrDefault](#texttoemojiordefault-field) | Regex MatchEvaluator for text to emoji or matched value |
| [EmojiToText](#emojitotext-method)(…) | Convert an emoji character to the emoji string text |
| [GetEmojiUrlEncoded](#getemojiurlencoded-method)(…) | Returns the emoji character or discord emoji string as it's url encoded formated. If no matching emoji is found, the originally passed string is returned |
| [ReplaceEmojiWithText](#replaceemojiwithtext-method-1-of-3)(…) | Replaces emoji character with emoji string characters (3 methods) |
| [ReplaceTextWithEmoji](#replacetextwithemoji-method-1-of-3)(…) | Replaces emoji string text with emoji characters (3 methods) |
| [TextToEmoji](#texttoemoji-method)(…) | Convert emoji string text to an emoji character |

## See Also

* class [Singleton&lt;T&gt;](../Types/Singleton%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [EmojiCache.cs](../../../../Oxide.Ext.Discord/Cache/EmojiCache.cs)
   
   
# EmojiToText method

Convert an emoji character to the emoji string text

```csharp
public string EmojiToText(string emoji)
```

| parameter | description |
| --- | --- |
| emoji | Emoji to convert |

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TextToEmoji method

Convert emoji string text to an emoji character

```csharp
public string TextToEmoji(string text)
```

| parameter | description |
| --- | --- |
| text |  |

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ReplaceEmojiWithText method (1 of 3)

Replaces emoji character with emoji string characters If no match is found then the original text is used

```csharp
public string ReplaceEmojiWithText(string text)
```

| parameter | description |
| --- | --- |
| text | Text to replace |

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ReplaceEmojiWithText method (2 of 3)

Replaces emoji character with emoji string characters

```csharp
public string ReplaceEmojiWithText(string text, MatchEvaluator evaluator)
```

| parameter | description |
| --- | --- |
| text | Text to replace |
| evaluator | Replacement Evaluator function |

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ReplaceEmojiWithText method (3 of 3)

Replaces emoji character with emoji string characters

```csharp
public string ReplaceEmojiWithText(string text, string nonMatchReplacement)
```

| parameter | description |
| --- | --- |
| text | Text to replace |
| nonMatchReplacement | Replacement Text to use if non-matching |

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ReplaceTextWithEmoji method (1 of 3)

Replaces emoji string text with emoji characters If no match is found then the original text is used

```csharp
public string ReplaceTextWithEmoji(string text)
```

| parameter | description |
| --- | --- |
| text | Text to replace |

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ReplaceTextWithEmoji method (2 of 3)

Replaces emoji string text with emoji characters

```csharp
public string ReplaceTextWithEmoji(string text, MatchEvaluator evaluator)
```

| parameter | description |
| --- | --- |
| text | Text to replace |
| evaluator | Replacement Evaluator function |

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ReplaceTextWithEmoji method (3 of 3)

Replaces emoji string text with emoji characters

```csharp
public string ReplaceTextWithEmoji(string text, string nonMatchReplacement)
```

| parameter | description |
| --- | --- |
| text | Text to replace |
| nonMatchReplacement | Replacement Text to use if non-matching |

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetEmojiUrlEncoded method

Returns the emoji character or discord emoji string as it's url encoded formated. If no matching emoji is found, the originally passed string is returned

```csharp
public string GetEmojiUrlEncoded(string emoji)
```

| parameter | description |
| --- | --- |
| emoji |  |

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EmojiRegex field

Regex for unicode emoji characters

```csharp
public readonly Regex EmojiRegex;
```

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TextRegex field

Regex for discord :emoji: strings

```csharp
public readonly Regex TextRegex;
```

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# EmojiToTextOrDefault field

Regex MatchEvaluator for emoji to text or matched value

```csharp
public readonly MatchEvaluator EmojiToTextOrDefault;
```

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TextToEmojiOrDefault field

Regex MatchEvaluator for text to emoji or matched value

```csharp
public readonly MatchEvaluator TextToEmojiOrDefault;
```

## See Also

* class [EmojiCache](./EmojiCache.md)
* namespace [Oxide.Ext.Discord.Cache](./CacheNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
