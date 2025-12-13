using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestAustraliaPublicHoliday
    {
        //source: http://www.australia.gov.au/about-australia/special-dates-and-events/public-holidays

        [TestMethod]
        [DataRow(1, 2, "new year (sunday, so monday is holiday)")]
        [DataRow(1, 26, "australia")]
        [DataRow(4, 14, "good friday")]
        [DataRow(4, 17, "easter monday")]
        [DataRow(4, 25, "anzac")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestHolidays2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.All };
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new AustraliaPublicHoliday(); //ALL states - just 7 national
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            //New Year's Day, Australia Day, Good Friday, Easter Monday, Anzac Day, Christmas Day and Boxing Day
            Assert.IsTrue(7 == hols.Count, "Should be 7 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidays2022Lists()
        {
            var holidayCalendar = new AustraliaPublicHoliday(); //ALL states - just 7 national
            var hols = holidayCalendar.PublicHolidays(2022);
            var holNames = holidayCalendar.PublicHolidayNames(2022);
            //New Year's Day, Australia Day, Good Friday, Easter Monday, Anzac Day, National Day of Mourning, Christmas Day and Boxing Day
            Assert.IsTrue(8 == hols.Count, "Should be 8 holidays in 2022");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        [DataRow(1, 2, "new year (sunday, so monday is holiday)")]
        [DataRow(1, 26, "australia")]
        [DataRow(3, 13, "Canberra Day")]
        [DataRow(4, 14, "good friday")]
        [DataRow(4, 17, "easter monday")]
        [DataRow(4, 25, "anzac")]
        [DataRow(6, 12, "queen's birthday")]
        [DataRow(9, 25, "family and community day")]
        [DataRow(10, 2, "labour day")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestAustralianCapitalTerritory2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.ACT };
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [TestMethod]
        public void TestAustralianCapitalTerritory2017Lists()
        {
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.ACT };
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(11 == hols.Count, "Should be 11 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        [DataRow(1, 2, "new year (sunday, so monday is holiday)")]
        [DataRow(1, 26, "australia")]
        [DataRow(4, 14, "good friday")]
        [DataRow(4, 17, "easter monday")]
        [DataRow(4, 25, "anzac")]
        [DataRow(6, 12, "queen's birthday")]
        [DataRow(10, 2, "labour day")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestNewSouthWales2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.NSW };
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [TestMethod]
        [DataRow(1, 2, "new year (sunday, so monday is holiday)")]
        [DataRow(1, 26, "australia")]
        [DataRow(4, 14, "good friday")]
        [DataRow(4, 17, "easter monday")]
        [DataRow(4, 25, "anzac")]
        [DataRow(5, 1, "may day")]
        [DataRow(6, 12, "queen's birthday")]
        [DataRow(8, 7, "picnic day")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestNorthernTerritory2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.NT };
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [TestMethod]
        [DataRow(1, 2, "new year (sunday, so monday is holiday)")]
        [DataRow(1, 26, "australia")]
        [DataRow(4, 14, "good friday")]
        [DataRow(4, 17, "easter monday")]
        [DataRow(4, 25, "anzac")]
        [DataRow(5, 1, "labour day")]
        [DataRow(10, 2, "queen's birthday")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestQueensland2017(int month, int day, string name)
        {
            //https://www.qld.gov.au/recreation/travel/holidays/public/
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.QLD };
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [TestMethod]
        [DataRow(1, 2, "new year (sunday, so monday is holiday)")]
        [DataRow(1, 26, "australia")]
        [DataRow(3, 13, "labour day")]
        [DataRow(4, 14, "good friday")]
        [DataRow(4, 17, "easter monday")]
        [DataRow(4, 25, "anzac")]
        [DataRow(6, 12, "queen's birthday")]
        [DataRow(11, 7, "melbourne cup")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestVictoria2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.VIC };
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [TestMethod]
        [DataRow(1, 2, "new year (sunday, so monday is holiday)")]
        [DataRow(1, 26, "australia")]
        [DataRow(3, 6, "labour day")]
        [DataRow(4, 14, "good friday")]
        [DataRow(4, 17, "easter monday")]
        [DataRow(4, 25, "anzac")]
        [DataRow(6, 5, "western australia day")]
        [DataRow(9, 25, "queen's birthday")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestWesternAustralia2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.WA };
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [TestMethod]
        public void TestAustralianNSW2016Lists()
        {
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.NSW };
            var hols = holidayCalendar.PublicHolidays(2016);
            var holNames = holidayCalendar.PublicHolidayNames(2016);
            Assert.IsTrue(9 == hols.Count, "Should be 9 holidays in 2016");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        [DataRow(2022, 6, 13, "Queen's birthday")]
        [DataRow(2023, 6, 12, "King's birthday")]
        public void TestKingsQueensBirthday(int year, int month, int day, string name)
        {
            var kingQueenBirthday = new DateTime(year, month, day);
            Assert.AreEqual(kingQueenBirthday, AustraliaPublicHoliday.QueenBirthday(year, AustraliaPublicHoliday.States.ACT), $"Holiday for {name} {year}");
            Assert.AreEqual(kingQueenBirthday, AustraliaPublicHoliday.KingBirthday(year, AustraliaPublicHoliday.States.ACT), $"Holiday for {name} {year}");
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.ACT };
            var holNames = holidayCalendar.PublicHolidayNames(year);
            Assert.IsTrue(holNames.ContainsKey(kingQueenBirthday));
        }

        [TestMethod]
        [DataRow(2022, 8, 1, "Bank Holiday")] 
        [DataRow(2024, 8, 5, "Bank Holiday")]
        public void TestNSWBankHoliday(int year, int month, int day, string name) {
            var bankHoliday = new DateTime(year, month, day);
            Assert.AreEqual(bankHoliday, AustraliaPublicHoliday.BankHoliday(year), $"Holiday for {name} {year}"); 
            var holidayCalendar = new AustraliaPublicHoliday { State = AustraliaPublicHoliday.States.NSW, IncludeNSWBankHoliday = true };
            var holNames = holidayCalendar.PublicHolidayNames(year);
            Assert.IsTrue(holNames.ContainsKey(bankHoliday));
        }
    }
}