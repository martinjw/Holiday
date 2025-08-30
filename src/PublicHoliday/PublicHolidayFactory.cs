using System;

namespace PublicHoliday
{
    /// <summary>
    /// Factory class to get holiday calendars by ISO 3166-1 country code
    /// </summary>
    public static class PublicHolidayFactory
    {
        /// <summary>
        /// Get a public holiday instance by ISO 3166-1 country code
        /// </summary>
        /// <param name="countryCode">One of the supported country codes</param>
        /// <returns>An IPublicHolidays instance for the country</returns>
        public static IPublicHolidays GetPublicHolidayForCountry(PublicHolidayCountryCode countryCode)
        {
            return GetPublicHolidayForCountry(countryCode.ToString());
        }
        /// <summary>
        /// Get a public holiday instance by ISO 3166-1 country code
        /// </summary>
        /// <param name="name">A 2-letter ISO code that is supported (eg CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)</param>
        /// <returns>An IPublicHolidays instance for the country</returns>
        /// <exception cref="ArgumentNullException">If the code is supplied</exception>
        /// <exception cref="ArgumentOutOfRangeException">If the code is not supported</exception>
        public static IPublicHolidays GetPublicHolidayForCountry(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            switch (name.ToUpperInvariant())
            {
                case "AU": return new AustraliaPublicHoliday();
                case "AT": return new AustriaPublicHoliday();
                case "BE": return new BelgiumPublicHoliday();
                case "BR": return new BrazilPublicHoliday();
                case "CA": return new CanadaPublicHoliday();
                case "CZ": return new CzechRepublicPublicHoliday();
                case "DK": return new DenmarkPublicHoliday();
                case "NL": return new DutchPublicHoliday();
                case "EE": return new EstoniaPublicHoliday();
                case "FI": return new FinlandPublicHoliday();
                case "FR": return new FrancePublicHoliday();
                case "DE": return new GermanPublicHoliday();
                case "GR": return new GreecePublicHoliday();
                case "HR": return new CroatiaPublicHoliday();
                case "IE": return new IrelandPublicHoliday();
                case "IT": return new ItalyPublicHoliday();
                case "JP": return new JapanPublicHoliday();
                case "KZ": return new KazakhstanPublicHoliday();
                case "LT": return new LithuaniaPublicHoliday();
                case "LU": return new LuxembourgPublicHoliday();
                case "MX": return new MexicoPublicHoliday();
                case "NZ": return new NewZealandPublicHoliday();
                case "NO": return new NorwayPublicHoliday();
                case "PO":
                case "PL": return new PolandPublicHoliday();
                case "PT": return new PortugalPublicHoliday();
                case "RO": return new RomanianPublicHoliday();
                case "RS": return new SerbianPublicHoliday();
                case "SK": return new SlovakiaPublicHoliday();
                case "SI": return new SloveniaPublicHoliday();
                case "ZA": return new SouthAfricaPublicHoliday();
                case "ES": return new SpainPublicHoliday();
                case "SE": return new SwedenPublicHoliday();
                case "CH": return new SwitzerlandPublicHoliday();
                case "TR": return new TurkeyPublicHoliday();
                case "GB": return new UKBankHoliday();
                case "US": return new USAPublicHoliday();
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
            }
        }
    }
}
