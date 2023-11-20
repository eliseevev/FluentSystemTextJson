using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Internal.Converters;
using System.Reflection;
using System.Text.Json.Serialization;

namespace FluentSystemTextJson
{
    public class JsonConverterOnProfileFactory
    {
        private static MethodInfo genericMethodInfo =
            typeof(JsonConverterOnProfileFactory)
                .GetMethod(
                    nameof(CreateJsonLogProfileWriteConverterConverterInternal),
                    BindingFlags.NonPublic | BindingFlags.Instance);

        public JsonConverter<T> CreateJsonLogProfileWriteConverterConverter<T>(ConvertProfile<T> logProfile)
        {
            return CreateJsonLogProfileWriteConverterConverterInternal<T>(logProfile);
        }

        internal JsonConverter CreateJsonLogProfileWriteConverterConverter(ConvertProfile logProfile)
        {
            MethodInfo genMetSum = genericMethodInfo.MakeGenericMethod(logProfile.Type);
            return (JsonConverter)genMetSum.Invoke(this, new[] { logProfile });
        }

        private JsonConverter<T> CreateJsonLogProfileWriteConverterConverterInternal<T>(
            ConvertProfile logProfile)
        {
            var typedConvertProfile = logProfile as ConvertProfile<T>;
            if (typedConvertProfile == null)
            {
                throw new ArgumentException("ConvertProfile is not type of ConvertProfile<T>");
            }

            var hideWriterRuleBuilder = typedConvertProfile.GetRuleBuilder().Build();

            return new RuleWriteJsonConverter<T>(hideWriterRuleBuilder);
        }
    }
}
