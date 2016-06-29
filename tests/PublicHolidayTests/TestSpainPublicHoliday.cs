using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestSpainPublicHoliday
    {

        [TestMethod]
        public void TestGoodFriday()
        {
            var goodFriday = SpainPublicHoliday.GoodFriday(2006);
            Assert.AreEqual(new DateTime(2006, 4, 14), goodFriday);
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new SpainPublicHoliday().NextWorkingDay(new DateTime(2006, 07, 15));
            Assert.AreEqual(new DateTime(2006, 07, 17), result); //Monday 17th
        }

        [TestMethod]
        public void TestPublicHolidays()
        {
            var assumption = new DateTime(2006, 8, 15);
            var result = new SpainPublicHoliday().PublicHolidayNames(2006);
            Assert.AreEqual(10, result.Count);
            Assert.IsTrue(result.ContainsKey(assumption));
        }

    }
}
