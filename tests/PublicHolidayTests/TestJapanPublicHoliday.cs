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

        [DataTestMethod]
        [DataRow(1, 1, "New year - observed on Monday")]
        [DataRow(1, 13, "Coming of Age Day")]
        [DataRow(2, 11, "Foundation Day (Saturday)")]
        [DataRow(2, 24, "The Emperor's Birthday")]
        [DataRow(3, 20, "Vernal Equinox Day")]
        [DataRow(4, 29, "Showa Day")]
        [DataRow(5, 3, "Constitution Memorial Day")]
        [DataRow(5, 5, "Children's Day")]
        [DataRow(5, 6, "Greenery Day")]
        [DataRow(7, 21, "Marine Day")]
        [DataRow(8, 11, "Mountain Day")]
        [DataRow(9, 15, "Respect for the Aged Day")]
        [DataRow(9, 23, "Autumnal Equinox Day")]
        [DataRow(10, 13, "Health and Sports Day")]
        [DataRow(11, 3, "Culture Day")]
        [DataRow(11, 24, "Labour Thanksgiving Day")]
        public void TestHolidays2025(int month, int day, string name)
        {
	        var holiday = new DateTime(2025, month, day);
	        var holidayCalendar = new JapanPublicHoliday();
	        var actual = holidayCalendar.IsPublicHoliday(holiday);
	        Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        public void TestVernalEquinoxDay()
        {
            Assert.AreEqual(new DateTime(1980, 3, 20), JapanPublicHoliday.VernalEquinoxDay(1980));
            Assert.AreEqual(new DateTime(1981, 3, 21), JapanPublicHoliday.VernalEquinoxDay(1981));
            Assert.AreEqual(new DateTime(1982, 3, 22), JapanPublicHoliday.VernalEquinoxDay(1982));
            Assert.AreEqual(new DateTime(1983, 3, 21), JapanPublicHoliday.VernalEquinoxDay(1983));

            Assert.AreEqual(new DateTime(2000, 3, 20), JapanPublicHoliday.VernalEquinoxDay(2000));
            Assert.AreEqual(new DateTime(2001, 3, 20), JapanPublicHoliday.VernalEquinoxDay(2001));
            Assert.AreEqual(new DateTime(2002, 3, 21), JapanPublicHoliday.VernalEquinoxDay(2002));
            Assert.AreEqual(new DateTime(2003, 3, 21), JapanPublicHoliday.VernalEquinoxDay(2003));

            Assert.AreEqual(new DateTime(2020, 3, 20), JapanPublicHoliday.VernalEquinoxDay(2020));
            Assert.AreEqual(new DateTime(2021, 3, 20), JapanPublicHoliday.VernalEquinoxDay(2021));
            Assert.AreEqual(new DateTime(2022, 3, 21), JapanPublicHoliday.VernalEquinoxDay(2022));
            Assert.AreEqual(new DateTime(2023, 3, 21), JapanPublicHoliday.VernalEquinoxDay(2023));

            Assert.AreEqual(new DateTime(2024, 3, 20), JapanPublicHoliday.VernalEquinoxDay(2024));
            Assert.AreEqual(new DateTime(2025, 3, 20), JapanPublicHoliday.VernalEquinoxDay(2025));
            Assert.AreEqual(new DateTime(2026, 3, 20), JapanPublicHoliday.VernalEquinoxDay(2026));
            Assert.AreEqual(new DateTime(2027, 3, 22), JapanPublicHoliday.VernalEquinoxDay(2027));
        }

        [TestMethod]
        public void TestAutumnalEquinoxDay()
        {
            Assert.AreEqual(new DateTime(1980, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(1980));
            Assert.AreEqual(new DateTime(1981, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(1981));
            Assert.AreEqual(new DateTime(1982, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(1982));
            Assert.AreEqual(new DateTime(1983, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(1983));

            Assert.AreEqual(new DateTime(2000, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2000));
            Assert.AreEqual(new DateTime(2001, 9, 24), JapanPublicHoliday.AutumnalEquinoxDay(2001));
            Assert.AreEqual(new DateTime(2002, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2002));
            Assert.AreEqual(new DateTime(2003, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2003));

            Assert.AreEqual(new DateTime(2020, 9, 22), JapanPublicHoliday.AutumnalEquinoxDay(2020));
            Assert.AreEqual(new DateTime(2021, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2021));
            Assert.AreEqual(new DateTime(2022, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2022));
            Assert.AreEqual(new DateTime(2023, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2023));

            Assert.AreEqual(new DateTime(2024, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2024));
            Assert.AreEqual(new DateTime(2025, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2025));
            Assert.AreEqual(new DateTime(2026, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2026));
            Assert.AreEqual(new DateTime(2027, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2027));

            Assert.AreEqual(new DateTime(2044, 9, 22), JapanPublicHoliday.AutumnalEquinoxDay(2044));
            Assert.AreEqual(new DateTime(2045, 9, 22), JapanPublicHoliday.AutumnalEquinoxDay(2045));
            Assert.AreEqual(new DateTime(2046, 9, 24), JapanPublicHoliday.AutumnalEquinoxDay(2046));
            Assert.AreEqual(new DateTime(2047, 9, 23), JapanPublicHoliday.AutumnalEquinoxDay(2047));
        }

        [TestMethod]
        public void TestHolidaysLists()
        {
            for (int year = 2017; year < 2035; year++)
            {
                var holidayCalendar = new JapanPublicHoliday();
                var hols = holidayCalendar.PublicHolidays(year);
                var holNames = holidayCalendar.PublicHolidayNames(year);
                Assert.IsTrue(16 == hols.Count, $"Should be 16 holidays in {year}");
                Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
            }
        }
    }
}