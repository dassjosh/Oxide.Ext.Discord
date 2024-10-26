using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in guild member
    /// </summary>
    public class InvalidGuildMemberException : BaseDiscordException
    {
        private InvalidGuildMemberException(string message) : base(message) { }

        internal static void ThrowIfInvalidNickname(string nickname)
        {
            const int MaxLength = 32;
            
            if (!string.IsNullOrEmpty(nickname) && nickname.Length > MaxLength)
            {
                throw new InvalidGuildMemberException($"{nameof(GuildMemberUpdate)}.{nameof(GuildMemberUpdate.Nick)} cannot be more than {MaxLength} characters");
            }
        }
    }
}