using FluentSystemTextJson.Contracts;
using FluentSystemTextJson.Internal;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentSystemTextJson.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T> IncludeSecure<T>(
            this IRuleBuilder<T> ruleBuilder,
            Expression<Func<T, string>> propertyExpression,
            byte firstShowCharacterCount = 8)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression));
            }

            PropertyInfo propertyInfo = ExpressionHelper.GetPropertyExpression(propertyExpression);

            return ruleBuilder.IncludeCustom(
                (_) 
                    => 
                    GetSubstring(propertyExpression.Compile().Invoke(_), firstShowCharacterCount) + new string('*', 3),
                    propertyInfo.Name);
        }

        private static string GetSubstring(string value, int firstShowCharacterCount)
        {
            return value.Substring(0, value.Length > firstShowCharacterCount ? firstShowCharacterCount : value.Length);
        }
    }
}
