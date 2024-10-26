using System;
using System.Collections.Generic;
using System.Reflection;
using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Plugins
{
    internal readonly struct PluginCallback
    {
        public readonly string Name;
        public readonly MethodInfo Method;
        public readonly List<Attribute> Attributes;

        public PluginCallback(string name, MethodInfo method, Attribute[] attributes)
        {
            Name = name;
            Method = method;
            Attributes = new List<Attribute>(0);
            for (int index = 0; index < attributes.Length; index++)
            {
                Attribute attribute = attributes[index];
                if (attribute is BaseDiscordAttribute)
                {
                    Attributes.Add(attribute);
                }
            }
        }

        public IEnumerable<T> GetAttributes<T>() where T : Attribute
        {
            for (int index = 0; index < Attributes.Count; index++)
            {
                Attribute attribute = Attributes[index];
                if (attribute is T tAttribute)
                {
                    yield return tAttribute;
                }
            }
        }
    }
}