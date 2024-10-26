using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in guild schedule event lookup requests
    /// </summary>
    public class InvalidGuildScheduledEventLookupException : BaseDiscordException
    {
        private InvalidGuildScheduledEventLookupException(string message) : base(message) { }

        internal static void ThrowIfInvalidLimit(int? limit)
        {
            const int MaxLimit = 100;
            if (limit > MaxLimit)
            {
                throw new InvalidGuildScheduledEventLookupException($"{nameof(ScheduledEventUsersLookup)}.{nameof(ScheduledEventUsersLookup.Limit)} cannot be greater than {MaxLimit}");
            }
        }
    }
}