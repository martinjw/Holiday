using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestKazakhstanPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        [DataRow(1, 7)]
        [DataRow(3, 8)]
        [DataRow(3, 21)]
        [DataRow(3, 22)]
        [DataRow(3, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 7)]
        [DataRow(5, 9)]
        [DataRow(7, 6)]
        [DataRow(8, 30)]
        [DataRow(9, 1)]
        [DataRow(12, 1)]
        [DataRow(12, 16)]
        [DataRow(12, 17)]
        public void TestHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new KazakhstanPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.AreEqual(true, actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        public void TestHas16HolidaysIn2017()
        {
            var holidayCalendar = new KazakhstanPublicHoliday();
            var actual = holidayCalendar.PublicHolidays(2017).Count;
            Assert.AreEqual(16, actual);
        }
    }
}
