using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestPolandPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1,"New year")]
        [DataRow(1, 6, "Epiphany")]
        [DataRow(4, 17, "Easter Monday")]
        [DataRow(5, 1, "Labour Day")]
        [DataRow(5, 3, "Constitution Day")]
        [DataRow(6, 15, "Corpus Christi")]
        [DataRow(8, 15, "Assumption")]
        [DataRow(11, 1, "All Saints")]
        [DataRow(11, 11, "Independence Day")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 26, "St Stephens")]
        public void TestHolidays2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new PolandPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new PolandPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(11 == hols.Count, "Should be 11 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }
    }
}