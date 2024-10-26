using System;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Base Discord Library for Oxide Libraries 
    /// </summary>
    /// <typeparam name="TLibrary"></typeparam>
    public abstract class BaseDiscordLibrary<TLibrary> : BaseDiscordLibrary where TLibrary : BaseDiscordLibrary<TLibrary>
    {
        internal static TLibrary Instance;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <exception cref="Exception">Thrown if the Library has already been initialized</exception>
        protected BaseDiscordLibrary()
        {
            if (Instance != null)
            {
                throw new Exception($"Duplicate Library Instances for type {typeof(TLibrary).FullName}");
            }
            
            Instance = (TLibrary)this;
        }
    }
}