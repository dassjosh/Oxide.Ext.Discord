﻿using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Cache
{
    /// <summary>
    /// Cached Emoji Data
    /// </summary>
    public sealed partial class EmojiCache : Singleton<EmojiCache>
    {
        private readonly Hash<string, string> _emojiToText = new();
        private readonly Hash<string, string> _textToEmoji = new(StringComparer.OrdinalIgnoreCase);
        
        /// <summary>
        /// Regex for unicode emoji characters
        /// </summary>
        public readonly Regex EmojiRegex = new(@"(\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]|\ud83e[\ud000-\udfff])", RegexOptions.Compiled);
        
        /// <summary>
        /// Regex for discord :emoji: strings
        /// </summary>
        public readonly Regex TextRegex = new(@":[\d\w_]*:", RegexOptions.Compiled);

        /// <summary>
        /// Regex MatchEvaluator for emoji to text or matched value
        /// </summary>
        public readonly MatchEvaluator EmojiToTextOrDefault;
        
        /// <summary>
        /// Regex MatchEvaluator for text to emoji or matched value
        /// </summary>
        public readonly MatchEvaluator TextToEmojiOrDefault;

        private EmojiCache()
        {
            Build();
            EmojiToTextOrDefault = match => _emojiToText[match.Value] ?? match.Value;
            TextToEmojiOrDefault = match => _textToEmoji[match.Value] ?? match.Value;
        }
        
        /// <summary>
        /// Convert an emoji character to the emoji string text
        /// </summary>
        /// <param name="emoji">Emoji to convert</param>
        /// <returns></returns>
        public string EmojiToText(string emoji) => _emojiToText[emoji];

        /// <summary>
        /// Convert emoji string text to an emoji character
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string TextToEmoji(string text) => _textToEmoji[text];

        /// <summary>
        /// Replaces emoji character with emoji string characters
        /// </summary>
        /// <param name="text">Text to replace</param>
        /// <param name="nonMatchReplacement">Replacement Text to use if non-matching</param>
        /// <returns></returns>
        public string ReplaceEmojiWithText(string text, string nonMatchReplacement) => EmojiRegex.Replace(text, match => _emojiToText[match.Value] ?? nonMatchReplacement);

        /// <summary>
        /// Replaces emoji string text with emoji characters
        /// </summary>
        /// <param name="text">Text to replace</param>
        /// <param name="nonMatchReplacement">Replacement Text to use if non-matching</param>
        /// <returns></returns>
        public string ReplaceTextWithEmoji(string text, string nonMatchReplacement) => TextRegex.Replace(text, match => _textToEmoji[match.Value] ?? nonMatchReplacement);
    
        /// <summary>
        /// Replaces emoji character with emoji string characters
        /// </summary>
        /// <param name="text">Text to replace</param>
        /// <param name="evaluator">Replacement Evaluator function</param>
        /// <returns></returns>
        public string ReplaceEmojiWithText(string text, MatchEvaluator evaluator) => EmojiRegex.Replace(text, evaluator);
    
        /// <summary>
        /// Replaces emoji string text with emoji characters
        /// </summary>
        /// <param name="text">Text to replace</param>
        /// <param name="evaluator">Replacement Evaluator function</param>
        /// <returns></returns>
        public string ReplaceTextWithEmoji(string text, MatchEvaluator evaluator) => TextRegex.Replace(text, evaluator);

        /// <summary>
        /// Replaces emoji character with emoji string characters
        /// If no match is found then the original text is used
        /// </summary>
        /// <param name="text">Text to replace</param>
        /// <returns></returns>
        public string ReplaceEmojiWithText(string text) => ReplaceEmojiWithText(text, EmojiToTextOrDefault);

        /// <summary>
        /// Replaces emoji string text with emoji characters
        /// If no match is found then the original text is used
        /// </summary>
        /// <param name="text">Text to replace</param>
        /// <returns></returns>
        public string ReplaceTextWithEmoji(string text) => ReplaceTextWithEmoji(text, TextToEmojiOrDefault);
        
        /// <summary>
        /// Returns the emoji character or discord emoji string as it's url encoded formated.
        /// If no matching emoji is found, the originally passed string is returned
        /// </summary>
        /// <param name="emoji"></param>
        /// <returns></returns>
        public string GetEmojiUrlEncoded(string emoji)
        {
            if (string.IsNullOrEmpty(emoji))
            {
                return emoji;
            }
            
            if (_textToEmoji.TryGetValue(emoji, out string emojiString))
            {
                emoji = emojiString;
            }
            
            return WebUtility.UrlEncode(emoji);
        }
    }
}