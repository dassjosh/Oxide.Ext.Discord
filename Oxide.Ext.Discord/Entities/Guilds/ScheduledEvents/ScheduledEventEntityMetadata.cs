using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-object-guild-scheduled-event-entity-metadata">Guild Scheduled Event Entity Metadata</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ScheduledEventEntityMetadata : IDiscordValidation
    {
        /// <summary>
        /// Location of the event (1-100 characters)
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        internal void Update(ScheduledEventEntityMetadata metadata)
        {
            if (metadata.Location != null)
            {
                Location = metadata.Location;
            }
        }

        /// <inheritdoc/>
        public void Validate()
        {
            InvalidGuildScheduledEventException.ThrowIfInvalidLocation(Location);
        }
    }
}