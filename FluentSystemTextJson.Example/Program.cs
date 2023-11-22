using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Example.Profiles;
using FluentSystemTextJson.Example.Models;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using FluentSystemTextJson.Internal.Converters;

namespace FluentSystemTextJson.Example
{
    internal class Program
    {
        ILogger logger;

        static void Main(string[] args)
        {
            ////var options =
            ////    new JsonSerializerOptionsFactoryOptions()
            ////    {
            ////        DefaultNoProfileConverterMessage = "Значение для моделей для которых нет профиля."
            ////    }
            ////        .AddProfile(new UserProfile())
            ////        .AddProfile(new CardInfoProfile());

            ////JsonSerializerOptionsFactory jsonLogSerializerFactory = new JsonSerializerOptionsFactory(options);

            ////var jsonSerializerOptions =
            ////    jsonLogSerializerFactory
            ////        .Create();

            ////jsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic);
            ////jsonSerializerOptions.WriteIndented = true;



            var jsonSerializerOptions = new JsonSerializerOptions();
            ////jsonSerializerOptions.Converters.Add(new InfoFluentJsonConverter());


            ////var a = JsonSerializer.SerializeToDocument(CreateUser(), jsonSerializerOptions);
            Console.WriteLine(JsonSerializer.Serialize(CreateUser(), jsonSerializerOptions));
            Console.WriteLine(JsonSerializer.Serialize(CreateUser(), jsonSerializerOptions));
            Console.WriteLine(JsonSerializer.Serialize(CreateUser(), jsonSerializerOptions));
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

        public class InfoFluentJsonConverter : ProfiledWriteOnlyJsonConverter<CardInfo>
        {
            public override void Configure(IRuleBuilder<CardInfo> builder)
            {
                builder.Include(it => it.Number);
            }
        }
    }
}