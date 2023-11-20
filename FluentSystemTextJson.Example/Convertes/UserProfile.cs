using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Example.Models;
using FluentSystemTextJson.Extensions;

namespace FluentSystemTextJson.Example.Profiles
{
    internal class UserProfile : ConvertProfile<User>
    {
        public override void Configure(IRuleBuilder<User> bulder)
        {
            //IncludeSecure и IncludeCustom БУДЕТ РАБОТАТЬ ТОЛЬКО СО СВОЙСТВАМИ ТИПА string.
            // ПРИ ЭТОМ ВНУТРИ ПРОВЕРЯЕМ ЧТО ЭТО membverExpression, соответственно написать что-то типа  
            //  .IncludeSecure(it => it.Card.ToString()) будет нельзя 
            bulder
                .IncludeSecure(it => it.Name, firstShowCharacterCount: 8)
                .IncludeSecure(it => it.Number1, firstShowCharacterCount: 2)
                .Include(it => it.Card)
                .Include(it => it.Cards)
                .Include(it => it.Other)
                .Include(it => it.Others)
                .Include(it => it.SomeArray)
                .IncludeCustom(it => 1000000, propertyName: "Some int value")
                .IncludeCustom(it => new DateTime() + TimeSpan.FromMinutes(123123123), "custom datetime");
        }
    }
}


