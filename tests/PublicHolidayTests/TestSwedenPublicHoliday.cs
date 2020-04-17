using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestSwedenPublicHoliday {
        [TestMethod]
        public void TestPublicHolidays() 
        {
            var easterMonday = new DateTime(2017, 4, 17);
            var result = new SwedenPublicHoliday().PublicHolidayNames(2017);
            Assert.AreEqual(16, result.Count);
            Assert.IsTrue(result.ContainsKey(easterMonday));
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new SwedenPublicHoliday().IsPublicHoliday(new DateTime(2017, 4, 17));

            Assert.IsTrue(isPublicHoliday, "Easter Monday");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new SwedenPublicHoliday().IsPublicHoliday(new DateTime(2017, 4, 18));

            Assert.IsFalse(isPublicHoliday, "Not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new SwedenPublicHoliday().NextWorkingDay(new DateTime(2017, 4, 14)); //Maundy thursday
            Assert.AreEqual(new DateTime(2017, 4, 18), result); //Day after easter monday7
        }

        [TestMethod]
        public void TestPreviousWorkingDay()
        {
            var result = new SwedenPublicHoliday().PreviousWorkingDay(new DateTime(2017, 4, 17)); //Easter monday
            Assert.AreEqual(new DateTime(2017, 4, 13), result); //Day before good friday
        }

        [TestMethod]
        public void TestNewYear2017()
        {
            var expected = new DateTime(2017, 1, 1);
            var actual = SwedenPublicHoliday.NewYear(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGoodFriday2017()
        {
            var expected = new DateTime(2017, 4, 14);
            var actual = SwedenPublicHoliday.GoodFriday(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEaster2017()
        {
            var expected = new DateTime(2017, 4, 16);
            var actual = SwedenPublicHoliday.Easter(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEasterMonday2017()
        {
            var expected = new DateTime(2017, 4, 17);
            var actual = SwedenPublicHoliday.EasterMonday(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLabourDay2017()
        {
            var expected = new DateTime(2017, 5, 1);
            var actual = SwedenPublicHoliday.LabourDay(2017);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestAscensionDay2017()
        {
            var expected = new DateTime(2017, 5, 25);
            var actual = SwedenPublicHoliday.Ascension(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWhitSunday2017()
        {
            var expected = new DateTime(2017, 6, 4);
            var actual = SwedenPublicHoliday.WhitSunday(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNationalDay2017() {
            var expected = new DateTime(2017, 6, 6);
            var actual = SwedenPublicHoliday.NationalDay(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMidsummerEve2017() {
            var expected = new DateTime(2017, 6, 23);
            var actual = SwedenPublicHoliday.MidsummerEve(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMidsummerDay2017() {
            var expected = new DateTime(2017, 6, 24);
            var actual = SwedenPublicHoliday.MidsummerDay(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAllSaintsDay2017() {
            var expected = new DateTime(2017, 11, 4);
            var actual = SwedenPublicHoliday.AllSaintsDay(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmasEve2017() {
            var expected = new DateTime(2017, 12, 24);
            var actual = SwedenPublicHoliday.ChristmasEve(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2017()
        {
            var expected = new DateTime(2017, 12, 25);
            var actual = SwedenPublicHoliday.Christmas(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBoxingDay2017()
        {
            var expected = new DateTime(2017, 12, 26);
            var actual = SwedenPublicHoliday.BoxingDay(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNewYearsEve2017() {
            var expected = new DateTime(2017, 12, 31);
            var actual = SwedenPublicHoliday.NewYearsEve(2017);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsPublicHoliday2017() {
            var h = new SwedenPublicHoliday();

            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 1, 1)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 1, 2)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 1, 5)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 1, 6)));
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
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 6, 5)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 6, 6)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 6, 23)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 6, 24)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 11, 3)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 11, 4)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 12, 23)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 12, 24)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 12, 25)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 12, 26)));
            Assert.IsFalse(h.IsPublicHoliday(new DateTime(2017, 12, 30)));
            Assert.IsTrue(h.IsPublicHoliday(new DateTime(2017, 12, 31)));
        }

        [TestMethod]
        public void TestAscension()
        {
            //Issue #40
            var h = new SwedenPublicHoliday();
            var days = h.PublicHolidays(2008);
            //should not be an error because Ascension = MayDay
            Assert.IsTrue(days.Contains(new DateTime(2008, 5, 1)), "Should contain 2 - MayDay and Ascension");
        }
    }
}
