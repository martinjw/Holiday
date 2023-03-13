using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestTurkeyPublicHoliday
    {
        [DataTestMethod]
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
            Assert.AreEqual(true, actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
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
            Assert.AreEqual(true, actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
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
            Assert.AreEqual(true, actual, $"{holiday.ToString("D")} is not a holiday");
        }
    }
}
