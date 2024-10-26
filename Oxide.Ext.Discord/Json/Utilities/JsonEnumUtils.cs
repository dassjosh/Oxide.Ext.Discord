using System;
using System.Collections.Concurrent;
using System.Reflection;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Extensions;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Json
{
    internal static class JsonEnumUtils
    {
        private static readonly ConcurrentDictionary<Type, EnumData> EnumData = new();

        internal static object GetDefault(Type enumType) => GetEnumData(enumType).Default;

        internal static string ToEnumName(Type enumType, string enumText)
        {
            EnumData data = GetEnumData(enumType);
            if (enumText.IndexOf(",", StringComparison.Ordinal) == -1)
            {
                return data.NameToProperty[enumText];
            }
            
            return ParseEnumNameList(enumText, data.NameToProperty);
        }
        
        internal static string FromEnumName(Type enumType, string enumText)
        {
            EnumData data = GetEnumData(enumType);
            if (enumText.IndexOf(",", StringComparison.Ordinal) == -1)
            {
                return data.PropertyToName[enumText];
            }
            
            return ParseEnumNameList(enumText, data.PropertyToName);
        }

        private static string ParseEnumNameList(string enumText, Hash<string, string> lookup)
        {
            string[] enums = enumText.Split(',');
            for (int index = 0; index < enums.Length; index++)
            {
                enums[index] = lookup[enums[index].Trim()];
            }

            return string.Join(", ", enums);
        }

        private static EnumData GetEnumData(Type type)
        {
            if (!EnumData.TryGetValue(type, out EnumData data))
            {
                data = new EnumData(type);
                EnumData[type] = data;
            }

            return data;
        }
    }

    internal class EnumData
    {
        public readonly object Default;
        public readonly Hash<string, string> NameToProperty = new();
        public readonly Hash<string, string> PropertyToName = new();

        public EnumData(Type type)
        {
            Default = type.GetDefault();
            foreach (FieldInfo field in type.GetFields())
            {
                string name = field.Name;
                string propertyName = field.GetCustomAttribute<DiscordEnumAttribute>()?.Name ?? field.Name;
                Add(name, propertyName);
            }
        }

        private void Add(string name, string propertyName)
        {
            NameToProperty[name] = propertyName;
            PropertyToName[propertyName] = name;
        }
    }
}