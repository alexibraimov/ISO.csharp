using System;

namespace ISO3166Lib.Models
{
    public class Language
    {
        public Language(string alpha2, string alpha3, string family, string name, string nativeName)
        {
            if (string.IsNullOrEmpty(alpha2))
            {
                throw new ArgumentNullException("Alpha 2 cannot be empty or null");
            }
            if (string.IsNullOrEmpty(alpha3))
            {
                throw new ArgumentNullException("Alpha 3 cannot be empty or null");
            }
            if (string.IsNullOrEmpty(family))
            {
                throw new ArgumentNullException("Family cannot be empty or null");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null");
            }
            if (string.IsNullOrEmpty(nativeName))
            {
                throw new ArgumentNullException("Native name cannot be empty or null");
            }

            Alpha2 = alpha2;
            Alpha3 = alpha3;
            Family = family;
            Name = name;
            NativeName = nativeName;
        }

        public string Alpha2 { get; }
        public string Alpha3 { get; }
        public string Family { get; }
        public string Name { get; }
        public string NativeName { get; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Language language)
            {
                return language.Alpha2.Equals(Alpha3);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Alpha2.GetHashCode();
        }
    }
}
