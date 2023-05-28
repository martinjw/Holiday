using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
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
                new AustraliaPublicHoliday(),
                new AustriaPublicHoliday(),
                new BelgiumPublicHoliday(),
                new CanadaPublicHoliday(),
                new CanadaQuebecGovClosingDay(),
                new CzechRepublicPublicHoliday(),
                new DenmarkPublicHoliday(),
                new DutchPublicHoliday(),
                new EcbTargetClosingDay(),
                new EstoniaPublicHoliday(),
                new FrancePublicHoliday(),
                new GermanPublicHoliday(),
                new IrelandPublicHoliday(),
                new ItalyPublicHoliday(),
                new JapanPublicHoliday(),
                new KazakhstanPublicHoliday(),
                new LuxembourgPublicHoliday(),
                new NewZealandPublicHoliday(),
                new NorwayPublicHoliday(),
                new PolandPublicHoliday(),
                new RomanianPublicHoliday(),
                new SerbianPublicHoliday(),
                new SlovakiaPublicHoliday(),
                new SouthAfricaPublicHoliday(),
                new SpainPublicHoliday(),
                new SwedenPublicHoliday(),
                new SwitzerlandPublicHoliday(),
                new UKBankHoliday(),
                new USAFederalReserveHoliday(),
                new USAPublicHoliday(),
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
    }
}