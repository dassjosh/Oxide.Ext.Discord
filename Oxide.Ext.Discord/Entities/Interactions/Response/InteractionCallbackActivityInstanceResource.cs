using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-interaction-callback-activity-instance-resource">Interaction Callback Activity Instance Resource</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class InteractionCallbackActivityInstanceResource
{
    /// <summary>
    /// Instance ID of the Activity if one was launched or joined.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
}