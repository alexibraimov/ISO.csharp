using System;

namespace ISO3166Lib.Models
{
    public class Country 
    {

        public Country(string name, string alpha2, string alpha3, 
            string countryCode, string iso3166_2 = null, string region = null, 
            string subRegion = null, string intermediateRegion= null,
            string regionCode = null, string subRegionCode = null, string intermediateRegionCode = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Country name cannot be empty or null");
            }
            if (string.IsNullOrEmpty(alpha2))
            {
                throw new ArgumentNullException("Alpha2 cannot be empty or null");
            }
            if (string.IsNullOrEmpty(alpha3))
            {
                throw new ArgumentNullException("Alpha3 cannot be empty or null");
            }
            if (string.IsNullOrEmpty(countryCode))
            {
                throw new ArgumentNullException("Country code cannot be empty or null");
            }
            Name = name;
            Alpha2 = alpha2;
            Alpha3 = alpha3;
            CountryCode = countryCode;
            ISO3166_2 = iso3166_2;
            Region = region;
            SubRegion = subRegion;
            IntermediateRegion = intermediateRegion;
            RegionCode = regionCode;
            SubRegionCode = subRegionCode;
            IntermediateRegionCode = intermediateRegionCode;
        }

        public string Name { get; }
        public string Alpha2 { get; }
        public string Alpha3 { get; }
        public string CountryCode { get; }
        public string ISO3166_2 { get; }
        public string Region { get; }
        public string SubRegion { get; }
        public string IntermediateRegion { get; }
        public string RegionCode { get; }
        public string SubRegionCode { get; }
        public string IntermediateRegionCode { get; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Country country)
            {
                return country.Name.Equals(Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
