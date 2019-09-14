using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestGermanyPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 6)]
        [DataRow(4, 14)]
        [DataRow(4, 17)]
        [DataRow(5, 1)]
        [DataRow(5, 25)]
        [DataRow(6, 5)]
        [DataRow(6, 15)]
        [DataRow(10, 3)]
        [DataRow(10, 31)]
        [DataRow(11, 1)]
        //[DataRow(11, 22)] only Saxony
        [DataRow(12, 25)]
        [DataRow(12, 26)]
        public void TestHolidays2017(int month, int day)
        {
            var holiday = new DateTime(2017, month, day);
            //Baden-Württemberg
            var holidayCalendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.BW };
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new GermanPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(10 == hols.Count, "Should be 10 holidays in 2017 - 500th anniversary Reformation");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidays2017BavariaLists()
        {
            var holidayCalendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.BY };
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            //technically, Bavaria widely observes Assumption/Mariä Himmelfahrt on August 15
            Assert.IsTrue(13 == hols.Count, "Should be 13 holidays in 2017 - 500th anniversary Reformation");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidays2017LowerSaxonyLists()
        {
            var holidayCalendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.NI };
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(10 == hols.Count, "Should be 10 holidays in 2017 - 500th anniversary Reformation");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidays2018Lists()
        {
            var holidayCalendar = new GermanPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2018);
            var holNames = holidayCalendar.PublicHolidayNames(2018);
            Assert.IsTrue(9 == hols.Count, "Should be 9 holidays in 2018");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestSaxonyRepentenceDay()
        {
            var actual = GermanPublicHoliday.Repentance(2017);
            Assert.AreEqual(new DateTime(2017, 11, 22), actual);

            var calendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.SN };
            Assert.IsTrue(calendar.HasRepentance);

            var calendar2 = new GermanPublicHoliday { State = GermanPublicHoliday.States.HE };
            Assert.IsFalse(calendar2.HasRepentance);
        }

        [TestMethod]
        public void TestThüringenChildrensDay()
        {
            var calendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.SN };
            Assert.IsFalse(calendar.HasWorldChildrensDay(2019));

            var calendar2 = new GermanPublicHoliday { State = GermanPublicHoliday.States.TH };
            //did not have official holiday in 2018
            Assert.IsFalse(calendar2.HasWorldChildrensDay(2018));
            Assert.IsFalse(calendar2.PublicHolidays(2018).Contains(new DateTime(2018, 9, 20)));
            //introduced official holiday in 2019
            Assert.IsTrue(calendar2.HasWorldChildrensDay(2019));
            Assert.IsTrue(calendar2.PublicHolidays(2019).Contains(new DateTime(2019, 9, 20)));
        }
    }
}