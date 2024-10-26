using System;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Base Template used in Discord Templates
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal sealed class DiscordTemplate<TTemplate> where TTemplate : class
    {
        /// <summary>
        /// Template Data for the template
        /// </summary>
        [JsonProperty("Template", Order = 1)]
        public TTemplate Template { get; private set;}
        
        /// <summary>
        /// The version of the Template
        /// Used when Registering templates to determine if we need to backup a template and create a new template for the given version
        /// </summary>
        [JsonProperty("Template Version", Order = 1000)]
        public TemplateVersion Version { get; set; } = new(1, 0, 0);
        
        // ReSharper disable once UnusedMember.Local
        [JsonConstructor]
        private DiscordTemplate() { }
        
        public DiscordTemplate(TTemplate template, TemplateVersion version)
        {
            Template = template ?? throw new ArgumentNullException(nameof(template));
            Version = version;
        }
    }
}