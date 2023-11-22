using System.Text.Json.Serialization;
using static FluentSystemTextJson.Example.Program;

namespace FluentSystemTextJson.Example.Models
{
    [JsonConverter(typeof(InfoFluentJsonConverter))]
    internal class CardInfo
    {
        public int Number { get; set; }

        public string Provider { get; set; }

        public string CCVCode { get; set; }
    }
}
