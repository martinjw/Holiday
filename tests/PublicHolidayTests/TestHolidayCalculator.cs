using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using PublicHolidayTests.HelperTest;

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

        [DataTestMethod]
        [DataRow(2021, 10, 22, 0, 2021, 10, 22, "Same day week and not holiday (not openDayAdd)")]
        [DataRow(2021, 10, 23, 0, 2021, 10, 25, "Weekend (saturday) go to Monday not holiday (not openDayAdd)")]
        [DataRow(2021, 10, 24, 0, 2021, 10, 25, "Weekend (sunday) go to Friday not holiday (not openDayAdd)")]
        [DataRow(2021, 10, 21, 1, 2021, 10, 22, "Day week and not holiday with openDayAdd of 1. Thursday -> Friday")]
        [DataRow(2021, 9, 3, 15, 2021, 9, 24, "Weekend with openDayAdd of 15 and not holiday. +3 week")]
        [DataRow(2021, 10, 18, 3, 2021, 10, 22, "Weekend with openDayAdd of 3 and one holiday in calculator. Monday -> Friday")]
        [DataRow(2021, 10, 22, 1, 2021, 10, 25, "Day week and weekend with openDayAdd of 1 (not holiday). Friday -> Monday")]
        [DataRow(2021, 10, 14, 1, 2021, 10, 18, "Day week and weekend with openDayAdd of 1 and holiday Friday. Friday -> Tuesday")]
        [DataRow(2021, 10, 8, 1, 2021, 10, 12, "Day week and with opendaysubstract of 1 and holiday Monday. Weekend to add. Friday -> Tuesday")]
        [DataRow(2021, 09, 23, 15, 2021, 10, 22, "Day week many holidays (6), weekend (3 standard and 1 with holiday) and openDayAdd (15).")]
        public void TestNextWorkingDay(int year, int month, int day, int opendaysubstract, int yearresult, int monthresult, int dayresult, string description)
        {
            var dateresult = new DateTime(yearresult, monthresult, dayresult);
            var datetest = new DateTime(year, month, day);

            var Holidaystest = new Dictionary<DateTime, string>();
            Holidaystest.Add(new DateTime(2021, 10, 4), "Holiday 2021-10-04");
            Holidaystest.Add(new DateTime(2021, 10, 5), "Holiday 2021-10-05");
            Holidaystest.Add(new DateTime(2021, 10, 6), "Holiday 2021-10-06");
            Holidaystest.Add(new DateTime(2021, 10, 11), "Holiday 2021-10-11");
            Holidaystest.Add(new DateTime(2021, 10, 15), "Holiday 2021-10-15");
            Holidaystest.Add(new DateTime(2021, 10, 20), "Holiday 2021-10-20");

            IPublicHolidays PublicHolidaysTest = new PublicHolidayHelperTest() { Holidays = Holidaystest };

            var result = HolidayCalculator.NextWorkingDay(PublicHolidaysTest, datetest, opendaysubstract);

            Assert.IsTrue(result.DayOfWeek != DayOfWeek.Saturday || result.DayOfWeek != DayOfWeek.Sunday, $"{result.ToString("D")} is not between Monday and Friday");
            Assert.AreEqual(dateresult, result, $"{result.ToString("D")} is not the {dateresult} - {description}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "openDayAdd negative is not allowed.")]
        public void TestNextWorkingDay_ArgumentOutOfRangeException()
        {
            var datetest = new DateTime(2021, 10, 22);
            var result = HolidayCalculator.NextWorkingDay(new PublicHolidayHelperTest(), datetest, -1);

            Assert.Fail("Not ArgumentOutOfRangeException");
        }

        [DataTestMethod]
        [DataRow(2021, 10, 22, 0, 2021, 10, 22, "Same day week and not holiday (not opendaysubstract)")]
        [DataRow(2021, 10, 23, 0, 2021, 10, 22, "Weekend (saturday) go to Friday not holiday (not opendaysubstract)")]
        [DataRow(2021, 10, 24, 0, 2021, 10, 22, "Weekend (sunday) go to Friday not holiday (not opendaysubstract)")]
        [DataRow(2021, 10, 22, 1, 2021, 10, 21, "Day week and not holiday with daysubstract of 1. Friday -> Thursday")]
        [DataRow(2021, 9, 24, 15, 2021, 9, 3, "Weekend with opendaysubstract of 15 and not holiday. -3 week")]
        [DataRow(2021, 10, 22, 3, 2021, 10, 18, "Weekend with opendaysubstract of 3 and one holiday in calculator. Friday -> Monday")]
        [DataRow(2021, 10, 25, 1, 2021, 10, 22, "Day week and weekend with opendaysubstract of 1 (not holiday). Monday -> Friday")]
        [DataRow(2021, 10, 18, 1, 2021, 10, 14, "Day week and weekend with opendaysubstract of 1 and holiday friday. Monday -> Thursday")]
        [DataRow(2021, 10, 12, 1, 2021, 10, 8, "Day week and with opendaysubstract of 1 and holiday Monday. Weekend to substract. Tuesday -> Friday")]
        [DataRow(2021, 10, 22, 15, 2021, 09, 23, "Day week many holidays (6), weekend (3 standard and 1 with holiday) and opendaysubstract (15).")]
        public void TestPreviousWorkingDay(int year, int month, int day, int opendaysubstract, int yearresult, int monthresult, int dayresult, string description)
        {
            var dateresult = new DateTime(yearresult, monthresult, dayresult);
            var datetest = new DateTime(year, month, day);

            var Holidaystest = new Dictionary<DateTime, string>();
            Holidaystest.Add(new DateTime(2021, 10, 4), "Holiday 2021-10-04");
            Holidaystest.Add(new DateTime(2021, 10, 5), "Holiday 2021-10-05");
            Holidaystest.Add(new DateTime(2021, 10, 6), "Holiday 2021-10-06");
            Holidaystest.Add(new DateTime(2021, 10, 11), "Holiday 2021-10-11");
            Holidaystest.Add(new DateTime(2021, 10, 15), "Holiday 2021-10-15");
            Holidaystest.Add(new DateTime(2021, 10, 20), "Holiday 2021-10-20");

            IPublicHolidays PublicHolidaysTest = new PublicHolidayHelperTest() { Holidays = Holidaystest };

            var result = HolidayCalculator.PreviousWorkingDay(PublicHolidaysTest, datetest, opendaysubstract);

            Assert.IsTrue(result.DayOfWeek != DayOfWeek.Saturday || result.DayOfWeek != DayOfWeek.Sunday, $"{result.ToString("D")} is not between Monday and Friday");
            Assert.AreEqual(dateresult, result, $"{result.ToString("D")} is not the {dateresult} - {description}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "daysubstract negative is not allowed.")]
        public void TestPreviousWorkingDay_ArgumentOutOfRangeException()
        {
            var datetest = new DateTime(2021, 10, 22);
            var result = HolidayCalculator.PreviousWorkingDay(new PublicHolidayHelperTest(), datetest, -1);

            Assert.Fail("Not ArgumentOutOfRangeException");
        }
    }

}



