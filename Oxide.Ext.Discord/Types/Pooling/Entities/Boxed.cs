using System;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Types
{
    internal class Boxed<T> : IBoxed
    {
        public T Value;
        private bool _disposed;
        internal DiscordPluginPool Pool;

        public override string ToString() => StringCache<T>.Instance.ToString(Value);

        internal void LeavePool()
        {
            _disposed = false;
        }

        public IBoxed Copy()
        {
            return Pool.GetBoxed(Value);
        }
        
        public void Dispose()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException($"{nameof(Boxed<T>)}<{typeof(T).Name}>");
            }
            
            _disposed = true;
            DiscordPool.Internal.FreeBoxed(this);
        }
    }

    internal interface IBoxed : IDisposable
    {
        IBoxed Copy();
    }
}