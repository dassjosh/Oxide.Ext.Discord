﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Oxide.Ext.Discord.Types
{
    internal class DiscordConcurrentQueue<T> : ICollection<T>, IProducerConsumerCollection<T>, IDisposable
    {
        private readonly List<T> _list = new();
        private readonly ReaderWriterLockSlim _lock = new(LockRecursionPolicy.SupportsRecursion);

        public int Count
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    return _list.Count;
                }
                finally
                {
                    if (_lock.IsReadLockHeld) _lock.ExitReadLock();
                }
            }
        }

        public object SyncRoot => throw new NotSupportedException("The SyncRoot property may not be used for the synchronization of concurrent collections.");
        public bool IsSynchronized => false;

        public bool IsReadOnly => ((ICollection<T>)_list).IsReadOnly;

        ~DiscordConcurrentQueue()
        {
            _lock?.Dispose();
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _lock?.Dispose();
        }

        public IEnumerator<T> GetEnumerator()
        {
            _lock.EnterReadLock();
            try
            {
                int count = Count;
                for (int i = 0; i < count; i++)
                {
                    yield return _list[i];
                }
            }
            finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitReadLock();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(T item)
        {
            _lock.EnterWriteLock();
            try
            {
                _list.Add(item);
            }
            finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }
        }

        public void Clear()
        {
            _lock.EnterWriteLock();
            try
            {
                _list.Clear();
            }
            finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }
        }

        public bool Contains(T item)
        {
            _lock.EnterReadLock();
            try
            {
                return _list.Contains(item);
            }
            finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitReadLock();
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _lock.EnterReadLock();
            try
            {
                _list.CopyTo(array, arrayIndex);
            }
            finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitReadLock();
            }
        }

        public bool TryAdd(T item)
        {
            Add(item);
            return true;
        }

        public bool TryTake(out T item)
        {
            _lock.EnterWriteLock();
            try
            {
                if (Count == 0)
                {
                    item = default;
                    return false;
                }

                item = _list[0];
                _list.RemoveAt(0);
                return true;
            }
            finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }
        }

        public T[] ToArray()
        {
            _lock.EnterReadLock();
            try
            {
                return _list.ToArray();
            }
            finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitReadLock();
            }
        }

        public bool Remove(T item)
        {
            _lock.EnterWriteLock();
            try
            {
                return _list.Remove(item);
            }
            finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }
        }

        public void RemoveAll(Predicate<T> predicate)
        {
            _lock.EnterWriteLock();
            try
            {
                _list.RemoveAll(predicate);
            }
            finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }
        }
        
        public void CopyTo(Array array, int index)
        {
            throw new NotSupportedException();
        }
    }
}