using System;
using System.Reflection;

namespace Oxide.Ext.Discord.Extensions
{
    internal static class MemberInfoExt
    {
        internal static void SetMemberValue(this MemberInfo info, object instance, object value)
        {
            switch (info.MemberType)
            {
                case MemberTypes.Field:
                    ((FieldInfo)info).SetValue(instance, value);
                    break;
                case MemberTypes.Property:
                    PropertyInfo property = ((PropertyInfo)info);
                    if (property.CanWrite)
                    {
                        ((PropertyInfo)info).SetValue(instance, value);
                        break;
                    }
                    throw new Exception($"{property.DeclaringType?.Name}.{property.Name} does not support writing");
                default:
                    throw new Exception("Invalid Member Type. This method only supports MemberTypes.Field or MemberTypes.Property");
            }
        }
    }
}