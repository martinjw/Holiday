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
        [DataRow(4, 18, "Good Friday")] // Moving holiday
        [DataRow(4, 20, "Easter Sunday")] // Moving holiday
        [DataRow(4, 21, "Easter Monday")] // Moving holiday
        [DataRow(5, 1, "Labour Day")]
        [DataRow(5, 4, "Restoration of Independence Day")]
        [DataRow(5, 5, "Restoration of Independence Day (moved from Sunday)")]
        [DataRow(5, 11, "Mother's Day")] // Second Sunday of May
        [DataRow(6, 8, "Pentecost")] // Moving holiday
        [DataRow(6, 23, "Midsummer Eve")]
        [DataRow(6, 24, "Midsummer Day")]
        [DataRow(11, 18, "Proclamation Day")]
        [DataRow(12, 24, "Christmas Eve")]
        [DataRow(12, 25, "Christmas Day")]
        [DataRow(12, 26, "Second Day of Christmas")]
        [DataRow(12, 31, "New Year's Eve")]
        public void TestLatvianHolidays2025(int month, int day, string name)
        {
            var holiday = new DateTime(2025, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        [TestMethod]
        public void TestLatvianHolidays2025List()
        {
            var holidays = new LatviaPublicHoliday().PublicHolidayNames(2025);

            Assert.AreEqual(16, holidays.Count, "Should be 16 holidays in 2025");
        }

        [TestMethod]
        [DataRow(1, 1, "New Year's Day")]
        [DataRow(3, 29, "Good Friday")] // moving holiday
        [DataRow(3, 31, "Easter Sunday")] // moving holiday
        [DataRow(4, 1, "Easter Monday")] // moving holiday
        [DataRow(5, 1, "Labour Day")]
        [DataRow(5, 4, "Restoration of Independence Day")]
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
        [DataRow(2008, 5, 5, "4 May on Sunday")]
        [DataRow(2007, 11, 19, "18 November on Sunday")]
        [DataRow(2023, 11, 20, "18 November on Saturday")]
        [DataRow(2024, 5, 6, "4 May on Saturday")]
        [DataRow(2028, 11, 20, "18 November on Saturday")]
        public void TestLatvianTransferredHolidays(int year, int month, int day, string reason)
        {
            var holiday = new DateTime(year, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - {reason}");
        }

        [TestMethod]
        [DataRow(2024, 5, 7)] // 4 May on Saturday moves to Monday only
        [DataRow(2024, 11, 19)] // 18 November on Monday, no transfer
        [DataRow(2026, 5, 5)] // 4 May on Monday, no transfer
        public void TestLatvianNotTransferred(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(date);

            Assert.IsFalse(actual, $"{date:D} should not be a holiday");
        }

        /// <summary>
        /// The three holidays the law names (4 May, the Song and Dance Festival closing day and
        /// 18 November) stay holidays on their own date when it falls on a weekend, and the next
        /// working day is a day off as well ("pārceltā brīvdiena") - a holiday of its own, with
        /// its own key and name.
        /// </summary>
        [TestMethod]
        [DataRow(2024, 5, 4, 5, 6, HolidayKeys.RestorationOfIndependenceDayTransferredLV)] // Saturday -> Monday
        [DataRow(2019, 5, 4, 5, 6, HolidayKeys.RestorationOfIndependenceDayTransferredLV)] // Saturday -> Monday
        [DataRow(2014, 5, 4, 5, 5, HolidayKeys.RestorationOfIndependenceDayTransferredLV)] // Sunday -> Monday
        [DataRow(2023, 11, 18, 11, 20, HolidayKeys.ProclamationDayTransferredLV)] // Saturday -> Monday
        [DataRow(2017, 11, 18, 11, 20, HolidayKeys.ProclamationDayTransferredLV)] // Saturday -> Monday
        [DataRow(2023, 7, 9, 7, 10, HolidayKeys.SongAndDanceFestivalTransferredLV)] // Sunday -> Monday
        public void TestTransferredDayOff(int year, int month, int day, int dayOffMonth, int dayOffDay, string dayOffKey)
        {
            var holidayCalendar = new LatviaPublicHoliday();
            var holidays = holidayCalendar.PublicHolidaysInformation(year);

            var holiday = holidays.Single(h => h.HolidayDate == new DateTime(year, month, day));
            var dayOff = holidays.Single(h => h.HolidayKey == dayOffKey);

            Assert.AreEqual(holiday.HolidayDate, holiday.ObservedDate, "the holiday itself is not moved");
            Assert.AreEqual(new DateTime(year, dayOffMonth, dayOffDay), dayOff.HolidayDate);
            Assert.AreEqual(dayOff.HolidayDate, dayOff.ObservedDate);
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(holiday.HolidayDate));
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(dayOff.HolidayDate));
        }

        [TestMethod]
        public void TestTransferredDayOffName()
        {
            var dayOff = new LatviaPublicHoliday().PublicHolidaysInformation(2025)
                .Single(h => h.HolidayDate == new DateTime(2025, 5, 5));

            Assert.AreEqual("Latvijas Republikas Neatkarības atjaunošanas diena (pārceltā brīvdiena)", dayOff.Name);
            Assert.AreEqual("Restoration of Independence Day (transferred day off)", dayOff.EnglishName);
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
        /// Before 2007 Christmas Eve was not a public holiday and 4 May / 18 November were not moved.
        /// </summary>
        [TestMethod]
        public void TestLatvianHolidays2006()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2006, 12, 24)), "Christmas Eve from 2007");
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2006, 11, 20)), "Transfer rule from 2007");
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2006, 5, 4)));
        }

        /// <summary>
        /// Before 2002 4 May was not a public holiday.
        /// </summary>
        [TestMethod]
        public void TestLatvianHolidays2001()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2001, 5, 4)));
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
        /// Mother's Day and Whit Sunday can fall on the same Sunday (2008): both are kept, one
        /// name each.
        /// </summary>
        [TestMethod]
        public void TestLatvianMothersDayOnPentecost()
        {
            var holidays = new LatviaPublicHoliday().PublicHolidayNames(2008);

            CollectionAssert.AreEquivalent(new[] { "Mātes diena", "Vasarsvētki" }, holidays[new DateTime(2008, 5, 11)]);
        }

        [TestMethod]
        [DataRow(2018, 7, 8, "Song and Dance Festival closing day")]
        [DataRow(2018, 7, 9, "Song and Dance Festival closing day (moved from Sunday)")]
        [DataRow(2023, 5, 29, "Ice hockey bronze medal")]
        [DataRow(2023, 7, 9, "Song and Dance Festival closing day")]
        [DataRow(2023, 7, 10, "Song and Dance Festival closing day (moved from Sunday)")]
        public void TestLatvianSpecialHolidays(int year, int month, int day, string name)
        {
            var holiday = new DateTime(year, month, day);
            var holidayCalendar = new LatviaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        [TestMethod]
        public void TestLatvianSpecialHolidaysOnlyInTheirYear()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2024, 5, 29)));
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2024, 7, 8)));
        }

        /// <summary>
        /// The Song and Dance Festival is held about every five years on announced dates, so only
        /// the years it took place have the holiday.
        /// </summary>
        [TestMethod]
        public void TestSongAndDanceFestivalOnlyInFestivalYears()
        {
            Assert.IsFalse(new LatviaPublicHoliday().PublicHolidaysInformation(2024)
                .Any(h => h.HolidayKey == HolidayKeys.SongAndDanceFestivalLV
                       || h.HolidayKey == HolidayKeys.SongAndDanceFestivalTransferredLV), "no festival in 2024");
        }

        /// <summary>
        /// The pastoral visit of Pope Francis on 24 September 2018 was declared a holiday by the
        /// Saeima on 21 June 2018 (amendment to the holidays law).
        /// </summary>
        [TestMethod]
        public void TestPopeFrancisVisit()
        {
            var holidayCalendar = new LatviaPublicHoliday();

            Assert.IsTrue(holidayCalendar.IsPublicHoliday(new DateTime(2018, 9, 24)));
            Assert.IsFalse(holidayCalendar.IsPublicHoliday(new DateTime(2019, 9, 24)));
        }

        [TestMethod]
        public void TestLatvianNames()
        {
            var holidays = new LatviaPublicHoliday().PublicHolidaysInformation(2024);

            Assert.AreEqual("Jāņu diena", holidays.Single(h => h.HolidayDate == new DateTime(2024, 6, 24)).Name);
            Assert.AreEqual("Līgo diena", holidays.Single(h => h.HolidayDate == new DateTime(2024, 6, 23)).Name);
            Assert.AreEqual("Darba svētki, Latvijas Republikas Satversmes sapulces sasaukšanas diena",
                holidays.Single(h => h.HolidayDate == new DateTime(2024, 5, 1)).Name);
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
            Assert.AreEqual(HolidayKeys.SecondChristmasDayLV, secondChristmasDay.HolidayKey);
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
