using System;

namespace uMod.Ext.Discord.Helpers
{
    public static class Time
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        public static double TimeSinceEpoch() => (DateTime.UtcNow - Epoch).TotalSeconds;
        public static double TimeSinceEpoch(DateTime time) => (time - Epoch).TotalSeconds;
    }
}
