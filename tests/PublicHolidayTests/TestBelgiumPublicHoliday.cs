using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestBelgiumPublicHoliday
    {


        [TestMethod]
        public void TestPublicHolidays()
        {
            var easterMonday = new DateTime(2006, 04, 17);
            var result = new BelgiumPublicHoliday().PublicHolidayNames(2006);
            Assert.AreEqual(10, result.Count);
            Assert.IsTrue(result.ContainsKey(easterMonday));
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new BelgiumPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 17));

            Assert.IsTrue(isPublicHoliday, "Easter Monday");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new BelgiumPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 18));

            Assert.IsFalse(isPublicHoliday, "Not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new BelgiumPublicHoliday().NextWorkingDay(new DateTime(2006, 05, 25));
            Assert.AreEqual(new DateTime(2006, 05, 26), result);
        }

    }
}
