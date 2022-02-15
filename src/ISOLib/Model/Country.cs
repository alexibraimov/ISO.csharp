using System.Collections.Generic;

namespace ISOLib.Model
{
    public class Country  : ISOModel
    {
        public Country(string name, string alpha2, string alpha3, 
            string countryCode, string iso3166_2 = null, string region = null, 
            string subRegion = null, string intermediateRegion= null,
            string regionCode = null, string subRegionCode = null, string intermediateRegionCode = null) : base(alpha2, alpha3, name)
        {
            CountryCode = countryCode;
            ISO3166_2 = iso3166_2;
            Region = region;
            SubRegion = subRegion;
            IntermediateRegion = intermediateRegion;
            RegionCode = regionCode;
            SubRegionCode = subRegionCode;
            IntermediateRegionCode = intermediateRegionCode;
        }
        public string CountryCode { get; }
        public string ISO3166_2 { get; }
        public string Region { get; }
        public string SubRegion { get; }
        public string IntermediateRegion { get; }
        public string RegionCode { get; }
        public string SubRegionCode { get; }
        public string IntermediateRegionCode { get; }
        public override IDictionary<string, string> ToDictionary()
        {
            var baseDictionary =  base.ToDictionary();
            baseDictionary.Add("countryCode", CountryCode);
            baseDictionary.Add("iso3166_2", ISO3166_2);
            baseDictionary.Add("region", Region);
            baseDictionary.Add("subRegion", SubRegion);
            baseDictionary.Add("intermediateRegion", IntermediateRegion);
            baseDictionary.Add("regionCode", RegionCode);
            baseDictionary.Add("subRegionCode", SubRegionCode);
            baseDictionary.Add("intermediateRegionCode", IntermediateRegionCode);
            return baseDictionary;
        }
    }
}
