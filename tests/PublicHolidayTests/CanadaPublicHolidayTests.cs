using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class CanadaPublicHolidayTests
    {
        [TestMethod]
        public void PublicHolidayNamesTest()
        {
            var newYear = new DateTime(2013, 1, 1);
            var goodFriday = new DateTime(2013, 3, 29);
            var easterMonday = new DateTime(2013, 4, 1);
            var victoriaDay = new DateTime(2013, 05, 20);
            var canadaDay = new DateTime(2013, 7, 1);
            var labourDay = new DateTime(2013, 9, 2);
            var thanksgiving = new DateTime(2013, 10, 14);
            var remembrance = new DateTime(2013, 11, 11);
            var christmas = new DateTime(2013, 12, 25);
            var boxingDay = new DateTime(2013, 12, 26);

            var result = new CanadaPublicHoliday().PublicHolidayNames(2013);
            Assert.AreEqual(10, result.Count);
            Assert.IsTrue(result.ContainsKey(newYear));
            Assert.IsTrue(result.ContainsKey(goodFriday));
            Assert.IsTrue(result.ContainsKey(easterMonday));
            Assert.IsTrue(result.ContainsKey(victoriaDay));
            Assert.IsTrue(result.ContainsKey(canadaDay));
            Assert.IsTrue(result.ContainsKey(labourDay));
            Assert.IsTrue(result.ContainsKey(thanksgiving));
            Assert.IsTrue(result.ContainsKey(remembrance));
            Assert.IsTrue(result.ContainsKey(christmas));
            Assert.IsTrue(result.ContainsKey(boxingDay));
        }

        [TestMethod]
        public void CivicDayProvincalTest()
        {
            //provincal holiday but not a national one
            var civicDay = CanadaPublicHoliday.CivicHoliday(2013);
            Assert.AreEqual(new DateTime(2013, 8, 5), civicDay);
        }
    }
}
