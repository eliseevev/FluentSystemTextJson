using FluentSystemTextJson.Contracts;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentSystemTextJson.Internal
{
    internal class RuleBuilder<T> : IRuleBuilder<T>
    {
        private readonly Dictionary<string, PropretyRule<T>> properties =
            new Dictionary<string, PropretyRule<T>>();

        public Rule<T> Build() => new Rule<T>() { PropertiesRules = properties.Values };

        public IRuleBuilder<T> Include(Expression<Func<T, object>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression));
            }

            PropertyInfo propertyInfo = ExpressionHelper.GetPropertyExpression(propertyExpression);

            ParameterExpression instance = Expression.Parameter(typeof(T), nameof(T));
            MemberExpression propertyAccess = Expression.Property(instance, propertyInfo);

            var getValueFunc = Expression.Lambda<Func<T, object>>(Expression.Convert(propertyAccess, typeof(object)), instance).Compile();

            properties.Add(
                propertyInfo.Name,
                new PropretyRule<T>
                {
                    PropertyName = propertyInfo.Name,
                    ConvertFunc = getValueFunc
                });

            return this;
        }

        public IRuleBuilder<T> IncludeCustom(Expression<Func<T, object>> propertyExpression, string propertyName)
        {
            properties.Add(
                propertyName,
                new PropretyRule<T>
                {
                    PropertyName = propertyName,
                    ConvertFunc = propertyExpression.Compile(),
                });
            return this;
        }
    }
}