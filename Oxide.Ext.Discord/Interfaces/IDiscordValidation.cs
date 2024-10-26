using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Interfaces
{
    internal interface IDiscordValidation
    {
        /// <summary>
        /// Validates data being passed to the discord API.
        /// Throws an exception with a base type of <see cref="BaseDiscordException"/> if the validation fails
        /// </summary>
        void Validate();
    }
}