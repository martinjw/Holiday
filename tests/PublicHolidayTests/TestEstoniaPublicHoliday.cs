using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestEstoniaPublicHoliday
    {
        [TestMethod]
        [DataRow(1, 1, "New Year's Day")]
        [DataRow(2, 24, "Independence Day")]
        [DataRow(4, 2, "Good Friday")] // Moving holiday
        [DataRow(4, 4, "Easter Sunday")] // Moving holiday
        [DataRow(5, 1, "Spring Day")]
        [DataRow(5, 23, "Whit Sunday")] // Moving holiday
        [DataRow(6, 23, "Victory Day")]
        [DataRow(6, 24, "Midsummer Day")]
        [DataRow(8, 20, "Independence Restoration Day ")]
        [DataRow(12, 24, "Christmas Eve")]
        [DataRow(12, 25, "Christmas Day")]
        [DataRow(12, 26, "Boxing Day")]
        public void TestEstonianHolidays2021(int month, int day, string name)
        {
            var holiday = new DateTime(2021, month, day);
            var holidayCalendar = new EstoniaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }
        
        [TestMethod]
        [DataRow(4, 15, "Good Friday")] // Moving holiday
        [DataRow(4, 17, "Easter Sunday")] // Moving holiday
        [DataRow(6, 5, "Whit Sunday")] // Moving holiday
        public void TestEstonianMovingHolidays2022(int month, int day, string name)
        {
            var holiday = new DateTime(2022, month, day);
            var holidayCalendar = new EstoniaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }
        
        [TestMethod]
        [DataRow(4, 7, "Good Friday")] // Moving holiday
        [DataRow(4, 9, "Easter Sunday")] // Moving holiday
        [DataRow(5, 28, "Whit Sunday")] // Moving holiday
        public void TestEstonianMovingHolidays2023(int month, int day, string name)
        {
            var holiday = new DateTime(2023, month, day);
            var holidayCalendar = new EstoniaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }
        
        [TestMethod]
        [DataRow(3, 29, "Good Friday")] // Moving holiday
        [DataRow(3, 31, "Easter Sunday")] // Moving holiday
        [DataRow(5, 19, "Whit Sunday")] // Moving holiday
        public void TestEstonianMovingHolidays2024(int month, int day, string name)
        {
            var holiday = new DateTime(2024, month, day);
            var holidayCalendar = new EstoniaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }
        
        [TestMethod]
        [DataRow(4, 18, "Good Friday")] // Moving holiday
        [DataRow(4, 20, "Easter Sunday")] // Moving holiday
        [DataRow(6, 8, "Whit Sunday")] // Moving holiday
        public void TestEstonianMovingHolidays2025(int month, int day, string name)
        {
            var holiday = new DateTime(2025, month, day);
            var holidayCalendar = new EstoniaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        /// <summary>
        /// Before 2005 Christmas Eve was not a public holiday.
        /// </summary>
        [TestMethod]
        public void TestEstonianHolidays2004List()
        {
            var holiday = new DateTime(2004, 12, 24);
            var holidayCalendar = new EstoniaPublicHoliday();
            var holidays = holidayCalendar.PublicHolidayNames(2004);

            Assert.AreEqual(11, holidays.Count, "Should be 11 holidays in 2004");
            Assert.IsFalse(holidays.ContainsKey(holiday));
        }

        [TestMethod]
        public void TestEstonianHolidays2005List()
        {
            var holiday = new DateTime(2005, 12, 24);
            var holidayCalendar = new EstoniaPublicHoliday();
            var holidays = holidayCalendar.PublicHolidayNames(2005);

            Assert.AreEqual(12, holidays.Count, "Should be 12 holidays in 2005");
            Assert.IsTrue(holidays.ContainsKey(holiday));
        }
    }
}