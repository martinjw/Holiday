using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using PublicHoliday.Localization;

namespace PublicHolidayTests
{
    /// <summary>
    /// The plug-in point for names the library does not ship: a consumer registers an
    /// <see cref="IHolidayNameProvider"/> and gets their own translations, without a fork.
    /// </summary>
    [TestClass]
    [DoNotParallelize] //the provider registry is process-wide
    public class TestHolidayNameProviders
    {
        private static readonly DateTime BelgianNationalDay2026 = new DateTime(2026, 7, 21);
        private static readonly DateTime Christmas2026 = new DateTime(2026, 12, 25);

        [TestCleanup]
        public void RemoveProviders()
        {
            HolidayNameProviders.Clear();
        }

        private static Holiday BelgianHoliday(DateTime date)
        {
            return new BelgiumPublicHoliday().PublicHolidaysInformation(2026)
                .Single(h => h.HolidayDate == date);
        }

        /// <summary>
        /// A dictionary of ((key, culture) -> name), matching one exact culture only - the shape
        /// the interface asks implementations for.
        /// </summary>
        private sealed class StubProvider : IHolidayNameProvider
        {
            private readonly string _culture;
            private readonly Dictionary<string, string> _names;

            public StubProvider(string culture, Dictionary<string, string> names)
            {
                _culture = culture;
                _names = names;
            }

            public bool TryGetName(string holidayKey, CultureInfo culture, out string name)
            {
                name = null;
                if (culture == null || culture.Name != _culture) return false;
                return _names.TryGetValue(holidayKey, out name);
            }
        }

        [TestMethod]
        public void NoProvidersRegisteredByDefault()
        {
            Assert.AreEqual(0, HolidayNameProviders.All.Count());
        }

        [TestMethod]
        public void ProviderAddsALanguageTheLibraryDoesNotShip()
        {
            var nationalDay = BelgianHoliday(BelgianNationalDay2026);
            //no Polish anywhere in the library, so today it answers in the calendar's own language
            Assert.AreEqual("Nationale feestdag", nationalDay.GetName(new CultureInfo("pl")));

            HolidayNameProviders.Add(new StubProvider("pl",
                new Dictionary<string, string> { { "BelgianNationalDay", "Belgijskie Święto Narodowe" } }));

            Assert.AreEqual("Belgijskie Święto Narodowe", nationalDay.GetName(new CultureInfo("pl")));
        }

        [TestMethod]
        public void ProviderOverridesAShippedName()
        {
            var christmas = BelgianHoliday(Christmas2026);
            Assert.AreEqual("Kerstmis", christmas.GetName(new CultureInfo("nl-BE")));

            HolidayNameProviders.Add(new StubProvider("nl-BE",
                new Dictionary<string, string> { { "Christmas", "Kerstdag" } }));

            Assert.AreEqual("Kerstdag", christmas.GetName(new CultureInfo("nl-BE")));
        }

        [TestMethod]
        public void KeysAProviderDoesNotKnowFallThroughUnchanged()
        {
            HolidayNameProviders.Add(new StubProvider("nl-BE",
                new Dictionary<string, string> { { "Christmas", "Kerstdag" } }));

            //untouched key, and the provider must not swallow other cultures either
            Assert.AreEqual("Nationale feestdag", BelgianHoliday(BelgianNationalDay2026).GetName(new CultureInfo("nl-BE")));
            Assert.AreEqual("Fête de Noël", BelgianHoliday(Christmas2026).GetName(new CultureInfo("fr")));
        }

        [TestMethod]
        public void ProviderIsAskedDownTheCultureHierarchy()
        {
            HolidayNameProviders.Add(new StubProvider("pl",
                new Dictionary<string, string> { { "Christmas", "Boże Narodzenie" } }));

            //pl-PL has no rows of its own, so the walk reaches pl
            Assert.AreEqual("Boże Narodzenie", BelgianHoliday(Christmas2026).GetName(new CultureInfo("pl-PL")));
        }

        [TestMethod]
        public void RemovedProviderStopsBeingConsulted()
        {
            var provider = new StubProvider("nl-BE",
                new Dictionary<string, string> { { "Christmas", "Kerstdag" } });

            HolidayNameProviders.Add(provider);
            Assert.AreEqual("Kerstdag", BelgianHoliday(Christmas2026).GetName(new CultureInfo("nl-BE")));

            Assert.IsTrue(HolidayNameProviders.Remove(provider));
            Assert.AreEqual("Kerstmis", BelgianHoliday(Christmas2026).GetName(new CultureInfo("nl-BE")));
            Assert.IsFalse(HolidayNameProviders.Remove(provider));
        }

        [TestMethod]
        public void ProvidersAreConsultedInRegistrationOrder()
        {
            HolidayNameProviders.Add(new StubProvider("nl-BE",
                new Dictionary<string, string> { { "Christmas", "first" } }));
            HolidayNameProviders.Add(new StubProvider("nl-BE",
                new Dictionary<string, string> { { "Christmas", "second" } }));

            Assert.AreEqual("first", BelgianHoliday(Christmas2026).GetName(new CultureInfo("nl-BE")));
            Assert.AreEqual(2, HolidayNameProviders.All.Count());
        }

        [TestMethod]
        public void AddRejectsNullAndIgnoresDuplicates()
        {
            var provider = new StubProvider("pl", new Dictionary<string, string>());

            Assert.ThrowsExactly<ArgumentNullException>(() => HolidayNameProviders.Add(null));

            HolidayNameProviders.Add(provider);
            HolidayNameProviders.Add(provider);
            Assert.AreEqual(1, HolidayNameProviders.All.Count());
        }

        /// <summary>
        /// The documented set-up for a consumer with their own .resx: a Polish company in Belgium
        /// wanting Polish names for Belgian holidays, wired with one line.
        /// </summary>
        [TestMethod]
        public void ConsumerResxSuppliesNamesThroughResourceManagerNameProvider()
        {
            var resources = new ResourceManager("PublicHolidayTests.ConsumerHolidayNames",
                typeof(TestHolidayNameProviders).Assembly);

            HolidayNameProviders.Add(new ResourceManagerNameProvider(resources));

            var polish = new CultureInfo("pl");
            Assert.AreEqual("Belgijskie Święto Narodowe", BelgianHoliday(BelgianNationalDay2026).GetName(polish));
            Assert.AreEqual("Boże Narodzenie", BelgianHoliday(Christmas2026).GetName(polish));

            //a culture the consumer resx has no file for still gets the library's own answer,
            //NOT the consumer's neutral row - the provider matches one exact culture at a time
            Assert.AreEqual("Fête nationale", BelgianHoliday(BelgianNationalDay2026).GetName(new CultureInfo("fr-BE")));
        }

        [TestMethod]
        public void ResourceManagerNameProviderRejectsNull()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() => new ResourceManagerNameProvider(null));
        }
    }
}
