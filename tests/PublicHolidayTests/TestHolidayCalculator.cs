using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestHolidayCalculator
    {
                
        [DataTestMethod]
        [DataRow(2010, 4, 4)]
        [DataRow(2011, 4, 24)]
        [DataRow(2012, 4, 8)]
        [DataRow(2013, 3, 31)]
        [DataRow(2014, 4, 20)]
        [DataRow(2015, 4, 5)]
        [DataRow(2016, 3, 27)]
        [DataRow(2017, 4, 16)]
        [DataRow(2018, 4, 1)]
        [DataRow(2019, 4, 21)]
        public void TestGetEaster(int year, int month, int day)
        {
            var holiday = new DateTime(year, month, day);
            var result = HolidayCalculator.GetEaster(year);

            Assert.IsTrue(result.DayOfWeek == DayOfWeek.Sunday, $"{result.ToString("D")} is not Sunday");
            Assert.AreEqual(holiday, result, $"{result.ToString("D")} is not the {holiday} - should be Easter");
        }

        [DataTestMethod]
        [DataRow(2021, 10, 09, 10, 11, "should be monday")]
        [DataRow(2021, 10, 10, 10, 11, "should be monday")]
        [DataRow(2021, 10, 7, 10, 7, "should be same day")]
        public void TestFixWeekend(int year, int month, int day, int monthresult, int dayresult, string description)
        {
             var holiday = new DateTime(year, monthresult, dayresult);
             var daytest = new DateTime(year, month, day);
             var result = HolidayCalculator.FixWeekend(daytest);

             Assert.IsTrue(result.DayOfWeek != DayOfWeek.Saturday || result.DayOfWeek != DayOfWeek.Sunday, $"{result.ToString("D")} is not between Monday and Friday");
             Assert.AreEqual(holiday, result, $"{result.ToString("D")} is not the {holiday} - {description}");
        }

        [DataTestMethod]
        [DataRow(2021, 10, 9, 10, 8, "should be friday")]
        [DataRow(2021, 10, 10, 10, 11, "should be monday")]
        [DataRow(2021, 10, 7, 10, 7, "should be same day")]
        public void TestFixFixWeekendSaturdayBeforeSundayAfter(int year, int month, int day, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(year, monthresult, dayresult);
             var daytest = new DateTime(year, month, day);
            var result = HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(daytest);

            Assert.IsTrue(result.DayOfWeek != DayOfWeek.Saturday || result.DayOfWeek != DayOfWeek.Sunday, $"{result.ToString("D")} is not between Monday and Friday");
             Assert.AreEqual(holiday, result, $"{result.ToString("D")} is not the {holiday} - {description}");
        }

        [DataTestMethod]
        [DataRow(2021, 10, 7, 10, 7, "Week day (Tuesday-Friday) observerd same day")]
        [DataRow(2021, 10, 9, 10, 11, "Saturday day observed the Monday")]
        [DataRow(2021, 10, 10, 10, 12, "Sunday day observed the Tuesday")]
        [DataRow(2021, 10, 11, 10, 12, "Monday day observed the Tuesday")]
        public void TestFixWeekendTwoHolidayAfter(int year, int month, int day, int monthresult, int dayresult, string description)
        {
             var holiday = new DateTime(year, monthresult, dayresult);
             var daytest = new DateTime(year, month, day);
            var result = HolidayCalculator.FixWeekendTwoHolidayAfter(daytest);

             Assert.IsTrue(result.DayOfWeek != DayOfWeek.Saturday || result.DayOfWeek != DayOfWeek.Sunday, $"{result.ToString("D")} is not between Monday and Friday");
             Assert.AreEqual(holiday, result, $"{result.ToString("D")} is not the {holiday} - {description}");
        }

        [DataTestMethod]
        [DataRow(2021, 10, 6, 10, 6, "Week day observerd same day")]
        [DataRow(2021, 10, 9, 10, 8, "Saturday day observed the Friday")]
        [DataRow(2021, 10, 10, 10, 8, "Sunday day observed the Friday")]
        public void TestFixWeekendTwoHolidayBefore(int year, int month, int day, int monthresult, int dayresult, string description)
        {
              var holiday = new DateTime(year, monthresult, dayresult);
             var daytest = new DateTime(year, month, day);
            var result = HolidayCalculator.FixWeekendTwoHolidayBefore(daytest);

             Assert.IsTrue(result.DayOfWeek != DayOfWeek.Saturday || result.DayOfWeek != DayOfWeek.Sunday, $"{result.ToString("D")} is not between Monday and Friday");
             Assert.AreEqual(holiday, result, $"{result.ToString("D")} is not the {holiday} - {description}");
        }

    }

}



