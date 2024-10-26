using System;
using System.Net.Http;
using Oxide.Core.Libraries;

namespace Oxide.Ext.Discord.Constants
{
    internal static class DiscordHttpMethods
    {
        private static readonly HttpMethod Patch = new("PATCH");

        public static HttpMethod GetMethod(RequestMethod method)
        {
            return method switch
            {
                RequestMethod.DELETE => HttpMethod.Delete,
                RequestMethod.GET => HttpMethod.Get,
                RequestMethod.PATCH => Patch,
                RequestMethod.POST => HttpMethod.Post,
                RequestMethod.PUT => HttpMethod.Put,
                _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
            };
        }
    }
}