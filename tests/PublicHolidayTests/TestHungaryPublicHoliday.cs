using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    /// <summary>
    /// Test the Hungarian Bank Holidays
    /// </summary>
    [TestClass]
    public class TestHungaryPublicHoliday
    {
        [TestMethod]
        [DataRow(1, 1)]   // New Year
        [DataRow(3, 15)]  // Revolution 1848
        [DataRow(4, 14)]  // Good Friday 2017
        [DataRow(4, 17)]  // Easter Monday 2017
        [DataRow(5, 1)]   // Workers Day
        [DataRow(6, 5)]   // Pentecost Monday 2017
        [DataRow(8, 20)]  // St. Stephen
        [DataRow(10, 23)] // Revolution 1956
        [DataRow(11, 1)]  // All Saints
        [DataRow(12, 25)] // Xmas 1
        [DataRow(12, 26)] // Xmas 2
        public void TestHuHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new HungaryPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        [DataRow(1, 6)]   // Epiphany (Holiday in SK, not in HU)
        [DataRow(5, 8)]   // Victory Day (Holiday in CZ, not in HU)
        [DataRow(11, 17)] // Velvet Revolution (Holiday in CZ, not in HU)
        [DataRow(12, 24)] // Christmas Eve (Holiday in CZ, not in HU)
        public void TestHuNoHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new HungaryPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        /// <summary>
        /// Test that Good Friday was NOT a holiday in 2016
        /// </summary>
        [TestMethod]
        public void TestHuGoodFridayBefore2017()
        {
            var calendar = new HungaryPublicHoliday();

            // In 2016, Good Friday was March 25th
            var goodFriday2016 = new DateTime(2016, 3, 25);
            Assert.IsFalse(calendar.IsPublicHoliday(goodFriday2016), "Good Friday should not be a holiday before 2017");

            // In 2017, it should be a holiday
            var goodFriday2017 = new DateTime(2017, 4, 14);
            Assert.IsTrue(calendar.IsPublicHoliday(goodFriday2017), "Good Friday should be a holiday from 2017 onwards");
        }

        [TestMethod]
        public void TestHuEasterMonday()
        {
            var calendar = new HungaryPublicHoliday();

            // 2017
            Assert.AreEqual(new DateTime(2017, 4, 17), HungaryPublicHoliday.EasterMonday(2017));
            // 2026
            Assert.AreEqual(new DateTime(2026, 4, 6), HungaryPublicHoliday.EasterMonday(2026));
        }

        [TestMethod]
        public void TestHuPentecostMonday()
        {
            var calendar = new HungaryPublicHoliday();

            // 2017 (Easter Sunday + 50 days)
            Assert.AreEqual(new DateTime(2017, 6, 5), HungaryPublicHoliday.PentecostMonday(2017));
            // 2026
            Assert.AreEqual(new DateTime(2026, 5, 25), HungaryPublicHoliday.PentecostMonday(2026));
        }

        [TestMethod]
        public void TestHuNextWorkingDayEaster2017()
        {
            var calendar = new HungaryPublicHoliday();
            // Friday 14th April is holiday (Good Friday)
            // Sat 15th, Sun 16th, Mon 17th (Easter Monday)
            // Next working day should be Tuesday 18th April
            var expected = new DateTime(2017, 4, 18);
            var actual = calendar.NextWorkingDay(new DateTime(2017, 4, 14));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHuPreviousWorkingDay()
        {
            var calendar = new HungaryPublicHoliday();

            // 1st Jan 2017 is Sunday (Holiday)
            // Previous working day should be Friday 30th Dec 2016
            var actual = calendar.PreviousWorkingDay(new DateTime(2017, 1, 1));
            Assert.AreEqual(new DateTime(2016, 12, 30), actual);
        }
    }
}