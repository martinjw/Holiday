﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Linq;

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
        public void AnzacDaySameDayAsEasterMonday2011() {
            var holidayCalendar = new NewZealandPublicHoliday();
            var hols = holidayCalendar.PublicHolidayNames(2011);
            Assert.IsTrue(10 == hols.Count, "Should be 10 holidays in 2011");

            var (anzacDay, _) = hols.FirstOrDefault(x => x.Value.Equals("ANZAC Day", StringComparison.CurrentCultureIgnoreCase));
            var (easterMonday, _) = hols.FirstOrDefault(x => x.Value.Equals("Easter Monday", StringComparison.CurrentCultureIgnoreCase));

            Assert.IsFalse(anzacDay == default(DateTime), "ANZAC Day not found in 2011");
            Assert.IsFalse(easterMonday == default(DateTime), "Easter Monday not found in 2011");

            Assert.IsTrue(anzacDay.Date.Equals(easterMonday.Date), $"ANZAC Day and Easter Monday fell on the same day in 2011");
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

        [TestMethod]
        public void TestHolidays2022Lists()
        {
            var holidayCalendar = new NewZealandPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2022);
            var holNames = holidayCalendar.PublicHolidayNames(2022);
            Assert.IsTrue(11 == hols.Count, "Should be 11 holidays in 2022");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestMatarikiBeforeIntroduction()
        {
            var matariki = NewZealandPublicHoliday.Matariki(2021);
            Assert.IsNull(matariki, "Matariki first occurs as a public holiday in 2022");
        }

        [TestMethod]
        public void TestMatarikiAfterIntroduction()
        {
            var matariki = NewZealandPublicHoliday.Matariki(2025);
            Assert.AreEqual(new DateTime(2025, 6, 20), matariki, "Matariki should be on 25th June 2025");
        }
    }
}
