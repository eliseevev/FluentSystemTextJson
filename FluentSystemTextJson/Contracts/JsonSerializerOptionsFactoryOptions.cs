namespace FluentSystemTextJson.Contracts
{
    public class JsonSerializerOptionsFactoryOptions
    {
        internal ICollection<ConvertProfile> LogProfiles = new HashSet<ConvertProfile>();

        public JsonSerializerOptionsFactoryOptions AddProfile<T>(ConvertProfile<T> logProfile)
        {
            LogProfiles.Add(logProfile);
            return this;
        }
    }
}
