using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Linq;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestSloveniaPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        [DataRow(2, 8)]
        [DataRow(4, 27)]
        [DataRow(5, 1)]
        [DataRow(5, 2)]
        [DataRow(6, 25)]
        [DataRow(8, 15)]
        [DataRow(10, 31)]
        [DataRow(11, 1)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new SloveniaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        public void TestEasterMondayOnYear2022()
        {
            var holiday = new DateTime(2022, 4, 18);
            var holidayCalendar = new SloveniaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, "Easter monday in year 2022 should be on 18.4.");
        }
    }
}