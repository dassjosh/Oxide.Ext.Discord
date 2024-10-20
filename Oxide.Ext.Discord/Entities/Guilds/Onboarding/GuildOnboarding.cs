﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-onboarding-object-guild-onboarding-structure">Guild Onboarding Structure</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class GuildOnboarding
{
    /// <summary>
    /// ID of the guild this onboarding is part of
    /// </summary>
    [JsonProperty("guild_id")]
    public Snowflake GuildId { get; set; }
        
    /// <summary>
    /// Prompts shown during onboarding and in customize community
    /// </summary>
    [JsonProperty("prompts")]
    public List<OnboardingPrompt> Prompts { get; set; }
        
    /// <summary>
    /// Channel IDs that members get opted into automatically
    /// </summary>
    [JsonProperty("default_channel_ids")]
    public List<Snowflake> DefaultChannelIds { get; set; }
        
    /// <summary>
    /// Whether onboarding is enabled in the guild
    /// </summary>
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }
        
    /// <summary>
    /// Current mode of onboarding
    /// </summary>
    [JsonProperty("mode")]
    public GuildOnboardingMode Mode { get; set; }
}