namespace FluentSystemTextJson.Tests.Models
{
    internal class ModelA0
    {
        public string StringSecure { get; set; }

        public string StringUnsecure { get; set; }

        public int IntSecure { get; set; }

        public int IntUnsecure { get; set; }

        public ModelA1 ModelA1Secure { get; set; }

        public ModelA1 ModelA1UnSecure { get; set; }
    }
}
