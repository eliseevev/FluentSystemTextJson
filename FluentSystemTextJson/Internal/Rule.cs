namespace FluentSystemTextJson.Internal
{
    internal class Rule<T>
    {
        public ICollection<PropretyRule<T>> PropertiesRules { get; init; }
    }
}
