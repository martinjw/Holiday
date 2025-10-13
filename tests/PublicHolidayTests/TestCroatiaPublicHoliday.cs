using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Linq;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestCroatiaPublicHoliday
    {
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 21)]
        [DataRow(5, 1)]
        [DataRow(5, 30)]
        [DataRow(6, 19)]
        [DataRow(6, 22)]
        [DataRow(8, 5)]
        [DataRow(8, 15)]
        [DataRow(11, 1)]
        [DataRow(11, 18)]
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestHolidays2025(int month, int day)
        {
            var holiday = new DateTime(2025, month, day);
            var holidayCalendar = new CroatiaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        public void TestHolidays2025Lists()
        {
            var holidayCalendar = new CroatiaPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2025);
            var holNames = holidayCalendar.PublicHolidayNames(2025);
            Assert.IsTrue(13 == hols.Count, "Should be 13 holidays in 2025");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidayListIsPublicHoliday()
        {
            var h = new CroatiaPublicHoliday();

            for (int year = 2015; year < 2025; year++)
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
    }
}