using System.Text.Json.Serialization;

namespace SystemTextJsonFluentIgnorer.Benchmark.Fluent
{
    internal class NestedClassLevel_3
    {
        [JsonIgnore]
        public string SecureValue { get; set; }

        public string UnSecureValue { get; set; }
    }
}
