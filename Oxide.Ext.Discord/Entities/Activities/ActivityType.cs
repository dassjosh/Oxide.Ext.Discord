using System;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#activity-object-activity-types">Activity Types</a>
    /// </summary>
    public enum ActivityType : byte
    {
        /// Playing {name}
        [Obsolete("This field has been deprecated and will be removed in a future version. Use ActivityType.Playing instead.")]
        Game = 0,      
        
        /// Playing {name}
        Playing = 0,    
        
        /// Streaming {name}
        Streaming = 1,  
        
        /// Listening {name}
        Listening = 2,  
        
        /// Watching {name}
        Watching = 3,   
        
        ///{emoji} {name} EX: ":smiley: I am cool"
        Custom = 4,     
        
        /// Competing in {name}
        Competing = 5   
    }
}