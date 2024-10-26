using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Cache
{
    /// <summary>
    /// Represents a cache of enum strings
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    public sealed class EnumCache<T> : Singleton<EnumCache<T>> where T : Enum, IConvertible
    {
        /// <summary>
        /// Readonly Collection of Enum Values
        /// </summary>
        public readonly ReadOnlyCollection<T> Values;

        private readonly T[] _values;
        private readonly Dictionary<T, string> _cachedStrings = new();
        private readonly Dictionary<T, string> _loweredStrings = new();
        private readonly Dictionary<T, string> _numberString = new();
        private readonly Type _type;
        private readonly bool _isFlagsEnum;
        private readonly TypeCode _typeCode;

        /// <summary>
        /// Constructor
        /// </summary>
        private EnumCache()
        {
            _type = typeof(T);
            _isFlagsEnum = _type.HasAttribute<FlagsAttribute>(false);
            _values = Enum.GetValues(_type).Cast<T>().ToArray();
            _typeCode = Convert.GetTypeCode(_values[0]);
            for (int index = 0; index < _values.Length; index++)
            {
                T value = _values[index];
                string enumString = value.ToString();
                _cachedStrings[value] = enumString;
                _loweredStrings[value] = enumString.ToLower();
            }
            Values = new ReadOnlyCollection<T>(_values);
        }
        
        /// <summary>
        /// Returns the string representation of the enum
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Enum value as string</returns>
        public string ToString(T value)
        {
            if (_cachedStrings.TryGetValue(value, out string str))
            {
                return str;
            }

            str = _isFlagsEnum ? CreateFlagsString(value) : value.ToString();
            
            _cachedStrings[value] = str;
            return str;
        }
        
        /// <summary>
        /// Returns the lowered string representation of the enum
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Enum value as lowered string</returns>
        public string ToLower(T value)
        {
            if (!_loweredStrings.TryGetValue(value, out string str))
            {
                str = ToString(value).ToLower();
                _loweredStrings[value] = str;
            }
            return str;
        }

        /// <summary>
        /// Converts the enum to it's number form as a string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToNumber(T value)
        {
            if (!_numberString.TryGetValue(value, out string str))
            {
                str = value.ToType(Enum.GetUnderlyingType(_type), null).ToString();
                _numberString[value] = str;
            }

            return str;
        }

        /// <summary>
        /// Returns the next enum values. If the value is the last value, it will start from the beginning
        /// </summary>
        /// <param name="value">Value to get the next enum from</param>
        /// <returns>Next enum from the given value</returns>
        public T Next(T value)
        {
            int index = Array.IndexOf(_values, value) + 1;
            return _values.Length == index ? _values[0] : _values[index];      
        }
        
        /// <summary>
        /// Returns the previous enum values.
        /// </summary>
        /// <param name="value">Value to get the previous enum from</param>
        /// <returns>Previous enum from the given value</returns>
        public T Previous(T value)
        {
            int index = Array.IndexOf(_values, value) + 1;
            return index == 0 ? _values[_values.Length] : _values[index];      
        }

        private int GetTypeSize()
        {
            return _typeCode switch
            {
                TypeCode.SByte or TypeCode.Byte => 8,
                TypeCode.Int16 or TypeCode.UInt16 => 16,
                TypeCode.Int32 or TypeCode.UInt32 => 32,
                TypeCode.Int64 or TypeCode.UInt64 => 64,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        private string CreateFlagsString(T value)
        {
            ValueStringBuilder sb = new();
            bool initial = true;
            int length = GetTypeSize();
            for (int index = 0; index < length; index++)
            {
                ulong enumValue = 1ul << index;
                if ((value.ToUInt64(null) & enumValue) != 0ul)
                {
                    if (!initial)
                    {
                        sb.Append(", ");
                    }

                    initial = false;

                    object converted = Convert.ChangeType(enumValue, _typeCode);
                    if (Enum.IsDefined(_type, converted))
                    {
                        sb.Append(Enum.GetName(_type, converted));
                    }
                    else
                    {
                        sb.Append("Unknown Value (1 << ");
                        sb.Append(index);
                        sb.Append(')');
                    }
                }
            }

            return sb.ToString();
        }

    }
}