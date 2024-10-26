namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="Application Role Connection Metadata Structure">Application Role Connection Metadata Type</a>
    /// </summary>
    public enum ApplicationRoleConnectionMetadataType : byte
    {
        /// <summary>
        /// The metadata value (integer) is less than or equal to the guild's configured value (integer)
        /// </summary>
        IntegerLessThanOrEqual = 1,
        
        /// <summary>
        /// The metadata value (integer) is greater than or equal to the guild's configured value (integer)
        /// </summary>
        IntegerGreaterThanOrEqual = 2,
        
        /// <summary>
        /// The metadata value (integer) is equal to the guild's configured value (integer)
        /// </summary>
        IntegerEqual = 3,
        
        /// <summary>
        /// The metadata value (integer) is not equal to the guild's configured value (integer)
        /// </summary>
        IntegerNotEqual = 4,
        
        /// <summary>
        /// The metadata value (ISO8601 string) is less than or equal to the guild's configured value (integer; days before current date)
        /// </summary>
        DatetimeLessThanOrEqual = 5,
        
        /// <summary>
        /// The metadata value (ISO8601 string) is greater than or equal to the guild's configured value (integer; days before current date)
        /// </summary>
        DatetimeGreaterThanOrEqual = 6,
        
        /// <summary>
        /// The metadata value (integer) is equal to the guild's configured value (integer; 1)
        /// </summary>
        BooleanEqual = 7,
        
        /// <summary>
        /// The metadata value (integer) is not equal to the guild's configured value (integer; 1)
        /// </summary>
        BooleanNotEqual = 8,
    }
}