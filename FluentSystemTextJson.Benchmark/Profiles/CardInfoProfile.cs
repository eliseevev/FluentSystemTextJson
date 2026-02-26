using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Example.Models;

namespace SystemTextJsonFluentIgnorer.Benchmark.Fluent.SystemText
{
    internal class CardInfoProfile : ConvertProfile<CardInfo>
    {
        public override void Configure(IRuleBuilder<CardInfo> bulder)
        {
            bulder
                .Include(it => it.Provider);
        }
    }
}


