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
                    nameof(CreateProfiledWriteOnlyJsonConverterInternal),
                    BindingFlags.NonPublic | BindingFlags.Instance);

        public JsonConverter<T> CreateProfiledWriteOnlyJsonConverter<T>(ConvertProfile<T> logProfile)
        {
            return CreateProfiledWriteOnlyJsonConverterInternal<T>(logProfile);
        }

        internal JsonConverter CreateProfiledWriteOnlyJsonConverter(ConvertProfile logProfile)
        {
            MethodInfo genMetSum = genericMethodInfo.MakeGenericMethod(logProfile.Type);
            return (JsonConverter)genMetSum.Invoke(this, new[] { logProfile });
        }

        private JsonConverter<T> CreateProfiledWriteOnlyJsonConverterInternal<T>(
            ConvertProfile logProfile)
        {
            var typedConvertProfile = logProfile as ConvertProfile<T>;
            if (typedConvertProfile == null)
            {
                throw new ArgumentException("ConvertProfile is not type of ConvertProfile<T>");
            }

            var rule = typedConvertProfile.GetRuleBuilder().Build();

            return new ProfiledWriteOnlyJsonConverter<T>(rule);
        }
    }
}
