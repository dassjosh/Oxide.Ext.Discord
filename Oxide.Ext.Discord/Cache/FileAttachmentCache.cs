﻿using System.Collections.Generic;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Cache
{
    /// <summary>
    /// Caches file names when sending attachments
    /// </summary>
    internal sealed class FileAttachmentCache : Singleton<FileAttachmentCache>
    {
        private readonly List<string> _cache = new();

        private FileAttachmentCache() { }

        internal string GetName(int index)
        {
            if (index >= _cache.Count)
            {
                for (int i = _cache.Count; i <= index; i++)
                {
                    _cache.Add($"files[{(index + 1).ToString()}]");
                }
            }

            return _cache[index];
        }
    }
}