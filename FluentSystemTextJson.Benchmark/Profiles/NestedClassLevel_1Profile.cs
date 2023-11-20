using FluentSystemTextJson.Contracts;
using SystemTextJsonFluentIgnorer.Benchmark.Fluent;

namespace SystemTextJsonFluentIgnorer.Benchmark.Fluent.SystemText
{
    internal class NestedClassLevel_1Profile : ConvertProfile<NestedClassLevel_1>
    {
        public override void Configure(IRuleBuilder<NestedClassLevel_1> bulder)
        {
            bulder
                .Include(it => it.UnSecureValue);
        }
    }
}


