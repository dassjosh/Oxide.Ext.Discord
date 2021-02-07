using System;

namespace uMod.Ext.Discord.Extensions
{
    public static class EnumExt
    {
        public static bool TryParse<TEnum>(this string value, out TEnum result)
            where TEnum : struct, IConvertible
        {
            bool retValue = value != null && Enum.IsDefined(typeof(TEnum), value);
            result = retValue ? (TEnum)Enum.Parse(typeof(TEnum), value) : default(TEnum);
            return retValue;
        }
    }
}