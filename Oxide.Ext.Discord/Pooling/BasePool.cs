using System;
using System.Text;
using Oxide.Ext.Discord.Exceptions.Pooling;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Pooling
{
    /// <summary>
    /// Represents a BasePool in Discord
    /// </summary>
    /// <typeparam name="TPooled">Type being pooled</typeparam>
    public abstract class BasePool<TPooled> : IPool<TPooled> where TPooled : class
    {
        /// <summary>
        /// Plugin Pool for this pool
        /// </summary>
        protected DiscordPluginPool PluginPool;
        
        private TPooled[] _pool;
        private int _index;
        private readonly object _lock = new object();
        private PoolSize _size;
        private static readonly Hash<PluginId, BasePool<TPooled>> Pools = new Hash<PluginId, BasePool<TPooled>>();
        private readonly StringBuilder _sb = new StringBuilder();
        
        private void InitPool(DiscordPluginPool pluginPool)
        {
            PluginPool = pluginPool;
            pluginPool.AddPool(this);
            Pools[pluginPool.PluginId] = this;
            _size = GetPoolSize(pluginPool.Settings);
            InvalidPoolException.ThrowIfInvalidPoolSize(_size);
            _pool = new TPooled[_size.StartingSize];
        }

        /// <summary>
        /// Returns the pool size from the pool settings for the pool
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        protected abstract PoolSize GetPoolSize(PoolSettings settings);

        /// <summary>
        /// Returns a pool for the given plugin pool
        /// </summary>
        /// <param name="pluginPool"><see cref="DiscordPluginPool"/> to get the pool from</param>
        /// <returns></returns>
        protected static T ForPlugin<T>(DiscordPluginPool pluginPool) where T : BasePool<TPooled>, new()
        {
            if (!(Pools[pluginPool.PluginId] is T pool))
            {
                pool = new T();
                pool.InitPool(pluginPool);
            }

            return pool;
        }

        /// <summary>
        /// Returns an element from the pool if it exists else it creates a new one
        /// </summary>
        /// <returns></returns>
        /// TODO: Remove after issue is found
        public TPooled Get()
        {
            try
            {
                _sb.Clear();
                _sb.Append($"A: {PluginPool == null} {_pool == null}");
                TPooled item = null;
                lock (_lock)
                {
                    _sb.Append("B");
                    if (_index == _pool.Length && _size.CanResize(_pool.Length))
                    {
                        _sb.Append("B1");
                        int nextSize = _size.GetNextSize(_pool.Length);
                        DiscordExtension.GlobalLogger.Debug("{0} Resizing Pool {1} Current Size: {2} Next Size: {3}", PluginPool.PluginName, GetType(), _pool.Length, nextSize);
                        Array.Resize(ref _pool, nextSize);
                    }

                    if (_index < _pool.Length)
                    {
                        _sb.Append("C");
                        item = _pool[_index];
                        _pool[_index] = null;
                        _index++;
                        _sb.Append("D");
                    }
                    else
                    {
                        _sb.Append("E");
                        DiscordExtension.GlobalLogger.Warning("{0} Pool {1} is leaking entities!!! {2}/{3}", PluginPool.PluginName, GetType(), _index, _pool.Length);
                        _sb.Append("F");
                    }
                }

                _sb.Append("G");
                if (item == null)
                {
                    _sb.Append("H");
                    item = CreateNew();
                    _sb.Append("I");
                }

                _sb.Append("J");
                OnGetItem(item);
                _sb.Append("K");
                return item;
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Error($"{_sb.ToString()}\n{ex.ToString()}");
                throw;
            }
        }

        /// <summary>
        /// Creates new type of T
        /// </summary>
        /// <returns>Newly created type of T</returns>
        protected abstract TPooled CreateNew();

        /// <summary>
        /// Frees an item back to the pool
        /// </summary>
        /// <param name="item">Item being freed</param>
        public void Free(TPooled item) => Free(ref item);

        private void Free(ref TPooled item)
        {
            if (item == null)
            {
                return;
            }

            if (!OnFreeItem(ref item))
            {
                //DiscordExtension.GlobalLogger.Debug("Skip Free Item: {0}", typeof(T).Name);
                return;
            }

            lock (_lock)
            {
                if (_index != 0)
                {
                    _index--;
                    _pool[_index] = item;
                }
            }
            
            item = null;
        }
        
        ///<inheritdoc/>
        public void OnPluginUnloaded(DiscordPluginPool pluginPool)
        {
            Pools.Remove(pluginPool.PluginId);
        }

        /// <summary>
        /// Clears the pool of all pooled objects and resets state to when the pool was first created
        /// </summary>
        public void ClearPoolEntities()
        {
            lock (_lock)
            {
                for (int i = _index; i >= 0; i--)
                {
                    _pool[i] = null;
                }
                _index = 0;
            }
        }

        /// <summary>
        /// Wipes all the pools for this type
        /// </summary>
        public void RemoveAllPools()
        {
            Pools.Clear();
        }

        /// <summary>
        /// Called when an item is retrieved from the pool
        /// </summary>
        /// <param name="item">Item being retrieved</param>
        protected virtual void OnGetItem(TPooled item)
        {
            
        }
        
        /// <summary>
        /// Returns if an item can be freed to the pool
        /// </summary>
        /// <param name="item">Item to be freed</param>
        /// <returns>True if can be freed; false otherwise</returns>
        protected virtual bool OnFreeItem(ref TPooled item)
        {
            return true;
        }
    }
}