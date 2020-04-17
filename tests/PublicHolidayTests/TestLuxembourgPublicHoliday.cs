using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestLuxembourgPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 17)]
        [DataRow(5, 1)]
        [DataRow(5, 25)]
        [DataRow(6, 5)]
        [DataRow(6, 23)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new LuxembourgPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new LuxembourgPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(10 == hols.Count, "Should be 10 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestAscension()
        {
            //Issue #40
            var h = new LuxembourgPublicHoliday();
            var days = h.PublicHolidays(2008);
            //should not be an error because Ascension = MayDay
            Assert.IsTrue(days.Contains(new DateTime(2008, 5, 1)), "Should contain 2 - MayDay and Ascension");
        }
    }
}