using Oxide.Core.Plugins;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Plugins
{
    internal partial class DiscordExtensionCore
    {
        [PluginReference]
#pragma warning disable CS0649
        public Plugin ImageLibrary;
#pragma warning restore CS0649
        
        public string GetPlayerAvatarUrl(string playerId) => IsPluginLoaded(ImageLibrary) ? ImageLibrary.Call<string>("GetImageURL", playerId, 0ul) : string.Empty;

        public string GetImageUrl(string imageName, ulong imageId) => IsPluginLoaded(ImageLibrary) ? ImageLibrary.Call<string>("GetImageURL", imageName, imageId) : string.Empty;
    }
}