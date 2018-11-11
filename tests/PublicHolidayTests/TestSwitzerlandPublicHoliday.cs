using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestSwitzerlandPublicHoliday {
        [TestMethod]
        public void TestPublicHolidays() 
        {
            var easterMonday = new DateTime(2017, 4, 17);
            var result = new SwitzerlandPublicHoliday().PublicHolidayNames(2017);
            Assert.AreEqual(10, result.Count);
            Assert.IsTrue(result.ContainsKey(easterMonday));
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new SwitzerlandPublicHoliday().IsPublicHoliday(new DateTime(2017, 4, 17));

            Assert.IsTrue(isPublicHoliday, "Easter Monday");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new SwitzerlandPublicHoliday().IsPublicHoliday(new DateTime(2017, 4, 18));

            Assert.IsFalse(isPublicHoliday, "Not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new SwitzerlandPublicHoliday().NextWorkingDay(new DateTime(2017, 4, 14)); //Maundy thursday
            Assert.AreEqual(new DateTime(2017, 4, 18), result); //Day after easter monday7
        }

        [TestMethod]
        public void TestPreviousWorkingDay()
        {
            var result = new SwitzerlandPublicHoliday().PreviousWorkingDay(new DateTime(2017, 4, 17)); //Easter monday
            Assert.AreEqual(new DateTime(2017, 4, 13), result); //Day before good friday
        }

        [TestMethod]
        public void TestNewYear2017()
        {
            var expected = new DateTime(2017, 1, 1);
            var actual = SwitzerlandPublicHoliday.NewYear(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGoodFriday2017()
        {
            var expected = new DateTime(2017, 4, 14);
            var actual = SwitzerlandPublicHoliday.GoodFriday(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEaster2017()
        {
            var expected = new DateTime(2017, 4, 16);
            var actual = SwitzerlandPublicHoliday.Easter(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEasterMonday2017()
        {
            var expected = new DateTime(2017, 4, 17);
            var actual = SwitzerlandPublicHoliday.EasterMonday(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLabourDay2017()
        {
            var expected = new DateTime(2017, 5, 1);
            var actual = SwitzerlandPublicHoliday.LabourDay(2017);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestAscensionDay2017()
        {
            var expected = new DateTime(2017, 5, 25);
            var actual = SwitzerlandPublicHoliday.Ascension(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWhitSunday2017()
        {
            var expected = new DateTime(2017, 6, 4);
            var actual = SwitzerlandPublicHoliday.WhitSunday(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNationalDay2017() {
            var expected = new DateTime(2017, 8, 1);
            var actual = SwitzerlandPublicHoliday.NationalDay(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmasEve2017() {
            var expected = new DateTime(2017, 12, 24);
            var actual = SwitzerlandPublicHoliday.ChristmasEve(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2017()
        {
            var expected = new DateTime(2017, 12, 25);
            var actual = SwitzerlandPublicHoliday.Christmas(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBoxingDay2017()
        {
            var expected = new DateTime(2017, 12, 26);
            var actual = SwitzerlandPublicHoliday.BoxingDay(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNewYearsEve2017() {
            var expected = new DateTime(2017, 12, 31);
            var actual = SwitzerlandPublicHoliday.NewYearsEve(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsPublicHoliday2017() {
            var h = new SwitzerlandPublicHoliday(hasLaborDay:true, hasNewYearsEve:true);

            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 1, 1)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 1, 2)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 1, 6)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 4, 13)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 4, 14)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 4, 16)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 4, 17)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 4, 18)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 4, 30)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 5, 1)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 5, 24)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 5, 25)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 5, 26)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 7, 31)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 8, 1)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 12, 23)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 12, 24)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 12, 25)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 12, 26)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 12, 30)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 12, 31)));
        }
    }
}
