using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an error in channel ban
    /// </summary>
    public class InvalidGuildBanException : BaseDiscordException
    {
        private InvalidGuildBanException(string message) : base(message) { }
        
        internal static void ThrowIfInvalidDeleteMessageSeconds(int? seconds)
        {
            const int MinSeconds = 0;
            const int MaxSeconds = 604800;

            if (!seconds.HasValue)
            {
                return;
            }
            
            if (seconds.Value < MinSeconds)
            {
                throw new InvalidGuildBanException($"{nameof(GuildBanCreate)}.{nameof(GuildBanCreate.DeleteMessageSeconds)} cannot be less than {MinSeconds} days");
            }
                
            if (seconds.Value < MaxSeconds)
            {
                throw new InvalidGuildBanException($"{nameof(GuildBanCreate)}.{nameof(GuildBanCreate.DeleteMessageSeconds)} cannot be more than {MaxSeconds} days");
            }
        }
    }
}