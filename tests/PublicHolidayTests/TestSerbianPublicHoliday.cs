using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestSerbianPublicHoliday
    {
        [TestMethod]
        public void TestPublicHolidays()
        {
            var easterMonday = new DateTime(2015, 4, 13);
            var result = new SerbianPublicHoliday().PublicHolidayNames(2015);
            Assert.AreEqual(11, result.Count);
            Assert.IsTrue(result.ContainsKey(easterMonday));
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new SerbianPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 24));
            Assert.IsTrue(isPublicHoliday, "Easter Monday");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new SerbianPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 18));
            Assert.IsFalse(isPublicHoliday, "Not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new SerbianPublicHoliday().NextWorkingDay(new DateTime(2023, 2, 15));
            Assert.AreEqual(new DateTime(2023, 2, 17), result);
        }

        [TestMethod]
        public void TestPreviousWorkingDay()
        {
            var result = new SerbianPublicHoliday().PreviousWorkingDay(new DateTime(2023, 1, 8));
            Assert.AreEqual(new DateTime(2023, 1, 6), result);
        }
        
        [TestMethod]
        public void TestNewYear2020()
        {
            var expected1 = new DateTime(2020, 1, 1);
            var expected2 = new DateTime(2020, 1, 2);
            
            var actual1 = SerbianPublicHoliday.NewYearFirst(2020);
            var actual2 = SerbianPublicHoliday.NewYearSecond(2020);
            
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
        
        [TestMethod]
        public void TestChristmas2024()
        {
            var expected = new DateTime(2024, 1, 7);
            var actual = SerbianPublicHoliday.Christmas(2024);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNationalDay2030()
        {
            var expected1 = new DateTime(2030, 2, 15);
            var expected2 = new DateTime(2030, 2, 16);
            
            var actual1 = SerbianPublicHoliday.NationalDayFirst(2030);
            var actual2 = SerbianPublicHoliday.NationalDaySecond(2030);
            
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
        
        [TestMethod]
        public void TestGoodFriday2015()
        {
            var expected = new DateTime(2015, 4, 10);
            var actual = SerbianPublicHoliday.GoodFriday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEaster2015()
        {
            var expected = new DateTime(2015, 4, 12);
            var actual = SerbianPublicHoliday.Easter(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEaster2024()
        {
            var expected = new DateTime(2024, 5, 5);
            var actual = SerbianPublicHoliday.Easter(2024);
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(new SerbianPublicHoliday().IsPublicHoliday(expected));
        }

        [TestMethod]
        public void TestEasterMonday2015()
        {
            var expected = new DateTime(2015, 4, 13);
            var actual = SerbianPublicHoliday.EasterMonday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLabourDay2025()
        {
            var expected1 = new DateTime(2025, 5, 1);
            var expected2 = new DateTime(2025, 5, 2);
            
            var actual1 = SerbianPublicHoliday.LabourDayFirst(2025);
            var actual2 = SerbianPublicHoliday.LabourDaySecond(2025);
            
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
        
        [TestMethod]
        public void TestArmisticeDay2025()
        {
            var expected = new DateTime(2025, 11, 11);
            var actual = SerbianPublicHoliday.ArmisticeDay(2025);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestHolidaysLists()
        {
            var holidayCalendar = new SerbianPublicHoliday();
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
    }   
}