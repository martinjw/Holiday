using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Linq;

namespace PublicHolidayTests
{
    /// <summary>
    /// Using official calendar from http://www.opm.gov/fedhol/2006.asp
    /// </summary>
    [TestClass]
    public class TestNewYorkStockExchangeHoliday
    {
        [TestMethod]
        public void TestThanksgiving2018()
        {
            var expected = new DateTime(2018, 11, 22);
            var actual = USANewYorkStockExchangeHoliday.Thanksgiving(2018);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNewYear2004()
        {
            var expected = new DateTime(2004, 1, 1);
            var actual = USANewYorkStockExchangeHoliday.NewYear(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMartinLutherKing2004()
        {
            var expected = new DateTime(2004, 1, 19);
            var actual = USANewYorkStockExchangeHoliday.MartinLutherKing(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWashington2004()
        {
            var expected = new DateTime(2004, 2, 16);
            var actual = USANewYorkStockExchangeHoliday.PresidentsDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGoodFriday2006()
        {
            var goodFriday = USANewYorkStockExchangeHoliday.GoodFriday(2006);
            Assert.AreEqual(new DateTime(2006, 4, 14), goodFriday);
        }

        [TestMethod]
        public void TestMemorial2004()
        {
            var expected = new DateTime(2004, 5, 31);
            var actual = USANewYorkStockExchangeHoliday.MemorialDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependence2004()
        {
            var expected = new DateTime(2004, 7, 5);
            var actual = USANewYorkStockExchangeHoliday.IndependenceDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLabor2004()
        {
            var expected = new DateTime(2004, 9, 6);
            var actual = USANewYorkStockExchangeHoliday.LaborDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving2004()
        {
            var expected = new DateTime(2004, 11, 25);
            var actual = USANewYorkStockExchangeHoliday.Thanksgiving(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2004()
        {
            var expected = new DateTime(2004, 12, 24);
            var actual = USANewYorkStockExchangeHoliday.Christmas(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNewYear()
        {
            var expected = new DateTime(2006, 1, 2);
            var actual = USANewYorkStockExchangeHoliday.NewYear(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNewYearObservedVsActual()
        {
            var actual = USANewYorkStockExchangeHoliday.NewYear(2023);
            Assert.AreEqual(new DateTime(2023, 1, 2), actual.ObservedDate, "1st January is Sunday, so observed on Monday");
            Assert.AreEqual(new DateTime(2023, 1, 1), actual.HolidayDate, "1st January is Sunday, available on Holiday date");
            Assert.AreEqual(new DateTime(2023, 1, 2), actual, "Implicit conversion to observed date");
            var hols = new USANewYorkStockExchangeHoliday().PublicHolidaysInformation(2023);
            var newYear = hols.First();
            Assert.AreEqual(new DateTime(2023, 1, 2), newYear.ObservedDate, "1st January is Sunday, so observed on Monday");
            Assert.AreEqual(new DateTime(2023, 1, 1), newYear.HolidayDate, "1st January is Sunday, available on Holiday date");
        }

        [TestMethod]
        public void TestMartinLutherKingDay()
        {
            var expected = new DateTime(2006, 1, 16);
            var actual = USANewYorkStockExchangeHoliday.MartinLutherKing(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWashington()
        {
            var expected = new DateTime(2006, 2, 20);
            var actual = USANewYorkStockExchangeHoliday.PresidentsDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMemorial()
        {
            var expected = new DateTime(2006, 5, 29);
            var actual = USANewYorkStockExchangeHoliday.MemorialDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependence()
        {
            var expected = new DateTime(2006, 7, 4);
            var actual = USANewYorkStockExchangeHoliday.IndependenceDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLabor()
        {
            var expected = new DateTime(2006, 9, 4);
            var actual = USANewYorkStockExchangeHoliday.LaborDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving()
        {
            var expected = new DateTime(2006, 11, 23);
            var actual = USANewYorkStockExchangeHoliday.Thanksgiving(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas()
        {
            var expected = new DateTime(2006, 12, 25);
            var actual = USANewYorkStockExchangeHoliday.Christmas(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving1999()
        {
            var expected = new DateTime(1999, 11, 25);
            var actual = USANewYorkStockExchangeHoliday.Thanksgiving(1999);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new USANewYorkStockExchangeHoliday().IsPublicHoliday(thanksgiving);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new USANewYorkStockExchangeHoliday().NextWorkingDay(thanksgiving);
            Assert.AreEqual(new DateTime(1999, 11, 26), result);
        }

        [TestMethod]
        public void TestJuneteenth2022()
        {
            var holidayDate = new DateTime(2022, 6, 19);
            var result = USANewYorkStockExchangeHoliday.Juneteenth(2022);
            var observedDate = new DateTime(2022, 6, 20);
            Assert.AreEqual(holidayDate, result.HolidayDate);
            Assert.AreEqual(observedDate, result.ObservedDate);

            //Was made a holiday for NYSE in 2022, so it should not appear in 2021 list
            holidayDate = holidayDate.AddYears(-1);
            var nyseHolidays = new USANewYorkStockExchangeHoliday().PublicHolidaysInformation(2021);
            var isJuneteenthPrior2022 = nyseHolidays.Where(x => x.HolidayDate == holidayDate).Any();
            Assert.IsFalse(isJuneteenthPrior2022);
        }

        [TestMethod]
        public void TestPublicHolidays()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new USANewYorkStockExchangeHoliday().PublicHolidays(1999);
            Assert.AreEqual(9, result.Count);
            Assert.IsTrue(result.Contains(thanksgiving));
        }

        [TestMethod]
        public void TestPublicHolidayInformation()
        {
            var USANewYorkStockExchangeHoliday = new USANewYorkStockExchangeHoliday();
            var hols = USANewYorkStockExchangeHoliday.PublicHolidays(2017);
            var infos = USANewYorkStockExchangeHoliday.PublicHolidaysInformation(2017);
            Assert.AreEqual(hols.Count, infos.Count);
            foreach (var info in infos)
            {
                Assert.IsTrue(hols.Contains(info), "observed date is implicitly in both lists");
            }
        }
    }
}