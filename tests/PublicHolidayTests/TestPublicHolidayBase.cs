using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PublicHolidayTests
{
    using System;
    using PublicHoliday;

    [TestClass]
    public class TestPublicHolidayBase
    {
        [TestMethod]
        public void TestUSAHolidayIsWorkingDay()
        {
            var result = new USAPublicHoliday().IsWorkingDay(new DateTime(2019, 7, 15));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUSAHolidayIsNotWorkingDay()
        {
            var result = new USAPublicHoliday().IsWorkingDay(new DateTime(2019, 7, 20));
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestUSAHolidayThreeYearDateRange()
        {
            var holidayCalendar = new USAPublicHoliday();
            var actual = holidayCalendar.GetHolidaysInDateRange(new DateTime(2015, 1, 2), new DateTime(2017, 12, 25));
            Assert.AreEqual(actual.Count, 29);
        }
    }
}
