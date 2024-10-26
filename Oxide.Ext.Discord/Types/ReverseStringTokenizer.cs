using System;

namespace Oxide.Ext.Discord.Types
{
    internal ref struct ReverseStringTokenizer
    {
        private ReadOnlySpan<char> _remaining;
        private readonly ReadOnlySpan<char> _token;

        public ReadOnlySpan<char> Current { get; private set; }
        
        public ReverseStringTokenizer(string str, string token)
        {
            _remaining = str;
            _token = token;
            Current = default;
        }

        public bool MoveNext()
        {
            if (_remaining.Length == 0)
            {
                return false;
            }
            
            int index = _remaining.LastIndexOf(_token);
            if (index < 0)
            {
                Current = _remaining;
                _remaining = default;
                return true;
            }
            
            int length = _remaining.Length - index;
            if (length <= 1)
            {
                _remaining = _remaining.Slice(0, index);
                return MoveNext();
            }

            Current = _remaining.Slice(index + 1, length - 1);
            _remaining = _remaining.Slice(0, Math.Min(index, _remaining.Length));
            return true;
        }
    }
}