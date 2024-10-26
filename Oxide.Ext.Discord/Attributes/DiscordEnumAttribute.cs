using System;

namespace Oxide.Ext.Discord.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class DiscordEnumAttribute : Attribute
    {
        public readonly string Name;

        public DiscordEnumAttribute(string name)
        {
            Name = name;
        }
    }
}