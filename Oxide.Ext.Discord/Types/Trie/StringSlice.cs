// Originally from: https://github.com/gmamaladze/trienet
// Modified by: MJSU

using System;
using System.Diagnostics;

namespace Oxide.Ext.Discord.Types
{
    [Serializable]
    [DebuggerDisplay("{ToString()}")]
    internal struct StringSlice : IEquatable<StringSlice>
    {
        public readonly string Original;
        private ushort _startIndex;
        private ushort _endIndex;

        public int StartIndex
        {
            set => _startIndex = (ushort)Math.Max(0, Math.Min(value, _endIndex));
            get => _startIndex;
        }

        public int EndIndex
        {
            set => _endIndex = (ushort)Math.Max(StartIndex, Math.Min(value, Original.Length));
            get => _endIndex;
        }

        public int Length => _endIndex - _startIndex;

        public StringSlice(string original) : this(original, 0, original.Length) {}

        public StringSlice(string original, int startIndex) : this(original, startIndex, original.Length - startIndex) {}

        public StringSlice(string original, int startIndex, int length)
        {
            if (startIndex < 0) throw new ArgumentOutOfRangeException(nameof(startIndex), "The value must be non negative.");
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length), "The value must be non negative.");
            Original = original;
            _startIndex = (ushort)startIndex;
            _endIndex = (ushort)Math.Min(original.Length, startIndex + length);
        }

        public char this[int index] => char.ToLower(Original[_startIndex + index]);

        public bool Equals(StringSlice other)
        {
            return Original.Equals(other.Original, StringComparison.OrdinalIgnoreCase) 
                   && _endIndex == other._endIndex 
                   && _startIndex == other._startIndex;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is StringSlice sli && Equals(sli);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = StringComparer.OrdinalIgnoreCase.GetHashCode(Original);
                hashCode = (hashCode * 397) ^ _endIndex;
                hashCode = (hashCode * 397) ^ _startIndex;
                return hashCode;
            }
        }

        public StringSlice Slice(int startIndex) => Slice(startIndex, Length - startIndex);
        public StringSlice Slice(int startIndex, int count) => new(Original, _startIndex + startIndex, Math.Min(count, Length - startIndex));

        public bool StartsWith(StringSlice other)
        {
            if (Length < other.Length)
            {
                return false;
            }

            for (int i = 0; i < other.Length; i++)
            {
                if (char.ToUpperInvariant(this[i]) != char.ToUpperInvariant(other[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public StringSlice SliceLastChar() => Length == 0 ? this : Slice(0, Length - 1);

        public static bool operator ==(StringSlice left, StringSlice right) => left.Equals(right);
        public static bool operator !=(StringSlice left, StringSlice right) => !(left == right);

        public override string ToString() => Original.Substring(_startIndex, Length);
    }
}