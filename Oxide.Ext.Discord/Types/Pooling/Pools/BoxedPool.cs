namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a pool for <see cref="Boxed{T}"/>;
    /// </summary>
    /// <typeparam name="T">Type that will be in the boxed object</typeparam>
    internal class BoxedPool<T> : BasePool<Boxed<T>, BoxedPool<T>>
    {
        protected override PoolSize GetPoolSize(PoolSettings settings) => new(32, 512);
        
        protected override void OnGetItem(Boxed<T> item)
        {
            item.LeavePool();
            item.Pool = PluginPool;
        }

        protected override bool OnFreeItem(ref Boxed<T> item)
        {
            item.Pool = null;
            return base.OnFreeItem(ref item);
        }

        protected override Boxed<T> CreateNew() => new();
    }
}