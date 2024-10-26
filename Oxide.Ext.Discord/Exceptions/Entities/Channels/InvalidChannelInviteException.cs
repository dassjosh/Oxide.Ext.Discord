using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an error in channel invite
    /// </summary>
    public class InvalidChannelInviteException : BaseDiscordException
    {
        private InvalidChannelInviteException(string message) : base(message) { }
        
        internal static void ThrowIfInvalidMaxAge(int? maxAge)
        {
            const int MinAge = 0;
            const int MaxAge = 604800;

            if (!maxAge.HasValue)
            {
                return;
            }
            
            if (maxAge.Value < MinAge)
            {
                throw new InvalidChannelInviteException($"{nameof(ChannelInvite)}.{nameof(ChannelInvite.MaxAge)} cannot be less than {MinAge}");
            }
                
            if (maxAge.Value > MaxAge)
            {
                throw new InvalidChannelInviteException($"{nameof(ChannelInvite)}.{nameof(ChannelInvite.MaxAge)}  cannot be more than {MaxAge}");
            }
        }
        
        internal static void ThrowIfInvalidMaxUses(int? maxUses)
        {
            const int MinUse = 0;
            const int MaxUse = 100;

            if (!maxUses.HasValue)
            {
                return;
            }
            
            if (maxUses.Value < MinUse)
            {
                throw new InvalidChannelInviteException($"{nameof(ChannelInvite)}.{nameof(ChannelInvite.MaxUses)} cannot be less than {MinUse}");
            }
                
            if (maxUses.Value > MaxUse)
            {
                throw new InvalidChannelInviteException($"{nameof(ChannelInvite)}.{nameof(ChannelInvite.MaxUses)} cannot be more than {MaxUse}");
            }
        }
        
        internal static void ThrowIfInvalidTargetUser(Snowflake? targetUser)
        {
            if (targetUser.HasValue && !targetUser.Value.IsValid())
            {
                throw new InvalidChannelInviteException($"{nameof(ChannelInvite)}.{nameof(ChannelInvite.TargetUser)} is not a valid snowflake ID");
            }
        }
    }
}