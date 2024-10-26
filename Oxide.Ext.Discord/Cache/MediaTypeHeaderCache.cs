using System.Net.Http.Headers;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Cache
{
    internal sealed class MediaTypeHeaderCache : Singleton<MediaTypeHeaderCache>
    {
        private readonly Hash<string, MediaTypeHeaderValue> _cache = new();
        private const string JsonHeader = "application/json";

        private MediaTypeHeaderCache()
        {
            MediaTypeHeaderValue header = MediaTypeHeaderValue.Parse(JsonHeader);
            header.CharSet = DiscordEncoding.Instance.Encoding.WebName;
            _cache[JsonHeader] = header;
        }

        public MediaTypeHeaderValue Get(string value)
        {
            MediaTypeHeaderValue header = _cache[value];
            if (header == null)
            {
                header = MediaTypeHeaderValue.Parse(value);
                _cache[value] = header;
            }

            return header;
        }
    }
}