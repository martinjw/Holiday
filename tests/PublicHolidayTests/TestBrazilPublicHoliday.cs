using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestBrazilPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 12)]
        [DataRow(2, 13)]
        [DataRow(3, 29)]
        [DataRow(4, 21)]
        [DataRow(5, 1)]
        [DataRow(5, 30)]
        [DataRow(9, 7)]
        [DataRow(10, 12)]
        [DataRow(11, 2)]
        [DataRow(11, 15)]
        [DataRow(12, 25)]
        public void TestHolidays2024(int month, int day)
        {
            var holiday = new DateTime(2024, month, day);
            var holidayCalendar = new BrazilPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 3)]
        [DataRow(3, 4)]
        [DataRow(4, 18)]
        [DataRow(4, 21)]
        [DataRow(5, 1)]
        [DataRow(6, 19)]
        [DataRow(9, 7)]
        [DataRow(10, 12)]
        [DataRow(11, 2)]
        [DataRow(11, 15)]
        [DataRow(12, 25)]
        public void TestHolidays2025(int month, int day)
        {
            var holiday = new DateTime(2025, month, day);
            var holidayCalendar = new BrazilPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        public void TestHolidays2024Lists()
        {
            var holidayCalendar = new BrazilPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.IsTrue(12 == hols.Count, "Should be 12 holidays in 2024");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }
    }
}
