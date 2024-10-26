using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents size constraints for a pool
    /// </summary>
    public readonly struct PoolSize
    {
        /// <summary>
        /// Starting size of the pool
        /// </summary>
        public readonly int StartingSize;
        
        /// <summary>
        /// Max size of the pool
        /// </summary>
        public readonly int MaxSize;
        
        /// <summary>
        /// If the pool size is valid
        /// </summary>
        public bool IsValid => StartingSize > 0 && MaxSize >= StartingSize;
        
        /// <summary>
        /// Constructor settings the startingSize and maxSize
        /// </summary>
        /// <param name="startingSize">Starting size of the pool</param>
        /// <param name="maxSize">Max size of the pool</param>
        public PoolSize(int startingSize, int maxSize)
        {
            InvalidPoolException.ThrowIfNotPowerOf2(startingSize, nameof(startingSize));
            InvalidPoolException.ThrowIfNotPowerOf2(maxSize, nameof(maxSize));
            StartingSize = startingSize;
            MaxSize = maxSize;
        }

        /// <summary>
        /// Returns true of the current size can be resized
        /// </summary>
        /// <param name="currentSize"></param>
        /// <returns></returns>
        public bool CanResize(int currentSize) => GetNextSize(currentSize) <= MaxSize;

        /// <summary>
        /// Returns the next size for the current size
        /// </summary>
        /// <param name="currentSize"></param>
        /// <returns></returns>
        public int GetNextSize(int currentSize) => currentSize << 1;
    }
}