using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in guid list request
    /// </summary>
    public class InvalidGuildListMembersException : BaseDiscordException
    {
        private InvalidGuildListMembersException(string message) : base(message) { }
        
        internal static void ThrowIfInvalidLimit(int? limit)
        {
            const int MinLimit = 0;
            const int MaxLimit = 1000;
            
            if (limit < MinLimit)
            {
                throw new InvalidGuildListMembersException($"{nameof(GuildListMembers)}.{nameof(GuildListMembers.Limit)} cannot be less than {MinLimit}");
            }
            
            if (limit > MaxLimit)
            {
                throw new InvalidGuildListMembersException($"{nameof(GuildListMembers)}.{nameof(GuildListMembers.Limit)} cannot be more than {MaxLimit}");
            }
        }
    }
}