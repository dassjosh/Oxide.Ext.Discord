using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// Extension for <see cref="ConcurrentDictionary{TKey,TValue}"/>
    /// </summary>
    internal static class ConcurrentDictionaryExt
    {
        /// <summary>
        /// Remove all records from the dictionary with the given predicate filter
        /// </summary>
        /// <param name="dic">dictionary to have data removed from</param>
        /// <param name="predicate">Filter of which values to remove</param>
        /// <typeparam name="TKey">Key type of the dictionary</typeparam>
        /// <typeparam name="TValue">Value type of the dictionary</typeparam>
        internal static void RemoveAll<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dic, Func<TKey, bool> predicate)
        {
            if (dic == null) throw new ArgumentNullException(nameof(dic));

            List<TKey> removeKeys = DiscordPool.Internal.GetList<TKey>();
            foreach (KeyValuePair<TKey, TValue> key in dic)
            {
                if (predicate(key.Key))
                {
                    removeKeys.Add(key.Key);
                }
            }

            for (int index = 0; index < removeKeys.Count; index++)
            {
                TKey key = removeKeys[index];
                dic.TryRemove(key, out TValue _);
            }

            DiscordPool.Internal.FreeList(removeKeys);
        }
        
        /// <summary>
        /// Remove all records from the dictionary with the given predicate filter
        /// </summary>
        /// <param name="dic">Dictionary to have data removed from</param>
        /// <param name="predicate">Filter of which values to remove</param>
        /// <param name="onRemove">Action to call when an element is removed</param>
        /// <typeparam name="TKey">Key type of the dictionary</typeparam>
        /// <typeparam name="TValue">Value type of the dictionary</typeparam>
        internal static void RemoveAll<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dic, Func<TValue, bool> predicate, Action<TValue> onRemove = null)
        {
            if (dic == null) throw new ArgumentNullException(nameof(dic));

            List<TKey> removeKeys = DiscordPool.Internal.GetList<TKey>();
            foreach (KeyValuePair<TKey, TValue> key in dic)
            {
                if (predicate(key.Value))
                {
                    removeKeys.Add(key.Key);
                    onRemove?.Invoke(key.Value);
                }
            }

            for (int index = 0; index < removeKeys.Count; index++)
            {
                TKey key = removeKeys[index];
                dic.TryRemove(key, out TValue _);
            }

            DiscordPool.Internal.FreeList(removeKeys);
        }
    }
}