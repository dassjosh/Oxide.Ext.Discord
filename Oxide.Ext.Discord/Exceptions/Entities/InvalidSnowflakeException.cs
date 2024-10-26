using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exception thrown when an invalid Snowflake ID is used in an API call
    /// </summary>
    public class InvalidSnowflakeException : BaseDiscordException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        private InvalidSnowflakeException(string message) : base(message) { }

        internal static InvalidSnowflakeException InvalidException(string paramName) => new($"Invalid Snowflake ID. Parameter Name: {paramName}");
        
        public static void ThrowIfInvalid(Snowflake snowflake, [CallerArgumentExpression("snowflake")] string paramName = null)
        {
            if (!snowflake.IsValid())
            {
                throw InvalidException(paramName);
            }
        }
        
        public static void ThrowIfInvalid(Snowflake? snowflake, [CallerArgumentExpression("snowflake")] string paramName = null)
        {
            if (snowflake.HasValue && !snowflake.Value.IsValid())
            {
                throw new InvalidSnowflakeException($"Invalid Snowflake ID. Parameter Name: {paramName}");
            }
        }
        
        public static void ThrowIfInvalid(ICollection<Snowflake> snowflakes, [CallerArgumentExpression("snowflakes")] string paramName = null)
        {
            int index = 0;
            foreach (Snowflake snowflake in snowflakes)
            {
                if (!snowflake.IsValid())
                {
                    throw new InvalidSnowflakeException($"Invalid Snowflake ID. Parameter Name: {paramName}[{index}]");
                }
                index++;
            }
        }
        
        public static void ThrowIfInvalid(Snowflake? snowflake, bool requireValue, [CallerArgumentExpression("snowflake")] string paramName = null)
        {
            if (requireValue && !snowflake.HasValue)
            {
                throw new InvalidSnowflakeException($"Snowflake is null when snowflake is required. Parameter Name: {paramName}");
            }

            if (snowflake.HasValue)
            {
                ThrowIfInvalid(snowflake.Value, paramName);
            }
        }
    }
}