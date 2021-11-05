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
    public class TestUSFederalReserveHoliday
    {
        [TestMethod]
        public void TestThanksgiving2018()
        {
            var expected = new DateTime(2018, 11, 22);
            var actual = USAFederalReserveHoliday.Thanksgiving(2018);
            Assert.AreEqual(expected, actual);
        }

         [TestMethod]
        public void TestNewYear2004()
        {
            var expected = new DateTime(2004, 1, 1);
            var actual = USAFederalReserveHoliday.NewYear(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMartinLutherKing2004()
        {
            var expected = new DateTime(2004, 1, 19);
            var actual = USAFederalReserveHoliday.MartinLutherKing(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWashington2004()
        {
            var expected = new DateTime(2004, 2, 16);
            var actual = USAFederalReserveHoliday.PresidentsDay(2004);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMemorial2004()
        {
            var expected = new DateTime(2004, 5, 31);
            var actual = USAFederalReserveHoliday.MemorialDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependence2004()
        {
            var expected = new DateTime(2004, 7, 5);
            var actual = USAFederalReserveHoliday.IndependenceDay(2004);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestLabor2004()
        {
            var expected = new DateTime(2004, 9, 6);
            var actual = USAFederalReserveHoliday.LaborDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColumbus2004()
        {
            var expected = new DateTime(2004, 10, 11);
            var actual = USAFederalReserveHoliday.ColumbusDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestVeterans2004()
        {
            var expected = new DateTime(2004, 11, 11);
            var actual = USAFederalReserveHoliday.VeteransDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving2004()
        {
            var expected = new DateTime(2004, 11, 25);
            var actual = USAFederalReserveHoliday.Thanksgiving(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2004()
        {
            var expected = new DateTime(2004, 12, 25);
            var actual = USAFederalReserveHoliday.Christmas(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNewYear()
        {
            var expected = new DateTime(2006, 1, 2);
            var actual = USAFederalReserveHoliday.NewYear(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMartinLutherKingDay()
        {
            var expected = new DateTime(2006, 1, 16);
            var actual = USAFederalReserveHoliday.MartinLutherKing(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWashington()
        {
            var expected = new DateTime(2006, 2, 20);
            var actual = USAFederalReserveHoliday.PresidentsDay(2006);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMemorial()
        {
            var expected = new DateTime(2006, 5, 29);
            var actual = USAFederalReserveHoliday.MemorialDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependence()
        {
            var expected = new DateTime(2006, 7, 4);
            var actual = USAFederalReserveHoliday.IndependenceDay(2006);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestLabor()
        {
            var expected = new DateTime(2006, 9, 4);
            var actual = USAFederalReserveHoliday.LaborDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColumbus()
        {
            var expected = new DateTime(2006, 10, 9);
            var actual = USAFederalReserveHoliday.ColumbusDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestVeterans()
        {
            var expected = new DateTime(2006, 11, 11);
            var actual = USAFederalReserveHoliday.VeteransDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving()
        {
            var expected = new DateTime(2006, 11, 23);
            var actual = USAFederalReserveHoliday.Thanksgiving(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas()
        {
            var expected = new DateTime(2006, 12, 25);
            var actual = USAFederalReserveHoliday.Christmas(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving1999()
        {
            var expected = new DateTime(1999, 11, 25);
            var actual = USAFederalReserveHoliday.Thanksgiving(1999);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new USAFederalReserveHoliday().IsPublicHoliday(thanksgiving);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new USAFederalReserveHoliday().NextWorkingDay(thanksgiving);
            Assert.AreEqual(new DateTime(1999, 11, 26), result);
        }

        [TestMethod]
        public void TestJuneteenth2021()
        {
            var juneteenth = new DateTime(2021, 6, 19);
            var result = USAFederalReserveHoliday.Juneteenth(2021);
            Assert.AreEqual(juneteenth, result.HolidayDate);

            var federalHolidays = new USAFederalReserveHoliday().PublicHolidaysInformation(2021);
            //19 June 2021 is Saturday, so would normally be observed on Friday
            var june19 = federalHolidays.FirstOrDefault(x => x.HolidayDate == juneteenth);
            Assert.IsNotNull(june19);

            //Was made a federal holiday in 2021, so it should not appear in 2020 list (although many states and companies observed it)
            federalHolidays = new USAFederalReserveHoliday().PublicHolidaysInformation(2020);
            june19 = federalHolidays.FirstOrDefault(x => x.HolidayDate == juneteenth);
            Assert.IsNull(june19);
        }

        [TestMethod]
        public void TestNextWorkingDayColumbus()
        {
            var result = new USAFederalReserveHoliday().NextWorkingDay(new DateTime(2006, 10, 8));
            Assert.AreEqual(new DateTime(2006, 10, 10), result);
        }

        [TestMethod]
        public void TestPublicHolidays()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new USAFederalReserveHoliday().PublicHolidays(1999);
            Assert.AreEqual(10, result.Count);
            Assert.IsTrue(result.Contains(thanksgiving));
        }

        [TestMethod]
        public void TestPublicHolidayInformation()
        {
            var usaFederalReserveHoliday = new USAFederalReserveHoliday();
            var hols = usaFederalReserveHoliday.PublicHolidays(2017);
            var infos = usaFederalReserveHoliday.PublicHolidaysInformation(2017);
            Assert.AreEqual(hols.Count, infos.Count);
            foreach (var info in infos)
            {
                Assert.IsTrue(hols.Contains(info), "observed date is implicitly in both lists");
            }
        }

        #region 2022 Tests

        [TestMethod]
        public void TestNewYears2022()
        {
            var expected = new DateTime(2022, 1, 1);
            var actual = USAFederalReserveHoliday.NewYear(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMLK2022()
        {
            var expected = new DateTime(2022, 1, 17);
            var actual = USAFederalReserveHoliday.MartinLutherKing(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPresidentsDay2022()
        {
            var expected = new DateTime(2022, 2, 21);
            var actual = USAFederalReserveHoliday.PresidentsDay(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMemorialDay2022()
        {
            var expected = new DateTime(2022, 5, 30);
            var actual = USAFederalReserveHoliday.MemorialDay(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestJuneteenth2022()
        {
            var expected = new DateTime(2022, 6, 20);
            var actual = USAFederalReserveHoliday.Juneteenth(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependenceDay2022()
        {
            var expected = new DateTime(2022, 7, 4);
            var actual = USAFederalReserveHoliday.IndependenceDay(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLaborDay2022()
        {
            var expected = new DateTime(2022, 9, 5);
            var actual = USAFederalReserveHoliday.LaborDay(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColumbus2022()
        {
            var expected = new DateTime(2022, 10, 10);
            var actual = USAFederalReserveHoliday.ColumbusDay(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestVeteransDay2022()
        {
            var expected = new DateTime(2022, 11, 11);
            var actual = USAFederalReserveHoliday.VeteransDay(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving2022()
        {
            var expected = new DateTime(2022, 11, 24);
            var actual = USAFederalReserveHoliday.Thanksgiving(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2022()
        {
            var expected = new DateTime(2022, 12, 26);
            var actual = USAFederalReserveHoliday.Christmas(2022);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region 2023 Tests

        [TestMethod]
        public void TestNewYears2023()
        {
            var expected = new DateTime(2023, 1, 2);
            var actual = USAFederalReserveHoliday.NewYear(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMLK2023()
        {
            var expected = new DateTime(2023, 1, 16);
            var actual = USAFederalReserveHoliday.MartinLutherKing(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPresidentsDay2023()
        {
            var expected = new DateTime(2023, 2, 20);
            var actual = USAFederalReserveHoliday.PresidentsDay(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMemorialDay2023()
        {
            var expected = new DateTime(2023, 5, 29);
            var actual = USAFederalReserveHoliday.MemorialDay(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestJuneteenth2023()
        {
            var expected = new DateTime(2023, 6, 19);
            var actual = USAFederalReserveHoliday.Juneteenth(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependenceDay2023()
        {
            var expected = new DateTime(2023, 7, 4);
            var actual = USAFederalReserveHoliday.IndependenceDay(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLaborDay2023()
        {
            var expected = new DateTime(2023, 9, 4);
            var actual = USAFederalReserveHoliday.LaborDay(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColumbus2023()
        {
            var expected = new DateTime(2023, 10, 9);
            var actual = USAFederalReserveHoliday.ColumbusDay(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestVeteransDay2023()
        {
            var expected = new DateTime(2023, 11, 11);
            var actual = USAFederalReserveHoliday.VeteransDay(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving2023()
        {
            var expected = new DateTime(2023, 11, 23);
            var actual = USAFederalReserveHoliday.Thanksgiving(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2023()
        {
            var expected = new DateTime(2023, 12, 25);
            var actual = USAFederalReserveHoliday.Christmas(2023);
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
