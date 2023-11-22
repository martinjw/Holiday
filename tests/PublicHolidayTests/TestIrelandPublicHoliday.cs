using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestIrelandPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1, "New year")]
        [DataRow(3, 17, "St Patrick's")]
        [DataRow(4, 17, "Easter Monday")]
        [DataRow(5, 1, "May Day")]
        [DataRow(6, 5, "June Holiday")]
        [DataRow(8, 7, "August Holiday")]
        [DataRow(10, 30, "October Holiday")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 26, "St Stephens")]
        public void TestHolidays2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new IrelandPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new IrelandPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(9 == hols.Count, "Should be 9 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [DataTestMethod]
        [DataRow(1, 1, "New year")]
        [DataRow(2, 5, "St Brigid's")]
        [DataRow(3, 17, "St Patrick's")]
        [DataRow(4, 1, "Easter Monday")]
        [DataRow(5, 6, "May Day")]
        [DataRow(6, 3, "June Holiday")]
        [DataRow(8, 5, "August Holiday")]
        [DataRow(10, 28, "October Holiday")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 26, "St Stephens")]
        public void TestHolidays2024(int month, int day, string name)
        {
            var holiday = new DateTime(2024, month, day);
            var holidayCalendar = new IrelandPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        public void TestStBrigid()
        {
            var holidayCalendar = new IrelandPublicHoliday();
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2022, 2, 5)));
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2023, 2, 6)));
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2024, 2, 5)));
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2025, 2, 3)));
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2030, 2, 1)));

            Assert.IsTrue(holidayCalendar.PublicHolidays(2023).Contains(new DateTime(2023, 2, 6)));
            Assert.IsTrue(holidayCalendar.PublicHolidays(2025).Contains(new DateTime(2025, 2, 3)));
            Assert.IsTrue(holidayCalendar.PublicHolidays(2030).Contains(new DateTime(2030, 2, 1)));
        }

    }
}