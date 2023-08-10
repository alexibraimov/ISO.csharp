namespace ISOLib
{
    using ISOLib.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Languages : ReadOnlyCollection<Language>, IISO
    {
        static Languages()
        {
            Collection = new Languages();
        }

        private Languages() : base(new Language[] { AA, AB, AE, AF, AK, AM, AN, AV, AS, AR, AZ, AY, BA, BE, BG, BH, BI, BM, BN, BO, BR, BS, CA, CE, CH, CO, CR, CS, CU, CV, CY, DA, DE, DV, DZ, EE, EL, EN, EO, ES, ET, EU, FA, FF, FI, FJ, FO, FR, FY, GA, GD, GL, GN, GU, GV, HA, HE, HI, HO, HR, HT, HU, HY, HZ, IA, ID, IE, IG, II, IK, IO, IS, IT, IU, JA, JV, KA, KG, KI, KJ, KK, KL, KM, KN, KO, KR, KS, KU, KV, KW, KY, LA, LB, LG, LI, LN, LO, LT, LU, LV, MG, MH, MI, MK, ML, MN, MR, MS, MT, MY, NA, NB, ND, NE, NG, NL, NN, NO, NR, NV, NY, OC, OJ, OM, OR, OS, PA, PI, PL, PS, PT, QU, RM, RN, RO, RU, RW, SA, SC, SD, SE, SG, SI, SK, SL, SM, SN, SO, SQ, SR, SS, ST, SU, SV, SW, TA, TE, TG, TH, TI, TK, TL, TN, TO, TR, TS, TT, TW, TY, UG, UK, UR, UZ, VE, VI, VO, WA, WO, XH, YI, YO, ZA, ZH, ZU, })
        {
        }

        public int Number { get; } = 639;
        public string Name { get; } = "ISO 639";
        public string Wiki { get; } = "https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes";
        /// <summary>
        /// Gets the collection of languages defined by the ISO 639 standard.
        /// </summary>
        public static Languages Collection { get; }
        /// <summary>
        /// Gets the <see cref="Language"/> object corresponding to the specified language name, Alpha-2 code, or Alpha-3 code.
        /// </summary>
        /// <param name="key">The name, Alpha-2 code, or Alpha-3 code of the language to retrieve.</param>
        /// <returns>The <see cref="Language"/> object representing the specified language.</returns>
        /// <exception cref="ArgumentException">Thrown when the specified language name, Alpha-2 code, or Alpha-3 code does not match any language in the collection.</exception>
        public Language this[string key]
        {
            get
            {
                if (TryGetValue(key, out Language language))
                {
                    return language;
                }

                throw new ArgumentException("Language not found", nameof(key));
            }
        }
        /// <summary>
        /// Tries to retrieve a language by its key (name, alpha2, or alpha3) from the collection of languages.
        /// </summary>
        /// <param name="key">The key (name, alpha2, or alpha3) of the language to retrieve.</param>
        /// <param name="language">When this method returns, contains the retrieved language or null if not found.</param>
        /// <returns>True if the language was found; otherwise, false.</returns>
        public bool TryGetValue(string key, out Language language)
        {
            if (string.IsNullOrEmpty(key))
            {
                language = null;
            }
            else
            {
                language = Items.FirstOrDefault(l =>
                    l.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase) ||
                    l.Alpha2.Equals(key, StringComparison.InvariantCultureIgnoreCase) ||
                    l.Alpha3.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            }

            return language != null;
        }
        /// <summary>
        /// Gets a language by its ISO 639-1 alpha-2 code.
        /// </summary>
        public static Language GetByAlpha2Code(string alpha2)
        {
            return Collection.FirstOrDefault(c => c.Alpha2.Equals(alpha2, StringComparison.InvariantCultureIgnoreCase));
        }
        /// <summary>
        /// Gets a language by its ISO 639-2/T alpha-3 code.
        /// </summary>
        public static Language GetByAlpha3Code(string alpha3)
        {
            return Collection.FirstOrDefault(c => c.Alpha3.Equals(alpha3, StringComparison.InvariantCultureIgnoreCase));
        }
        /// <summary>
        /// Gets a language by its name or alternative name.
        /// </summary>
        public static Language GetByName(string name)
        {
            return Collection.FirstOrDefault(c => c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) || c.Name2.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
        /// <summary>
        /// Gets an array of language names.
        /// </summary>
        public static string[] GetNames()
        {
            return Collection.Select(c => c.Name).ToArray();
        }
        /// <summary>
        /// Gets an array of ISO 639-1 alpha-2 codes.
        /// </summary>
        public static string[] GetAlpha2Codes()
        {
            return Collection.Select(c => c.Alpha2).ToArray();
        }
        /// <summary>
        /// Gets an array of ISO 639-2/T alpha-3 codes.
        /// </summary>
        public static string[] GetAlpha3Codes()
        {
            return Collection.Select(c => c.Alpha3).ToArray();
        }
        /// <summary>
        /// Filters and returns an array of languages based on their keys.
        /// </summary>
        /// <param name="langKeys">The keys of the languages to filter by.</param>
        /// <returns>An array of filtered languages.</returns>
        public static Language[] FilterLanguages(params string[] langKeys)
        {
            var filteredLanguages = new List<Language>();

            foreach (var key in langKeys)
            {
                if (Collection.TryGetValue(key, out Language language))
                {
                    filteredLanguages.Add(language);
                }
            }

            return filteredLanguages.ToArray();
        }
        #region Alpha2
        /// <summary>
        /// Afar
        /// </summary>
        public static Language AA { get; } = new Language(alpha2: "aa", alpha3: "aar", name: "Afar", name2: "Afar", nativeName: "Afar", family: "Afro-Asiatic");
        /// <summary>
        /// Abkhaz
        /// </summary>
        public static Language AB { get; } = new Language(alpha2: "ab", alpha3: "abk", name: "Abkhaz", name2: "Abkhazian", nativeName: "Аҧсуа", family: "Northwest Caucasian");
        /// <summary>
        /// Avestan
        /// </summary>
        public static Language AE { get; } = new Language(alpha2: "ae", alpha3: "ave", name: "Avestan", name2: "Avestan", nativeName: "avesta", family: "Indo-European");
        /// <summary>
        /// Afrikaans
        /// </summary>
        public static Language AF { get; } = new Language(alpha2: "af", alpha3: "afr", name: "Afrikaans", name2: "Afrikaans", nativeName: "Afrikaans", family: "Indo-European");
        /// <summary>
        /// Akan
        /// </summary>
        public static Language AK { get; } = new Language(alpha2: "ak", alpha3: "aka", name: "Akan", name2: "Akan", nativeName: "Akana", family: "Niger–Congo");
        /// <summary>
        /// Amharic
        /// </summary>
        public static Language AM { get; } = new Language(alpha2: "am", alpha3: "amh", name: "Amharic", name2: "Amharic", nativeName: "አማርኛ", family: "Afro-Asiatic");
        /// <summary>
        /// Aragonese
        /// </summary>
        public static Language AN { get; } = new Language(alpha2: "an", alpha3: "arg", name: "Aragonese", name2: "Aragonese", nativeName: "Aragonés", family: "Indo-European");
        /// <summary>
        /// Avaric
        /// </summary>
        public static Language AV { get; } = new Language(alpha2: "av", alpha3: "ava", name: "Avaric", name2: "Avar", nativeName: "Авар", family: "Northeast Caucasian");
        /// <summary>
        /// Assamese
        /// </summary>
        public static Language AS { get; } = new Language(alpha2: "as", alpha3: "asm", name: "Assamese", name2: "Assamese", nativeName: "অসমীয়া", family: "Indo-European");
        /// <summary>
        /// Arabic
        /// </summary>
        public static Language AR { get; } = new Language(alpha2: "ar", alpha3: "ara", name: "Arabic", name2: "Arabic", nativeName: "العربية", family: "Afro-Asiatic");
        /// <summary>
        /// Azerbaijani
        /// </summary>
        public static Language AZ { get; } = new Language(alpha2: "az", alpha3: "aze", name: "Azerbaijani", name2: "Azerbaijani", nativeName: "Azərbaycanca / آذربايجان", family: "Turkic");
        /// <summary>
        /// Aymara
        /// </summary>
        public static Language AY { get; } = new Language(alpha2: "ay", alpha3: "aym", name: "Aymara", name2: "Aymara", nativeName: "Aymar", family: "Aymaran");
        /// <summary>
        /// Bashkir
        /// </summary>
        public static Language BA { get; } = new Language(alpha2: "ba", alpha3: "bak", name: "Bashkir", name2: "Bashkir", nativeName: "Башҡорт", family: "Turkic");
        /// <summary>
        /// Belarusian
        /// </summary>
        public static Language BE { get; } = new Language(alpha2: "be", alpha3: "bel", name: "Belarusian", name2: "Belarusian", nativeName: "Беларуская", family: "Indo-European");
        /// <summary>
        /// Bulgarian
        /// </summary>
        public static Language BG { get; } = new Language(alpha2: "bg", alpha3: "bul", name: "Bulgarian", name2: "Bulgarian", nativeName: "Български", family: "Indo-European");
        /// <summary>
        /// Bihari
        /// </summary>
        public static Language BH { get; } = new Language(alpha2: "bh", alpha3: "bih", name: "Bihari", name2: "Bihari", nativeName: "भोजपुरी", family: "Indo-European");
        /// <summary>
        /// Bislama
        /// </summary>
        public static Language BI { get; } = new Language(alpha2: "bi", alpha3: "bis", name: "Bislama", name2: "Bislama", nativeName: "Bislama", family: "Creole");
        /// <summary>
        /// Bambara
        /// </summary>
        public static Language BM { get; } = new Language(alpha2: "bm", alpha3: "bam", name: "Bambara", name2: "Bambara", nativeName: "Bamanankan", family: "Niger–Congo");
        /// <summary>
        /// Bengali, Bangla
        /// </summary>
        public static Language BN { get; } = new Language(alpha2: "bn", alpha3: "ben", name: "Bengali, Bangla", name2: "Bengali", nativeName: "বাংলা", family: "Indo-European");
        /// <summary>
        /// Tibetan Standard, Tibetan, Central
        /// </summary>
        public static Language BO { get; } = new Language(alpha2: "bo", alpha3: "bod", name: "Tibetan Standard, Tibetan, Central", name2: "Tibetan", nativeName: "བོད་ཡིག / Bod skad", family: "Sino-Tibetan");
        /// <summary>
        /// Breton
        /// </summary>
        public static Language BR { get; } = new Language(alpha2: "br", alpha3: "bre", name: "Breton", name2: "Breton", nativeName: "Brezhoneg", family: "Indo-European");
        /// <summary>
        /// Bosnian
        /// </summary>
        public static Language BS { get; } = new Language(alpha2: "bs", alpha3: "bos", name: "Bosnian", name2: "Bosnian", nativeName: "Bosanski", family: "Indo-European");
        /// <summary>
        /// Catalan
        /// </summary>
        public static Language CA { get; } = new Language(alpha2: "ca", alpha3: "cat", name: "Catalan", name2: "Catalan", nativeName: "Català", family: "Indo-European");
        /// <summary>
        /// Chechen
        /// </summary>
        public static Language CE { get; } = new Language(alpha2: "ce", alpha3: "che", name: "Chechen", name2: "Chechen", nativeName: "Нохчийн", family: "Northeast Caucasian");
        /// <summary>
        /// Chamorro
        /// </summary>
        public static Language CH { get; } = new Language(alpha2: "ch", alpha3: "cha", name: "Chamorro", name2: "Chamorro", nativeName: "Chamoru", family: "Austronesian");
        /// <summary>
        /// Corsican
        /// </summary>
        public static Language CO { get; } = new Language(alpha2: "co", alpha3: "cos", name: "Corsican", name2: "Corsican", nativeName: "Corsu", family: "Indo-European");
        /// <summary>
        /// Cree
        /// </summary>
        public static Language CR { get; } = new Language(alpha2: "cr", alpha3: "cre", name: "Cree", name2: "Cree", nativeName: "Nehiyaw", family: "Algonquian");
        /// <summary>
        /// Czech
        /// </summary>
        public static Language CS { get; } = new Language(alpha2: "cs", alpha3: "ces", name: "Czech", name2: "Czech", nativeName: "Čeština", family: "Indo-European");
        /// <summary>
        /// Old Church Slavonic, Church Slavonic, Old Bulgarian
        /// </summary>
        public static Language CU { get; } = new Language(alpha2: "cu", alpha3: "chu", name: "Old Church Slavonic, Church Slavonic, Old Bulgarian", name2: "Old Church Slavonic / Old Bulgarian", nativeName: "словѣньскъ / slověnĭskŭ", family: "Indo-European");
        /// <summary>
        /// Chuvash
        /// </summary>
        public static Language CV { get; } = new Language(alpha2: "cv", alpha3: "chv", name: "Chuvash", name2: "Chuvash", nativeName: "Чăваш", family: "Turkic");
        /// <summary>
        /// Welsh
        /// </summary>
        public static Language CY { get; } = new Language(alpha2: "cy", alpha3: "cym", name: "Welsh", name2: "Welsh", nativeName: "Cymraeg", family: "Indo-European");
        /// <summary>
        /// Danish
        /// </summary>
        public static Language DA { get; } = new Language(alpha2: "da", alpha3: "dan", name: "Danish", name2: "Danish", nativeName: "Dansk", family: "Indo-European");
        /// <summary>
        /// German
        /// </summary>
        public static Language DE { get; } = new Language(alpha2: "de", alpha3: "deu", name: "German", name2: "German", nativeName: "Deutsch", family: "Indo-European");
        /// <summary>
        /// Divehi, Dhivehi, Maldivian
        /// </summary>
        public static Language DV { get; } = new Language(alpha2: "dv", alpha3: "div", name: "Divehi, Dhivehi, Maldivian", name2: "Divehi", nativeName: "ދިވެހިބަސް", family: "Indo-European");
        /// <summary>
        /// Dzongkha
        /// </summary>
        public static Language DZ { get; } = new Language(alpha2: "dz", alpha3: "dzo", name: "Dzongkha", name2: "Dzongkha", nativeName: "ཇོང་ཁ", family: "Sino-Tibetan");
        /// <summary>
        /// Ewe
        /// </summary>
        public static Language EE { get; } = new Language(alpha2: "ee", alpha3: "ewe", name: "Ewe", name2: "Ewe", nativeName: "Ɛʋɛ", family: "Niger–Congo");
        /// <summary>
        /// Greek (modern)
        /// </summary>
        public static Language EL { get; } = new Language(alpha2: "el", alpha3: "ell", name: "Greek (modern)", name2: "Greek", nativeName: "Ελληνικά", family: "Indo-European");
        /// <summary>
        /// English
        /// </summary>
        public static Language EN { get; } = new Language(alpha2: "en", alpha3: "eng", name: "English", name2: "English", nativeName: "English", family: "Indo-European");
        /// <summary>
        /// Esperanto
        /// </summary>
        public static Language EO { get; } = new Language(alpha2: "eo", alpha3: "epo", name: "Esperanto", name2: "Esperanto", nativeName: "Esperanto", family: "Constructed");
        /// <summary>
        /// Spanish
        /// </summary>
        public static Language ES { get; } = new Language(alpha2: "es", alpha3: "spa", name: "Spanish", name2: "Spanish", nativeName: "Español", family: "Indo-European");
        /// <summary>
        /// Estonian
        /// </summary>
        public static Language ET { get; } = new Language(alpha2: "et", alpha3: "est", name: "Estonian", name2: "Estonian", nativeName: "Eesti", family: "Uralic");
        /// <summary>
        /// Basque
        /// </summary>
        public static Language EU { get; } = new Language(alpha2: "eu", alpha3: "eus", name: "Basque", name2: "Basque", nativeName: "Euskara", family: "Language isolate");
        /// <summary>
        /// Persian (Farsi)
        /// </summary>
        public static Language FA { get; } = new Language(alpha2: "fa", alpha3: "fas", name: "Persian (Farsi)", name2: "Persian", nativeName: "فارسی", family: "Indo-European");
        /// <summary>
        /// Fula, Fulah, Pulaar, Pular
        /// </summary>
        public static Language FF { get; } = new Language(alpha2: "ff", alpha3: "ful", name: "Fula, Fulah, Pulaar, Pular", name2: "Peul", nativeName: "Fulfulde", family: "Niger–Congo");
        /// <summary>
        /// Finnish
        /// </summary>
        public static Language FI { get; } = new Language(alpha2: "fi", alpha3: "fin", name: "Finnish", name2: "Finnish", nativeName: "Suomi", family: "Uralic");
        /// <summary>
        /// Fijian
        /// </summary>
        public static Language FJ { get; } = new Language(alpha2: "fj", alpha3: "fij", name: "Fijian", name2: "Fijian", nativeName: "Na Vosa Vakaviti", family: "Austronesian");
        /// <summary>
        /// Faroese
        /// </summary>
        public static Language FO { get; } = new Language(alpha2: "fo", alpha3: "fao", name: "Faroese", name2: "Faroese", nativeName: "Føroyskt", family: "Indo-European");
        /// <summary>
        /// French
        /// </summary>
        public static Language FR { get; } = new Language(alpha2: "fr", alpha3: "fra", name: "French", name2: "French", nativeName: "Français", family: "Indo-European");
        /// <summary>
        /// Western Frisian
        /// </summary>
        public static Language FY { get; } = new Language(alpha2: "fy", alpha3: "fry", name: "Western Frisian", name2: "West Frisian", nativeName: "Frysk", family: "Indo-European");
        /// <summary>
        /// Irish
        /// </summary>
        public static Language GA { get; } = new Language(alpha2: "ga", alpha3: "gle", name: "Irish", name2: "Irish", nativeName: "Gaeilge", family: "Indo-European");
        /// <summary>
        /// Scottish Gaelic, Gaelic
        /// </summary>
        public static Language GD { get; } = new Language(alpha2: "gd", alpha3: "gla", name: "Scottish Gaelic, Gaelic", name2: "Scottish Gaelic", nativeName: "Gàidhlig", family: "Indo-European");
        /// <summary>
        /// Galician
        /// </summary>
        public static Language GL { get; } = new Language(alpha2: "gl", alpha3: "glg", name: "Galician", name2: "Galician", nativeName: "Galego", family: "Indo-European");
        /// <summary>
        /// Guaraní
        /// </summary>
        public static Language GN { get; } = new Language(alpha2: "gn", alpha3: "grn", name: "Guaraní", name2: "Guarani", nativeName: "Avañe'ẽ", family: "Tupian");
        /// <summary>
        /// Gujarati
        /// </summary>
        public static Language GU { get; } = new Language(alpha2: "gu", alpha3: "guj", name: "Gujarati", name2: "Gujarati", nativeName: "ગુજરાતી", family: "Indo-European");
        /// <summary>
        /// Manx
        /// </summary>
        public static Language GV { get; } = new Language(alpha2: "gv", alpha3: "glv", name: "Manx", name2: "Manx", nativeName: "Gaelg", family: "Indo-European");
        /// <summary>
        /// Hausa
        /// </summary>
        public static Language HA { get; } = new Language(alpha2: "ha", alpha3: "hau", name: "Hausa", name2: "Hausa", nativeName: "هَوُسَ", family: "Afro-Asiatic");
        /// <summary>
        /// Hebrew (modern)
        /// </summary>
        public static Language HE { get; } = new Language(alpha2: "he", alpha3: "heb", name: "Hebrew (modern)", name2: "Hebrew", nativeName: "עברית", family: "Afro-Asiatic");
        /// <summary>
        /// Hindi
        /// </summary>
        public static Language HI { get; } = new Language(alpha2: "hi", alpha3: "hin", name: "Hindi", name2: "Hindi", nativeName: "हिन्दी", family: "Indo-European");
        /// <summary>
        /// Hiri Motu
        /// </summary>
        public static Language HO { get; } = new Language(alpha2: "ho", alpha3: "hmo", name: "Hiri Motu", name2: "Hiri Motu", nativeName: "Hiri Motu", family: "Austronesian");
        /// <summary>
        /// Croatian
        /// </summary>
        public static Language HR { get; } = new Language(alpha2: "hr", alpha3: "hrv", name: "Croatian", name2: "Croatian", nativeName: "Hrvatski", family: "Indo-European");
        /// <summary>
        /// Haitian, Haitian Creole
        /// </summary>
        public static Language HT { get; } = new Language(alpha2: "ht", alpha3: "hat", name: "Haitian, Haitian Creole", name2: "Haitian", nativeName: "Krèyol ayisyen", family: "Creole");
        /// <summary>
        /// Hungarian
        /// </summary>
        public static Language HU { get; } = new Language(alpha2: "hu", alpha3: "hun", name: "Hungarian", name2: "Hungarian", nativeName: "Magyar", family: "Uralic");
        /// <summary>
        /// Armenian
        /// </summary>
        public static Language HY { get; } = new Language(alpha2: "hy", alpha3: "hye", name: "Armenian", name2: "Armenian", nativeName: "Հայերեն", family: "Indo-European");
        /// <summary>
        /// Herero
        /// </summary>
        public static Language HZ { get; } = new Language(alpha2: "hz", alpha3: "her", name: "Herero", name2: "Herero", nativeName: "Otsiherero", family: "Niger–Congo");
        /// <summary>
        /// Interlingua
        /// </summary>
        public static Language IA { get; } = new Language(alpha2: "ia", alpha3: "ina", name: "Interlingua", name2: "Interlingua", nativeName: "Interlingua", family: "Constructed");
        /// <summary>
        /// Indonesian
        /// </summary>
        public static Language ID { get; } = new Language(alpha2: "id", alpha3: "ind", name: "Indonesian", name2: "Indonesian", nativeName: "Bahasa Indonesia", family: "Austronesian");
        /// <summary>
        /// Interlingue
        /// </summary>
        public static Language IE { get; } = new Language(alpha2: "ie", alpha3: "ile", name: "Interlingue", name2: "Interlingue", nativeName: "Interlingue", family: "Constructed");
        /// <summary>
        /// Igbo
        /// </summary>
        public static Language IG { get; } = new Language(alpha2: "ig", alpha3: "ibo", name: "Igbo", name2: "Igbo", nativeName: "Igbo", family: "Niger–Congo");
        /// <summary>
        /// Nuosu
        /// </summary>
        public static Language II { get; } = new Language(alpha2: "ii", alpha3: "iii", name: "Nuosu", name2: "Sichuan Yi", nativeName: "ꆇꉙ / 四川彝语", family: "Sino-Tibetan");
        /// <summary>
        /// Inupiaq
        /// </summary>
        public static Language IK { get; } = new Language(alpha2: "ik", alpha3: "ipk", name: "Inupiaq", name2: "Inupiak", nativeName: "Iñupiak", family: "Eskimo–Aleut");
        /// <summary>
        /// Ido
        /// </summary>
        public static Language IO { get; } = new Language(alpha2: "io", alpha3: "ido", name: "Ido", name2: "Ido", nativeName: "Ido", family: "Constructed");
        /// <summary>
        /// Icelandic
        /// </summary>
        public static Language IS { get; } = new Language(alpha2: "is", alpha3: "isl", name: "Icelandic", name2: "Icelandic", nativeName: "Íslenska", family: "Indo-European");
        /// <summary>
        /// Italian
        /// </summary>
        public static Language IT { get; } = new Language(alpha2: "it", alpha3: "ita", name: "Italian", name2: "Italian", nativeName: "Italiano", family: "Indo-European");
        /// <summary>
        /// Inuktitut
        /// </summary>
        public static Language IU { get; } = new Language(alpha2: "iu", alpha3: "iku", name: "Inuktitut", name2: "Inuktitut", nativeName: "ᐃᓄᒃᑎᑐᑦ", family: "Eskimo–Aleut");
        /// <summary>
        /// Japanese
        /// </summary>
        public static Language JA { get; } = new Language(alpha2: "ja", alpha3: "jpn", name: "Japanese", name2: "Japanese", nativeName: "日本語", family: "Japonic");
        /// <summary>
        /// Javanese
        /// </summary>
        public static Language JV { get; } = new Language(alpha2: "jv", alpha3: "jav", name: "Javanese", name2: "Javanese", nativeName: "Basa Jawa", family: "Austronesian");
        /// <summary>
        /// Georgian
        /// </summary>
        public static Language KA { get; } = new Language(alpha2: "ka", alpha3: "kat", name: "Georgian", name2: "Georgian", nativeName: "ქართული", family: "South Caucasian");
        /// <summary>
        /// Kongo
        /// </summary>
        public static Language KG { get; } = new Language(alpha2: "kg", alpha3: "kon", name: "Kongo", name2: "Kongo", nativeName: "KiKongo", family: "Niger–Congo");
        /// <summary>
        /// Kikuyu, Gikuyu
        /// </summary>
        public static Language KI { get; } = new Language(alpha2: "ki", alpha3: "kik", name: "Kikuyu, Gikuyu", name2: "Kikuyu", nativeName: "Gĩkũyũ", family: "Niger–Congo");
        /// <summary>
        /// Kwanyama, Kuanyama
        /// </summary>
        public static Language KJ { get; } = new Language(alpha2: "kj", alpha3: "kua", name: "Kwanyama, Kuanyama", name2: "Kuanyama", nativeName: "Kuanyama", family: "Niger–Congo");
        /// <summary>
        /// Kazakh
        /// </summary>
        public static Language KK { get; } = new Language(alpha2: "kk", alpha3: "kaz", name: "Kazakh", name2: "Kazakh", nativeName: "Қазақша", family: "Turkic");
        /// <summary>
        /// Kalaallisut, Greenlandic
        /// </summary>
        public static Language KL { get; } = new Language(alpha2: "kl", alpha3: "kal", name: "Kalaallisut, Greenlandic", name2: "Greenlandic", nativeName: "Kalaallisut", family: "Eskimo–Aleut");
        /// <summary>
        /// Khmer
        /// </summary>
        public static Language KM { get; } = new Language(alpha2: "km", alpha3: "khm", name: "Khmer", name2: "Cambodian", nativeName: "ភាសាខ្មែរ", family: "Austroasiatic");
        /// <summary>
        /// Kannada
        /// </summary>
        public static Language KN { get; } = new Language(alpha2: "kn", alpha3: "kan", name: "Kannada", name2: "Kannada", nativeName: "ಕನ್ನಡ", family: "Dravidian");
        /// <summary>
        /// Korean
        /// </summary>
        public static Language KO { get; } = new Language(alpha2: "ko", alpha3: "kor", name: "Korean", name2: "Korean", nativeName: "한국어", family: "Koreanic");
        /// <summary>
        /// Kanuri
        /// </summary>
        public static Language KR { get; } = new Language(alpha2: "kr", alpha3: "kau", name: "Kanuri", name2: "Kanuri", nativeName: "Kanuri", family: "Nilo-Saharan");
        /// <summary>
        /// Kashmiri
        /// </summary>
        public static Language KS { get; } = new Language(alpha2: "ks", alpha3: "kas", name: "Kashmiri", name2: "Kashmiri", nativeName: "कश्मीरी / كشميري", family: "Indo-European");
        /// <summary>
        /// Kurdish
        /// </summary>
        public static Language KU { get; } = new Language(alpha2: "ku", alpha3: "kur", name: "Kurdish", name2: "Kurdish", nativeName: "Kurdî / كوردی", family: "Indo-European");
        /// <summary>
        /// Komi
        /// </summary>
        public static Language KV { get; } = new Language(alpha2: "kv", alpha3: "kom", name: "Komi", name2: "Komi", nativeName: "Коми", family: "Uralic");
        /// <summary>
        /// Cornish
        /// </summary>
        public static Language KW { get; } = new Language(alpha2: "kw", alpha3: "cor", name: "Cornish", name2: "Cornish", nativeName: "Kernewek", family: "Indo-European");
        /// <summary>
        /// Kyrgyz
        /// </summary>
        public static Language KY { get; } = new Language(alpha2: "ky", alpha3: "kir", name: "Kyrgyz", name2: "Kyrgyz", nativeName: "Кыргызча", family: "Turkic");
        /// <summary>
        /// Latin
        /// </summary>
        public static Language LA { get; } = new Language(alpha2: "la", alpha3: "lat", name: "Latin", name2: "Latin", nativeName: "Latina", family: "Indo-European");
        /// <summary>
        /// Luxembourgish, Letzeburgesch
        /// </summary>
        public static Language LB { get; } = new Language(alpha2: "lb", alpha3: "ltz", name: "Luxembourgish, Letzeburgesch", name2: "Luxembourgish", nativeName: "Lëtzebuergesch", family: "Indo-European");
        /// <summary>
        /// Ganda
        /// </summary>
        public static Language LG { get; } = new Language(alpha2: "lg", alpha3: "lug", name: "Ganda", name2: "Ganda", nativeName: "Luganda", family: "Niger–Congo");
        /// <summary>
        /// Limburgish, Limburgan, Limburger
        /// </summary>
        public static Language LI { get; } = new Language(alpha2: "li", alpha3: "lim", name: "Limburgish, Limburgan, Limburger", name2: "Limburgian", nativeName: "Limburgs", family: "Indo-European");
        /// <summary>
        /// Lingala
        /// </summary>
        public static Language LN { get; } = new Language(alpha2: "ln", alpha3: "lin", name: "Lingala", name2: "Lingala", nativeName: "Lingála", family: "Niger–Congo");
        /// <summary>
        /// Lao
        /// </summary>
        public static Language LO { get; } = new Language(alpha2: "lo", alpha3: "lao", name: "Lao", name2: "Laotian", nativeName: "ລາວ / Pha xa lao", family: "Tai–Kadai");
        /// <summary>
        /// Lithuanian
        /// </summary>
        public static Language LT { get; } = new Language(alpha2: "lt", alpha3: "lit", name: "Lithuanian", name2: "Lithuanian", nativeName: "Lietuvių", family: "Indo-European");
        /// <summary>
        /// Luba-Katanga
        /// </summary>
        public static Language LU { get; } = new Language(alpha2: "lu", alpha3: "lub", name: "Luba-Katanga", name2: "Luba-Katanga", nativeName: "Tshiluba", family: "Niger–Congo");
        /// <summary>
        /// Latvian
        /// </summary>
        public static Language LV { get; } = new Language(alpha2: "lv", alpha3: "lav", name: "Latvian", name2: "Latvian", nativeName: "Latviešu", family: "Indo-European");
        /// <summary>
        /// Malagasy
        /// </summary>
        public static Language MG { get; } = new Language(alpha2: "mg", alpha3: "mlg", name: "Malagasy", name2: "Malagasy", nativeName: "Malagasy", family: "Austronesian");
        /// <summary>
        /// Marshallese
        /// </summary>
        public static Language MH { get; } = new Language(alpha2: "mh", alpha3: "mah", name: "Marshallese", name2: "Marshallese", nativeName: "Kajin Majel / Ebon", family: "Austronesian");
        /// <summary>
        /// Māori
        /// </summary>
        public static Language MI { get; } = new Language(alpha2: "mi", alpha3: "mri", name: "Māori", name2: "Maori", nativeName: "Māori", family: "Austronesian");
        /// <summary>
        /// Macedonian
        /// </summary>
        public static Language MK { get; } = new Language(alpha2: "mk", alpha3: "mkd", name: "Macedonian", name2: "Macedonian", nativeName: "Македонски", family: "Indo-European");
        /// <summary>
        /// Malayalam
        /// </summary>
        public static Language ML { get; } = new Language(alpha2: "ml", alpha3: "mal", name: "Malayalam", name2: "Malayalam", nativeName: "മലയാളം", family: "Dravidian");
        /// <summary>
        /// Mongolian
        /// </summary>
        public static Language MN { get; } = new Language(alpha2: "mn", alpha3: "mon", name: "Mongolian", name2: "Mongolian", nativeName: "Монгол", family: "Mongolic");
        /// <summary>
        /// Marathi (Marāṭhī)
        /// </summary>
        public static Language MR { get; } = new Language(alpha2: "mr", alpha3: "mar", name: "Marathi (Marāṭhī)", name2: "Marathi", nativeName: "मराठी", family: "Indo-European");
        /// <summary>
        /// Malay
        /// </summary>
        public static Language MS { get; } = new Language(alpha2: "ms", alpha3: "msa", name: "Malay", name2: "Malay", nativeName: "Bahasa Melayu", family: "Austronesian");
        /// <summary>
        /// Maltese
        /// </summary>
        public static Language MT { get; } = new Language(alpha2: "mt", alpha3: "mlt", name: "Maltese", name2: "Maltese", nativeName: "bil-Malti", family: "Afro-Asiatic");
        /// <summary>
        /// Burmese
        /// </summary>
        public static Language MY { get; } = new Language(alpha2: "my", alpha3: "mya", name: "Burmese", name2: "Burmese", nativeName: "မြန်မာစာ", family: "Sino-Tibetan");
        /// <summary>
        /// Nauruan
        /// </summary>
        public static Language NA { get; } = new Language(alpha2: "na", alpha3: "nau", name: "Nauruan", name2: "Nauruan", nativeName: "Dorerin Naoero", family: "Austronesian");
        /// <summary>
        /// Norwegian Bokmål
        /// </summary>
        public static Language NB { get; } = new Language(alpha2: "nb", alpha3: "nob", name: "Norwegian Bokmål", name2: "Norwegian Bokmål", nativeName: "Norsk bokmål", family: "Indo-European");
        /// <summary>
        /// Northern Ndebele
        /// </summary>
        public static Language ND { get; } = new Language(alpha2: "nd", alpha3: "nde", name: "Northern Ndebele", name2: "North Ndebele", nativeName: "Sindebele", family: "Niger–Congo");
        /// <summary>
        /// Nepali
        /// </summary>
        public static Language NE { get; } = new Language(alpha2: "ne", alpha3: "nep", name: "Nepali", name2: "Nepali", nativeName: "नेपाली", family: "Indo-European");
        /// <summary>
        /// Ndonga
        /// </summary>
        public static Language NG { get; } = new Language(alpha2: "ng", alpha3: "ndo", name: "Ndonga", name2: "Ndonga", nativeName: "Oshiwambo", family: "Niger–Congo");
        /// <summary>
        /// Dutch
        /// </summary>
        public static Language NL { get; } = new Language(alpha2: "nl", alpha3: "nld", name: "Dutch", name2: "Dutch", nativeName: "Nederlands", family: "Indo-European");
        /// <summary>
        /// Norwegian Nynorsk
        /// </summary>
        public static Language NN { get; } = new Language(alpha2: "nn", alpha3: "nno", name: "Norwegian Nynorsk", name2: "Norwegian Nynorsk", nativeName: "Norsk nynorsk", family: "Indo-European");
        /// <summary>
        /// Norwegian
        /// </summary>
        public static Language NO { get; } = new Language(alpha2: "no", alpha3: "nor", name: "Norwegian", name2: "Norwegian", nativeName: "Norsk", family: "Indo-European");
        /// <summary>
        /// Southern Ndebele
        /// </summary>
        public static Language NR { get; } = new Language(alpha2: "nr", alpha3: "nbl", name: "Southern Ndebele", name2: "South Ndebele", nativeName: "isiNdebele", family: "Niger–Congo");
        /// <summary>
        /// Navajo, Navaho
        /// </summary>
        public static Language NV { get; } = new Language(alpha2: "nv", alpha3: "nav", name: "Navajo, Navaho", name2: "Navajo", nativeName: "Diné bizaad", family: "Dené–Yeniseian");
        /// <summary>
        /// Chichewa, Chewa, Nyanja
        /// </summary>
        public static Language NY { get; } = new Language(alpha2: "ny", alpha3: "nya", name: "Chichewa, Chewa, Nyanja", name2: "Chichewa", nativeName: "Chi-Chewa", family: "Niger–Congo");
        /// <summary>
        /// Occitan
        /// </summary>
        public static Language OC { get; } = new Language(alpha2: "oc", alpha3: "oci", name: "Occitan", name2: "Occitan", nativeName: "Occitan", family: "Indo-European");
        /// <summary>
        /// Ojibwe, Ojibwa
        /// </summary>
        public static Language OJ { get; } = new Language(alpha2: "oj", alpha3: "oji", name: "Ojibwe, Ojibwa", name2: "Ojibwa", nativeName: "ᐊᓂᔑᓈᐯᒧᐎᓐ / Anishinaabemowin", family: "Algonquian");
        /// <summary>
        /// Oromo
        /// </summary>
        public static Language OM { get; } = new Language(alpha2: "om", alpha3: "orm", name: "Oromo", name2: "Oromo", nativeName: "Oromoo", family: "Afro-Asiatic");
        /// <summary>
        /// Oriya
        /// </summary>
        public static Language OR { get; } = new Language(alpha2: "or", alpha3: "ori", name: "Oriya", name2: "Oriya", nativeName: "ଓଡ଼ିଆ", family: "Indo-European");
        /// <summary>
        /// Ossetian, Ossetic
        /// </summary>
        public static Language OS { get; } = new Language(alpha2: "os", alpha3: "oss", name: "Ossetian, Ossetic", name2: "Ossetian / Ossetic", nativeName: "Иронау", family: "Indo-European");
        /// <summary>
        /// (Eastern) Punjabi
        /// </summary>
        public static Language PA { get; } = new Language(alpha2: "pa", alpha3: "pan", name: "(Eastern) Punjabi", name2: "Panjabi / Punjabi", nativeName: "ਪੰਜਾਬੀ / पंजाबी / پنجابي", family: "Indo-European");
        /// <summary>
        /// Pāli
        /// </summary>
        public static Language PI { get; } = new Language(alpha2: "pi", alpha3: "pli", name: "Pāli", name2: "Pali", nativeName: "Pāli / पाऴि", family: "Indo-European");
        /// <summary>
        /// Polish
        /// </summary>
        public static Language PL { get; } = new Language(alpha2: "pl", alpha3: "pol", name: "Polish", name2: "Polish", nativeName: "Polski", family: "Indo-European");
        /// <summary>
        /// Pashto, Pushto
        /// </summary>
        public static Language PS { get; } = new Language(alpha2: "ps", alpha3: "pus", name: "Pashto, Pushto", name2: "Pashto", nativeName: "پښتو", family: "Indo-European");
        /// <summary>
        /// Portuguese
        /// </summary>
        public static Language PT { get; } = new Language(alpha2: "pt", alpha3: "por", name: "Portuguese", name2: "Portuguese", nativeName: "Português", family: "Indo-European");
        /// <summary>
        /// Quechua
        /// </summary>
        public static Language QU { get; } = new Language(alpha2: "qu", alpha3: "que", name: "Quechua", name2: "Quechua", nativeName: "Runa Simi", family: "Quechuan");
        /// <summary>
        /// Romansh
        /// </summary>
        public static Language RM { get; } = new Language(alpha2: "rm", alpha3: "roh", name: "Romansh", name2: "Raeto Romance", nativeName: "Rumantsch", family: "Indo-European");
        /// <summary>
        /// Kirundi
        /// </summary>
        public static Language RN { get; } = new Language(alpha2: "rn", alpha3: "run", name: "Kirundi", name2: "Kirundi", nativeName: "Kirundi", family: "Niger–Congo");
        /// <summary>
        /// Romanian
        /// </summary>
        public static Language RO { get; } = new Language(alpha2: "ro", alpha3: "ron", name: "Romanian", name2: "Romanian", nativeName: "Română", family: "Indo-European");
        /// <summary>
        /// Russian
        /// </summary>
        public static Language RU { get; } = new Language(alpha2: "ru", alpha3: "rus", name: "Russian", name2: "Russian", nativeName: "Русский", family: "Indo-European");
        /// <summary>
        /// Kinyarwanda
        /// </summary>
        public static Language RW { get; } = new Language(alpha2: "rw", alpha3: "kin", name: "Kinyarwanda", name2: "Rwandi", nativeName: "Kinyarwandi", family: "Niger–Congo");
        /// <summary>
        /// Sanskrit (Saṁskṛta)
        /// </summary>
        public static Language SA { get; } = new Language(alpha2: "sa", alpha3: "san", name: "Sanskrit (Saṁskṛta)", name2: "Sanskrit", nativeName: "संस्कृतम्", family: "Indo-European");
        /// <summary>
        /// Sardinian
        /// </summary>
        public static Language SC { get; } = new Language(alpha2: "sc", alpha3: "srd", name: "Sardinian", name2: "Sardinian", nativeName: "Sardu", family: "Indo-European");
        /// <summary>
        /// Sindhi
        /// </summary>
        public static Language SD { get; } = new Language(alpha2: "sd", alpha3: "snd", name: "Sindhi", name2: "Sindhi", nativeName: "सिनधि", family: "Indo-European");
        /// <summary>
        /// Northern Sami
        /// </summary>
        public static Language SE { get; } = new Language(alpha2: "se", alpha3: "sme", name: "Northern Sami", name2: "Northern Sami", nativeName: "Sámegiella", family: "Uralic");
        /// <summary>
        /// Sango
        /// </summary>
        public static Language SG { get; } = new Language(alpha2: "sg", alpha3: "sag", name: "Sango", name2: "Sango", nativeName: "Sängö", family: "Creole");
        /// <summary>
        /// Sinhalese, Sinhala
        /// </summary>
        public static Language SI { get; } = new Language(alpha2: "si", alpha3: "sin", name: "Sinhalese, Sinhala", name2: "Sinhalese", nativeName: "සිංහල", family: "Indo-European");
        /// <summary>
        /// Slovak
        /// </summary>
        public static Language SK { get; } = new Language(alpha2: "sk", alpha3: "slk", name: "Slovak", name2: "Slovak", nativeName: "Slovenčina", family: "Indo-European");
        /// <summary>
        /// Slovene
        /// </summary>
        public static Language SL { get; } = new Language(alpha2: "sl", alpha3: "slv", name: "Slovene", name2: "Slovenian", nativeName: "Slovenščina", family: "Indo-European");
        /// <summary>
        /// Samoan
        /// </summary>
        public static Language SM { get; } = new Language(alpha2: "sm", alpha3: "smo", name: "Samoan", name2: "Samoan", nativeName: "Gagana Samoa", family: "Austronesian");
        /// <summary>
        /// Shona
        /// </summary>
        public static Language SN { get; } = new Language(alpha2: "sn", alpha3: "sna", name: "Shona", name2: "Shona", nativeName: "chiShona", family: "Niger–Congo");
        /// <summary>
        /// Somali
        /// </summary>
        public static Language SO { get; } = new Language(alpha2: "so", alpha3: "som", name: "Somali", name2: "Somalia", nativeName: "Soomaaliga", family: "Afro-Asiatic");
        /// <summary>
        /// Albanian
        /// </summary>
        public static Language SQ { get; } = new Language(alpha2: "sq", alpha3: "sqi", name: "Albanian", name2: "Albanian", nativeName: "Shqip", family: "Indo-European");
        /// <summary>
        /// Serbian
        /// </summary>
        public static Language SR { get; } = new Language(alpha2: "sr", alpha3: "srp", name: "Serbian", name2: "Serbian", nativeName: "Српски", family: "Indo-European");
        /// <summary>
        /// Swati
        /// </summary>
        public static Language SS { get; } = new Language(alpha2: "ss", alpha3: "ssw", name: "Swati", name2: "Swati", nativeName: "SiSwati", family: "Niger–Congo");
        /// <summary>
        /// Southern Sotho
        /// </summary>
        public static Language ST { get; } = new Language(alpha2: "st", alpha3: "sot", name: "Southern Sotho", name2: "Southern Sotho", nativeName: "Sesotho", family: "Niger–Congo");
        /// <summary>
        /// Sundanese
        /// </summary>
        public static Language SU { get; } = new Language(alpha2: "su", alpha3: "sun", name: "Sundanese", name2: "Sundanese", nativeName: "Basa Sunda", family: "Austronesian");
        /// <summary>
        /// Swedish
        /// </summary>
        public static Language SV { get; } = new Language(alpha2: "sv", alpha3: "swe", name: "Swedish", name2: "Swedish", nativeName: "Svenska", family: "Indo-European");
        /// <summary>
        /// Swahili
        /// </summary>
        public static Language SW { get; } = new Language(alpha2: "sw", alpha3: "swa", name: "Swahili", name2: "Swahili", nativeName: "Kiswahili", family: "Niger–Congo");
        /// <summary>
        /// Tamil
        /// </summary>
        public static Language TA { get; } = new Language(alpha2: "ta", alpha3: "tam", name: "Tamil", name2: "Tamil", nativeName: "தமிழ்", family: "Dravidian");
        /// <summary>
        /// Telugu
        /// </summary>
        public static Language TE { get; } = new Language(alpha2: "te", alpha3: "tel", name: "Telugu", name2: "Telugu", nativeName: "తెలుగు", family: "Dravidian");
        /// <summary>
        /// Tajik
        /// </summary>
        public static Language TG { get; } = new Language(alpha2: "tg", alpha3: "tgk", name: "Tajik", name2: "Tajik", nativeName: "Тоҷикӣ", family: "Indo-European");
        /// <summary>
        /// Thai
        /// </summary>
        public static Language TH { get; } = new Language(alpha2: "th", alpha3: "tha", name: "Thai", name2: "Thai", nativeName: "ไทย / Phasa Thai", family: "Tai–Kadai");
        /// <summary>
        /// Tigrinya
        /// </summary>
        public static Language TI { get; } = new Language(alpha2: "ti", alpha3: "tir", name: "Tigrinya", name2: "Tigrinya", nativeName: "ትግርኛ", family: "Afro-Asiatic");
        /// <summary>
        /// Turkmen
        /// </summary>
        public static Language TK { get; } = new Language(alpha2: "tk", alpha3: "tuk", name: "Turkmen", name2: "Turkmen", nativeName: "Туркмен / تركمن", family: "Turkic");
        /// <summary>
        /// Tagalog
        /// </summary>
        public static Language TL { get; } = new Language(alpha2: "tl", alpha3: "tgl", name: "Tagalog", name2: "Tagalog / Filipino", nativeName: "Tagalog", family: "Austronesian");
        /// <summary>
        /// Tswana
        /// </summary>
        public static Language TN { get; } = new Language(alpha2: "tn", alpha3: "tsn", name: "Tswana", name2: "Tswana", nativeName: "Setswana", family: "Niger–Congo");
        /// <summary>
        /// Tonga (Tonga Islands)
        /// </summary>
        public static Language TO { get; } = new Language(alpha2: "to", alpha3: "ton", name: "Tonga (Tonga Islands)", name2: "Tonga", nativeName: "Lea Faka-Tonga", family: "Austronesian");
        /// <summary>
        /// Turkish
        /// </summary>
        public static Language TR { get; } = new Language(alpha2: "tr", alpha3: "tur", name: "Turkish", name2: "Turkish", nativeName: "Türkçe", family: "Turkic");
        /// <summary>
        /// Tsonga
        /// </summary>
        public static Language TS { get; } = new Language(alpha2: "ts", alpha3: "tso", name: "Tsonga", name2: "Tsonga", nativeName: "Xitsonga", family: "Niger–Congo");
        /// <summary>
        /// Tatar
        /// </summary>
        public static Language TT { get; } = new Language(alpha2: "tt", alpha3: "tat", name: "Tatar", name2: "Tatar", nativeName: "Tatarça", family: "Turkic");
        /// <summary>
        /// Twi
        /// </summary>
        public static Language TW { get; } = new Language(alpha2: "tw", alpha3: "twi", name: "Twi", name2: "Twi", nativeName: "Twi", family: "Niger–Congo");
        /// <summary>
        /// Tahitian
        /// </summary>
        public static Language TY { get; } = new Language(alpha2: "ty", alpha3: "tah", name: "Tahitian", name2: "Tahitian", nativeName: "Reo Mā`ohi", family: "Austronesian");
        /// <summary>
        /// Uyghur
        /// </summary>
        public static Language UG { get; } = new Language(alpha2: "ug", alpha3: "uig", name: "Uyghur", name2: "Uyghur", nativeName: "Uyƣurqə / ئۇيغۇرچە", family: "Turkic");
        /// <summary>
        /// Ukrainian
        /// </summary>
        public static Language UK { get; } = new Language(alpha2: "uk", alpha3: "ukr", name: "Ukrainian", name2: "Ukrainian", nativeName: "Українська", family: "Indo-European");
        /// <summary>
        /// Urdu
        /// </summary>
        public static Language UR { get; } = new Language(alpha2: "ur", alpha3: "urd", name: "Urdu", name2: "Urdu", nativeName: "اردو", family: "Indo-European");
        /// <summary>
        /// Uzbek
        /// </summary>
        public static Language UZ { get; } = new Language(alpha2: "uz", alpha3: "uzb", name: "Uzbek", name2: "Uzbek", nativeName: "Ўзбек", family: "Turkic");
        /// <summary>
        /// Venda
        /// </summary>
        public static Language VE { get; } = new Language(alpha2: "ve", alpha3: "ven", name: "Venda", name2: "Venda", nativeName: "Tshivenḓa", family: "Niger–Congo");
        /// <summary>
        /// Vietnamese
        /// </summary>
        public static Language VI { get; } = new Language(alpha2: "vi", alpha3: "vie", name: "Vietnamese", name2: "Vietnamese", nativeName: "Tiếng Việt", family: "Austroasiatic");
        /// <summary>
        /// Volapük
        /// </summary>
        public static Language VO { get; } = new Language(alpha2: "vo", alpha3: "vol", name: "Volapük", name2: "Volapük", nativeName: "Volapük", family: "Constructed");
        /// <summary>
        /// Walloon
        /// </summary>
        public static Language WA { get; } = new Language(alpha2: "wa", alpha3: "wln", name: "Walloon", name2: "Walloon", nativeName: "Walon", family: "Indo-European");
        /// <summary>
        /// Wolof
        /// </summary>
        public static Language WO { get; } = new Language(alpha2: "wo", alpha3: "wol", name: "Wolof", name2: "Wolof", nativeName: "Wollof", family: "Niger–Congo");
        /// <summary>
        /// Xhosa
        /// </summary>
        public static Language XH { get; } = new Language(alpha2: "xh", alpha3: "xho", name: "Xhosa", name2: "Xhosa", nativeName: "isiXhosa", family: "Niger–Congo");
        /// <summary>
        /// Yiddish
        /// </summary>
        public static Language YI { get; } = new Language(alpha2: "yi", alpha3: "yid", name: "Yiddish", name2: "Yiddish", nativeName: "ייִדיש", family: "Indo-European");
        /// <summary>
        /// Yoruba
        /// </summary>
        public static Language YO { get; } = new Language(alpha2: "yo", alpha3: "yor", name: "Yoruba", name2: "Yoruba", nativeName: "Yorùbá", family: "Niger–Congo");
        /// <summary>
        /// Zhuang, Chuang
        /// </summary>
        public static Language ZA { get; } = new Language(alpha2: "za", alpha3: "zha", name: "Zhuang, Chuang", name2: "Zhuang", nativeName: "Cuengh / Tôô / 壮语", family: "Tai–Kadai");
        /// <summary>
        /// Chinese
        /// </summary>
        public static Language ZH { get; } = new Language(alpha2: "zh", alpha3: "zho", name: "Chinese", name2: "Chinese", nativeName: "中文", family: "Sino-Tibetan");
        /// <summary>
        /// Zulu
        /// </summary>
        public static Language ZU { get; } = new Language(alpha2: "zu", alpha3: "zul", name: "Zulu", name2: "Zulu", nativeName: "isiZulu", family: "Niger–Congo");
        #endregion
        #region Alpha3
        /// <summary>
        /// Afar
        /// </summary>
        public static Language AAR => AA;
        /// <summary>
        /// Abkhaz
        /// </summary>
        public static Language ABK => AB;
        /// <summary>
        /// Avestan
        /// </summary>
        public static Language AVE => AE;
        /// <summary>
        /// Afrikaans
        /// </summary>
        public static Language AFR => AF;
        /// <summary>
        /// Akan
        /// </summary>
        public static Language AKA => AK;
        /// <summary>
        /// Amharic
        /// </summary>
        public static Language AMH => AM;
        /// <summary>
        /// Aragonese
        /// </summary>
        public static Language ARG => AN;
        /// <summary>
        /// Avaric
        /// </summary>
        public static Language AVA => AV;
        /// <summary>
        /// Assamese
        /// </summary>
        public static Language ASM => AS;
        /// <summary>
        /// Arabic
        /// </summary>
        public static Language ARA => AR;
        /// <summary>
        /// Azerbaijani
        /// </summary>
        public static Language AZE => AZ;
        /// <summary>
        /// Aymara
        /// </summary>
        public static Language AYM => AY;
        /// <summary>
        /// Bashkir
        /// </summary>
        public static Language BAK => BA;
        /// <summary>
        /// Belarusian
        /// </summary>
        public static Language BEL => BE;
        /// <summary>
        /// Bulgarian
        /// </summary>
        public static Language BUL => BG;
        /// <summary>
        /// Bihari
        /// </summary>
        public static Language BIH => BH;
        /// <summary>
        /// Bislama
        /// </summary>
        public static Language BIS => BI;
        /// <summary>
        /// Bambara
        /// </summary>
        public static Language BAM => BM;
        /// <summary>
        /// Bengali, Bangla
        /// </summary>
        public static Language BEN => BN;
        /// <summary>
        /// Tibetan Standard, Tibetan, Central
        /// </summary>
        public static Language BOD => BO;
        /// <summary>
        /// Breton
        /// </summary>
        public static Language BRE => BR;
        /// <summary>
        /// Bosnian
        /// </summary>
        public static Language BOS => BS;
        /// <summary>
        /// Catalan
        /// </summary>
        public static Language CAT => CA;
        /// <summary>
        /// Chechen
        /// </summary>
        public static Language CHE => CE;
        /// <summary>
        /// Chamorro
        /// </summary>
        public static Language CHA => CH;
        /// <summary>
        /// Corsican
        /// </summary>
        public static Language COS => CO;
        /// <summary>
        /// Cree
        /// </summary>
        public static Language CRE => CR;
        /// <summary>
        /// Czech
        /// </summary>
        public static Language CES => CS;
        /// <summary>
        /// Old Church Slavonic, Church Slavonic, Old Bulgarian
        /// </summary>
        public static Language CHU => CU;
        /// <summary>
        /// Chuvash
        /// </summary>
        public static Language CHV => CV;
        /// <summary>
        /// Welsh
        /// </summary>
        public static Language CYM => CY;
        /// <summary>
        /// Danish
        /// </summary>
        public static Language DAN => DA;
        /// <summary>
        /// German
        /// </summary>
        public static Language DEU => DE;
        /// <summary>
        /// Divehi, Dhivehi, Maldivian
        /// </summary>
        public static Language DIV => DV;
        /// <summary>
        /// Dzongkha
        /// </summary>
        public static Language DZO => DZ;
        /// <summary>
        /// Ewe
        /// </summary>
        public static Language EWE => EE;
        /// <summary>
        /// Greek (modern)
        /// </summary>
        public static Language ELL => EL;
        /// <summary>
        /// English
        /// </summary>
        public static Language ENG => EN;
        /// <summary>
        /// Esperanto
        /// </summary>
        public static Language EPO => EO;
        /// <summary>
        /// Spanish
        /// </summary>
        public static Language SPA => ES;
        /// <summary>
        /// Estonian
        /// </summary>
        public static Language EST => ET;
        /// <summary>
        /// Basque
        /// </summary>
        public static Language EUS => EU;
        /// <summary>
        /// Persian (Farsi)
        /// </summary>
        public static Language FAS => FA;
        /// <summary>
        /// Fula, Fulah, Pulaar, Pular
        /// </summary>
        public static Language FUL => FF;
        /// <summary>
        /// Finnish
        /// </summary>
        public static Language FIN => FI;
        /// <summary>
        /// Fijian
        /// </summary>
        public static Language FIJ => FJ;
        /// <summary>
        /// Faroese
        /// </summary>
        public static Language FAO => FO;
        /// <summary>
        /// French
        /// </summary>
        public static Language FRA => FR;
        /// <summary>
        /// Western Frisian
        /// </summary>
        public static Language FRY => FY;
        /// <summary>
        /// Irish
        /// </summary>
        public static Language GLE => GA;
        /// <summary>
        /// Scottish Gaelic, Gaelic
        /// </summary>
        public static Language GLA => GD;
        /// <summary>
        /// Galician
        /// </summary>
        public static Language GLG => GL;
        /// <summary>
        /// Guaraní
        /// </summary>
        public static Language GRN => GN;
        /// <summary>
        /// Gujarati
        /// </summary>
        public static Language GUJ => GU;
        /// <summary>
        /// Manx
        /// </summary>
        public static Language GLV => GV;
        /// <summary>
        /// Hausa
        /// </summary>
        public static Language HAU => HA;
        /// <summary>
        /// Hebrew (modern)
        /// </summary>
        public static Language HEB => HE;
        /// <summary>
        /// Hindi
        /// </summary>
        public static Language HIN => HI;
        /// <summary>
        /// Hiri Motu
        /// </summary>
        public static Language HMO => HO;
        /// <summary>
        /// Croatian
        /// </summary>
        public static Language HRV => HR;
        /// <summary>
        /// Haitian, Haitian Creole
        /// </summary>
        public static Language HAT => HT;
        /// <summary>
        /// Hungarian
        /// </summary>
        public static Language HUN => HU;
        /// <summary>
        /// Armenian
        /// </summary>
        public static Language HYE => HY;
        /// <summary>
        /// Herero
        /// </summary>
        public static Language HER => HZ;
        /// <summary>
        /// Interlingua
        /// </summary>
        public static Language INA => IA;
        /// <summary>
        /// Indonesian
        /// </summary>
        public static Language IND => ID;
        /// <summary>
        /// Interlingue
        /// </summary>
        public static Language ILE => IE;
        /// <summary>
        /// Igbo
        /// </summary>
        public static Language IBO => IG;
        /// <summary>
        /// Nuosu
        /// </summary>
        public static Language III => II;
        /// <summary>
        /// Inupiaq
        /// </summary>
        public static Language IPK => IK;
        /// <summary>
        /// Ido
        /// </summary>
        public static Language IDO => IO;
        /// <summary>
        /// Icelandic
        /// </summary>
        public static Language ISL => IS;
        /// <summary>
        /// Italian
        /// </summary>
        public static Language ITA => IT;
        /// <summary>
        /// Inuktitut
        /// </summary>
        public static Language IKU => IU;
        /// <summary>
        /// Japanese
        /// </summary>
        public static Language JPN => JA;
        /// <summary>
        /// Javanese
        /// </summary>
        public static Language JAV => JV;
        /// <summary>
        /// Georgian
        /// </summary>
        public static Language KAT => KA;
        /// <summary>
        /// Kongo
        /// </summary>
        public static Language KON => KG;
        /// <summary>
        /// Kikuyu, Gikuyu
        /// </summary>
        public static Language KIK => KI;
        /// <summary>
        /// Kwanyama, Kuanyama
        /// </summary>
        public static Language KUA => KJ;
        /// <summary>
        /// Kazakh
        /// </summary>
        public static Language KAZ => KK;
        /// <summary>
        /// Kalaallisut, Greenlandic
        /// </summary>
        public static Language KAL => KL;
        /// <summary>
        /// Khmer
        /// </summary>
        public static Language KHM => KM;
        /// <summary>
        /// Kannada
        /// </summary>
        public static Language KAN => KN;
        /// <summary>
        /// Korean
        /// </summary>
        public static Language KOR => KO;
        /// <summary>
        /// Kanuri
        /// </summary>
        public static Language KAU => KR;
        /// <summary>
        /// Kashmiri
        /// </summary>
        public static Language KAS => KS;
        /// <summary>
        /// Kurdish
        /// </summary>
        public static Language KUR => KU;
        /// <summary>
        /// Komi
        /// </summary>
        public static Language KOM => KV;
        /// <summary>
        /// Cornish
        /// </summary>
        public static Language COR => KW;
        /// <summary>
        /// Kyrgyz
        /// </summary>
        public static Language KIR => KY;
        /// <summary>
        /// Latin
        /// </summary>
        public static Language LAT => LA;
        /// <summary>
        /// Luxembourgish, Letzeburgesch
        /// </summary>
        public static Language LTZ => LB;
        /// <summary>
        /// Ganda
        /// </summary>
        public static Language LUG => LG;
        /// <summary>
        /// Limburgish, Limburgan, Limburger
        /// </summary>
        public static Language LIM => LI;
        /// <summary>
        /// Lingala
        /// </summary>
        public static Language LIN => LN;
        /// <summary>
        /// Lao
        /// </summary>
        public static Language LAO => LO;
        /// <summary>
        /// Lithuanian
        /// </summary>
        public static Language LIT => LT;
        /// <summary>
        /// Luba-Katanga
        /// </summary>
        public static Language LUB => LU;
        /// <summary>
        /// Latvian
        /// </summary>
        public static Language LAV => LV;
        /// <summary>
        /// Malagasy
        /// </summary>
        public static Language MLG => MG;
        /// <summary>
        /// Marshallese
        /// </summary>
        public static Language MAH => MH;
        /// <summary>
        /// Māori
        /// </summary>
        public static Language MRI => MI;
        /// <summary>
        /// Macedonian
        /// </summary>
        public static Language MKD => MK;
        /// <summary>
        /// Malayalam
        /// </summary>
        public static Language MAL => ML;
        /// <summary>
        /// Mongolian
        /// </summary>
        public static Language MON => MN;
        /// <summary>
        /// Marathi (Marāṭhī)
        /// </summary>
        public static Language MAR => MR;
        /// <summary>
        /// Malay
        /// </summary>
        public static Language MSA => MS;
        /// <summary>
        /// Maltese
        /// </summary>
        public static Language MLT => MT;
        /// <summary>
        /// Burmese
        /// </summary>
        public static Language MYA => MY;
        /// <summary>
        /// Nauruan
        /// </summary>
        public static Language NAU => NA;
        /// <summary>
        /// Norwegian Bokmål
        /// </summary>
        public static Language NOB => NB;
        /// <summary>
        /// Northern Ndebele
        /// </summary>
        public static Language NDE => ND;
        /// <summary>
        /// Nepali
        /// </summary>
        public static Language NEP => NE;
        /// <summary>
        /// Ndonga
        /// </summary>
        public static Language NDO => NG;
        /// <summary>
        /// Dutch
        /// </summary>
        public static Language NLD => NL;
        /// <summary>
        /// Norwegian Nynorsk
        /// </summary>
        public static Language NNO => NN;
        /// <summary>
        /// Norwegian
        /// </summary>
        public static Language NOR => NO;
        /// <summary>
        /// Southern Ndebele
        /// </summary>
        public static Language NBL => NR;
        /// <summary>
        /// Navajo, Navaho
        /// </summary>
        public static Language NAV => NV;
        /// <summary>
        /// Chichewa, Chewa, Nyanja
        /// </summary>
        public static Language NYA => NY;
        /// <summary>
        /// Occitan
        /// </summary>
        public static Language OCI => OC;
        /// <summary>
        /// Ojibwe, Ojibwa
        /// </summary>
        public static Language OJI => OJ;
        /// <summary>
        /// Oromo
        /// </summary>
        public static Language ORM => OM;
        /// <summary>
        /// Oriya
        /// </summary>
        public static Language ORI => OR;
        /// <summary>
        /// Ossetian, Ossetic
        /// </summary>
        public static Language OSS => OS;
        /// <summary>
        /// (Eastern) Punjabi
        /// </summary>
        public static Language PAN => PA;
        /// <summary>
        /// Pāli
        /// </summary>
        public static Language PLI => PI;
        /// <summary>
        /// Polish
        /// </summary>
        public static Language POL => PL;
        /// <summary>
        /// Pashto, Pushto
        /// </summary>
        public static Language PUS => PS;
        /// <summary>
        /// Portuguese
        /// </summary>
        public static Language POR => PT;
        /// <summary>
        /// Quechua
        /// </summary>
        public static Language QUE => QU;
        /// <summary>
        /// Romansh
        /// </summary>
        public static Language ROH => RM;
        /// <summary>
        /// Kirundi
        /// </summary>
        public static Language RUN => RN;
        /// <summary>
        /// Romanian
        /// </summary>
        public static Language RON => RO;
        /// <summary>
        /// Russian
        /// </summary>
        public static Language RUS => RU;
        /// <summary>
        /// Kinyarwanda
        /// </summary>
        public static Language KIN => RW;
        /// <summary>
        /// Sanskrit (Saṁskṛta)
        /// </summary>
        public static Language SAN => SA;
        /// <summary>
        /// Sardinian
        /// </summary>
        public static Language SRD => SC;
        /// <summary>
        /// Sindhi
        /// </summary>
        public static Language SND => SD;
        /// <summary>
        /// Northern Sami
        /// </summary>
        public static Language SME => SE;
        /// <summary>
        /// Sango
        /// </summary>
        public static Language SAG => SG;
        /// <summary>
        /// Sinhalese, Sinhala
        /// </summary>
        public static Language SIN => SI;
        /// <summary>
        /// Slovak
        /// </summary>
        public static Language SLK => SK;
        /// <summary>
        /// Slovene
        /// </summary>
        public static Language SLV => SL;
        /// <summary>
        /// Samoan
        /// </summary>
        public static Language SMO => SM;
        /// <summary>
        /// Shona
        /// </summary>
        public static Language SNA => SN;
        /// <summary>
        /// Somali
        /// </summary>
        public static Language SOM => SO;
        /// <summary>
        /// Albanian
        /// </summary>
        public static Language SQI => SQ;
        /// <summary>
        /// Serbian
        /// </summary>
        public static Language SRP => SR;
        /// <summary>
        /// Swati
        /// </summary>
        public static Language SSW => SS;
        /// <summary>
        /// Southern Sotho
        /// </summary>
        public static Language SOT => ST;
        /// <summary>
        /// Sundanese
        /// </summary>
        public static Language SUN => SU;
        /// <summary>
        /// Swedish
        /// </summary>
        public static Language SWE => SV;
        /// <summary>
        /// Swahili
        /// </summary>
        public static Language SWA => SW;
        /// <summary>
        /// Tamil
        /// </summary>
        public static Language TAM => TA;
        /// <summary>
        /// Telugu
        /// </summary>
        public static Language TEL => TE;
        /// <summary>
        /// Tajik
        /// </summary>
        public static Language TGK => TG;
        /// <summary>
        /// Thai
        /// </summary>
        public static Language THA => TH;
        /// <summary>
        /// Tigrinya
        /// </summary>
        public static Language TIR => TI;
        /// <summary>
        /// Turkmen
        /// </summary>
        public static Language TUK => TK;
        /// <summary>
        /// Tagalog
        /// </summary>
        public static Language TGL => TL;
        /// <summary>
        /// Tswana
        /// </summary>
        public static Language TSN => TN;
        /// <summary>
        /// Tonga (Tonga Islands)
        /// </summary>
        public static Language TON => TO;
        /// <summary>
        /// Turkish
        /// </summary>
        public static Language TUR => TR;
        /// <summary>
        /// Tsonga
        /// </summary>
        public static Language TSO => TS;
        /// <summary>
        /// Tatar
        /// </summary>
        public static Language TAT => TT;
        /// <summary>
        /// Twi
        /// </summary>
        public static Language TWI => TW;
        /// <summary>
        /// Tahitian
        /// </summary>
        public static Language TAH => TY;
        /// <summary>
        /// Uyghur
        /// </summary>
        public static Language UIG => UG;
        /// <summary>
        /// Ukrainian
        /// </summary>
        public static Language UKR => UK;
        /// <summary>
        /// Urdu
        /// </summary>
        public static Language URD => UR;
        /// <summary>
        /// Uzbek
        /// </summary>
        public static Language UZB => UZ;
        /// <summary>
        /// Venda
        /// </summary>
        public static Language VEN => VE;
        /// <summary>
        /// Vietnamese
        /// </summary>
        public static Language VIE => VI;
        /// <summary>
        /// Volapük
        /// </summary>
        public static Language VOL => VO;
        /// <summary>
        /// Walloon
        /// </summary>
        public static Language WLN => WA;
        /// <summary>
        /// Wolof
        /// </summary>
        public static Language WOL => WO;
        /// <summary>
        /// Xhosa
        /// </summary>
        public static Language XHO => XH;
        /// <summary>
        /// Yiddish
        /// </summary>
        public static Language YID => YI;
        /// <summary>
        /// Yoruba
        /// </summary>
        public static Language YOR => YO;
        /// <summary>
        /// Zhuang, Chuang
        /// </summary>
        public static Language ZHA => ZA;
        /// <summary>
        /// Chinese
        /// </summary>
        public static Language ZHO => ZH;
        /// <summary>
        /// Zulu
        /// </summary>
        public static Language ZUL => ZU;
        #endregion
    }
}
