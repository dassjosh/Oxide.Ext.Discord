using System;
using System.Collections.Generic;
using System.Linq;
using uMod.Collections;

namespace uMod.Ext.Discord.Extensions
{
    public static class HashExt
    {
        public static void RemoveAll<TKey, TValue>(this Hash<TKey, TValue> dict, Func<TValue, bool> predicate)
        {
            if (dict == null)
            {
                return;
            }
            
            foreach (KeyValuePair<TKey, TValue> key in dict.Where(k => predicate(k.Value)).ToList())
            {
                dict.Remove(key.Key);
            }
        }
    }
}