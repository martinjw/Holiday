using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

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
            var holidayCalendar = new FrancePublicHoliday();
            holidayCalendar.Region = FrancePublicHoliday.Regions.ALL;
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);
            Assert.IsTrue(25 == hols.Count, "Should be 25 holidays");
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

            Assert.IsTrue(counter == 11, "Should be 11");
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

            Assert.IsTrue(hols[0].IsPublic == true);
            Assert.IsTrue(hols[0].HolidayDate == new DateTime(2024, 1, 1));
            Assert.IsTrue(hols[0].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAllSaints2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            holidayCalendar.Region = FrancePublicHoliday.Regions.ALL;
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            Assert.IsTrue(hols[20].IsPublic == true);
            Assert.IsTrue(hols[20].HolidayDate == new DateTime(2024, 11, 1));
            Assert.IsTrue(hols[20].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysInformationArmistice2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            holidayCalendar.Region = FrancePublicHoliday.Regions.ALL;
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            Assert.IsTrue(hols[21].IsPublic == true);
            Assert.IsTrue(hols[21].HolidayDate == new DateTime(2024, 11, 11));
            Assert.IsTrue(hols[21].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysInformationChristmas2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            holidayCalendar.Region = FrancePublicHoliday.Regions.ALL;
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            Assert.IsTrue(hols[23].IsPublic == true);
            Assert.IsTrue(hols[23].HolidayDate == new DateTime(2024, 12, 25));
            Assert.IsTrue(hols[23].Regions is null);
        }

        [TestMethod]
        public void TestEnsuresNoSameKeyBecauseEasterDate()
        {
            for (int i = 1970; i < 2100; i++)
            {
                var calendar = new FrancePublicHoliday();
                var hols = calendar.PublicHolidays(i);
                Assert.IsTrue(11 == hols.Count, "Should be 11 holidays");
            }
        }
    }
}
