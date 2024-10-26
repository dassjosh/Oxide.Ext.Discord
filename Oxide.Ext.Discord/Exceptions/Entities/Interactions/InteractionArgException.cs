using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an error when an interaction arg does not match the requested type
    /// </summary>
    public class InteractionArgException : BaseDiscordException
    {
        private InteractionArgException(string message) : base(message) { }

        internal static void ThrowIfInvalidArgType(string name, CommandOptionType arg, CommandOptionType requested)
        {
            if (arg != CommandOptionType.Mentionable)
            {
                if (arg != requested)
                {
                    throw new InteractionArgException($"Attempted to parse {name} {arg} type to: {requested} which is not valid.");
                }
            }
            else if (requested != CommandOptionType.Role && requested != CommandOptionType.User)
            {
                throw new InteractionArgException($"Attempted to parse {name} role/user type to: {requested} which is not valid.");
            }
        }
    }
}