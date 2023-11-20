using System.Collections;
using System.Text.Json;

namespace FluentSystemTextJson.Internal.Converters
{
    internal class DefaultEnumerableWriteOnlyJsonConverter : WriteOnlyJsonConverter<object>
    {
        private static Type enumerableType = typeof(IEnumerable);

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsAssignableTo(enumerableType);
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value is IEnumerable enumerable)
            {
                writer.WriteStartArray();
                foreach (var item in enumerable)
                {
                    JsonSerializer.Serialize(writer, item, options);
                }
                writer.WriteEndArray();
            }
        }
    }
}