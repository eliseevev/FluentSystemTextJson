using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Example.Models;

namespace FluentSystemTextJson.Example.Profiles
{
    internal class CardInfoProfile : ConvertProfile<CardInfo>
    {
        public override void Configure(IRuleBuilder<CardInfo> bulder)
        {
            bulder
                .Include(it => it.Number)
                .Include(it => it.CCVCode);
        }
    }
}


