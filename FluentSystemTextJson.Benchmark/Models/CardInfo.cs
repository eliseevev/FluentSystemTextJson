using System.Text.Json.Serialization;

namespace FluentSystemTextJson.Example.Models
{

    internal class OtherInfo
    {
        [JsonIgnore]
        public int Number { get; set; }

        public string CCVCode { get; set; }
    }
}
