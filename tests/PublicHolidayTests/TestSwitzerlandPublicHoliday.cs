using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestSwitzerlandPublicHoliday {
        [TestMethod]
        public void TestPublicHolidays() 
        {
            var easterMonday = new DateTime(2017, 4, 17);
            var result = new SwitzerlandPublicHoliday().PublicHolidayNames(2017);
            Assert.AreEqual(4, result.Count);
            Assert.IsFalse(result.ContainsKey(easterMonday));
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new SwitzerlandPublicHoliday().IsPublicHoliday(new DateTime(2017, 4, 17));

            Assert.IsFalse(isPublicHoliday, "Easter Monday");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new SwitzerlandPublicHoliday().IsPublicHoliday(new DateTime(2017, 4, 18));

            Assert.IsFalse(isPublicHoliday, "Not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new SwitzerlandPublicHoliday().NextWorkingDay(new DateTime(2024, 5, 9)); //thursday Ascension Day
            Assert.AreEqual(new DateTime(2024, 5, 10), result); 
        }

        [TestMethod]
        public void TestPreviousWorkingDay()
        {
            var result = new SwitzerlandPublicHoliday().PreviousWorkingDay(new DateTime(2027, 8, 1)); 
            Assert.AreEqual(new DateTime(2027, 7, 30), result); 
        }

        [TestMethod]
        public void TestNewYear2017()
        {
            var expected = new DateTime(2017, 1, 1);
            var actual = SwitzerlandPublicHoliday.NewYear(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGoodFriday2017()
        {
            var expected = new DateTime(2017, 4, 14);
            var actual = SwitzerlandPublicHoliday.GoodFriday(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEasterMonday2017()
        {
            var expected = new DateTime(2017, 4, 17);
            var actual = SwitzerlandPublicHoliday.EasterMonday(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLabourDay2017()
        {
            var expected = new DateTime(2017, 5, 1);
            var actual = SwitzerlandPublicHoliday.LabourDay(2017);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestAscensionDay2017()
        {
            var expected = new DateTime(2017, 5, 25);
            var actual = SwitzerlandPublicHoliday.Ascension(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNationalDay2017() {
            var expected = new DateTime(2017, 8, 1);
            var actual = SwitzerlandPublicHoliday.NationalDay(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2017()
        {
            var expected = new DateTime(2017, 12, 25);
            var actual = SwitzerlandPublicHoliday.Christmas(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBoxingDay2017()
        {
            var expected = new DateTime(2017, 12, 26);
            var actual = SwitzerlandPublicHoliday.SaintStephensDay(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsPublicHoliday2024() {

            //https://www.touringswitzerland.com/switzerland-national-holidays-a-complete-guide/#:~:text=These%20are%20the%20following%20Swiss%20National%20Holidays%3A%201,National%20Day%204%20December%2025%20%E2%80%93%20Christmas%20Day 

            var h = new SwitzerlandPublicHoliday(hasLaborDay:true, hasNewYearsEve:true);

            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2024, 1, 1)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2024, 5, 9)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2024, 8, 1)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2024, 12, 25)));

            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2024, 5, 1))); // hasLaborDay

            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2024, 1, 2)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2024, 1, 6)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2024, 4, 13)));
        }

        [TestMethod]
        public void TestHolidays2024ObWaldLists()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday { Canton = SwitzerlandPublicHoliday.Cantons.OW };
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.IsTrue(13 == hols.Count, "Should be 13 holidays in 2024");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }


        [TestMethod]
        public void TestHolidays2024AllCantons()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday { Canton = SwitzerlandPublicHoliday.Cantons.ALL };
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.IsTrue(18 == hols.Count, "Should be 18 holidays");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteCount2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);
            Assert.IsTrue(18 == hols.Count, "Should be 18 holidays");
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteNewYear2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[0].IsPublic == true);
            Assert.IsTrue(hols[0].HolidayDate == new DateTime(2024, 1, 1));
            Assert.IsTrue(hols[0].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteSecondJanuary2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[1].IsPublic == false, "Berchtold's Day isn't public");
            Assert.IsTrue(hols[1].HolidayDate == new DateTime(2024, 1, 2), "Berchtold's Day is on 2nd January 2024");
            Assert.IsTrue(hols[1].Regions.Length == 13);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteSecondEpiphany2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[2].IsPublic == false);
            Assert.IsTrue(hols[2].HolidayDate == new DateTime(2024, 1, 6));
            Assert.IsTrue(hols[2].Regions.Length == 5);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteRepublicDay2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[3].IsPublic == false);
            Assert.IsTrue(hols[3].HolidayDate == new DateTime(2024, 3, 1));
            Assert.IsTrue(hols[3].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteStJosephDay2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[4].IsPublic == false);
            Assert.IsTrue(hols[4].HolidayDate == new DateTime(2024, 3, 19));
            Assert.IsTrue(hols[4].Regions.Length == 7);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteGoodFriday2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[5].IsPublic == false);
            Assert.IsTrue(hols[5].HolidayDate == new DateTime(2024, 3, 29));
            Assert.IsTrue(hols[5].Regions.Length == 24);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteEasterMonday2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[6].IsPublic == false);
            Assert.IsTrue(hols[6].HolidayDate == new DateTime(2024, 4, 1));
            Assert.IsTrue(hols[6].Regions.Length == 25);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteLabourDay2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[7].IsPublic == false);
            Assert.IsTrue(hols[7].HolidayDate == new DateTime(2024, 5, 1));
            Assert.IsTrue(hols[7].Regions.Length == 11);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteAscension2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[8].IsPublic == true);
            Assert.IsTrue(hols[8].HolidayDate == new DateTime(2024, 5, 9));
            Assert.IsTrue(hols[8].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteWhitMonday2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[9].IsPublic == false);
            Assert.IsTrue(hols[9].HolidayDate == new DateTime(2024, 5, 20));
            Assert.IsTrue(hols[9].Regions.Length == 25);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteCorpusChristi2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[10].IsPublic == false);
            Assert.IsTrue(hols[10].HolidayDate == new DateTime(2024, 5, 30));
            Assert.IsTrue(hols[10].Regions.Length == 13);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteNationalDay2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[11].IsPublic == true);
            Assert.IsTrue(hols[11].HolidayDate == new DateTime(2024, 8, 1));
            Assert.IsTrue(hols[11].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteAssumption2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[12].IsPublic == false);
            Assert.IsTrue(hols[12].HolidayDate == new DateTime(2024, 8, 15));
            Assert.IsTrue(hols[12].Regions.Length == 12);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteGenevaPrayDay2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[13].IsPublic == false);
            Assert.IsTrue(hols[13].HolidayDate == new DateTime(2024, 8, 29));
            Assert.IsTrue(hols[13].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteAllSaints2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[14].IsPublic == false);
            Assert.IsTrue(hols[14].HolidayDate == new DateTime(2024, 11, 1));
            Assert.IsTrue(hols[14].Regions.Length == 15);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteImmaculateConception2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[15].IsPublic == false);
            Assert.IsTrue(hols[15].HolidayDate == new DateTime(2024, 12, 8));
            Assert.IsTrue(hols[15].Regions.Length == 13);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteChristmas2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[16].IsPublic == true);
            Assert.IsTrue(hols[16].HolidayDate == new DateTime(2024, 12, 25));
            Assert.IsTrue(hols[16].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteSaintStephensDay2024()
        {
            var holidayCalendar = new SwitzerlandPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[17].IsPublic == false);
            Assert.IsTrue(hols[17].HolidayDate == new DateTime(2024, 12, 26));
            Assert.IsTrue(hols[17].Regions.Length == 22);
        }
    }
}
