using Oxide.Plugins;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a pool for Hash&lt;TKey, TValue&gt;
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    internal class HashPool<TKey, TValue> : BasePool<Hash<TKey, TValue>, HashPool<TKey, TValue>>
    {
        protected override PoolSize GetPoolSize(PoolSettings settings) => settings.HashPoolSize;

        protected override Hash<TKey, TValue> CreateNew() => new();
        
        ///<inheritdoc/>
        protected override bool OnFreeItem(ref Hash<TKey, TValue> item)
        {
            item.Clear();
            return true;
        }
    }
}