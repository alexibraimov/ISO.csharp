namespace ISOLib.Models
{
    public class Language : ISOModel
    {
        internal Language(string name, string alpha3, string? alpha2, string? family, string? nativeName) : base(alpha3: alpha3, name: name)
        {
            Alpha2 = alpha2?.ToUpper();
            Family = family;
            NativeName = nativeName;
        }

        public string? Alpha2 { get; }
        public string? Family { get; }
        public string? NativeName { get; }
    }
}
