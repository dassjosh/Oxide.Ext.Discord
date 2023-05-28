﻿using System.Collections.Generic;
using Oxide.Ext.Discord.Entities.Applications;
using Oxide.Ext.Discord.Entities.Applications.RoleConnection;

namespace Oxide.Ext.Discord.Exceptions.Entities.Applications
{
    /// <summary>
    /// Exceptions for <see cref="DiscordApplication"/>
    /// </summary>
    public class DiscordApplicationException : BaseDiscordException
    {
        private DiscordApplicationException(string message) : base(message) { }

        internal static void ThrowIfInvalidApplicationRoleConnectionMetadataLength(List<ApplicationRoleConnectionMetadata> records)
        {
            const int MaxLength = 5;
            
            if (records == null)
            {
                throw new DiscordApplicationException($"{nameof(records)} cannot be null");
            }

            if (records.Count > MaxLength)
            {
                throw new DiscordApplicationException($"{nameof(records)} cannot have more than {MaxLength} records");
            }
        }
    }
}