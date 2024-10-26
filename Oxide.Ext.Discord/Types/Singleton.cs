using System;
using System.Reflection;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a singleton of type {T}
    /// </summary>
    /// <typeparam name="T">Type of the singleton</typeparam>
    public abstract class Singleton<T> where T : Singleton<T>
    {
        /// <summary>
        /// Retrieves the instance of the singleton
        /// </summary>
        public static readonly T Instance;

        private const string ErrorMessage = "must have only one constructor that is parameterless and private.";
        
        static Singleton()
        {
            ConstructorInfo[] constructors = typeof(T).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (constructors.Length != 1)
            {
                throw new Exception($"{typeof(T)} {ErrorMessage}");
            }

            ConstructorInfo constructor = constructors[0];
            if (constructor.IsPublic)
            {
                throw new Exception($"{typeof(T)} {ErrorMessage}");
            }
            
            try 
            {
                Instance = (T)constructor.Invoke(null);
            }
            catch 
            {
                throw new Exception($"{typeof(T)} {ErrorMessage}");
            }
        }
    }
}