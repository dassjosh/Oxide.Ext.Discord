namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/message-components#buttons-button-styles">Button Styles</a> within Discord..
    /// </summary>
    public enum ButtonStyle : byte
    {
        /// <summary>
        /// Color blurple
        /// Requires CustomId field
        /// </summary>
        Primary = 1,
        
        /// <summary>
        /// Color grey
        /// Requires CustomId field
        /// </summary>
        Secondary = 2,
        
        /// <summary>
        /// Color green
        /// Requires CustomId field
        /// </summary>
        Success = 3,
        
        /// <summary>
        /// Color red
        /// Requires CustomId field
        /// </summary>
        Danger = 4,
        
        /// <summary>
        /// Color grey
        /// Navigates to a URL
        /// Requires Url field
        /// </summary>
        Link = 5,
        
        /// <summary>
        /// Color blurple
        /// Navigates to a URL
        /// Requires SkuId field
        /// </summary>
        Premium = 6
    }
}