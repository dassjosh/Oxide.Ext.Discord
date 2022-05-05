using System.Collections.Generic;

namespace Oxide.Ext.Discord.Pooling
{
    /// <summary>
    /// Represents a pool for list&lt;T&gt;
    /// </summary>
    /// <typeparam name="T">Type that will be in the list</typeparam>
    public class ListPool<T> : BasePool<List<T>>
    {
        internal ListPool() : base(32) { }
        
        ///<inheritdoc/>
        protected override bool OnFreeItem(ref List<T> item)
        {
            item.Clear();
            return true;
        }
    }
}