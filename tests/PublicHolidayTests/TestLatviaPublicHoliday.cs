using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestLatviaPublicHoliday
    {
        [TestMethod]
        [DataRow(1, 1, "New Year's Day")]
        [DataRow(4, 18, "Good Friday")] // Moving holiday
        [DataRow(4, 20, "Easter Sunday")] // Moving holiday
        [DataRow(4, 21, "Easter Monday")] // Moving holiday
        [DataRow(5, 1, "Labour Day")]
        [DataRow(5, 4, "Restoration of Independence Day")]
        [DataRow(5, 5, "Restoration of Independence Day (moved from Sunday)")]
        [DataRow(5, 11, "Mother's Day")] // Second Sunday of May
        [DataRow(6, 8, "Pentecost")] // Moving holiday
        [DataRow(6, 23, "Midsummer Eve")]
        [DataRow(6, 24, "Midsummer Day")]
        [DataRow(11, 18, "Proclamation Day")]
        [DataRow(12, 24, "Christmas Eve")]
        [DataRow(12, 25, "Christmas Day")]
        [DataRow(12, 26, "Second Day of Christmas")]
        [DataRow(12, 31, "New Year's Eve")]
        public void TestLatvianHolidays2025(int month, int day, string name)
        {
            var holiday = new DateTime(2025, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        [TestMethod]
        public void TestLatvianHolidays2025List()
        {
            var holidays = new LatviaPublicHoliday().PublicHolidayNames(2025);

            Assert.AreEqual(16, holidays.Count, "Should be 16 holidays in 2025");
        }

        [TestMethod]
        [DataRow(2008, 5, 5, "4 May on Sunday")]
        [DataRow(2007, 11, 19, "18 November on Sunday")]
        [DataRow(2023, 11, 20, "18 November on Saturday")]
        [DataRow(2024, 5, 6, "4 May on Saturday")]
        [DataRow(2028, 11, 20, "18 November on Saturday")]
        public void TestLatvianTransferredHolidays(int year, int month, int day, string reason)
        {
            var holiday = new DateTime(year, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - {reason}");
        }

        [TestMethod]
        [DataRow(2024, 5, 7)] // 4 May on Saturday moves to Monday only
        [DataRow(2024, 11, 19)] // 18 November on Monday, no transfer
        [DataRow(2026, 5, 5)] // 4 May on Monday, no transfer
        public void TestLatvianNotTransferred(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(date);

            Assert.IsFalse(actual, $"{date:D} should not be a holiday");
        }

        /// <summary>
        /// Before 2007 Christmas Eve was not a public holiday and 4 May / 18 November were not moved.
        /// </summary>
        [TestMethod]
        public void TestLatvianHolidays2006()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2006, 12, 24)), "Christmas Eve from 2007");
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2006, 11, 20)), "Transfer rule from 2007");
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2006, 5, 4)));
        }

        /// <summary>
        /// Before 2002 4 May was not a public holiday.
        /// </summary>
        [TestMethod]
        public void TestLatvianHolidays2001()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2001, 5, 4)));
        }

        [TestMethod]
        public void TestLatvianMothersDayOnPentecost()
        {
            var holidays = new LatviaPublicHoliday().PublicHolidayNames(2008);

            Assert.AreEqual("Mātes diena, Vasarsvētki", holidays[new DateTime(2008, 5, 11)]);
        }

        [TestMethod]
        [DataRow(2018, 7, 8, "Song and Dance Festival closing day")]
        [DataRow(2018, 7, 9, "Song and Dance Festival closing day (moved from Sunday)")]
        [DataRow(2023, 5, 29, "Ice hockey bronze medal")]
        [DataRow(2023, 7, 9, "Song and Dance Festival closing day")]
        [DataRow(2023, 7, 10, "Song and Dance Festival closing day (moved from Sunday)")]
        public void TestLatvianSpecialHolidays(int year, int month, int day, string name)
        {
            var holiday = new DateTime(year, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        [TestMethod]
        public void TestLatvianSpecialHolidaysOnlyInTheirYear()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2024, 5, 29)));
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2024, 7, 8)));
        }
    }
}
