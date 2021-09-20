using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestCanadaGovQuebecClosingDay
    {
        
        [DataTestMethod]
        [DataRow(1, 2, "New Year")]
        [DataRow(1, 3, "Day After New Year")]
        [DataRow(4, 14, "Good Friday")]
        [DataRow(4, 17, "Easter Monday")]
        [DataRow(5, 22, "National Patriots' Day")]
        [DataRow(6, 23, "National Holiday")]
        [DataRow(6, 30, "Canada Day")]
        [DataRow(9, 4, "Labour Day")]
        [DataRow(10, 9, "Thanksgiving")]
        [DataRow(12, 22, "Day Before Christmas")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 26, "Day After Christmas")]
        [DataRow(12, 29, "Day Before New Year")]
        public void TestCanadaGovQuebecClosingDay2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new CanadaGovQuebecClosingDay();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [DataTestMethod]
        [DataRow(1, 1, "New Year")]
        [DataRow(1, 4, "Day After New Year")]
        [DataRow(3, 25, "Good Friday")]
        [DataRow(3, 28, "Easter Monday")]
        [DataRow(5, 23, "National Patriots' Day")]
        [DataRow(6, 24, "National Holiday")]
        [DataRow(7, 1, "Canada Day")]
        [DataRow(9, 5, "Labour Day")]
        [DataRow(10, 10, "Thanksgiving")]
        [DataRow(12, 23, "Day Before Christmas")]
        [DataRow(12, 26, "Christmas")]
        [DataRow(12, 27, "Day After Christmas")]
        [DataRow(12, 30, "Day Before New Year")]
        public void TestCanadaGovQuebecClosingDay2016(int month, int day, string name)
        {
            var holiday = new DateTime(2016, month, day);
            var holidayCalendar = new CanadaGovQuebecClosingDay();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
           
        }

        [DataTestMethod]
        [DataRow(1, 3, "New Year")]
        [DataRow(1, 4, "Day After New Year")]
        [DataRow(4, 22, "Good Friday")]
        [DataRow(4, 25, "Easter Monday")]
        [DataRow(5, 23, "National Patriots' Day")]
        [DataRow(6, 24, "National Holiday")]
        [DataRow(7, 1, "Canada Day")]
        [DataRow(9, 5, "Labour Day")]
        [DataRow(10, 10, "Thanksgiving")]
        [DataRow(12, 23, "Day Before Christmas")]
        [DataRow(12, 26, "Christmas")]
        [DataRow(12, 27, "Day After Christmas")]
        [DataRow(12, 30, "Day Before New Year")]
        public void TestCanadaGovQuebecClosingDay2011(int month, int day, string name)
        {
            var holiday = new DateTime(2011, month, day);
            var holidayCalendar = new CanadaGovQuebecClosingDay();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");

        }

        [TestMethod]
        public void TestCanadaGovQuebecClosingDay2017Lists()
        {
            var holidayCalendar = new CanadaGovQuebecClosingDay();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            //13 holidays
            Assert.IsTrue(13 == hols.Count, "Should be 13 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }



    }
}
