using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Example.Models;

namespace SystemTextJsonFluentIgnorer.Benchmark.Fluent.SystemText
{
    internal class UserProfile : ConvertProfile<User>
    {
        public override void Configure(IRuleBuilder<User> bulder)
        {
            bulder
                .Include(it => it.Name)
                .Include(it => it.Number1)
                .Include(it => it.Number2)
                .Include(it => it.Number3)
                .Include(it => it.Card)
                .Include(it => it.Cards)
                .Include(it => it.NestedClassLevel_1);
        }
    }
}


