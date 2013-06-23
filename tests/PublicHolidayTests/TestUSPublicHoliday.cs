using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{

   /// <summary>
    /// Using official calendar from http://www.opm.gov/fedhol/2006.asp
    /// </summary>
    [TestClass]
    public class TestUSPublicHoliday
    {
        [TestMethod]
        public void TestNewYear2004()
        {
            DateTime expected = new DateTime(2004, 1, 1);
            DateTime actual = USAPublicHoliday.NewYear(2004);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestMartinLutherKing2004()
        {
            DateTime expected = new DateTime(2004, 1, 19);
            DateTime actual = USAPublicHoliday.MartinLutherKing(2004);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestWashington2004()
        {
            DateTime expected = new DateTime(2004, 2, 16);
            DateTime actual = USAPublicHoliday.PresidentsDay(2004);
            Assert.AreEqual(expected, actual);
        }
 
 
        [TestMethod]
        public void TestMemorial2004()
        {
            DateTime expected = new DateTime(2004, 5, 31);
            DateTime actual = USAPublicHoliday.MemorialDay(2004);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestIndependence2004()
        {
            DateTime expected = new DateTime(2004, 7, 5);
            DateTime actual = USAPublicHoliday.IndependenceDay(2004);
            Assert.AreEqual(expected, actual);
        }
 
 
        [TestMethod]
        public void TestLabor2004()
        {
            DateTime expected = new DateTime(2004, 9, 6);
            DateTime actual = USAPublicHoliday.LaborDay(2004);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestColumbus2004()
        {
            DateTime expected = new DateTime(2004, 10, 11);
            DateTime actual = USAPublicHoliday.ColumbusDay(2004);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestVeterans2004()
        {
            DateTime expected = new DateTime(2004, 11, 11);
            DateTime actual = USAPublicHoliday.VeteransDay(2004);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestThanksgiving2004()
        {
            DateTime expected = new DateTime(2004, 11, 25);
            DateTime actual = USAPublicHoliday.Thanksgiving(2004);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestChristmas2004()
        {
            DateTime expected = new DateTime(2004, 12, 24);
            DateTime actual = USAPublicHoliday.Christmas(2004);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestNewYear()
        {
            DateTime expected = new DateTime(2006, 1, 2);
            DateTime actual = USAPublicHoliday.NewYear(2006);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestMartinLutherKingDay()
        {
            DateTime expected = new DateTime(2006, 1, 16);
            DateTime actual = USAPublicHoliday.MartinLutherKing(2006);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestWashington()
        {
            DateTime expected = new DateTime(2006, 2, 20);
            DateTime actual = USAPublicHoliday.PresidentsDay(2006);
            Assert.AreEqual(expected, actual);
        }
 
 
        [TestMethod]
        public void TestMemorial()
        {
            DateTime expected = new DateTime(2006, 5, 29);
            DateTime actual = USAPublicHoliday.MemorialDay(2006);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestIndependence()
        {
            DateTime expected = new DateTime(2006, 7, 4);
            DateTime actual = USAPublicHoliday.IndependenceDay(2006);
            Assert.AreEqual(expected, actual);
        }
 
 
        [TestMethod]
        public void TestLabor()
        {
            DateTime expected = new DateTime(2006, 9, 4);
            DateTime actual = USAPublicHoliday.LaborDay(2006);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestColumbus()
        {
            DateTime expected = new DateTime(2006, 10, 9);
            DateTime actual = USAPublicHoliday.ColumbusDay(2006);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestVeterans()
        {
            DateTime expected = new DateTime(2006, 11, 10);
            DateTime actual = USAPublicHoliday.VeteransDay(2006);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestThanksgiving()
        {
            DateTime expected = new DateTime(2006, 11, 23);
            DateTime actual = USAPublicHoliday.Thanksgiving(2006);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestChristmas()
        {
            DateTime expected = new DateTime(2006, 12, 25);
            DateTime actual = USAPublicHoliday.Christmas(2006);
            Assert.AreEqual(expected, actual);
        }
 
        [TestMethod]
        public void TestThanksgiving1999()
        {
            DateTime expected = new DateTime(1999, 11, 25);
            DateTime actual = USAPublicHoliday.Thanksgiving(1999);
            Assert.AreEqual(expected, actual);
        }
    }
}
