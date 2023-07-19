using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestMontenegroPublicHolidays
    {
        [TestMethod]
        public void TestPublicHolidays()
        {    
            var easterMonday = new DateTime(2023, 4, 17);
            var result = new MontenegroPublicHoliday().PublicHolidayNames(2023);
            Assert.AreEqual(13, result.Count);        
            Assert.IsTrue(result.ContainsKey(easterMonday));
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new MontenegroPublicHoliday().NextWorkingDay(new DateTime(2023, 2, 15));
            Assert.AreEqual(new DateTime(2023, 2, 15), result);
        }

        [TestMethod]
        public void TestPreviousWorkingDay()
        {
            var result = new MontenegroPublicHoliday().PreviousWorkingDay(new DateTime(2023, 1, 8));
            Assert.AreEqual(new DateTime(2023, 1, 5), result);
        }

        [TestMethod]
        public void TestNewYear2020()
        {
            var expected1 = new DateTime(2020, 1, 1);
            var expected2 = new DateTime(2020, 1, 2);

            var actual1 = MontenegroPublicHoliday.NewYearFirst(2020);
            var actual2 = MontenegroPublicHoliday.NewYearSecond(2020);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void TestChristmasEve2023()
        {
            var expected = new DateTime(2023, 1, 6);
            var actual = MontenegroPublicHoliday.ChristmasEve(2023);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2024()
        {
            var expected = new DateTime(2024, 1, 7);
            var actual = MontenegroPublicHoliday.Christmas(2024);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLabourDay2030()
        {
            var expected1 = new DateTime(2030, 5, 1);
            var expected2 = new DateTime(2030, 5, 2);

            var actual1 = MontenegroPublicHoliday.LabourDayFirst(2030);
            var actual2 = MontenegroPublicHoliday.LabourDaySecond(2030);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void TestGoodFriday2015()
        {
            var expected = new DateTime(2015, 4, 10);
            var actual = MontenegroPublicHoliday.GoodFriday(2015);
            Assert.AreEqual(expected, actual);
        }      

        [TestMethod]
        public void TestEasterMonday2015()
        {      
            var expected = new DateTime(2015, 4, 13);
            var actual = MontenegroPublicHoliday.EasterMonday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStatehoodDay2025()
        {
            var expected1 = new DateTime(2023, 7, 13);
            var expected2 = new DateTime(2023, 7, 14);

            var actual1 = MontenegroPublicHoliday.StatehoodDayFirst(2023);
            var actual2 = MontenegroPublicHoliday.StatehoodDaySecond(2023);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void TestNegoshevDay()
        {
            var expected = new DateTime(2023, 11, 13);
            var actual = MontenegroPublicHoliday.NegoshevDay(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHolidaysLists()
        {
            var holidayCalendar = new MontenegroPublicHoliday();
            for (var year = 2015; year < 2040; year++)
            {
                //looking for collisions
                var holNames = holidayCalendar.PublicHolidayNames(year);
                var hols = holidayCalendar.PublicHolidays(year);
                foreach (var holiday in holNames.Keys)
                {
                    Assert.IsTrue(holidayCalendar.IsPublicHoliday(holiday),
                        $"Should be holiday: {holNames[holiday]} {holiday:yyyy-MM-dd}");
                }
            }
        }
    }
}
