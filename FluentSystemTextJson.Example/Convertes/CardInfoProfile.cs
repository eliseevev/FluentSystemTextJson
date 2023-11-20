using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Example.Models;
using FluentSystemTextJson.Extensions;

namespace FluentSystemTextJson.Example.Profiles
{
    internal class CardInfoProfile : ConvertProfile<CardInfo>
    {
        public override void Configure(IRuleBuilder<CardInfo> bulder)
        {
            bulder
                .IncludeAll()
                .Skip(it => it.Provider)
                .Include(it => it.Number)
                .IncludeSecure(it => it.CCVCode);
        }
    }
}


