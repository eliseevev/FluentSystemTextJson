using FluentSystemTextJson.Contracts;
using SystemTextJsonFluentIgnorer.Benchmark.Fluent;

namespace SystemTextJsonFluentIgnorer.Benchmark.Fluent.SystemText
{
    internal class NestedClassLevel_2Profile : ConvertProfile<NestedClassLevel_2>
    {
        public override void Configure(IRuleBuilder<NestedClassLevel_2> bulder)
        {
            bulder
                .Include(it => it.UnSecureValue);
        }
    }
}


