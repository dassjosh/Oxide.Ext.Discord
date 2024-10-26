using System.Text;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Pool for StringBuilders
    /// </summary>
    internal class StringBuilderPool : BasePool<StringBuilder, StringBuilderPool>
    {
        protected override PoolSize GetPoolSize(PoolSettings settings) => settings.StringBuilderPoolSize;
        
        protected override StringBuilder CreateNew() => new();

        ///<inheritdoc/>
        protected override bool OnFreeItem(ref StringBuilder item)
        {
            item.Clear();
            return true;
        }
    }
}