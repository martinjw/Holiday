using System;
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
        public void TestEaster2017()
        {
            var expected = new DateTime(2017, 4, 16);
            var actual = SwitzerlandPublicHoliday.Easter(2017);
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
        public void TestWhitSunday2017()
        {
            var expected = new DateTime(2017, 6, 4);
            var actual = SwitzerlandPublicHoliday.WhitSunday(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNationalDay2017() {
            var expected = new DateTime(2017, 8, 1);
            var actual = SwitzerlandPublicHoliday.NationalDay(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmasEve2017() {
            var expected = new DateTime(2017, 12, 24);
            var actual = SwitzerlandPublicHoliday.ChristmasEve(2017);
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
        public void TestNewYearsEve2017() {
            var expected = new DateTime(2017, 12, 31);
            var actual = SwitzerlandPublicHoliday.NewYearsEve(2017);
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
    }
}
