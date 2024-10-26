using System;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a poolable object
    /// </summary>
    public abstract class BasePoolable : IDisposable
    {
        internal DiscordPluginPool PluginPool { get; private set; }

        /// <summary>
        /// Returns if the object should be pooled.
        /// This field is set to true when leaving the pool.
        /// If the object instantiated using new() outside the pool it will be false
        /// </summary>
        private bool _shouldPool;
        internal bool Disposed;
        
        private IPool<BasePoolable> _pool;

        internal void OnInit(DiscordPluginPool pluginPool, IPool<BasePoolable> pool)
        {
            PluginPool = pluginPool;
            _pool = pool;
        }

        internal void EnterPoolInternal()
        {
            EnterPool();
            _shouldPool = false;
            Disposed = true;
        }

        internal void LeavePoolInternal()
        {
            _shouldPool = true;
            Disposed = false;
            LeavePool();
        }

        /// <summary>
        /// Called when the object is returned to the pool.
        /// Can be overriden in child classes to cleanup used data
        /// </summary>
        protected virtual void EnterPool()
        {
            
        }
        
        /// <summary>
        /// Called when the object leaves the pool.
        /// Can be overriden in child classes to set the initial object state
        /// </summary>
        protected virtual void LeavePool()
        {
            
        }

        /// <summary>
        /// Disposes the object when used in a using statement
        /// </summary>
        public void Dispose()
        {
            if (!_shouldPool)
            {
                return;
            }
            
            if (Disposed)
            {
                throw new ObjectDisposedException(GetType().GetRealTypeName());
            }
                
            _pool.Free(this);
        }
    }
}