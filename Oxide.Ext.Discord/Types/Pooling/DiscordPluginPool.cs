using System.Collections.Generic;
using System.IO;
using System.Text;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Built in pooling for discord entities
    /// </summary>
    public class DiscordPluginPool : IDebugLoggable
    {
        private readonly List<IPool> _pools = new();
        private PoolSettings _settings;

        internal PoolSettings Settings => _settings ?? DefaultSettings;
        internal readonly PluginId PluginId;
        internal readonly string PluginName;

        private static readonly PoolSettings DefaultSettings = new();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="plugin">Plugin the pool is for</param>
        public DiscordPluginPool(Plugin plugin)
        {
            PluginId = plugin.Id();
            PluginName = plugin.FullName();
        }

        /// <summary>
        /// Sets the settings for the pools
        /// </summary>
        /// <param name="settings"></param>
        public void SetSettings(PoolSettings settings)
        {
            _settings = settings;
        }

        internal void AddPool(IPool pool) => _pools.Add(pool);
        
        /// <summary>
        /// Returns a pooled object of {T} type
        /// Must inherit from <see cref="BasePoolable"/> and have an empty default constructor
        /// </summary>
        /// <typeparam name="T">Type to be returned</typeparam>
        /// <returns>Pooled object of type T</returns>
        public T Get<T>() where T : BasePoolable, new()
        {
            return (T)ObjectPool<T>.ForPlugin(this).Get();
        }

        /// <summary>
        /// Returns a <see cref="BasePoolable"/> back into the pool
        /// </summary>
        /// <param name="value">Object to free</param>
        /// <typeparam name="T">Type of object being freed</typeparam>
        internal void Free<T>(T value) where T : BasePoolable, new()
        {
            ObjectPool<T>.ForPlugin(this).Free(value);
        }

        /// <summary>
        /// Returns a pooled <see cref="List{T}"/>
        /// </summary>
        /// <typeparam name="T">Type for the list</typeparam>
        /// <returns>Pooled List</returns>
        public List<T> GetList<T>()
        {
            return ListPool<T>.ForPlugin(this).Get();
        }

        /// <summary>
        /// Free's a pooled <see cref="List{T}"/>
        /// </summary>
        /// <param name="list">List to be freed</param>
        /// <typeparam name="T">Type of the list</typeparam>
        public void FreeList<T>(List<T> list)
        {
            ListPool<T>.ForPlugin(this).Free(list);
        }

        /// <summary>
        /// Returns a pooled <see cref="Hash{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">Type for the key</typeparam>
        /// <typeparam name="TValue">Type for the value</typeparam>
        /// <returns>Pooled Hash</returns>
        public Hash<TKey, TValue> GetHash<TKey, TValue>()
        {
            return HashPool<TKey, TValue>.ForPlugin(this).Get();
        }

        /// <summary>
        /// Frees a pooled <see cref="Hash{TKey, TValue}"/>
        /// </summary>
        /// <param name="hash">Hash to be freed</param>
        /// <typeparam name="TKey">Type for key</typeparam>
        /// <typeparam name="TValue">Type for value</typeparam>
        public void FreeHash<TKey, TValue>(Hash<TKey, TValue> hash)
        {
            HashPool<TKey, TValue>.ForPlugin(this).Free(hash);
        }
        
        /// <summary>
        /// Returns a pooled <see cref="HashSet{T}"/>
        /// </summary>
        /// <typeparam name="T">Type for the HashSet</typeparam>
        /// <returns>Pooled List</returns>
        public HashSet<T> GetHashSet<T>()
        {
            return HashSetPool<T>.ForPlugin(this).Get();
        }

        /// <summary>
        /// Free's a pooled <see cref="HashSet{T}"/>
        /// </summary>
        /// <param name="list">HashSet to be freed</param>
        /// <typeparam name="T">Type of the HashSet</typeparam>
        public void FreeHashSet<T>(HashSet<T> list)
        {
            HashSetPool<T>.ForPlugin(this).Free(list);
        }

        /// <summary>
        /// Returns a pooled <see cref="StringBuilder"/>
        /// </summary>
        /// <returns>Pooled <see cref="StringBuilder"/></returns>
        public StringBuilder GetStringBuilder()
        {
            return StringBuilderPool.ForPlugin(this).Get();
        }
        
        /// <summary>
        /// Returns a pooled <see cref="StringBuilder"/>
        /// </summary>
        /// <param name="initial">Initial text for the builder</param>
        /// <returns>Pooled <see cref="StringBuilder"/></returns>
        public StringBuilder GetStringBuilder(string initial)
        {
            StringBuilder builder = StringBuilderPool.ForPlugin(this).Get();
            builder.Append(initial);
            return builder;
        }

        /// <summary>
        /// Frees a <see cref="StringBuilder"/> back to the pool
        /// </summary>
        /// <param name="sb">StringBuilder being freed</param>
        public void FreeStringBuilder(StringBuilder sb)
        {
            StringBuilderPool.ForPlugin(this).Free(sb);
        }

        /// <summary>
        /// Frees a <see cref="StringBuilder"/> back to the pool returning the built <see cref="string"/>
        /// </summary>
        /// <param name="sb"><see cref="StringBuilder"/> being freed</param>
        public string ToStringAndFree(StringBuilder sb)
        {
            string result = sb?.ToString();
            FreeStringBuilder(sb);
            return result;
        }

        /// <summary>
        /// Returns a pooled <see cref="MemoryStream"/>
        /// </summary>
        /// <returns>Pooled <see cref="MemoryStream"/></returns>
        public MemoryStream GetMemoryStream()
        {
            return MemoryStreamPool.ForPlugin(this).Get();
        }

        /// <summary>
        /// Frees a <see cref="MemoryStream"/> back to the pool
        /// </summary>
        /// <param name="stream"><see cref="MemoryStream"/> being freed</param>
        public void FreeMemoryStream(MemoryStream stream)
        {
            MemoryStreamPool.ForPlugin(this).Free(stream);
        }

        /// <summary>
        /// Returns a pooled <see cref="PlaceholderData"/>
        /// </summary>
        /// <returns>Pooled <see cref="PlaceholderData"/></returns>
        internal PlaceholderData GetPlaceholderData()
        {
            return (PlaceholderData)PlaceholderDataPool.ForPlugin(this).Get();
        }

        /// <summary>
        /// Frees a <see cref="PlaceholderData"/> back to the pool
        /// </summary>
        /// <param name="data"><see cref="PlaceholderData"/> being freed</param>
        internal void FreePlaceholderData(PlaceholderData data)
        {
            PlaceholderDataPool.ForPlugin(this).Free(data);
        }
        
        /// <summary>
        /// Returns a pooled <see cref="Boxed{T}"/>
        /// </summary>
        /// <typeparam name="T">Type for the Boxed</typeparam>
        /// <returns>Pooled Boxed</returns>
        internal Boxed<T> GetBoxed<T>(T value)
        {
            Boxed<T> boxed = BoxedPool<T>.ForPlugin(this).Get();
            boxed.Value = value;
            return boxed;
        }

        /// <summary>
        /// Free's a pooled <see cref="BoxedPool{T}"/>
        /// </summary>
        /// <param name="boxed">Boxed to be freed</param>
        /// <typeparam name="T">Type of the Boxed</typeparam>
        internal void FreeBoxed<T>(Boxed<T> boxed)
        {
            BoxedPool<T>.ForPlugin(this).Free(boxed);
        }

        internal void OnPluginUnloaded()
        {
            for (int index = 0; index < _pools.Count; index++)
            {
                IPool pool = _pools[index];
                pool.OnPluginUnloaded(this);
            }
        }
        
        internal void Clear()
        {
            for (int index = 0; index < _pools.Count; index++)
            {
                IPool pool = _pools[index];
                pool.ClearPoolEntities();
            }
        }

        internal void Wipe()
        {
            for (int index = 0; index < _pools.Count; index++)
            {
                IPool pool = _pools[index];
                pool.RemoveAllPools();
            }
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.StartArray(PluginId.PluginName());
            foreach (IPool pool in _pools)
            {
                pool.LogDebug(logger);
            }
            logger.EndArray();
        }
    }
}