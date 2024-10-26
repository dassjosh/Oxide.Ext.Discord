﻿using System.Reflection;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Plugins
{
    internal readonly struct PluginFieldResult<T> where T : BaseDiscordAttribute
    {
        private readonly MemberInfo _member;
        private readonly T _attribute;
        public bool IsValid => _member != null && _attribute != null;

        public PluginFieldResult(MemberInfo member, T attribute)
        {
            _member = member;
            _attribute = attribute;
        }

        public void SetValue(object instance, object value) => _member.SetMemberValue(instance, value);
    }
}