using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestSouthAfricaPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 2, "New year - observed on Monday")]
        [DataRow(3, 21, "Human Rights Day")]
        [DataRow(4, 14, "Good Friday")]
        [DataRow(4, 17, "Family Day")]
        [DataRow(4, 27, "Freedom Day")]
        [DataRow(5, 1, "Workers' Day")]
        [DataRow(6, 16, "Youth Day")]
        [DataRow(8, 9, "National Women's Day")]
        [DataRow(9, 25, "Heritage Day")]
        [DataRow(12, 18, "Day of Reconciliation")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestHolidays2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(12 == hols.Count, "Should be 12 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }
    }
}
