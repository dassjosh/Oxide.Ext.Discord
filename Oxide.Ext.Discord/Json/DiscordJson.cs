using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Json
{
    internal static class DiscordJson
    {
        internal static readonly JsonSerializerSettings Settings = new() 
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.None
        }; 
    
        internal static readonly JsonSerializerSettings IndentedSettings = new()
        {
            Formatting = Formatting.Indented
        };
    }
}