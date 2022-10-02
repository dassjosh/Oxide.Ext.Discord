using System.IO;

namespace Oxide.Ext.Discord.Pooling
{
    /// <summary>
    /// Represents a pool for MemoryStream
    /// </summary>
    internal class MemoryStreamPool : BasePool<MemoryStream>
    {
        internal static readonly IPool<MemoryStream> Instance = new MemoryStreamPool();
        
        static MemoryStreamPool()
        {
            DiscordPool.Pools.Add(Instance);
        }

        private MemoryStreamPool() : base(256) { }

        protected override MemoryStream CreateNew() => new MemoryStream();

        ///<inheritdoc/>
        protected override bool OnFreeItem(ref MemoryStream item)
        {
            item.SetLength(0);
            return true;
        }
    }
}