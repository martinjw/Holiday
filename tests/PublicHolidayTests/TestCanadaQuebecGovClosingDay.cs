using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestCanadaQuebecGovClosingDay
    {

        [DataTestMethod]
        [DataRow(1, 2, "New Year")]
        [DataRow(1, 3, "Day After New Year")]
        [DataRow(4, 14, "Good Friday")]
        [DataRow(4, 17, "Easter Monday")]
        [DataRow(5, 22, "National Patriots' Day")]
        [DataRow(6, 23, "National Holiday")]
        [DataRow(6, 30, "Canada Day")]
        [DataRow(9, 4, "Labour Day")]
        [DataRow(10, 9, "Thanksgiving")]
        [DataRow(12, 22, "Day Before Christmas")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 26, "Day After Christmas")]
        [DataRow(12, 29, "Day Before New Year")]
        public void TestCanadaQuebecGovClosingDay2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new CanadaQuebecGovClosingDay();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
        }

        [DataTestMethod]
        [DataRow(1, 1, "New Year")]
        [DataRow(1, 4, "Day After New Year")]
        [DataRow(3, 25, "Good Friday")]
        [DataRow(3, 28, "Easter Monday")]
        [DataRow(5, 23, "National Patriots' Day")]
        [DataRow(6, 24, "National Holiday")]
        [DataRow(7, 1, "Canada Day")]
        [DataRow(9, 5, "Labour Day")]
        [DataRow(10, 10, "Thanksgiving")]
        [DataRow(12, 23, "Day Before Christmas")]
        [DataRow(12, 26, "Christmas")]
        [DataRow(12, 27, "Day After Christmas")]
        [DataRow(12, 30, "Day Before New Year")]
        public void TestCanadaQuebecGovClosingDay2016(int month, int day, string name)
        {
            var holiday = new DateTime(2016, month, day);
            var holidayCalendar = new CanadaQuebecGovClosingDay();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");
           
        }

        [DataTestMethod]
        [DataRow(1, 3, "New Year")]
        [DataRow(1, 4, "Day After New Year")]
        [DataRow(4, 22, "Good Friday")]
        [DataRow(4, 25, "Easter Monday")]
        [DataRow(5, 23, "National Patriots' Day")]
        [DataRow(6, 24, "National Holiday")]
        [DataRow(7, 1, "Canada Day")]
        [DataRow(9, 5, "Labour Day")]
        [DataRow(10, 10, "Thanksgiving")]
        [DataRow(12, 23, "Day Before Christmas")]
        [DataRow(12, 26, "Christmas")]
        [DataRow(12, 27, "Day After Christmas")]
        [DataRow(12, 30, "Day Before New Year")]
        public void TestCanadaQuebecGovClosingDay2011(int month, int day, string name)
        {
            var holiday = new DateTime(2011, month, day);
            var holidayCalendar = new CanadaQuebecGovClosingDay();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday - should be {name}");

        }

        [TestMethod]
        public void TestCanadaQuebecGovClosingDay2017Lists()
        {
            var holidayCalendar = new CanadaQuebecGovClosingDay();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            //13 holidays
            Assert.IsTrue(13 == hols.Count, "Should be 13 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [DataTestMethod]
        [DataRow(2021, 2021, 1, 1, "New Year week day observerd same day")]
        [DataRow(2011, 2011, 1, 3, "New Year Saturday day observed the Monday")]
        [DataRow(2017, 2017, 1, 2, "New Year Sunday day observed the Monday")]
        public void TestCanadaQuebecGovClosingDayNewYear(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.NewYear(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2020, 2020, 1, 2, "Day After New Year week day (Tuesday-Friday) observerd same day")]
        [DataRow(2021, 2021, 1, 4, "Day After New Year Saturday day observed the Monday")]
        [DataRow(2011, 2011, 1, 4, "Day After New Year Sunday day observed the Tuesday")]
        [DataRow(2017, 2017, 1, 3, "Day After New Year Monday day observed the Tuesday")]
        public void TestCanadaQuebecGovClosingDayAfterNewYear(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.DayAfterNewYear(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2010, 2010, 4, 2, "Good Friday")]
        [DataRow(2011, 2011, 4, 22, "Good Friday")]
        [DataRow(2012, 2012, 4, 6, "Good Friday")]
        [DataRow(2013, 2013, 3, 29, "Good Friday")]
        [DataRow(2014, 2014, 4, 18, "Good Friday")]
        [DataRow(2015, 2015, 4, 3, "Good Friday")]
        [DataRow(2016, 2016, 3, 25, "Good Friday")]
        [DataRow(2017, 2017, 4, 14, "Good Friday")]
        [DataRow(2018, 2018, 3, 30, "Good Friday")]
        [DataRow(2019, 2019, 4, 19, "Good Friday")]
        public void TestCanadaQuebecGovClosingGoodFriday(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.GoodFriday(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2010, 2010, 4, 5, "Easter Monday")]
        [DataRow(2011, 2011, 4, 25, "Easter Monday")]
        [DataRow(2012, 2012, 4, 9, "Easter Monday")]
        [DataRow(2013, 2013, 4, 1, "Easter Monday")]
        [DataRow(2014, 2014, 4, 21, "Easter Monday")]
        [DataRow(2015, 2015, 4, 6, "Easter Monday")]
        [DataRow(2016, 2016, 3, 28, "Easter Monday")]
        [DataRow(2017, 2017, 4, 17, "Easter Monday")]
        [DataRow(2018, 2018, 4, 2, "Easter Monday")]
        [DataRow(2019, 2019, 4, 22, "Easter Monday")]
        public void TestCanadaQuebecGovClosingEasterMonday(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.EasterMonday(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2010, 2010, 5, 24, "National Patriot Day")]
        [DataRow(2011, 2011, 5, 23, "National Patriot Day")]
        [DataRow(2012, 2012, 5, 21, "National Patriot Day")]
        [DataRow(2013, 2013, 5, 20, "National Patriot Day")]
        [DataRow(2014, 2014, 5, 19, "National Patriot Day")]
        [DataRow(2015, 2015, 5, 18, "National Patriot Day")]
        [DataRow(2017, 2017, 5, 22, "National Patriot Day")]
        public void TestCanadaQuebecGovClosingNationalPatriotDay(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.NationalPatriotDay(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2021, 2021, 6, 24, "National Holiday week day (Monday-Friday) observerd same day")]
        [DataRow(2017, 2017, 6, 23, "National Holiday Saturday observerd Friday")]
        [DataRow(2018, 2018, 6, 25, "National Holiday Sunday observerd Monday")]
        public void TestCanadaQuebecGovClosingNationalHoliday(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.NationalHoliday(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2021, 2021, 7, 1, "Canada Day week day (Monday-Friday) observerd same day")]
        [DataRow(2017, 2017, 6, 30, "Canada Day Saturday observerd Friday")]
        [DataRow(2018, 2018, 7, 2, "Canada Day Sunday observerd Monday")]
        public void TestCanadaQuebecGovClosingCanadaDay(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.CanadaDay(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2010, 2010, 9, 6, "Labour Day")]
        [DataRow(2011, 2011, 9, 5, "Labour Day")]
        [DataRow(2012, 2012, 9, 3, "Labour Day")]
        [DataRow(2013, 2013, 9, 2, "Labour Day")]
        [DataRow(2014, 2014, 9, 1, "Labour Day")]
        [DataRow(2015, 2015, 9, 7, "Labour Day")]
        [DataRow(2017, 2017, 9, 4, "Labour Day")]
        public void TestCanadaQuebecGovClosingLabourDay(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.LabourDay(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2010, 2010, 10, 11, "Thanksgiving")]
        [DataRow(2011, 2011, 10, 10, "Thanksgiving")]
        [DataRow(2012, 2012, 10, 8, "Thanksgiving")]
        [DataRow(2013, 2013, 10, 14, "Thanksgiving")]
        [DataRow(2014, 2014, 10, 13, "Thanksgiving")]
        [DataRow(2015, 2015, 10, 12, "Thanksgiving")]
        [DataRow(2017, 2017, 10, 9, "Thanksgiving")]
        public void TestCanadaQuebecGovClosingThanksgiving(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.Thanksgiving(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2015, 2015, 12, 24, "Day Before Christmas week day observerd same day")]
        [DataRow(2016, 2016, 12, 23, "Day Before Christmas Saturday day observed the Monday")]
        [DataRow(2017, 2017, 12, 22, "Day Before Christmas Sunday day observed the Tuesday")]
        public void TestCanadaQuebecGovClosingDayBeforeChristmas(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.DayBeforeChristmas(year);
            
            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2012, 2012, 12, 25, "Christmas week day observerd same day")]
        [DataRow(2010, 2010, 12, 27, "Christmas Saturday day observed the Monday")]
        [DataRow(2011, 2011, 12, 26, "Christmas Sunday day observed the Monday")]
        public void TestCanadaQuebecGovClosingDayChristmas(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.Christmas(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2012, 2012, 12, 26, "Day After Christmas week day (Tuesday-Friday) observerd same day")]
        [DataRow(2015, 2015, 12, 28, "Day After Christmas Saturday day observed the Monday")]
        [DataRow(2010, 2010, 12, 28, "Day After Christmas Sunday day observed the Tuesday")]
        [DataRow(2011, 2011, 12, 27, "Day After Christmas Monday day observed the Tuesday")]
        public void TestCanadaQuebecGovClosingDayAfterChristmas(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.DayAfterChristmas(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2015, 2015, 12, 31, "Day Before New Year week day observerd same day")]
        [DataRow(2016, 2016, 12, 30, "Day Before New Year Saturday day observed the Friday")]
        [DataRow(2017, 2017, 12, 29, "Day Before New Year Sunday day observed the Friday")]
        public void TestCanadaQuebecGovClosingDayBeforeNewYear(int year, int yearresult, int monthresult, int dayresult, string description)
        {
            var holiday = new DateTime(yearresult, monthresult, dayresult);
            var result = CanadaQuebecGovClosingDay.DayBeforeNewYear(year);

            Assert.AreEqual(result, holiday, $"{result.ObservedDate.ToString("D")} is not the {holiday.ToString()} - should be {description}");
        }

        [DataTestMethod]
        [DataRow(2021, 12, 25, 0, 2021, 12, 29, "Christmas a Satuday NextWorkingDay with 0 openDayAdd the Wednesday")]
        public void TestNextWorkingDay(int year, int month, int day, int openDayAdd, int yearresult, int monthresult, int dayresult, string description)
        {
            var dateresult = new DateTime(yearresult, monthresult, dayresult);
            var datetest = new DateTime(year, month, day);

            var QuebecGov = new CanadaQuebecGovClosingDay();
            var result = QuebecGov.NextWorkingDay(datetest,openDayAdd);

            Assert.IsTrue(result.DayOfWeek != DayOfWeek.Saturday || result.DayOfWeek != DayOfWeek.Sunday, $"{result.ToString("D")} is not between Monday and Friday");
            Assert.AreEqual(dateresult, result, $"{result.ToString("D")} is not the {dateresult} - {description}");
        }

    }

}



