using Newtonsoft.Json;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/user#connection-object-connection-structure">Connection Type</a> for a connection
    /// </summary>
    [JsonConverter(typeof(DiscordEnumConverter))]
    public enum ConnectionType : byte
    {
        /// <summary>
        /// Discord Extension doesn't currently support this connection type
        /// </summary>
        Unknown,
        
        /// <summary>
        /// Connection type is Battle.net
        /// </summary>
        [DiscordEnum("battlenet")] BattleNet,
        
        /// <summary>
        /// Connection type is Bungie.net
        /// </summary>
        [DiscordEnum("bungie")] Bungie,
        
        /// <summary>
        /// Connection type is Domain              
        /// </summary>
        [DiscordEnum("domain")] Domain,
        
        /// <summary>
        /// Connection type is Epic Games
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [DiscordEnum("ebay")] eBay,
        
        /// <summary>
        /// Connection type is Epic Games
        /// </summary>
        [DiscordEnum("epicgames")] EpicGames,
        
        /// <summary>
        /// Connection type is Facebook
        /// </summary>
        [DiscordEnum("facebook")] Facebook,
        
        /// <summary>
        /// Connection type is GitHub
        /// </summary>
        [DiscordEnum("github")] GitHub,
        
        /// <summary>
        /// Connection type is Instagram
        /// </summary>
        [DiscordEnum("instagram")] Instagram,
        
        /// <summary>
        /// Connection type is League of Legends
        /// </summary>
        [DiscordEnum("paypal")] PayPal,
        
        /// <summary>
        /// Connection type is League of Legends
        /// </summary>
        [DiscordEnum("leagueoflegends")] LeagueOfLegends,
        
        /// <summary>
        /// Connection type is PlayStation Network
        /// </summary>
        [DiscordEnum("playstation")] PlayStationNetwork,
        
        /// <summary>
        /// Connection type is Reddit
        /// </summary>
        [DiscordEnum("reddit")] Reddit,
        
        /// <summary>
        /// Connection type is Riot Games
        /// </summary>
        [DiscordEnum("riotgames")] RiotGames,
        
        /// <summary>
        /// Connection type is Roblox
        /// </summary>
        [DiscordEnum("roblox")] Roblox,

        /// <summary>
        /// Connection type is Spotify
        /// </summary>
        [DiscordEnum("spotify")] Spotify,    
        
        /// <summary>
        /// Connection type is Skype
        /// </summary>
        [DiscordEnum("skype")] Skype,     
        
        /// <summary>
        /// Connection type is Steam
        /// </summary>
        [DiscordEnum("steam")] Steam, 
        
        /// <summary>
        /// Connection type is TikTok
        /// </summary>
        [DiscordEnum("tiktok")] TikTok, 
        
        /// <summary>
        /// Connection type is Twitch
        /// </summary>
        [DiscordEnum("twitch")] Twitch,      
        
        /// <summary>
        /// Connection type is Twitter
        /// </summary>
        [DiscordEnum("twitter")] Twitter,   
        
        /// <summary>
        /// Connection type is X (Twitter)
        /// </summary>
        [DiscordEnum("twitter")] X,   
        
        /// <summary>
        /// Connection type is Xbox
        /// </summary>
        [DiscordEnum("xbox")] Xbox,        
        
        /// <summary>
        /// Connection type is Youtube
        /// </summary>
        [DiscordEnum("youtube")] Youtube,
    }
}