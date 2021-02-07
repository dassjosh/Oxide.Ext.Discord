namespace uMod.Ext.Discord.Gateway
{
    public enum ReceiveOpCode
    {
        Dispatch = 0,
        Heartbeat = 1,
        Reconnect = 7,
        InvalidSession = 9,
        Hello = 10,
        HeartbeatAcknowledge = 11
    }

    public enum SendOpCode
    {
        Heartbeat = 1,
        Identify = 2,
        StatusUpdate = 3,
        VoiceStateUpdate = 4,
        Resume = 6,
        RequestGuildMembers = 8,
    }
}