using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestRomanianPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1, "New Year")]
        [DataRow(1, 2, "New Year")]
        [DataRow(1, 24, "Day of the Unification of the Romanian Principalities")]
        [DataRow(4, 14, "Easter Orthodox Good Friday")]
        [DataRow(4, 16, "Easter")]
        [DataRow(4, 17, "Easter Monday")]
        [DataRow(5, 1, "Labour Day")]
        [DataRow(6, 1, "Children Day")]
        [DataRow(6, 4, "Whit Day")]
        [DataRow(6, 5, "Whit Monday")]
        [DataRow(8, 15, "Saint Mary Day")]
        [DataRow(11, 30, "Saint Andrew Day")]
        [DataRow(12, 1, "National Day")]
        [DataRow(12, 25, "Christmas Day")]
        [DataRow(12, 26, "Christmas Next Day")]
        public void TestRomanianHolidays2023(int month, int day, string name)
        {
            var holiday = new DateTime(2023, month, day);
            var holidayCalendar = new RomanianPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        [DataTestMethod]
        [DataRow(2010, 4, 4, "Easter 2010")]
        [DataRow(2015, 4, 12, "Easter 2015")]
        [DataRow(2018, 4, 8, "Easter 2018")]
        [DataRow(2019, 4, 28, "Easter 2019")]
        [DataRow(2020, 4, 19, "Easter 2020")]
        public void TestOrthodoxEasterRange2018_2019_2020(int year, int month, int day, string name)
        {
            var holiday = new DateTime(year, month, day);
            var holidayCalendar = new RomanianPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        /// <summary>
        /// Before 2016 Children Day was not a public holiday.
        /// Expect 14 items in list
        /// </summary>
        [TestMethod]
        public void TestRomanianHolidays2016List()
        {
            var holidayCalendar = new RomanianPublicHoliday();
            var holidays = holidayCalendar.PublicHolidayNames(2016);

            Assert.IsTrue(14 == holidays.Count, "Should be 14 holidays in 2016");
        }

        /// <summary>
        /// After 2017 Children Day was added as a public holiday.
        /// Expect 15 items in list
        /// </summary>
        [TestMethod]
        public void TestRomanianHolidays2017List()
        {
            var holidayCalendar = new RomanianPublicHoliday();
            var holidays = holidayCalendar.PublicHolidayNames(2017);

            Assert.IsTrue(15 == holidays.Count, "Should be 15 holidays in 2017");
        }

        /// <summary>
        /// After 2024 Epiphany and Saint John the Baptist were added as a public holidays.
        /// Expect 17 items in list
        /// </summary>
        [TestMethod]
        public void TestRomanianHolidays2024List()
        {
            var holidayCalendar = new RomanianPublicHoliday();
            var holidays = holidayCalendar.PublicHolidayNames(2024);

            Assert.IsTrue(17 == holidays.Count, "Should be 17 holidays in 2024");
        }
    }
}
