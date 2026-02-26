using System.Linq.Expressions;
using System.Reflection;

namespace FluentSystemTextJson.Internal
{
    internal static class ExpressionHelper
    {
        internal static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> propertyExpression)
        {
            return GetPropertyInfoInternal(propertyExpression);
        }

        internal static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, string>> propertyExpression)
        {
            var parameter = propertyExpression.Parameters[0];
            var body = Expression.Convert(propertyExpression.Body, typeof(object));
            var convertedExpression = Expression.Lambda<Func<T, object>>(body, parameter);

            return GetPropertyInfoInternal(convertedExpression);
        }

        private static PropertyInfo GetPropertyInfoInternal<T>(Expression<Func<T, object>> propertyExpression)
        {
            if (!(GetMemberExpression(propertyExpression) is MemberExpression memberExpression))
            {
                throw new ArgumentException("Expression is not a member expression.", nameof(propertyExpression));
            }

            if (!(memberExpression.Member is PropertyInfo propertyInfo))
            {
                throw new ArgumentException("Member is not a property.", nameof(propertyExpression));
            }

            return propertyInfo;
        }

        private static MemberExpression GetMemberExpression<T>(Expression<Func<T, object>> expression)
        {
            var member = expression.Body as MemberExpression;
            var unary = expression.Body as UnaryExpression;
            return member ?? (unary != null ? unary.Operand as MemberExpression : null);
        }
    }
}
