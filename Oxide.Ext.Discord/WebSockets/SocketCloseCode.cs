namespace uMod.Ext.Discord.WebSockets
{
    public enum SocketCloseCode
    {
        UnknownError = 4000, //We're not sure what went wrong. Try reconnecting?
        UnknownOpcode = 4001, //You sent an invalid Gateway opcode or an invalid payload for an opcode. Don't do that!
        DecodeError = 4002, //You sent an invalid payload to us. Don't do that!
        NotAuthenticated = 4003, //You sent us a payload prior to identifying.
        AuthenticationFailed = 4004, //The account token sent with your identify payload is incorrect.
        AlreadyAuthenticated = 4005, //You sent more than one identify payload. Don't do that!
        InvalidSequence = 4007, //The sequence sent when resuming the session was invalid. Reconnect and start a new session.
        RateLimited = 4008, //Woah nelly! You're sending payloads to us too quickly. Slow it down! You will be disconnected on receiving this.
        SessionTimedOut = 4009, //Your session timed out. Reconnect and start a new one.
        InvalidShard = 4010, //You sent us an invalid shard when identifying.
        ShardingRequired = 4011, //The session would have handled too many guilds - you are required to shard your connection in order to connect.
        InvalidApiVersion = 4012, //You sent an invalid version for the gateway.
        InvalidIntents = 4013, //You sent an invalid intent for a Gateway Intent. You may have incorrectly calculated the bitwise value.
        DisallowedIntent = 4014 //You sent a disallowed intent for a Gateway Intent. You may have tried to specify an intent that you have not enabled or are not whitelisted for.
    }
}