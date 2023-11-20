using FluentSystemTextJson.Internal;
using System.Linq.Expressions;

namespace FluentSystemTextJson.Contracts
{
    public interface IRuleBuilder<T>
    {
        public IRuleBuilder<T> Include(Expression<Func<T, object>> propertyExpression);

        public IRuleBuilder<T> IncludeCustom(Expression<Func<T, object>> propertyExpression, string propertyName);

        internal Rule<T> Build();
    }
}