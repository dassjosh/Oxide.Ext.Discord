// Originally from: https://github.com/gmamaladze/trienet
// Modified by: MJSU

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Oxide.Ext.Discord.Types
{
    [DebuggerDisplay("{DebuggerDisplay()}")]
    internal readonly struct WordKey<T> : IEquatable<WordKey<T>>
    {
        public readonly string Key;
        public readonly T Value;
        
        public WordKey(string key, T value) 
        {
            Key = key;
            Value = value;
        }

        public string DebuggerDisplay() => $"{Key}: {Value}";

        public bool Equals(WordKey<T> other)
        {
            return Key == other.Key && EqualityComparer<T>.Default.Equals(Value, other.Value);
        }
        
        public override bool Equals(object obj)
        {
            return obj is WordKey<T> other && Equals(other);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Key != null ? Key.GetHashCode() : 0) * 397) ^ EqualityComparer<T>.Default.GetHashCode(Value);
            }
        }
    }
}