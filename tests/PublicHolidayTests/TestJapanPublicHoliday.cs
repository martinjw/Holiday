using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestJapanPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 2, "New year - observed on Monday")]
        [DataRow(1, 9, "Coming of Age Day")]
        [DataRow(2, 11, "Foundation Day (Saturday)")]
        [DataRow(3, 20, "Vernal Equinox Day")]
        [DataRow(4, 29, "Showa Day")]
        [DataRow(5, 3, "Constitution Memorial Day")]
        [DataRow(5, 4, "Greenery Day")]
        [DataRow(5, 5, "Children's Day")]
        [DataRow(7, 17, "Marine Day")]
        [DataRow(8, 11, "Mountain Day")]
        [DataRow(9, 18, "Respect for the Aged Day")]
        [DataRow(9, 23, "Autumnal Equinox Day")]
        [DataRow(10, 9, "Health and Sports Day")]
        [DataRow(11, 3, "Culture Day")]
        [DataRow(11, 23, "Labour Thanksgiving Day")]
        [DataRow(12, 23, "The Emperor's Birthday")]
        public void TestHolidays2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new JapanPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new JapanPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(16 == hols.Count, "Should be 16 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }
    }
}