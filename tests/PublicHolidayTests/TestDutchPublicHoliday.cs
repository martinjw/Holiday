using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestDutchPublicHoliday
    {
        [TestMethod]
        public void TestPublicHolidays()
        {
            var easterMonday = new DateTime(2015, 4, 6);
            var result = new DutchPublicHoliday().PublicHolidayNames(2015);
            Assert.AreEqual(8, result.Count);
            Assert.IsTrue(result.ContainsKey(easterMonday));
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new DutchPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 17));

            Assert.IsTrue(isPublicHoliday, "Easter Monday");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new DutchPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 18));

            Assert.IsFalse(isPublicHoliday, "Not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new DutchPublicHoliday().NextWorkingDay(new DateTime(2006, 05, 25));
            Assert.AreEqual(new DateTime(2006, 05, 26), result);
        }
    }
}
