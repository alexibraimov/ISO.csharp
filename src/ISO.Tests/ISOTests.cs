namespace ISO.Tests
{
    using ISOLib;
    using NUnit.Framework;

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
            Assert.AreEqual(Countries.Collection[alpha3].Name, name);
            Assert.AreEqual(Countries.Collection[name].Alpha3, alpha3);
        }

        [TestCase("aar", "Afar")]
        [TestCase("eng", "English")]
        [TestCase("nor", "Norwegian")]
        [TestCase("zul", "Zulu")]
        [TestCase("tah", "Tahitian")]
        [TestCase("swa", "Swahili")]
        [TestCase("som", "Somali")]
        public void LanguageCollection_Tests(string alpha3, string name)
        {
            Assert.AreEqual(Languages.Collection[alpha3].Name, name);
            Assert.AreEqual(Languages.Collection[name].Alpha3, alpha3);
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
            Assert.AreEqual(Currencies.Collection[alpha3].Name, name);
            Assert.AreEqual(Currencies.Collection[name].Alpha3, alpha3);
        }
    }
}