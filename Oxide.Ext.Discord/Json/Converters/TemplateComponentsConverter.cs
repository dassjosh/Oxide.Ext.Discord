using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Json
{
    /// <summary>
    /// Converter for a list of message components
    /// </summary>
    public class TemplateComponentsConverter : JsonConverter
    {
        /// <summary>
        /// Ignored as we don't write JSON
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotSupportedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotSupportedException();

        /// <summary>
        /// Populate the correct types in components instead of just the BaseComponent
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            if (existingValue is not List<BaseComponentTemplate> components)
            {
                components = new List<BaseComponentTemplate>();
            }

            foreach (JToken token in array)
            {
                MessageComponentType type = (MessageComponentType)Enum.Parse(typeof(MessageComponentType), token["Type"].ToString());
                switch (type)
                {
                    case MessageComponentType.Button:
                        components.Add(token.ToObject<ButtonTemplate>(serializer));
                        break;
                        
                    case MessageComponentType.StringSelect:
                    case MessageComponentType.UserSelect:
                    case MessageComponentType.RoleSelect:
                    case MessageComponentType.MentionableSelect:
                    case MessageComponentType.ChannelSelect:
                        components.Add(token.ToObject<SelectMenuTemplate>(serializer));
                        break;
                    
                    case MessageComponentType.InputText:
                        components.Add(token.ToObject<InputTextTemplate>(serializer));
                        break;
                }
            }

            return components;
        }

        /// <summary>
        /// Returns if this can convert the value
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType) => objectType == typeof(List<BaseComponentTemplate>);

        /// <summary>
        /// Message Component Convert does not write JSON
        /// </summary>
        public override bool CanWrite => false;
    }
}