using System;
using System.Collections.Generic;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// Represents Extension to IEnumerable
    /// </summary>
// ReSharper disable once InconsistentNaming
    public static class IEnumerableExt
    {
        /// <summary>
        /// Converts an IEnumerable{TSource} to a pooled List
        /// </summary>
        /// <param name="source">IEnumerable to convert</param>
        /// <param name="pluginPool">The <see cref="DiscordPluginPool"/> to pool from</param>
        /// <typeparam name="TSource">Type of the list</typeparam>
        /// <returns>Pooled List{TSource}</returns>
        /// <exception cref="ArgumentNullException">Thrown if the source is null</exception>
        public static List<TSource> ToPooledList<TSource>(this IEnumerable<TSource> source, DiscordPluginPool pluginPool)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            List<TSource> list = pluginPool.GetList<TSource>();
            list.AddRange(source);
            return list;
        }

        /// <summary>
        /// Converts an IEnumerable{TSource} to a Hash{TKey, TElement}
        /// </summary>
        /// <param name="source">IEnumerable to convert</param>
        /// <param name="keySelector">Selector for the key</param>
        /// <param name="elementSelector">Selector for the value</param>
        /// <typeparam name="TSource">Type of the source</typeparam>
        /// <typeparam name="TKey">Key type for the hash</typeparam>
        /// <typeparam name="TElement">Value type for the hash</typeparam>
        /// <returns>Pooled Hash{TKey, TElement}</returns>
        /// <exception cref="ArgumentNullException">Thrown if the source is null</exception>
        public static Hash<TKey, TElement> ToHash<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
            
            Hash<TKey, TElement> hash = new();
            foreach (TSource element in source)
            {
                hash.Add(keySelector(element), elementSelector(element));
            }
            
            return hash;
        }

        /// <summary>
        /// Converts an IEnumerable{TSource} to a pooled Hash{TKey, TElement}
        /// </summary>
        /// <param name="source">IEnumerable to convert</param>
        /// <param name="pluginPool">The <see cref="DiscordPluginPool"/> to pool from</param>
        /// <param name="keySelector">Selector for the key</param>
        /// <param name="elementSelector">Selector for the value</param>
        /// <typeparam name="TSource">Type of the source</typeparam>
        /// <typeparam name="TKey">Key type for the hash</typeparam>
        /// <typeparam name="TElement">Value type for the hash</typeparam>
        /// <returns>Pooled Hash{TKey, TElement}</returns>
        /// <exception cref="ArgumentNullException">Thrown if the source is null</exception>
        public static Hash<TKey, TElement> ToPooledHash<TSource, TKey, TElement>(this IEnumerable<TSource> source, DiscordPluginPool pluginPool, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));

            Hash<TKey, TElement> hash = pluginPool.GetHash<TKey, TElement>();
            foreach (TSource element in source)
            {
                hash.Add(keySelector(element), elementSelector(element));
            }
            
            return hash;
        }
    }
}