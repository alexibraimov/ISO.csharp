namespace ISOLib
{
    using ISOLib.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Countries : ReadOnlyCollection<Country>, IISO
    {
        static Countries()
        {
            Collection = new Countries();
        }
        private Countries() : base(new Country[] { AF, AX, AL, DZ, AO, AI, AD, AS, AQ, AG, AR, AM, AW, AU, AT, AZ, BS, BH, BD, BB, BY, BE, BZ, BJ, BM, BT, BO, BQ, BA, BW, BV, BR, IO, BN, BG, BF, BI, CV, KH, CM, CA, KY, CF, TD, CL, CN, CX, CC, CO, KM, CG, CD, CK, CR, CI, HR, CU, CW, CY, CZ, DK, DJ, DM, DO, EC, EG, SV, GQ, ER, EE, SZ, ET, FK, FO, FJ, FI, FR, GF, PF, TF, GA, GM, GE, DE, GH, GI, GR, GL, GD, GP, GU, GT, GG, GN, GW, GY, HT, HM, VA, HN, HK, HU, IS, IN, ID, IR, IQ, IE, IM, IL, IT, JM, JP, JE, JO, KZ, KE, KI, KP, KR, KW, KG, LA, LV, LB, LS, LR, LY, LI, LT, LU, MO, MG, MW, MY, MV, ML, MT, MH, MQ, MR, MU, YT, MX, FM, MD, MC, MN, ME, MS, MA, MZ, MM, NA, NR, NP, NL, NC, NZ, NI, NE, NG, NU, NF, MK, MP, NO, OM, PK, PW, PS, PA, PG, PY, PE, PH, PN, PL, PT, PR, QA, RE, RO, RU, RW, BL, SH, KN, LC, MF, PM, VC, WS, SM, ST, SA, SN, RS, SC, SL, SG, SX, SK, SI, SB, SO, ZA, GS, SS, ES, LK, SD, SR, SJ, SE, CH, SY, TW, TJ, TZ, TH, TL, TG, TK, TO, TT, TN, TR, TM, TC, TV, UG, UA, AE, GB, US, UM, UY, UZ, VU, VE, VN, VG, VI, WF, EH, YE, ZM, ZW, })
        {
        }

        public int Number { get; } = 3166;
        public string Name { get; } = "ISO 3166";
        public string Wiki { get; } = "https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes";
        /// <summary>
        /// Gets the collection of countries defined by the ISO 3166 standard.
        /// </summary>
        public static Countries Collection { get; }
        /// <summary>
        /// Gets the <see cref="Country"/> object corresponding to the specified country name, Alpha-2 code, or Alpha-3 code.
        /// </summary>
        /// <param name="key">The name, Alpha-2 code, or Alpha-3 code of the country to retrieve.</param>
        /// <returns>The <see cref="Country"/> object representing the specified country.</returns>
        /// <exception cref="ArgumentException">Thrown when the specified country name, Alpha-2 code, or Alpha-3 code does not match any country in the collection.</exception>
        public Country this[string key]
        {
            get
            {
                if (TryGetValue(key, out Country country))
                {
                    return country;
                }

                throw new ArgumentException("Country not found", nameof(key));
            }
        }
        /// <summary>
        /// Tries to retrieve a country by its key (name, name2, alpha2, or alpha3) from the collection of countries.
        /// </summary>
        /// <param name="key">The key (name, name2, alpha2, or alpha3) of the country to retrieve.</param>
        /// <param name="country">When this method returns, contains the retrieved country or null if not found.</param>
        /// <returns>True if the country was found; otherwise, false.</returns>
        public bool TryGetValue(string key, out Country country)
        {
            if (string.IsNullOrEmpty(key))
            {
                country = null;
            }
            else
            {
                country = Items.FirstOrDefault(c =>
                    c.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase) ||
                    c.Name2.Equals(key, StringComparison.InvariantCultureIgnoreCase) ||
                    c.Alpha2.Equals(key, StringComparison.InvariantCultureIgnoreCase) ||
                    c.Alpha3.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            }

            return country != null;
        }
        /// <summary>
        /// Gets a country by its ISO 3166-1 alpha-2 code.
        /// </summary>
        public static Country GetByAlpha2Code(string alpha2)
        {
            return Collection.FirstOrDefault(c => c.Alpha2.Equals(alpha2, StringComparison.InvariantCultureIgnoreCase));
        }
        /// <summary>
        /// Gets a country by its ISO 3166-2 alpha-3 code.
        /// </summary>
        public static Country GetByAlpha3Code(string alpha3)
        {
            return Collection.FirstOrDefault(c => c.Alpha3.Equals(alpha3, StringComparison.InvariantCultureIgnoreCase));
        }
        /// <summary>
        /// Gets a country by its name or alternative name.
        /// </summary>
        public static Country GetByName(string name)
        {
            return Collection.FirstOrDefault(c => c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) || c.Name2.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
        /// <summary>
        /// Gets an array of country names.
        /// </summary>
        public static string[] GetNames()
        {
            return Collection.Select(c => c.Name).ToArray();
        }
        /// <summary>
        /// Gets an array of ISO 3166-1 alpha-2 codes.
        /// </summary>
        public static string[] GetAlpha2Codes()
        {
            return Collection.Select(c => c.Alpha2).ToArray();
        }
        /// <summary>
        /// Gets an array of ISO 3166-2 alpha-3 codes.
        /// </summary>
        public static string[] GetAlpha3Codes()
        {
            return Collection.Select(c => c.Alpha3).ToArray();
        }
        /// <summary>
        /// Filters and returns an array of countries based on their keys.
        /// </summary>
        /// <param name="countryKeys">The keys of the countries to filter by.</param>
        /// <returns>An array of filtered countries.</returns>
        public static Country[] FilterCountries(params string[] countryKeys)
        {
            var filteredCountries = new List<Country>();

            foreach (var key in countryKeys)
            {
                if (Collection.TryGetValue(key, out Country country))
                {
                    filteredCountries.Add(country);
                }
            }

            return filteredCountries.ToArray();
        }
        #region Alpha2
        /// <summary>
        /// Afghanistan
        /// </summary>
        public static Country AF { get; } = new Country(alpha2: "AF", alpha3: "AFG", name: "Afghanistan", name2: "Afghanistan", nativeName: "افغانستان", capital: "Kabul", countryCode: "004", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 93 }, currency: new string[] { "AFN" }, languages: new string[] { "ps", "uz", "tk" }, flag: "🇦🇫", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AF");
        /// <summary>
        /// Åland Islands
        /// </summary>
        public static Country AX { get; } = new Country(alpha2: "AX", alpha3: "ALA", name: "Åland Islands", name2: "Aland", nativeName: "Åland", capital: "Mariehamn", countryCode: "248", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 358 }, currency: new string[] { "EUR" }, languages: new string[] { "sv" }, flag: "🇦🇽", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AX");
        /// <summary>
        /// Albania
        /// </summary>
        public static Country AL { get; } = new Country(alpha2: "AL", alpha3: "ALB", name: "Albania", name2: "Albania", nativeName: "Shqipëria", capital: "Tirana", countryCode: "008", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 355 }, currency: new string[] { "ALL" }, languages: new string[] { "sq" }, flag: "🇦🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AL");
        /// <summary>
        /// Algeria
        /// </summary>
        public static Country DZ { get; } = new Country(alpha2: "DZ", alpha3: "DZA", name: "Algeria", name2: "Algeria", nativeName: "الجزائر", capital: "Algiers", countryCode: "012", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 213 }, currency: new string[] { "DZD" }, languages: new string[] { "ar" }, flag: "🇩🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:DZ");
        /// <summary>
        /// Angola
        /// </summary>
        public static Country AO { get; } = new Country(alpha2: "AO", alpha3: "AGO", name: "Angola", name2: "Angola", nativeName: "Angola", capital: "Luanda", countryCode: "024", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 244 }, currency: new string[] { "AOA" }, languages: new string[] { "pt" }, flag: "🇦🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AO");
        /// <summary>
        /// Anguilla
        /// </summary>
        public static Country AI { get; } = new Country(alpha2: "AI", alpha3: "AIA", name: "Anguilla", name2: "Anguilla", nativeName: "Anguilla", capital: "The Valley", countryCode: "660", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1264 }, currency: new string[] { "XCD" }, languages: new string[] { "en" }, flag: "🇦🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AI");
        /// <summary>
        /// Andorra
        /// </summary>
        public static Country AD { get; } = new Country(alpha2: "AD", alpha3: "AND", name: "Andorra", name2: "Andorra", nativeName: "Andorra", capital: "Andorra la Vella", countryCode: "020", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 376 }, currency: new string[] { "EUR" }, languages: new string[] { "ca" }, flag: "🇦🇩", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AD");
        /// <summary>
        /// American Samoa
        /// </summary>
        public static Country AS { get; } = new Country(alpha2: "AS", alpha3: "ASM", name: "American Samoa", name2: "American Samoa", nativeName: "American Samoa", capital: "Pago Pago", countryCode: "016", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 1684 }, currency: new string[] { "USD" }, languages: new string[] { "en", "sm" }, flag: "🇦🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AS");
        /// <summary>
        /// Antarctica
        /// </summary>
        public static Country AQ { get; } = new Country(alpha2: "AQ", alpha3: "ATA", name: "Antarctica", name2: "Antarctica", nativeName: "Antarctica", capital: "", countryCode: "010", continent: "Antarctica", continentAlpha2: "AN", phone: new int[] { 672 }, currency: Array.Empty<string>(), languages: Array.Empty<string>(), flag: "🇦🇶", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AQ");
        /// <summary>
        /// Antigua and Barbuda
        /// </summary>
        public static Country AG { get; } = new Country(alpha2: "AG", alpha3: "ATG", name: "Antigua and Barbuda", name2: "Antigua and Barbuda", nativeName: "Antigua and Barbuda", capital: "Saint John's", countryCode: "028", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1268 }, currency: new string[] { "XCD" }, languages: new string[] { "en" }, flag: "🇦🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AG");
        /// <summary>
        /// Argentina
        /// </summary>
        public static Country AR { get; } = new Country(alpha2: "AR", alpha3: "ARG", name: "Argentina", name2: "Argentina", nativeName: "Argentina", capital: "Buenos Aires", countryCode: "032", continent: "South America", continentAlpha2: "SA", phone: new int[] { 54 }, currency: new string[] { "ARS" }, languages: new string[] { "es", "gn" }, flag: "🇦🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AR");
        /// <summary>
        /// Armenia
        /// </summary>
        public static Country AM { get; } = new Country(alpha2: "AM", alpha3: "ARM", name: "Armenia", name2: "Armenia", nativeName: "Հայաստան", capital: "Yerevan", countryCode: "051", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 374 }, currency: new string[] { "AMD" }, languages: new string[] { "hy", "ru" }, flag: "🇦🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AM");
        /// <summary>
        /// Aruba
        /// </summary>
        public static Country AW { get; } = new Country(alpha2: "AW", alpha3: "ABW", name: "Aruba", name2: "Aruba", nativeName: "Aruba", capital: "Oranjestad", countryCode: "533", continent: "North America", continentAlpha2: "NA", phone: new int[] { 297 }, currency: new string[] { "AWG" }, languages: new string[] { "nl", "pa" }, flag: "🇦🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AW");
        /// <summary>
        /// Australia
        /// </summary>
        public static Country AU { get; } = new Country(alpha2: "AU", alpha3: "AUS", name: "Australia", name2: "Australia", nativeName: "Australia", capital: "Canberra", countryCode: "036", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 61 }, currency: new string[] { "AUD" }, languages: new string[] { "en" }, flag: "🇦🇺", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AU");
        /// <summary>
        /// Austria
        /// </summary>
        public static Country AT { get; } = new Country(alpha2: "AT", alpha3: "AUT", name: "Austria", name2: "Austria", nativeName: "Österreich", capital: "Vienna", countryCode: "040", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 43 }, currency: new string[] { "EUR" }, languages: new string[] { "de" }, flag: "🇦🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AT");
        /// <summary>
        /// Azerbaijan
        /// </summary>
        public static Country AZ { get; } = new Country(alpha2: "AZ", alpha3: "AZE", name: "Azerbaijan", name2: "Azerbaijan", nativeName: "Azərbaycan", capital: "Baku", countryCode: "031", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 994 }, currency: new string[] { "AZN" }, languages: new string[] { "az" }, flag: "🇦🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AZ");
        /// <summary>
        /// Bahamas
        /// </summary>
        public static Country BS { get; } = new Country(alpha2: "BS", alpha3: "BHS", name: "Bahamas", name2: "Bahamas", nativeName: "Bahamas", capital: "Nassau", countryCode: "044", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1242 }, currency: new string[] { "BSD" }, languages: new string[] { "en" }, flag: "🇧🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BS");
        /// <summary>
        /// Bahrain
        /// </summary>
        public static Country BH { get; } = new Country(alpha2: "BH", alpha3: "BHR", name: "Bahrain", name2: "Bahrain", nativeName: "‏البحرين", capital: "Manama", countryCode: "048", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 973 }, currency: new string[] { "BHD" }, languages: new string[] { "ar" }, flag: "🇧🇭", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BH");
        /// <summary>
        /// Bangladesh
        /// </summary>
        public static Country BD { get; } = new Country(alpha2: "BD", alpha3: "BGD", name: "Bangladesh", name2: "Bangladesh", nativeName: "Bangladesh", capital: "Dhaka", countryCode: "050", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 880 }, currency: new string[] { "BDT" }, languages: new string[] { "bn" }, flag: "🇧🇩", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BD");
        /// <summary>
        /// Barbados
        /// </summary>
        public static Country BB { get; } = new Country(alpha2: "BB", alpha3: "BRB", name: "Barbados", name2: "Barbados", nativeName: "Barbados", capital: "Bridgetown", countryCode: "052", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1246 }, currency: new string[] { "BBD" }, languages: new string[] { "en" }, flag: "🇧🇧", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BB");
        /// <summary>
        /// Belarus
        /// </summary>
        public static Country BY { get; } = new Country(alpha2: "BY", alpha3: "BLR", name: "Belarus", name2: "Belarus", nativeName: "Белару́сь", capital: "Minsk", countryCode: "112", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 375 }, currency: new string[] { "BYN" }, languages: new string[] { "be", "ru" }, flag: "🇧🇾", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BY");
        /// <summary>
        /// Belgium
        /// </summary>
        public static Country BE { get; } = new Country(alpha2: "BE", alpha3: "BEL", name: "Belgium", name2: "Belgium", nativeName: "België", capital: "Brussels", countryCode: "056", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 32 }, currency: new string[] { "EUR" }, languages: new string[] { "nl", "fr", "de" }, flag: "🇧🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BE");
        /// <summary>
        /// Belize
        /// </summary>
        public static Country BZ { get; } = new Country(alpha2: "BZ", alpha3: "BLZ", name: "Belize", name2: "Belize", nativeName: "Belize", capital: "Belmopan", countryCode: "084", continent: "North America", continentAlpha2: "NA", phone: new int[] { 501 }, currency: new string[] { "BZD" }, languages: new string[] { "en", "es" }, flag: "🇧🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BZ");
        /// <summary>
        /// Benin
        /// </summary>
        public static Country BJ { get; } = new Country(alpha2: "BJ", alpha3: "BEN", name: "Benin", name2: "Benin", nativeName: "Bénin", capital: "Porto-Novo", countryCode: "204", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 229 }, currency: new string[] { "XOF" }, languages: new string[] { "fr" }, flag: "🇧🇯", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BJ");
        /// <summary>
        /// Bermuda
        /// </summary>
        public static Country BM { get; } = new Country(alpha2: "BM", alpha3: "BMU", name: "Bermuda", name2: "Bermuda", nativeName: "Bermuda", capital: "Hamilton", countryCode: "060", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1441 }, currency: new string[] { "BMD" }, languages: new string[] { "en" }, flag: "🇧🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BM");
        /// <summary>
        /// Bhutan
        /// </summary>
        public static Country BT { get; } = new Country(alpha2: "BT", alpha3: "BTN", name: "Bhutan", name2: "Bhutan", nativeName: "ʼbrug-yul", capital: "Thimphu", countryCode: "064", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 975 }, currency: new string[] { "BTN", "INR" }, languages: new string[] { "dz" }, flag: "🇧🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BT");
        /// <summary>
        /// Bolivia (Plurinational State of)
        /// </summary>
        public static Country BO { get; } = new Country(alpha2: "BO", alpha3: "BOL", name: "Bolivia (Plurinational State of)", name2: "Bolivia", nativeName: "Bolivia", capital: "Sucre", countryCode: "068", continent: "South America", continentAlpha2: "SA", phone: new int[] { 591 }, currency: new string[] { "BOB", "BOV" }, languages: new string[] { "es", "ay", "qu" }, flag: "🇧🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BO");
        /// <summary>
        /// Bonaire, Sint Eustatius and Saba
        /// </summary>
        public static Country BQ { get; } = new Country(alpha2: "BQ", alpha3: "BES", name: "Bonaire, Sint Eustatius and Saba", name2: "Bonaire", nativeName: "Bonaire", capital: "Kralendijk", countryCode: "535", continent: "North America", continentAlpha2: "NA", phone: new int[] { 5997 }, currency: new string[] { "USD" }, languages: new string[] { "nl" }, flag: "🇧🇶", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BQ");
        /// <summary>
        /// Bosnia and Herzegovina
        /// </summary>
        public static Country BA { get; } = new Country(alpha2: "BA", alpha3: "BIH", name: "Bosnia and Herzegovina", name2: "Bosnia and Herzegovina", nativeName: "Bosna i Hercegovina", capital: "Sarajevo", countryCode: "070", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 387 }, currency: new string[] { "BAM" }, languages: new string[] { "bs", "hr", "sr" }, flag: "🇧🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BA");
        /// <summary>
        /// Botswana
        /// </summary>
        public static Country BW { get; } = new Country(alpha2: "BW", alpha3: "BWA", name: "Botswana", name2: "Botswana", nativeName: "Botswana", capital: "Gaborone", countryCode: "072", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 267 }, currency: new string[] { "BWP" }, languages: new string[] { "en", "tn" }, flag: "🇧🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BW");
        /// <summary>
        /// Bouvet Island
        /// </summary>
        public static Country BV { get; } = new Country(alpha2: "BV", alpha3: "BVT", name: "Bouvet Island", name2: "Bouvet Island", nativeName: "Bouvetøya", capital: "", countryCode: "074", continent: "Antarctica", continentAlpha2: "AN", phone: new int[] { 47 }, currency: new string[] { "NOK" }, languages: new string[] { "no", "nb", "nn" }, flag: "🇧🇻", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BV");
        /// <summary>
        /// Brazil
        /// </summary>
        public static Country BR { get; } = new Country(alpha2: "BR", alpha3: "BRA", name: "Brazil", name2: "Brazil", nativeName: "Brasil", capital: "Brasília", countryCode: "076", continent: "South America", continentAlpha2: "SA", phone: new int[] { 55 }, currency: new string[] { "BRL" }, languages: new string[] { "pt" }, flag: "🇧🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BR");
        /// <summary>
        /// British Indian Ocean Territory
        /// </summary>
        public static Country IO { get; } = new Country(alpha2: "IO", alpha3: "IOT", name: "British Indian Ocean Territory", name2: "British Indian Ocean Territory", nativeName: "British Indian Ocean Territory", capital: "Diego Garcia", countryCode: "086", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 246 }, currency: new string[] { "USD" }, languages: new string[] { "en" }, flag: "🇮🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:IO");
        /// <summary>
        /// Brunei Darussalam
        /// </summary>
        public static Country BN { get; } = new Country(alpha2: "BN", alpha3: "BRN", name: "Brunei Darussalam", name2: "Brunei", nativeName: "Negara Brunei Darussalam", capital: "Bandar Seri Begawan", countryCode: "096", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 673 }, currency: new string[] { "BND" }, languages: new string[] { "ms" }, flag: "🇧🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BN");
        /// <summary>
        /// Bulgaria
        /// </summary>
        public static Country BG { get; } = new Country(alpha2: "BG", alpha3: "BGR", name: "Bulgaria", name2: "Bulgaria", nativeName: "България", capital: "Sofia", countryCode: "100", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 359 }, currency: new string[] { "BGN" }, languages: new string[] { "bg" }, flag: "🇧🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BG");
        /// <summary>
        /// Burkina Faso
        /// </summary>
        public static Country BF { get; } = new Country(alpha2: "BF", alpha3: "BFA", name: "Burkina Faso", name2: "Burkina Faso", nativeName: "Burkina Faso", capital: "Ouagadougou", countryCode: "854", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 226 }, currency: new string[] { "XOF" }, languages: new string[] { "fr", "ff" }, flag: "🇧🇫", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BF");
        /// <summary>
        /// Burundi
        /// </summary>
        public static Country BI { get; } = new Country(alpha2: "BI", alpha3: "BDI", name: "Burundi", name2: "Burundi", nativeName: "Burundi", capital: "Bujumbura", countryCode: "108", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 257 }, currency: new string[] { "BIF" }, languages: new string[] { "fr", "rn" }, flag: "🇧🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BI");
        /// <summary>
        /// Cabo Verde
        /// </summary>
        public static Country CV { get; } = new Country(alpha2: "CV", alpha3: "CPV", name: "Cabo Verde", name2: "Cape Verde", nativeName: "Cabo Verde", capital: "Praia", countryCode: "132", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 238 }, currency: new string[] { "CVE" }, languages: new string[] { "pt" }, flag: "🇨🇻", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CV");
        /// <summary>
        /// Cambodia
        /// </summary>
        public static Country KH { get; } = new Country(alpha2: "KH", alpha3: "KHM", name: "Cambodia", name2: "Cambodia", nativeName: "Kâmpŭchéa", capital: "Phnom Penh", countryCode: "116", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 855 }, currency: new string[] { "KHR" }, languages: new string[] { "km" }, flag: "🇰🇭", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KH");
        /// <summary>
        /// Cameroon
        /// </summary>
        public static Country CM { get; } = new Country(alpha2: "CM", alpha3: "CMR", name: "Cameroon", name2: "Cameroon", nativeName: "Cameroon", capital: "Yaoundé", countryCode: "120", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 237 }, currency: new string[] { "XAF" }, languages: new string[] { "en", "fr" }, flag: "🇨🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CM");
        /// <summary>
        /// Canada
        /// </summary>
        public static Country CA { get; } = new Country(alpha2: "CA", alpha3: "CAN", name: "Canada", name2: "Canada", nativeName: "Canada", capital: "Ottawa", countryCode: "124", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1 }, currency: new string[] { "CAD" }, languages: new string[] { "en", "fr" }, flag: "🇨🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CA");
        /// <summary>
        /// Cayman Islands
        /// </summary>
        public static Country KY { get; } = new Country(alpha2: "KY", alpha3: "CYM", name: "Cayman Islands", name2: "Cayman Islands", nativeName: "Cayman Islands", capital: "George Town", countryCode: "136", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1345 }, currency: new string[] { "KYD" }, languages: new string[] { "en" }, flag: "🇰🇾", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KY");
        /// <summary>
        /// Central African Republic
        /// </summary>
        public static Country CF { get; } = new Country(alpha2: "CF", alpha3: "CAF", name: "Central African Republic", name2: "Central African Republic", nativeName: "Ködörösêse tî Bêafrîka", capital: "Bangui", countryCode: "140", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 236 }, currency: new string[] { "XAF" }, languages: new string[] { "fr", "sg" }, flag: "🇨🇫", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CF");
        /// <summary>
        /// Chad
        /// </summary>
        public static Country TD { get; } = new Country(alpha2: "TD", alpha3: "TCD", name: "Chad", name2: "Chad", nativeName: "Tchad", capital: "N'Djamena", countryCode: "148", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 235 }, currency: new string[] { "XAF" }, languages: new string[] { "fr", "ar" }, flag: "🇹🇩", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TD");
        /// <summary>
        /// Chile
        /// </summary>
        public static Country CL { get; } = new Country(alpha2: "CL", alpha3: "CHL", name: "Chile", name2: "Chile", nativeName: "Chile", capital: "Santiago", countryCode: "152", continent: "South America", continentAlpha2: "SA", phone: new int[] { 56 }, currency: new string[] { "CLF", "CLP" }, languages: new string[] { "es" }, flag: "🇨🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CL");
        /// <summary>
        /// China
        /// </summary>
        public static Country CN { get; } = new Country(alpha2: "CN", alpha3: "CHN", name: "China", name2: "China", nativeName: "中国", capital: "Beijing", countryCode: "156", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 86 }, currency: new string[] { "CNY" }, languages: new string[] { "zh" }, flag: "🇨🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CN");
        /// <summary>
        /// Christmas Island
        /// </summary>
        public static Country CX { get; } = new Country(alpha2: "CX", alpha3: "CXR", name: "Christmas Island", name2: "Christmas Island", nativeName: "Christmas Island", capital: "Flying Fish Cove", countryCode: "162", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 61 }, currency: new string[] { "AUD" }, languages: new string[] { "en" }, flag: "🇨🇽", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CX");
        /// <summary>
        /// Cocos (Keeling) Islands
        /// </summary>
        public static Country CC { get; } = new Country(alpha2: "CC", alpha3: "CCK", name: "Cocos (Keeling) Islands", name2: "Cocos (Keeling) Islands", nativeName: "Cocos (Keeling) Islands", capital: "West Island", countryCode: "166", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 61 }, currency: new string[] { "AUD" }, languages: new string[] { "en" }, flag: "🇨🇨", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CC");
        /// <summary>
        /// Colombia
        /// </summary>
        public static Country CO { get; } = new Country(alpha2: "CO", alpha3: "COL", name: "Colombia", name2: "Colombia", nativeName: "Colombia", capital: "Bogotá", countryCode: "170", continent: "South America", continentAlpha2: "SA", phone: new int[] { 57 }, currency: new string[] { "COP" }, languages: new string[] { "es" }, flag: "🇨🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CO");
        /// <summary>
        /// Comoros
        /// </summary>
        public static Country KM { get; } = new Country(alpha2: "KM", alpha3: "COM", name: "Comoros", name2: "Comoros", nativeName: "Komori", capital: "Moroni", countryCode: "174", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 269 }, currency: new string[] { "KMF" }, languages: new string[] { "ar", "fr" }, flag: "🇰🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KM");
        /// <summary>
        /// Congo
        /// </summary>
        public static Country CG { get; } = new Country(alpha2: "CG", alpha3: "COG", name: "Congo", name2: "Republic of the Congo", nativeName: "République du Congo", capital: "Brazzaville", countryCode: "178", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 242 }, currency: new string[] { "XAF" }, languages: new string[] { "fr", "ln" }, flag: "🇨🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CG");
        /// <summary>
        /// Congo, Democratic Republic of the
        /// </summary>
        public static Country CD { get; } = new Country(alpha2: "CD", alpha3: "COD", name: "Congo, Democratic Republic of the", name2: "Democratic Republic of the Congo", nativeName: "République démocratique du Congo", capital: "Kinshasa", countryCode: "180", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 243 }, currency: new string[] { "CDF" }, languages: new string[] { "fr", "ln", "kg", "sw", "lu" }, flag: "🇨🇩", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CD");
        /// <summary>
        /// Cook Islands
        /// </summary>
        public static Country CK { get; } = new Country(alpha2: "CK", alpha3: "COK", name: "Cook Islands", name2: "Cook Islands", nativeName: "Cook Islands", capital: "Avarua", countryCode: "184", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 682 }, currency: new string[] { "NZD" }, languages: new string[] { "en" }, flag: "🇨🇰", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CK");
        /// <summary>
        /// Costa Rica
        /// </summary>
        public static Country CR { get; } = new Country(alpha2: "CR", alpha3: "CRI", name: "Costa Rica", name2: "Costa Rica", nativeName: "Costa Rica", capital: "San José", countryCode: "188", continent: "North America", continentAlpha2: "NA", phone: new int[] { 506 }, currency: new string[] { "CRC" }, languages: new string[] { "es" }, flag: "🇨🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CR");
        /// <summary>
        /// Côte d'Ivoire
        /// </summary>
        public static Country CI { get; } = new Country(alpha2: "CI", alpha3: "CIV", name: "Côte d'Ivoire", name2: "Ivory Coast", nativeName: "Côte d'Ivoire", capital: "Yamoussoukro", countryCode: "384", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 225 }, currency: new string[] { "XOF" }, languages: new string[] { "fr" }, flag: "🇨🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CI");
        /// <summary>
        /// Croatia
        /// </summary>
        public static Country HR { get; } = new Country(alpha2: "HR", alpha3: "HRV", name: "Croatia", name2: "Croatia", nativeName: "Hrvatska", capital: "Zagreb", countryCode: "191", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 385 }, currency: new string[] { "EUR" }, languages: new string[] { "hr" }, flag: "🇭🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:HR");
        /// <summary>
        /// Cuba
        /// </summary>
        public static Country CU { get; } = new Country(alpha2: "CU", alpha3: "CUB", name: "Cuba", name2: "Cuba", nativeName: "Cuba", capital: "Havana", countryCode: "192", continent: "North America", continentAlpha2: "NA", phone: new int[] { 53 }, currency: new string[] { "CUC", "CUP" }, languages: new string[] { "es" }, flag: "🇨🇺", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CU");
        /// <summary>
        /// Curaçao
        /// </summary>
        public static Country CW { get; } = new Country(alpha2: "CW", alpha3: "CUW", name: "Curaçao", name2: "Curacao", nativeName: "Curaçao", capital: "Willemstad", countryCode: "531", continent: "North America", continentAlpha2: "NA", phone: new int[] { 5999 }, currency: new string[] { "ANG" }, languages: new string[] { "nl", "pa", "en" }, flag: "🇨🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CW");
        /// <summary>
        /// Cyprus
        /// </summary>
        public static Country CY { get; } = new Country(alpha2: "CY", alpha3: "CYP", name: "Cyprus", name2: "Cyprus", nativeName: "Κύπρος", capital: "Nicosia", countryCode: "196", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 357 }, currency: new string[] { "EUR" }, languages: new string[] { "el", "tr", "hy" }, flag: "🇨🇾", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CY");
        /// <summary>
        /// Czechia
        /// </summary>
        public static Country CZ { get; } = new Country(alpha2: "CZ", alpha3: "CZE", name: "Czechia", name2: "Czech Republic", nativeName: "Česká republika", capital: "Prague", countryCode: "203", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 420 }, currency: new string[] { "CZK" }, languages: new string[] { "cs" }, flag: "🇨🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CZ");
        /// <summary>
        /// Denmark
        /// </summary>
        public static Country DK { get; } = new Country(alpha2: "DK", alpha3: "DNK", name: "Denmark", name2: "Denmark", nativeName: "Danmark", capital: "Copenhagen", countryCode: "208", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 45 }, currency: new string[] { "DKK" }, languages: new string[] { "da" }, flag: "🇩🇰", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:DK");
        /// <summary>
        /// Djibouti
        /// </summary>
        public static Country DJ { get; } = new Country(alpha2: "DJ", alpha3: "DJI", name: "Djibouti", name2: "Djibouti", nativeName: "Djibouti", capital: "Djibouti", countryCode: "262", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 253 }, currency: new string[] { "DJF" }, languages: new string[] { "fr", "ar" }, flag: "🇩🇯", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:DJ");
        /// <summary>
        /// Dominica
        /// </summary>
        public static Country DM { get; } = new Country(alpha2: "DM", alpha3: "DMA", name: "Dominica", name2: "Dominica", nativeName: "Dominica", capital: "Roseau", countryCode: "212", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1767 }, currency: new string[] { "XCD" }, languages: new string[] { "en" }, flag: "🇩🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:DM");
        /// <summary>
        /// Dominican Republic
        /// </summary>
        public static Country DO { get; } = new Country(alpha2: "DO", alpha3: "DOM", name: "Dominican Republic", name2: "Dominican Republic", nativeName: "República Dominicana", capital: "Santo Domingo", countryCode: "214", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1809, 1829, 1849 }, currency: new string[] { "DOP" }, languages: new string[] { "es" }, flag: "🇩🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:DO");
        /// <summary>
        /// Ecuador
        /// </summary>
        public static Country EC { get; } = new Country(alpha2: "EC", alpha3: "ECU", name: "Ecuador", name2: "Ecuador", nativeName: "Ecuador", capital: "Quito", countryCode: "218", continent: "South America", continentAlpha2: "SA", phone: new int[] { 593 }, currency: new string[] { "USD" }, languages: new string[] { "es" }, flag: "🇪🇨", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:EC");
        /// <summary>
        /// Egypt
        /// </summary>
        public static Country EG { get; } = new Country(alpha2: "EG", alpha3: "EGY", name: "Egypt", name2: "Egypt", nativeName: "مصر‎", capital: "Cairo", countryCode: "818", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 20 }, currency: new string[] { "EGP" }, languages: new string[] { "ar" }, flag: "🇪🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:EG");
        /// <summary>
        /// El Salvador
        /// </summary>
        public static Country SV { get; } = new Country(alpha2: "SV", alpha3: "SLV", name: "El Salvador", name2: "El Salvador", nativeName: "El Salvador", capital: "San Salvador", countryCode: "222", continent: "North America", continentAlpha2: "NA", phone: new int[] { 503 }, currency: new string[] { "SVC", "USD" }, languages: new string[] { "es" }, flag: "🇸🇻", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SV");
        /// <summary>
        /// Equatorial Guinea
        /// </summary>
        public static Country GQ { get; } = new Country(alpha2: "GQ", alpha3: "GNQ", name: "Equatorial Guinea", name2: "Equatorial Guinea", nativeName: "Guinea Ecuatorial", capital: "Malabo", countryCode: "226", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 240 }, currency: new string[] { "XAF" }, languages: new string[] { "es", "fr" }, flag: "🇬🇶", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GQ");
        /// <summary>
        /// Eritrea
        /// </summary>
        public static Country ER { get; } = new Country(alpha2: "ER", alpha3: "ERI", name: "Eritrea", name2: "Eritrea", nativeName: "ኤርትራ", capital: "Asmara", countryCode: "232", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 291 }, currency: new string[] { "ERN" }, languages: new string[] { "ti", "ar", "en" }, flag: "🇪🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ER");
        /// <summary>
        /// Estonia
        /// </summary>
        public static Country EE { get; } = new Country(alpha2: "EE", alpha3: "EST", name: "Estonia", name2: "Estonia", nativeName: "Eesti", capital: "Tallinn", countryCode: "233", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 372 }, currency: new string[] { "EUR" }, languages: new string[] { "et" }, flag: "🇪🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:EE");
        /// <summary>
        /// Eswatini
        /// </summary>
        public static Country SZ { get; } = new Country(alpha2: "SZ", alpha3: "SWZ", name: "Eswatini", name2: "Eswatini", nativeName: "Eswatini", capital: "Lobamba", countryCode: "748", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 268 }, currency: new string[] { "SZL" }, languages: new string[] { "en", "ss" }, flag: "🇸🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SZ");
        /// <summary>
        /// Ethiopia
        /// </summary>
        public static Country ET { get; } = new Country(alpha2: "ET", alpha3: "ETH", name: "Ethiopia", name2: "Ethiopia", nativeName: "ኢትዮጵያ", capital: "Addis Ababa", countryCode: "231", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 251 }, currency: new string[] { "ETB" }, languages: new string[] { "am" }, flag: "🇪🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ET");
        /// <summary>
        /// Falkland Islands (Malvinas)
        /// </summary>
        public static Country FK { get; } = new Country(alpha2: "FK", alpha3: "FLK", name: "Falkland Islands (Malvinas)", name2: "Falkland Islands", nativeName: "Falkland Islands", capital: "Stanley", countryCode: "238", continent: "South America", continentAlpha2: "SA", phone: new int[] { 500 }, currency: new string[] { "FKP" }, languages: new string[] { "en" }, flag: "🇫🇰", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:FK");
        /// <summary>
        /// Faroe Islands
        /// </summary>
        public static Country FO { get; } = new Country(alpha2: "FO", alpha3: "FRO", name: "Faroe Islands", name2: "Faroe Islands", nativeName: "Føroyar", capital: "Tórshavn", countryCode: "234", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 298 }, currency: new string[] { "DKK" }, languages: new string[] { "fo" }, flag: "🇫🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:FO");
        /// <summary>
        /// Fiji
        /// </summary>
        public static Country FJ { get; } = new Country(alpha2: "FJ", alpha3: "FJI", name: "Fiji", name2: "Fiji", nativeName: "Fiji", capital: "Suva", countryCode: "242", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 679 }, currency: new string[] { "FJD" }, languages: new string[] { "en", "fj", "hi", "ur" }, flag: "🇫🇯", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:FJ");
        /// <summary>
        /// Finland
        /// </summary>
        public static Country FI { get; } = new Country(alpha2: "FI", alpha3: "FIN", name: "Finland", name2: "Finland", nativeName: "Suomi", capital: "Helsinki", countryCode: "246", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 358 }, currency: new string[] { "EUR" }, languages: new string[] { "fi", "sv" }, flag: "🇫🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:FI");
        /// <summary>
        /// France
        /// </summary>
        public static Country FR { get; } = new Country(alpha2: "FR", alpha3: "FRA", name: "France", name2: "France", nativeName: "France", capital: "Paris", countryCode: "250", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 33 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇫🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:FR");
        /// <summary>
        /// French Guiana
        /// </summary>
        public static Country GF { get; } = new Country(alpha2: "GF", alpha3: "GUF", name: "French Guiana", name2: "French Guiana", nativeName: "Guyane française", capital: "Cayenne", countryCode: "254", continent: "South America", continentAlpha2: "SA", phone: new int[] { 594 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇬🇫", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GF");
        /// <summary>
        /// French Polynesia
        /// </summary>
        public static Country PF { get; } = new Country(alpha2: "PF", alpha3: "PYF", name: "French Polynesia", name2: "French Polynesia", nativeName: "Polynésie française", capital: "Papeetē", countryCode: "258", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 689 }, currency: new string[] { "XPF" }, languages: new string[] { "fr" }, flag: "🇵🇫", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PF");
        /// <summary>
        /// French Southern Territories
        /// </summary>
        public static Country TF { get; } = new Country(alpha2: "TF", alpha3: "ATF", name: "French Southern Territories", name2: "French Southern Territories", nativeName: "Territoire des Terres australes et antarctiques fr", capital: "Port-aux-Français", countryCode: "260", continent: "Antarctica", continentAlpha2: "AN", phone: new int[] { 262 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇹🇫", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TF");
        /// <summary>
        /// Gabon
        /// </summary>
        public static Country GA { get; } = new Country(alpha2: "GA", alpha3: "GAB", name: "Gabon", name2: "Gabon", nativeName: "Gabon", capital: "Libreville", countryCode: "266", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 241 }, currency: new string[] { "XAF" }, languages: new string[] { "fr" }, flag: "🇬🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GA");
        /// <summary>
        /// Gambia
        /// </summary>
        public static Country GM { get; } = new Country(alpha2: "GM", alpha3: "GMB", name: "Gambia", name2: "Gambia", nativeName: "Gambia", capital: "Banjul", countryCode: "270", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 220 }, currency: new string[] { "GMD" }, languages: new string[] { "en" }, flag: "🇬🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GM");
        /// <summary>
        /// Georgia
        /// </summary>
        public static Country GE { get; } = new Country(alpha2: "GE", alpha3: "GEO", name: "Georgia", name2: "Georgia", nativeName: "საქართველო", capital: "Tbilisi", countryCode: "268", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 995 }, currency: new string[] { "GEL" }, languages: new string[] { "ka" }, flag: "🇬🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GE");
        /// <summary>
        /// Germany
        /// </summary>
        public static Country DE { get; } = new Country(alpha2: "DE", alpha3: "DEU", name: "Germany", name2: "Germany", nativeName: "Deutschland", capital: "Berlin", countryCode: "276", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 49 }, currency: new string[] { "EUR" }, languages: new string[] { "de" }, flag: "🇩🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:DE");
        /// <summary>
        /// Ghana
        /// </summary>
        public static Country GH { get; } = new Country(alpha2: "GH", alpha3: "GHA", name: "Ghana", name2: "Ghana", nativeName: "Ghana", capital: "Accra", countryCode: "288", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 233 }, currency: new string[] { "GHS" }, languages: new string[] { "en" }, flag: "🇬🇭", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GH");
        /// <summary>
        /// Gibraltar
        /// </summary>
        public static Country GI { get; } = new Country(alpha2: "GI", alpha3: "GIB", name: "Gibraltar", name2: "Gibraltar", nativeName: "Gibraltar", capital: "Gibraltar", countryCode: "292", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 350 }, currency: new string[] { "GIP" }, languages: new string[] { "en" }, flag: "🇬🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GI");
        /// <summary>
        /// Greece
        /// </summary>
        public static Country GR { get; } = new Country(alpha2: "GR", alpha3: "GRC", name: "Greece", name2: "Greece", nativeName: "Ελλάδα", capital: "Athens", countryCode: "300", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 30 }, currency: new string[] { "EUR" }, languages: new string[] { "el" }, flag: "🇬🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GR");
        /// <summary>
        /// Greenland
        /// </summary>
        public static Country GL { get; } = new Country(alpha2: "GL", alpha3: "GRL", name: "Greenland", name2: "Greenland", nativeName: "Kalaallit Nunaat", capital: "Nuuk", countryCode: "304", continent: "North America", continentAlpha2: "NA", phone: new int[] { 299 }, currency: new string[] { "DKK" }, languages: new string[] { "kl" }, flag: "🇬🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GL");
        /// <summary>
        /// Grenada
        /// </summary>
        public static Country GD { get; } = new Country(alpha2: "GD", alpha3: "GRD", name: "Grenada", name2: "Grenada", nativeName: "Grenada", capital: "St. George's", countryCode: "308", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1473 }, currency: new string[] { "XCD" }, languages: new string[] { "en" }, flag: "🇬🇩", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GD");
        /// <summary>
        /// Guadeloupe
        /// </summary>
        public static Country GP { get; } = new Country(alpha2: "GP", alpha3: "GLP", name: "Guadeloupe", name2: "Guadeloupe", nativeName: "Guadeloupe", capital: "Basse-Terre", countryCode: "312", continent: "North America", continentAlpha2: "NA", phone: new int[] { 590 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇬🇵", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GP");
        /// <summary>
        /// Guam
        /// </summary>
        public static Country GU { get; } = new Country(alpha2: "GU", alpha3: "GUM", name: "Guam", name2: "Guam", nativeName: "Guam", capital: "Hagåtña", countryCode: "316", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 1671 }, currency: new string[] { "USD" }, languages: new string[] { "en", "ch", "es" }, flag: "🇬🇺", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GU");
        /// <summary>
        /// Guatemala
        /// </summary>
        public static Country GT { get; } = new Country(alpha2: "GT", alpha3: "GTM", name: "Guatemala", name2: "Guatemala", nativeName: "Guatemala", capital: "Guatemala City", countryCode: "320", continent: "North America", continentAlpha2: "NA", phone: new int[] { 502 }, currency: new string[] { "GTQ" }, languages: new string[] { "es" }, flag: "🇬🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GT");
        /// <summary>
        /// Guernsey
        /// </summary>
        public static Country GG { get; } = new Country(alpha2: "GG", alpha3: "GGY", name: "Guernsey", name2: "Guernsey", nativeName: "Guernsey", capital: "St. Peter Port", countryCode: "831", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 44 }, currency: new string[] { "GBP" }, languages: new string[] { "en", "fr" }, flag: "🇬🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GG");
        /// <summary>
        /// Guinea
        /// </summary>
        public static Country GN { get; } = new Country(alpha2: "GN", alpha3: "GIN", name: "Guinea", name2: "Guinea", nativeName: "Guinée", capital: "Conakry", countryCode: "324", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 224 }, currency: new string[] { "GNF" }, languages: new string[] { "fr", "ff" }, flag: "🇬🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GN");
        /// <summary>
        /// Guinea-Bissau
        /// </summary>
        public static Country GW { get; } = new Country(alpha2: "GW", alpha3: "GNB", name: "Guinea-Bissau", name2: "Guinea-Bissau", nativeName: "Guiné-Bissau", capital: "Bissau", countryCode: "624", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 245 }, currency: new string[] { "XOF" }, languages: new string[] { "pt" }, flag: "🇬🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GW");
        /// <summary>
        /// Guyana
        /// </summary>
        public static Country GY { get; } = new Country(alpha2: "GY", alpha3: "GUY", name: "Guyana", name2: "Guyana", nativeName: "Guyana", capital: "Georgetown", countryCode: "328", continent: "South America", continentAlpha2: "SA", phone: new int[] { 592 }, currency: new string[] { "GYD" }, languages: new string[] { "en" }, flag: "🇬🇾", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GY");
        /// <summary>
        /// Haiti
        /// </summary>
        public static Country HT { get; } = new Country(alpha2: "HT", alpha3: "HTI", name: "Haiti", name2: "Haiti", nativeName: "Haïti", capital: "Port-au-Prince", countryCode: "332", continent: "North America", continentAlpha2: "NA", phone: new int[] { 509 }, currency: new string[] { "HTG", "USD" }, languages: new string[] { "fr", "ht" }, flag: "🇭🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:HT");
        /// <summary>
        /// Heard Island and McDonald Islands
        /// </summary>
        public static Country HM { get; } = new Country(alpha2: "HM", alpha3: "HMD", name: "Heard Island and McDonald Islands", name2: "Heard Island and McDonald Islands", nativeName: "Heard Island and McDonald Islands", capital: "", countryCode: "334", continent: "Antarctica", continentAlpha2: "AN", phone: new int[] { 61 }, currency: new string[] { "AUD" }, languages: new string[] { "en" }, flag: "🇭🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:HM");
        /// <summary>
        /// Holy See
        /// </summary>
        public static Country VA { get; } = new Country(alpha2: "VA", alpha3: "VAT", name: "Holy See", name2: "Vatican City", nativeName: "Vaticano", capital: "Vatican City", countryCode: "336", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 379 }, currency: new string[] { "EUR" }, languages: new string[] { "it", "la" }, flag: "🇻🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:VA");
        /// <summary>
        /// Honduras
        /// </summary>
        public static Country HN { get; } = new Country(alpha2: "HN", alpha3: "HND", name: "Honduras", name2: "Honduras", nativeName: "Honduras", capital: "Tegucigalpa", countryCode: "340", continent: "North America", continentAlpha2: "NA", phone: new int[] { 504 }, currency: new string[] { "HNL" }, languages: new string[] { "es" }, flag: "🇭🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:HN");
        /// <summary>
        /// Hong Kong
        /// </summary>
        public static Country HK { get; } = new Country(alpha2: "HK", alpha3: "HKG", name: "Hong Kong", name2: "Hong Kong", nativeName: "香港", capital: "City of Victoria", countryCode: "344", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 852 }, currency: new string[] { "HKD" }, languages: new string[] { "zh", "en" }, flag: "🇭🇰", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:HK");
        /// <summary>
        /// Hungary
        /// </summary>
        public static Country HU { get; } = new Country(alpha2: "HU", alpha3: "HUN", name: "Hungary", name2: "Hungary", nativeName: "Magyarország", capital: "Budapest", countryCode: "348", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 36 }, currency: new string[] { "HUF" }, languages: new string[] { "hu" }, flag: "🇭🇺", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:HU");
        /// <summary>
        /// Iceland
        /// </summary>
        public static Country IS { get; } = new Country(alpha2: "IS", alpha3: "ISL", name: "Iceland", name2: "Iceland", nativeName: "Ísland", capital: "Reykjavik", countryCode: "352", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 354 }, currency: new string[] { "ISK" }, languages: new string[] { "is" }, flag: "🇮🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:IS");
        /// <summary>
        /// India
        /// </summary>
        public static Country IN { get; } = new Country(alpha2: "IN", alpha3: "IND", name: "India", name2: "India", nativeName: "भारत", capital: "New Delhi", countryCode: "356", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 91 }, currency: new string[] { "INR" }, languages: new string[] { "hi", "en" }, flag: "🇮🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:IN");
        /// <summary>
        /// Indonesia
        /// </summary>
        public static Country ID { get; } = new Country(alpha2: "ID", alpha3: "IDN", name: "Indonesia", name2: "Indonesia", nativeName: "Indonesia", capital: "Jakarta", countryCode: "360", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 62 }, currency: new string[] { "IDR" }, languages: new string[] { "id" }, flag: "🇮🇩", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ID");
        /// <summary>
        /// Iran (Islamic Republic of)
        /// </summary>
        public static Country IR { get; } = new Country(alpha2: "IR", alpha3: "IRN", name: "Iran (Islamic Republic of)", name2: "Iran", nativeName: "ایران", capital: "Tehran", countryCode: "364", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 98 }, currency: new string[] { "IRR" }, languages: new string[] { "fa" }, flag: "🇮🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:IR");
        /// <summary>
        /// Iraq
        /// </summary>
        public static Country IQ { get; } = new Country(alpha2: "IQ", alpha3: "IRQ", name: "Iraq", name2: "Iraq", nativeName: "العراق", capital: "Baghdad", countryCode: "368", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 964 }, currency: new string[] { "IQD" }, languages: new string[] { "ar", "ku" }, flag: "🇮🇶", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:IQ");
        /// <summary>
        /// Ireland
        /// </summary>
        public static Country IE { get; } = new Country(alpha2: "IE", alpha3: "IRL", name: "Ireland", name2: "Ireland", nativeName: "Éire", capital: "Dublin", countryCode: "372", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 353 }, currency: new string[] { "EUR" }, languages: new string[] { "ga", "en" }, flag: "🇮🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:IE");
        /// <summary>
        /// Isle of Man
        /// </summary>
        public static Country IM { get; } = new Country(alpha2: "IM", alpha3: "IMN", name: "Isle of Man", name2: "Isle of Man", nativeName: "Isle of Man", capital: "Douglas", countryCode: "833", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 44 }, currency: new string[] { "GBP" }, languages: new string[] { "en", "gv" }, flag: "🇮🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:IM");
        /// <summary>
        /// Israel
        /// </summary>
        public static Country IL { get; } = new Country(alpha2: "IL", alpha3: "ISR", name: "Israel", name2: "Israel", nativeName: "יִשְׂרָאֵל", capital: "Jerusalem", countryCode: "376", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 972 }, currency: new string[] { "ILS" }, languages: new string[] { "he", "ar" }, flag: "🇮🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:IL");
        /// <summary>
        /// Italy
        /// </summary>
        public static Country IT { get; } = new Country(alpha2: "IT", alpha3: "ITA", name: "Italy", name2: "Italy", nativeName: "Italia", capital: "Rome", countryCode: "380", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 39 }, currency: new string[] { "EUR" }, languages: new string[] { "it" }, flag: "🇮🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:IT");
        /// <summary>
        /// Jamaica
        /// </summary>
        public static Country JM { get; } = new Country(alpha2: "JM", alpha3: "JAM", name: "Jamaica", name2: "Jamaica", nativeName: "Jamaica", capital: "Kingston", countryCode: "388", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1876 }, currency: new string[] { "JMD" }, languages: new string[] { "en" }, flag: "🇯🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:JM");
        /// <summary>
        /// Japan
        /// </summary>
        public static Country JP { get; } = new Country(alpha2: "JP", alpha3: "JPN", name: "Japan", name2: "Japan", nativeName: "日本", capital: "Tokyo", countryCode: "392", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 81 }, currency: new string[] { "JPY" }, languages: new string[] { "ja" }, flag: "🇯🇵", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:JP");
        /// <summary>
        /// Jersey
        /// </summary>
        public static Country JE { get; } = new Country(alpha2: "JE", alpha3: "JEY", name: "Jersey", name2: "Jersey", nativeName: "Jersey", capital: "Saint Helier", countryCode: "832", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 44 }, currency: new string[] { "GBP" }, languages: new string[] { "en", "fr" }, flag: "🇯🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:JE");
        /// <summary>
        /// Jordan
        /// </summary>
        public static Country JO { get; } = new Country(alpha2: "JO", alpha3: "JOR", name: "Jordan", name2: "Jordan", nativeName: "الأردن", capital: "Amman", countryCode: "400", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 962 }, currency: new string[] { "JOD" }, languages: new string[] { "ar" }, flag: "🇯🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:JO");
        /// <summary>
        /// Kazakhstan
        /// </summary>
        public static Country KZ { get; } = new Country(alpha2: "KZ", alpha3: "KAZ", name: "Kazakhstan", name2: "Kazakhstan", nativeName: "Қазақстан", capital: "Astana", countryCode: "398", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 76, 77 }, currency: new string[] { "KZT" }, languages: new string[] { "kk", "ru" }, flag: "🇰🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KZ");
        /// <summary>
        /// Kenya
        /// </summary>
        public static Country KE { get; } = new Country(alpha2: "KE", alpha3: "KEN", name: "Kenya", name2: "Kenya", nativeName: "Kenya", capital: "Nairobi", countryCode: "404", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 254 }, currency: new string[] { "KES" }, languages: new string[] { "en", "sw" }, flag: "🇰🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KE");
        /// <summary>
        /// Kiribati
        /// </summary>
        public static Country KI { get; } = new Country(alpha2: "KI", alpha3: "KIR", name: "Kiribati", name2: "Kiribati", nativeName: "Kiribati", capital: "South Tarawa", countryCode: "296", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 686 }, currency: new string[] { "AUD" }, languages: new string[] { "en" }, flag: "🇰🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KI");
        /// <summary>
        /// Korea (Democratic People's Republic of)
        /// </summary>
        public static Country KP { get; } = new Country(alpha2: "KP", alpha3: "PRK", name: "Korea (Democratic People's Republic of)", name2: "North Korea", nativeName: "북한", capital: "Pyongyang", countryCode: "408", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 850 }, currency: new string[] { "KPW" }, languages: new string[] { "ko" }, flag: "🇰🇵", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KP");
        /// <summary>
        /// Korea, Republic of
        /// </summary>
        public static Country KR { get; } = new Country(alpha2: "KR", alpha3: "KOR", name: "Korea, Republic of", name2: "South Korea", nativeName: "대한민국", capital: "Seoul", countryCode: "410", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 82 }, currency: new string[] { "KRW" }, languages: new string[] { "ko" }, flag: "🇰🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KR");
        /// <summary>
        /// Kuwait
        /// </summary>
        public static Country KW { get; } = new Country(alpha2: "KW", alpha3: "KWT", name: "Kuwait", name2: "Kuwait", nativeName: "الكويت", capital: "Kuwait City", countryCode: "414", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 965 }, currency: new string[] { "KWD" }, languages: new string[] { "ar" }, flag: "🇰🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KW");
        /// <summary>
        /// Kyrgyzstan
        /// </summary>
        public static Country KG { get; } = new Country(alpha2: "KG", alpha3: "KGZ", name: "Kyrgyzstan", name2: "Kyrgyzstan", nativeName: "Кыргызстан", capital: "Bishkek", countryCode: "417", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 996 }, currency: new string[] { "KGS" }, languages: new string[] { "ky", "ru" }, flag: "🇰🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KG");
        /// <summary>
        /// Lao People's Democratic Republic
        /// </summary>
        public static Country LA { get; } = new Country(alpha2: "LA", alpha3: "LAO", name: "Lao People's Democratic Republic", name2: "Laos", nativeName: "ສປປລາວ", capital: "Vientiane", countryCode: "418", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 856 }, currency: new string[] { "LAK" }, languages: new string[] { "lo" }, flag: "🇱🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LA");
        /// <summary>
        /// Latvia
        /// </summary>
        public static Country LV { get; } = new Country(alpha2: "LV", alpha3: "LVA", name: "Latvia", name2: "Latvia", nativeName: "Latvija", capital: "Riga", countryCode: "428", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 371 }, currency: new string[] { "EUR" }, languages: new string[] { "lv" }, flag: "🇱🇻", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LV");
        /// <summary>
        /// Lebanon
        /// </summary>
        public static Country LB { get; } = new Country(alpha2: "LB", alpha3: "LBN", name: "Lebanon", name2: "Lebanon", nativeName: "لبنان", capital: "Beirut", countryCode: "422", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 961 }, currency: new string[] { "LBP" }, languages: new string[] { "ar", "fr" }, flag: "🇱🇧", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LB");
        /// <summary>
        /// Lesotho
        /// </summary>
        public static Country LS { get; } = new Country(alpha2: "LS", alpha3: "LSO", name: "Lesotho", name2: "Lesotho", nativeName: "Lesotho", capital: "Maseru", countryCode: "426", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 266 }, currency: new string[] { "LSL", "ZAR" }, languages: new string[] { "en", "st" }, flag: "🇱🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LS");
        /// <summary>
        /// Liberia
        /// </summary>
        public static Country LR { get; } = new Country(alpha2: "LR", alpha3: "LBR", name: "Liberia", name2: "Liberia", nativeName: "Liberia", capital: "Monrovia", countryCode: "430", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 231 }, currency: new string[] { "LRD" }, languages: new string[] { "en" }, flag: "🇱🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LR");
        /// <summary>
        /// Libya
        /// </summary>
        public static Country LY { get; } = new Country(alpha2: "LY", alpha3: "LBY", name: "Libya", name2: "Libya", nativeName: "‏ليبيا", capital: "Tripoli", countryCode: "434", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 218 }, currency: new string[] { "LYD" }, languages: new string[] { "ar" }, flag: "🇱🇾", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LY");
        /// <summary>
        /// Liechtenstein
        /// </summary>
        public static Country LI { get; } = new Country(alpha2: "LI", alpha3: "LIE", name: "Liechtenstein", name2: "Liechtenstein", nativeName: "Liechtenstein", capital: "Vaduz", countryCode: "438", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 423 }, currency: new string[] { "CHF" }, languages: new string[] { "de" }, flag: "🇱🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LI");
        /// <summary>
        /// Lithuania
        /// </summary>
        public static Country LT { get; } = new Country(alpha2: "LT", alpha3: "LTU", name: "Lithuania", name2: "Lithuania", nativeName: "Lietuva", capital: "Vilnius", countryCode: "440", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 370 }, currency: new string[] { "EUR" }, languages: new string[] { "lt" }, flag: "🇱🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LT");
        /// <summary>
        /// Luxembourg
        /// </summary>
        public static Country LU { get; } = new Country(alpha2: "LU", alpha3: "LUX", name: "Luxembourg", name2: "Luxembourg", nativeName: "Luxembourg", capital: "Luxembourg", countryCode: "442", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 352 }, currency: new string[] { "EUR" }, languages: new string[] { "fr", "de", "lb" }, flag: "🇱🇺", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LU");
        /// <summary>
        /// Macao
        /// </summary>
        public static Country MO { get; } = new Country(alpha2: "MO", alpha3: "MAC", name: "Macao", name2: "Macao", nativeName: "澳門", capital: "", countryCode: "446", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 853 }, currency: new string[] { "MOP" }, languages: new string[] { "zh", "pt" }, flag: "🇲🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MO");
        /// <summary>
        /// Madagascar
        /// </summary>
        public static Country MG { get; } = new Country(alpha2: "MG", alpha3: "MDG", name: "Madagascar", name2: "Madagascar", nativeName: "Madagasikara", capital: "Antananarivo", countryCode: "450", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 261 }, currency: new string[] { "MGA" }, languages: new string[] { "fr", "mg" }, flag: "🇲🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MG");
        /// <summary>
        /// Malawi
        /// </summary>
        public static Country MW { get; } = new Country(alpha2: "MW", alpha3: "MWI", name: "Malawi", name2: "Malawi", nativeName: "Malawi", capital: "Lilongwe", countryCode: "454", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 265 }, currency: new string[] { "MWK" }, languages: new string[] { "en", "ny" }, flag: "🇲🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MW");
        /// <summary>
        /// Malaysia
        /// </summary>
        public static Country MY { get; } = new Country(alpha2: "MY", alpha3: "MYS", name: "Malaysia", name2: "Malaysia", nativeName: "Malaysia", capital: "Kuala Lumpur", countryCode: "458", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 60 }, currency: new string[] { "MYR" }, languages: new string[] { "ms" }, flag: "🇲🇾", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MY");
        /// <summary>
        /// Maldives
        /// </summary>
        public static Country MV { get; } = new Country(alpha2: "MV", alpha3: "MDV", name: "Maldives", name2: "Maldives", nativeName: "Maldives", capital: "Malé", countryCode: "462", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 960 }, currency: new string[] { "MVR" }, languages: new string[] { "dv" }, flag: "🇲🇻", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MV");
        /// <summary>
        /// Mali
        /// </summary>
        public static Country ML { get; } = new Country(alpha2: "ML", alpha3: "MLI", name: "Mali", name2: "Mali", nativeName: "Mali", capital: "Bamako", countryCode: "466", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 223 }, currency: new string[] { "XOF" }, languages: new string[] { "fr" }, flag: "🇲🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ML");
        /// <summary>
        /// Malta
        /// </summary>
        public static Country MT { get; } = new Country(alpha2: "MT", alpha3: "MLT", name: "Malta", name2: "Malta", nativeName: "Malta", capital: "Valletta", countryCode: "470", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 356 }, currency: new string[] { "EUR" }, languages: new string[] { "mt", "en" }, flag: "🇲🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MT");
        /// <summary>
        /// Marshall Islands
        /// </summary>
        public static Country MH { get; } = new Country(alpha2: "MH", alpha3: "MHL", name: "Marshall Islands", name2: "Marshall Islands", nativeName: "M̧ajeļ", capital: "Majuro", countryCode: "584", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 692 }, currency: new string[] { "USD" }, languages: new string[] { "en", "mh" }, flag: "🇲🇭", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MH");
        /// <summary>
        /// Martinique
        /// </summary>
        public static Country MQ { get; } = new Country(alpha2: "MQ", alpha3: "MTQ", name: "Martinique", name2: "Martinique", nativeName: "Martinique", capital: "Fort-de-France", countryCode: "474", continent: "North America", continentAlpha2: "NA", phone: new int[] { 596 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇲🇶", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MQ");
        /// <summary>
        /// Mauritania
        /// </summary>
        public static Country MR { get; } = new Country(alpha2: "MR", alpha3: "MRT", name: "Mauritania", name2: "Mauritania", nativeName: "موريتانيا", capital: "Nouakchott", countryCode: "478", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 222 }, currency: new string[] { "MRU" }, languages: new string[] { "ar" }, flag: "🇲🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MR");
        /// <summary>
        /// Mauritius
        /// </summary>
        public static Country MU { get; } = new Country(alpha2: "MU", alpha3: "MUS", name: "Mauritius", name2: "Mauritius", nativeName: "Maurice", capital: "Port Louis", countryCode: "480", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 230 }, currency: new string[] { "MUR" }, languages: new string[] { "en" }, flag: "🇲🇺", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MU");
        /// <summary>
        /// Mayotte
        /// </summary>
        public static Country YT { get; } = new Country(alpha2: "YT", alpha3: "MYT", name: "Mayotte", name2: "Mayotte", nativeName: "Mayotte", capital: "Mamoudzou", countryCode: "175", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 262 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇾🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:YT");
        /// <summary>
        /// Mexico
        /// </summary>
        public static Country MX { get; } = new Country(alpha2: "MX", alpha3: "MEX", name: "Mexico", name2: "Mexico", nativeName: "México", capital: "Mexico City", countryCode: "484", continent: "North America", continentAlpha2: "NA", phone: new int[] { 52 }, currency: new string[] { "MXN" }, languages: new string[] { "es" }, flag: "🇲🇽", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MX");
        /// <summary>
        /// Micronesia (Federated States of)
        /// </summary>
        public static Country FM { get; } = new Country(alpha2: "FM", alpha3: "FSM", name: "Micronesia (Federated States of)", name2: "Micronesia", nativeName: "Micronesia", capital: "Palikir", countryCode: "583", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 691 }, currency: new string[] { "USD" }, languages: new string[] { "en" }, flag: "🇫🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:FM");
        /// <summary>
        /// Moldova, Republic of
        /// </summary>
        public static Country MD { get; } = new Country(alpha2: "MD", alpha3: "MDA", name: "Moldova, Republic of", name2: "Moldova", nativeName: "Moldova", capital: "Chișinău", countryCode: "498", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 373 }, currency: new string[] { "MDL" }, languages: new string[] { "ro" }, flag: "🇲🇩", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MD");
        /// <summary>
        /// Monaco
        /// </summary>
        public static Country MC { get; } = new Country(alpha2: "MC", alpha3: "MCO", name: "Monaco", name2: "Monaco", nativeName: "Monaco", capital: "Monaco", countryCode: "492", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 377 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇲🇨", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MC");
        /// <summary>
        /// Mongolia
        /// </summary>
        public static Country MN { get; } = new Country(alpha2: "MN", alpha3: "MNG", name: "Mongolia", name2: "Mongolia", nativeName: "Монгол улс", capital: "Ulan Bator", countryCode: "496", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 976 }, currency: new string[] { "MNT" }, languages: new string[] { "mn" }, flag: "🇲🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MN");
        /// <summary>
        /// Montenegro
        /// </summary>
        public static Country ME { get; } = new Country(alpha2: "ME", alpha3: "MNE", name: "Montenegro", name2: "Montenegro", nativeName: "Црна Гора", capital: "Podgorica", countryCode: "499", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 382 }, currency: new string[] { "EUR" }, languages: new string[] { "sr", "bs", "sq", "hr" }, flag: "🇲🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ME");
        /// <summary>
        /// Montserrat
        /// </summary>
        public static Country MS { get; } = new Country(alpha2: "MS", alpha3: "MSR", name: "Montserrat", name2: "Montserrat", nativeName: "Montserrat", capital: "Plymouth", countryCode: "500", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1664 }, currency: new string[] { "XCD" }, languages: new string[] { "en" }, flag: "🇲🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MS");
        /// <summary>
        /// Morocco
        /// </summary>
        public static Country MA { get; } = new Country(alpha2: "MA", alpha3: "MAR", name: "Morocco", name2: "Morocco", nativeName: "المغرب", capital: "Rabat", countryCode: "504", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 212 }, currency: new string[] { "MAD" }, languages: new string[] { "ar" }, flag: "🇲🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MA");
        /// <summary>
        /// Mozambique
        /// </summary>
        public static Country MZ { get; } = new Country(alpha2: "MZ", alpha3: "MOZ", name: "Mozambique", name2: "Mozambique", nativeName: "Moçambique", capital: "Maputo", countryCode: "508", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 258 }, currency: new string[] { "MZN" }, languages: new string[] { "pt" }, flag: "🇲🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MZ");
        /// <summary>
        /// Myanmar
        /// </summary>
        public static Country MM { get; } = new Country(alpha2: "MM", alpha3: "MMR", name: "Myanmar", name2: "Myanmar (Burma)", nativeName: "မြန်မာ", capital: "Naypyidaw", countryCode: "104", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 95 }, currency: new string[] { "MMK" }, languages: new string[] { "my" }, flag: "🇲🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MM");
        /// <summary>
        /// Namibia
        /// </summary>
        public static Country NA { get; } = new Country(alpha2: "NA", alpha3: "NAM", name: "Namibia", name2: "Namibia", nativeName: "Namibia", capital: "Windhoek", countryCode: "516", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 264 }, currency: new string[] { "NAD", "ZAR" }, languages: new string[] { "en", "af" }, flag: "🇳🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NA");
        /// <summary>
        /// Nauru
        /// </summary>
        public static Country NR { get; } = new Country(alpha2: "NR", alpha3: "NRU", name: "Nauru", name2: "Nauru", nativeName: "Nauru", capital: "Yaren", countryCode: "520", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 674 }, currency: new string[] { "AUD" }, languages: new string[] { "en", "na" }, flag: "🇳🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NR");
        /// <summary>
        /// Nepal
        /// </summary>
        public static Country NP { get; } = new Country(alpha2: "NP", alpha3: "NPL", name: "Nepal", name2: "Nepal", nativeName: "नेपाल", capital: "Kathmandu", countryCode: "524", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 977 }, currency: new string[] { "NPR" }, languages: new string[] { "ne" }, flag: "🇳🇵", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NP");
        /// <summary>
        /// Netherlands
        /// </summary>
        public static Country NL { get; } = new Country(alpha2: "NL", alpha3: "NLD", name: "Netherlands", name2: "Netherlands", nativeName: "Nederland", capital: "Amsterdam", countryCode: "528", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 31 }, currency: new string[] { "EUR" }, languages: new string[] { "nl" }, flag: "🇳🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NL");
        /// <summary>
        /// New Caledonia
        /// </summary>
        public static Country NC { get; } = new Country(alpha2: "NC", alpha3: "NCL", name: "New Caledonia", name2: "New Caledonia", nativeName: "Nouvelle-Calédonie", capital: "Nouméa", countryCode: "540", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 687 }, currency: new string[] { "XPF" }, languages: new string[] { "fr" }, flag: "🇳🇨", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NC");
        /// <summary>
        /// New Zealand
        /// </summary>
        public static Country NZ { get; } = new Country(alpha2: "NZ", alpha3: "NZL", name: "New Zealand", name2: "New Zealand", nativeName: "New Zealand", capital: "Wellington", countryCode: "554", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 64 }, currency: new string[] { "NZD" }, languages: new string[] { "en", "mi" }, flag: "🇳🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NZ");
        /// <summary>
        /// Nicaragua
        /// </summary>
        public static Country NI { get; } = new Country(alpha2: "NI", alpha3: "NIC", name: "Nicaragua", name2: "Nicaragua", nativeName: "Nicaragua", capital: "Managua", countryCode: "558", continent: "North America", continentAlpha2: "NA", phone: new int[] { 505 }, currency: new string[] { "NIO" }, languages: new string[] { "es" }, flag: "🇳🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NI");
        /// <summary>
        /// Niger
        /// </summary>
        public static Country NE { get; } = new Country(alpha2: "NE", alpha3: "NER", name: "Niger", name2: "Niger", nativeName: "Niger", capital: "Niamey", countryCode: "562", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 227 }, currency: new string[] { "XOF" }, languages: new string[] { "fr" }, flag: "🇳🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NE");
        /// <summary>
        /// Nigeria
        /// </summary>
        public static Country NG { get; } = new Country(alpha2: "NG", alpha3: "NGA", name: "Nigeria", name2: "Nigeria", nativeName: "Nigeria", capital: "Abuja", countryCode: "566", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 234 }, currency: new string[] { "NGN" }, languages: new string[] { "en" }, flag: "🇳🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NG");
        /// <summary>
        /// Niue
        /// </summary>
        public static Country NU { get; } = new Country(alpha2: "NU", alpha3: "NIU", name: "Niue", name2: "Niue", nativeName: "Niuē", capital: "Alofi", countryCode: "570", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 683 }, currency: new string[] { "NZD" }, languages: new string[] { "en" }, flag: "🇳🇺", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NU");
        /// <summary>
        /// Norfolk Island
        /// </summary>
        public static Country NF { get; } = new Country(alpha2: "NF", alpha3: "NFK", name: "Norfolk Island", name2: "Norfolk Island", nativeName: "Norfolk Island", capital: "Kingston", countryCode: "574", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 672 }, currency: new string[] { "AUD" }, languages: new string[] { "en" }, flag: "🇳🇫", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NF");
        /// <summary>
        /// North Macedonia
        /// </summary>
        public static Country MK { get; } = new Country(alpha2: "MK", alpha3: "MKD", name: "North Macedonia", name2: "North Macedonia", nativeName: "Северна Македонија", capital: "Skopje", countryCode: "807", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 389 }, currency: new string[] { "MKD" }, languages: new string[] { "mk" }, flag: "🇲🇰", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MK");
        /// <summary>
        /// Northern Mariana Islands
        /// </summary>
        public static Country MP { get; } = new Country(alpha2: "MP", alpha3: "MNP", name: "Northern Mariana Islands", name2: "Northern Mariana Islands", nativeName: "Northern Mariana Islands", capital: "Saipan", countryCode: "580", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 1670 }, currency: new string[] { "USD" }, languages: new string[] { "en", "ch" }, flag: "🇲🇵", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MP");
        /// <summary>
        /// Norway
        /// </summary>
        public static Country NO { get; } = new Country(alpha2: "NO", alpha3: "NOR", name: "Norway", name2: "Norway", nativeName: "Norge", capital: "Oslo", countryCode: "578", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 47 }, currency: new string[] { "NOK" }, languages: new string[] { "no", "nb", "nn" }, flag: "🇳🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:NO");
        /// <summary>
        /// Oman
        /// </summary>
        public static Country OM { get; } = new Country(alpha2: "OM", alpha3: "OMN", name: "Oman", name2: "Oman", nativeName: "عمان", capital: "Muscat", countryCode: "512", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 968 }, currency: new string[] { "OMR" }, languages: new string[] { "ar" }, flag: "🇴🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:OM");
        /// <summary>
        /// Pakistan
        /// </summary>
        public static Country PK { get; } = new Country(alpha2: "PK", alpha3: "PAK", name: "Pakistan", name2: "Pakistan", nativeName: "Pakistan", capital: "Islamabad", countryCode: "586", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 92 }, currency: new string[] { "PKR" }, languages: new string[] { "en", "ur" }, flag: "🇵🇰", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PK");
        /// <summary>
        /// Palau
        /// </summary>
        public static Country PW { get; } = new Country(alpha2: "PW", alpha3: "PLW", name: "Palau", name2: "Palau", nativeName: "Palau", capital: "Ngerulmud", countryCode: "585", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 680 }, currency: new string[] { "USD" }, languages: new string[] { "en" }, flag: "🇵🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PW");
        /// <summary>
        /// Palestine, State of
        /// </summary>
        public static Country PS { get; } = new Country(alpha2: "PS", alpha3: "PSE", name: "Palestine, State of", name2: "Palestine", nativeName: "فلسطين", capital: "Ramallah", countryCode: "275", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 970 }, currency: new string[] { "ILS" }, languages: new string[] { "ar" }, flag: "🇵🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PS");
        /// <summary>
        /// Panama
        /// </summary>
        public static Country PA { get; } = new Country(alpha2: "PA", alpha3: "PAN", name: "Panama", name2: "Panama", nativeName: "Panamá", capital: "Panama City", countryCode: "591", continent: "North America", continentAlpha2: "NA", phone: new int[] { 507 }, currency: new string[] { "PAB", "USD" }, languages: new string[] { "es" }, flag: "🇵🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PA");
        /// <summary>
        /// Papua New Guinea
        /// </summary>
        public static Country PG { get; } = new Country(alpha2: "PG", alpha3: "PNG", name: "Papua New Guinea", name2: "Papua New Guinea", nativeName: "Papua Niugini", capital: "Port Moresby", countryCode: "598", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 675 }, currency: new string[] { "PGK" }, languages: new string[] { "en" }, flag: "🇵🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PG");
        /// <summary>
        /// Paraguay
        /// </summary>
        public static Country PY { get; } = new Country(alpha2: "PY", alpha3: "PRY", name: "Paraguay", name2: "Paraguay", nativeName: "Paraguay", capital: "Asunción", countryCode: "600", continent: "South America", continentAlpha2: "SA", phone: new int[] { 595 }, currency: new string[] { "PYG" }, languages: new string[] { "es", "gn" }, flag: "🇵🇾", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PY");
        /// <summary>
        /// Peru
        /// </summary>
        public static Country PE { get; } = new Country(alpha2: "PE", alpha3: "PER", name: "Peru", name2: "Peru", nativeName: "Perú", capital: "Lima", countryCode: "604", continent: "South America", continentAlpha2: "SA", phone: new int[] { 51 }, currency: new string[] { "PEN" }, languages: new string[] { "es" }, flag: "🇵🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PE");
        /// <summary>
        /// Philippines
        /// </summary>
        public static Country PH { get; } = new Country(alpha2: "PH", alpha3: "PHL", name: "Philippines", name2: "Philippines", nativeName: "Pilipinas", capital: "Manila", countryCode: "608", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 63 }, currency: new string[] { "PHP" }, languages: new string[] { "en" }, flag: "🇵🇭", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PH");
        /// <summary>
        /// Pitcairn
        /// </summary>
        public static Country PN { get; } = new Country(alpha2: "PN", alpha3: "PCN", name: "Pitcairn", name2: "Pitcairn Islands", nativeName: "Pitcairn Islands", capital: "Adamstown", countryCode: "612", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 64 }, currency: new string[] { "NZD" }, languages: new string[] { "en" }, flag: "🇵🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PN");
        /// <summary>
        /// Poland
        /// </summary>
        public static Country PL { get; } = new Country(alpha2: "PL", alpha3: "POL", name: "Poland", name2: "Poland", nativeName: "Polska", capital: "Warsaw", countryCode: "616", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 48 }, currency: new string[] { "PLN" }, languages: new string[] { "pl" }, flag: "🇵🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PL");
        /// <summary>
        /// Portugal
        /// </summary>
        public static Country PT { get; } = new Country(alpha2: "PT", alpha3: "PRT", name: "Portugal", name2: "Portugal", nativeName: "Portugal", capital: "Lisbon", countryCode: "620", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 351 }, currency: new string[] { "EUR" }, languages: new string[] { "pt" }, flag: "🇵🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PT");
        /// <summary>
        /// Puerto Rico
        /// </summary>
        public static Country PR { get; } = new Country(alpha2: "PR", alpha3: "PRI", name: "Puerto Rico", name2: "Puerto Rico", nativeName: "Puerto Rico", capital: "San Juan", countryCode: "630", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1787, 1939 }, currency: new string[] { "USD" }, languages: new string[] { "es", "en" }, flag: "🇵🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PR");
        /// <summary>
        /// Qatar
        /// </summary>
        public static Country QA { get; } = new Country(alpha2: "QA", alpha3: "QAT", name: "Qatar", name2: "Qatar", nativeName: "قطر", capital: "Doha", countryCode: "634", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 974 }, currency: new string[] { "QAR" }, languages: new string[] { "ar" }, flag: "🇶🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:QA");
        /// <summary>
        /// Réunion
        /// </summary>
        public static Country RE { get; } = new Country(alpha2: "RE", alpha3: "REU", name: "Réunion", name2: "Reunion", nativeName: "La Réunion", capital: "Saint-Denis", countryCode: "638", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 262 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇷🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:RE");
        /// <summary>
        /// Romania
        /// </summary>
        public static Country RO { get; } = new Country(alpha2: "RO", alpha3: "ROU", name: "Romania", name2: "Romania", nativeName: "România", capital: "Bucharest", countryCode: "642", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 40 }, currency: new string[] { "RON" }, languages: new string[] { "ro" }, flag: "🇷🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:RO");
        /// <summary>
        /// Russian Federation
        /// </summary>
        public static Country RU { get; } = new Country(alpha2: "RU", alpha3: "RUS", name: "Russian Federation", name2: "Russia", nativeName: "Россия", capital: "Moscow", countryCode: "643", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 7 }, currency: new string[] { "RUB" }, languages: new string[] { "ru" }, flag: "🇷🇺", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:RU");
        /// <summary>
        /// Rwanda
        /// </summary>
        public static Country RW { get; } = new Country(alpha2: "RW", alpha3: "RWA", name: "Rwanda", name2: "Rwanda", nativeName: "Rwanda", capital: "Kigali", countryCode: "646", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 250 }, currency: new string[] { "RWF" }, languages: new string[] { "rw", "en", "fr" }, flag: "🇷🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:RW");
        /// <summary>
        /// Saint Barthélemy
        /// </summary>
        public static Country BL { get; } = new Country(alpha2: "BL", alpha3: "BLM", name: "Saint Barthélemy", name2: "Saint Barthelemy", nativeName: "Saint-Barthélemy", capital: "Gustavia", countryCode: "652", continent: "North America", continentAlpha2: "NA", phone: new int[] { 590 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇧🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:BL");
        /// <summary>
        /// Saint Helena, Ascension and Tristan da Cunha
        /// </summary>
        public static Country SH { get; } = new Country(alpha2: "SH", alpha3: "SHN", name: "Saint Helena, Ascension and Tristan da Cunha", name2: "Saint Helena", nativeName: "Saint Helena", capital: "Jamestown", countryCode: "654", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 290 }, currency: new string[] { "SHP" }, languages: new string[] { "en" }, flag: "🇸🇭", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SH");
        /// <summary>
        /// Saint Kitts and Nevis
        /// </summary>
        public static Country KN { get; } = new Country(alpha2: "KN", alpha3: "KNA", name: "Saint Kitts and Nevis", name2: "Saint Kitts and Nevis", nativeName: "Saint Kitts and Nevis", capital: "Basseterre", countryCode: "659", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1869 }, currency: new string[] { "XCD" }, languages: new string[] { "en" }, flag: "🇰🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:KN");
        /// <summary>
        /// Saint Lucia
        /// </summary>
        public static Country LC { get; } = new Country(alpha2: "LC", alpha3: "LCA", name: "Saint Lucia", name2: "Saint Lucia", nativeName: "Saint Lucia", capital: "Castries", countryCode: "662", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1758 }, currency: new string[] { "XCD" }, languages: new string[] { "en" }, flag: "🇱🇨", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LC");
        /// <summary>
        /// Saint Martin (French part)
        /// </summary>
        public static Country MF { get; } = new Country(alpha2: "MF", alpha3: "MAF", name: "Saint Martin (French part)", name2: "Saint Martin", nativeName: "Saint-Martin", capital: "Marigot", countryCode: "663", continent: "North America", continentAlpha2: "NA", phone: new int[] { 590 }, currency: new string[] { "EUR" }, languages: new string[] { "en", "fr", "nl" }, flag: "🇲🇫", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:MF");
        /// <summary>
        /// Saint Pierre and Miquelon
        /// </summary>
        public static Country PM { get; } = new Country(alpha2: "PM", alpha3: "SPM", name: "Saint Pierre and Miquelon", name2: "Saint Pierre and Miquelon", nativeName: "Saint-Pierre-et-Miquelon", capital: "Saint-Pierre", countryCode: "666", continent: "North America", continentAlpha2: "NA", phone: new int[] { 508 }, currency: new string[] { "EUR" }, languages: new string[] { "fr" }, flag: "🇵🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:PM");
        /// <summary>
        /// Saint Vincent and the Grenadines
        /// </summary>
        public static Country VC { get; } = new Country(alpha2: "VC", alpha3: "VCT", name: "Saint Vincent and the Grenadines", name2: "Saint Vincent and the Grenadines", nativeName: "Saint Vincent and the Grenadines", capital: "Kingstown", countryCode: "670", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1784 }, currency: new string[] { "XCD" }, languages: new string[] { "en" }, flag: "🇻🇨", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:VC");
        /// <summary>
        /// Samoa
        /// </summary>
        public static Country WS { get; } = new Country(alpha2: "WS", alpha3: "WSM", name: "Samoa", name2: "Samoa", nativeName: "Samoa", capital: "Apia", countryCode: "882", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 685 }, currency: new string[] { "WST" }, languages: new string[] { "sm", "en" }, flag: "🇼🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:WS");
        /// <summary>
        /// San Marino
        /// </summary>
        public static Country SM { get; } = new Country(alpha2: "SM", alpha3: "SMR", name: "San Marino", name2: "San Marino", nativeName: "San Marino", capital: "City of San Marino", countryCode: "674", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 378 }, currency: new string[] { "EUR" }, languages: new string[] { "it" }, flag: "🇸🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SM");
        /// <summary>
        /// Sao Tome and Principe
        /// </summary>
        public static Country ST { get; } = new Country(alpha2: "ST", alpha3: "STP", name: "Sao Tome and Principe", name2: "Sao Tome and Principe", nativeName: "São Tomé e Príncipe", capital: "São Tomé", countryCode: "678", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 239 }, currency: new string[] { "STN" }, languages: new string[] { "pt" }, flag: "🇸🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ST");
        /// <summary>
        /// Saudi Arabia
        /// </summary>
        public static Country SA { get; } = new Country(alpha2: "SA", alpha3: "SAU", name: "Saudi Arabia", name2: "Saudi Arabia", nativeName: "العربية السعودية", capital: "Riyadh", countryCode: "682", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 966 }, currency: new string[] { "SAR" }, languages: new string[] { "ar" }, flag: "🇸🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SA");
        /// <summary>
        /// Senegal
        /// </summary>
        public static Country SN { get; } = new Country(alpha2: "SN", alpha3: "SEN", name: "Senegal", name2: "Senegal", nativeName: "Sénégal", capital: "Dakar", countryCode: "686", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 221 }, currency: new string[] { "XOF" }, languages: new string[] { "fr" }, flag: "🇸🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SN");
        /// <summary>
        /// Serbia
        /// </summary>
        public static Country RS { get; } = new Country(alpha2: "RS", alpha3: "SRB", name: "Serbia", name2: "Serbia", nativeName: "Србија", capital: "Belgrade", countryCode: "688", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 381 }, currency: new string[] { "RSD" }, languages: new string[] { "sr" }, flag: "🇷🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:RS");
        /// <summary>
        /// Seychelles
        /// </summary>
        public static Country SC { get; } = new Country(alpha2: "SC", alpha3: "SYC", name: "Seychelles", name2: "Seychelles", nativeName: "Seychelles", capital: "Victoria", countryCode: "690", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 248 }, currency: new string[] { "SCR" }, languages: new string[] { "fr", "en" }, flag: "🇸🇨", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SC");
        /// <summary>
        /// Sierra Leone
        /// </summary>
        public static Country SL { get; } = new Country(alpha2: "SL", alpha3: "SLE", name: "Sierra Leone", name2: "Sierra Leone", nativeName: "Sierra Leone", capital: "Freetown", countryCode: "694", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 232 }, currency: new string[] { "SLL" }, languages: new string[] { "en" }, flag: "🇸🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SL");
        /// <summary>
        /// Singapore
        /// </summary>
        public static Country SG { get; } = new Country(alpha2: "SG", alpha3: "SGP", name: "Singapore", name2: "Singapore", nativeName: "Singapore", capital: "Singapore", countryCode: "702", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 65 }, currency: new string[] { "SGD" }, languages: new string[] { "en", "ms", "ta", "zh" }, flag: "🇸🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SG");
        /// <summary>
        /// Sint Maarten (Dutch part)
        /// </summary>
        public static Country SX { get; } = new Country(alpha2: "SX", alpha3: "SXM", name: "Sint Maarten (Dutch part)", name2: "Sint Maarten", nativeName: "Sint Maarten", capital: "Philipsburg", countryCode: "534", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1721 }, currency: new string[] { "ANG" }, languages: new string[] { "nl", "en" }, flag: "🇸🇽", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SX");
        /// <summary>
        /// Slovakia
        /// </summary>
        public static Country SK { get; } = new Country(alpha2: "SK", alpha3: "SVK", name: "Slovakia", name2: "Slovakia", nativeName: "Slovensko", capital: "Bratislava", countryCode: "703", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 421 }, currency: new string[] { "EUR" }, languages: new string[] { "sk" }, flag: "🇸🇰", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SK");
        /// <summary>
        /// Slovenia
        /// </summary>
        public static Country SI { get; } = new Country(alpha2: "SI", alpha3: "SVN", name: "Slovenia", name2: "Slovenia", nativeName: "Slovenija", capital: "Ljubljana", countryCode: "705", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 386 }, currency: new string[] { "EUR" }, languages: new string[] { "sl" }, flag: "🇸🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SI");
        /// <summary>
        /// Solomon Islands
        /// </summary>
        public static Country SB { get; } = new Country(alpha2: "SB", alpha3: "SLB", name: "Solomon Islands", name2: "Solomon Islands", nativeName: "Solomon Islands", capital: "Honiara", countryCode: "090", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 677 }, currency: new string[] { "SBD" }, languages: new string[] { "en" }, flag: "🇸🇧", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SB");
        /// <summary>
        /// Somalia
        /// </summary>
        public static Country SO { get; } = new Country(alpha2: "SO", alpha3: "SOM", name: "Somalia", name2: "Somalia", nativeName: "Soomaaliya", capital: "Mogadishu", countryCode: "706", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 252 }, currency: new string[] { "SOS" }, languages: new string[] { "so", "ar" }, flag: "🇸🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SO");
        /// <summary>
        /// South Africa
        /// </summary>
        public static Country ZA { get; } = new Country(alpha2: "ZA", alpha3: "ZAF", name: "South Africa", name2: "South Africa", nativeName: "South Africa", capital: "Pretoria", countryCode: "710", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 27 }, currency: new string[] { "ZAR" }, languages: new string[] { "af", "en", "nr", "st", "ss", "tn", "ts", "ve", "xh", "zu" }, flag: "🇿🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ZA");
        /// <summary>
        /// South Georgia and the South Sandwich Islands
        /// </summary>
        public static Country GS { get; } = new Country(alpha2: "GS", alpha3: "SGS", name: "South Georgia and the South Sandwich Islands", name2: "South Georgia and the South Sandwich Islands", nativeName: "South Georgia", capital: "King Edward Point", countryCode: "239", continent: "Antarctica", continentAlpha2: "AN", phone: new int[] { 500 }, currency: new string[] { "GBP" }, languages: new string[] { "en" }, flag: "🇬🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GS");
        /// <summary>
        /// South Sudan
        /// </summary>
        public static Country SS { get; } = new Country(alpha2: "SS", alpha3: "SSD", name: "South Sudan", name2: "South Sudan", nativeName: "South Sudan", capital: "Juba", countryCode: "728", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 211 }, currency: new string[] { "SSP" }, languages: new string[] { "en" }, flag: "🇸🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SS");
        /// <summary>
        /// Spain
        /// </summary>
        public static Country ES { get; } = new Country(alpha2: "ES", alpha3: "ESP", name: "Spain", name2: "Spain", nativeName: "España", capital: "Madrid", countryCode: "724", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 34 }, currency: new string[] { "EUR" }, languages: new string[] { "es", "eu", "ca", "gl", "oc" }, flag: "🇪🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ES");
        /// <summary>
        /// Sri Lanka
        /// </summary>
        public static Country LK { get; } = new Country(alpha2: "LK", alpha3: "LKA", name: "Sri Lanka", name2: "Sri Lanka", nativeName: "śrī laṃkāva", capital: "Colombo", countryCode: "144", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 94 }, currency: new string[] { "LKR" }, languages: new string[] { "si", "ta" }, flag: "🇱🇰", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:LK");
        /// <summary>
        /// Sudan
        /// </summary>
        public static Country SD { get; } = new Country(alpha2: "SD", alpha3: "SDN", name: "Sudan", name2: "Sudan", nativeName: "السودان", capital: "Khartoum", countryCode: "729", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 249 }, currency: new string[] { "SDG" }, languages: new string[] { "ar", "en" }, flag: "🇸🇩", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SD");
        /// <summary>
        /// Suriname
        /// </summary>
        public static Country SR { get; } = new Country(alpha2: "SR", alpha3: "SUR", name: "Suriname", name2: "Suriname", nativeName: "Suriname", capital: "Paramaribo", countryCode: "740", continent: "South America", continentAlpha2: "SA", phone: new int[] { 597 }, currency: new string[] { "SRD" }, languages: new string[] { "nl" }, flag: "🇸🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SR");
        /// <summary>
        /// Svalbard and Jan Mayen
        /// </summary>
        public static Country SJ { get; } = new Country(alpha2: "SJ", alpha3: "SJM", name: "Svalbard and Jan Mayen", name2: "Svalbard and Jan Mayen", nativeName: "Svalbard og Jan Mayen", capital: "Longyearbyen", countryCode: "744", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 4779 }, currency: new string[] { "NOK" }, languages: new string[] { "no" }, flag: "🇸🇯", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SJ");
        /// <summary>
        /// Sweden
        /// </summary>
        public static Country SE { get; } = new Country(alpha2: "SE", alpha3: "SWE", name: "Sweden", name2: "Sweden", nativeName: "Sverige", capital: "Stockholm", countryCode: "752", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 46 }, currency: new string[] { "SEK" }, languages: new string[] { "sv" }, flag: "🇸🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SE");
        /// <summary>
        /// Switzerland
        /// </summary>
        public static Country CH { get; } = new Country(alpha2: "CH", alpha3: "CHE", name: "Switzerland", name2: "Switzerland", nativeName: "Schweiz", capital: "Bern", countryCode: "756", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 41 }, currency: new string[] { "CHE", "CHF", "CHW" }, languages: new string[] { "de", "fr", "it" }, flag: "🇨🇭", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:CH");
        /// <summary>
        /// Syrian Arab Republic
        /// </summary>
        public static Country SY { get; } = new Country(alpha2: "SY", alpha3: "SYR", name: "Syrian Arab Republic", name2: "Syria", nativeName: "سوريا", capital: "Damascus", countryCode: "760", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 963 }, currency: new string[] { "SYP" }, languages: new string[] { "ar" }, flag: "🇸🇾", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:SY");
        /// <summary>
        /// Taiwan, Province of China
        /// </summary>
        public static Country TW { get; } = new Country(alpha2: "TW", alpha3: "TWN", name: "Taiwan, Province of China", name2: "Taiwan", nativeName: "臺灣", capital: "Taipei", countryCode: "158", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 886 }, currency: new string[] { "TWD" }, languages: new string[] { "zh" }, flag: "🇹🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TW");
        /// <summary>
        /// Tajikistan
        /// </summary>
        public static Country TJ { get; } = new Country(alpha2: "TJ", alpha3: "TJK", name: "Tajikistan", name2: "Tajikistan", nativeName: "Тоҷикистон", capital: "Dushanbe", countryCode: "762", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 992 }, currency: new string[] { "TJS" }, languages: new string[] { "tg", "ru" }, flag: "🇹🇯", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TJ");
        /// <summary>
        /// Tanzania, United Republic of
        /// </summary>
        public static Country TZ { get; } = new Country(alpha2: "TZ", alpha3: "TZA", name: "Tanzania, United Republic of", name2: "Tanzania", nativeName: "Tanzania", capital: "Dodoma", countryCode: "834", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 255 }, currency: new string[] { "TZS" }, languages: new string[] { "sw", "en" }, flag: "🇹🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TZ");
        /// <summary>
        /// Thailand
        /// </summary>
        public static Country TH { get; } = new Country(alpha2: "TH", alpha3: "THA", name: "Thailand", name2: "Thailand", nativeName: "ประเทศไทย", capital: "Bangkok", countryCode: "764", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 66 }, currency: new string[] { "THB" }, languages: new string[] { "th" }, flag: "🇹🇭", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TH");
        /// <summary>
        /// Timor-Leste
        /// </summary>
        public static Country TL { get; } = new Country(alpha2: "TL", alpha3: "TLS", name: "Timor-Leste", name2: "East Timor", nativeName: "Timor-Leste", capital: "Dili", countryCode: "626", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 670 }, currency: new string[] { "USD" }, languages: new string[] { "pt" }, flag: "🇹🇱", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TL");
        /// <summary>
        /// Togo
        /// </summary>
        public static Country TG { get; } = new Country(alpha2: "TG", alpha3: "TGO", name: "Togo", name2: "Togo", nativeName: "Togo", capital: "Lomé", countryCode: "768", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 228 }, currency: new string[] { "XOF" }, languages: new string[] { "fr" }, flag: "🇹🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TG");
        /// <summary>
        /// Tokelau
        /// </summary>
        public static Country TK { get; } = new Country(alpha2: "TK", alpha3: "TKL", name: "Tokelau", name2: "Tokelau", nativeName: "Tokelau", capital: "Fakaofo", countryCode: "772", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 690 }, currency: new string[] { "NZD" }, languages: new string[] { "en" }, flag: "🇹🇰", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TK");
        /// <summary>
        /// Tonga
        /// </summary>
        public static Country TO { get; } = new Country(alpha2: "TO", alpha3: "TON", name: "Tonga", name2: "Tonga", nativeName: "Tonga", capital: "Nuku'alofa", countryCode: "776", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 676 }, currency: new string[] { "TOP" }, languages: new string[] { "en", "to" }, flag: "🇹🇴", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TO");
        /// <summary>
        /// Trinidad and Tobago
        /// </summary>
        public static Country TT { get; } = new Country(alpha2: "TT", alpha3: "TTO", name: "Trinidad and Tobago", name2: "Trinidad and Tobago", nativeName: "Trinidad and Tobago", capital: "Port of Spain", countryCode: "780", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1868 }, currency: new string[] { "TTD" }, languages: new string[] { "en" }, flag: "🇹🇹", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TT");
        /// <summary>
        /// Tunisia
        /// </summary>
        public static Country TN { get; } = new Country(alpha2: "TN", alpha3: "TUN", name: "Tunisia", name2: "Tunisia", nativeName: "تونس", capital: "Tunis", countryCode: "788", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 216 }, currency: new string[] { "TND" }, languages: new string[] { "ar" }, flag: "🇹🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TN");
        /// <summary>
        /// Turkey
        /// </summary>
        public static Country TR { get; } = new Country(alpha2: "TR", alpha3: "TUR", name: "Turkey", name2: "Turkey", nativeName: "Türkiye", capital: "Ankara", countryCode: "792", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 90 }, currency: new string[] { "TRY" }, languages: new string[] { "tr" }, flag: "🇹🇷", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TR");
        /// <summary>
        /// Turkmenistan
        /// </summary>
        public static Country TM { get; } = new Country(alpha2: "TM", alpha3: "TKM", name: "Turkmenistan", name2: "Turkmenistan", nativeName: "Türkmenistan", capital: "Ashgabat", countryCode: "795", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 993 }, currency: new string[] { "TMT" }, languages: new string[] { "tk", "ru" }, flag: "🇹🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TM");
        /// <summary>
        /// Turks and Caicos Islands
        /// </summary>
        public static Country TC { get; } = new Country(alpha2: "TC", alpha3: "TCA", name: "Turks and Caicos Islands", name2: "Turks and Caicos Islands", nativeName: "Turks and Caicos Islands", capital: "Cockburn Town", countryCode: "796", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1649 }, currency: new string[] { "USD" }, languages: new string[] { "en" }, flag: "🇹🇨", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TC");
        /// <summary>
        /// Tuvalu
        /// </summary>
        public static Country TV { get; } = new Country(alpha2: "TV", alpha3: "TUV", name: "Tuvalu", name2: "Tuvalu", nativeName: "Tuvalu", capital: "Funafuti", countryCode: "798", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 688 }, currency: new string[] { "AUD" }, languages: new string[] { "en" }, flag: "🇹🇻", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:TV");
        /// <summary>
        /// Uganda
        /// </summary>
        public static Country UG { get; } = new Country(alpha2: "UG", alpha3: "UGA", name: "Uganda", name2: "Uganda", nativeName: "Uganda", capital: "Kampala", countryCode: "800", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 256 }, currency: new string[] { "UGX" }, languages: new string[] { "en", "sw" }, flag: "🇺🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:UG");
        /// <summary>
        /// Ukraine
        /// </summary>
        public static Country UA { get; } = new Country(alpha2: "UA", alpha3: "UKR", name: "Ukraine", name2: "Ukraine", nativeName: "Україна", capital: "Kyiv", countryCode: "804", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 380 }, currency: new string[] { "UAH" }, languages: new string[] { "uk" }, flag: "🇺🇦", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:UA");
        /// <summary>
        /// United Arab Emirates
        /// </summary>
        public static Country AE { get; } = new Country(alpha2: "AE", alpha3: "ARE", name: "United Arab Emirates", name2: "United Arab Emirates", nativeName: "دولة الإمارات العربية المتحدة", capital: "Abu Dhabi", countryCode: "784", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 971 }, currency: new string[] { "AED" }, languages: new string[] { "ar" }, flag: "🇦🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:AE");
        /// <summary>
        /// United Kingdom of Great Britain and Northern Ireland
        /// </summary>
        public static Country GB { get; } = new Country(alpha2: "GB", alpha3: "GBR", name: "United Kingdom of Great Britain and Northern Ireland", name2: "United Kingdom", nativeName: "United Kingdom", capital: "London", countryCode: "826", continent: "Europe", continentAlpha2: "EU", phone: new int[] { 44 }, currency: new string[] { "GBP" }, languages: new string[] { "en" }, flag: "🇬🇧", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:GB");
        /// <summary>
        /// United States of America
        /// </summary>
        public static Country US { get; } = new Country(alpha2: "US", alpha3: "USA", name: "United States of America", name2: "United States", nativeName: "United States", capital: "Washington D.C.", countryCode: "840", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1 }, currency: new string[] { "USD", "USN", "USS" }, languages: new string[] { "en" }, flag: "🇺🇸", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:US");
        /// <summary>
        /// United States Minor Outlying Islands
        /// </summary>
        public static Country UM { get; } = new Country(alpha2: "UM", alpha3: "UMI", name: "United States Minor Outlying Islands", name2: "U.S. Minor Outlying Islands", nativeName: "United States Minor Outlying Islands", capital: "", countryCode: "581", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 1 }, currency: new string[] { "USD" }, languages: new string[] { "en" }, flag: "🇺🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:UM");
        /// <summary>
        /// Uruguay
        /// </summary>
        public static Country UY { get; } = new Country(alpha2: "UY", alpha3: "URY", name: "Uruguay", name2: "Uruguay", nativeName: "Uruguay", capital: "Montevideo", countryCode: "858", continent: "South America", continentAlpha2: "SA", phone: new int[] { 598 }, currency: new string[] { "UYI", "UYU" }, languages: new string[] { "es" }, flag: "🇺🇾", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:UY");
        /// <summary>
        /// Uzbekistan
        /// </summary>
        public static Country UZ { get; } = new Country(alpha2: "UZ", alpha3: "UZB", name: "Uzbekistan", name2: "Uzbekistan", nativeName: "O‘zbekiston", capital: "Tashkent", countryCode: "860", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 998 }, currency: new string[] { "UZS" }, languages: new string[] { "uz", "ru" }, flag: "🇺🇿", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:UZ");
        /// <summary>
        /// Vanuatu
        /// </summary>
        public static Country VU { get; } = new Country(alpha2: "VU", alpha3: "VUT", name: "Vanuatu", name2: "Vanuatu", nativeName: "Vanuatu", capital: "Port Vila", countryCode: "548", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 678 }, currency: new string[] { "VUV" }, languages: new string[] { "bi", "en", "fr" }, flag: "🇻🇺", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:VU");
        /// <summary>
        /// Venezuela (Bolivarian Republic of)
        /// </summary>
        public static Country VE { get; } = new Country(alpha2: "VE", alpha3: "VEN", name: "Venezuela (Bolivarian Republic of)", name2: "Venezuela", nativeName: "Venezuela", capital: "Caracas", countryCode: "862", continent: "South America", continentAlpha2: "SA", phone: new int[] { 58 }, currency: new string[] { "VES" }, languages: new string[] { "es" }, flag: "🇻🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:VE");
        /// <summary>
        /// Viet Nam
        /// </summary>
        public static Country VN { get; } = new Country(alpha2: "VN", alpha3: "VNM", name: "Viet Nam", name2: "Vietnam", nativeName: "Việt Nam", capital: "Hanoi", countryCode: "704", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 84 }, currency: new string[] { "VND" }, languages: new string[] { "vi" }, flag: "🇻🇳", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:VN");
        /// <summary>
        /// Virgin Islands (British)
        /// </summary>
        public static Country VG { get; } = new Country(alpha2: "VG", alpha3: "VGB", name: "Virgin Islands (British)", name2: "British Virgin Islands", nativeName: "British Virgin Islands", capital: "Road Town", countryCode: "092", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1284 }, currency: new string[] { "USD" }, languages: new string[] { "en" }, flag: "🇻🇬", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:VG");
        /// <summary>
        /// Virgin Islands (U.S.)
        /// </summary>
        public static Country VI { get; } = new Country(alpha2: "VI", alpha3: "VIR", name: "Virgin Islands (U.S.)", name2: "U.S. Virgin Islands", nativeName: "United States Virgin Islands", capital: "Charlotte Amalie", countryCode: "850", continent: "North America", continentAlpha2: "NA", phone: new int[] { 1340 }, currency: new string[] { "USD" }, languages: new string[] { "en" }, flag: "🇻🇮", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:VI");
        /// <summary>
        /// Wallis and Futuna
        /// </summary>
        public static Country WF { get; } = new Country(alpha2: "WF", alpha3: "WLF", name: "Wallis and Futuna", name2: "Wallis and Futuna", nativeName: "Wallis et Futuna", capital: "Mata-Utu", countryCode: "876", continent: "Oceania", continentAlpha2: "OC", phone: new int[] { 681 }, currency: new string[] { "XPF" }, languages: new string[] { "fr" }, flag: "🇼🇫", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:WF");
        /// <summary>
        /// Western Sahara
        /// </summary>
        public static Country EH { get; } = new Country(alpha2: "EH", alpha3: "ESH", name: "Western Sahara", name2: "Western Sahara", nativeName: "الصحراء الغربية", capital: "El Aaiún", countryCode: "732", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 212 }, currency: new string[] { "MAD", "DZD", "MRU" }, languages: new string[] { "es" }, flag: "🇪🇭", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:EH");
        /// <summary>
        /// Yemen
        /// </summary>
        public static Country YE { get; } = new Country(alpha2: "YE", alpha3: "YEM", name: "Yemen", name2: "Yemen", nativeName: "اليَمَن", capital: "Sana'a", countryCode: "887", continent: "Asia", continentAlpha2: "AS", phone: new int[] { 967 }, currency: new string[] { "YER" }, languages: new string[] { "ar" }, flag: "🇾🇪", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:YE");
        /// <summary>
        /// Zambia
        /// </summary>
        public static Country ZM { get; } = new Country(alpha2: "ZM", alpha3: "ZMB", name: "Zambia", name2: "Zambia", nativeName: "Zambia", capital: "Lusaka", countryCode: "894", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 260 }, currency: new string[] { "ZMW" }, languages: new string[] { "en" }, flag: "🇿🇲", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ZM");
        /// <summary>
        /// Zimbabwe
        /// </summary>
        public static Country ZW { get; } = new Country(alpha2: "ZW", alpha3: "ZWE", name: "Zimbabwe", name2: "Zimbabwe", nativeName: "Zimbabwe", capital: "Harare", countryCode: "716", continent: "Africa", continentAlpha2: "AF", phone: new int[] { 263 }, currency: new string[] { "USD", "ZAR", "BWP", "GBP", "AUD", "CNY", "INR", "JPY" }, languages: new string[] { "en", "sn", "nd" }, flag: "🇿🇼", wiki: "https://en.wikipedia.org/wiki/ISO_3166-2:ZW");

        #endregion
        #region Alpha3
        /// <summary>
        /// Afghanistan
        /// </summary>
        public static Country AFG => AF;
        /// <summary>
        /// Åland Islands
        /// </summary>
        public static Country ALA => AX;
        /// <summary>
        /// Albania
        /// </summary>
        public static Country ALB => AL;
        /// <summary>
        /// Algeria
        /// </summary>
        public static Country DZA => DZ;
        /// <summary>
        /// Angola
        /// </summary>
        public static Country AGO => AO;
        /// <summary>
        /// Anguilla
        /// </summary>
        public static Country AIA => AI;
        /// <summary>
        /// Andorra
        /// </summary>
        public static Country AND => AD;
        /// <summary>
        /// American Samoa
        /// </summary>
        public static Country ASM => AS;
        /// <summary>
        /// Antarctica
        /// </summary>
        public static Country ATA => AQ;
        /// <summary>
        /// Antigua and Barbuda
        /// </summary>
        public static Country ATG => AG;
        /// <summary>
        /// Argentina
        /// </summary>
        public static Country ARG => AR;
        /// <summary>
        /// Armenia
        /// </summary>
        public static Country ARM => AM;
        /// <summary>
        /// Aruba
        /// </summary>
        public static Country ABW => AW;
        /// <summary>
        /// Australia
        /// </summary>
        public static Country AUS => AU;
        /// <summary>
        /// Austria
        /// </summary>
        public static Country AUT => AT;
        /// <summary>
        /// Azerbaijan
        /// </summary>
        public static Country AZE => AZ;
        /// <summary>
        /// Bahamas
        /// </summary>
        public static Country BHS => BS;
        /// <summary>
        /// Bahrain
        /// </summary>
        public static Country BHR => BH;
        /// <summary>
        /// Bangladesh
        /// </summary>
        public static Country BGD => BD;
        /// <summary>
        /// Barbados
        /// </summary>
        public static Country BRB => BB;
        /// <summary>
        /// Belarus
        /// </summary>
        public static Country BLR => BY;
        /// <summary>
        /// Belgium
        /// </summary>
        public static Country BEL => BE;
        /// <summary>
        /// Belize
        /// </summary>
        public static Country BLZ => BZ;
        /// <summary>
        /// Benin
        /// </summary>
        public static Country BEN => BJ;
        /// <summary>
        /// Bermuda
        /// </summary>
        public static Country BMU => BM;
        /// <summary>
        /// Bhutan
        /// </summary>
        public static Country BTN => BT;
        /// <summary>
        /// Bolivia (Plurinational State of)
        /// </summary>
        public static Country BOL => BO;
        /// <summary>
        /// Bonaire, Sint Eustatius and Saba
        /// </summary>
        public static Country BES => BQ;
        /// <summary>
        /// Bosnia and Herzegovina
        /// </summary>
        public static Country BIH => BA;
        /// <summary>
        /// Botswana
        /// </summary>
        public static Country BWA => BW;
        /// <summary>
        /// Bouvet Island
        /// </summary>
        public static Country BVT => BV;
        /// <summary>
        /// Brazil
        /// </summary>
        public static Country BRA => BR;
        /// <summary>
        /// British Indian Ocean Territory
        /// </summary>
        public static Country IOT => IO;
        /// <summary>
        /// Brunei Darussalam
        /// </summary>
        public static Country BRN => BN;
        /// <summary>
        /// Bulgaria
        /// </summary>
        public static Country BGR => BG;
        /// <summary>
        /// Burkina Faso
        /// </summary>
        public static Country BFA => BF;
        /// <summary>
        /// Burundi
        /// </summary>
        public static Country BDI => BI;
        /// <summary>
        /// Cabo Verde
        /// </summary>
        public static Country CPV => CV;
        /// <summary>
        /// Cambodia
        /// </summary>
        public static Country KHM => KH;
        /// <summary>
        /// Cameroon
        /// </summary>
        public static Country CMR => CM;
        /// <summary>
        /// Canada
        /// </summary>
        public static Country CAN => CA;
        /// <summary>
        /// Cayman Islands
        /// </summary>
        public static Country CYM => KY;
        /// <summary>
        /// Central African Republic
        /// </summary>
        public static Country CAF => CF;
        /// <summary>
        /// Chad
        /// </summary>
        public static Country TCD => TD;
        /// <summary>
        /// Chile
        /// </summary>
        public static Country CHL => CL;
        /// <summary>
        /// China
        /// </summary>
        public static Country CHN => CN;
        /// <summary>
        /// Christmas Island
        /// </summary>
        public static Country CXR => CX;
        /// <summary>
        /// Cocos (Keeling) Islands
        /// </summary>
        public static Country CCK => CC;
        /// <summary>
        /// Colombia
        /// </summary>
        public static Country COL => CO;
        /// <summary>
        /// Comoros
        /// </summary>
        public static Country COM => KM;
        /// <summary>
        /// Congo
        /// </summary>
        public static Country COG => CG;
        /// <summary>
        /// Congo, Democratic Republic of the
        /// </summary>
        public static Country COD => CD;
        /// <summary>
        /// Cook Islands
        /// </summary>
        public static Country COK => CK;
        /// <summary>
        /// Costa Rica
        /// </summary>
        public static Country CRI => CR;
        /// <summary>
        /// Côte d'Ivoire
        /// </summary>
        public static Country CIV => CI;
        /// <summary>
        /// Croatia
        /// </summary>
        public static Country HRV => HR;
        /// <summary>
        /// Cuba
        /// </summary>
        public static Country CUB => CU;
        /// <summary>
        /// Curaçao
        /// </summary>
        public static Country CUW => CW;
        /// <summary>
        /// Cyprus
        /// </summary>
        public static Country CYP => CY;
        /// <summary>
        /// Czechia
        /// </summary>
        public static Country CZE => CZ;
        /// <summary>
        /// Denmark
        /// </summary>
        public static Country DNK => DK;
        /// <summary>
        /// Djibouti
        /// </summary>
        public static Country DJI => DJ;
        /// <summary>
        /// Dominica
        /// </summary>
        public static Country DMA => DM;
        /// <summary>
        /// Dominican Republic
        /// </summary>
        public static Country DOM => DO;
        /// <summary>
        /// Ecuador
        /// </summary>
        public static Country ECU => EC;
        /// <summary>
        /// Egypt
        /// </summary>
        public static Country EGY => EG;
        /// <summary>
        /// El Salvador
        /// </summary>
        public static Country SLV => SV;
        /// <summary>
        /// Equatorial Guinea
        /// </summary>
        public static Country GNQ => GQ;
        /// <summary>
        /// Eritrea
        /// </summary>
        public static Country ERI => ER;
        /// <summary>
        /// Estonia
        /// </summary>
        public static Country EST => EE;
        /// <summary>
        /// Eswatini
        /// </summary>
        public static Country SWZ => SZ;
        /// <summary>
        /// Ethiopia
        /// </summary>
        public static Country ETH => ET;
        /// <summary>
        /// Falkland Islands (Malvinas)
        /// </summary>
        public static Country FLK => FK;
        /// <summary>
        /// Faroe Islands
        /// </summary>
        public static Country FRO => FO;
        /// <summary>
        /// Fiji
        /// </summary>
        public static Country FJI => FJ;
        /// <summary>
        /// Finland
        /// </summary>
        public static Country FIN => FI;
        /// <summary>
        /// France
        /// </summary>
        public static Country FRA => FR;
        /// <summary>
        /// French Guiana
        /// </summary>
        public static Country GUF => GF;
        /// <summary>
        /// French Polynesia
        /// </summary>
        public static Country PYF => PF;
        /// <summary>
        /// French Southern Territories
        /// </summary>
        public static Country ATF => TF;
        /// <summary>
        /// Gabon
        /// </summary>
        public static Country GAB => GA;
        /// <summary>
        /// Gambia
        /// </summary>
        public static Country GMB => GM;
        /// <summary>
        /// Georgia
        /// </summary>
        public static Country GEO => GE;
        /// <summary>
        /// Germany
        /// </summary>
        public static Country DEU => DE;
        /// <summary>
        /// Ghana
        /// </summary>
        public static Country GHA => GH;
        /// <summary>
        /// Gibraltar
        /// </summary>
        public static Country GIB => GI;
        /// <summary>
        /// Greece
        /// </summary>
        public static Country GRC => GR;
        /// <summary>
        /// Greenland
        /// </summary>
        public static Country GRL => GL;
        /// <summary>
        /// Grenada
        /// </summary>
        public static Country GRD => GD;
        /// <summary>
        /// Guadeloupe
        /// </summary>
        public static Country GLP => GP;
        /// <summary>
        /// Guam
        /// </summary>
        public static Country GUM => GU;
        /// <summary>
        /// Guatemala
        /// </summary>
        public static Country GTM => GT;
        /// <summary>
        /// Guernsey
        /// </summary>
        public static Country GGY => GG;
        /// <summary>
        /// Guinea
        /// </summary>
        public static Country GIN => GN;
        /// <summary>
        /// Guinea-Bissau
        /// </summary>
        public static Country GNB => GW;
        /// <summary>
        /// Guyana
        /// </summary>
        public static Country GUY => GY;
        /// <summary>
        /// Haiti
        /// </summary>
        public static Country HTI => HT;
        /// <summary>
        /// Heard Island and McDonald Islands
        /// </summary>
        public static Country HMD => HM;
        /// <summary>
        /// Holy See
        /// </summary>
        public static Country VAT => VA;
        /// <summary>
        /// Honduras
        /// </summary>
        public static Country HND => HN;
        /// <summary>
        /// Hong Kong
        /// </summary>
        public static Country HKG => HK;
        /// <summary>
        /// Hungary
        /// </summary>
        public static Country HUN => HU;
        /// <summary>
        /// Iceland
        /// </summary>
        public static Country ISL => IS;
        /// <summary>
        /// India
        /// </summary>
        public static Country IND => IN;
        /// <summary>
        /// Indonesia
        /// </summary>
        public static Country IDN => ID;
        /// <summary>
        /// Iran (Islamic Republic of)
        /// </summary>
        public static Country IRN => IR;
        /// <summary>
        /// Iraq
        /// </summary>
        public static Country IRQ => IQ;
        /// <summary>
        /// Ireland
        /// </summary>
        public static Country IRL => IE;
        /// <summary>
        /// Isle of Man
        /// </summary>
        public static Country IMN => IM;
        /// <summary>
        /// Israel
        /// </summary>
        public static Country ISR => IL;
        /// <summary>
        /// Italy
        /// </summary>
        public static Country ITA => IT;
        /// <summary>
        /// Jamaica
        /// </summary>
        public static Country JAM => JM;
        /// <summary>
        /// Japan
        /// </summary>
        public static Country JPN => JP;
        /// <summary>
        /// Jersey
        /// </summary>
        public static Country JEY => JE;
        /// <summary>
        /// Jordan
        /// </summary>
        public static Country JOR => JO;
        /// <summary>
        /// Kazakhstan
        /// </summary>
        public static Country KAZ => KZ;
        /// <summary>
        /// Kenya
        /// </summary>
        public static Country KEN => KE;
        /// <summary>
        /// Kiribati
        /// </summary>
        public static Country KIR => KI;
        /// <summary>
        /// Korea (Democratic People's Republic of)
        /// </summary>
        public static Country PRK => KP;
        /// <summary>
        /// Korea, Republic of
        /// </summary>
        public static Country KOR => KR;
        /// <summary>
        /// Kuwait
        /// </summary>
        public static Country KWT => KW;
        /// <summary>
        /// Kyrgyzstan
        /// </summary>
        public static Country KGZ => KG;
        /// <summary>
        /// Lao People's Democratic Republic
        /// </summary>
        public static Country LAO => LA;
        /// <summary>
        /// Latvia
        /// </summary>
        public static Country LVA => LV;
        /// <summary>
        /// Lebanon
        /// </summary>
        public static Country LBN => LB;
        /// <summary>
        /// Lesotho
        /// </summary>
        public static Country LSO => LS;
        /// <summary>
        /// Liberia
        /// </summary>
        public static Country LBR => LR;
        /// <summary>
        /// Libya
        /// </summary>
        public static Country LBY => LY;
        /// <summary>
        /// Liechtenstein
        /// </summary>
        public static Country LIE => LI;
        /// <summary>
        /// Lithuania
        /// </summary>
        public static Country LTU => LT;
        /// <summary>
        /// Luxembourg
        /// </summary>
        public static Country LUX => LU;
        /// <summary>
        /// Macao
        /// </summary>
        public static Country MAC => MO;
        /// <summary>
        /// Madagascar
        /// </summary>
        public static Country MDG => MG;
        /// <summary>
        /// Malawi
        /// </summary>
        public static Country MWI => MW;
        /// <summary>
        /// Malaysia
        /// </summary>
        public static Country MYS => MY;
        /// <summary>
        /// Maldives
        /// </summary>
        public static Country MDV => MV;
        /// <summary>
        /// Mali
        /// </summary>
        public static Country MLI => ML;
        /// <summary>
        /// Malta
        /// </summary>
        public static Country MLT => MT;
        /// <summary>
        /// Marshall Islands
        /// </summary>
        public static Country MHL => MH;
        /// <summary>
        /// Martinique
        /// </summary>
        public static Country MTQ => MQ;
        /// <summary>
        /// Mauritania
        /// </summary>
        public static Country MRT => MR;
        /// <summary>
        /// Mauritius
        /// </summary>
        public static Country MUS => MU;
        /// <summary>
        /// Mayotte
        /// </summary>
        public static Country MYT => YT;
        /// <summary>
        /// Mexico
        /// </summary>
        public static Country MEX => MX;
        /// <summary>
        /// Micronesia (Federated States of)
        /// </summary>
        public static Country FSM => FM;
        /// <summary>
        /// Moldova, Republic of
        /// </summary>
        public static Country MDA => MD;
        /// <summary>
        /// Monaco
        /// </summary>
        public static Country MCO => MC;
        /// <summary>
        /// Mongolia
        /// </summary>
        public static Country MNG => MN;
        /// <summary>
        /// Montenegro
        /// </summary>
        public static Country MNE => ME;
        /// <summary>
        /// Montserrat
        /// </summary>
        public static Country MSR => MS;
        /// <summary>
        /// Morocco
        /// </summary>
        public static Country MAR => MA;
        /// <summary>
        /// Mozambique
        /// </summary>
        public static Country MOZ => MZ;
        /// <summary>
        /// Myanmar
        /// </summary>
        public static Country MMR => MM;
        /// <summary>
        /// Namibia
        /// </summary>
        public static Country NAM => NA;
        /// <summary>
        /// Nauru
        /// </summary>
        public static Country NRU => NR;
        /// <summary>
        /// Nepal
        /// </summary>
        public static Country NPL => NP;
        /// <summary>
        /// Netherlands
        /// </summary>
        public static Country NLD => NL;
        /// <summary>
        /// New Caledonia
        /// </summary>
        public static Country NCL => NC;
        /// <summary>
        /// New Zealand
        /// </summary>
        public static Country NZL => NZ;
        /// <summary>
        /// Nicaragua
        /// </summary>
        public static Country NIC => NI;
        /// <summary>
        /// Niger
        /// </summary>
        public static Country NER => NE;
        /// <summary>
        /// Nigeria
        /// </summary>
        public static Country NGA => NG;
        /// <summary>
        /// Niue
        /// </summary>
        public static Country NIU => NU;
        /// <summary>
        /// Norfolk Island
        /// </summary>
        public static Country NFK => NF;
        /// <summary>
        /// North Macedonia
        /// </summary>
        public static Country MKD => MK;
        /// <summary>
        /// Northern Mariana Islands
        /// </summary>
        public static Country MNP => MP;
        /// <summary>
        /// Norway
        /// </summary>
        public static Country NOR => NO;
        /// <summary>
        /// Oman
        /// </summary>
        public static Country OMN => OM;
        /// <summary>
        /// Pakistan
        /// </summary>
        public static Country PAK => PK;
        /// <summary>
        /// Palau
        /// </summary>
        public static Country PLW => PW;
        /// <summary>
        /// Palestine, State of
        /// </summary>
        public static Country PSE => PS;
        /// <summary>
        /// Panama
        /// </summary>
        public static Country PAN => PA;
        /// <summary>
        /// Papua New Guinea
        /// </summary>
        public static Country PNG => PG;
        /// <summary>
        /// Paraguay
        /// </summary>
        public static Country PRY => PY;
        /// <summary>
        /// Peru
        /// </summary>
        public static Country PER => PE;
        /// <summary>
        /// Philippines
        /// </summary>
        public static Country PHL => PH;
        /// <summary>
        /// Pitcairn
        /// </summary>
        public static Country PCN => PN;
        /// <summary>
        /// Poland
        /// </summary>
        public static Country POL => PL;
        /// <summary>
        /// Portugal
        /// </summary>
        public static Country PRT => PT;
        /// <summary>
        /// Puerto Rico
        /// </summary>
        public static Country PRI => PR;
        /// <summary>
        /// Qatar
        /// </summary>
        public static Country QAT => QA;
        /// <summary>
        /// Réunion
        /// </summary>
        public static Country REU => RE;
        /// <summary>
        /// Romania
        /// </summary>
        public static Country ROU => RO;
        /// <summary>
        /// Russian Federation
        /// </summary>
        public static Country RUS => RU;
        /// <summary>
        /// Rwanda
        /// </summary>
        public static Country RWA => RW;
        /// <summary>
        /// Saint Barthélemy
        /// </summary>
        public static Country BLM => BL;
        /// <summary>
        /// Saint Helena, Ascension and Tristan da Cunha
        /// </summary>
        public static Country SHN => SH;
        /// <summary>
        /// Saint Kitts and Nevis
        /// </summary>
        public static Country KNA => KN;
        /// <summary>
        /// Saint Lucia
        /// </summary>
        public static Country LCA => LC;
        /// <summary>
        /// Saint Martin (French part)
        /// </summary>
        public static Country MAF => MF;
        /// <summary>
        /// Saint Pierre and Miquelon
        /// </summary>
        public static Country SPM => PM;
        /// <summary>
        /// Saint Vincent and the Grenadines
        /// </summary>
        public static Country VCT => VC;
        /// <summary>
        /// Samoa
        /// </summary>
        public static Country WSM => WS;
        /// <summary>
        /// San Marino
        /// </summary>
        public static Country SMR => SM;
        /// <summary>
        /// Sao Tome and Principe
        /// </summary>
        public static Country STP => ST;
        /// <summary>
        /// Saudi Arabia
        /// </summary>
        public static Country SAU => SA;
        /// <summary>
        /// Senegal
        /// </summary>
        public static Country SEN => SN;
        /// <summary>
        /// Serbia
        /// </summary>
        public static Country SRB => RS;
        /// <summary>
        /// Seychelles
        /// </summary>
        public static Country SYC => SC;
        /// <summary>
        /// Sierra Leone
        /// </summary>
        public static Country SLE => SL;
        /// <summary>
        /// Singapore
        /// </summary>
        public static Country SGP => SG;
        /// <summary>
        /// Sint Maarten (Dutch part)
        /// </summary>
        public static Country SXM => SX;
        /// <summary>
        /// Slovakia
        /// </summary>
        public static Country SVK => SK;
        /// <summary>
        /// Slovenia
        /// </summary>
        public static Country SVN => SI;
        /// <summary>
        /// Solomon Islands
        /// </summary>
        public static Country SLB => SB;
        /// <summary>
        /// Somalia
        /// </summary>
        public static Country SOM => SO;
        /// <summary>
        /// South Africa
        /// </summary>
        public static Country ZAF => ZA;
        /// <summary>
        /// South Georgia and the South Sandwich Islands
        /// </summary>
        public static Country SGS => GS;
        /// <summary>
        /// South Sudan
        /// </summary>
        public static Country SSD => SS;
        /// <summary>
        /// Spain
        /// </summary>
        public static Country ESP => ES;
        /// <summary>
        /// Sri Lanka
        /// </summary>
        public static Country LKA => LK;
        /// <summary>
        /// Sudan
        /// </summary>
        public static Country SDN => SD;
        /// <summary>
        /// Suriname
        /// </summary>
        public static Country SUR => SR;
        /// <summary>
        /// Svalbard and Jan Mayen
        /// </summary>
        public static Country SJM => SJ;
        /// <summary>
        /// Sweden
        /// </summary>
        public static Country SWE => SE;
        /// <summary>
        /// Switzerland
        /// </summary>
        public static Country CHE => CH;
        /// <summary>
        /// Syrian Arab Republic
        /// </summary>
        public static Country SYR => SY;
        /// <summary>
        /// Taiwan, Province of China
        /// </summary>
        public static Country TWN => TW;
        /// <summary>
        /// Tajikistan
        /// </summary>
        public static Country TJK => TJ;
        /// <summary>
        /// Tanzania, United Republic of
        /// </summary>
        public static Country TZA => TZ;
        /// <summary>
        /// Thailand
        /// </summary>
        public static Country THA => TH;
        /// <summary>
        /// Timor-Leste
        /// </summary>
        public static Country TLS => TL;
        /// <summary>
        /// Togo
        /// </summary>
        public static Country TGO => TG;
        /// <summary>
        /// Tokelau
        /// </summary>
        public static Country TKL => TK;
        /// <summary>
        /// Tonga
        /// </summary>
        public static Country TON => TO;
        /// <summary>
        /// Trinidad and Tobago
        /// </summary>
        public static Country TTO => TT;
        /// <summary>
        /// Tunisia
        /// </summary>
        public static Country TUN => TN;
        /// <summary>
        /// Turkey
        /// </summary>
        public static Country TUR => TR;
        /// <summary>
        /// Turkmenistan
        /// </summary>
        public static Country TKM => TM;
        /// <summary>
        /// Turks and Caicos Islands
        /// </summary>
        public static Country TCA => TC;
        /// <summary>
        /// Tuvalu
        /// </summary>
        public static Country TUV => TV;
        /// <summary>
        /// Uganda
        /// </summary>
        public static Country UGA => UG;
        /// <summary>
        /// Ukraine
        /// </summary>
        public static Country UKR => UA;
        /// <summary>
        /// United Arab Emirates
        /// </summary>
        public static Country ARE => AE;
        /// <summary>
        /// United Kingdom of Great Britain and Northern Ireland
        /// </summary>
        public static Country GBR => GB;
        /// <summary>
        /// United States of America
        /// </summary>
        public static Country USA => US;
        /// <summary>
        /// United States Minor Outlying Islands
        /// </summary>
        public static Country UMI => UM;
        /// <summary>
        /// Uruguay
        /// </summary>
        public static Country URY => UY;
        /// <summary>
        /// Uzbekistan
        /// </summary>
        public static Country UZB => UZ;
        /// <summary>
        /// Vanuatu
        /// </summary>
        public static Country VUT => VU;
        /// <summary>
        /// Venezuela (Bolivarian Republic of)
        /// </summary>
        public static Country VEN => VE;
        /// <summary>
        /// Viet Nam
        /// </summary>
        public static Country VNM => VN;
        /// <summary>
        /// Virgin Islands (British)
        /// </summary>
        public static Country VGB => VG;
        /// <summary>
        /// Virgin Islands (U.S.)
        /// </summary>
        public static Country VIR => VI;
        /// <summary>
        /// Wallis and Futuna
        /// </summary>
        public static Country WLF => WF;
        /// <summary>
        /// Western Sahara
        /// </summary>
        public static Country ESH => EH;
        /// <summary>
        /// Yemen
        /// </summary>
        public static Country YEM => YE;
        /// <summary>
        /// Zambia
        /// </summary>
        public static Country ZMB => ZM;
        /// <summary>
        /// Zimbabwe
        /// </summary>
        public static Country ZWE => ZW;
        #endregion
    }
}
