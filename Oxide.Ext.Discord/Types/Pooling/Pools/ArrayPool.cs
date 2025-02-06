using System;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Types
{
    internal sealed class ArrayPool<TPooled> : Singleton<ArrayPool<TPooled>>, IDebugLoggable
    {
        private const int MaxArraySize = 64;
        private readonly ArrayPoolInternal[] _pool = new ArrayPoolInternal[MaxArraySize + 1];

        private ArrayPool() { }

        public TPooled[] Get(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size), "Cannot be less than 0");
            if (size == 0)
            {
                return Array.Empty<TPooled>();
            }

            if (size > MaxArraySize)
            {
                throw new ArgumentOutOfRangeException(nameof(size), $"Cannot be greater than {MaxArraySize}");
            }
            
            ArrayPoolInternal pool = _pool[size];
            if (pool == null)
            {
                pool = new ArrayPoolInternal(size);
                _pool[size] = pool;
            }

            return pool.Get();
        }

        public void Free(ref TPooled[] array)
        {
            int size = array.Length;
            if (size == 0)
            {
                return;
            }
            
            if (size > MaxArraySize)
            {
                throw new ArgumentOutOfRangeException(nameof(array), $"Array length cannot be greater than {MaxArraySize}");
            }
            
            _pool[size]?.Free(ref array);
        }
        
        public void LogDebug(DebugLogger logger)
        {
            logger.StartObject($"Array Pools <{typeof(TPooled).GetRealTypeName()}>");
            foreach (ArrayPoolInternal pool in _pool)
            {
                if (pool != null)
                {
                    logger.AppendFieldOutOf($"{typeof(TPooled).GetRealTypeName()} Size: {pool.ArraySize}", ArrayPoolInternal.MaxArrays - pool.Index, ArrayPoolInternal.MaxArrays);
                }
            }
            
            logger.EndObject();
        }

        private sealed class ArrayPoolInternal
        {
            internal const int MaxArrays = 256;
            internal ushort Index;
            private readonly TPooled[][] _pool = new TPooled[MaxArrays][];
            private readonly object _lock = new();
            internal readonly int ArraySize;
            private LeakHandler _leakHandler;

            public ArrayPoolInternal(int arraySize)
            {
                ArraySize = arraySize;
            }
            
            public TPooled[] Get()
            {
                TPooled[] array = null;
                lock (_lock)
                {
                    if (Index < _pool.Length)
                    {
                        array = _pool[Index];
                        _pool[Index] = null;
                        Index++;
                    }
                    else
                    {
                        LeakHandler leak = _leakHandler ??= new LeakHandler(DiscordExtensionCore.Instance.PluginId, $"{typeof(ArrayPool<TPooled>).GetRealTypeName()}[{ArraySize}]");
                        leak.OnLeak(Index, _pool.Length);
                    }
                }

                return array ?? new TPooled[ArraySize];
            }
            
            public void Free(ref TPooled[] item)
            {
                if (item == null)
                {
                    return;
                }

                for (int index = 0; index < item.Length; ++index)
                {
                    item[index] = default;
                }

                lock (_lock)
                {
                    if (Index != 0)
                    {
                        _pool[--Index] = item;
                    }
                }
            
                item = null;
            }
        }
    }
}