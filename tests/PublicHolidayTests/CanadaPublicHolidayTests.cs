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
            var civicHoliday = new DateTime(2013, 8, 5);
            var labourDay = new DateTime(2013, 9, 2);
            var thanksgiving = new DateTime(2013, 10, 14);
            var remembrance = new DateTime(2013, 11, 11);
            var christmas = new DateTime(2013, 12, 25);
            var boxingDay = new DateTime(2013, 12, 26);

            var result = new CanadaPublicHoliday().PublicHolidayNames(2013);
            Assert.AreEqual(11, result.Count);
            Assert.IsTrue(result.ContainsKey(newYear));
            Assert.IsTrue(result.ContainsKey(goodFriday));
            Assert.IsTrue(result.ContainsKey(easterMonday));
            Assert.IsTrue(result.ContainsKey(victoriaDay));
            Assert.IsTrue(result.ContainsKey(canadaDay));
            Assert.IsTrue(result.ContainsKey(civicHoliday));
            Assert.IsTrue(result.ContainsKey(labourDay));
            Assert.IsTrue(result.ContainsKey(thanksgiving));
            Assert.IsTrue(result.ContainsKey(remembrance));
            Assert.IsTrue(result.ContainsKey(christmas));
            Assert.IsTrue(result.ContainsKey(boxingDay));
        }

        [TestMethod]
        public void PublicHolidaysTest()
        {
            var newYear = new DateTime(2013, 1, 1);
            var goodFriday = new DateTime(2013, 3, 29);
            var easterMonday = new DateTime(2013, 4, 1);
            var victoriaDay = new DateTime(2013, 05, 20);
            var canadaDay = new DateTime(2013, 7, 1);
            var civicHoliday = new DateTime(2013, 8, 5);
            var labourDay = new DateTime(2013, 9, 2);
            var thanksgiving = new DateTime(2013, 10, 14);
            var remembrance = new DateTime(2013, 11, 11);
            var christmas = new DateTime(2013, 12, 25);
            var boxingDay = new DateTime(2013, 12, 26);

            var result = new CanadaPublicHoliday().PublicHolidays(2013);
            Assert.AreEqual(11, result.Count);
            Assert.IsTrue(result.Contains(newYear));
            Assert.IsTrue(result.Contains(goodFriday));
            Assert.IsTrue(result.Contains(easterMonday));
            Assert.IsTrue(result.Contains(victoriaDay));
            Assert.IsTrue(result.Contains(canadaDay));
            Assert.IsTrue(result.Contains(civicHoliday));
            Assert.IsTrue(result.Contains(labourDay));
            Assert.IsTrue(result.Contains(thanksgiving));
            Assert.IsTrue(result.Contains(remembrance));
            Assert.IsTrue(result.Contains(christmas));
            Assert.IsTrue(result.Contains(boxingDay));
        }

        [TestMethod]
        public void CivicDayProvincalTest()
        {
            //provincal holiday but not a national one
            var civicDay = CanadaPublicHoliday.CivicHoliday(2013);
            Assert.AreEqual(new DateTime(2013, 8, 5), civicDay);
        }

        [TestMethod]
        public void ProvincialTotalsTest()
        {
            var result = new CanadaPublicHoliday("AB").PublicHolidayNames(2013);
            Assert.AreEqual(12, result.Count);

            result = new CanadaPublicHoliday("BC").PublicHolidayNames(2013);
            Assert.AreEqual(10, result.Count);

            result = new CanadaPublicHoliday("MB").PublicHolidayNames(2013);
            Assert.AreEqual(9, result.Count);

            result = new CanadaPublicHoliday("NB").PublicHolidayNames(2013);
            Assert.AreEqual(10, result.Count);

            result = new CanadaPublicHoliday("NL").PublicHolidayNames(2013);
            Assert.AreEqual(12, result.Count);

            result = new CanadaPublicHoliday("NT").PublicHolidayNames(2013);
            Assert.AreEqual(10, result.Count);

            result = new CanadaPublicHoliday("NS").PublicHolidayNames(2013);
            Assert.AreEqual(11, result.Count);

            result = new CanadaPublicHoliday("NU").PublicHolidayNames(2013);
            Assert.AreEqual(9, result.Count);

            result = new CanadaPublicHoliday("ON").PublicHolidayNames(2013);
            Assert.AreEqual(9, result.Count);

            result = new CanadaPublicHoliday("PE").PublicHolidayNames(2013);
            Assert.AreEqual(12, result.Count);

            result = new CanadaPublicHoliday("QC").PublicHolidayNames(2013);
            Assert.AreEqual(8, result.Count);

            result = new CanadaPublicHoliday("SK").PublicHolidayNames(2013);
            Assert.AreEqual(10, result.Count);

            result = new CanadaPublicHoliday("YT").PublicHolidayNames(2013);
            Assert.AreEqual(11, result.Count);
        }

        [TestMethod]
        public void SaskatchewanTest()
        {
            var newYear = new DateTime(2016, 1, 1);
            var familyDay = new DateTime(2016, 2, 15);
            var goodFriday = new DateTime(2016, 3, 25);
            var victoriaDay = new DateTime(2016, 05, 23);
            var canadaDay = new DateTime(2016, 7, 1);
            var civicHoliday = new DateTime(2016, 8, 1);
            var labourDay = new DateTime(2016, 9, 5);
            var thanksgiving = new DateTime(2016, 10, 10);
            var remembrance = new DateTime(2016, 11, 11);
            var christmas = new DateTime(2016, 12, 26);

            var result = new CanadaPublicHoliday("SK").PublicHolidayNames(2016);
            Assert.AreEqual(10, result.Count);
            Assert.IsTrue(result.ContainsKey(newYear));
            Assert.IsTrue(result.ContainsKey(familyDay));
            Assert.IsTrue(result.ContainsKey(goodFriday));
            Assert.IsTrue(result.ContainsKey(victoriaDay));
            Assert.IsTrue(result.ContainsKey(canadaDay));
            Assert.IsTrue(result.ContainsKey(civicHoliday));
            Assert.IsTrue(result.ContainsKey(labourDay));
            Assert.IsTrue(result.ContainsKey(thanksgiving));
            Assert.IsTrue(result.ContainsKey(remembrance));
            Assert.IsTrue(result.ContainsKey(christmas));
        }

        [TestMethod]
        public void BritishColumbiaTest()
        {
            var newYear = new DateTime(2016, 1, 1);
            var familyDay = new DateTime(2016, 2, 8);
            var goodFriday = new DateTime(2016, 3, 25);
            var victoriaDay = new DateTime(2016, 05, 23);
            var canadaDay = new DateTime(2016, 7, 1);
            var civicHoliday = new DateTime(2016, 8, 1);
            var labourDay = new DateTime(2016, 9, 5);
            var thanksgiving = new DateTime(2016, 10, 10);
            var remembrance = new DateTime(2016, 11, 11);
            var christmas = new DateTime(2016, 12, 26);

            var result = new CanadaPublicHoliday("BC").PublicHolidayNames(2016);
            Assert.AreEqual(10, result.Count);
            Assert.IsTrue(result.ContainsKey(newYear));
            Assert.IsTrue(result.ContainsKey(familyDay));
            Assert.IsTrue(result.ContainsKey(goodFriday));
            Assert.IsTrue(result.ContainsKey(victoriaDay));
            Assert.IsTrue(result.ContainsKey(canadaDay));
            Assert.IsTrue(result.ContainsKey(civicHoliday));
            Assert.IsTrue(result.ContainsKey(labourDay));
            Assert.IsTrue(result.ContainsKey(thanksgiving));
            Assert.IsTrue(result.ContainsKey(remembrance));
            Assert.IsTrue(result.ContainsKey(christmas));
        }

        [TestMethod]
        public void BritishColumbiaFamilyDay2019Test()
        {
            var cph = new CanadaPublicHoliday("BC");

            var isFamilyDay = cph.IsPublicHoliday(new DateTime(2019, 2, 18));
            Assert.IsTrue(isFamilyDay);
        }

        [TestMethod]
        public void StPatricksTest()
        {
            var stPattys = CanadaPublicHoliday.StPatricksDay(2016);
            Assert.AreEqual(stPattys, new DateTime(2016, 3, 14));
            Assert.IsTrue(CanadaPublicHoliday.HasStPatricksDay("NL"));
            Assert.IsFalse(CanadaPublicHoliday.HasStPatricksDay());
        }

        [TestMethod]
        public void OrangemensDayTest()
        {
            var orangemens = CanadaPublicHoliday.OrangemensDay(2016);
            Assert.AreEqual(orangemens, new DateTime(2016, 7, 11));
            Assert.IsTrue(CanadaPublicHoliday.HasOrangemensDay("NL"));
            Assert.IsFalse(CanadaPublicHoliday.HasOrangemensDay());
        }

        [TestMethod]
        public void StGeorgesDayTest()
        {
            var stGeorges = CanadaPublicHoliday.StGeorgesDay(2016);
            Assert.AreEqual(stGeorges, new DateTime(2016, 4, 25));
            Assert.IsTrue(CanadaPublicHoliday.HasStGeorgesDay("NL"));
            Assert.IsFalse(CanadaPublicHoliday.HasStGeorgesDay());
        }

        [TestMethod]
        public void NationalDayTest()
        {
            var nat = CanadaPublicHoliday.NationalHoliday(2016);
            Assert.AreEqual(nat, new DateTime(2016, 6, 24));
            Assert.IsTrue(CanadaPublicHoliday.HasNationalHoliday("NL"));
            Assert.IsTrue(CanadaPublicHoliday.HasNationalHoliday("QC"));
            Assert.IsTrue(CanadaPublicHoliday.HasNationalHoliday("YT"));
            Assert.IsFalse(CanadaPublicHoliday.HasNationalHoliday());
        }

        [TestMethod]
        public void AboriginalDayTest()
        {
            var aboriginal = CanadaPublicHoliday.AboriginalDay(2016);
            Assert.AreEqual(aboriginal, new DateTime(2016,6, 21));
            Assert.IsTrue(CanadaPublicHoliday.HasAboriginalDay("NT"));
            Assert.IsFalse(CanadaPublicHoliday.HasAboriginalDay());
        }

        [TestMethod]
        public void GoldCupDayTest()
        {
            var gcp = CanadaPublicHoliday.GoldCupParadeDay(2016);
            Assert.AreEqual(gcp, new DateTime(2016, 8, 19));
            Assert.IsTrue(CanadaPublicHoliday.HasGoldCupParadeDay("PE"));
            Assert.IsFalse(CanadaPublicHoliday.HasGoldCupParadeDay());
        }

        [TestMethod]
        public void DiscoveryDayTest()
        {
            var disc = CanadaPublicHoliday.DiscoveryDay(2016);
            Assert.AreEqual(disc, new DateTime(2016, 8, 15));
            Assert.IsTrue(CanadaPublicHoliday.HasDiscoveryDay("YT"));
            Assert.IsFalse(CanadaPublicHoliday.HasDiscoveryDay());
        }
    }
}
