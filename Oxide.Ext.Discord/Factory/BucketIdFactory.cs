using System;
using Oxide.Core.Libraries;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Rest;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Factory
{
    internal static class BucketIdFactory
    {
        private const string SplitChar = "/";
        private const char QueryStringChar = '?';
        private const string IdReplacement = "id";
        private const string ReactionsRoute =  "reactions";

        /// <summary>
        /// Returns the Rate Limit Bucket for the given route
        /// https://discord.com/developers/docs/topics/rate-limits#rate-limits
        /// </summary>
        /// <param name="method">Request method for the request</param>
        /// <param name="route">API Route</param>
        /// <returns>Bucket ID for route</returns>
        internal static BucketId GenerateId(RequestMethod method, string route)
        {
            int routeLength = route.LastIndexOf(QueryStringChar);
            if (routeLength == -1)
            {
                routeLength = route.Length;
            }
            
            StringTokenizer tokenizer = new(route, SplitChar, routeLength);
            tokenizer.MoveNext();
            ReadOnlySpan<char> previous = tokenizer.Current;
            
            ValueStringBuilder bucket = new();
            bucket.Append(EnumCache<RequestMethod>.Instance.ToString(method));
            bucket.Append(':');
            bucket.Append(previous);

            ReadOnlySpan<char> reactions = ReactionsRoute.AsSpan();
            
            while (tokenizer.MoveNext())
            {
                bucket.Append('/');

                ReadOnlySpan<char> current = GetCurrent(tokenizer.Index, previous, tokenizer.Current);

                bucket.Append(current);
                if (current.Equals(reactions, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                
                previous = current;
            }

            return new BucketId(bucket.ToString());
        }
        
        private static ReadOnlySpan<char> GetCurrent(int index, ReadOnlySpan<char> previous, ReadOnlySpan<char> token)
        {
            //If previous is not a major ID we don't want to include the ID in the bucket ID so use "id" string instead
            return char.IsNumber(token[0]) && !IsMajorId(index, previous) ? IdReplacement.AsSpan() : token;
        }

        private static bool IsMajorId(int index, ReadOnlySpan<char> previous)
        {
            //We should only use Major ID if the previous segment name is the first segment and the ID is the second.
            return index == 1 && 
                   (previous.Equals("guilds".AsSpan(), StringComparison.OrdinalIgnoreCase) 
                    || previous.Equals("channels".AsSpan(), StringComparison.OrdinalIgnoreCase) 
                    || previous.Equals("webhooks".AsSpan(), StringComparison.OrdinalIgnoreCase)
                   );
        }
    }
}