using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Json
{
    internal class TemplateVersionConverter : JsonConverter
    {
        private const string Token = ".";
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = reader.Value.ToString();
            ReadOnlySpan<char> span = value;

            if (!span.TryParseNextString(Token, out span, out ReadOnlySpan<char> majorSpan) || !ushort.TryParse(majorSpan, out ushort major))
            {
                throw new JsonSerializationException($"{value} is not a valid major template version for. Major: {majorSpan.ToString()} Path: {reader.Path}.");
            }
            if (!span.TryParseNextString(Token, out span, out ReadOnlySpan<char> minorSpan) || !ushort.TryParse(minorSpan, out ushort minor))
            {
                throw new JsonSerializationException($"{value} is not a valid minor template version for. Minor: {minorSpan.ToString()} Path: {reader.Path}.");
            }
            if (!span.TryParseNextString(Token, out span, out ReadOnlySpan<char> revisionSpan) || !ushort.TryParse(revisionSpan, out ushort revision))
            {
                throw new JsonSerializationException($"{value} is not a valid revision template version for. Revision: {revisionSpan.ToString()} Path: {reader.Path}.");
            }
            
            return new TemplateVersion(major, minor, revision);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(TemplateVersion) == objectType;
        }
    }
}