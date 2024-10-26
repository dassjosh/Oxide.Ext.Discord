using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Callbacks
{
    internal class SubscriptionCallback : BaseNextTickCallback
    {
        private DiscordMessage _message;
        private Action<DiscordMessage> _callback;
        private Plugin _plugin;

        public static void Start(Plugin plugin, DiscordMessage message, Action<DiscordMessage> callback)
        {
            SubscriptionCallback sub = DiscordPool.Internal.Get<SubscriptionCallback>();
            sub.Init(plugin, message, callback);
            sub.Run();
        }
        
        private void Init(Plugin plugin, DiscordMessage message, Action<DiscordMessage> callback)
        {
            _message = message;
            _callback = callback;
            _plugin = plugin;
        }

        protected override void HandleCallback()
        {
            if (_plugin is not {IsLoaded: true})
            {
                return;
            }
            
            try
            {
                _plugin.TrackStart();
                _callback.Invoke(_message);
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception("An exception occured for discord subscription in channel {0} for plugin {1}", _message.ChannelId, _plugin.FullName(), ex);
            }
            finally
            {
                _plugin.TrackEnd();
            }
        }

        protected override void EnterPool()
        {
            _plugin = null;
            _message = null;
            _callback = null;
        }
    }
}