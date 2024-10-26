
namespace Oxide.Ext.Discord.Types
{
    internal class ObjectPool<T> : BasePool<BasePoolable, ObjectPool<T>> where T : BasePoolable, new()
    {
        protected override PoolSize GetPoolSize(PoolSettings settings) => settings.ObjectPoolSize;
        
        protected override BasePoolable CreateNew()
        {
            T obj = new();
            obj.OnInit(PluginPool, this);
            return obj;
        }

        protected override void OnGetItem(BasePoolable item)
        {
            item.LeavePoolInternal();
        }
        
        protected override bool OnFreeItem(ref BasePoolable item)
        {
            if (item.Disposed)
            {
                return false;
            }
            
            item.EnterPoolInternal();
            return true;
        }
    }
}