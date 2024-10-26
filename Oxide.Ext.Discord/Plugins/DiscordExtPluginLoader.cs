using System;
using Oxide.Core.Plugins;

namespace Oxide.Ext.Discord.Plugins
{
    internal class DiscordExtPluginLoader : PluginLoader
    {
        public override Type[] CorePlugins => new[] {typeof(DiscordExtensionCore)};
    }
}