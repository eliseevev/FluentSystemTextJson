using System.Text.Json.Serialization;
using System.Text.Json;

namespace FluentSystemTextJson.Internal
{
    public abstract class WriteOnlyJsonConverter<T> : JsonConverter<T>
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException("The write-only converter does not allow deserialization.");
        }
    }
}