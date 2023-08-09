namespace ISO.Tests
{
    using NUnit.Framework;
    using ISOLib;

    [TestFixture]
    public class ISOTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [TestCase("USA", "United States of America")]
        [TestCase("ZWE", "Zimbabwe")]
        [TestCase("TLS", "Timor-Leste")]
        [TestCase("RUS", "Russian Federation")]
        [TestCase("AFG", "Afghanistan")]
        [TestCase("BHS", "Bahamas")]
        [TestCase("KGZ", "Kyrgyzstan")]
        public void CountryCollection_Tests(string alpha3, string name)
        {
            Assert.AreEqual(ISO.CountryCollection[alpha3].Name, name);
            Assert.AreEqual(ISO.CountryCollection[name].Alpha3, alpha3);
        }


        [TestCase("AAR", "Afar")]
        [TestCase("ENG", "English")]
        [TestCase("NOR", "Norwegian")]
        [TestCase("ZUL", "Zulu")]
        [TestCase("TAH", "Tahitian")]
        [TestCase("SWA", "Swahili")]
        [TestCase("SOM", "Somali")]
        public void LanguageCollection_Tests(string alpha3, string name)
        {
            Assert.AreEqual(ISO.LanguageCollection[alpha3].Name, name);
            Assert.AreEqual(ISO.LanguageCollection[name].Alpha3, alpha3);
        }

        [TestCase("AFN", "Afghan afghani")]
        [TestCase("ZMW", "Zambian kwacha")]
        [TestCase("VUV", "Vanuatu vatu")]
        [TestCase("USD", "United States dollar")]
        [TestCase("MXN", "Mexican peso")]
        [TestCase("LYD", "Libyan dinar")]
        [TestCase("INR", "Indian rupee")]
        public void CurrencyCollection_Tests(string alpha3, string name)
        {
            Assert.AreEqual(ISO.CurrencyCollection[alpha3].Name, name);
            Assert.AreEqual(ISO.CurrencyCollection[name].Alpha3, alpha3);
        }
    }
}