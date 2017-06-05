using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    /// <summary>
    /// Test the Slovak Bank Holidays
    /// </summary>
    [TestClass]
    public class TestSlovakiaPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 14)]
        [DataRow(4, 17)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        public void TestSkNoHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 14)]
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1952(int month, int day)
        {
            var holiday = new DateTime(1952, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 11)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestSkNoHolidays1952(int month, int day)
        {
            var holiday = new DateTime(1952, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 15)]
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1974(int month, int day)
        {
            var holiday = new DateTime(1974, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 12)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestSkNoHolidays1974(int month, int day)
        {
            var holiday = new DateTime(1974, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 31)]
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1975(int month, int day)
        {
            var holiday = new DateTime(1975, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(3, 28)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(10, 28)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestSkNoHolidays1975(int month, int day)
        {
            var holiday = new DateTime(1975, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 20)]
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1987(int month, int day)
        {
            var holiday = new DateTime(1987, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 17)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(10, 28)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestSkNoHolidays1987(int month, int day)
        {
            var holiday = new DateTime(1987, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 4)]
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1988(int month, int day)
        {
            var holiday = new DateTime(1988, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestSkNoHolidays1988(int month, int day)
        {
            var holiday = new DateTime(1988, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 27)]
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1989(int month, int day)
        {
            var holiday = new DateTime(1989, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(3, 24)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        public void TestSkNoHolidays1989(int month, int day)
        {
            var holiday = new DateTime(1989, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 16)]
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(7, 5)]
        [DataRow(10, 28)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1990(int month, int day)
        {
            var holiday = new DateTime(1990, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 13)]
        [DataRow(5, 8)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        public void TestSkNoHolidays1990(int month, int day)
        {
            var holiday = new DateTime(1990, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 1)]
        [DataRow(5, 1)]
        [DataRow(5, 9)]
        [DataRow(7, 5)]
        [DataRow(10, 28)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1991(int month, int day)
        {
            var holiday = new DateTime(1991, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(3, 29)]
        [DataRow(5, 8)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        public void TestSkNoHolidays1991(int month, int day)
        {
            var holiday = new DateTime(1991, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 20)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(10, 28)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1992(int month, int day)
        {
            var holiday = new DateTime(1992, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 17)]
        [DataRow(5, 9)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        public void TestSkNoHolidays1992(int month, int day)
        {
            var holiday = new DateTime(1992, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 12)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(10, 28)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1993(int month, int day)
        {
            var holiday = new DateTime(1993, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 6)]
        [DataRow(4, 9)]
        [DataRow(5, 9)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        public void TestSkNoHolidays1993(int month, int day)
        {
            var holiday = new DateTime(1993, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 1)]
        [DataRow(4, 4)]
        [DataRow(5, 1)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1994(int month, int day)
        {
            var holiday = new DateTime(1994, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        public void TestSkNoHolidays1994(int month, int day)
        {
            var holiday = new DateTime(1994, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 5)]
        [DataRow(4, 8)]
        [DataRow(5, 1)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1996(int month, int day)
        {
            var holiday = new DateTime(1996, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(5, 8)]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        public void TestSkNoHolidays1996(int month, int day)
        {
            var holiday = new DateTime(1996, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(3, 28)]
        [DataRow(3, 31)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays1997(int month, int day)
        {
            var holiday = new DateTime(1997, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        public void TestSkNoHolidays1997(int month, int day)
        {
            var holiday = new DateTime(1997, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 21)]
        [DataRow(4, 24)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays2000(int month, int day)
        {
            var holiday = new DateTime(2000, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        [DataRow(11, 17)]
        public void TestSkNoHolidays2000(int month, int day)
        {
            var holiday = new DateTime(2000, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsFalse(actual, $"{holiday.ToString("D")} is a holiday (shouldn't be)");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 13)]
        [DataRow(4, 16)]
        [DataRow(5, 1)]
        [DataRow(5, 8)]
        [DataRow(7, 5)]
        [DataRow(8, 29)]
        [DataRow(9, 1)]
        [DataRow(9, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 17)]
        [DataRow(12, 24)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestSkHolidays2001(int month, int day)
        {
            var holiday = new DateTime(2001, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(5, 9)]
        [DataRow(10, 28)]
        public void TestSkNoHolidays2001(int month, int day)
        {
            var holiday = new DateTime(2001, month, day);
            var holidayCalendar = new SlovakiaPublicHoliday();
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
            var actual = SlovakiaPublicHoliday.EasterMonday(2017);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2000, 4, 24);
            actual = SlovakiaPublicHoliday.EasterMonday(2000);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2005, 3, 28);
            actual = SlovakiaPublicHoliday.EasterMonday(2005);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Good Friday (Easter)
        /// </summary>
        [TestMethod]
        public void TestGoodFriday()
        {
            var expected = new DateTime(2017, 4, 14);
            var actual = SlovakiaPublicHoliday.GoodFriday(2017);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2000, 4, 21);
            actual = SlovakiaPublicHoliday.GoodFriday(2000);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2005, 3, 25);
            actual = SlovakiaPublicHoliday.GoodFriday(2005);
            Assert.AreEqual(expected, actual);


        }

        /// <summary>
        /// Test Good Friday (Easter) Before 1994
        /// </summary>
        [TestMethod]
        public void TestGoodFridayBefore1994()
        {
            // few tests before 1994
            Assert.IsFalse(new SlovakiaPublicHoliday().IsPublicHoliday(new DateTime(1993, 4, 9)));
            Assert.IsFalse(new SlovakiaPublicHoliday().IsPublicHoliday(new DateTime(1990, 4, 13)));
            Assert.IsFalse(new SlovakiaPublicHoliday().IsPublicHoliday(new DateTime(1980, 4, 4)));

            // and others since 1994
            Assert.IsTrue(new SlovakiaPublicHoliday().IsPublicHoliday(new DateTime(1994, 4, 1)));
            Assert.IsTrue(new SlovakiaPublicHoliday().IsPublicHoliday(new DateTime(2000, 4, 21)));
            Assert.IsTrue(new SlovakiaPublicHoliday().IsPublicHoliday(new DateTime(2017, 4, 14)));
        }

        /// <summary>
        /// Test Holiday names of 1st January
        /// </summary>
        [TestMethod]
        public void Test1stJanuaryHolidayNames()
        {
            const string NewYearName = "Nový rok";
            const string EstablishmentName = "Deň vzniku Slovenskej republiky";

            Assert.AreEqual(new SlovakiaPublicHoliday().PublicHolidayNames(1952)[new DateTime(1952, 1, 1)], NewYearName);
            Assert.AreEqual(new SlovakiaPublicHoliday().PublicHolidayNames(1993)[new DateTime(1993, 1, 1)], NewYearName);

            Assert.AreEqual(new SlovakiaPublicHoliday().PublicHolidayNames(1994)[new DateTime(1994, 1, 1)], EstablishmentName);
            Assert.AreEqual(new SlovakiaPublicHoliday().PublicHolidayNames(2000)[new DateTime(2000, 1, 1)], EstablishmentName);
            Assert.AreEqual(new SlovakiaPublicHoliday().PublicHolidayNames(2017)[new DateTime(2017, 1, 1)], EstablishmentName);

        }

        /// <summary>
        /// Sat, no holiday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySat()
        {
            var expected = new DateTime(2017, 6, 5);
            var actual = new SlovakiaPublicHoliday().NextWorkingDay(new DateTime(2017, 6, 3));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Sun, no holiday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySunday()
        {
            var expected = new DateTime(2017, 6, 12);
            var actual = new SlovakiaPublicHoliday().NextWorkingDay(new DateTime(2017, 6, 11));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Good Friday, next working day is next Tuesday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayEaster()
        {
            var expected = new DateTime(2017, 4, 18);
            var actual = new SlovakiaPublicHoliday().NextWorkingDay(new DateTime(2017, 4, 14));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ChristmasEve2014, on Wednesday (holiday), next working day is next Monday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayChristmasEve2014()
        {
            var expected = new DateTime(2014, 12, 29);
            var actual = new SlovakiaPublicHoliday().NextWorkingDay(new DateTime(2014, 12, 24));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// holiday with another following
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayXmas()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new SlovakiaPublicHoliday().NextWorkingDay(new DateTime(2006, 12, 25));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Saturday, holiday on Monday with another following
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySatBeforeXMas()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new SlovakiaPublicHoliday().NextWorkingDay(new DateTime(2006, 12, 23));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayBoxingDay()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new SlovakiaPublicHoliday().NextWorkingDay(new DateTime(2006, 12, 26));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Previous working days
        /// </summary>
        [TestMethod]
        public void TestPreviousWorkingDay()
        {
            var actual = new SlovakiaPublicHoliday().PreviousWorkingDay(new DateTime(2016, 1, 1)); //Friday
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);

            actual = new SlovakiaPublicHoliday().PreviousWorkingDay(new DateTime(2014, 12, 28)); // Sunday
            Assert.AreEqual(new DateTime(2014, 12, 23), actual);

            actual = new SlovakiaPublicHoliday().PreviousWorkingDay(new DateTime(2014, 12, 29)); // Monday
            Assert.AreEqual(new DateTime(2014, 12, 29), actual);

            actual = new SlovakiaPublicHoliday().PreviousWorkingDay(new DateTime(2016, 1, 3)); // Sunday
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);

            actual = new SlovakiaPublicHoliday().PreviousWorkingDay(new DateTime(2016, 1, 4)); // Monday
            Assert.AreEqual(new DateTime(2016, 1, 4), actual); //is a working day

            actual = new SlovakiaPublicHoliday().PreviousWorkingDay(new DateTime(2016, 1, 3, 11, 31, 0, 0)); //Sun with date
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);
        }
    }
}
