using System;
using System.Collections.Concurrent;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a BasePool in Discord
    /// </summary>
    /// <typeparam name="TPooled">Type being pooled</typeparam>
    /// <typeparam name="TPool">Type of the pool</typeparam>
    public abstract class BasePool<TPooled, TPool> : IPool<TPooled> 
        where TPooled : class 
        where TPool : BasePool<TPooled, TPool>, new()
    {
        /// <summary>
        /// Plugin Pool for this pool
        /// </summary>
        protected DiscordPluginPool PluginPool;
        
        private TPooled[] _pool;
        private int _index;
        private readonly object _lock = new();
        private PoolSize _size;
        private bool _isFirstLeakError = true;
        private DateTime _nextLeakError;
        private bool _isInitialized;
        
        private static readonly ConcurrentDictionary<PluginId, TPool> Pools = new();

        private void InitPool(DiscordPluginPool pluginPool)
        {
            lock (_lock)
            {
                if (_isInitialized)
                {
                    return;
                }
                _size = GetPoolSize(pluginPool.Settings);
                InvalidPoolException.ThrowIfInvalidPoolSize(_size);
                PluginPool = pluginPool;
                pluginPool.AddPool(this);
                _pool = new TPooled[_size.StartingSize];
                _isInitialized = true;
                DiscordExtension.GlobalLogger.Debug("Creating Pool. Plugin ID: {0} Type: {1}", pluginPool.PluginName, typeof(TPool).GetRealTypeName());
            }
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
        public static TPool ForPlugin(DiscordPluginPool pluginPool)
        {
            TPool pool = Pools.GetOrAdd(pluginPool.PluginId, CreatePool);
            if (!pool._isInitialized)
            {
                pool.InitPool(pluginPool);
            }
            return pool;
        }

        private static TPool CreatePool(PluginId id) => new();
        /// <summary>
        /// Returns an element from the pool if it exists else it creates a new one
        /// </summary>
        /// <returns></returns>
        public TPooled Get()
        {
            TPooled item = null;
            lock (_lock)
            {
                if (_index == _pool.Length && _size.CanResize(_pool.Length))
                {
                    int nextSize = _size.GetNextSize(_pool.Length);
                    DiscordExtension.GlobalLogger.Debug("{0} Resizing Pool {1} Current Size: {2} Next Size: {3}", PluginPool.PluginName, GetType(), _pool.Length, nextSize);
                    Array.Resize(ref _pool, nextSize);
                }
                
                if (_index < _pool.Length)
                {
                    item = _pool[_index];
                    _pool[_index] = null;
                    _index++;
                }
                else if(ShouldLogLeak())
                {
                    DiscordExtension.GlobalLogger.Warning("{0} Pool {1} is leaking entities!!! {2}/{3}", PluginPool.PluginName, GetType(), _index, _pool.Length);
                }
            }
                
            item ??= CreateNew();
                
            OnGetItem(item);
            return item;
        }

        private bool ShouldLogLeak()
        {
            if (!PluginPool.PluginId.IsExtensionPlugin)
            {
                return true;
            }

            if (_isFirstLeakError)
            {
                _isFirstLeakError = false;
                return false;
            }

            if (_nextLeakError < DateTime.UtcNow)
            {
                return false;
            }
            
            _nextLeakError = DateTime.UtcNow + TimeSpan.FromSeconds(30);
            return true;
        }

        /// <summary>
        /// Creates a new type of T
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
            Pools.TryRemove(pluginPool.PluginId, out TPool _);
        }

        /// <summary>
        /// Clears the pool of all pooled objects and resets state to when the pool was first created
        /// </summary>
        public void ClearPoolEntities()
        {
            lock (_lock)
            {
                for (int i = _pool.Length - 1; i >= 0; i--)
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
        /// <returns>True if the item can be freed; false otherwise</returns>
        protected virtual bool OnFreeItem(ref TPooled item)
        {
            return true;
        }
        
        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.StartObject($"{GetType().GetRealTypeName()}");
            logger.AppendFieldOutOf("Pool", _pool.Length - _index, _pool.Length);
            logger.EndObject();
        }
    }
}