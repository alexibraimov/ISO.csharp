namespace ISOLib
{
    using ISOLib.Collections;
    /// <summary>
    /// Provides access to collections of countries and languages defined by ISO standards.
    /// </summary>
    public static class ISO
    {
        /// <summary>
        /// Gets the collection of countries defined by the ISO 3166 standard.
        /// </summary>
        public static Countries CountryCollection { get; } = new Countries();
        /// <summary>
        /// Gets the collection of languages defined by the ISO 639 standard.
        /// </summary>
        public static Languages LanguageCollection { get; } = new Languages();
        /// <summary>
        /// Gets the collection of currencies defined by the ISO 4217 standard.
        /// </summary>
        public static Currencies CurrencyCollection { get; } = new Currencies();
    }
}
