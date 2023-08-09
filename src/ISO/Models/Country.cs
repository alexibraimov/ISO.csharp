namespace ISOLib.Models
{
    public class Country : ISOModel
    {
        internal Country(string name, string alpha3, string alpha2 = null,
                         string countryCode = null, string iso3166_2 = null, string region = null,
                         string subRegion = null, string intermediateRegion = null,
                         string regionCode = null, string subRegionCode = null, string intermediateRegionCode = null) : base(alpha3: alpha3, name: name)
        {
            Alpha2 = alpha2?.ToUpper();
            CountryCode = countryCode;
            ISO3166_2 = iso3166_2;
            Region = region;
            SubRegion = subRegion;
            IntermediateRegion = intermediateRegion;
            RegionCode = regionCode;
            SubRegionCode = subRegionCode;
            IntermediateRegionCode = intermediateRegionCode;
            Wiki = $"https://en.wikipedia.org/wiki/ISO_3166-2:{Alpha2}";
        }

        public string Alpha2 { get; }
        public string CountryCode { get; }
        public string ISO3166_2 { get; }
        public string Region { get; }
        public string SubRegion { get; }
        public string IntermediateRegion { get; }
        public string RegionCode { get; }
        public string SubRegionCode { get; }
        public string IntermediateRegionCode { get; }
        public string Wiki { get; }
    }
}
