using FluentSystemTextJson.Contracts;

namespace SystemTextJsonFluentIgnorer.Benchmark.Fluent.SystemText
{
    internal class NestedClassLevel_3Profile : ConvertProfile<NestedClassLevel_3>
    {
        public override void Configure(IRuleBuilder<NestedClassLevel_3> bulder)
        {
            bulder
                .Include(it => it.UnSecureValue);
        }
    }
}


