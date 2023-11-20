using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Tests.Models;
using System.Reflection.Metadata;
using System.Text.Json;

namespace FluentSystemTextJson.Tests
{
    public class Tests
    {
        private JsonSerializerOptions _jsonSerializerOptions;

        [SetUp]
        public void Setup()
        {
            var options =
                new JsonSerializerOptionsFactoryOptions()
                    .AddProfile(new ModelA0Profile());

            ProfiledWriteOnlyJsonConverterFactory jsonConverterOnProfileFactory = new ProfiledWriteOnlyJsonConverterFactory();
            JsonSerializerOptionsFactory jsonLogSerializerFactory = new JsonSerializerOptionsFactory(
                options,
                jsonConverterOnProfileFactory);
            _jsonSerializerOptions = jsonLogSerializerFactory.Create();
        }

        [Test]
        public void Test1()
        {
            // arrange
            var modelA0 = new ModelA0()
            {
                StringSecure = "1",
                StringUnsecure = "2",
                IntSecure = 3,
                IntUnsecure = 4,
            };


            // Act
            var actual = JsonSerializer.Serialize(modelA0, _jsonSerializerOptions);

            // Assert

            var expected = "{\"StringUnsecure\":\"2\",\"IntUnsecure\":4}";

            Assert.AreEqual(expected , actual);
        }


        internal class ModelA0Profile : ConvertProfile<ModelA0>
        {
            public override void Configure(IRuleBuilder<ModelA0> bulder)
            {
                bulder
                    .Include(it => it.StringUnsecure)
                    .Include(it => it.IntUnsecure);
            }
        }

    }
}