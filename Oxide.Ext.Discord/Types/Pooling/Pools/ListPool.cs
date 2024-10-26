using System.Collections.Generic;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a pool for list&lt;T&gt;
    /// </summary>
    /// <typeparam name="T">Type that will be in the list</typeparam>
    internal class ListPool<T> : BasePool<List<T>, ListPool<T>>
    {
        protected override PoolSize GetPoolSize(PoolSettings settings) => settings.ListPoolSize;
        
        protected override List<T> CreateNew() => new();
        
        ///<inheritdoc/>
        protected override bool OnFreeItem(ref List<T> item)
        {
            item.Clear();
            return true;
        }
    }
}