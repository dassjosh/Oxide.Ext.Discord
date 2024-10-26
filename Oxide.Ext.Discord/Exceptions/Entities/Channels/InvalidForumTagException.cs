
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception for channel threads
    /// </summary>
    public class InvalidForumTagException : BaseDiscordException
    {
        private InvalidForumTagException(string message) : base(message) { }

        internal static void ThrowIfInvalidName(string name)
        {
            const int MaxLength = 20;
            
            if (!string.IsNullOrEmpty(name) && name.Length > MaxLength)
            {
                throw new InvalidForumTagException($"{nameof(ForumTag)}.{nameof(ForumTag.Name)} cannot be more than {MaxLength} characters");
            }
        }
    }
}