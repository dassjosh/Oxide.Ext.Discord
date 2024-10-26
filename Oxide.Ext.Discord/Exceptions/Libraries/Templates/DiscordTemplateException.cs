using System.Text.RegularExpressions;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exception for Discord Templates
    /// </summary>
    public class DiscordTemplateException : BaseDiscordException
    {
        private static readonly Regex FileNameRegex = new(@"^[\w \.]+$", RegexOptions.Compiled);
        private static readonly Regex DuplicateCharacterRegex = new(@"(\.)\1{1}", RegexOptions.Compiled);
        
        private DiscordTemplateException(string message) : base(message) { }

        internal static void ThrowIfInvalidTemplateName(string name, TemplateType type)
        {
            if (type == TemplateType.Command && string.IsNullOrEmpty(name))
            {
                return;
            }
            
            if (string.IsNullOrEmpty(name))
            {
                throw new DiscordTemplateException($"{name} cannot contain be null or empty");
            }
            
            if (!FileNameRegex.IsMatch(name))
            {
                throw new DiscordTemplateException($"{name} is not a valid template name. Only Letters, Numbers, _, ., and spaces are allowed");
            }

            if (DuplicateCharacterRegex.IsMatch(name))
            {
                throw new DiscordTemplateException($"{name} cannot contain duplicate '.'");
            }
        }
    }
}