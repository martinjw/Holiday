using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    /// <summary>
    /// Test the Slovak Bank Holidays
    /// </summary>
    [TestClass]
    public class TestCzechRepublicPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 14)]
        [DataRow(4, 17)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(5, 9)]
        [DataRow(5, 25)]
        [DataRow(6, 5)]
        [DataRow(6, 15)]
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        public void TestCzNoHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 25)]
        [DataRow(3, 28)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays2016(int month, int day)
        {
            var holiday = new DateTime(2016, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(5, 9)]
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        public void TestCzNoHolidays2016(int month, int day)
        {
            var holiday = new DateTime(2016, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 6)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays2015(int month, int day)
        {
            var holiday = new DateTime(2015, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(4, 3)]
        [DataRow(1, 6)]
        [DataRow(5, 9)]
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        public void TestCzNoHolidays2015(int month, int day)
        {
            var holiday = new DateTime(2015, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(5, 21)]
        [DataRow(6, 11)]
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(12, 25)]
        public void TestCzHolidays1925(int month, int day)
        {
            var holiday = new DateTime(1925, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(4, 10)]
        [DataRow(4, 12)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(6, 1)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        [DataRow(12, 26)]
        public void TestCzNoHolidays1925(int month, int day)
        {
            var holiday = new DateTime(1925, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(5, 26)]
        [DataRow(6, 16)]
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(12, 25)]
        public void TestCzHolidays1938(int month, int day)
        {
            var holiday = new DateTime(1938, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(4, 15)]
        [DataRow(4, 18)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(6, 6)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        [DataRow(12, 26)]
        public void TestCzNoHolidays1938(int month, int day)
        {
            var holiday = new DateTime(1938, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 10)]
        [DataRow(5, 18)]
        [DataRow(5, 29)]
        [DataRow(6, 8)]
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1939(int month, int day)
        {
            var holiday = new DateTime(1939, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(4, 7)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1939(int month, int day)
        {
            var holiday = new DateTime(1939, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 22)]
        [DataRow(5, 30)]
        [DataRow(6, 10)]
        [DataRow(6, 20)]
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1946(int month, int day)
        {
            var holiday = new DateTime(1946, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(4, 18)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1946(int month, int day)
        {
            var holiday = new DateTime(1946, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 4)]
        [DataRow(5, 15)]
        [DataRow(6, 5)]
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1947(int month, int day)
        {
            var holiday = new DateTime(1947, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(4, 7)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(5, 26)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1947(int month, int day)
        {
            var holiday = new DateTime(1947, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(3, 26)]  // Good Friday
        [DataRow(5, 6)]  // Ascension 
        [DataRow(5, 17)] // Pentecost Monday
        [DataRow(5, 27)] // Corpus Christi
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1948(int month, int day)
        {
            var holiday = new DateTime(1948, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(3, 29)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1948(int month, int day)
        {
            var holiday = new DateTime(1948, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 15)]  // Good Friday
        [DataRow(4, 18)] // Easter Monday
        [DataRow(5, 26)]  // Ascension 
        [DataRow(6, 6)] // Pentecost Monday
        [DataRow(6, 16)] // Corpus Christi
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1949(int month, int day)
        {
            var holiday = new DateTime(1949, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1949(int month, int day)
        {
            var holiday = new DateTime(1949, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(3, 23)]  // Good Friday
        [DataRow(3, 26)] // Easter Monday
        [DataRow(5, 3)]  // Ascension 
        [DataRow(5, 14)] // Pentecost Monday
        [DataRow(5, 24)] // Corpus Christi
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1951(int month, int day)
        {
            var holiday = new DateTime(1951, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1951(int month, int day)
        {
            var holiday = new DateTime(1951, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 14)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1952(int month, int day)
        {
            var holiday = new DateTime(1952, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 11)]  // Good Friday
        [DataRow(5, 22)]  // Ascension 
        [DataRow(6, 2)] // Pentecost Monday
        [DataRow(6, 12)] // Corpus Christi
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1952(int month, int day)
        {
            var holiday = new DateTime(1952, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 15)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1974(int month, int day)
        {
            var holiday = new DateTime(1974, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 12)]  // Good Friday
        [DataRow(5, 23)]  // Ascension 
        [DataRow(6, 3)] // Pentecost Monday
        [DataRow(6, 13)] // Corpus Christi
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1974(int month, int day)
        {
            var holiday = new DateTime(1974, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 31)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1975(int month, int day)
        {
            var holiday = new DateTime(1975, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(3, 28)]  // Good Friday
        [DataRow(5, 8)]  // Ascension 
        [DataRow(5, 19)] // Pentecost Monday
        [DataRow(5, 29)] // Corpus Christi
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1975(int month, int day)
        {
            var holiday = new DateTime(1975, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 20)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1987(int month, int day)
        {
            var holiday = new DateTime(1987, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 17)]  // Good Friday
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1987(int month, int day)
        {
            var holiday = new DateTime(1987, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 4)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1988(int month, int day)
        {
            var holiday = new DateTime(1988, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 1)]  // Good Friday
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1988(int month, int day)
        {
            var holiday = new DateTime(1988, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 27)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1989(int month, int day)
        {
            var holiday = new DateTime(1989, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(3, 24)]  // Good Friday
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestCzNoHolidays1989(int month, int day)
        {
            var holiday = new DateTime(1989, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 16)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(7, 5)]
        [DataRow(10, 28)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1990(int month, int day)
        {
            var holiday = new DateTime(1990, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 13)]  // Good Friday
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 8)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 8)]
        public void TestCzNoHolidays1990(int month, int day)
        {
            var holiday = new DateTime(1990, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 1)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(7, 5)]
        [DataRow(10, 28)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1991(int month, int day)
        {
            var holiday = new DateTime(1991, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(3, 29)]  // Good Friday
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 8)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 8)]
        public void TestCzNoHolidays1991(int month, int day)
        {
            var holiday = new DateTime(1991, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 20)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(10, 28)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1992(int month, int day)
        {
            var holiday = new DateTime(1992, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 17)]  // Good Friday
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 9)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 8)]
        public void TestCzNoHolidays1992(int month, int day)
        {
            var holiday = new DateTime(1992, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 5)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(10, 28)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays1999(int month, int day)
        {
            var holiday = new DateTime(1999, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 2)]  // Good Friday
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 9)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 8)]
        public void TestCzNoHolidays1999(int month, int day)
        {
            var holiday = new DateTime(1999, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 24)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays2000(int month, int day)
        {
            var holiday = new DateTime(2000, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 21)]  // Good Friday
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 9)]
        [DataRow(7, 6)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        public void TestCzNoHolidays2000(int month, int day)
        {
            var holiday = new DateTime(2000, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 16)] // Easter Monday
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(7, 6)]
        [DataRow(9, 28)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestCzHolidays2001(int month, int day)
        {
            var holiday = new DateTime(2001, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 13)]  // Good Friday
        [DataRow(6, 29)]
        [DataRow(8, 15)]
        [DataRow(5, 9)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        public void TestCzNoHolidays2001(int month, int day)
        {
            var holiday = new DateTime(2001, month, day);
            var holidayCalendar = new CzechRepublicPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        /// <summary>
        /// Test Easter Monday
        /// </summary>
        [TestMethod]
        public void TestEasterMonday()
        {
            var expected = new DateTime(2017, 4, 17);
            var actual = CzechRepublicPublicHoliday.EasterMonday(2017);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2000, 4, 24);
            actual = CzechRepublicPublicHoliday.EasterMonday(2000);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2005, 3, 28);
            actual = CzechRepublicPublicHoliday.EasterMonday(2005);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Good Friday (Easter)
        /// </summary>
        [TestMethod]
        public void TestGoodFriday()
        {
            var expected = new DateTime(2017, 4, 14);
            var actual = CzechRepublicPublicHoliday.GoodFriday(2017);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2016, 3, 25);
            actual = CzechRepublicPublicHoliday.GoodFriday(2016);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Good Friday (Easter) Before 1994
        /// </summary>
        [TestMethod]
        public void TestGoodFridayBefore2015()
        {

            Assert.IsFalse(new CzechRepublicPublicHoliday().IsPublicHoliday(new DateTime(2015, 4, 3)));
            Assert.IsFalse(new CzechRepublicPublicHoliday().IsPublicHoliday(new DateTime(1993, 4, 9)));
            Assert.IsFalse(new CzechRepublicPublicHoliday().IsPublicHoliday(new DateTime(1990, 4, 13)));
            Assert.IsFalse(new CzechRepublicPublicHoliday().IsPublicHoliday(new DateTime(1980, 4, 4)));

            
            Assert.IsTrue(new CzechRepublicPublicHoliday().IsPublicHoliday(new DateTime(2017, 4, 14)));
            Assert.IsTrue(new CzechRepublicPublicHoliday().IsPublicHoliday(new DateTime(2016, 3, 25)));
        }

        /// <summary>
        /// Sat, no holiday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySat()
        {
            var expected = new DateTime(2017, 6, 5);
            var actual = new CzechRepublicPublicHoliday().NextWorkingDay(new DateTime(2017, 6, 3));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Sun, no holiday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySunday()
        {
            var expected = new DateTime(2017, 6, 12);
            var actual = new CzechRepublicPublicHoliday().NextWorkingDay(new DateTime(2017, 6, 11));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Good Friday, next working day is next Tuesday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayEaster()
        {
            var expected = new DateTime(2017, 4, 18);
            var actual = new CzechRepublicPublicHoliday().NextWorkingDay(new DateTime(2017, 4, 14));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ChristmasEve2014, on Wednesday (holiday), next working day is next Monday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayChristmasEve2014()
        {
            var expected = new DateTime(2014, 12, 29);
            var actual = new CzechRepublicPublicHoliday().NextWorkingDay(new DateTime(2014, 12, 24));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// holiday with another following
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayXmas()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new CzechRepublicPublicHoliday().NextWorkingDay(new DateTime(2006, 12, 25));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Saturday, holiday on Monday with another following
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySatBeforeXMas()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new CzechRepublicPublicHoliday().NextWorkingDay(new DateTime(2006, 12, 23));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayBoxingDay()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new CzechRepublicPublicHoliday().NextWorkingDay(new DateTime(2006, 12, 26));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Previous working days
        /// </summary>
        [TestMethod]
        public void TestPreviousWorkingDay()
        {
            var actual = new CzechRepublicPublicHoliday().PreviousWorkingDay(new DateTime(2016, 1, 1)); //Friday
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);

            actual = new CzechRepublicPublicHoliday().PreviousWorkingDay(new DateTime(2014, 12, 28)); // Sunday
            Assert.AreEqual(new DateTime(2014, 12, 23), actual);

            actual = new CzechRepublicPublicHoliday().PreviousWorkingDay(new DateTime(2014, 12, 29)); // Monday
            Assert.AreEqual(new DateTime(2014, 12, 29), actual);

            actual = new CzechRepublicPublicHoliday().PreviousWorkingDay(new DateTime(2016, 1, 3)); // Sunday
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);

            actual = new CzechRepublicPublicHoliday().PreviousWorkingDay(new DateTime(2016, 1, 4)); // Monday
            Assert.AreEqual(new DateTime(2016, 1, 4), actual); //is a working day

            actual = new CzechRepublicPublicHoliday().PreviousWorkingDay(new DateTime(2016, 1, 3, 11, 31, 0, 0)); //Sun with date
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);
        }
        
    }
}
