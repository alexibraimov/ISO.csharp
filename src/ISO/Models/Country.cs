namespace ISOLib
{
    using System.Linq;
    public class Country
    {
        internal Country(string alpha2, string alpha3,
                         string name, string name2,
                         string nativeName, string capital,
                         string countryCode, string continent,
                         string continentAlpha2,
                         int[] phone, string[] currency, string[] languages,
                         string flag, string wiki)
        {
            Alpha2 = alpha2;
            Alpha3 = alpha3;
            Name = name;
            Name2 = name2;
            NativeName = nativeName;
            Capital = capital;
            CountryCode = countryCode;
            Continent = continent;
            ContinentAlpha2 = continentAlpha2;
            Phones = phone;
            Currencies = currency;
            Languages = languages;
            Flag = flag;
            Wiki = wiki;
        }

        public string Alpha2 { get; }
        public string Alpha3 { get; }
        public string Name { get; }
        public string Name2 { get; }
        public string NativeName { get; }
        public string Capital { get; }
        public string CountryCode { get; }
        public string Continent { get; }
        public string ContinentAlpha2 { get; }
        public string Wiki { get; }
        public string Flag { get; }
        public int[] Phones { get; }
        public string[] Currencies { get; }
        public string[] Languages { get; }

        /// <summary>
        /// Gets an array of languages associated with the country.
        /// </summary>
        public Language[] GetLanguages()
        {
            return this.Languages.Select(l => ISOLib.Languages.Collection[l]).ToArray();
        }
        /// <summary>
        /// Gets an array of currencies used in the country.
        /// </summary>
        public Currency[] GetCurrencies()
        {
            return this.Currencies.Select(l => ISOLib.Currencies.Collection[l]).ToArray();
        }
        public override string ToString() => Name;
        public override bool Equals(object obj)
        {
            if (obj is Country model)
            {
                return model.Alpha3.Equals(Alpha3);
            }
            return false;
        }
        public override int GetHashCode() => Alpha3.GetHashCode();
    }
}