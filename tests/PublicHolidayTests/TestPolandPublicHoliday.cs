using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestPolandPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1, "New Year")]
        [DataRow(1, 6, "Epiphany")]
        [DataRow(4, 17, "Easter Monday")]
        [DataRow(5, 1, "Labour Day")]
        [DataRow(5, 3, "Constitution Day")]
        [DataRow(6, 15, "Corpus Christi")]
        [DataRow(8, 15, "Assumption")]
        [DataRow(11, 1, "All Saints")]
        [DataRow(11, 11, "Independence Day")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 26, "St Stephens")]
        public void TestHolidays2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new PolandPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - {name}");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new PolandPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
        
            // Spodziewana liczba dni wolnych w 2017 roku
            Assert.AreEqual(13, hols.Count, "Should be 13 holidays in 2017");
        
            // Liczba nazw powinna odpowiadać liczbie dni wolnych
            Assert.AreEqual(hols.Count, holNames.Count, "Names and holiday list count should match");
        
            // Sprawdzenie, czy lista dni wolnych zawiera wszystkie oczekiwane daty
            var expectedHolidays = new[]
            {
                new DateTime(2017, 1, 1),  // New Year
                new DateTime(2017, 1, 6),  // Epiphany
                new DateTime(2017, 4, 16), // Easter Sunday
                new DateTime(2017, 4, 17), // Easter Monday
                new DateTime(2017, 5, 1),  // Labour Day
                new DateTime(2017, 5, 3),  // Constitution Day
                new DateTime(2017, 6, 15), // Corpus Christi
                new DateTime(2017, 8, 15), // Assumption
                new DateTime(2017, 11, 1), // All Saints
                new DateTime(2017, 11, 11), // Independence Day
                new DateTime(2017, 12, 25), // Christmas
                new DateTime(2017, 12, 26), // St Stephen's Day
                new DateTime(2017, 6, 15)  // Corpus Christi
            };
        
            foreach (var expectedHoliday in expectedHolidays)
            {
                Assert.IsTrue(hols.Contains(expectedHoliday), $"{expectedHoliday.ToString("D")} is missing in holiday list");
                Assert.IsTrue(holNames.ContainsKey(expectedHoliday), $"Name for {expectedHoliday.ToString("D")} is missing");
            }
        }

        [TestMethod]
        public void TestHolidays2020Lists()
        {
            var holidayCalendar = new PolandPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2020);
            var holNames = holidayCalendar.PublicHolidayNames(2020);
        
            // Spodziewana liczba dni wolnych w 2020 roku
            Assert.AreEqual(13, hols.Count, "Should be 13 holidays in 2020");
        
            // Liczba nazw powinna odpowiadać liczbie dni wolnych
            Assert.AreEqual(hols.Count, holNames.Count, "Names and holiday list count should match");
        
            // Sprawdzenie, czy lista dni wolnych zawiera wszystkie oczekiwane daty
            var expectedHolidays = new[]
            {
                new DateTime(2020, 1, 1),  // New Year
                new DateTime(2020, 1, 6),  // Epiphany
                new DateTime(2020, 4, 12), // Easter Sunday
                new DateTime(2020, 4, 13), // Easter Monday
                new DateTime(2020, 5, 1),  // Labour Day
                new DateTime(2020, 5, 3),  // Constitution Day
                new DateTime(2020, 5, 31), // Pentecost
                new DateTime(2020, 6, 11), // Corpus Christi
                new DateTime(2020, 8, 15), // Assumption
                new DateTime(2020, 11, 1), // All Saints
                new DateTime(2020, 11, 11), // Independence Day
                new DateTime(2020, 12, 25), // Christmas
                new DateTime(2020, 12, 26)  // St Stephen's Day
            };
        
            foreach (var expectedHoliday in expectedHolidays)
            {
                Assert.IsTrue(hols.Contains(expectedHoliday), $"{expectedHoliday.ToString("D")} is missing in holiday list");
                Assert.IsTrue(holNames.ContainsKey(expectedHoliday), $"Name for {expectedHoliday.ToString("D")} is missing");
            }
        }

        [DataTestMethod]
        [DataRow(1, 1, "New Year")]
        [DataRow(1, 6, "Epiphany")]
        [DataRow(4, 20, "Easter Sunday")]
        [DataRow(4, 21, "Easter Monday")]
        [DataRow(5, 1, "Labour Day")]
        [DataRow(5, 3, "Constitution Day")]
        [DataRow(6, 8, "Pentecost")]
        [DataRow(6, 19, "Corpus Christi")]
        [DataRow(8, 15, "Assumption")]
        [DataRow(11, 1, "All Saints")]
        [DataRow(11, 11, "Independence Day")]
        [DataRow(12, 24, "Christmas Eve")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 26, "St Stephen's Day")]
        public void TestHolidays2025(int month, int day, string name)
        {
            var holiday = new DateTime(2025, month, day);
            var holidayCalendar = new PolandPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - {name}");
        }

        [TestMethod]
        public void TestHolidays2025Lists()
        {
            var holidayCalendar = new PolandPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2025);
            var holNames = holidayCalendar.PublicHolidayNames(2025);
        
            // Spodziewana liczba dni wolnych w 2025 roku
            Assert.AreEqual(14, hols.Count, "Should be 14 holidays in 2025");
        
            // Liczba nazw powinna odpowiadać liczbie dni wolnych
            Assert.AreEqual(hols.Count, holNames.Count, "Names and holiday list count should match");
        
            // Sprawdzenie, czy lista dni wolnych zawiera wszystkie oczekiwane daty
            var expectedHolidays = new[]
            {
                new DateTime(2025, 1, 1),  // New Year
                new DateTime(2025, 1, 6),  // Epiphany
                new DateTime(2025, 4, 20), // Easter Sunday
                new DateTime(2025, 4, 21), // Easter Monday
                new DateTime(2025, 5, 1),  // Labour Day
                new DateTime(2025, 5, 3),  // Constitution Day
                new DateTime(2025, 6, 8),  // Pentecost
                new DateTime(2025, 6, 19), // Corpus Christi
                new DateTime(2025, 8, 15), // Assumption
                new DateTime(2025, 11, 1), // All Saints
                new DateTime(2025, 11, 11), // Independence Day
                new DateTime(2025, 12, 24), // Christmas Eve
                new DateTime(2025, 12, 25), // Christmas
                new DateTime(2025, 12, 26)  // St Stephen's Day
            };
        
            foreach (var expectedHoliday in expectedHolidays)
            {
                Assert.IsTrue(hols.Contains(expectedHoliday), $"{expectedHoliday.ToString("D")} is missing in holiday list");
                Assert.IsTrue(holNames.ContainsKey(expectedHoliday), $"Name for {expectedHoliday.ToString("D")} is missing");
            }
        }
    }
}
