using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Collections.Generic;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestAllPublicHolidays
    {
        [TestMethod]
        public void TestHolidayLists()
        {
            var list = new List<IPublicHolidays>
            {
                PublicHolidayFactory.GetPublicHolidayForCountry(PublicHolidayCountryCode.Au),
                PublicHolidayFactory.GetPublicHolidayForCountry("AT"),
                PublicHolidayFactory.GetPublicHolidayForCountry("BE"),
                PublicHolidayFactory.GetPublicHolidayForCountry("BR"),
                PublicHolidayFactory.GetPublicHolidayForCountry("CA"),
                PublicHolidayFactory.GetPublicHolidayForCountry("CZ"),
                PublicHolidayFactory.GetPublicHolidayForCountry("DK"),
                PublicHolidayFactory.GetPublicHolidayForCountry("NL"),
                PublicHolidayFactory.GetPublicHolidayForCountry("EE"),
                PublicHolidayFactory.GetPublicHolidayForCountry("FI"),
                PublicHolidayFactory.GetPublicHolidayForCountry("FR"),
                PublicHolidayFactory.GetPublicHolidayForCountry("DE"),
                PublicHolidayFactory.GetPublicHolidayForCountry("GR"),
                PublicHolidayFactory.GetPublicHolidayForCountry("HR"),
                PublicHolidayFactory.GetPublicHolidayForCountry("IE"),
                PublicHolidayFactory.GetPublicHolidayForCountry("IT"),
                PublicHolidayFactory.GetPublicHolidayForCountry("JP"),
                PublicHolidayFactory.GetPublicHolidayForCountry("KZ"),
                PublicHolidayFactory.GetPublicHolidayForCountry("LT"),
                PublicHolidayFactory.GetPublicHolidayForCountry("LU"),
                PublicHolidayFactory.GetPublicHolidayForCountry("MX"),
                PublicHolidayFactory.GetPublicHolidayForCountry("NZ"),
                PublicHolidayFactory.GetPublicHolidayForCountry("NO"),
                PublicHolidayFactory.GetPublicHolidayForCountry("PL"),
                PublicHolidayFactory.GetPublicHolidayForCountry("PO"),
                PublicHolidayFactory.GetPublicHolidayForCountry("PT"),
                PublicHolidayFactory.GetPublicHolidayForCountry("RO"),
                PublicHolidayFactory.GetPublicHolidayForCountry("RS"),
                PublicHolidayFactory.GetPublicHolidayForCountry("SK"),
                PublicHolidayFactory.GetPublicHolidayForCountry("SI"),
                PublicHolidayFactory.GetPublicHolidayForCountry("ZA"),
                PublicHolidayFactory.GetPublicHolidayForCountry("ES"),
                PublicHolidayFactory.GetPublicHolidayForCountry("SE"),
                PublicHolidayFactory.GetPublicHolidayForCountry("CH"),
                PublicHolidayFactory.GetPublicHolidayForCountry("TR"),
                PublicHolidayFactory.GetPublicHolidayForCountry("GB"),
                PublicHolidayFactory.GetPublicHolidayForCountry("US"),
				//not actually countries but special rules
                new CanadaQuebecGovClosingDay(),
                new EcbTargetClosingDay(),
                new USAFederalReserveHoliday(),
                new USANewYorkStockExchangeHoliday(),
            };
            foreach (var calendar in list)
            {
                for (int year = 1990; year < 2050; year++)
                {
                    var hInfo = calendar.PublicHolidaysInformation(year);
                    Assert.IsTrue(hInfo.Count > 0, $"Holidays for {calendar} in {year}");
                }
            }
        }

        [TestMethod]
        public void TestHolidayFactory()
        {
            var list = new Dictionary<string, Type>
            {
                { "AT", typeof(AustriaPublicHoliday) },
                { "AU", typeof(AustraliaPublicHoliday) },
                { "BE", typeof(BelgiumPublicHoliday) },
                { "BR", typeof(BrazilPublicHoliday) },
                { "CA", typeof(CanadaPublicHoliday) },
                { "CH", typeof(SwitzerlandPublicHoliday) },
                { "CZ", typeof(CzechRepublicPublicHoliday) },
                { "DE", typeof(GermanPublicHoliday) },
                { "DK", typeof(DenmarkPublicHoliday) },
                { "EE", typeof(EstoniaPublicHoliday) },
                { "ES", typeof(SpainPublicHoliday) },
                { "FI", typeof(FinlandPublicHoliday) },
                { "FR", typeof(FrancePublicHoliday) },
                { "GB", typeof(UKBankHoliday) },
                { "GR", typeof(GreecePublicHoliday) },
                { "HR", typeof(CroatiaPublicHoliday) },
                { "IE", typeof(IrelandPublicHoliday) },
                { "IT", typeof(ItalyPublicHoliday) },
                { "JP", typeof(JapanPublicHoliday) },
                { "KZ", typeof(KazakhstanPublicHoliday) },
                { "LT", typeof(LithuaniaPublicHoliday) },
                { "LU", typeof(LuxembourgPublicHoliday) },
                { "MX", typeof(MexicoPublicHoliday) },
                { "NL", typeof(DutchPublicHoliday) },
                { "NO", typeof(NorwayPublicHoliday) },
                { "NZ", typeof(NewZealandPublicHoliday) },
                { "PL", typeof(PolandPublicHoliday) },
                { "PO", typeof(PolandPublicHoliday) }, //incorrect ISO code
                { "PT", typeof(PortugalPublicHoliday) },
                { "RO", typeof(RomanianPublicHoliday) },
                { "RS", typeof(SerbianPublicHoliday) },
                { "SE", typeof(SwedenPublicHoliday) },
                { "SI", typeof(SloveniaPublicHoliday) },
                { "SK", typeof(SlovakiaPublicHoliday) },
                { "TR", typeof(TurkeyPublicHoliday) },
                { "US", typeof(USAPublicHoliday) },
                { "ZA", typeof(SouthAfricaPublicHoliday) },
            };

            Assert.AreEqual(Enum.GetNames(typeof(PublicHolidayCountryCode)).Length, list.Count);

            foreach (var holidayClass in list)
            {
                Assert.IsInstanceOfType(PublicHolidayFactory.GetPublicHolidayForCountry(holidayClass.Key), holidayClass.Value);
            }
        }
    }
}