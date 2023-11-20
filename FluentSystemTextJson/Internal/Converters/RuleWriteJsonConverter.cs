using System.Text.Json;

namespace FluentSystemTextJson.Internal.Converters
{
    internal class RuleWriteJsonConverter<T> : WriteOnlyJsonConverter<T>
    {
        private readonly Rule<T> _rule;

        public RuleWriteJsonConverter(
            Rule<T> rule)
        {
            _rule = rule ?? throw new ArgumentNullException(nameof(rule));
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var propertyRule in _rule.PropertiesRules)
            {
                if (options.PropertyNamingPolicy != null)
                {
                    writer.WritePropertyName(options.PropertyNamingPolicy.ConvertName(propertyRule.PropertyName));
                }
                else
                {
                    writer.WritePropertyName(propertyRule.PropertyName);
                }

                JsonSerializer.Serialize(writer, propertyRule.ConvertFunc.Invoke(value), options);
            }

            writer.WriteEndObject();
        }
    }
}