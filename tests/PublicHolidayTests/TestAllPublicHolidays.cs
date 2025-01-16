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
                PublicHolidayFactory.GetPublicHolidayForCountry("IE"),
                PublicHolidayFactory.GetPublicHolidayForCountry("IT"),
                PublicHolidayFactory.GetPublicHolidayForCountry("JP"),
                PublicHolidayFactory.GetPublicHolidayForCountry("KZ"),
                PublicHolidayFactory.GetPublicHolidayForCountry("LT"),
                PublicHolidayFactory.GetPublicHolidayForCountry("LU"),
                PublicHolidayFactory.GetPublicHolidayForCountry("NZ"),
                PublicHolidayFactory.GetPublicHolidayForCountry("NO"),
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
    }
}