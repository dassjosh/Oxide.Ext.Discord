using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Types
{
    internal class PlaceholderDataPool : BasePool<BasePoolable, PlaceholderDataPool>
    {
        protected override PoolSize GetPoolSize(PoolSettings settings) => settings.PlaceholderDataPoolSize;
        
        protected override BasePoolable CreateNew()
        {
            PlaceholderData data = new();
            data.OnInit(PluginPool, this);
            return data;
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