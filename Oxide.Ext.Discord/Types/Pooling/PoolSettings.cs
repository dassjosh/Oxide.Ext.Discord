namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Settings for the pools
    /// </summary>
    public class PoolSettings
    {
        /// <summary>
        /// Size of the <see cref="HashPool{TKey,TValue}"/>
        /// </summary>
        public PoolSize HashPoolSize = new(32, 256);
        
        /// <summary>
        /// Size of the <see cref="HashSetPool{T}"/>
        /// </summary>
        public PoolSize HashSetPoolSize { get; set; } = new(32, 256);
        
        /// <summary>
        /// Size of the <see cref="ListPool{T}"/>
        /// </summary>
        public PoolSize ListPoolSize { get; set; } = new(32, 256);
        
        /// <summary>
        /// Size of the <see cref="MemoryStreamPool"/>
        /// </summary>
        public PoolSize MemoryStreamPoolSize { get; set; } = new(32, 256);
        
        /// <summary>
        /// Size of the <see cref="ObjectPool{T}"/>
        /// </summary>
        public PoolSize ObjectPoolSize { get; set; } = new(32, 256);
        
        /// <summary>
        /// Size of the <see cref="PlaceholderDataPool"/>
        /// </summary>
        public PoolSize PlaceholderDataPoolSize { get; set; } = new(32, 512);
        
        /// <summary>
        /// Size of the <see cref="StringBuilderPool"/>
        /// </summary>
        public PoolSize StringBuilderPoolSize { get; set; } = new(32, 256);

        internal static PoolSettings CreateInternal() => new()
        {
            HashPoolSize = new PoolSize(128, 1024),
            HashSetPoolSize = new PoolSize(128, 1024),
            ListPoolSize = new PoolSize(128, 1024),
            MemoryStreamPoolSize = new PoolSize(128, 1024),
            ObjectPoolSize = new PoolSize(128, 1024),
            PlaceholderDataPoolSize = new PoolSize(128, 1024),
            StringBuilderPoolSize = new PoolSize(128, 1024),
        };
    }
}