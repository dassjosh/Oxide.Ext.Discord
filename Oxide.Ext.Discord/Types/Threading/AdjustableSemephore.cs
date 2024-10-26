using System;
using System.Threading;
using System.Threading.Tasks;

namespace Oxide.Ext.Discord.Types
{
    internal class AdjustableSemaphore
    {
        private readonly object _syncRoot = new();
        private int _maximum;
        public int Available { get; private set; }

        public AdjustableSemaphore(int maximumCount)
        {
            MaximumCount = maximumCount;
        }

        public int MaximumCount
        {
            get
            {
                lock (_syncRoot)
                {
                    return _maximum;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Must be greater than or equal to 0.", nameof(MaximumCount));
                    }
                    
                    Available += value - _maximum;
                    _maximum = value;
                    Monitor.PulseAll(_syncRoot);
                }
            }
        }

        public ValueTask WaitOneAsync()
        {
            lock (_syncRoot)
            {
                while (Available <= 0)
                {
                    Monitor.Wait(_syncRoot);
                }
                Available--;
            }

            return new ValueTask();
        }

        public void Release()
        {
            lock (_syncRoot)
            {
                if (Available + 1 <= _maximum)
                {
                    Available += 1;
                    Monitor.Pulse(_syncRoot);
                }
                else
                {
                    throw new Exception($"Adding 1 the given count to the semaphore would cause it to exceed its maximum count of {_maximum}.");
                }
            }
        }

        public void AllowAllThrough()
        {
            MaximumCount = int.MaxValue;
            //Needs to be in a lock or an exception is thrown
            lock (_syncRoot)
            {
                Monitor.PulseAll(_syncRoot);
            }
        }

        public void Reset()
        {
            MaximumCount = 1;
        }
    }
}