using ISOLib.ISO;
using ISOLib.Model;
using NUnit.Framework;

namespace ISOLibTest
{
    public class Tests
    {
        private ISO<Country> iso3166;
        private ISO<Language> iso639;
        [SetUp]
        public void Setup()
        {
            iso3166 = new ISO3166();
            iso639 = new ISO639();
        }

        [TestCase("AF")]
        [TestCase("Andorra")]
        [TestCase("COD")]
        public void TestISO3166(string country)
        {
            Assert.True(iso3166.TryGet(country, out Country country1));
        }

        [TestCase("zu")]
        [TestCase("Chinese")]
        [TestCase("som")]
        public void TestISO639(string language)
        {
            Assert.True(iso639.TryGet(language, out Language languageModel));
        }
    }
}