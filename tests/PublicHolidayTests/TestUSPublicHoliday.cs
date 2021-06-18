using System;
using System.Linq;
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
        public void TestThanksgiving2018()
        {
            var expected = new DateTime(2018, 11, 22);
            var actual = USAPublicHoliday.Thanksgiving(2018);
            Assert.AreEqual(expected, actual);
        }

         [TestMethod]
        public void TestNewYear2004()
        {
            var expected = new DateTime(2004, 1, 1);
            var actual = USAPublicHoliday.NewYear(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMartinLutherKing2004()
        {
            var expected = new DateTime(2004, 1, 19);
            var actual = USAPublicHoliday.MartinLutherKing(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWashington2004()
        {
            var expected = new DateTime(2004, 2, 16);
            var actual = USAPublicHoliday.PresidentsDay(2004);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMemorial2004()
        {
            var expected = new DateTime(2004, 5, 31);
            var actual = USAPublicHoliday.MemorialDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependence2004()
        {
            var expected = new DateTime(2004, 7, 5);
            var actual = USAPublicHoliday.IndependenceDay(2004);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestLabor2004()
        {
            var expected = new DateTime(2004, 9, 6);
            var actual = USAPublicHoliday.LaborDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColumbus2004()
        {
            var expected = new DateTime(2004, 10, 11);
            var actual = USAPublicHoliday.ColumbusDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestVeterans2004()
        {
            var expected = new DateTime(2004, 11, 11);
            var actual = USAPublicHoliday.VeteransDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving2004()
        {
            var expected = new DateTime(2004, 11, 25);
            var actual = USAPublicHoliday.Thanksgiving(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2004()
        {
            var expected = new DateTime(2004, 12, 24);
            var actual = USAPublicHoliday.Christmas(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNewYear()
        {
            var expected = new DateTime(2006, 1, 2);
            var actual = USAPublicHoliday.NewYear(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMartinLutherKingDay()
        {
            var expected = new DateTime(2006, 1, 16);
            var actual = USAPublicHoliday.MartinLutherKing(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWashington()
        {
            var expected = new DateTime(2006, 2, 20);
            var actual = USAPublicHoliday.PresidentsDay(2006);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMemorial()
        {
            var expected = new DateTime(2006, 5, 29);
            var actual = USAPublicHoliday.MemorialDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependence()
        {
            var expected = new DateTime(2006, 7, 4);
            var actual = USAPublicHoliday.IndependenceDay(2006);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestLabor()
        {
            var expected = new DateTime(2006, 9, 4);
            var actual = USAPublicHoliday.LaborDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColumbus()
        {
            var expected = new DateTime(2006, 10, 9);
            var actual = USAPublicHoliday.ColumbusDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestVeterans()
        {
            var expected = new DateTime(2006, 11, 10);
            var actual = USAPublicHoliday.VeteransDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving()
        {
            var expected = new DateTime(2006, 11, 23);
            var actual = USAPublicHoliday.Thanksgiving(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas()
        {
            var expected = new DateTime(2006, 12, 25);
            var actual = USAPublicHoliday.Christmas(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving1999()
        {
            var expected = new DateTime(1999, 11, 25);
            var actual = USAPublicHoliday.Thanksgiving(1999);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new USAPublicHoliday().IsPublicHoliday(thanksgiving);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new USAPublicHoliday().NextWorkingDay(thanksgiving);
            Assert.AreEqual(new DateTime(1999, 11, 26), result);
        }

        [TestMethod]
        public void TestJuneteenth2021()
        {
            var juneteenth = new DateTime(2021, 6, 19);
            var result = USAPublicHoliday.Juneteenth(2021);
            Assert.AreEqual(juneteenth, result.HolidayDate);

            var federalHolidays = new USAPublicHoliday().PublicHolidaysInformation(2021);
            //19 June 2021 is Saturday, so would normally be observed on Friday
            var june19 = federalHolidays.FirstOrDefault(x => x.HolidayDate == juneteenth);
            Assert.IsNotNull(june19);

            //Was made a federal holiday in 2021, so it should not appear in 2020 list (although many states and companies observed it)
            federalHolidays = new USAPublicHoliday().PublicHolidaysInformation(2020);
            june19 = federalHolidays.FirstOrDefault(x => x.HolidayDate == juneteenth);
            Assert.IsNull(june19);
        }

        [TestMethod]
        public void TestNextWorkingDayColumbus()
        {
            var result = new USAPublicHoliday().NextWorkingDay(new DateTime(2006, 10, 8));
            Assert.AreEqual(new DateTime(2006, 10, 10), result);
        }

        [TestMethod]
        public void TestPublicHolidays()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new USAPublicHoliday().PublicHolidays(1999);
            Assert.AreEqual(10, result.Count);
            Assert.IsTrue(result.Contains(thanksgiving));
        }

        [TestMethod]
        public void TestPublicHolidayInformation()
        {
            var usaPublicHoliday = new USAPublicHoliday();
            var hols = usaPublicHoliday.PublicHolidays(2017);
            var infos = usaPublicHoliday.PublicHolidaysInformation(2017);
            Assert.AreEqual(hols.Count, infos.Count);
            foreach (var info in infos)
            {
                Assert.IsTrue(hols.Contains(info), "observed date is implicitly in both lists");
            }
        }
    }
}
