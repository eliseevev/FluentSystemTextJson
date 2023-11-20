using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Internal.Converters;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace FluentSystemTextJson.Internal
{
    public class JsonSerializerOptionsFactory
    {
        private readonly Lazy<ICollection<JsonConverter>> _converters;
        private readonly Lazy<JsonSerializerOptions> jsonSerializerOptions;

        public JsonSerializerOptionsFactory(
            JsonSerializerOptionsFactoryOptions jsonSerializerOptionsFactoryOptions,
            JsonConverterOnProfileFactory jsonConverterOnProfileFactory)
        {
            _converters = new Lazy<ICollection<JsonConverter>>(() =>
            {
                return jsonSerializerOptionsFactoryOptions
                   .LogProfiles
                   .Select(it => jsonConverterOnProfileFactory.CreateProfiledWriteOnlyJsonConverter(it))
                   .ToArray();
            });

            jsonSerializerOptions = new Lazy<JsonSerializerOptions>(CreateJsonSerializerOptions());
        }

        public JsonSerializerOptions Create()
        {
            return jsonSerializerOptions.Value;
        }

        private JsonSerializerOptions CreateJsonSerializerOptions()
        {
            var jsonSerializerOptions = new JsonSerializerOptions();

            // Порядок важен! фабрика должна быть в конце!
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.BooleanConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.ByteConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.ByteArrayConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.CharConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.DateTimeConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.DateTimeOffsetConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.DoubleConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.DecimalConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.GuidConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.Int16Converter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.Int32Converter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.Int64Converter);
            //jsonSerializerOptions.Converters.Add(new JsonElementConverter());
            //jsonSerializerOptions.Converters.Add(new JsonDocumentConverter());
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.ObjectConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.SByteConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.SingleConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.StringConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.TimeSpanConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.UInt16Converter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.UInt32Converter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.UInt64Converter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.UriConverter);
            jsonSerializerOptions.Converters.Add(JsonMetadataServices.VersionConverter);

            foreach (var converter in _converters.Value)
            {
                jsonSerializerOptions.Converters.Add(converter);
            }

            return jsonSerializerOptions;
        }
    }
}
