namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a pool of type T
    /// </summary>
    /// <typeparam name="T">Type to be pooled</typeparam>
    public interface IPool<T> : IPool
    {
        /// <summary>
        /// Returns the Pooled type or a new instance if pool is empty.
        /// </summary>
        /// <returns></returns>
        T Get();

        /// <summary>
        /// Returns the pooled type to the pool
        /// </summary>
        /// <param name="poolable"></param>
        void Free(T poolable);
    }
}