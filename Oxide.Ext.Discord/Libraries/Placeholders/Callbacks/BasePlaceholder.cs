using System;
using System.Text;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    internal abstract class BasePlaceholder<TResult> : IPlaceholder
    {
        public string PluginName { get; }
        private readonly PluginId _pluginId;
        public bool IsExtensionPlaceholder { get; }
        private readonly Action<StringBuilder, PlaceholderState, TResult> _apply;

        protected BasePlaceholder(Plugin plugin)
        {
            _pluginId = plugin.Id();
            PluginName = plugin.FullName();
            IsExtensionPlaceholder = plugin is DiscordExtensionCore;
            _apply = PlaceholderFormatting.CreatePlaceholderCallback<TResult>();
        }

        public void Invoke(StringBuilder sb, PlaceholderState state)
        {
            TResult result = InvokeInternal(state);
            _apply.Invoke(sb, state, result);
        }
        
        public abstract TResult InvokeInternal(PlaceholderState state);
        
        public bool IsForPlugin(Plugin plugin) => !IsExtensionPlaceholder && plugin.Id() == _pluginId;

        public Type GetReturnType() => typeof(TResult);
    }
}