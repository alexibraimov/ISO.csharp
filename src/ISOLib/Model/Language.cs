namespace ISO3166Lib.Model
{
    public class Language : ISOModel
    {
        public Language(string alpha2, string alpha3, string family, string name, string nativeName) : base(alpha2, alpha3, name)
        {
            Family = family;
            NativeName = nativeName;
        }
        public string Family { get; }
        public string NativeName { get; }
    }
}
