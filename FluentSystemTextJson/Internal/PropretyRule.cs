using System.Reflection;

namespace FluentSystemTextJson.Internal
{
    internal class PropretyRule<T>
    {
        public string PropertyName { get; init; }

        public Func<T, object> ConvertFunc { get; init; }
    }
}
