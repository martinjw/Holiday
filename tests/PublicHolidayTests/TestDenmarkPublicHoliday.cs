using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestDenmarkPublicHoliday
    {
        [TestMethod]
        public void TestPublicHolidays()
        {
            var easterMonday = new DateTime(2015, 4, 6);
            var result = new DenmarkPublicHoliday().PublicHolidayNames(2015);
            Assert.AreEqual(12, result.Count);
            Assert.IsTrue(result.ContainsKey(easterMonday));
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new DenmarkPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 17));

            Assert.IsTrue(isPublicHoliday, "Easter Monday");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new DenmarkPublicHoliday().IsPublicHoliday(new DateTime(2006, 4, 18));

            Assert.IsFalse(isPublicHoliday, "Not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new DenmarkPublicHoliday().NextWorkingDay(new DateTime(2015, 4, 2)); //Maundy thursday
            Assert.AreEqual(new DateTime(2015, 4, 7), result); //Day after easter monday
        }

        [TestMethod]
        public void TestPreviousWorkingDay()
        {
            var result = new DenmarkPublicHoliday().PreviousWorkingDay(new DateTime(2015, 4, 6)); //Easter monday
            Assert.AreEqual(new DateTime(2015, 4, 1), result); //Day before Maundy thursday
        }

        [TestMethod]
        public void TestNewYear2015()
        {
            var expected = new DateTime(2015, 1, 1);
            var actual = DenmarkPublicHoliday.NewYear(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMaundyThursday2015()
        {
            var expected = new DateTime(2015, 4, 2);
            var actual = DenmarkPublicHoliday.MaundyThursday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGoodFriday2015()
        {
            var expected = new DateTime(2015, 4, 3);
            var actual = DenmarkPublicHoliday.GoodFriday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEaster2015()
        {
            var expected = new DateTime(2015, 4, 5);
            var actual = DenmarkPublicHoliday.Easter(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEaster2024()
        {
            var expected = new DateTime(2024, 3, 31);
            var actual = DenmarkPublicHoliday.Easter(2024);
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(new DenmarkPublicHoliday().IsPublicHoliday(expected));
        }

        [TestMethod]
        public void TestEasterMonday2015()
        {
            var expected = new DateTime(2015, 4, 6);
            var actual = DenmarkPublicHoliday.EasterMonday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLabourDay2015()
        {
            var expected = new DateTime(2015, 5, 1);
            var actual = DenmarkPublicHoliday.LabourDay(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConstitutionDay2015()
        {
            var expected = new DateTime(2015, 6, 5);
            var actual = DenmarkPublicHoliday.ConstitutionDay(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAscensionDay2015()
        {
            var expected = new DateTime(2015, 5, 14);
            var actual = DenmarkPublicHoliday.Ascension(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGeneralPrayerDay2021()
        {
            var expected = new DateTime(2021, 4, 30);
            var actual = DenmarkPublicHoliday.GeneralPrayerDay(2021);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGeneralPrayerDay2024()
        {
            DateTime? expected = null;
            var actual = DenmarkPublicHoliday.GeneralPrayerDay(2024);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGeneralPrayerDay2023IsListedAsPublicHoliday()
        {
            var holidays = new DenmarkPublicHoliday().PublicHolidayNames(2023);
            Assert.IsTrue(holidays.Values.Contains("Store bededag"));
        }

        [TestMethod]
        public void TestGeneralPrayerDay2024IsNotListedAsPublicHoliday()
        {
            var holidays = new DenmarkPublicHoliday().PublicHolidayNames(2024);
            Assert.IsFalse(holidays.Values.Contains("Store bededag"));
        }

        [TestMethod]
        public void TestWhitSunday2015()
        {
            var expected = new DateTime(2015, 5, 24);
            var actual = DenmarkPublicHoliday.WhitSunday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWhitMonday2015()
        {
            var expected = new DateTime(2015, 5, 25);
            var actual = DenmarkPublicHoliday.WhitMonday(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2015()
        {
            var expected = new DateTime(2015, 12, 25);
            var actual = DenmarkPublicHoliday.Christmas(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBoxingDay2015()
        {
            var expected = new DateTime(2015, 12, 26);
            var actual = DenmarkPublicHoliday.BoxingDay(2015);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2017()
        {
            //Constitution Day falls on the same day as the Whit Monday holiday - Monday 5th June 2017
            var holidays = new DenmarkPublicHoliday().PublicHolidayNames(2017);
            Assert.AreEqual(DenmarkPublicHoliday.WhitMonday(2017), DenmarkPublicHoliday.ConstitutionDay(2017));

            var whitMondayName = holidays[DenmarkPublicHoliday.WhitMonday(2017)];
            Assert.IsNotNull(whitMondayName);
            Assert.IsTrue(whitMondayName.Contains(","));
        }

        [TestMethod]
        public void TestDisabledHolidays()
        {
            var holidays = new DenmarkPublicHoliday(includeConstitutionDay: false, includeLabourDay: false).PublicHolidayNames(2023);
            Assert.ThrowsException<KeyNotFoundException>(() => holidays[DenmarkPublicHoliday.ConstitutionDay(2023)]);
            Assert.ThrowsException<KeyNotFoundException>(() => holidays[DenmarkPublicHoliday.LabourDay(2023)]);
        }

        [TestMethod]
        public void TestDayAfterAscension2023()
        {
            var expected = new DateTime(2023, 05, 19);
            var actual = new DenmarkPublicHoliday(false, false, includeDayAfterAscension: true).DayAfterAscension(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDayAfterAscenionDifferenctConstructors()
        {
            Assert.IsFalse(new DenmarkPublicHoliday().IsPublicHoliday(new DateTime(2023, 05, 19)));
            Assert.IsFalse(new DenmarkPublicHoliday(true, true).IsPublicHoliday(new DateTime(2023, 05, 19)));
            Assert.IsTrue(new DenmarkPublicHoliday(true, true, true).IsPublicHoliday(new DateTime(2023, 05, 19)));

        }

        [TestMethod]
        public void TestBankHoliday2024()
        {
            var bankHolidayCalendar = new DenmarkPublicHoliday(true, false, includeDayAfterAscension: true,
                includeChristmasEve: true, includeNewYearsEve: true);
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 01, 01)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 03, 28)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 03, 29)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 04, 01)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 05, 09)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 05, 10)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 06, 05)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 12, 24)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 12, 25)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 12, 26)));
            Assert.IsTrue(bankHolidayCalendar.IsPublicHoliday(new DateTime(2024, 12, 31)));
        }

        [TestMethod]
        public void TestHolidaysLists()
        {
            var holidayCalendar = new DenmarkPublicHoliday();
            for (var year = 2015; year < 2040; year++)
            {
                //looking for collisions
                var holNames = holidayCalendar.PublicHolidayNames(year);
                var hols = holidayCalendar.PublicHolidays(year);
                foreach (var holiday in holNames.Keys)
                {
                    Assert.IsTrue(holidayCalendar.IsPublicHoliday(holiday),
                        $"Should be holiday: {holNames[holiday]} {holiday:yyyy-MM-dd}");
                }
            }
        }
    }
}
