﻿using System.Reflection;
using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Plugins;

internal readonly struct PluginHookResult<T> where T : BaseDiscordAttribute
{
    public readonly string Name;
    public readonly MethodInfo Method;
    public readonly T Attribute;
    public bool IsValid => !string.IsNullOrEmpty(Name) && Attribute != null;

    public PluginHookResult(PluginCallback callback, T attribute)
    {
        Name = callback.Name;
        Method = callback.Method;
        Attribute = attribute;
    }
}