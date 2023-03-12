using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Globalization;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestGreecePublicHoliday
    {
        [TestMethod]
        public void TestHolidaysLists()
        {
            var holidayCalendar = new GreecePublicHoliday();
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            for (var year = 2015; year < 2040; year++)
            {
                //looking for collisions
                var holNames = holidayCalendar.PublicHolidayNames(year);
                foreach (var holiday in holNames.Keys)
                {
                    Assert.IsTrue(holidayCalendar.IsPublicHoliday(holiday), 
                        $"Should be holiday: {holNames[holiday]} {holiday:yyyy-MM-dd}");
                }
            }
        }

        [DataTestMethod]
        [DataRow(1, 1, "New Year's Day, Sunday")]
        [DataRow(1, 6, "Epiphany")]
        [DataRow(2, 27, "Clean Monday")]
        [DataRow(3, 25, "Independence Day")]
        [DataRow(4, 14, "Great Friday")]
        [DataRow(4, 17, "Easter Monday")]
        [DataRow(5, 1, "Labour Day")]
        [DataRow(6, 5, "Whit Monday")]
        [DataRow(8, 15, "Dormition")]
        [DataRow(10, 28, "Ochi day")]
        [DataRow(12, 25, "Christmas Day")]
        [DataRow(12, 26, "Glorifying Mother")]
        public void TestHolidays2023(int month, int day, string name)
        {
            var testDate = new DateTime(2023, month, day);
            var holidayCalendar = new GreecePublicHoliday();
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            var holNames = holidayCalendar.PublicHolidayNames(2023);
            Assert.IsTrue(holNames.ContainsKey(testDate));

            Assert.IsTrue(holidayCalendar.IsPublicHoliday(testDate), $"{name} should be holiday");
        }
    }
}