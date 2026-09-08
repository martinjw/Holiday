using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestLatviaPublicHoliday
    {
        [TestMethod]
        [DataRow(1, 1, "New Year's Day")]
        [DataRow(3, 29, "Good Friday")] // moving holiday
        [DataRow(3, 31, "Easter Sunday")] // moving holiday
        [DataRow(4, 1, "Easter Monday")] // moving holiday
        [DataRow(5, 1, "Labour Day")]
        [DataRow(5, 6, "Restoration of Independence Day - 4 May was a Saturday")]
        [DataRow(5, 12, "Mother's Day")] // second Sunday of May
        [DataRow(5, 19, "Whit Sunday")] // moving holiday
        [DataRow(6, 23, "Midsummer Eve")]
        [DataRow(6, 24, "Midsummer Day")]
        [DataRow(11, 18, "Proclamation Day")]
        [DataRow(12, 24, "Christmas Eve")]
        [DataRow(12, 25, "Christmas Day")]
        [DataRow(12, 26, "Second Day of Christmas")]
        [DataRow(12, 31, "New Year's Eve")]
        public void TestLatvianHolidays2024(int month, int day, string name)
        {
            var holiday = new DateTime(2024, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        [TestMethod]
        [DataRow(4, 18, "Good Friday")]
        [DataRow(4, 20, "Easter Sunday")]
        [DataRow(4, 21, "Easter Monday")]
        [DataRow(5, 11, "Mother's Day")]
        [DataRow(6, 8, "Whit Sunday")]
        public void TestLatvianMovingHolidays2025(int month, int day, string name)
        {
            var holiday = new DateTime(2025, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        /// <summary>
        /// The three holidays the law names (4 May, the Song and Dance Festival closing day and
        /// 18 November) keep their date but are observed on the next working day when they fall on
        /// a weekend.
        /// </summary>
        [TestMethod]
        [DataRow(2024, 5, 4, 5, 6)] // Saturday -> Monday
        [DataRow(2019, 5, 4, 5, 6)] // Saturday -> Monday
        [DataRow(2014, 5, 4, 5, 5)] // Sunday -> Monday
        [DataRow(2023, 11, 18, 11, 20)] // Saturday -> Monday
        [DataRow(2017, 11, 18, 11, 20)] // Saturday -> Monday
        public void TestObservedOnNextWorkingDay(int year, int month, int day, int observedMonth, int observedDay)
        {
            var holidayCalendar = new LatviaPublicHoliday();

            var holiday = holidayCalendar.PublicHolidaysInformation(year)
                .Single(h => h.HolidayDate == new DateTime(year, month, day));

            Assert.AreEqual(new DateTime(year, observedMonth, observedDay), holiday.ObservedDate);
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(holiday.HolidayDate), "the weekend day itself is not a day off");
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(holiday.ObservedDate));
        }

        /// <summary>
        /// Latvia has no general mondayisation: Christmas and New Year's Eve are not moved when
        /// they fall on a weekend.
        /// </summary>
        [TestMethod]
        [DataRow(2022, 12, 27)] // 25 and 26 December 2022 were Sunday and Monday
        [DataRow(2021, 12, 27)] // 25 and 26 December 2021 were Saturday and Sunday
        [DataRow(2022, 1, 3)] // 1 January 2022 was a Saturday
        public void TestNoSubstituteDayForChristmasOrNewYear(int year, int month, int day)
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(year, month, day)));
        }

        /// <summary>
        /// The weekend rule arrived with the 2007 amendment to the holidays law: in 2006,
        /// 18 November fell on a Saturday and no day off followed it.
        /// </summary>
        [TestMethod]
        public void TestNoSubstituteDayBefore2007()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            var holiday = holidayCalendar.PublicHolidaysInformation(2006)
                .Single(h => h.HolidayDate == new DateTime(2006, 11, 18));

            Assert.AreEqual(new DateTime(2006, 11, 18), holiday.ObservedDate);
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2006, 11, 20)));
        }

        /// <summary>
        /// Christmas Eve became a holiday with the same 2007 amendment.
        /// </summary>
        [TestMethod]
        public void TestChristmasEveFrom2007()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsFalse(holidayCalendar.PublicHolidayNames(2006).ContainsKey(new DateTime(2006, 12, 24)));
            Assert.IsTrue(holidayCalendar.PublicHolidayNames(2007).ContainsKey(new DateTime(2007, 12, 24)));
        }

        /// <summary>
        /// The Song and Dance Festival is held about every five years on announced dates, so only
        /// the years it took place have the holiday.
        /// </summary>
        [TestMethod]
        public void TestSongAndDanceFestivalClosingDay()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2018, 7, 9)), "8 July 2018 was a Sunday, observed on the Monday");
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2023, 7, 10)), "9 July 2023 was a Sunday, observed on the Monday");
            Assert.IsFalse(holidayCalendar.PublicHolidaysInformation(2024)
                .Any(h => h.HolidayKey == "SongAndDanceFestivalLV"), "no festival in 2024");
        }

        /// <summary>
        /// Two holidays that happened exactly once: the pastoral visit of Pope Francis and the day
        /// after the ice hockey team won bronze at the 2023 World Championship.
        /// </summary>
        [TestMethod]
        public void TestOneOffHolidays()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2018, 9, 24)));
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2023, 5, 29)));
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2024, 5, 29)));
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2019, 9, 24)));
        }

        [TestMethod]
        public void TestLatvianNames()
        {
            var holidays = new LatviaPublicHoliday().PublicHolidaysInformation(2024);

            Assert.AreEqual("Jāņu diena", holidays.Single(h => h.HolidayDate == new DateTime(2024, 6, 24)).Name);
            Assert.AreEqual("Līgo diena", holidays.Single(h => h.HolidayDate == new DateTime(2024, 6, 23)).Name);
            Assert.AreEqual("Latvijas Republikas proklamēšanas diena",
                holidays.Single(h => h.HolidayDate == new DateTime(2024, 11, 18)).Name);
            Assert.AreEqual("Otrie Ziemassvētki", holidays.Single(h => h.HolidayDate == new DateTime(2024, 12, 26)).Name);
        }

        /// <summary>
        /// 26 December is Latvia's second day of Christmas, not St Stephen's Day, so it has its own
        /// localization key and English name.
        /// </summary>
        [TestMethod]
        public void TestSecondChristmasDayIsNotStStephensDay()
        {
            var secondChristmasDay = new LatviaPublicHoliday().PublicHolidaysInformation(2024)
                .Single(h => h.HolidayDate == new DateTime(2024, 12, 26));

            Assert.AreEqual("Second Day of Christmas", secondChristmasDay.GetName("en"));
            Assert.AreEqual("SecondChristmasDayLV", secondChristmasDay.HolidayKey);
        }

        /// <summary>
        /// A holiday Latvia shares with other countries takes its translation from the shared key,
        /// so asking for another language works without any Latvia-specific resource.
        /// </summary>
        [TestMethod]
        public void TestSharedKeysTranslate()
        {
            var christmas = new LatviaPublicHoliday().PublicHolidaysInformation(2024)
                .Single(h => h.HolidayDate == new DateTime(2024, 12, 25));

            Assert.AreEqual("Pirmie Ziemassvētki", christmas.Name);
            Assert.AreEqual("Fête de Noël", christmas.GetName("fr"));
            Assert.AreEqual("Christmas", christmas.GetName("en"));
        }

        [TestMethod]
        public void TestFactoryAndCulture()
        {
            var calendar = PublicHolidayFactory.GetPublicHolidayForCountry(PublicHolidayCountryCode.Lv);

            Assert.IsInstanceOfType(calendar, typeof(LatviaPublicHoliday));
            Assert.AreEqual("Jaungada diena", calendar.PublicHolidayNames(2024)[new DateTime(2024, 1, 1)].Single());
            Assert.AreEqual("New Year", calendar.WithCulture("en-GB")
                .PublicHolidayNames(2024)[new DateTime(2024, 1, 1)].Single());
        }
    }
}
