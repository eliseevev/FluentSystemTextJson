using System.Text.Json.Serialization;

namespace FluentSystemTextJson.Example.Models
{
    internal class CardInfo
    {
        [JsonIgnore]
        public int Number { get; set; }

        public string Provider { get; set; }

        [JsonIgnore]
        public string CCVCode { get; set; }
    }
}
