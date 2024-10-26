using System.Collections.Generic;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a pool for Hash&lt;TKey, TValue&gt;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class HashSetPool<T> : BasePool<HashSet<T>, HashSetPool<T>>
    {
        protected override PoolSize GetPoolSize(PoolSettings settings) => settings.HashSetPoolSize;
        
        protected override HashSet<T> CreateNew() => new();
        
        ///<inheritdoc/>
        protected override bool OnFreeItem(ref HashSet<T> item)
        {
            item.Clear();
            return true;
        }
    }
}