using FluentSystemTextJson.Internal.Converters;
using System.Text.Json;

namespace FluentSystemTextJson.Extensions
{
    public static class JsonSerializerOptionExtensions
    {
        public static JsonSerializerOptions AddDefaultWriteOnlyConverters(
            this JsonSerializerOptions jsonSerializerOptions,
            string noProfileConverterMessage = "No profile!")
        {
            jsonSerializerOptions.Converters.Add(new DefaultEnumerableWriteOnlyJsonConverter());
            jsonSerializerOptions.Converters.Add(new DefaultNoProfileWriteOnlyJsonConverter(noProfileConverterMessage));
            return jsonSerializerOptions;
        }
    }
}
