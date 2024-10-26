using System;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Types
{
    internal sealed class ArrayPool<TPooled> : Singleton<ArrayPool<TPooled>>
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

        private class ArrayPoolInternal
        {
            private const int MaxArrays = 64;
            private ushort _index;
            private readonly TPooled[][] _pool = new TPooled[MaxArrays][];
            private readonly object _lock = new();
            private readonly int _arraySize;

            public ArrayPoolInternal(int arraySize)
            {
                _arraySize = arraySize;
            }
            
            public TPooled[] Get()
            {
                TPooled[] array = null;
                lock (_lock)
                {
                    if (_index < _pool.Length)
                    {
                        array = _pool[_index];
                        _pool[_index] = null;
                        _index++;
                    }
                    else
                    {
                        DiscordExtension.GlobalLogger.Warning("Pool {0} is leaking entities!!! {1}/{2}", GetType(), _index, _pool.Length);
                    }
                }

                return array ?? new TPooled[_arraySize];
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
                    if (_index != 0)
                    {
                        _pool[--_index] = item;
                    }
                }
            
                item = null;
            }
        }
    }
}