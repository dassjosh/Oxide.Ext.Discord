using System;
using Oxide.Core;
using Oxide.Core.Libraries;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Cache;

namespace Oxide.Ext.Discord.Plugins
{
    internal class BaseDiscordPlugin : CSPlugin
    {
        protected readonly Covalence Covalence = OxideLibrary.Instance.Covalence;
        protected readonly Lang Lang = OxideLibrary.Instance.Lang;
        protected readonly Oxide.Core.Libraries.Plugins Plugins = OxideLibrary.Instance.Plugins;
        protected readonly Permission Permission = OxideLibrary.Instance.Permission;
        //internal readonly PluginTimers Timer;

        protected BaseDiscordPlugin()
        {
            Author = DiscordExtension.Authors;
            Version = DiscordExtension.ExtensionVersion;
            //Timer = new PluginTimers(this);
        }
        
        #region Helper Methods
        protected void Chat(IPlayer player, string key) => player.Reply(GetLang(LangKeys.Chat, player, player.IsServer ? Formatter.ToPlaintext(GetLang(key, player)) : GetLang(key, player)));
        protected void Chat(IPlayer player, string key, params object[] args) => player.Reply(GetLang(LangKeys.Chat, player, player.IsServer ? Formatter.ToPlaintext(GetLang(key, player, args)) : GetLang(key, player, args)));
        
        protected string GetLang(string key, IPlayer player = null) => Lang.GetMessage(key, this, player?.Id);

        protected string GetLang(string key, IPlayer player = null, params object[] args)
        {
            try
            {
                return string.Format(GetLang(key, player), args);
            }
            catch(Exception ex)
            {
                PrintError($"Lang Key '{key}' threw exception\n:{ex.Message}");
                throw;
            }
        }
        
        protected void Puts(string format, params object[] args) => Interface.Oxide.LogInfo("[{0}] {1}", Title, args.Length != 0 ? string.Format(format, args) : (object) format);

        protected void PrintWarning(string format, params object[] args) => Interface.Oxide.LogWarning("[{0}] {1}", Title, args.Length != 0 ? string.Format(format, args) : (object) format);

        protected void PrintError(string format, params object[] args) => Interface.Oxide.LogError("[{0}] {1}", Title, args.Length != 0 ? string.Format(format, args) : (object) format);
        #endregion
    }
}