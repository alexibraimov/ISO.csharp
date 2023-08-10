namespace ISOLib
{
    using ISOLib.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    public class Currencies : ReadOnlyCollection<Currency>, IISO
    {
        static Currencies()
        {
            Collection = new Currencies();
        }
        private Currencies() : base(new Currency[] { AED, AFN, ALL, AMD, ANG, AOA, ARS, AUD, AWG, AZN, BAM, BBD, BDT, BGN, BHD, BIF, BMD, BND, BOB, BOV, BRL, BSD, BTN, BWP, BYR, BZD, CAD, CDF, CHE, CHF, CHW, CLF, CLP, CNY, COP, COU, CRC, CUC, CUP, CVE, CZK, DJF, DKK, DOP, DZD, EGP, ERN, ETB, EUR, FJD, FKP, GBP, GEL, GHS, GIP, GMD, GNF, GTQ, GYD, HKD, HNL, HRK, HTG, HUF, IDR, ILS, INR, IQD, IRR, ISK, JMD, JOD, JPY, KES, KGS, KHR, KMF, KPW, KRW, KWD, KYD, KZT, LAK, LBP, LKR, LRD, LSL, LTL, LVL, LYD, MAD, MDL, MGA, MKD, MMK, MNT, MOP, MRO, MUR, MVR, MWK, MXN, MXV, MYR, MZN, NAD, NGN, NIO, NOK, NPR, NZD, OMR, PAB, PEN, PGK, PHP, PKR, PLN, PYG, QAR, RON, RSD, RUB, RWF, SAR, SBD, SCR, SDG, SEK, SGD, SHP, SLL, SOS, SRD, SSP, STD, SYP, SZL, THB, TJS, TMT, TND, TOP, TRY, TTD, TWD, TZS, UAH, UGX, USD, USN, USS, UYI, UYU, UZS, VEF, VND, VUV, WST, XAF, XAG, XAU, XBA, XBB, XBC, XBD, XCD, XDR, XFU, XOF, XPD, XPF, XPT, XTS, XXX, YER, ZAR, ZMW, })
        {
        }

        public int Number { get; } = 4217;
        public string Name { get; } = "ISO 4217";
        public string Wiki { get; } = "https://en.wikipedia.org/wiki/ISO_4217";
        /// <summary>
        /// Gets the collection of currencies defined by the ISO 4217 standard.
        /// </summary>
        public static Currencies Collection { get; }
        /// <summary>
        /// Gets the <see cref="Currency"/> object corresponding to the specified currency name or Alpha-3 code.
        /// </summary>
        /// <param name="key">The currency name or Alpha-3 code to retrieve.</param>
        /// <returns>The <see cref="Currency"/> object representing the specified currency.</returns>
        /// <exception cref="ArgumentException">Thrown when the specified currency name or Alpha-3 code does not match any currency in the collection.</exception>
        public Currency this[string key]
        {
            get
            {
                if (TryGetValue(key, out Currency currency))
                {
                    return currency;
                }

                throw new ArgumentException("Currency not found", nameof(key));
            }
        }
        /// <summary>
        /// Tries to retrieve a currency by its key (name or alpha3 code) from the collection of currencies.
        /// </summary>
        /// <param name="key">The key (name or alpha3 code) of the currency to retrieve.</param>
        /// <param name="currency">When this method returns, contains the retrieved currency or null if not found.</param>
        /// <returns>True if the currency was found; otherwise, false.</returns>
        public bool TryGetValue(string key, out Currency currency)
        {
            if (string.IsNullOrEmpty(key))
            {
                currency = null;
            }
            else
            {
                currency = Items.FirstOrDefault(c => c.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase) || c.Alpha3.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            }

            return currency != null;
        }
        /// <summary>
        /// Gets a currency by its ISO 4217 alpha-3 code.
        /// </summary>
        public static Currency GetByAlpha3Code(string alpha3)
        {
            return Collection.FirstOrDefault(c => c.Alpha3.Equals(alpha3, StringComparison.InvariantCultureIgnoreCase));
        }
        /// <summary>
        /// Gets a currency by its name.
        /// </summary>
        public static Currency GetByName(string name)
        {
            return Collection.FirstOrDefault(c => c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
        /// <summary>
        /// Gets an array of currency names.
        /// </summary>
        public static string[] GetNames()
        {
            return Collection.Select(c => c.Name).ToArray();
        }
        /// <summary>
        /// Gets an array of ISO 4217 alpha-3 codes.
        /// </summary>
        public static string[] GetAlpha3Codes()
        {
            return Collection.Select(c => c.Alpha3).ToArray();
        }
        /// <summary>
        /// Filters and returns an array of currencies based on their keys.
        /// </summary>
        /// <param name="currencyKeys">The keys of the currencies to filter by.</param>
        /// <returns>An array of filtered currencies.</returns>
        public static Currency[] FilterCurrencies(params string[] currencyKeys)
        {
            var filteredCurrencies = new List<Currency>();

            for (int i = 0; i < currencyKeys.Length; i++)
            {
                if (Collection.TryGetValue(currencyKeys[i], out Currency currency))
                {
                    filteredCurrencies.Add(currency);
                }
            }

            return filteredCurrencies.ToArray();
        }
        #region Alpha3
        /// <summary>
        /// United Arab Emirates dirham
        /// </summary>
        public static Currency AED { get; } = new Currency(alpha3: "AED", name: "United Arab Emirates dirham", number: "784", minorUnit: 2);
        /// <summary>
        /// Afghan afghani
        /// </summary>
        public static Currency AFN { get; } = new Currency(alpha3: "AFN", name: "Afghan afghani", number: "971", minorUnit: 2);
        /// <summary>
        /// Albanian lek
        /// </summary>
        public static Currency ALL { get; } = new Currency(alpha3: "ALL", name: "Albanian lek", number: "8", minorUnit: 2);
        /// <summary>
        /// Armenian dram
        /// </summary>
        public static Currency AMD { get; } = new Currency(alpha3: "AMD", name: "Armenian dram", number: "51", minorUnit: 2);
        /// <summary>
        /// Netherlands Antillean guilder
        /// </summary>
        public static Currency ANG { get; } = new Currency(alpha3: "ANG", name: "Netherlands Antillean guilder", number: "532", minorUnit: 2);
        /// <summary>
        /// Angolan kwanza
        /// </summary>
        public static Currency AOA { get; } = new Currency(alpha3: "AOA", name: "Angolan kwanza", number: "973", minorUnit: 2);
        /// <summary>
        /// Argentine peso
        /// </summary>
        public static Currency ARS { get; } = new Currency(alpha3: "ARS", name: "Argentine peso", number: "32", minorUnit: 2);
        /// <summary>
        /// Australian dollar
        /// </summary>
        public static Currency AUD { get; } = new Currency(alpha3: "AUD", name: "Australian dollar", number: "36", minorUnit: 2);
        /// <summary>
        /// Aruban florin
        /// </summary>
        public static Currency AWG { get; } = new Currency(alpha3: "AWG", name: "Aruban florin", number: "533", minorUnit: 2);
        /// <summary>
        /// Azerbaijani manat
        /// </summary>
        public static Currency AZN { get; } = new Currency(alpha3: "AZN", name: "Azerbaijani manat", number: "944", minorUnit: 2);
        /// <summary>
        /// Bosnia and Herzegovina convertible mark
        /// </summary>
        public static Currency BAM { get; } = new Currency(alpha3: "BAM", name: "Bosnia and Herzegovina convertible mark", number: "977", minorUnit: 2);
        /// <summary>
        /// Barbados dollar
        /// </summary>
        public static Currency BBD { get; } = new Currency(alpha3: "BBD", name: "Barbados dollar", number: "52", minorUnit: 2);
        /// <summary>
        /// Bangladeshi taka
        /// </summary>
        public static Currency BDT { get; } = new Currency(alpha3: "BDT", name: "Bangladeshi taka", number: "50", minorUnit: 2);
        /// <summary>
        /// Bulgarian lev
        /// </summary>
        public static Currency BGN { get; } = new Currency(alpha3: "BGN", name: "Bulgarian lev", number: "975", minorUnit: 2);
        /// <summary>
        /// Bahraini dinar
        /// </summary>
        public static Currency BHD { get; } = new Currency(alpha3: "BHD", name: "Bahraini dinar", number: "48", minorUnit: 3);
        /// <summary>
        /// Burundian franc
        /// </summary>
        public static Currency BIF { get; } = new Currency(alpha3: "BIF", name: "Burundian franc", number: "108", minorUnit: 0);
        /// <summary>
        /// Bermudian dollar (customarily known as Bermuda dollar)
        /// </summary>
        public static Currency BMD { get; } = new Currency(alpha3: "BMD", name: "Bermudian dollar (customarily known as Bermuda dollar)", number: "60", minorUnit: 2);
        /// <summary>
        /// Brunei dollar
        /// </summary>
        public static Currency BND { get; } = new Currency(alpha3: "BND", name: "Brunei dollar", number: "96", minorUnit: 2);
        /// <summary>
        /// Boliviano
        /// </summary>
        public static Currency BOB { get; } = new Currency(alpha3: "BOB", name: "Boliviano", number: "68", minorUnit: 2);
        /// <summary>
        /// Bolivian Mvdol (funds code)
        /// </summary>
        public static Currency BOV { get; } = new Currency(alpha3: "BOV", name: "Bolivian Mvdol (funds code)", number: "984", minorUnit: 2);
        /// <summary>
        /// Brazilian real
        /// </summary>
        public static Currency BRL { get; } = new Currency(alpha3: "BRL", name: "Brazilian real", number: "986", minorUnit: 2);
        /// <summary>
        /// Bahamian dollar
        /// </summary>
        public static Currency BSD { get; } = new Currency(alpha3: "BSD", name: "Bahamian dollar", number: "44", minorUnit: 2);
        /// <summary>
        /// Bhutanese ngultrum
        /// </summary>
        public static Currency BTN { get; } = new Currency(alpha3: "BTN", name: "Bhutanese ngultrum", number: "64", minorUnit: 2);
        /// <summary>
        /// Botswana pula
        /// </summary>
        public static Currency BWP { get; } = new Currency(alpha3: "BWP", name: "Botswana pula", number: "72", minorUnit: 2);
        /// <summary>
        /// Belarusian ruble
        /// </summary>
        public static Currency BYR { get; } = new Currency(alpha3: "BYR", name: "Belarusian ruble", number: "974", minorUnit: 0);
        /// <summary>
        /// Belize dollar
        /// </summary>
        public static Currency BZD { get; } = new Currency(alpha3: "BZD", name: "Belize dollar", number: "84", minorUnit: 2);
        /// <summary>
        /// Canadian dollar
        /// </summary>
        public static Currency CAD { get; } = new Currency(alpha3: "CAD", name: "Canadian dollar", number: "124", minorUnit: 2);
        /// <summary>
        /// Congolese franc
        /// </summary>
        public static Currency CDF { get; } = new Currency(alpha3: "CDF", name: "Congolese franc", number: "976", minorUnit: 2);
        /// <summary>
        /// WIR Euro (complementary currency)
        /// </summary>
        public static Currency CHE { get; } = new Currency(alpha3: "CHE", name: "WIR Euro (complementary currency)", number: "947", minorUnit: 2);
        /// <summary>
        /// Swiss franc
        /// </summary>
        public static Currency CHF { get; } = new Currency(alpha3: "CHF", name: "Swiss franc", number: "756", minorUnit: 2);
        /// <summary>
        /// WIR Franc (complementary currency)
        /// </summary>
        public static Currency CHW { get; } = new Currency(alpha3: "CHW", name: "WIR Franc (complementary currency)", number: "948", minorUnit: 2);
        /// <summary>
        /// Unidad de Fomento (funds code)
        /// </summary>
        public static Currency CLF { get; } = new Currency(alpha3: "CLF", name: "Unidad de Fomento (funds code)", number: "990", minorUnit: 0);
        /// <summary>
        /// Chilean peso
        /// </summary>
        public static Currency CLP { get; } = new Currency(alpha3: "CLP", name: "Chilean peso", number: "152", minorUnit: 0);
        /// <summary>
        /// Chinese yuan
        /// </summary>
        public static Currency CNY { get; } = new Currency(alpha3: "CNY", name: "Chinese yuan", number: "156", minorUnit: 2);
        /// <summary>
        /// Colombian peso
        /// </summary>
        public static Currency COP { get; } = new Currency(alpha3: "COP", name: "Colombian peso", number: "170", minorUnit: 2);
        /// <summary>
        /// Unidad de Valor Real
        /// </summary>
        public static Currency COU { get; } = new Currency(alpha3: "COU", name: "Unidad de Valor Real", number: "970", minorUnit: 2);
        /// <summary>
        /// Costa Rican colon
        /// </summary>
        public static Currency CRC { get; } = new Currency(alpha3: "CRC", name: "Costa Rican colon", number: "188", minorUnit: 2);
        /// <summary>
        /// Cuban convertible peso
        /// </summary>
        public static Currency CUC { get; } = new Currency(alpha3: "CUC", name: "Cuban convertible peso", number: "931", minorUnit: 2);
        /// <summary>
        /// Cuban peso
        /// </summary>
        public static Currency CUP { get; } = new Currency(alpha3: "CUP", name: "Cuban peso", number: "192", minorUnit: 2);
        /// <summary>
        /// Cape Verde escudo
        /// </summary>
        public static Currency CVE { get; } = new Currency(alpha3: "CVE", name: "Cape Verde escudo", number: "132", minorUnit: 0);
        /// <summary>
        /// Czech koruna
        /// </summary>
        public static Currency CZK { get; } = new Currency(alpha3: "CZK", name: "Czech koruna", number: "203", minorUnit: 2);
        /// <summary>
        /// Djiboutian franc
        /// </summary>
        public static Currency DJF { get; } = new Currency(alpha3: "DJF", name: "Djiboutian franc", number: "262", minorUnit: 0);
        /// <summary>
        /// Danish krone
        /// </summary>
        public static Currency DKK { get; } = new Currency(alpha3: "DKK", name: "Danish krone", number: "208", minorUnit: 2);
        /// <summary>
        /// Dominican peso
        /// </summary>
        public static Currency DOP { get; } = new Currency(alpha3: "DOP", name: "Dominican peso", number: "214", minorUnit: 2);
        /// <summary>
        /// Algerian dinar
        /// </summary>
        public static Currency DZD { get; } = new Currency(alpha3: "DZD", name: "Algerian dinar", number: "12", minorUnit: 2);
        /// <summary>
        /// Egyptian pound
        /// </summary>
        public static Currency EGP { get; } = new Currency(alpha3: "EGP", name: "Egyptian pound", number: "818", minorUnit: 2);
        /// <summary>
        /// Eritrean nakfa
        /// </summary>
        public static Currency ERN { get; } = new Currency(alpha3: "ERN", name: "Eritrean nakfa", number: "232", minorUnit: 2);
        /// <summary>
        /// Ethiopian birr
        /// </summary>
        public static Currency ETB { get; } = new Currency(alpha3: "ETB", name: "Ethiopian birr", number: "230", minorUnit: 2);
        /// <summary>
        /// Euro
        /// </summary>
        public static Currency EUR { get; } = new Currency(alpha3: "EUR", name: "Euro", number: "978", minorUnit: 2);
        /// <summary>
        /// Fiji dollar
        /// </summary>
        public static Currency FJD { get; } = new Currency(alpha3: "FJD", name: "Fiji dollar", number: "242", minorUnit: 2);
        /// <summary>
        /// Falkland Islands pound
        /// </summary>
        public static Currency FKP { get; } = new Currency(alpha3: "FKP", name: "Falkland Islands pound", number: "238", minorUnit: 2);
        /// <summary>
        /// Pound sterling
        /// </summary>
        public static Currency GBP { get; } = new Currency(alpha3: "GBP", name: "Pound sterling", number: "826", minorUnit: 2);
        /// <summary>
        /// Georgian lari
        /// </summary>
        public static Currency GEL { get; } = new Currency(alpha3: "GEL", name: "Georgian lari", number: "981", minorUnit: 2);
        /// <summary>
        /// Ghanaian cedi
        /// </summary>
        public static Currency GHS { get; } = new Currency(alpha3: "GHS", name: "Ghanaian cedi", number: "936", minorUnit: 2);
        /// <summary>
        /// Gibraltar pound
        /// </summary>
        public static Currency GIP { get; } = new Currency(alpha3: "GIP", name: "Gibraltar pound", number: "292", minorUnit: 2);
        /// <summary>
        /// Gambian dalasi
        /// </summary>
        public static Currency GMD { get; } = new Currency(alpha3: "GMD", name: "Gambian dalasi", number: "270", minorUnit: 2);
        /// <summary>
        /// Guinean franc
        /// </summary>
        public static Currency GNF { get; } = new Currency(alpha3: "GNF", name: "Guinean franc", number: "324", minorUnit: 0);
        /// <summary>
        /// Guatemalan quetzal
        /// </summary>
        public static Currency GTQ { get; } = new Currency(alpha3: "GTQ", name: "Guatemalan quetzal", number: "320", minorUnit: 2);
        /// <summary>
        /// Guyanese dollar
        /// </summary>
        public static Currency GYD { get; } = new Currency(alpha3: "GYD", name: "Guyanese dollar", number: "328", minorUnit: 2);
        /// <summary>
        /// Hong Kong dollar
        /// </summary>
        public static Currency HKD { get; } = new Currency(alpha3: "HKD", name: "Hong Kong dollar", number: "344", minorUnit: 2);
        /// <summary>
        /// Honduran lempira
        /// </summary>
        public static Currency HNL { get; } = new Currency(alpha3: "HNL", name: "Honduran lempira", number: "340", minorUnit: 2);
        /// <summary>
        /// Croatian kuna
        /// </summary>
        public static Currency HRK { get; } = new Currency(alpha3: "HRK", name: "Croatian kuna", number: "191", minorUnit: 2);
        /// <summary>
        /// Haitian gourde
        /// </summary>
        public static Currency HTG { get; } = new Currency(alpha3: "HTG", name: "Haitian gourde", number: "332", minorUnit: 2);
        /// <summary>
        /// Hungarian forint
        /// </summary>
        public static Currency HUF { get; } = new Currency(alpha3: "HUF", name: "Hungarian forint", number: "348", minorUnit: 2);
        /// <summary>
        /// Indonesian rupiah
        /// </summary>
        public static Currency IDR { get; } = new Currency(alpha3: "IDR", name: "Indonesian rupiah", number: "360", minorUnit: 2);
        /// <summary>
        /// Israeli new shekel
        /// </summary>
        public static Currency ILS { get; } = new Currency(alpha3: "ILS", name: "Israeli new shekel", number: "376", minorUnit: 2);
        /// <summary>
        /// Indian rupee
        /// </summary>
        public static Currency INR { get; } = new Currency(alpha3: "INR", name: "Indian rupee", number: "356", minorUnit: 2);
        /// <summary>
        /// Iraqi dinar
        /// </summary>
        public static Currency IQD { get; } = new Currency(alpha3: "IQD", name: "Iraqi dinar", number: "368", minorUnit: 3);
        /// <summary>
        /// Iranian rial
        /// </summary>
        public static Currency IRR { get; } = new Currency(alpha3: "IRR", name: "Iranian rial", number: "364", minorUnit: 0);
        /// <summary>
        /// Icelandic króna
        /// </summary>
        public static Currency ISK { get; } = new Currency(alpha3: "ISK", name: "Icelandic króna", number: "352", minorUnit: 0);
        /// <summary>
        /// Jamaican dollar
        /// </summary>
        public static Currency JMD { get; } = new Currency(alpha3: "JMD", name: "Jamaican dollar", number: "388", minorUnit: 2);
        /// <summary>
        /// Jordanian dinar
        /// </summary>
        public static Currency JOD { get; } = new Currency(alpha3: "JOD", name: "Jordanian dinar", number: "400", minorUnit: 3);
        /// <summary>
        /// Japanese yen
        /// </summary>
        public static Currency JPY { get; } = new Currency(alpha3: "JPY", name: "Japanese yen", number: "392", minorUnit: 0);
        /// <summary>
        /// Kenyan shilling
        /// </summary>
        public static Currency KES { get; } = new Currency(alpha3: "KES", name: "Kenyan shilling", number: "404", minorUnit: 2);
        /// <summary>
        /// Kyrgyzstani som
        /// </summary>
        public static Currency KGS { get; } = new Currency(alpha3: "KGS", name: "Kyrgyzstani som", number: "417", minorUnit: 2);
        /// <summary>
        /// Cambodian riel
        /// </summary>
        public static Currency KHR { get; } = new Currency(alpha3: "KHR", name: "Cambodian riel", number: "116", minorUnit: 2);
        /// <summary>
        /// Comoro franc
        /// </summary>
        public static Currency KMF { get; } = new Currency(alpha3: "KMF", name: "Comoro franc", number: "174", minorUnit: 0);
        /// <summary>
        /// North Korean won
        /// </summary>
        public static Currency KPW { get; } = new Currency(alpha3: "KPW", name: "North Korean won", number: "408", minorUnit: 0);
        /// <summary>
        /// South Korean won
        /// </summary>
        public static Currency KRW { get; } = new Currency(alpha3: "KRW", name: "South Korean won", number: "410", minorUnit: 0);
        /// <summary>
        /// Kuwaiti dinar
        /// </summary>
        public static Currency KWD { get; } = new Currency(alpha3: "KWD", name: "Kuwaiti dinar", number: "414", minorUnit: 3);
        /// <summary>
        /// Cayman Islands dollar
        /// </summary>
        public static Currency KYD { get; } = new Currency(alpha3: "KYD", name: "Cayman Islands dollar", number: "136", minorUnit: 2);
        /// <summary>
        /// Kazakhstani tenge
        /// </summary>
        public static Currency KZT { get; } = new Currency(alpha3: "KZT", name: "Kazakhstani tenge", number: "398", minorUnit: 2);
        /// <summary>
        /// Lao kip
        /// </summary>
        public static Currency LAK { get; } = new Currency(alpha3: "LAK", name: "Lao kip", number: "418", minorUnit: 0);
        /// <summary>
        /// Lebanese pound
        /// </summary>
        public static Currency LBP { get; } = new Currency(alpha3: "LBP", name: "Lebanese pound", number: "422", minorUnit: 0);
        /// <summary>
        /// Sri Lankan rupee
        /// </summary>
        public static Currency LKR { get; } = new Currency(alpha3: "LKR", name: "Sri Lankan rupee", number: "144", minorUnit: 2);
        /// <summary>
        /// Liberian dollar
        /// </summary>
        public static Currency LRD { get; } = new Currency(alpha3: "LRD", name: "Liberian dollar", number: "430", minorUnit: 2);
        /// <summary>
        /// Lesotho loti
        /// </summary>
        public static Currency LSL { get; } = new Currency(alpha3: "LSL", name: "Lesotho loti", number: "426", minorUnit: 2);
        /// <summary>
        /// Lithuanian litas
        /// </summary>
        public static Currency LTL { get; } = new Currency(alpha3: "LTL", name: "Lithuanian litas", number: "440", minorUnit: 2);
        /// <summary>
        /// Latvian lats
        /// </summary>
        public static Currency LVL { get; } = new Currency(alpha3: "LVL", name: "Latvian lats", number: "428", minorUnit: 2);
        /// <summary>
        /// Libyan dinar
        /// </summary>
        public static Currency LYD { get; } = new Currency(alpha3: "LYD", name: "Libyan dinar", number: "434", minorUnit: 3);
        /// <summary>
        /// Moroccan dirham
        /// </summary>
        public static Currency MAD { get; } = new Currency(alpha3: "MAD", name: "Moroccan dirham", number: "504", minorUnit: 2);
        /// <summary>
        /// Moldovan leu
        /// </summary>
        public static Currency MDL { get; } = new Currency(alpha3: "MDL", name: "Moldovan leu", number: "498", minorUnit: 2);
        /// <summary>
        /// Malagasy ariary
        /// </summary>
        public static Currency MGA { get; } = new Currency(alpha3: "MGA", name: "Malagasy ariary", number: "969", minorUnit: 0);
        /// <summary>
        /// Macedonian denar
        /// </summary>
        public static Currency MKD { get; } = new Currency(alpha3: "MKD", name: "Macedonian denar", number: "807", minorUnit: 0);
        /// <summary>
        /// Myanma kyat
        /// </summary>
        public static Currency MMK { get; } = new Currency(alpha3: "MMK", name: "Myanma kyat", number: "104", minorUnit: 0);
        /// <summary>
        /// Mongolian tugrik
        /// </summary>
        public static Currency MNT { get; } = new Currency(alpha3: "MNT", name: "Mongolian tugrik", number: "496", minorUnit: 2);
        /// <summary>
        /// Macanese pataca
        /// </summary>
        public static Currency MOP { get; } = new Currency(alpha3: "MOP", name: "Macanese pataca", number: "446", minorUnit: 2);
        /// <summary>
        /// Mauritanian ouguiya
        /// </summary>
        public static Currency MRO { get; } = new Currency(alpha3: "MRO", name: "Mauritanian ouguiya", number: "478", minorUnit: 0);
        /// <summary>
        /// Mauritian rupee
        /// </summary>
        public static Currency MUR { get; } = new Currency(alpha3: "MUR", name: "Mauritian rupee", number: "480", minorUnit: 2);
        /// <summary>
        /// Maldivian rufiyaa
        /// </summary>
        public static Currency MVR { get; } = new Currency(alpha3: "MVR", name: "Maldivian rufiyaa", number: "462", minorUnit: 2);
        /// <summary>
        /// Malawian kwacha
        /// </summary>
        public static Currency MWK { get; } = new Currency(alpha3: "MWK", name: "Malawian kwacha", number: "454", minorUnit: 2);
        /// <summary>
        /// Mexican peso
        /// </summary>
        public static Currency MXN { get; } = new Currency(alpha3: "MXN", name: "Mexican peso", number: "484", minorUnit: 2);
        /// <summary>
        /// Mexican Unidad de Inversion (UDI) (funds code)
        /// </summary>
        public static Currency MXV { get; } = new Currency(alpha3: "MXV", name: "Mexican Unidad de Inversion (UDI) (funds code)", number: "979", minorUnit: 2);
        /// <summary>
        /// Malaysian ringgit
        /// </summary>
        public static Currency MYR { get; } = new Currency(alpha3: "MYR", name: "Malaysian ringgit", number: "458", minorUnit: 2);
        /// <summary>
        /// Mozambican metical
        /// </summary>
        public static Currency MZN { get; } = new Currency(alpha3: "MZN", name: "Mozambican metical", number: "943", minorUnit: 2);
        /// <summary>
        /// Namibian dollar
        /// </summary>
        public static Currency NAD { get; } = new Currency(alpha3: "NAD", name: "Namibian dollar", number: "516", minorUnit: 2);
        /// <summary>
        /// Nigerian naira
        /// </summary>
        public static Currency NGN { get; } = new Currency(alpha3: "NGN", name: "Nigerian naira", number: "566", minorUnit: 2);
        /// <summary>
        /// Nicaraguan córdoba
        /// </summary>
        public static Currency NIO { get; } = new Currency(alpha3: "NIO", name: "Nicaraguan córdoba", number: "558", minorUnit: 2);
        /// <summary>
        /// Norwegian krone
        /// </summary>
        public static Currency NOK { get; } = new Currency(alpha3: "NOK", name: "Norwegian krone", number: "578", minorUnit: 2);
        /// <summary>
        /// Nepalese rupee
        /// </summary>
        public static Currency NPR { get; } = new Currency(alpha3: "NPR", name: "Nepalese rupee", number: "524", minorUnit: 2);
        /// <summary>
        /// New Zealand dollar
        /// </summary>
        public static Currency NZD { get; } = new Currency(alpha3: "NZD", name: "New Zealand dollar", number: "554", minorUnit: 2);
        /// <summary>
        /// Omani rial
        /// </summary>
        public static Currency OMR { get; } = new Currency(alpha3: "OMR", name: "Omani rial", number: "512", minorUnit: 3);
        /// <summary>
        /// Panamanian balboa
        /// </summary>
        public static Currency PAB { get; } = new Currency(alpha3: "PAB", name: "Panamanian balboa", number: "590", minorUnit: 2);
        /// <summary>
        /// Peruvian nuevo sol
        /// </summary>
        public static Currency PEN { get; } = new Currency(alpha3: "PEN", name: "Peruvian nuevo sol", number: "604", minorUnit: 2);
        /// <summary>
        /// Papua New Guinean kina
        /// </summary>
        public static Currency PGK { get; } = new Currency(alpha3: "PGK", name: "Papua New Guinean kina", number: "598", minorUnit: 2);
        /// <summary>
        /// Philippine peso
        /// </summary>
        public static Currency PHP { get; } = new Currency(alpha3: "PHP", name: "Philippine peso", number: "608", minorUnit: 2);
        /// <summary>
        /// Pakistani rupee
        /// </summary>
        public static Currency PKR { get; } = new Currency(alpha3: "PKR", name: "Pakistani rupee", number: "586", minorUnit: 2);
        /// <summary>
        /// Polish złoty
        /// </summary>
        public static Currency PLN { get; } = new Currency(alpha3: "PLN", name: "Polish złoty", number: "985", minorUnit: 2);
        /// <summary>
        /// Paraguayan guaraní
        /// </summary>
        public static Currency PYG { get; } = new Currency(alpha3: "PYG", name: "Paraguayan guaraní", number: "600", minorUnit: 0);
        /// <summary>
        /// Qatari riyal
        /// </summary>
        public static Currency QAR { get; } = new Currency(alpha3: "QAR", name: "Qatari riyal", number: "634", minorUnit: 2);
        /// <summary>
        /// Romanian new leu
        /// </summary>
        public static Currency RON { get; } = new Currency(alpha3: "RON", name: "Romanian new leu", number: "946", minorUnit: 2);
        /// <summary>
        /// Serbian dinar
        /// </summary>
        public static Currency RSD { get; } = new Currency(alpha3: "RSD", name: "Serbian dinar", number: "941", minorUnit: 2);
        /// <summary>
        /// Russian rouble
        /// </summary>
        public static Currency RUB { get; } = new Currency(alpha3: "RUB", name: "Russian rouble", number: "643", minorUnit: 2);
        /// <summary>
        /// Rwandan franc
        /// </summary>
        public static Currency RWF { get; } = new Currency(alpha3: "RWF", name: "Rwandan franc", number: "646", minorUnit: 0);
        /// <summary>
        /// Saudi riyal
        /// </summary>
        public static Currency SAR { get; } = new Currency(alpha3: "SAR", name: "Saudi riyal", number: "682", minorUnit: 2);
        /// <summary>
        /// Solomon Islands dollar
        /// </summary>
        public static Currency SBD { get; } = new Currency(alpha3: "SBD", name: "Solomon Islands dollar", number: "90", minorUnit: 2);
        /// <summary>
        /// Seychelles rupee
        /// </summary>
        public static Currency SCR { get; } = new Currency(alpha3: "SCR", name: "Seychelles rupee", number: "690", minorUnit: 2);
        /// <summary>
        /// Sudanese pound
        /// </summary>
        public static Currency SDG { get; } = new Currency(alpha3: "SDG", name: "Sudanese pound", number: "938", minorUnit: 2);
        /// <summary>
        /// Swedish krona/kronor
        /// </summary>
        public static Currency SEK { get; } = new Currency(alpha3: "SEK", name: "Swedish krona/kronor", number: "752", minorUnit: 2);
        /// <summary>
        /// Singapore dollar
        /// </summary>
        public static Currency SGD { get; } = new Currency(alpha3: "SGD", name: "Singapore dollar", number: "702", minorUnit: 2);
        /// <summary>
        /// Saint Helena pound
        /// </summary>
        public static Currency SHP { get; } = new Currency(alpha3: "SHP", name: "Saint Helena pound", number: "654", minorUnit: 2);
        /// <summary>
        /// Sierra Leonean leone
        /// </summary>
        public static Currency SLL { get; } = new Currency(alpha3: "SLL", name: "Sierra Leonean leone", number: "694", minorUnit: 0);
        /// <summary>
        /// Somali shilling
        /// </summary>
        public static Currency SOS { get; } = new Currency(alpha3: "SOS", name: "Somali shilling", number: "706", minorUnit: 2);
        /// <summary>
        /// Surinamese dollar
        /// </summary>
        public static Currency SRD { get; } = new Currency(alpha3: "SRD", name: "Surinamese dollar", number: "968", minorUnit: 2);
        /// <summary>
        /// South Sudanese pound
        /// </summary>
        public static Currency SSP { get; } = new Currency(alpha3: "SSP", name: "South Sudanese pound", number: "728", minorUnit: 2);
        /// <summary>
        /// São Tomé and Príncipe dobra
        /// </summary>
        public static Currency STD { get; } = new Currency(alpha3: "STD", name: "São Tomé and Príncipe dobra", number: "678", minorUnit: 0);
        /// <summary>
        /// Syrian pound
        /// </summary>
        public static Currency SYP { get; } = new Currency(alpha3: "SYP", name: "Syrian pound", number: "760", minorUnit: 2);
        /// <summary>
        /// Swazi lilangeni
        /// </summary>
        public static Currency SZL { get; } = new Currency(alpha3: "SZL", name: "Swazi lilangeni", number: "748", minorUnit: 2);
        /// <summary>
        /// Thai baht
        /// </summary>
        public static Currency THB { get; } = new Currency(alpha3: "THB", name: "Thai baht", number: "764", minorUnit: 2);
        /// <summary>
        /// Tajikistani somoni
        /// </summary>
        public static Currency TJS { get; } = new Currency(alpha3: "TJS", name: "Tajikistani somoni", number: "972", minorUnit: 2);
        /// <summary>
        /// Turkmenistani manat
        /// </summary>
        public static Currency TMT { get; } = new Currency(alpha3: "TMT", name: "Turkmenistani manat", number: "934", minorUnit: 2);
        /// <summary>
        /// Tunisian dinar
        /// </summary>
        public static Currency TND { get; } = new Currency(alpha3: "TND", name: "Tunisian dinar", number: "788", minorUnit: 3);
        /// <summary>
        /// Tongan paʻanga
        /// </summary>
        public static Currency TOP { get; } = new Currency(alpha3: "TOP", name: "Tongan paʻanga", number: "776", minorUnit: 2);
        /// <summary>
        /// Turkish lira
        /// </summary>
        public static Currency TRY { get; } = new Currency(alpha3: "TRY", name: "Turkish lira", number: "949", minorUnit: 2);
        /// <summary>
        /// Trinidad and Tobago dollar
        /// </summary>
        public static Currency TTD { get; } = new Currency(alpha3: "TTD", name: "Trinidad and Tobago dollar", number: "780", minorUnit: 2);
        /// <summary>
        /// New Taiwan dollar
        /// </summary>
        public static Currency TWD { get; } = new Currency(alpha3: "TWD", name: "New Taiwan dollar", number: "901", minorUnit: 2);
        /// <summary>
        /// Tanzanian shilling
        /// </summary>
        public static Currency TZS { get; } = new Currency(alpha3: "TZS", name: "Tanzanian shilling", number: "834", minorUnit: 2);
        /// <summary>
        /// Ukrainian hryvnia
        /// </summary>
        public static Currency UAH { get; } = new Currency(alpha3: "UAH", name: "Ukrainian hryvnia", number: "980", minorUnit: 2);
        /// <summary>
        /// Ugandan shilling
        /// </summary>
        public static Currency UGX { get; } = new Currency(alpha3: "UGX", name: "Ugandan shilling", number: "800", minorUnit: 2);
        /// <summary>
        /// United States dollar
        /// </summary>
        public static Currency USD { get; } = new Currency(alpha3: "USD", name: "United States dollar", number: "840", minorUnit: 2);
        /// <summary>
        /// United States dollar (next day) (funds code)
        /// </summary>
        public static Currency USN { get; } = new Currency(alpha3: "USN", name: "United States dollar (next day) (funds code)", number: "997", minorUnit: 2);
        /// <summary>
        /// United States dollar (same day) (funds code)
        /// </summary>
        public static Currency USS { get; } = new Currency(alpha3: "USS", name: "United States dollar (same day) (funds code)", number: "998", minorUnit: 2);
        /// <summary>
        /// Uruguay Peso en Unidades Indexadas (URUIURUI) (funds code)
        /// </summary>
        public static Currency UYI { get; } = new Currency(alpha3: "UYI", name: "Uruguay Peso en Unidades Indexadas (URUIURUI) (funds code)", number: "940", minorUnit: 0);
        /// <summary>
        /// Uruguayan peso
        /// </summary>
        public static Currency UYU { get; } = new Currency(alpha3: "UYU", name: "Uruguayan peso", number: "858", minorUnit: 2);
        /// <summary>
        /// Uzbekistan som
        /// </summary>
        public static Currency UZS { get; } = new Currency(alpha3: "UZS", name: "Uzbekistan som", number: "860", minorUnit: 2);
        /// <summary>
        /// Venezuelan bolívar fuerte
        /// </summary>
        public static Currency VEF { get; } = new Currency(alpha3: "VEF", name: "Venezuelan bolívar fuerte", number: "937", minorUnit: 2);
        /// <summary>
        /// Vietnamese dong
        /// </summary>
        public static Currency VND { get; } = new Currency(alpha3: "VND", name: "Vietnamese dong", number: "704", minorUnit: 0);
        /// <summary>
        /// Vanuatu vatu
        /// </summary>
        public static Currency VUV { get; } = new Currency(alpha3: "VUV", name: "Vanuatu vatu", number: "548", minorUnit: 0);
        /// <summary>
        /// Samoan tala
        /// </summary>
        public static Currency WST { get; } = new Currency(alpha3: "WST", name: "Samoan tala", number: "882", minorUnit: 2);
        /// <summary>
        /// CFA franc BEAC
        /// </summary>
        public static Currency XAF { get; } = new Currency(alpha3: "XAF", name: "CFA franc BEAC", number: "950", minorUnit: 0);
        /// <summary>
        /// Silver (one troy ounce)
        /// </summary>
        public static Currency XAG { get; } = new Currency(alpha3: "XAG", name: "Silver (one troy ounce)", number: "961", minorUnit: 0);
        /// <summary>
        /// Gold (one troy ounce)
        /// </summary>
        public static Currency XAU { get; } = new Currency(alpha3: "XAU", name: "Gold (one troy ounce)", number: "959", minorUnit: 0);
        /// <summary>
        /// European Composite Unit (EURCO) (bond market unit)
        /// </summary>
        public static Currency XBA { get; } = new Currency(alpha3: "XBA", name: "European Composite Unit (EURCO) (bond market unit)", number: "955", minorUnit: 0);
        /// <summary>
        /// European Monetary Unit (E.M.U.-6) (bond market unit)
        /// </summary>
        public static Currency XBB { get; } = new Currency(alpha3: "XBB", name: "European Monetary Unit (E.M.U.-6) (bond market unit)", number: "956", minorUnit: 0);
        /// <summary>
        /// European Unit of Account 9 (E.U.A.-9) (bond market unit)
        /// </summary>
        public static Currency XBC { get; } = new Currency(alpha3: "XBC", name: "European Unit of Account 9 (E.U.A.-9) (bond market unit)", number: "957", minorUnit: 0);
        /// <summary>
        /// European Unit of Account 17 (E.U.A.-17) (bond market unit)
        /// </summary>
        public static Currency XBD { get; } = new Currency(alpha3: "XBD", name: "European Unit of Account 17 (E.U.A.-17) (bond market unit)", number: "958", minorUnit: 0);
        /// <summary>
        /// East Caribbean dollar
        /// </summary>
        public static Currency XCD { get; } = new Currency(alpha3: "XCD", name: "East Caribbean dollar", number: "951", minorUnit: 2);
        /// <summary>
        /// Special drawing rights
        /// </summary>
        public static Currency XDR { get; } = new Currency(alpha3: "XDR", name: "Special drawing rights", number: "960", minorUnit: 0);
        /// <summary>
        /// UIC franc (special settlement currency)
        /// </summary>
        public static Currency XFU { get; } = new Currency(alpha3: "XFU", name: "UIC franc (special settlement currency)", number: "null", minorUnit: 0);
        /// <summary>
        /// CFA franc BCEAO
        /// </summary>
        public static Currency XOF { get; } = new Currency(alpha3: "XOF", name: "CFA franc BCEAO", number: "952", minorUnit: 0);
        /// <summary>
        /// Palladium (one troy ounce)
        /// </summary>
        public static Currency XPD { get; } = new Currency(alpha3: "XPD", name: "Palladium (one troy ounce)", number: "964", minorUnit: 0);
        /// <summary>
        /// CFP franc
        /// </summary>
        public static Currency XPF { get; } = new Currency(alpha3: "XPF", name: "CFP franc", number: "953", minorUnit: 0);
        /// <summary>
        /// Platinum (one troy ounce)
        /// </summary>
        public static Currency XPT { get; } = new Currency(alpha3: "XPT", name: "Platinum (one troy ounce)", number: "962", minorUnit: 0);
        /// <summary>
        /// Code reserved for testing purposes
        /// </summary>
        public static Currency XTS { get; } = new Currency(alpha3: "XTS", name: "Code reserved for testing purposes", number: "963", minorUnit: 0);
        /// <summary>
        /// No currency
        /// </summary>
        public static Currency XXX { get; } = new Currency(alpha3: "XXX", name: "No currency", number: "999", minorUnit: 0);
        /// <summary>
        /// Yemeni rial
        /// </summary>
        public static Currency YER { get; } = new Currency(alpha3: "YER", name: "Yemeni rial", number: "886", minorUnit: 2);
        /// <summary>
        /// South African rand
        /// </summary>
        public static Currency ZAR { get; } = new Currency(alpha3: "ZAR", name: "South African rand", number: "710", minorUnit: 2);
        /// <summary>
        /// Zambian kwacha
        /// </summary>
        public static Currency ZMW { get; } = new Currency(alpha3: "ZMW", name: "Zambian kwacha", number: "967", minorUnit: 2);
        #endregion
    }
}
