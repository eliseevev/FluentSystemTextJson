namespace FluentSystemTextJson.Example.Models
{
    internal class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CardInfo Card { get; set; }

        public CardInfo[] Cards { get; set; }

        public OtherInfo Other { get; set; }

        public OtherInfo[] Others { get; set; }

        public string Number1 { get; set; }

        public string Number2 { get; set; }

        public string Number3 { get; set; }

        public string[] SomeArray { get; set; }
    }
}
