using Oxide.Core.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    internal class StaticPlaceholder : BasePlaceholder<string>
    {
        private readonly string _value;
        
        public StaticPlaceholder(Plugin plugin, string value) : base(plugin) 
        {
            _value = value;
        }

        public override string InvokeInternal(PlaceholderState state) => _value;
    }
}