using System;

namespace Oxide.Ext.Discord.Extensions
{
    internal static class CastExt
    {
        internal static TDestination Cast<TSource, TDestination>(this TSource source)
        {
            CastImpl<TSource, TDestination>.Value = source;
            return CastImpl<TDestination, TSource>.Value;
        }
        
        private static class CastImpl<TSource, TDestination>
        {
            [ThreadStatic]
            public static TSource Value;

            static CastImpl()
            {
                if (typeof(TSource) != typeof(TDestination)) throw new InvalidCastException($"{typeof(TSource)} != {typeof(TDestination)}");
            }
        }
    }
}