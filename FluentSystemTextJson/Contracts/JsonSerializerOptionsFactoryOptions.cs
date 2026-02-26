using System.ComponentModel;
using System.Text.Json.Serialization;

namespace FluentSystemTextJson.Contracts
{
    public class JsonSerializerOptionsFactoryOptions
    {
        internal ICollection<ConvertProfile> LogProfiles = new HashSet<ConvertProfile>();

        public JsonSerializerOptionsFactoryOptions AddProfile<T>(ConvertProfile<T> logProfile)
        {
            LogProfiles.Add(logProfile);
            return this;
        }

        public bool IncludeDefaultNoProfileConverter { get; set; } = true;

        public string DefaultNoProfileConverterMessage { get; set; } = "No profile";

        public bool IncludeDefaultEnumerableConverter { get; set; } = true;

        public ICollection<JsonConverter> AdditionalConverters { get; set; }
    }
}
