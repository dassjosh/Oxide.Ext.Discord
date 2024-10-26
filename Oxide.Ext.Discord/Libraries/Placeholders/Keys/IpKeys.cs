namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="IpPlaceholders"/>
    /// </summary>
    public class IpKeys
    {
        /// <summary>
        /// IP placeholder
        /// </summary>
        public readonly PlaceholderKey Ip;
        
        /// <summary>
        /// Ip Country Name Placeholder
        /// </summary>
        public readonly PlaceholderKey CountryName;
        
        /// <summary>
        /// IP Country Code Placeholder
        /// </summary>
        public readonly PlaceholderKey CountryCode;
        
        /// <summary>
        /// IP Country Emoji Placeholder
        /// </summary>
        public readonly PlaceholderKey CountryEmoji;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public IpKeys(string prefix)
        {
            Ip = new PlaceholderKey(prefix, "ip");
            CountryName = new PlaceholderKey(prefix, "country.name");
            CountryCode = new PlaceholderKey(prefix, "country.code");
            CountryEmoji = new PlaceholderKey(prefix, "country.emoji");
        }
    }
}