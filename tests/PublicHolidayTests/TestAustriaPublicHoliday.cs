using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Linq;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestAustriaPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 17)]
        [DataRow(5, 1)]
        [DataRow(5, 25)]
        [DataRow(6, 5)]
        [DataRow(6, 15)]
        [DataRow(8, 15)]
        [DataRow(10, 26)]
        [DataRow(11, 1)]
        [DataRow(12, 8)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new AustriaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new AustriaPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(13 == hols.Count, "Should be 10 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidayListIsPublicHoliday()
        {
            //github issue #12, @oliver-h
            var h = new AustriaPublicHoliday();

            for (int year = 2010; year < 2018; year++)
            {
                var days = h.PublicHolidayNames(year);
                var fd = days.Where(d => !h.IsPublicHoliday(d.Key)).ToArray();

                if (fd.Any())
                {
                    var s = string.Join(Environment.NewLine, fd);
                    Console.WriteLine(s);
                    Assert.Fail($"Dates in list are not public holidays: {s}");
                }
            }
        }

        [TestMethod]
        public void TestAscension()
        {
            //Issue #40
            var h = new AustriaPublicHoliday();
            var days = h.PublicHolidays(2008);
            //should not be an error because Ascension = MayDay
            Assert.IsTrue(days.Contains(new DateTime(2008, 5, 1)), "Should contain 2 - MayDay and Ascension");
        }
    }
}