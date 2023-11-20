using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Example.Profiles;
using FluentSystemTextJson.Example.Models;
using FluentSystemTextJson.Internal;
using System.Text.Json;

namespace FluentSystemTextJson.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options =
                new JsonSerializerOptionsFactoryOptions()
                    .AddProfile(new UserProfile())
                    .AddProfile(new CardInfoProfile());

            JsonConverterOnProfileFactory jsonConverterOnProfileFactory = new JsonConverterOnProfileFactory();
            JsonSerializerOptionsFactory jsonLogSerializerFactory = new JsonSerializerOptionsFactory(
                options,
                jsonConverterOnProfileFactory);
            var jsonSerializerOptions = jsonLogSerializerFactory.Create();

            Console.WriteLine(JsonSerializer.Serialize(CreateUser(), jsonSerializerOptions));
        }

        static User CreateUser()
        {
            var user = new User()
            {
                Id = 1,
                Name = "Test",
                Card = new CardInfo
                {
                    CCVCode = "1",
                    Number = 1,
                    Provider = "Visa"
                },
                Cards = new CardInfo[]
                {
                    new CardInfo
                    {
                        CCVCode = "1",
                        Number = 1,
                        Provider = "Visa"
                    }
                },
                Other = new OtherInfo
                {
                    Number = 2,
                    CCVCode = "!23",
                },
                Others = null,
                Number1 = "11111111111",
                Number2 = "11111111111",
                Number3 = "11111111111",
                SomeArray = new string[] { "12", "312" }
            };

            return user;
        }
    }
}