using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday.Localization;
using System.Globalization;
using System.Xml.Linq;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestLocalizedProviderString
    {
        [DataTestMethod]
        [DataRow("E0", "en", "", false, "Not exist")]
        [DataRow("E0", "fr", "", false, "Not exist")]
        [DataRow("E0", "fr-CA", "", false, "Not exist")]
        [DataRow("E0", "en-US", "", false, "Not exist")]
        [DataRow("E0", "zh-CHT", "", false, "Not exist")]
        [DataRow("E1", "en", "en_V1", true, "Exist in en")]
        [DataRow("E1", "en-US", "en-US_V1", true, "Exist in en")]
        [DataRow("E1", "fr", "fr_V1", true, "Exist in fr")]
        [DataRow("E1", "fr-CA", "fr-CA_V1", true, "In fr-CA")]
        [DataRow("E2", "fr-CA", "fr_V2", true, "Exist in fr and not in fr-CA")]
        [DataRow("E3", "fr-CA", "en_V3", true, "Exist in en and not in fr or fr-CA")]
        [DataRow("E4", "en-US", "", true, "Exist in en and Empty and not in en-US")]
        [DataRow("E5", "zh-CHT", "en_V5", true, "Exist in en and zh-CHT and zh not exist")]
        public void TestTryGetLocalizedString(string idText, string culturestring, string valueresult, bool result, string comment)
        {
            LocalizedProviderString Local = new LocalizedProviderString(new ResourceProviderXDocumentForTest());
            string valueActual;
            CultureInfo culture = new CultureInfo(culturestring);

            bool resultActual = Local.TryGetLocalized(idText, culture, out valueActual);

            Assert.AreEqual(result, resultActual, comment);
            Assert.AreEqual(valueresult, valueActual, comment);
        }

        [DataTestMethod]
        [DataRow("E0", "", false, "Not exist")]
        [DataRow("E1", "en_V1", true, "Exist in en")]
        public void TestTryGetLocalizedString(string idText, string valueresult, bool result, string comment)
        {
            LocalizedProviderString Local = new LocalizedProviderString(new ResourceProviderXDocumentForTest());
            string valueActual;

            bool resultActual = Local.TryGetLocalized(idText, out valueActual);

            Assert.AreEqual(result, resultActual, comment);
            Assert.AreEqual(valueresult, valueActual, comment);
        }

        [DataTestMethod]
        [DataRow("E0", "en", "", "Not exist")]
        [DataRow("E0", "en-US", "", "Exist in en")]
        [DataRow("E1", "en", "en_V1", "Exist in en")]
        [DataRow("E1", "en-US", "en-US_V1", "Exist in en-US")]
        [DataRow("E2", "en-US", "en_V2", "Exist in en-US")]
        public void TestGetLocalizedString2Param(string idText, string culturestring, string valueresult, string comment)
        {
            LocalizedProviderString Local = new LocalizedProviderString(new ResourceProviderXDocumentForTest());
            CultureInfo culture = new CultureInfo(culturestring);

            string valueActual = Local.GetLocalized(idText, culture);

            Assert.AreEqual(valueresult, valueActual, comment);
        }

        [DataTestMethod]
        [DataRow("E0", "", "Not exist")]
        [DataRow("E1", "en_V1", "Exist in en")]
        public void TestGetLocalizedString1Param(string idText, string valueResult, string comment)
        {
            LocalizedProviderString Local = new LocalizedProviderString(new ResourceProviderXDocumentForTest());

            string valueActual = Local.GetLocalized(idText);

            Assert.AreEqual(valueResult, valueActual, comment);
        }
    }

    internal class ResourceProviderXDocumentForTest : IResourceProvider<XDocument>
    {
        XDocument IResourceProvider<XDocument>.GetResource()
        {
            XDocument document = new XDocument(
               new XDeclaration("0.1", "utf-8", "yes"),
               new XElement("root",
                 new XElement("en",
                      new XElement("E1", new XAttribute("value", "en_V1")),
                      new XElement("E2", new XAttribute("value", "en_V2")),
                      new XElement("E3", new XAttribute("value", "en_V3")),
                      new XElement("E4", new XAttribute("value", "")),
                      new XElement("E5", new XAttribute("value", "en_V5"))
                      ),
                 new XElement("en-US",
                      new XElement("E1", new XAttribute("value", "en-US_V1"))
                  ),
                 new XElement("fr",
                      new XElement("E1", new XAttribute("value", "fr_V1")),
                      new XElement("E2", new XAttribute("value", "fr_V2"))
                      ),
                 new XElement("fr-CA",
                      new XElement("E1", new XAttribute("value", "fr-CA_V1"))
                      )
                 )

              );
            return document;
        }
    }
}