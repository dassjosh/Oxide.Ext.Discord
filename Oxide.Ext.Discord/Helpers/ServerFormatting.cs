using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Helpers
{
    /// <summary>
    /// Server Text Formatting
    /// </summary>
    public static class ServerFormatting
    {
        /// <summary>
        /// Color Text with the given color
        /// </summary>
        /// <param name="text">Text to color</param>
        /// <param name="color">Color of the text</param>
        /// <returns></returns>
        public static string Color(this string text, DiscordColor color) => $"[{color.ToHex()}]{text}[/#]";
        
        /// <summary>
        /// Color the placeholder text with a given color
        /// </summary>
        /// <param name="key">PlaceholderKey to color</param>
        /// <param name="color">Color of the text</param>
        /// <returns></returns>
        public static string Color(this PlaceholderKey key, DiscordColor color) => $"[{color.ToHex()}]{key.ToString()}[/#]";

        /// <summary>
        /// Bold the Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Bold text formatting</returns>
        public static string Bold(this string text) => $"[b]{text}[/b]";
        
        /// <summary>
        /// Italics the Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Italic text formatting</returns>
        public static string Italic(this string text) => $"[i]{text}[/i]";
        
        /// <summary>
        /// Font size formatted text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="size">Font size for the text</param>
        /// <returns>Font size text formatting</returns>
        public static string Size(this string text, int size) => $"[+{size}]{text}[/+]";
    }
}