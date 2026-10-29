using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    /// <summary>
    /// How a holiday's name is resolved, case by case. Doubles as the documentation of the rules, so each
    /// test states the rule it pins and uses a real calendar rather than a stub.
    ///
    /// The sources, in the order they are tried:
    ///   1. the culture asked for (GetName), and the cultures it falls back to: nl-BE, then nl, then invariant
    ///   2. EnglishName, when English is what was asked for
    ///   3. a LocalName the calendar set in code - no calendar in the library needs one any more
    ///   4. the calendar's own Culture, and its fallbacks
    ///   5. EnglishName - the floor, always present, so a name is never empty
    ///
    /// Whatever answers, a "{0}" in it is filled with the day number of a multi-day holiday, so the days of
    /// Eid al-Fitr are one row rather than three.
    ///
    /// Names live in one .resx per culture: a plain language file (Names.nl.resx) unless several supported
    /// countries share the language and word things differently, which is when a region file appears
    /// (Names.nl-BE.resx). Region files are keyed by CULTURE, not by calendar: asking a Belgian calendar for
    /// nl-NL gets the Dutch wording, because that is what nl-NL means. A calendar that disagrees with the
    /// culture it shares gets a file of its own, read first (Names.EcbTargetClosingDay.en-US.resx).
    /// </summary>
    [TestClass]
    public class TestNameResolutionOrder
    {
        private static readonly DateTime Christmas = new DateTime(2026, 12, 25);
        private static readonly DateTime NewYear = new DateTime(2026, 1, 1);

        private static Holiday Holiday(IPublicHolidays calendar, DateTime date)
        {
            return calendar.PublicHolidaysInformation(date.Year).Single(h => h.HolidayDate == date);
        }

        private static string NameOf(IPublicHolidays calendar, DateTime date)
        {
            return Holiday(calendar, date).Name;
        }

        #region the culture asked for

        /// <summary>
        /// An exact region file answers first. Belgium and the Netherlands both speak Dutch and word
        /// Christmas differently, which is exactly when a region file is warranted.
        /// </summary>
        [TestMethod]
        public void ExactRegionFileAnswersFirst()
        {
            var belgian = Holiday(new BelgiumPublicHoliday(), Christmas);

            Assert.AreEqual("Kerstmis", belgian.GetName("nl-BE"), "Names.nl-BE.resx");
            Assert.AreEqual("Noël", belgian.GetName("fr-BE"), "Names.fr-BE.resx");
        }

        /// <summary>
        /// No region file for the culture asked for? Its parent language answers. de-BE has no file of its
        /// own, so a Belgian holiday asked for Belgian German answers from Names.de.resx.
        /// </summary>
        [TestMethod]
        public void AnUnknownRegionFallsBackToItsLanguage()
        {
            var belgian = Holiday(new BelgiumPublicHoliday(), Christmas);

            Assert.AreEqual("Weihnachten", belgian.GetName("de-BE"), "de-BE -> de");
            Assert.AreEqual("Weihnachten", belgian.GetName("de"), "de directly");
        }

        /// <summary>
        /// The same fallback covers cultures no calendar declares at all - French Guiana has no file and no
        /// calendar, and resolves as plain French.
        /// </summary>
        [TestMethod]
        public void ACultureNoCalendarDeclaresStillResolves()
        {
            Assert.AreEqual("Fête de Noël", Holiday(new FrancePublicHoliday(), Christmas).GetName("fr-GF"));
        }

        /// <summary>
        /// A region file belongs to a culture, not to a calendar. Asking a Belgian calendar for nl-NL gives
        /// the Dutch wording and vice versa - each answers what that culture calls the holiday.
        /// </summary>
        [TestMethod]
        public void RegionFilesAreKeyedByCultureNotByCalendar()
        {
            var belgian = Holiday(new BelgiumPublicHoliday(), Christmas);
            var dutch = Holiday(new DutchPublicHoliday(), Christmas);

            Assert.AreEqual("Eerste Kerstdag", belgian.GetName("nl-NL"), "Belgian holiday, Dutch wording");
            Assert.AreEqual("Kerstmis", dutch.GetName("nl-BE"), "Dutch holiday, Belgian wording");

            //...and a third country's region file is reachable too: de-AT says Christtag where de says Weihnachten
            Assert.AreEqual("Christtag", belgian.GetName("de-AT"));
            Assert.AreEqual("Weihnachten", belgian.GetName("de"));
        }

        /// <summary>
        /// A language file is shared: two calendars asked for the same language give the same answer, which
        /// is the point of having one.
        /// </summary>
        [TestMethod]
        public void ALanguageFileServesEveryCalendar()
        {
            var german = new CultureInfo("de");
            var easterMonday = new DateTime(2026, 4, 6);

            Assert.AreEqual("Ostermontag", Holiday(new PolandPublicHoliday(), easterMonday).GetName(german));
            Assert.AreEqual("Ostermontag", Holiday(new ItalyPublicHoliday(), easterMonday).GetName(german));
            Assert.AreEqual("Ostermontag", Holiday(new BelgiumPublicHoliday(), easterMonday).GetName(german));
        }

        /// <summary>
        /// The region file and the language file above it can hold different wording, and both are used -
        /// which country's wording you get depends only on what you asked for.
        /// </summary>
        [TestMethod]
        public void ARegionFileAndItsLanguageFileCanDiffer()
        {
            var belgian = Holiday(new BelgiumPublicHoliday(), Christmas);

            Assert.AreEqual("Noël", belgian.GetName("fr-BE"), "Belgian French");
            Assert.AreEqual("Fête de Noël", belgian.GetName("fr"), "French in general");
        }

        /// <summary>
        /// A language file with no row for the key is not a dead end - the walk continues, and ends at the
        /// calendar's own language rather than at English.
        /// </summary>
        [TestMethod]
        public void AnUntranslatedCultureEndsAtTheCalendarsOwnLanguage()
        {
            var belgian = Holiday(new BelgiumPublicHoliday(), Christmas);

            foreach (var noSuchLanguage in new[] { "es", "ja", "pl", "xx-XX" })
            {
                Assert.AreEqual("Kerstmis", belgian.GetName(noSuchLanguage), noSuchLanguage);
            }
        }

        #endregion

        #region English

        /// <summary>
        /// English is not a resource file: it is the definition's EnglishName, which is why it can differ
        /// per calendar for the same holiday and the same key.
        /// </summary>
        [TestMethod]
        public void EnglishComesFromTheDefinition()
        {
            var belgian = Holiday(new BelgiumPublicHoliday(), Christmas);

            Assert.AreEqual("Christmas", belgian.GetName("en"));
            Assert.AreEqual("Christmas", belgian.GetName("en-GB"), "any English region");
            Assert.AreEqual("Christmas", belgian.GetName(CultureInfo.InvariantCulture), "no culture at all");
            Assert.AreEqual("Christmas", belgian.EnglishName);

            //Switzerland's definition deliberately says Christmas Day for the same key
            Assert.AreEqual("Christmas Day", Holiday(new SwitzerlandPublicHoliday(), Christmas).GetName("en"));
        }

        #endregion

        #region a calendar's own file

        /// <summary>
        /// A calendar that words a holiday differently from the culture it shares gets its own file, read
        /// before the shared one: Names.EcbTargetClosingDay.en-US.resx over Names.en-US.resx. The USA
        /// calendars share en-US and are unaffected.
        /// </summary>
        [TestMethod]
        public void ACalendarsOwnFileIsReadBeforeTheSharedOne()
        {
            var ecb = new EcbTargetClosingDay();
            var usa = new USAPublicHoliday();

            Assert.AreEqual("en-US", ecb.Culture.Name);
            Assert.AreEqual("en-US", usa.Culture.Name, "the same culture");

            Assert.AreEqual("Christmas Day", NameOf(ecb, Christmas), "from the ECB's own file");
            Assert.AreEqual("Christmas", NameOf(usa, Christmas), "from the definition, unaffected");

            Assert.AreEqual("New Year’s Day", NameOf(ecb, NewYear), "note the typographic apostrophe");
            Assert.AreEqual("New Year", NameOf(usa, NewYear));
        }

        /// <summary>
        /// The calendar's file is consulted per culture like any other, so it does not shadow a translation:
        /// asked in French, the ECB answers from Names.fr.resx, which it has no file for.
        /// </summary>
        [TestMethod]
        public void ACalendarsOwnFileDoesNotShadowOtherLanguages()
        {
            var ecbChristmas = Holiday(new EcbTargetClosingDay(), Christmas);

            Assert.AreEqual("Fête de Noël", ecbChristmas.GetName("fr"));
            Assert.AreEqual("Weihnachten", ecbChristmas.GetName("de"));
            Assert.AreEqual("Christmas", ecbChristmas.GetName("en"), "English is still EnglishName");
        }

        #endregion

        #region multi-day holidays

        /// <summary>
        /// A holiday whose days are numbered needs ONE resource row, not one per day: the row carries a
        /// "{0}" and the day number is substituted into it. Eid al-Fitr runs three days, Eid al-Adha four,
        /// from one row each in Names.tr.resx.
        /// </summary>
        [TestMethod]
        public void MultiDayHolidayNamesComeFromOneRowWithAPlaceholder()
        {
            var turkey = new TurkeyPublicHoliday();

            var ramadan = turkey.PublicHolidaysInformation(2026)
                .Where(h => h.HolidayKey == "EidAlFitr")
                .OrderBy(h => h.HolidayDate)
                .Select(h => h.Name)
                .ToList();
            var sacrifice = turkey.PublicHolidaysInformation(2026)
                .Where(h => h.HolidayKey == "EidAlAdha")
                .OrderBy(h => h.HolidayDate)
                .Select(h => h.Name)
                .ToList();

            CollectionAssert.AreEqual(
                new[] { "Ramazan Bayramı 1. Gün", "Ramazan Bayramı 2. Gün", "Ramazan Bayramı 3. Gün" },
                ramadan.ToArray());
            CollectionAssert.AreEqual(
                new[] { "Kurban Bayramı 1. Gün", "Kurban Bayramı 2. Gün", "Kurban Bayramı 3. Gün", "Kurban Bayramı 4. Gün" },
                sacrifice.ToArray());
        }

        /// <summary>
        /// The day number goes only where a placeholder is. The English names have none, so they are
        /// returned as they are - all three days of the feast share one English name.
        /// </summary>
        [TestMethod]
        public void ADayNumberIsSubstitutedOnlyWhereThePlaceholderIs()
        {
            var ramadan = new TurkeyPublicHoliday().PublicHolidaysInformation(2026)
                .Where(h => h.HolidayKey == "EidAlFitr")
                .OrderBy(h => h.HolidayDate)
                .ToList();

            foreach (var day in ramadan)
            {
                Assert.AreEqual("Eid al-Fitr", day.GetName("en"), "no placeholder, no number");
                Assert.AreEqual("Eid al-Fitr", day.EnglishName);
            }

            //and a one-day holiday is never numbered
            Assert.AreEqual("Cumhuriyet Bayramı",
                NameOf(new TurkeyPublicHoliday(), new DateTime(2026, 10, 29)));
        }

        #endregion

        #region the calendar's own culture

        /// <summary>
        /// Name asks no culture, so it answers from the calendar's own - and walks the same fallbacks, which
        /// is why Greece (Names.el.resx, no el-GR) names its holidays in Greek.
        /// </summary>
        [TestMethod]
        public void NameAnswersFromTheCalendarsOwnCultureAndItsFallbacks()
        {
            Assert.AreEqual("Kerstmis", NameOf(new BelgiumPublicHoliday(), Christmas), "nl-BE, exact");
            Assert.AreEqual("Neujahr", NameOf(new AustriaPublicHoliday(), NewYear), "de-AT, exact");
            Assert.AreEqual("Neujahrstag", NameOf(new GermanPublicHoliday(), NewYear), "de-DE, exact");
            Assert.AreEqual("Uusaasta", NameOf(new EstoniaPublicHoliday(), NewYear), "et-EE -> Names.et.resx");
            Assert.AreEqual("Πρωτοχρονιά", NameOf(new GreecePublicHoliday(), NewYear), "el-GR -> Names.el.resx");
        }

        /// <summary>
        /// A language spoken in one supported country needs no region file: the calendar's own culture and
        /// any other variant of the language both reach the language file.
        /// </summary>
        [TestMethod]
        public void OneCountryPerLanguageNeedsOnlyALanguageFile()
        {
            var estonian = Holiday(new EstoniaPublicHoliday(), NewYear);

            Assert.AreEqual("et-EE", new EstoniaPublicHoliday().Culture.Name, "the calendar's declared culture");
            Assert.AreEqual("Uusaasta", estonian.GetName("et-EE"));
            Assert.AreEqual("Uusaasta", estonian.GetName("et"), "the file itself");
            Assert.AreEqual("Uusaasta", estonian.Name);
        }

        #endregion

        #region the floor

        /// <summary>
        /// A calendar whose language has no file at all answers in English, and says so consistently. This
        /// is a gap in the translations, not an error - the names are correct, just not localized yet.
        /// </summary>
        [TestMethod]
        public void ACalendarWithNoFileForItsLanguageAnswersInEnglish()
        {
            Assert.AreEqual("pl-PL", new PolandPublicHoliday().Culture.Name);
            Assert.AreEqual("New Year", NameOf(new PolandPublicHoliday(), NewYear), "no Names.pl.resx yet");
            Assert.AreEqual("New Year", NameOf(new JapanPublicHoliday(), NewYear), "no Names.ja.resx yet");
        }

        /// <summary>
        /// Whatever is asked for, something is returned.
        /// </summary>
        [TestMethod]
        public void ANameIsNeverEmpty()
        {
            var belgian = Holiday(new BelgiumPublicHoliday(), Christmas);

            foreach (var culture in new[] { "en", "fr", "de", "el", "ja", "es-419", "zh-Hant-TW", "" })
            {
                Assert.IsFalse(string.IsNullOrEmpty(belgian.GetName(new CultureInfo(culture))), culture);
            }
            Assert.IsFalse(string.IsNullOrEmpty(belgian.GetName((string)null)), "null culture name");
            Assert.IsFalse(string.IsNullOrEmpty(belgian.GetName((CultureInfo)null)), "null culture");
        }

        /// <summary>
        /// The same, swept across every calendar in every configuration - each value of each region
        /// property, every option flag on - so a holiday that only appears behind a flag is covered too.
        /// </summary>
        [TestMethod]
        public void NoHolidayOfAnyCalendarIsEverNameless()
        {
            var cultures = new[] { "en", "fr", "de", "el", "ja", "es-419", "" };

            foreach (var configuration in AllNamesGoldenMasterTest.AllConfigurations())
            {
                foreach (var holiday in configuration.Value.PublicHolidaysInformation(2026))
                {
                    Assert.IsFalse(string.IsNullOrEmpty(holiday.Name),
                        configuration.Key + " " + holiday.HolidayKey + " Name");

                    foreach (var culture in cultures)
                    {
                        Assert.IsFalse(string.IsNullOrEmpty(holiday.GetName(new CultureInfo(culture))),
                            configuration.Key + " " + holiday.HolidayKey + " GetName(" + culture + ")");
                    }
                }
            }
        }

        /// <summary>
        /// Asking for no culture is the same question as Name - not the same as asking for English.
        /// </summary>
        [TestMethod]
        public void NoCultureMeansTheCalendarsOwnLanguage()
        {
            var belgian = Holiday(new BelgiumPublicHoliday(), Christmas);

            Assert.AreEqual("Kerstmis", belgian.GetName((CultureInfo)null));
            Assert.AreEqual("Kerstmis", belgian.GetName((string)null));
            Assert.AreEqual("Kerstmis", belgian.Name);
            Assert.AreEqual("Christmas", belgian.GetName(CultureInfo.InvariantCulture), "invariant IS English");
        }

        #endregion

        #region choosing the calendar's culture

        /// <summary>
        /// Initialising a calendar in another of its languages changes what Name answers, with no culture
        /// passed to any call.
        /// </summary>
        [TestMethod]
        public void ACalendarCanBeInitialisedInAnotherLanguage()
        {
            Assert.AreEqual("Kerstmis", NameOf(new BelgiumPublicHoliday(), Christmas), "default: nl-BE");
            Assert.AreEqual("Noël", NameOf(new BelgiumPublicHoliday().WithCulture("fr-BE"), Christmas));
            Assert.AreEqual("Fête de Noël", NameOf(new BelgiumPublicHoliday().WithCulture("fr"), Christmas));
            Assert.AreEqual("Weihnachten", NameOf(new BelgiumPublicHoliday().WithCulture("de-BE"), Christmas), "de-BE -> de");
            Assert.AreEqual("Christmas", NameOf(new BelgiumPublicHoliday().WithCulture("en"), Christmas));
        }

        /// <summary>
        /// Setting Culture REPLACES the calendar's language, so an untranslated holiday falls to English -
        /// where GetName, which leaves Culture alone, would fall to the country's language. This is the one
        /// difference between the two ways of asking, and it is deliberate.
        /// </summary>
        [TestMethod]
        public void SettingTheCultureReplacesTheCalendarsLanguage()
        {
            var chosen = NameOf(new BelgiumPublicHoliday().WithCulture("es"), Christmas);
            var asked = Holiday(new BelgiumPublicHoliday(), Christmas).GetName("es");

            Assert.AreEqual("Christmas", chosen, "Culture = es: no Spanish, so English");
            Assert.AreEqual("Kerstmis", asked, "GetName(es): no Spanish, so the country's own");
        }

        /// <summary>
        /// WithCulture is the same as the property, keeps the calendar's own type so it composes with a
        /// region, and ignores a null or empty culture rather than blanking the calendar's language.
        /// </summary>
        [TestMethod]
        public void WithCultureIsSetupSugarAndKeepsTheType()
        {
            CanadaPublicHoliday quebec = new CanadaPublicHoliday("QC").WithCulture("fr-CA");
            Assert.AreEqual("QC", quebec.Province, "still the concrete calendar, region intact");
            Assert.AreEqual("fr-CA", quebec.Culture.Name);

            //a region set as a property survives it too
            AustraliaPublicHoliday newSouthWales =
                new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.NSW }.WithCulture("en-AU");
            Assert.AreEqual(AustraliaPublicHoliday.States.NSW, newSouthWales.State);
            Assert.AreEqual("en-AU", newSouthWales.Culture.Name);

            //and so does a calendar the factory built, which the caller only knows as IPublicHolidays
            IPublicHolidays fromFactory = PublicHolidayFactory.GetPublicHolidayForCountry("BE").WithCulture("fr-BE");
            Assert.AreEqual("Noël", NameOf(fromFactory, Christmas));

            Assert.AreEqual("nl-BE", new BelgiumPublicHoliday().WithCulture((string)null).Culture.Name);
            Assert.AreEqual("nl-BE", new BelgiumPublicHoliday().WithCulture("").Culture.Name);
        }

        /// <summary>
        /// Every calendar has Culture, including the multilingual ones read through the object initialiser.
        /// </summary>
        [TestMethod]
        public void AnyCalendarCanBeGivenACulture()
        {
            var swiss = new SwitzerlandPublicHoliday { Culture = new CultureInfo("fr-CH") };

            Assert.AreEqual("fr-CH", swiss.Culture.Name);
            Assert.AreEqual("Fête de Noël", NameOf(swiss, Christmas), "fr-CH has no file, so Names.fr.resx");
        }

        /// <summary>
        /// A Spanish request against calendars whose own language differs shows the last rung clearly.
        /// </summary>
        [TestMethod]
        public void AnUntranslatedCultureFallsBackPerCalendar()
        {
            var spanish = new CultureInfo("es");

            Assert.AreEqual("Uusaasta", Holiday(new EstoniaPublicHoliday(), NewYear).GetName(spanish));
            Assert.AreEqual("Πρωτοχρονιά", Holiday(new GreecePublicHoliday(), NewYear).GetName(spanish));
            Assert.AreEqual("New Year", Holiday(new PolandPublicHoliday(), NewYear).GetName(spanish),
                "Poland has no file of its own either, so English");
        }

        /// <summary>
        /// Changing the culture after a first call must not serve names from the cached year.
        /// </summary>
        [TestMethod]
        public void ChangingTheCultureInvalidatesTheCachedYear()
        {
            var belgium = new BelgiumPublicHoliday();
            Assert.AreEqual("Kerstmis", NameOf(belgium, Christmas));

            belgium.Culture = new CultureInfo("fr-BE");
            Assert.AreEqual("Noël", NameOf(belgium, Christmas), "cache cleared by the setter");
        }

        #endregion

        #region regions and the calendars that are not countries

        /// <summary>
        /// A region selection and a language are independent: the province decides which holidays appear,
        /// the culture decides what they are called.
        /// </summary>
        [TestMethod]
        public void ARegionAndACultureAreIndependent()
        {
            //English Canada: no en-CA row for these, so the definitions' English names
            Assert.AreEqual("Christmas Day", NameOf(new CanadaPublicHoliday(), Christmas), "no province");
            Assert.AreEqual("Christmas Day", NameOf(new CanadaPublicHoliday("SK"), Christmas), "Saskatchewan");
            Assert.AreEqual("Christmas Day", NameOf(new CanadaPublicHoliday("QC"), Christmas), "Quebec");
            Assert.AreEqual("en-CA", new CanadaPublicHoliday().Culture.Name);

            //the same calendars in French answer from Names.fr.resx
            Assert.AreEqual("Jour de l'An", NameOf(new CanadaPublicHoliday("SK").WithCulture("fr-CA"), NewYear));
            Assert.AreEqual("Jour de l'An", NameOf(new CanadaPublicHoliday().WithCulture("fr"), NewYear));
        }

        /// <summary>
        /// The Quebec government calendar is French: it declares fr-CA, so Name is French without anyone
        /// asking, while GetName("en") still gives its English name.
        /// </summary>
        [TestMethod]
        public void AFrenchCalendarNamesItsHolidaysInFrench()
        {
            var quebec = new CanadaQuebecGovClosingDay();
            var newYear = Holiday(quebec, NewYear);

            Assert.AreEqual("fr-CA", quebec.Culture.Name);
            Assert.AreEqual("Jour de l'An", newYear.Name);
            Assert.AreEqual("New Year", newYear.GetName("en"));
            Assert.AreEqual("Fête de Noël", NameOf(quebec, Christmas), "fr-CA has no row, so Names.fr.resx");
        }

        /// <summary>
        /// Two calendars can share a culture and still disagree - see ACalendarsOwnFileIsReadBeforeTheSharedOne
        /// for how.
        /// </summary>
        [TestMethod]
        public void CalendarsSharingACultureCanStillDisagree()
        {
            var ecb = Holiday(new EcbTargetClosingDay(), Christmas);
            var usa = Holiday(new USAPublicHoliday(), Christmas);

            Assert.AreEqual("en-US", new EcbTargetClosingDay().Culture.Name);
            Assert.AreEqual("en-US", new USAPublicHoliday().Culture.Name);
            Assert.AreEqual("Christmas Day", ecb.Name, "from Names.EcbTargetClosingDay.en-US.resx");
            Assert.AreEqual("Christmas", usa.Name, "unaffected by it");
        }

        #endregion

        #region asking for something that does not exist

        /// <summary>
        /// The factory covers ISO 3166-1 alpha-2 codes, case-insensitively, and is explicit about the rest.
        /// </summary>
        [TestMethod]
        public void AskingForACountryThatIsNotImplemented()
        {
            Assert.IsInstanceOfType<BelgiumPublicHoliday>(PublicHolidayFactory.GetPublicHolidayForCountry("BE"));
            Assert.IsInstanceOfType<BelgiumPublicHoliday>(PublicHolidayFactory.GetPublicHolidayForCountry("be"),
                "case-insensitive");

            //a real country the library has no calendar for, and a code that is not a country at all
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => PublicHolidayFactory.GetPublicHolidayForCountry("IS"));
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => PublicHolidayFactory.GetPublicHolidayForCountry("XX"));
            Assert.ThrowsExactly<ArgumentNullException>(() => PublicHolidayFactory.GetPublicHolidayForCountry((string)null));
        }

        /// <summary>
        /// A culture the library has never heard of is not an error: it resolves down the same ladder.
        /// </summary>
        [TestMethod]
        public void AskingForALanguageThatDoesNotExist()
        {
            var belgian = Holiday(new BelgiumPublicHoliday(), Christmas);

            Assert.AreEqual("Kerstmis", belgian.GetName("zu"), "Zulu: no file, so the calendar's own");
            Assert.AreEqual("Kerstmis", belgian.GetName("qps-ploc"), "a pseudo-locale");
            Assert.AreEqual("Weihnachten", belgian.GetName("de-LI"), "unknown region of a known language");
        }

        #endregion
    }
}
