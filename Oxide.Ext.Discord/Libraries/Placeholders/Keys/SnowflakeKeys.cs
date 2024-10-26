using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="Snowflake"/>
    /// </summary>
    public class SnowflakeKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="Snowflake.Id"/>
        /// </summary>
        public readonly PlaceholderKey Id;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="Snowflake.GetCreationDate"/>
        /// </summary>
        public readonly PlaceholderKey Created;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public SnowflakeKeys(string prefix)
        {
            Id = new PlaceholderKey(prefix, "id");
            Created = new PlaceholderKey(prefix, "created");
        }
    }
}