namespace ISOLib
{
    public class Language
    {
        internal Language(string alpha2, string alpha3, string name, string name2, string nativeName, string family)
        {
            Alpha2 = alpha2;
            Alpha3 = alpha3;
            Name = name;
            Name2 = name2;
            NativeName = nativeName;
            Family = family;
        }

        public string Alpha2 { get; }
        public string Alpha3 { get; }
        public string Name { get; }
        public string Name2 { get; }
        public string NativeName { get; }
        public string Family { get; }
        public override string ToString() => Name;
        public override bool Equals(object obj)
        {
            if (obj is Language model)
            {
                return model.Alpha3.Equals(Alpha3);
            }
            return false;
        }
        public override int GetHashCode() => Alpha3.GetHashCode();
    }
}