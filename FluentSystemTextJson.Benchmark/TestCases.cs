using BenchmarkDotNet.Attributes;
using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Example.Models;
using FluentSystemTextJson.Extensions;
using System.Text.Json;
using SystemTextJsonFluentIgnorer.Benchmark.Fluent;
using SystemTextJsonFluentIgnorer.Benchmark.Fluent.SystemText;

namespace FluentSystemTextJson.Benchmark
{
    [MemoryDiagnoser]
    public class TestCases
    {
        User user = new User()
            {
                Id = 1,
                Name = "Test",
                Card = new CardInfo
                {
                    CCVCode = "ccv",
                    Number = 1,
                    Provider = "Visa"
                },
                NestedClassLevel_1 = new NestedClassLevel_1
                {
                    UnSecureValue = "123",
                    NestedClassLevel_2 = new NestedClassLevel_2
                    {
                        UnSecureValue = "321",
                        NestedClassLevel_3 = new NestedClassLevel_3
                        {
                            SecureValue = "secure",
                            UnSecureValue = "unsecure"
                        }
                    }
                },
                Cards = new CardInfo[]
                {
                    new CardInfo(),
                    new CardInfo(),
                    new CardInfo(),
                }
            };


        [Benchmark]
        public string DefaultSerializeTest()
        {
            var json = JsonSerializer.Serialize(user);
            return json;
        }

        JsonSerializerOptions defaultJsonSerializerOptions = new JsonSerializerOptions();

        [Benchmark]
        public string DefaultSerializePreparedOptionsTest()
        {
            var json = JsonSerializer.Serialize(user, defaultJsonSerializerOptions);
            return json;
        }

        JsonSerializerOptions fluentPreparedJsonSerializerOptions;

        [GlobalSetup(Target = nameof(FluentSerializeTest))]
        public void FluentSerializeSetup()
        {
            var options =
                new JsonSerializerOptionsFactoryOptions()
                    .AddProfile(new UserProfile())
                    .AddProfile(new CardInfoProfile())
                    .AddProfile(new NestedClassLevel_3Profile());

            JsonSerializerOptionsFactory jsonLogSerializerFactory = new JsonSerializerOptionsFactory(
                options);
            fluentPreparedJsonSerializerOptions = jsonLogSerializerFactory
                .Create();
        }

        [Benchmark]
        public string FluentSerializeTest()
        {
            var json = JsonSerializer.Serialize(user, fluentPreparedJsonSerializerOptions);

            return json;
        }
    }
}
