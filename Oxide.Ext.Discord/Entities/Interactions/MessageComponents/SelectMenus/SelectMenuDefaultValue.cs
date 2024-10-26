using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#select-menu-object-select-default-value-structure">Select Default Value Structure</a> within discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SelectMenuDefaultValue
    {
        /// <summary>
        /// ID of a user, role, or channel
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// Type of value that id represents. Either "user", "role", or "channel"
        /// Default 1, Min 0, Max 25
        /// </summary>
        [JsonProperty("type")]
        public SelectMenuDefaultValueType Type { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        [JsonConstructor]
        public SelectMenuDefaultValue() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of the default value</param>
        /// <param name="type">Type of the ID</param>
        public SelectMenuDefaultValue(Snowflake id, SelectMenuDefaultValueType type)
        {
            Id = id;
            Type = type;
        }
    }
}