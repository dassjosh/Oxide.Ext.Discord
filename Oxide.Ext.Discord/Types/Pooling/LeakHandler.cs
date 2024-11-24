using System;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Types
{
    internal class LeakHandler
    {
        private readonly PluginId _pluginId;
        private readonly string _type;
        
        private bool _isFirstLeakError = true;
        private DateTime _nextLeakError;

        public LeakHandler(PluginId pluginId, string poolType) 
        {
            _pluginId = pluginId;
            _type = poolType;
        }

        internal void OnLeak(int index, int poolSize)
        {
            if (ShouldLogLeak())
            {
                DiscordExtension.GlobalLogger.Warning("Plugin: {0} Pool: {1} is leaking entities!!! {2}/{3}", _pluginId.PluginName(), _type, index, poolSize);
            }
        }

        private bool ShouldLogLeak()
        {
            if (!_pluginId.IsExtensionPlugin)
            {
                return true;
            }

            if (_isFirstLeakError)
            {
                _isFirstLeakError = false;
                return false;
            }

            if (_nextLeakError >= DateTime.UtcNow)
            {
                return false;
            }
            
            _nextLeakError = DateTime.UtcNow + TimeSpan.FromSeconds(30);
            return true;
        }
    }
}