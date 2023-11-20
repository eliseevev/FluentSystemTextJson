using FluentSystemTextJson.Internal;

namespace FluentSystemTextJson.Contracts
{
    public abstract class ConvertProfile<T> : ConvertProfile
    {
        public abstract void Configure(IRuleBuilder<T> bulder);

        internal sealed override Type Type => typeof(T);

        internal RuleBuilder<T> GetRuleBuilder()
        {
            var builder = new RuleBuilder<T>();
            Configure(builder);
            return builder;
        }
    }

    public abstract class ConvertProfile
    {
        internal abstract Type Type { get; }
    }
}
