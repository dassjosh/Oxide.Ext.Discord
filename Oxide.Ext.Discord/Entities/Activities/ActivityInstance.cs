using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/application#get-application-activity-instance-activity-instance-object">Activity Instance</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ActivityInstance
    {
        /// <summary>
        /// Application ID
        /// </summary>
        [JsonProperty("application_id")]
        public Snowflake ApplicationId { get; set; }
    
        /// <summary>
        /// Activity Instance ID
        /// </summary>
        [JsonProperty("instance_id")]
        public string InstanceId { get; set; }
    
        /// <summary>
        /// Unique identifier for the launch
        /// </summary>
        [JsonProperty("launch_id")]
        public Snowflake LaunchId { get; set; }
    
        /// <summary>
        /// The Location the instance is running in
        /// </summary>
        [JsonProperty("location")]
        public ActivityLocation Location { get; set; }
    
        /// <summary>
        /// The IDs of the Users currently connected to the instance
        /// </summary>
        [JsonProperty("users")]
        public List<Snowflake> Users { get; set; }
    }
}