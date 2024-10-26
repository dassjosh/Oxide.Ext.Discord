namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Used for bulk template registration
    /// </summary>
    /// <typeparam name="T">Type of the template being registered</typeparam>
    public class BulkTemplateRegistration<T>
    {
        /// <summary>
        /// Language for this template
        /// </summary>
        public string Language { get; set; }
        
        /// <summary>
        /// Template to register
        /// </summary>
        public T Template { get; set; }
        
        /// <summary>
        /// Version of the template
        /// </summary>
        public TemplateVersion Version { get; set; }

        /// <summary>
        /// Constructor for bulk template registration
        /// </summary>
        /// <param name="template">Template to register</param>
        /// <param name="language">Language for the template</param>
        /// <param name="version">Version of the template</param>
        public BulkTemplateRegistration(T template, string language, TemplateVersion version)
        {
            Template = template;
            Language = language;
            Version = version;
        }
    }
}