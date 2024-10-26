using System.Collections.Generic;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Represents a Template that supports bulk operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBulkTemplate<T> where T : class
    {
        /// <summary>
        /// return the {T} entity with the given placeholder data
        /// If entity is not specified a new one will be created
        /// </summary>
        /// <param name="data">Placeholder Data to apply</param>
        /// <param name="entity">Initial entity</param>
        /// <returns></returns>
        T ToEntity(PlaceholderData data = null, T entity = null);
        
        /// <summary>
        /// Returns a promise that returns a bulk to entity.
        /// </summary>
        /// <param name="data">List of data to be bulk converter</param>
        /// <returns></returns>
        IPromise<List<T>> ToEntityBulk(List<PlaceholderData> data = null);
    }
}