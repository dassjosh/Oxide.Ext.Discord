using System.Collections.Generic;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Cache
{
    /// <summary>
    /// Caches strings from {T} ToString method
    /// </summary>
    /// <typeparam name="T">Type for the cache</typeparam>
    public sealed class StringCache<T> : Singleton<StringCache<T>>
    {
        private readonly Dictionary<T, string> _cachedStrings = new();
        private readonly Dictionary<T, string> _loweredStrings = new();

        private StringCache() { }

        /// <summary>
        /// Returns a cached ToString call of the type {T}
        /// </summary>
        /// <param name="value">value to ToString</param>
        /// <returns></returns>
        public string ToString(T value)
        {
            if (!_cachedStrings.TryGetValue(value, out string str))
            {
                str = value.ToString();
                _cachedStrings[value] = str;
            }
            
            return str;
        }
        
        /// <summary>
        /// Returns the lowered string representation of the type {T}
        /// </summary>
        /// <param name="value">value to lower</param>
        /// <returns></returns>
        public string ToLower(T value)
        {
            if (!_loweredStrings.TryGetValue(value, out string str))
            {
                str = value.ToString().ToLower();
                _loweredStrings[value] = str;
            }
            return str;
        }
    }
}