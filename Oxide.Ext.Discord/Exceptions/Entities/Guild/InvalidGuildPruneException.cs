using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an exception in guild prune requests
    /// </summary>
    public class InvalidGuildPruneException : BaseDiscordException
    {
        private InvalidGuildPruneException(string message) : base(message) { }

        internal static void ThrowIfInvalidDays(int days)
        {
            const int MinDays = 1;
            const int MaxDays = 30;

            if (days < MinDays)
            {
                throw new InvalidGuildPruneException($"{nameof(GuildPruneGet)}.{nameof(GuildPruneGet.Days)} cannot be less than {MinDays}");
            }
            
            if (days > MaxDays)
            {
                throw new InvalidGuildPruneException($"{nameof(GuildPruneGet)}.{nameof(GuildPruneGet.Days)} cannot be more than {MaxDays}");
            }
        }
    }
}