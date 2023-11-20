using System.Text.Json;

namespace FluentSystemTextJson.Internal.Converters
{
    internal class DefaultNoProfileJsonConverter : WriteOnlyJsonConverter<object>
    {
        private readonly string _noProfileMessage;
        public DefaultNoProfileJsonConverter(string noProfileMessage = "No profile!")
        {
            _noProfileMessage = noProfileMessage;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_noProfileMessage);
        }
    }
}