using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Represents entities that are cacheable by the DiscordExtension
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDiscordCacheable<in T>
    {
        /// <summary>
        /// ID of the entity
        /// </summary>
        Snowflake Id { get; set; }

        /// <summary>
        /// Method to update the entity
        /// </summary>
        /// <param name="update">Update data to apply</param>
        void Update(T update);
    }
}