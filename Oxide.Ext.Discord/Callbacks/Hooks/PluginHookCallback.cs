using System.Collections.Generic;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Callbacks
{
    internal class PluginHookCallback : BaseNextTickCallback
    {
        private string _name;
        private object[] _args;
        private Plugin _plugin;
        private List<Plugin> _plugins;

        public static void Start(Plugin plugin, string name, object[] args)
        {
            PluginHookCallback callback = DiscordPool.Internal.Get<PluginHookCallback>();
            callback.Init(plugin, name, args);
            callback.Run();
        }
        
        public static void Start(List<Plugin> plugins, string name, object[] args)
        {
            PluginHookCallback callback = DiscordPool.Internal.Get<PluginHookCallback>();
            callback.Init(plugins, name, args);
            callback.Run();
        }
        
        private void Init(Plugin plugin, string hook, object[] args)
        {
            Init(hook, args);
            _plugin = plugin;
        }
        
        private void Init(List<Plugin> plugins, string hook, object[] args)
        {
            Init(hook, args);
            _plugins = plugins;
        }
        
        private void Init(string hook, object[] args)
        {
            _name = hook;
            _args = args;
        }

        protected override void HandleCallback()
        {
            if (_plugin != null)
            {
                DiscordHook.CallHook(_plugin, _name, _args);
                return;
            }
            
            DiscordHook.CallHook(_plugins, _name, _args);
        }

        protected override void EnterPool()
        {
            _name = null;
            _args = null;
            _plugin = null;
            _plugins = null;
        }
    }
}