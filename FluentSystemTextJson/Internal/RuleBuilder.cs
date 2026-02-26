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

            PropertyInfo propertyInfo = ExpressionHelper.GetPropertyInfo(propertyExpression);

            ParameterExpression instance = Expression.Parameter(typeof(T), nameof(T));
            MemberExpression propertyAccess = Expression.Property(instance, propertyInfo);

            var getValueFunc = Expression.Lambda<Func<T, object>>(Expression.Convert(propertyAccess, typeof(object)), instance).Compile();

            properties[propertyInfo.Name] =
                new PropretyRule<T>
                {
                    PropertyName = propertyInfo.Name,
                    ConvertFunc = getValueFunc
                };

            return this;
        }

        public IRuleBuilder<T> IncludeAll()
        {
            foreach (var property in typeof(T).GetProperties())
            {
                ParameterExpression instance = Expression.Parameter(typeof(T), property.Name);
                MemberExpression propertyAccess = Expression.Property(instance, property);
                Func<T, object> getValueFunc = Expression.Lambda<Func<T, object>>(Expression.Convert(propertyAccess, typeof(object)), instance).Compile();

                AddPropertyRule(getValueFunc, property.Name);
            }

            return this;
        }

        public IRuleBuilder<T> Skip(Expression<Func<T, object>> propertyExpression)
        {
            properties.Remove(ExpressionHelper.GetPropertyInfo(propertyExpression).Name);

            return this;
        }

        public IRuleBuilder<T> IncludeCustom(Expression<Func<T, object>> propertyExpression, string propertyName)
        {
            properties[propertyName] =
                new PropretyRule<T>
                {
                    PropertyName = propertyName,
                    ConvertFunc = propertyExpression.Compile(),
                };

            return this;
        }

        private void AddPropertyRule(Func<T, object> convertFunc, string name)
        {
            properties[name] =
                new PropretyRule<T>
                {
                    PropertyName = name,
                    ConvertFunc = convertFunc,
                };
        }
    }
}