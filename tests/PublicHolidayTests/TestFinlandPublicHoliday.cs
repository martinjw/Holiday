using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
// ReSharper disable StringLiteralTypo

namespace PublicHolidayTests
{
    [TestClass]
    public class TestFinlandPublicHoliday
    {
        [TestMethod]
        public void Test2022FullCalendar()
        {
            // https://almanakka.helsinki.fi/en/flag-days-and-holidays-in-finland.html
            var holidays = new List<DateTime>
            {
                new(2022, 1, 1),
                new(2022, 1, 6),
                new(2022, 4, 15),
                new(2022, 4, 17),
                new(2022, 4, 18),
                new(2022, 5, 1),
                new(2022, 5, 26),
                new(2022, 6, 24),
                new(2022, 6, 25),
                new(2022, 11, 5),
                new(2022, 12, 6),
                new(2022, 12, 24),
                new(2022, 12, 25),
                new(2022, 12, 26)
            };

            var calendar = new FinlandPublicHoliday(true);

            foreach (var date in holidays)
            {
                Assert.IsTrue(calendar.IsPublicHoliday(date));
            }
        }

        [TestMethod]
        public void Test2023FullCalentar()
        {
            // https://almanakka.helsinki.fi/en/flag-days-and-holidays-in-finland.html
            var holidays = new List<DateTime>
            {
                new(2023, 1, 1),
                new(2023, 1, 6),
                new(2023, 4, 7),
                new(2023, 4, 9),
                new(2023, 4, 10),
                new(2023, 5, 1),
                new(2023, 5, 18),
                new(2023, 6, 23),
                new(2023, 6, 24),
                new(2023, 11, 4),
                new(2023, 12, 6),
                new(2023, 12, 24),
                new(2023, 12, 25),
                new(2023, 12, 26)
            };

            var calendar = new FinlandPublicHoliday(true);

            foreach (var date in holidays)
            {
                Assert.IsTrue(calendar.IsPublicHoliday(date));
            }
        }

        // https://fi.wikipedia.org/wiki/Juhannus
        [TestMethod]
        [DataRow(2010, 6, 26)]
        [DataRow(2011, 6, 25)]
        [DataRow(2012, 6, 23)]
        [DataRow(2013, 6, 22)]
        [DataRow(2014, 6, 21)]
        [DataRow(2015, 6, 20)]
        [DataRow(2016, 6, 25)]
        [DataRow(2017, 6, 24)]
        [DataRow(2018, 6, 23)]
        [DataRow(2019, 6, 22)]
        public void TestMovingMidsummers(int year, int month, int day)
        {
            var calendar = new FinlandPublicHoliday(true);

            var date = new DateTime(year, month, day);
            Assert.IsTrue(calendar.IsPublicHoliday(date));

            var holidays = calendar.PublicHolidayNames(year);
            Assert.AreEqual("Juhannuspäivä", holidays[date]);
            Assert.AreEqual("Juhannusaatto", holidays[date.AddDays(-1)]);
        }

        [TestMethod]
        [DataRow(2023, 11, 4)]
        [DataRow(2024, 11, 2)]
        [DataRow(2025, 11, 1)]
        public void TestMovingAllSaintsDay(int year, int month, int day)
        {
            var calendar = new FinlandPublicHoliday(true);

            var date = new DateTime(year, month, day);
            Assert.IsTrue(calendar.IsPublicHoliday(date));

            var holidays = calendar.PublicHolidayNames(year);
            Assert.AreEqual("Pyhäinpäivä", holidays[date]);
        }

        [TestMethod]
        [DataRow(2020)]
        [DataRow(2021)]
        [DataRow(2022)]
        [DataRow(2023)]
        [DataRow(2024)]
        [DataRow(2025)]
        [DataRow(2026)]
        [DataRow(2027)]
        [DataRow(2028)]
        [DataRow(2029)]
        public void TestStaticDates(int year)
        {
            var staticHolidays = new List<DateTime>
            {
                new(year, 1, 1),
                new(year, 1, 6),
                new(year, 5, 1),
                new(year, 12, 6),
                new(year, 12, 25),
                new(year, 12, 26)
            };

            var calendar = new FinlandPublicHoliday();

            foreach (var holiday in staticHolidays)
            {
                Assert.IsTrue(calendar.IsPublicHoliday(holiday));
            }
        }

        [TestMethod]
        public void TestIsPublicHoliday_ShouldNormalizeInputDateTime()
        {
            var calendar = new FinlandPublicHoliday();
            
            var holiday = new DateTime(2023, 1, 1, 5, 0, 0);

            Assert.IsTrue(calendar.IsPublicHoliday(holiday));

        }
        
        [TestMethod]
        [DataRow(2000, 13)]
        [DataRow(2001, 13)]
        [DataRow(2002, 13)]
        [DataRow(2003, 13)]
        [DataRow(2004, 13)]
        [DataRow(2005, 13)] 
        [DataRow(2006, 13)] 
        [DataRow(2007, 13)] 
        [DataRow(2008, 12)]//Alteration due to leap year 
        [DataRow(2009, 13)] 
        public void TestHolidayCountWithoutNonOfficials(int year, int expected)
        {
            var calendar = new FinlandPublicHoliday();

            Assert.AreEqual(expected, calendar.PublicHolidays(year).Count);
        }

        [TestMethod]
        public void TestCalendarAlterations()
        {
            var calendar = new FinlandPublicHoliday(true);

            // Independence day
            Assert.IsFalse(calendar.IsPublicHoliday(new DateTime(1918, 12, 6)));
            Assert.IsTrue(calendar.IsPublicHoliday(new DateTime(1919, 12, 6)));

            // Midsummer & All Saints Day
            var holidays1954 = calendar.PublicHolidayNames(1954);
            Assert.AreEqual("Juhannusaatto", holidays1954[new DateTime(1954, 6, 23)]);
            Assert.AreEqual("Juhannuspäivä", holidays1954[new DateTime(1954, 6, 24)]);
            Assert.AreEqual("Pyhäinpäivä", holidays1954[new DateTime(1954, 11, 1)]);

            var holidays1955 = calendar.PublicHolidayNames(1955);
            Assert.AreEqual("Juhannusaatto", holidays1955[new DateTime(1955, 6, 24)]);
            Assert.AreEqual("Juhannuspäivä", holidays1955[new DateTime(1955, 6, 25)]);
            Assert.AreEqual("Pyhäinpäivä", holidays1955[new DateTime(1955, 11, 5)]);
        }

        [TestMethod]
        [Ignore("Test that moving days won't cause any unexpected failures")]
        public void TestCalendarCreationFrom1744To2100()
        {
            for (int i = 1744; i <= 2100; i++)
            {
                var calendar = new FinlandPublicHoliday(true);

                var holidays = calendar.PublicHolidayNames(i);
            }
        }
    }
}
