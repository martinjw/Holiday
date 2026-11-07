using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestLocalization
    {
        [TestMethod]
        public void BelgiumNewYearInThreeLanguages()
        {
            var newYear = new BelgiumPublicHoliday().PublicHolidaysInformation(2026)
                .Single(h => h.HolidayDate == new DateTime(2026, 1, 1));

            Assert.AreEqual("Nieuwjaar", newYear.GetName(new CultureInfo("nl-BE")));
            Assert.AreEqual("Nouvel An", newYear.GetName(new CultureInfo("fr-BE")));
            Assert.AreEqual("Neujahrstag", newYear.GetName(new CultureInfo("de-BE")));
            Assert.AreEqual("New Year", newYear.GetName(new CultureInfo("en")));
        }

        [TestMethod]
        public void BelgiumNationalDayInThreeLanguages()
        {
            var national = new BelgiumPublicHoliday().PublicHolidaysInformation(2026)
                .Single(h => h.HolidayDate == new DateTime(2026, 7, 21));

            Assert.AreEqual("Nationale feestdag", national.GetName(new CultureInfo("nl-BE")));
            Assert.AreEqual("Fête nationale", national.GetName(new CultureInfo("fr-BE")));
        }

        [TestMethod]
        public void GetNameFallsBackToLocalNameWhenCultureUnknown()
        {
            var newYear = new BelgiumPublicHoliday().PublicHolidaysInformation(2026)
                .Single(h => h.HolidayDate == new DateTime(2026, 1, 1));

            // no Japanese translation -> Belgium's default culture (nl-BE) -> Dutch
            Assert.AreEqual("Nieuwjaar", newYear.GetName(new CultureInfo("ja-JP")));
        }

        [TestMethod]
        public void GetNameNeverEmptyForAnyCalendar()
        {
            var iso = new[] { "IT", "DE", "PL", "US", "GB", "JP", "TR", "ZA" };
            foreach (var code in iso)
            {
                var calendar = PublicHolidayFactory.GetPublicHolidayForCountry(code);
                foreach (var holiday in calendar.PublicHolidaysInformation(2026))
                {
                    Assert.IsFalse(string.IsNullOrEmpty(holiday.GetName(new CultureInfo("es"))),
                        $"{code} {holiday.HolidayDate:MM-dd} GetName(es) empty");
                    Assert.IsFalse(string.IsNullOrEmpty(holiday.GetName(new CultureInfo("en"))),
                        $"{code} {holiday.HolidayDate:MM-dd} GetName(en) empty");
                }
            }
        }

        [TestMethod]
        public void PublicHolidayNamesWithCultureIsOnTheInterface()
        {
            IPublicHolidays calendar = PublicHolidayFactory.GetPublicHolidayForCountry("BE");
            var french = calendar.PublicHolidayNames(2026, new CultureInfo("fr-BE"));

            Assert.AreEqual("Nouvel An", string.Join(", ", french[new DateTime(2026, 1, 1)]));
            Assert.AreEqual("Noël", string.Join(", ", french[new DateTime(2026, 12, 25)]));
        }

        [TestMethod]
        public void ItalianChristmasResolvesGermanAndFrench()
        {
            var christmas = new ItalyPublicHoliday().PublicHolidaysInformation(2026)
                .Single(h => h.HolidayDate == new DateTime(2026, 12, 25));

            Assert.AreEqual("Natale", christmas.Name);
            Assert.AreEqual("Weihnachten", christmas.GetName(new CultureInfo("de")));
            Assert.AreEqual("Fête de Noël", christmas.GetName(new CultureInfo("fr")));
        }

        /// <summary>
        /// Every calendar must report the language its own holiday names are written in, so that
        /// <see cref="Holiday.GetName(CultureInfo)"/> can fall back to it. Only the US calendars
        /// and the ECB one legitimately keep the base en-US.
        /// </summary>
        [TestMethod]
        public void EveryCalendarDeclaresItsOwnCulture()
        {
            var keepsEnglishDefault = new[]
            {
                "USAPublicHoliday", "USAFederalReserveHoliday", "USANewYorkStockExchangeHoliday",
                "EcbTargetClosingDay"
            };

            foreach (var calendar in TestAllPublicHolidays.AllCalendars())
            {
                var name = calendar.GetType().Name;
                var culture = ((PublicHolidayBase)calendar).Culture;

                Assert.IsNotNull(culture, $"{name} has no Culture");
                if (keepsEnglishDefault.Contains(name)) continue;

                Assert.AreNotEqual("en-US", culture.Name,
                    $"{name} still reports the base en-US - declare the language of its LocalNames");
            }
        }

        /// <summary>
        /// A culture with no translation falls back to the calendar's own language, not to English.
        /// Greece is the clearest case: its definitions carry no LocalName, so the name can only
        /// come from the el rows in LocalizationString.xml via Culture.
        /// </summary>
        [TestMethod]
        public void UntranslatedCultureFallsBackToTheCalendarsOwnLanguage()
        {
            var greekNewYear = new GreecePublicHoliday().PublicHolidaysInformation(2026)
                .First(h => h.HolidayDate == new DateTime(2026, 1, 1));

            Assert.AreEqual("el-GR", new GreecePublicHoliday().Culture.Name);
            //"es" has no section in the resource file
            Assert.AreEqual("Πρωτοχρονιά", greekNewYear.GetName(new CultureInfo("es")));
            //an explicitly translated culture still wins over the calendar's own language
            Assert.AreEqual("Neujahrstag", greekNewYear.GetName(new CultureInfo("de")));
        }

        /// <summary>
        /// 26 December is Boxing Day in the UK, Australia, Canada and New Zealand, and the Day of
        /// Goodwill in South Africa - not St Stephen's Day. They must not share the
        /// SaintStephensDay key, whose en row would override their own English name.
        /// </summary>
        [TestMethod]
        public void BoxingDayIsNotStStephensDay()
        {
            var english = new CultureInfo("en");
            var calendars = new (string Label, IPublicHolidays Calendar, string Expected)[]
            {
                ("UK", new UKBankHoliday(), "Boxing Day"),
                ("Australia", new AustraliaPublicHoliday(), "Boxing Day"),
                ("Canada", new CanadaPublicHoliday("ON"), "Boxing Day"),
                ("New Zealand", new NewZealandPublicHoliday(), "Boxing Day"),
                ("South Africa", new SouthAfricaPublicHoliday(), "Day of Goodwill"),
            };

            foreach (var (label, calendar, expected) in calendars)
            {
                var holiday = calendar.PublicHolidaysInformation(2026)
                    .Single(h => h.HolidayDate == new DateTime(2026, 12, 26));

                Assert.AreEqual(expected, holiday.GetName(english), $"{label} GetName(en)");
                Assert.AreEqual(expected, holiday.Name, $"{label} Name");
            }
        }

        /// <summary>
        /// South Africa's 1 May is Workers' Day, so it cannot share the LabourDay key either.
        /// </summary>
        [TestMethod]
        public void SouthAfricanWorkersDayKeepsItsOwnName()
        {
            var workersDay = new SouthAfricaPublicHoliday().PublicHolidaysInformation(2026)
                .Single(h => h.HolidayDate == new DateTime(2026, 5, 1));

            Assert.AreEqual("Workers' Day", workersDay.GetName(new CultureInfo("en")));
            //the translations moved across to the new key with it
            Assert.AreEqual("Fête du travail", workersDay.GetName(new CultureInfo("fr")));
        }

        /// <summary>
        /// A definition's own LocalName still beats the resource file for an untranslated culture.
        /// </summary>
        [TestMethod]
        public void LocalNameWinsOverTheCalendarsCultureLookup()
        {
            var germanNewYear = new GermanPublicHoliday().PublicHolidaysInformation(2026)
                .Single(h => h.HolidayDate == new DateTime(2026, 1, 1));

            Assert.AreEqual("de-DE", new GermanPublicHoliday().Culture.Name);
            Assert.AreEqual("Neujahrstag", germanNewYear.GetName(new CultureInfo("es")));
        }
    }
}
