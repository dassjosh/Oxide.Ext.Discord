using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in guild member search requests
    /// </summary>
    public class InvalidGuildSearchMembersException : BaseDiscordException
    {
        private InvalidGuildSearchMembersException(string message) : base(message) { }

        internal static void ThrowIfInvalidQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new InvalidGuildSearchMembersException($"{nameof(GuildSearchMembers)}.{nameof(GuildSearchMembers.Query)} cannot be less than 1 character");
            }
        }
        
        internal static void ThrowIfInvalidLimit(int? limit)
        {
            const int MinLimit = 0;
            const int MaxLimit = 1000;
            
            if (limit < MinLimit)
            {
                throw new InvalidGuildSearchMembersException($"{nameof(GuildSearchMembers)}.{nameof(GuildSearchMembers.Limit)} cannot be less than {MinLimit}");
            }
            
            if (limit > MaxLimit)
            {
                throw new InvalidGuildSearchMembersException($"{nameof(GuildSearchMembers)}.{nameof(GuildSearchMembers.Limit)} cannot be more than {MaxLimit}");
            }
        }
    }
}