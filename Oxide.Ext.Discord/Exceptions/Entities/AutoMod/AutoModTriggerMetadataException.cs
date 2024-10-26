using System.Collections.Generic;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exceptions for <see cref="AutoModTriggerMetadata"/>
    /// </summary>
    public class AutoModTriggerMetadataException : BaseDiscordException
    {
        private AutoModTriggerMetadataException(string message) : base(message) { }

        internal static void ThrowIfKeywordFilterInvalid(List<string> filter)
        {
            const int MaxKeywordFilterLength = 1000;
            const int MaxKeywordLength = 60;
            
            if (filter == null)
            {
                return;
            }

            if (filter.Count > MaxKeywordFilterLength)
            {
                throw new AutoModTriggerMetadataException($"{nameof(AutoModTriggerMetadata)}.{nameof(AutoModTriggerMetadata.KeywordFilter)} cannot have more than {MaxKeywordFilterLength} keywords");
            }

            for (int index = 0; index < filter.Count; index++)
            {
                string keyword = filter[index];
                if (keyword.Length > MaxKeywordLength)
                {
                    throw new AutoModTriggerMetadataException($"{nameof(AutoModTriggerMetadata)}.{nameof(AutoModTriggerMetadata.KeywordFilter)} keyword {keyword} cannot have more than {MaxKeywordLength} characters");
                }
            }
        }
        
        internal static void ThrowIfRegexPatternsInvalid(List<string> patterns)
        {
            const int MaxPatternsLength = 10;
            const int MaxRegexLength = 260;
            
            if (patterns == null)
            {
                return;
            }

            if (patterns.Count > MaxPatternsLength)
            {
                throw new AutoModTriggerMetadataException($"{nameof(AutoModTriggerMetadata)}.{nameof(AutoModTriggerMetadata.RegexPatterns)} cannot have more than {MaxPatternsLength} patterns");
            }

            for (int index = 0; index < patterns.Count; index++)
            {
                string regex = patterns[index];
                if (regex.Length > MaxRegexLength)
                {
                    throw new AutoModTriggerMetadataException($"{nameof(AutoModTriggerMetadata)}.{nameof(AutoModTriggerMetadata.KeywordFilter)} regex {regex} cannot have more than {MaxRegexLength} characters");
                }
            }
        }
        
        internal static void ThrowIfAllowListInvalid(List<string> allowList, AutoModTriggerType type)
        {
            if (allowList == null)
            {
                return;
            }

            switch (type)
            {
                case AutoModTriggerType.Keyword:
                    ThrowIfAllowListKeywordInvalid(allowList);
                    break;
                case AutoModTriggerType.KeywordPreset:
                    ThrowIfAllowListKeywordPresetInvalid(allowList);
                    break;
            }
        }

        private static void ThrowIfAllowListKeywordInvalid(List<string> allowList)
        {
            const int MaxAllowListLength = 100;
            const int MaxAllowLength = 60;
            
            if (allowList.Count > MaxAllowListLength)
            {
                throw new AutoModTriggerMetadataException($"{nameof(AutoModTriggerMetadata)}.{nameof(AutoModTriggerMetadata.AllowList)} cannot have more than {MaxAllowListLength} allowed strings");
            }

            for (int index = 0; index < allowList.Count; index++)
            {
                string str = allowList[index];
                if (str.Length > MaxAllowLength)
                {
                    throw new AutoModTriggerMetadataException($"{nameof(AutoModTriggerMetadata)}.{nameof(AutoModTriggerMetadata.AllowList)} strings {str} cannot have more than {MaxAllowLength} characters");
                }
            }
        }
        
        private static void ThrowIfAllowListKeywordPresetInvalid(List<string> allowList)
        {
            const int MaxAllowListLength = 1000;
            const int MaxAllowLength = 60;
            
            if (allowList.Count > MaxAllowListLength)
            {
                throw new AutoModTriggerMetadataException($"{nameof(AutoModTriggerMetadata)}.{nameof(AutoModTriggerMetadata.AllowList)} cannot have more than {MaxAllowListLength} allowed strings");
            }

            for (int index = 0; index < allowList.Count; index++)
            {
                string str = allowList[index];
                if (str.Length > MaxAllowLength)
                {
                    throw new AutoModTriggerMetadataException($"{nameof(AutoModTriggerMetadata)}.{nameof(AutoModTriggerMetadata.AllowList)} strings {str} cannot have more than {MaxAllowLength} characters");
                }
            }
        }

        internal static void ThrowIfInvalidMentionTotalLimit(int limit)
        {
            const int MaxLimit = 50;
            
            if (limit > MaxLimit)
            {
                throw new AutoModTriggerMetadataException($"{nameof(AutoModTriggerMetadata)}.{nameof(AutoModTriggerMetadata.AllowList)} cannot be more than {MaxLimit}");
            }
        }
    }
}