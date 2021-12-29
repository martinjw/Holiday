using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday.Localization;

namespace PublicHolidayTests.Localization
{
    [TestClass]
    public class TestResourceProviderXDocument
    {
        [DataTestMethod]
        [DataRow("en", "NewYear", "New Year", "")]
        [DataRow("en", "DayAfterNewYear", "Day After New Year", "")]
        [DataRow("en", "GoodFriday", "Good Friday", "")]
        [DataRow("en", "EasterMonday", "Easter Monday", "")]
        [DataRow("en", "NationalPatriotDay", "National Patriots' Day", "")]
        [DataRow("en", "DollardDay", "Dollard Day", "")]
        [DataRow("en", "NationalHoliday", "National Holiday", "")]
        [DataRow("en", "NationalHolidayQuebec", "Quebec National Holiday", "")]
        [DataRow("en", "CanadaDay", "Canada Day", "")]
        [DataRow("en", "DominionDay", "Dominion Day", "")]
        [DataRow("en", "LabourDay", "Labour Day", "")]
        [DataRow("en", "Thanksgiving", "Thanksgiving", "")]
        [DataRow("en", "DayBeforeChristmas", "Day Before Christmas", "")]
        [DataRow("en", "Christmas", "Christmas", "")]
        [DataRow("en", "DayAfterChristmas", "Day After Christmas", "")]
        [DataRow("en", "DayBeforeNewYear", "Day Before New Year", "")]
        [DataRow("en", "MartinLutherKing", "Martin Luther King Day", "")]
        [DataRow("en", "PresidentsDay", "President's Day", "")]
        [DataRow("en", "MemorialDay", "Memorial Day", "")]
        [DataRow("en", "Juneteenth", "Juneteenth", "")]
        [DataRow("en", "IndependenceDay", "Independence Day", "")]
        [DataRow("en", "LaborDay", "Labor Day", "")]
        [DataRow("en", "ColumbusDay", "Columbus Day", "")]
        [DataRow("en", "VeteransDay", "Veteran's Day", "")]
        [DataRow("en", "MayDay", "May Day", "")]
        [DataRow("en", "Ascension", "Ascension", "")]
        [DataRow("en", "VictoryInEuropeDay", "Victory in Europe Day", "")]
        [DataRow("en", "PentecostMonday", "Pentecost Monday", "")]
        [DataRow("en", "Assumption", "Assumption", "")]
        [DataRow("en", "AllSaints", "All Saints' Day", "")]
        [DataRow("en", "Armistice", "Armistice Day", "")]
        [DataRow("fr", "NewYear", "Jour de l'An", "")]
        [DataRow("fr", "DayAfterNewYear", "Lendemain du jour de l'An", "")]
        [DataRow("fr", "GoodFriday", "Vendredi Saint", "")]
        [DataRow("fr", "EasterMonday", "Lundi de Pâques", "")]
        [DataRow("fr", "NationalPatriotDay", "Journée nationale des patriotes", "")]
        [DataRow("fr", "DollardDay", "Fête de Dollard", "")]
        [DataRow("fr", "NationalHoliday", "Fête nationale", "")]
        [DataRow("fr", "NationalHolidayQuebec", "Fête nationale du Québec", "")]
        [DataRow("fr", "CanadaDay", "Fête du Canada", "")]
        [DataRow("fr", "DominionDay", "Jour de la Confédération", "")]
        [DataRow("fr", "LabourDay", "Fête du travail", "")]
        [DataRow("fr", "Thanksgiving", "Fête de l'Action de Grâces", "")]
        [DataRow("fr", "DayBeforeChristmas", "Veille de Noël", "")]
        [DataRow("fr", "Christmas", "Fête de Noël", "")]
        [DataRow("fr", "DayAfterChristmas", "Lendemain de Noël", "")]
        [DataRow("fr", "DayBeforeNewYear", "Veille du jour de l'An", "")]
        [DataRow("fr", "MayDay", "Fête du Travail", "")]
        [DataRow("fr", "Ascension", "Ascension", "")]
        [DataRow("fr", "VictoryInEuropeDay", "Fête de la Victoire", "")]
        [DataRow("fr", "PentecostMonday", "Lundi de Pentecôte", "")]
        [DataRow("fr", "Assumption", "Assomption", "")]
        [DataRow("fr", "AllSaints", "Toussaint", "")]
        [DataRow("fr", "Armistice", "Jour de l'armistice", "")]
        public void TestGetResource(string culture, string id, string result, string comment)
        {
            IResourceProvider<XDocument> local = new ResourceProviderXDocument();
            XDocument doc = local.GetResource();

            var resultActual = (from xml2 in doc.Descendants("root").Descendants(culture).Descendants(id)
                                select xml2).FirstOrDefault();

            Assert.IsNotNull(resultActual);

            var valueActual = resultActual.Attribute("value")?.Value.ToString();

            Assert.AreEqual(result, valueActual, comment);
        }
    }
}