using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestFrancePublicHoliday
    {

        [TestMethod]
        public void TestAscension()
        {
            var ascension = FrancePublicHoliday.Ascension(2006);
            Assert.AreEqual(new DateTime(2006, 5, 25), ascension);
        }

        [TestMethod]
        public void TestPentecost()
        {
            var pentecost = FrancePublicHoliday.PentecostMonday(2006);
            Assert.AreEqual(new DateTime(2006, 6, 5), pentecost);
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new FrancePublicHoliday().IsPublicHoliday(new DateTime(2006, 5, 8));

            Assert.IsTrue(isPublicHoliday, "Monday 8th May 2006 is Victory In Europe day");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new FrancePublicHoliday().IsPublicHoliday(new DateTime(2006, 5, 9));

            Assert.IsFalse(isPublicHoliday, "Tuesday 9th May 2006 is not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new FrancePublicHoliday().NextWorkingDay(new DateTime(2006, 05, 25));
            Assert.AreEqual(new DateTime(2006, 05, 26), result);
        }

        [TestMethod]
        public void TestPublicHolidays()
        {
            var ascension = new DateTime(2006, 05, 25);
            var result = new FrancePublicHoliday().PublicHolidayNames(2006);
            Assert.AreEqual(11, result.Count);
            Assert.IsTrue(result.ContainsKey(ascension));
        }

    }
}
