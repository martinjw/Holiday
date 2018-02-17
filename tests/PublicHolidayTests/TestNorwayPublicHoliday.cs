using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestNorwayPublicHoliday
    {
        [TestMethod]
        public void TestPublicHolidays()
        {
            var easterMonday = new DateTime(2015, 4, 6);
            var result = new NorwayPublicHoliday().PublicHolidayNames(2015);
            Assert.AreEqual(12, result.Count);
            Assert.IsTrue(result.ContainsKey(easterMonday));
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new NorwayPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 17));

            Assert.IsTrue(isPublicHoliday, "Easter Monday");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new NorwayPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 18));

            Assert.IsFalse(isPublicHoliday, "Not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new NorwayPublicHoliday().NextWorkingDay(new DateTime(2015, 4, 2)); //Maundy thursday
            Assert.AreEqual(new DateTime(2015, 4, 7), result); //Day after easter monday
        }

        [TestMethod]
        public void TestPreviousWorkingDay()
        {
            var result = new NorwayPublicHoliday().PreviousWorkingDay(new DateTime(2015, 4, 6)); //Easter monday
            Assert.AreEqual(new DateTime(2015, 4, 1), result); //Day before Maundy thursday
        }

        [TestMethod]
        public void TestNewYear2015()
        {
            var expected = new DateTime(2015, 1, 1);
            var actual = NorwayPublicHoliday.NewYear(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMaundyThursday2015()
        {
            var expected = new DateTime(2015, 4, 2);
            var actual = NorwayPublicHoliday.MaundyThursday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGoodFriday2015()
        {
            var expected = new DateTime(2015, 4, 3);
            var actual = NorwayPublicHoliday.GoodFriday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEaster2015()
        {
            var expected = new DateTime(2015, 4, 5);
            var actual = NorwayPublicHoliday.Easter(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEasterMonday2015()
        {
            var expected = new DateTime(2015, 4, 6);
            var actual = NorwayPublicHoliday.EasterMonday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLabourDay2015()
        {
            var expected = new DateTime(2015, 5, 1);
            var actual = NorwayPublicHoliday.LabourDay(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConstitutionDay2015()
        {
            var expected = new DateTime(2015, 5, 17);
            var actual = NorwayPublicHoliday.ConstitutionDay(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAscensionDay2015()
        {
            var expected = new DateTime(2015, 5, 14);
            var actual = NorwayPublicHoliday.Ascension(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWhitSunday2015()
        {
            var expected = new DateTime(2015, 5, 24);
            var actual = NorwayPublicHoliday.WhitSunday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWhitMonday2015()
        {
            var expected = new DateTime(2015, 5, 25);
            var actual = NorwayPublicHoliday.WhitMonday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2015()
        {
            var expected = new DateTime(2015, 12, 25);
            var actual = NorwayPublicHoliday.Christmas(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBoxingDay2015()
        {
            var expected = new DateTime(2015, 12, 26);
            var actual = NorwayPublicHoliday.BoxingDay(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2043()
        {
            //Constitution Day falls on the same day as the Whit Sunday holiday - Sunday 17th May 2043
            var hols = new NorwayPublicHoliday().PublicHolidays(2043);
        }
    }
}
