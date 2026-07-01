using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestFrancePublicHoliday
    {

        [TestMethod]
        public void TestAscension()
        {
            var ascension = FrancePublicHoliday.Ascension(2006);
            Assert.AreEqual(new DateTime(2006, 5, 25), ascension.Date); //we don't care about time part
        }

        [TestMethod]
        public void TestPentecost()
        {
            var pentecost = FrancePublicHoliday.PentecostMonday(2006);
            Assert.AreEqual(new DateTime(2006, 6, 5), pentecost);
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new FrancePublicHoliday().IsPublicHoliday(new DateTime(2006, 5, 8));

            Assert.IsTrue(isPublicHoliday, "Monday 8th May 2006 is Victory In Europe day");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new FrancePublicHoliday().IsPublicHoliday(new DateTime(2006, 5, 9));

            Assert.IsFalse(isPublicHoliday, "Tuesday 9th May 2006 is not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new FrancePublicHoliday().NextWorkingDay(new DateTime(2006, 05, 25)); //thursday Ascension Day
            Assert.AreEqual(new DateTime(2006, 05, 26), result);
        }

        [TestMethod]
        public void TestPublicHolidays()
        {
            var ascension = new DateTime(2006, 05, 25);
            var result = new FrancePublicHoliday().PublicHolidayNames(2006);
            Assert.AreEqual(11, result.Count);
            Assert.IsTrue(result.ContainsKey(ascension));
        }

        [TestMethod]
        public void TestPublicHolidaysInformationCount2024()
        {
            var holidayCalendar = new FrancePublicHoliday
            {
                Region = FrancePublicHoliday.Regions.ALL
            };
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);
            Assert.AreEqual(25, hols.Count, "Should be 25 holidays");
        }


        [TestMethod]
        public void TestOnlyPublicHolidaysInformationCount2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            int counter = 0;
            foreach (var h in hols)
            {
                if (h.IsPublic) counter++;
            }

            Assert.AreEqual(11, counter, "Should be 11");
        }


        [TestMethod]
        public void TestHolidays2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.IsTrue(11 == hols.Count, "Should be 11 holidays");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidays2024Martinique()
        {
            var holidayCalendar = new FrancePublicHoliday { Region = FrancePublicHoliday.Regions.Martinique };
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.IsTrue(14 == hols.Count, "Should be 14 holidays");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationNewYear2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            holidayCalendar.Region = FrancePublicHoliday.Regions.ALL;
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            Assert.IsTrue(hols[0].IsPublic);
            Assert.IsTrue(hols[0].HolidayDate == new DateTime(2024, 1, 1));
            Assert.IsNull(hols[0].Regions);
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAllSaints2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            holidayCalendar.Region = FrancePublicHoliday.Regions.ALL;
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            Assert.IsTrue(hols[20].IsPublic);
            Assert.IsTrue(hols[20].HolidayDate == new DateTime(2024, 11, 1));
            Assert.IsNull(hols[20].Regions);
        }

        [TestMethod]
        public void TestPublicHolidaysInformationArmistice2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            holidayCalendar.Region = FrancePublicHoliday.Regions.ALL;
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            Assert.IsTrue(hols[21].IsPublic);
            Assert.IsTrue(hols[21].HolidayDate == new DateTime(2024, 11, 11));
            Assert.IsNull(hols[21].Regions);
        }

        [TestMethod]
        public void TestPublicHolidaysInformationChristmas2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            holidayCalendar.Region = FrancePublicHoliday.Regions.ALL;
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            Assert.IsTrue(hols[23].IsPublic);
            Assert.IsTrue(hols[23].HolidayDate == new DateTime(2024, 12, 25));
            Assert.IsNull(hols[23].Regions);
        }

        [TestMethod]
        public void TestEnsuresNoSameKeyBecauseEasterDate()
        {
            for (int i = 1970; i < 2100; i++)
            {
                var calendar = new FrancePublicHoliday();
                var hols = calendar.PublicHolidays(i);
                Assert.AreEqual(11, hols.Count, "Should be 11 holidays");
            }
        }

        [TestMethod]
        public void TestBastilleDayCultureAwareName()
        {
            var holidayCalendar = new FrancePublicHoliday { Region = FrancePublicHoliday.Regions.ALL };
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var bastilleDay = hols.Single(h => h.HolidayDate == new DateTime(2026, 7, 14));

            Assert.AreEqual("Französischer Nationalfeiertag", bastilleDay.GetName(new CultureInfo("de")));
            Assert.AreEqual("Festa nazionale francese", bastilleDay.GetName(new CultureInfo("it")));
        }

        [TestMethod]
        public void TestAssumptionCultureAwareName()
        {
            var holidayCalendar = new FrancePublicHoliday { Region = FrancePublicHoliday.Regions.ALL };
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var assumption = hols.Single(h => h.HolidayDate == new DateTime(2026, 8, 15));

            Assert.AreEqual("Mariä Himmelfahrt", assumption.GetName(new CultureInfo("de")));
        }

        [TestMethod]
        public void TestAscensionCultureAwareNameWhenCollidingWithMayHoliday()
        {
            // In 2008 Ascension falls on 1 May, the same day as Fête du Travail. Each holiday must
            // still resolve to its own culture-aware name. Regression guard: a date-keyed id lookup
            // mislabeled the movable Ascension with the fixed holiday's id on collision years.
            var holidayCalendar = new FrancePublicHoliday { Region = FrancePublicHoliday.Regions.ALL };
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2008);

            var ascension = hols.Single(h => h.Name == "Jeudi de l'Ascension");
            Assert.AreEqual(new DateTime(2008, 5, 1), ascension.HolidayDate.Date);
            Assert.AreEqual("Christi Himmelfahrt", ascension.GetName(new CultureInfo("de")));
            Assert.AreEqual("Ascensione", ascension.GetName(new CultureInfo("it")));

            var labourDay = hols.Single(h => h.Name == "Fête du Travail");
            Assert.AreEqual("Tag der Arbeit", labourDay.GetName(new CultureInfo("de")));
        }
    }
}
