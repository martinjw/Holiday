using System;
using System.Linq;
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

        [TestMethod]
        public void TestLiberationDay()
        {
            const int year = 2021;
            var may5th = new DateTime(year, 5, 5);

            var libertion = DutchPublicHoliday.LiberationDay(year);
            Assert.AreEqual(may5th, libertion);
            var dutch = new DutchPublicHoliday();
            Assert.IsTrue(dutch.IsPublicHoliday(may5th));
            var hols = dutch.PublicHolidaysInformation(year);
            var lib = hols.FirstOrDefault(x => x.ObservedDate == may5th);
            Assert.IsNotNull(lib);
        }
    }
}
