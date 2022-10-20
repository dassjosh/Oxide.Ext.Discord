using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oxide.Ext.Discord.Entities.Interactions.MessageComponents;
using Oxide.Ext.Discord.Entities.Interactions.MessageComponents.SelectMenus;

namespace Oxide.Ext.Discord.Json.Converters
{
    /// <summary>
    /// Converter for list of message components
    /// </summary>
    public class MessageComponentsConverter : JsonConverter
    {
        /// <summary>
        /// Ignored as we don't write JSON
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotSupportedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

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
            if (!(existingValue is List<BaseComponent> components))
            {
                components = new List<BaseComponent>();
            }

            foreach (JToken token in array)
            {
                MessageComponentType type = (MessageComponentType)Enum.Parse(typeof(MessageComponentType), token["type"].ToString());
                switch (type)
                {
                    case MessageComponentType.Button:
                        components.Add(token.ToObject<ButtonComponent>());
                        break;
                        
                    case MessageComponentType.StringSelect:
                        components.Add(token.ToObject<StringSelectComponent>());
                        break;
                    
                    case MessageComponentType.UserSelect:
                        components.Add(token.ToObject<UserSelectComponent>());
                        break;
                    
                    case MessageComponentType.RoleSelect:
                        components.Add(token.ToObject<RoleSelectComponent>());
                        break;
                    
                    case MessageComponentType.MentionableSelect:
                        components.Add(token.ToObject<MentionableSelectComponent>());
                        break;
                    
                    case MessageComponentType.ChannelSelect:
                        components.Add(token.ToObject<ChannelSelectComponent>());
                        break;
                    
                    case MessageComponentType.InputText:
                        components.Add(token.ToObject<InputTextComponent>());
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
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<BaseComponent>);
        }

        /// <summary>
        /// Message Component Convert does not write JSON
        /// </summary>
        public override bool CanWrite => false;
    }
}