using System;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Callbacks;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Types
{
    internal class DiscordHook
    {
        private readonly DiscordHookCache _cache;
        private readonly ILogger _logger;

        internal DiscordHook(ILogger logger) 
        {
            _logger = logger;
            _cache = new DiscordHookCache(logger);
        }

        #region Plugin Handling
        internal void AddPlugin(DiscordClient client)
        {
            _cache.AddPlugin(client, client.PluginSetup.PluginHooks);
        }

        internal void RemovePlugin(Plugin plugin)
        {
            _cache.RemovePlugin(plugin);
        }
        #endregion

        #region Hooks
        internal void CallHook(string hookName) => CallHookInternal(_cache, hookName);
        internal void CallHook<T0>(string hookName, T0 arg0) => CallHookInternal(_cache, hookName, arg0);
        internal void CallHook<T0, T1>(string hookName, T0 arg0, T1 arg1) => CallHookInternal(_cache, hookName, arg0, arg1);
        internal void CallHook<T0, T1, T2>(string hookName, T0 arg0, T1 arg1, T2 arg2) => CallHookInternal(_cache, hookName, arg0, arg1, arg2);
        internal void CallHook<T0, T1, T2, T3>(string hookName, T0 arg0, T1 arg1, T2 arg2, T3 arg3) => CallHookInternal(_cache, hookName, arg0, arg1, arg2, arg3);
        internal void CallHook<T0, T1, T2, T3, T4>(string hookName, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => CallHookInternal(_cache, hookName, arg0, arg1, arg2, arg3, arg4);
        #endregion

        #region Global Hooks
        internal static void CallGlobalHook(string hookName) => Interface.Oxide.CallHook(hookName);
        internal static void CallGlobalHook<T0>(string hookName, T0 arg0) => Interface.Oxide.CallHook(hookName, arg0);
        internal static void CallGlobalHook<T0, T1>(string hookName, T0 arg0, T1 arg1) => Interface.Oxide.CallHook(hookName, arg0, arg1);
        internal static void CallGlobalHook<T0, T1, T2>(string hookName, T0 arg0, T1 arg1, T2 arg2) => Interface.Oxide.CallHook(hookName, arg0, arg1, arg2);
        internal static void CallGlobalHook<T0, T1, T2, T3>(string hookName, T0 arg0, T1 arg1, T2 arg2, T3 arg3) => Interface.Oxide.CallHook(hookName, arg0, arg1, arg2, arg3);
        #endregion

        #region Plugin Hooks
        internal static void CallPluginHook(Plugin plugin, string name) => CallHookInternal(plugin, name);
        internal static void CallPluginHook<T0>(Plugin plugin, string name, T0 arg0) => CallHookInternal(plugin, name, arg0);
        internal static void CallPluginHook<T0, T1>(Plugin plugin, string name, T0 arg0, T1 arg1) => CallHookInternal(plugin, name, arg0, arg1);
        internal static void CallPluginHook<T0, T1, T2>(Plugin plugin, string name, T0 arg0, T1 arg1, T2 arg2) => CallHookInternal(plugin, name, arg0, arg1, arg2);
        internal static void CallPluginHook<T0, T1, T2, T3>(Plugin plugin, string name, T0 arg0, T1 arg1, T2 arg2, T3 arg3) => CallHookInternal(plugin, name, arg0, arg1, arg2, arg3);
        #endregion

        #region Internal Handling
        private static bool CanCallHook(DiscordHookCache cache, string hookName, out List<Plugin> plugins) => cache.TryGetHook(hookName, out plugins) && plugins.Count != 0;
        private static void CallHookInternal(Plugin plugin, string hookName, object[] args)
        {
            if (ThreadEx.IsMain)
            {
                CallHook(plugin, hookName, args);
                return;
            }
            
            PluginHookCallback.Start(plugin, hookName, args);
        }

        private static void CallHookInternal(List<Plugin> plugins, string hookName, object[] args)
        {
            if (ThreadEx.IsMain)
            {
                CallHook(plugins, hookName, args);
                return;
            }
            
            PluginHookCallback.Start(plugins, hookName, args);
        }

        private static void CallHookInternal(Plugin plugin, string name) => CallHookInternal(plugin, name, GetArgs());
        private static void CallHookInternal<T0>(Plugin plugin, string name, T0 arg0) => CallHookInternal(plugin, name, GetArgs(arg0));
        private static void CallHookInternal<T0, T1>(Plugin plugin, string name, T0 arg0, T1 arg1) => CallHookInternal(plugin, name, GetArgs(arg0, arg1));
        private static void CallHookInternal<T0, T1, T2>(Plugin plugin, string name, T0 arg0, T1 arg1, T2 arg2) => CallHookInternal(plugin, name, GetArgs(arg0, arg1, arg2));
        private static void CallHookInternal<T0, T1, T2, T3>(Plugin plugin, string name, T0 arg0, T1 arg1, T2 arg2, T3 arg3) => CallHookInternal(plugin, name, GetArgs(arg0, arg1, arg2, arg3));

        private static void CallHookInternal(DiscordHookCache cache, string name)
        {
            if (CanCallHook(cache, name, out List<Plugin> plugins))
            {
                CallHookInternal(plugins, name, GetArgs());
            }
        }

        private static void CallHookInternal<T0>(DiscordHookCache cache, string name, T0 arg0)
        {
            if (CanCallHook(cache, name, out List<Plugin> plugins))
            {
                CallHookInternal(plugins, name, GetArgs(arg0));
            }
        }

        private static void CallHookInternal<T0, T1>(DiscordHookCache cache, string name, T0 arg0, T1 arg1)
        {
            if (CanCallHook(cache, name, out List<Plugin> plugins))
            {
                CallHookInternal(plugins, name, GetArgs(arg0, arg1));
            }
        }

        private static void CallHookInternal<T0, T1, T2>(DiscordHookCache cache, string name, T0 arg0, T1 arg1, T2 arg2)
        {
            if (CanCallHook(cache, name, out List<Plugin> plugins))
            {
                CallHookInternal(plugins, name, GetArgs(arg0, arg1, arg2));
            }
        }

        private static void CallHookInternal<T0, T1, T2, T3>(DiscordHookCache cache, string name, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            if (CanCallHook(cache, name, out List<Plugin> plugins))
            {
                CallHookInternal(plugins, name, GetArgs(arg0, arg1, arg2, arg3));
            }
        }
        
        private static void CallHookInternal<T0, T1, T2, T3, T4>(DiscordHookCache cache, string name, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (CanCallHook(cache, name, out List<Plugin> plugins))
            {
                CallHookInternal(plugins, name, GetArgs(arg0, arg1, arg2, arg3, arg4));
            }
        }
        
        private static object[] GetArgs()
        {
            return Array.Empty<object>();
        }
        
        private static object[] GetArgs<T0>( T0 arg0)
        {
            object[] args = ArrayPool<object>.Instance.Get(1);
            args[0] = arg0;
            return args;
        }

        private static object[] GetArgs<T0, T1>(T0 arg0, T1 arg1)
        {
            object[] args = ArrayPool<object>.Instance.Get(2);
            args[0] = arg0;
            args[1] = arg1;
            return args;
        }

        private static object[] GetArgs<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2)
        {
            object[] args = ArrayPool<object>.Instance.Get(3);
            args[0] = arg0;
            args[1] = arg1;
            args[2] = arg2;
            return args;
        }

        private static object[] GetArgs<T0, T1, T2, T3>( T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            object[] args = ArrayPool<object>.Instance.Get(4);
            args[0] = arg0;
            args[1] = arg1;
            args[2] = arg2;
            args[3] = arg3;
            return args;
        }
        
        private static object[] GetArgs<T0, T1, T2, T3, T4>( T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            object[] args = ArrayPool<object>.Instance.Get(5);
            args[0] = arg0;
            args[1] = arg1;
            args[2] = arg2;
            args[3] = arg3;
            args[4] = arg4;
            return args;
        }
        #endregion

        #region HandleCall
        internal static void CallHook(Plugin plugin, string name, object[] args)
        {
            plugin?.CallHook(name, args);

            if (args.Length != 0)
            {
                ArrayPool<object>.Instance.Free(ref args);
            }
        }
        
        internal static void CallHook(List<Plugin> plugins, string name, object[] args)
        {
            for (int index = 0; index < plugins.Count; index++)
            {
                Plugin plugin = plugins[index];
                if (plugin.IsLoaded)
                {
                    plugin.CallHook(name, args);
                }
            }
            
            if (args.Length != 0)
            {
                ArrayPool<object>.Instance.Free(ref args);
            }
        }
        #endregion
    }
}