using System.Text.Json.Serialization;
using SystemTextJsonFluentIgnorer.Benchmark.Fluent;

namespace FluentSystemTextJson.Example.Models
{
    internal class User
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public CardInfo Card { get; set; }

        public CardInfo[] Cards { get; set; }

        [JsonIgnore]
        public OtherInfo Other { get; set; }

        [JsonIgnore]
        public OtherInfo[] Others { get; set; }

        public string Number1 { get; set; }

        public string Number2 { get; set; }

        public string Number3 { get; set; }

        [JsonIgnore]
        public string[] SomeArray { get; set; }

        public NestedClassLevel_1 NestedClassLevel_1 { get; set; }
    }
}
