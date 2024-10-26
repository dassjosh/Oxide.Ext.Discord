using System.Collections.Generic;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Builder used to build query strings for urls
    /// </summary>
    public ref struct QueryStringBuilder
    {
        private ValueStringBuilder _builder;

        /// <summary>
        /// Add a key value pair to the query string
        /// </summary>
        /// <param name="key">Key name</param>
        /// <param name="value">Key value</param>
        public void Add(string key, string value)
        {
            AddKey(key);
            _builder.Append(value);
        }

        /// <summary>
        /// Add a list of values with the specified separator
        /// </summary>
        /// <param name="key">Key name</param>
        /// <param name="list">List to be added</param>
        /// <param name="separator">Separator for the list</param>
        /// <typeparam name="T"></typeparam>
        public void AddList<T>(string key, List<T> list, string separator)
        {
            AddKey(key);
            for (int index = 0; index < list.Count; index++)
            {
                T entry = list[index];
                _builder.Append(entry.ToString());
                if (index + 1 != list.Count)
                {
                    _builder.Append(separator);
                }
            }
        }

        private void AddKey(string key)
        {
            if (_builder.Length > 1)
            {
                _builder.Append('&');
            }
            
            _builder.Append(key);
            _builder.Append('=');
        }

        /// <summary>
        /// Returns the query string as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            _builder.Insert(0, "?");
            return _builder.Length <= 1 ? string.Empty : _builder.ToString();
        }
    }
}