using System;
using Oxide.Ext.Discord.Data;

namespace Oxide.Ext.Discord.Exceptions.Data
{
    /// <summary>
    /// Exception for Data Info not being fouind
    /// </summary>
    public class DataInfoNotFoundException : BaseDiscordException
    {
        private DataInfoNotFoundException(string message) : base(message) { }

        internal static void ThrowIfDataInfoNotFound(Type type, DataFileInfo info)
        {
            if (info == null)
            {
                throw new DataInfoNotFoundException($"Failed to find DataInfo for type: {type.FullName}");
            }
        }
    }
}