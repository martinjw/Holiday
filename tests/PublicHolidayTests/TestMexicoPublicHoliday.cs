using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestMexicoPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 5)]
        [DataRow(3, 18)]
        [DataRow(5, 1)]
        [DataRow(9, 16)]
        [DataRow(11, 18)]
        [DataRow(12, 25)]
        public void TestHolidays2024(int month, int day)
        {
            var holiday = new DateTime(2024, month, day, 0, 0, 0, DateTimeKind.Local);
            var holidayCalendar = new MexicoPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(10, 1)]
        public void TestPresidentialInaugurationHoliday2030(int month, int day)
        {
            var holiday = new DateTime(2030, month, day, 0, 0, 0, DateTimeKind.Local);
            var holidayCalendar = new MexicoPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }


        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 3)]
        [DataRow(3, 17)]
        [DataRow(5, 1)]
        [DataRow(9, 16)]
        [DataRow(11, 17)]
        [DataRow(12, 25)]
        public void TestHolidays2025(int month, int day)
        {
            var holiday = new DateTime(2025, month, day, 0, 0, 0, DateTimeKind.Local);
            var holidayCalendar = new MexicoPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        public void TestHolidays2024Lists()
        {
            var holidayCalendar = new MexicoPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.IsTrue(8 == hols.Count, "Should be 8 holidays in 2024");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }
    }
}
