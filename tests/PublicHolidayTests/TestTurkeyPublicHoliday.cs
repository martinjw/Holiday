using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Globalization;
using System.Linq;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestTurkeyPublicHoliday
    {
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(4, 21)]
        [DataRow(4, 22)]
        [DataRow(5, 19)]
        [DataRow(6, 28)]
        [DataRow(6, 29)]
        [DataRow(6, 30)]
        [DataRow(7, 1)]
        [DataRow(8, 30)]
        [DataRow(10, 29)]
        [DataRow(7, 15)]
        public void TestHolidays2023(int month, int day)
        {
            var holiday = new DateTime(2023, month, day);
            var holidayCalendar = new TurkeyPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 2)]
        [DataRow(5, 3)]
        [DataRow(5, 4)]
        [DataRow(5, 19)]
        [DataRow(7, 9)]
        [DataRow(7, 10)]
        [DataRow(7, 11)]
        [DataRow(7, 12)]
        [DataRow(7, 15)]
        [DataRow(8, 30)]
        [DataRow(10, 29)]
        public void TestHolidays2022(int month, int day)
        {
            var holiday = new DateTime(2022, month, day);
            var holidayCalendar = new TurkeyPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 13)]
        [DataRow(5, 14)]
        [DataRow(5, 15)]
        [DataRow(5, 19)]
        [DataRow(7, 20)]
        [DataRow(7, 21)]
        [DataRow(7, 22)]
        [DataRow(7, 23)]
        [DataRow(7, 15)]
        [DataRow(8, 30)]
        [DataRow(10, 29)]
        public void TestHolidays2021(int month, int day)
        {
            var holiday = new DateTime(2021, month, day);
            var holidayCalendar = new TurkeyPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        // Ramadan Bayram (Shawwal 1 / Eid al-Fitr) dates (UmAlQura algorithmic calendar) for years 2020-2040
        [DataRow(2020, 5, 24)]
        [DataRow(2021, 5, 13)]
        [DataRow(2022, 5, 2)]
        [DataRow(2023, 4, 21)]
        [DataRow(2024, 4, 10)]
        [DataRow(2025, 3, 30)]
        [DataRow(2026, 3, 20)]
        [DataRow(2027, 3, 9)]
        [DataRow(2028, 2, 26)]
        [DataRow(2029, 2, 14)]
        [DataRow(2030, 2, 4)]
        [DataRow(2031, 1, 24)]
        [DataRow(2032, 1, 14)]
        [DataRow(2033, 1, 2)]
        [DataRow(2034, 12, 12)]
        [DataRow(2035, 12, 1)]
        [DataRow(2036, 11, 19)]
        [DataRow(2037, 11, 8)]
        [DataRow(2038, 10, 29)]
        [DataRow(2039, 10, 19)]
        [DataRow(2040, 10, 7)]
        public void TestRamadanYearShifts(int year, int month, int day)
        {
            var expected = new DateTime(year, month, day);
            var ramadan1 = TurkeyPublicHoliday.RamadanFirstDay(year).First();
            Assert.AreEqual(expected, ramadan1, $"Expected Ramadan Bayram (Shawwal 1) for {year} to be {expected:yyyy-MM-dd} but was {ramadan1:yyyy-MM-dd}");
        }

        [TestMethod]
        public void TestHolidaysLists()
        {
            var holidayCalendar = new TurkeyPublicHoliday();
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            for (var year = 2015; year < 2040; year++)
            {
                //looking for collisions
                var holNames = holidayCalendar.PublicHolidayNames(year);
                var hols = holidayCalendar.PublicHolidays(year);
                foreach (var holiday in holNames.Keys)
                {
                    Assert.IsTrue(holidayCalendar.IsPublicHoliday(holiday),
                        $"Should be holiday: {holNames[holiday]} {holiday:yyyy-MM-dd}");
                }
            }
        }
    }
}
