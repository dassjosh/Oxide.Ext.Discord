using System;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Helpers
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/reference#message-formatting-formats">Message text formatting options</a>
    /// </summary>
    public static class DiscordFormatting
    {
        /// <summary>
        /// Mention the user with the given user ID
        /// </summary>
        /// <param name="userId">User ID to mention</param>
        /// <returns>Mention user formatted string</returns>
        public static string MentionUser(Snowflake userId) => $"<@{userId.ToString()}>";

        /// <summary>
        /// Mention the channel with the given ID
        /// </summary>
        /// <param name="channelId">Channel ID to mention</param>
        /// <returns>Mention channel formatted string</returns>
        public static string MentionChannel(Snowflake channelId) => $"<#{channelId.ToString()}>";

        /// <summary>
        /// Mention the role with the given ID
        /// </summary>
        /// <param name="roleId">Role ID to mention</param>
        /// <returns>Mention role formatted string</returns>
        public static string MentionRole(Snowflake roleId) => $"<@&{roleId.ToString()}>";

        /// <summary>
        /// Mention the Application command
        /// </summary>
        /// <param name="commandId">Application Command ID</param>
        /// <param name="name">Name of the command</param>
        /// <param name="subCommand">Sub Command Name (Optional)</param>
        /// <param name="group">Sub Command Group (Optional)</param>
        /// <returns>Mentions the application command</returns>
        public static string MentionApplicationCommand(Snowflake commandId, string name, string subCommand = null, string group = null)
        {
            InvalidSnowflakeException.ThrowIfInvalid(commandId);
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (!string.IsNullOrEmpty(subCommand))
            {
                if (!string.IsNullOrEmpty(group))
                {
                    return $"</{name} {group} {subCommand}:{commandId}>";
                }
                
                return $"</{name} {subCommand}:{commandId}>";
            }
            return $"</{name}:{commandId}>";
        }

        /// <summary>
        /// Mention the application command using a custom command string
        /// </summary>
        /// <param name="commandId">Application Command ID</param>
        /// <param name="command">Custom Command String</param>
        /// <returns></returns>
        public static string MentionApplicationCommandCustom(Snowflake commandId, string command)
        {
            return $"</{command}:{commandId}>";
        }

        /// <summary>
        /// Return the emoji string for a message
        /// </summary>
        /// <param name="emoji">Emoji to create as a string</param>
        /// <returns>Emoji message string</returns>
        public static string EmojiMessageString(DiscordEmoji emoji)
        {
            if (!emoji.EmojiId.HasValue)
            {
                return emoji.Name;
            }

            return CustomEmojiMessageString(emoji.Id, emoji.Name, emoji.Animated ?? false);
        }

        /// <summary>
        /// Returns formatting string for custom emoji to be used in a message
        /// </summary>
        /// <param name="name">Name of the custom emoji</param>
        /// <param name="id">ID of the custom emoji</param>
        /// <param name="animated">If the emoji is animated</param>
        /// <returns>Custom emoji formatted string</returns>
        public static string CustomEmojiMessageString(Snowflake id, string name, bool animated) => $"<{CustomEmojiDataString(id, name, animated)}>";
        
        /// <summary>
        /// Returns formatting string for custom emoji to be used in a url
        /// </summary>
        /// <param name="name">Name of the custom emoji</param>
        /// <param name="id">ID of the custom emoji</param>
        /// <param name="animated">If the emoji is animated</param>
        /// <returns>Custom emoji formatted string</returns>
        public static string CustomEmojiDataString(Snowflake id, string name, bool animated) => $"{(animated ? "a" : "")}:{name}:{id.ToString()}";

        /// <summary>
        /// Displays a timestamp 
        /// </summary>
        /// <param name="time">Time to display</param>
        /// <param name="style">Style of the timestamp</param>
        /// <returns></returns>
        public static string UnixTimestamp(DateTimeOffset time, TimestampStyles style = TimestampStyles.ShortDateTime) => UnixTimestamp(time.ToUnixTimeSeconds(), style);
        
        /// <summary>
        /// Displays a timestamp 
        /// </summary>
        /// <param name="timestamp">UNIX Timestamp</param>
        /// <param name="style">Display style for the timestamp</param>
        /// <returns></returns>
        public static string UnixTimestamp(long timestamp, TimestampStyles style = TimestampStyles.ShortDateTime)
        {
            return $"<t:{timestamp.ToString()}:{GetTimestampFlag(style)}>";
        }

        private static char GetTimestampFlag(TimestampStyles style)
        {
            return style switch
            {
                TimestampStyles.ShortTime => 't',
                TimestampStyles.LongTime => 'T',
                TimestampStyles.ShortDate => 'd',
                TimestampStyles.LongDate => 'D',
                TimestampStyles.ShortDateTime => 'f',
                TimestampStyles.LongDateTime => 'F',
                TimestampStyles.RelativeTime => 'R',
                _ => 'f'
            };

        }

        /// <summary>
        /// Guild Navigation Format
        /// </summary>
        /// <param name="type">Type to navigate to</param>
        /// <returns>string with navigation to the navigation type</returns>
        public static string GuildNavigation(GuildNavigationType type)
        {
            return $"<id:{EnumCache<GuildNavigationType>.Instance.ToLower(type)}>";
        }
        
        /// <summary>
        /// Will display the message in italics
        /// </summary>
        /// <param name="message">Message to make italics</param>
        /// <returns>Italics formatted message</returns>
        public static string Italics(string message) => $"*{message}*";
        
        /// <summary>
        /// Will display the message in bold
        /// </summary>
        /// <param name="message">Message to make bold</param>
        /// <returns>Bold formatted message</returns>
        public static string Bold(string message) => $"**{message}**";
        
        /// <summary>
        /// Will display the message in italics and bold
        /// </summary>
        /// <param name="message">Message to make italics and bold</param>
        /// <returns>Bold and Italics formatted message</returns>
        public static string ItalicsBold(string message) => $"***{message}***";
        
        /// <summary>
        /// Will display the message in underline
        /// </summary>
        /// <param name="message">Message to make underline</param>
        /// <returns>Underline formatted message</returns>
        public static string Underline(string message) => $"__{message}__";
        
        /// <summary>
        /// Will display the message in underline and italics
        /// </summary>
        /// <param name="message">Message to make underline and italics</param>
        /// <returns>Underline and Italics formatted message</returns>
        public static string UnderlineItalics(string message) => $"__*{message}*__";
        
        /// <summary>
        /// Will display the message in underline and bold
        /// </summary>
        /// <param name="message">Message to make underline and bold</param>
        /// <returns>Underline and bold formatted message</returns>
        public static string UnderlineBold(string message) => $"__**{message}**__";
        
        /// <summary>
        /// Will display the message in underline and bold and italics
        /// </summary>
        /// <param name="message">Message to make underline and bold and italics</param>
        /// <returns>Underline and Bold and Italics formatted message</returns>
        public static string UnderlineBoldItalics(string message) => $"__***{message}***__";
        
        /// <summary>
        /// Will display the message with a strikethrough
        /// </summary>
        /// <param name="message">Message to make strikethrough</param>
        /// <returns>Strikethrough formatted message</returns>
        public static string Strikethrough(string message) => $"~~{message}~~";
        
        /// <summary>
        /// Will display the message as a one-line code block
        /// </summary>
        /// <param name="message">Message to make code block</param>
        /// <returns>Code block formatted message</returns>
        public static string CodeBlockOneLine(string message) => $"`{message}`";
        
        /// <summary>
        /// Will display the message as a multiline code block
        /// </summary>
        /// <param name="message">Message to make multiline code block</param>
        /// <returns>Code block formatted message</returns>
        public static string CodeBlockMultiLine(string message) => $"```\n{message}\n```";

        /// <summary>
        /// Will display a multiline code bloc with the specified language
        /// </summary>
        /// <param name="message">Message to make code block with language</param>
        /// <param name="language">Language to display the code block as</param>
        /// <returns>Language code block formatted message</returns>
        public static string CodeBlockLanguage(string message, string language) => $"```{language}\n{message}\n```";
        
        /// <summary>
        /// Will display the message in single line block quote
        /// </summary>
        /// <param name="message">Message to make block quote</param>
        /// <returns>Block Quote formatted message</returns>
        public static string BlockQuoteSingleLine(string message) => $"> {message}";
        
        /// <summary>
        /// Will display the message in multiline block quote
        /// </summary>
        /// <param name="message">Message to make block quote</param>
        /// <returns>Multiline block quote formatted message</returns>
        public static string BlockQuoteMultiLine(string message) => $">>> {message}";

        /// <summary>
        /// Will display the text as a spoiler
        /// </summary>
        /// <param name="message">Message to make Spoiler</param>
        /// <returns>Spoiler message</returns>
        public static string Spoiler(string message) => $"||{message}||";
        
        /// <summary>
        /// Creates a Big Header
        /// </summary>
        /// <param name="header">text for the header</param>
        /// <returns></returns>
        public static string Header1(string header) => $"# {header}";
        
        /// <summary>
        /// Creates a Medium Header
        /// </summary>
        /// <param name="header">text for the header</param>
        /// <returns></returns>
        public static string Header2(string header) => $"## {header}";
        
        /// <summary>
        /// Creates a Small Header
        /// </summary>
        /// <param name="header">text for the header</param>
        /// <returns></returns>
        public static string Header3(string header) => $"### {header}";

        /// <summary>
        /// Creates a clickable link displayed as the mask text
        /// </summary>
        /// <param name="mask">Text to display the link as</param>
        /// <param name="url">Url for the link</param>
        /// <returns></returns>
        public static string MaskLink(string mask, string url) => $"[{mask}]({url})";
        
        /// <summary>
        /// Creates a list item for the given message
        /// </summary>
        /// <param name="message">Text for the list</param>
        /// <param name="indent">If the list should be indented a level</param>
        /// <returns></returns>
        public static string List(string message, bool indent) => $"{(indent ? " " : string.Empty)}- {message}";

        /// <summary>
        /// Creates a list item for the given message
        /// </summary>
        /// <param name="message">Text for the list</param>
        /// <param name="number">Number to display</param>
        /// <param name="indent">If the list should be indented a level</param>
        /// <returns></returns>
        public static string NumberedList(string message, int number, bool indent) => $"{(indent ? " " : string.Empty)}{StringCache<int>.Instance.ToString(number)} {message}";
    }
}