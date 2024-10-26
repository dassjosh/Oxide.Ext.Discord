// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// A non-heap-allocation allocating string builder
    /// </summary>
    public ref struct ValueStringBuilder
    {
        private char[] _arrayToReturnToPool;
        private Span<char> _chars;
        private int _pos;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="initialBuffer">Initial buffer to use for the chars</param>
        public ValueStringBuilder(Span<char> initialBuffer)
        {
            _arrayToReturnToPool = null;
            _chars = initialBuffer;
            _pos = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="initialCapacity">Initial buffer capacity to rent</param>
        public ValueStringBuilder(int initialCapacity)
        {
            _arrayToReturnToPool = System.Buffers.ArrayPool<char>.Shared.Rent(initialCapacity);
            _chars = _arrayToReturnToPool;
            _pos = 0;
        }

        /// <summary>
        /// Length of the builder
        /// </summary>
        public int Length
        {
            get => _pos;
            set
            {
                Debug.Assert(value >= 0);
                Debug.Assert(value <= _chars.Length);
                _pos = value;
            }
        }

        /// <summary>
        /// Current capacity of the builder
        /// </summary>
        public int Capacity => _chars.Length;

        /// <summary>
        /// Ensure the builder has a capacity of at least <paramref name="capacity"/>
        /// </summary>
        /// <param name="capacity"></param>
        public void EnsureCapacity(int capacity)
        {
            // This is not expected to be called this with negative capacity
            Debug.Assert(capacity >= 0);

            // If the caller has a bug and calls this with negative capacity, make sure to call Grow to throw an exception.
            if ((uint)capacity > (uint)_chars.Length)
                Grow(capacity - _pos);
        }

        /// <summary>
        /// Get a pinnable reference to the builder.
        /// Does not ensure there is a null char after <see cref="Length"/>
        /// This overload is pattern matched in the C# 7.3+ compiler so you can omit
        /// the explicit method call, and write eg "fixed (char* c = builder)"
        /// </summary>
        public ref char GetPinnableReference()
        {
            return ref MemoryMarshal.GetReference(_chars);
        }

        /// <summary>
        /// Get a pinnable reference to the builder.
        /// </summary>
        /// <param name="terminate">Ensures that the builder has a null char after <see cref="Length"/></param>
        public ref char GetPinnableReference(bool terminate)
        {
            if (terminate)
            {
                EnsureCapacity(Length + 1);
                _chars[Length] = '\0';
            }
            return ref MemoryMarshal.GetReference(_chars);
        }

        /// <summary>
        /// Get the char at the specified index
        /// </summary>
        /// <param name="index"></param>
        public ref char this[int index]
        {
            get
            {
                Debug.Assert(index < _pos);
                return ref _chars[index];
            }
        }

        /// <summary>
        /// Get's the final string and disposes of the builder
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = _chars.Slice(0, _pos).ToString();
            Dispose();
            return s;
        }

        /// <summary>Returns the underlying storage of the builder.</summary>
        public Span<char> RawChars => _chars;

        /// <summary>
        /// Returns a span around the contents of the builder.
        /// </summary>
        /// <param name="terminate">Ensures that the builder has a null char after <see cref="Length"/></param>
        public ReadOnlySpan<char> AsSpan(bool terminate)
        {
            if (terminate)
            {
                EnsureCapacity(Length + 1);
                _chars[Length] = '\0';
            }
            return _chars.Slice(0, _pos);
        }

        /// <summary>
        /// Converts the current builder to a <see cref="ReadOnlySpan{T}"/>
        /// </summary>
        /// <returns></returns>
        public ReadOnlySpan<char> AsSpan() => _chars.Slice(0, _pos);
        
        /// <summary>
        /// Converts the current builder to a <see cref="ReadOnlySpan{T}"/>
        /// </summary>
        /// <param name="start">Index to start at</param>
        /// <returns></returns>
        public ReadOnlySpan<char> AsSpan(int start) => _chars.Slice(start, _pos - start);
        
        /// <summary>
        /// Converts the current builder to a <see cref="ReadOnlySpan{T}"/>
        /// </summary>
        /// <param name="start">Index to start at</param>
        /// <param name="length">Length of the span</param>
        /// <returns></returns>
        public ReadOnlySpan<char> AsSpan(int start, int length) => _chars.Slice(start, length);

        /// <summary>
        /// Tries to copy the current builder to a <see cref="Span{T}"/>
        /// </summary>
        /// <param name="destination">Span to write the chars to</param>
        /// <param name="charsWritten">Number of chars written</param>
        /// <returns>True if successfully; false otherwise</returns>
        public bool TryCopyTo(Span<char> destination, out int charsWritten)
        {
            if (_chars.Slice(0, _pos).TryCopyTo(destination))
            {
                charsWritten = _pos;
                Dispose();
                return true;
            }
        
            charsWritten = 0;
            Dispose();
            return false;
        }

        /// <summary>
        /// Insert a char at the specified index count times
        /// </summary>
        /// <param name="index">Index to insert the char</param>
        /// <param name="value">Char to insert</param>
        /// <param name="count">Number of times to insert</param>
        public void Insert(int index, char value, int count)
        {
            if (_pos > _chars.Length - count)
            {
                Grow(count);
            }

            int remaining = _pos - index;
            _chars.Slice(index, remaining).CopyTo(_chars.Slice(index + count));
            _chars.Slice(index, count).Fill(value);
            _pos += count;
        }

        /// <summary>
        /// Insert string at the specified index
        /// </summary>
        /// <param name="index">Index to insert the string</param>
        /// <param name="s">String to insert</param>
        public void Insert(int index, string s)
        {
            if (s == null)
            {
                return;
            }

            int count = s.Length;

            if (_pos > (_chars.Length - count))
            {
                Grow(count);
            }

            int remaining = _pos - index;
            _chars.Slice(index, remaining).CopyTo(_chars.Slice(index + count));
            s.AsSpan().CopyTo(_chars.Slice(index));
            _pos += count;
        }

        /// <summary>
        /// Appends char to the builder
        /// </summary>
        /// <param name="c">Char to append</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(char c)
        {
            int pos = _pos;
            Span<char> chars = _chars;
            if ((uint)pos < (uint)chars.Length)
            {
                chars[pos] = c;
                _pos = pos + 1;
            }
            else
            {
                GrowAndAppend(c);
            }
        }

        /// <summary>
        /// Appends string to the builder
        /// </summary>
        /// <param name="s">string to append</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(string s)
        {
            if (s == null)
            {
                return;
            }

            int pos = _pos;
            if (s.Length == 1 && (uint)pos < (uint)_chars.Length) // very common case, e.g. appending strings from NumberFormatInfo like separators, percent symbols, etc.
            {
                _chars[pos] = s[0];
                _pos = pos + 1;
            }
            else
            {
                AppendSlow(s);
            }
        }

        private void AppendSlow(string s)
        {
            int pos = _pos;
            if (pos > _chars.Length - s.Length)
            {
                Grow(s.Length);
            }

            s.AsSpan().CopyTo(_chars.Slice(pos));
            _pos += s.Length;
        }

        public void Append(char c, int count)
        {
            if (_pos > _chars.Length - count)
            {
                Grow(count);
            }

            Span<char> dst = _chars.Slice(_pos, count);
            for (int i = 0; i < dst.Length; i++)
            {
                dst[i] = c;
            }
            _pos += count;
        }

        /// <summary>
        /// Appends span to the builder
        /// </summary>
        /// <param name="value">Span to append</param>
        public void Append(ReadOnlySpan<char> value)
        {
            int pos = _pos;
            if (pos > _chars.Length - value.Length)
            {
                Grow(value.Length);
            }

            value.CopyTo(_chars.Slice(_pos));
            _pos += value.Length;
        }

        /// <summary>
        /// Requests a writable span of length
        /// </summary>
        /// <param name="length">Length of the request span</param>
        /// <returns>Span of the request length</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<char> AppendSpan(int length)
        {
            int origPos = _pos;
            if (origPos > _chars.Length - length)
            {
                Grow(length);
            }

            _pos = origPos + length;
            return _chars.Slice(origPos, length);
        }
    
        /// <summary>
        /// Appends a <see cref="byte"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(byte value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
    
        /// <summary>
        /// Appends a <see cref="sbyte"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(sbyte value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
    
        /// <summary>
        /// Appends a <see cref="sbyte"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(short value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
    
        /// <summary>
        /// Appends a <see cref="sbyte"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ushort value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
    
        /// <summary>
        /// Appends a <see cref="int"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(int value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
    
        /// <summary>
        /// Appends a <see cref="uint"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(uint value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
    
        /// <summary>
        /// Appends a <see cref="long"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(long value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
    
        /// <summary>
        /// Appends a <see cref="ulong"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ulong value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
        
        /// <summary>
        /// Appends a <see cref="decimal"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(decimal value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
        
        /// <summary>
        /// Appends a <see cref="float"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(float value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
        
        /// <summary>
        /// Appends a <see cref="double"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(double value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
        
        /// <summary>
        /// Appends a <see cref="DateTime"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(DateTime value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
        
        /// <summary>
        /// Appends a <see cref="DateTimeOffset"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(DateTimeOffset value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }
        
        /// <summary>
        /// Appends a <see cref="TimeSpan"/> to the builder
        /// </summary>
        /// <param name="value">Value to append</param>
        /// <param name="format">format for the value</param>
        /// <param name="provider">Format provider for the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(TimeSpan value, string format = null, IFormatProvider provider = null)
        {
            if (value.TryFormat(out ReadOnlySpan<char> span, format, provider))
            {
                Append(span);
            }
            else
            {
                Append(value.ToString(format, provider));
            }
        }

        /// <summary>
        /// Appends <paramref name="s"/> followed by a newline
        /// </summary>
        /// <param name="s"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(string s)
        {
            Append(s);
            AppendLine();
        }
    
        /// <summary>
        /// Appends a newline
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine() => Append(Environment.NewLine);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void GrowAndAppend(char c)
        {
            Grow(1);
            Append(c);
        }

        /// <summary>
        /// Resize the internal buffer either by doubling current buffer size or
        /// by adding <paramref name="additionalCapacityBeyondPos"/> to
        /// <see cref="_pos"/> whichever is greater.
        /// </summary>
        /// <param name="additionalCapacityBeyondPos">
        /// Number of chars requested beyond current position.
        /// </param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Grow(int additionalCapacityBeyondPos)
        {
            Debug.Assert(additionalCapacityBeyondPos > 0);
            Debug.Assert(_pos > _chars.Length - additionalCapacityBeyondPos, "Grow called incorrectly, no resize is needed.");

            const uint ArrayMaxLength = 0x7FFFFFC7; // same as Array.MaxLength

            // Increase to at least the required size (_pos + additionalCapacityBeyondPos), but try
            // to double the size if possible, bounding the doubling to not go beyond the max array length.
            int newCapacity = (int)Math.Max(
                (uint)(_pos + additionalCapacityBeyondPos),
                Math.Min((uint)_chars.Length * 2, ArrayMaxLength));

            // Make sure to let Rent throw an exception if the caller has a bug and the desired capacity is negative.
            // This could also go negative if the actual required length wraps around.
            char[] poolArray = System.Buffers.ArrayPool<char>.Shared.Rent(newCapacity);

            _chars.Slice(0, _pos).CopyTo(poolArray);

            char[] toReturn = _arrayToReturnToPool;
            _chars = _arrayToReturnToPool = poolArray;
            if (toReturn != null)
            {
                System.Buffers.ArrayPool<char>.Shared.Return(toReturn);
            }
        }

        // Dispose of the builder. Only needs to be called if ToString() is not used.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            char[] toReturn = _arrayToReturnToPool;
            this = default; // for safety, to avoid using pooled array if this instance is erroneously appended to again
            if (toReturn != null)
            {
                System.Buffers.ArrayPool<char>.Shared.Return(toReturn);
            }
        }
    }
}