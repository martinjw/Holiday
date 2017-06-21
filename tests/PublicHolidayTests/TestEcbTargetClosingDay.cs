using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestEcbTargetClosingDay
    {
        
        [DataTestMethod]
        [DataRow(1, 1, "New Year’s Day")]
        [DataRow(4, 14, "Good Friday")]
        [DataRow(4, 17, "Easter Monday")]
        [DataRow(5, 1, "Labour Day")]
        [DataRow(12, 25, "Christmas Day")]
        [DataRow(12, 26, "Christmas Holiday")]
        public void TestEcbTargetClosingDays2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new EcbTargetClosingDay();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [DataTestMethod]
        [DataRow(1, 1, "New Year’s Day")]
        [DataRow(3, 25, "Good Friday")]
        [DataRow(3, 28, "Easter Monday")]
        [DataRow(5, 1, "Labour Day")]
        [DataRow(12, 25, "Christmas Day")]
        [DataRow(12, 26, "Christmas Holiday")]
        public void TestEcbTargetClosingDays2016(int month, int day, string name)
        {
            var holiday = new DateTime(2016, month, day);
            var holidayCalendar = new EcbTargetClosingDay();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
            
        }

        [TestMethod]
        public void TestEcbTargetClosingDays2017Lists()
        {
            var holidayCalendar = new EcbTargetClosingDay();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            //New Year's Day, Good Friday, Easter Monday, Labour Day, Christmas Day and Christmas Holiday
            Assert.IsTrue(6 == hols.Count, "Should be 7 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }



    }
}
