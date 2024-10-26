// Originally from: https://github.com/gmamaladze/trienet
// Modified by: MJSU

using System;

namespace Oxide.Ext.Discord.Types
{
    internal readonly struct EdgeKey<T> : IEquatable<EdgeKey<T>>
    {
        public readonly char Key;
        public readonly Edge<T> Value;

        public EdgeKey(char key, Edge<T> value)
        {
            Key = key;
            Value = value;
        }
        public bool Equals(EdgeKey<T> other)
        {
            return Key == other.Key && Equals(Value, other.Value);
        }
        
        public override bool Equals(object obj)
        {
            return obj is EdgeKey<T> other && Equals(other);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                return (Key.GetHashCode() * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }
    }
}