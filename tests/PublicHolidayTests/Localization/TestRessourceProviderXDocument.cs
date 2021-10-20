using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using PublicHoliday.Localization;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestRessourceProviderXDocument
    {

        [DataTestMethod]
        [DataRow("en", "NewYear", "", "")]
        [DataRow("en", "DayAfterNewYear", "", "")]
        [DataRow("en", "GoodFriday", "", "")]
        [DataRow("en", "EasterMonday", "", "")]
        [DataRow("en", "NationalPatriotDay", "", "")]
        [DataRow("en", "NationalHoliday", "", "")]
        [DataRow("en", "CanadaDay", "", "")]
        [DataRow("en", "LabourDay", "", "")]
        [DataRow("en", "Thanksgiving", "", "")]
        [DataRow("en", "DayBeforeChristmas", "", "")]
        [DataRow("en", "Christmas", "", "")]
        [DataRow("en", "DayAfterChristmas", "", "")]
        [DataRow("en", "DayBeforeNewYear", "", "")]
        [DataRow("fr", "NewYear", "", "")]
        [DataRow("fr", "DayAfterNewYear", "", "")]
        [DataRow("fr", "GoodFriday", "", "")]
        [DataRow("fr", "EasterMonday", "", "")]
        [DataRow("fr", "NationalPatriotDay", "", "")]
        [DataRow("fr", "NationalHoliday", "", "")]
        [DataRow("fr", "CanadaDay", "", "")]
        [DataRow("fr", "LabourDay", "", "")]
        [DataRow("fr", "Thanksgiving", "", "")]
        [DataRow("fr", "DayBeforeChristmas", "", "")]
        [DataRow("fr", "Christmas", "", "")]
        [DataRow("fr", "DayAfterChristmas", "", "")]
        [DataRow("fr", "DayBeforeNewYear", "", "")]
        public void TestGetRessource(string culture, string Id, string result, string comment)
        {
            IRessourceProvider<XDocument> local = new RessourceProviderXDocument();
            XDocument doc = local.GetRessource();

            var resultActual = (from xml2 in doc.Descendants("root").Descendants(culture).Descendants(Id)
            select xml2).FirstOrDefault();

            Assert.IsNotNull(resultActual);
            //Assert.AreEqual(result, resultActual, comment);

        }


    }

}



