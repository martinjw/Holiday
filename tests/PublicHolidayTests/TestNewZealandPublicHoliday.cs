using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestNewZealandPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 2, "new year")]
        [DataRow(1, 3, "day after new year")]
        [DataRow(2, 6, "Waitangi")]
        [DataRow(4, 14, "good friday")]
        [DataRow(4, 17, "easter monday")]
        [DataRow(4, 25, "anzac")]
        [DataRow(6, 5, "queen's birthday")]
        [DataRow(10, 23, "labour day")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestWesternAustralia2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new NewZealandPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        [TestMethod]
        public void TestChristmasAndBoxingDayLandingOnTheEntireWeekend()
        {
            Assert.AreEqual(new DateTime(2021, 12, 27), NewZealandPublicHoliday.Christmas(2021));
            Assert.AreEqual(new DateTime(2021, 12, 28), NewZealandPublicHoliday.BoxingDay(2021));
        }

        [TestMethod]
        public void TestChristmasOnSundayWithBoxingOnMonday()
        {
            Assert.AreEqual(new DateTime(2016, 12, 26), NewZealandPublicHoliday.Christmas(2016));
            Assert.AreEqual(new DateTime(2016, 12, 27), NewZealandPublicHoliday.BoxingDay(2016));
        }

        [TestMethod]
        public void TestBoxingDayLandingOnSaturday()
        {
            var actual = NewZealandPublicHoliday.BoxingDay(2020);
            var expected = new DateTime(2020, 12, 28);
            Assert.AreEqual(expected, actual);
        }

		 [TestMethod]
        public void AnzacDayIsNotObservedToMonday()
        {
            var actual = NewZealandPublicHoliday.AnzacDay(2010);
            var expected = new DateTime(2010, 4, 25);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AnzacDayIsObservedToMondayFromChangeInLaw()
        {
            var actual = NewZealandPublicHoliday.AnzacDay(2015);
            var expected = new DateTime(2015, 4, 27);
            Assert.AreEqual(expected, actual);
        }
		
        [TestMethod]
        public void AnzacDayIsObservedToMonday()
        {
            var actual = NewZealandPublicHoliday.AnzacDay(2020);
            var expected = new DateTime(2020, 4, 27); // Observed to Monday the 27th.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new NewZealandPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(10 == hols.Count, "Should be 10 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }
    }
}
