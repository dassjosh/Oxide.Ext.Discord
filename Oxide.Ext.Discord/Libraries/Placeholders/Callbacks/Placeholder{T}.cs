using System;
using Oxide.Core.Plugins;

namespace Oxide.Ext.Discord.Libraries.Placeholders.Callbacks
{
    internal class Placeholder<T, TResult> : BasePlaceholder<TResult>
    {
        private readonly string _dataKey;
        private readonly Func<PlaceholderState, T, TResult> _dataCallback;
        private readonly Func<T, TResult> _callback;

        public Placeholder(string dataKey, Plugin plugin, Func<PlaceholderState, T, TResult> callback) : base(plugin)
        {
            _dataKey = dataKey;
            _dataCallback = callback;
        }
        
        public Placeholder(string dataKey, Plugin plugin, Func<T, TResult> callback) : base(plugin)
        {
            _dataKey = dataKey;
            _callback = callback;
        }

        public override TResult InvokeInternal(PlaceholderState state)
        {
            T data = state.Data.Get<T>(_dataKey);
            if (data != null)
            {
                return _callback != null ? _callback(data) : _dataCallback(state, data);
            }

            return default(TResult);
        }
    }
}