using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestLithuaniaPublicHoliday
    {
        [DataTestMethod]
        [DataRow(1, 1, "Naujųjų metų diena")]
        [DataRow(2, 16, "Lietuvos valstybės atkūrimo diena")]
        [DataRow(3, 11, "Lietuvos nepriklausomybės atkūrimo diena")]
        [DataRow(4, 17, "Šv. Velykos")] // Moving holiday
        [DataRow(4, 18, "Antroji šv. Velykų diena")] // Moving holiday
        [DataRow(5, 1, "Tarptautinė darbo diena ir Motinos diena")] // Moving holiday (Two holidays one day)
        [DataRow(6, 5, "Tėvo diena")] // Moving holiday
        [DataRow(6, 24, "Rasos ir Joninių diena")]
        [DataRow(7, 6, "Valstybės (Lietuvos karaliaus Mindaugo karūnavimo) ir Tautiškos giesmės diena")]
        [DataRow(11, 1, "Visų šventųjų diena")]
        [DataRow(11, 2, "Mirusiųjų atminimo (Vėlinių) diena")]
        [DataRow(12, 24, "Šv. Kūčios")]
        [DataRow(12, 25, "Šv. Kalėdos")]
        [DataRow(12, 26, "Šv. Kalėdos")]
        public void TestLithuaniaHolidays2022(int month, int day, string name)
        {
            var holiday = new DateTime(2022, month, day);
            var holidayCalendar = new LithuaniaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        [DataTestMethod]
        [DataRow(4, 9, "Šv. Velykos")] // Moving holiday
        [DataRow(4, 10, "Antroji šv. Velykų diena")] // Moving holiday
        [DataRow(5, 1, "Tarptautinė darbo diena")]
        [DataRow(5, 7, "Motinos diena")] // Moving holiday
        [DataRow(6, 4, "Tėvo diena")] // Moving holiday
        public void TestLithuaniaHolidays2023(int month, int day, string name)
        {
            var holiday = new DateTime(2023, month, day);
            var holidayCalendar = new LithuaniaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }
        
        [DataTestMethod]
        [DataRow(3, 31, "Šv. Velykos")] // Moving holiday
        [DataRow(4, 1, "Antroji šv. Velykų diena")] // Moving holiday
        [DataRow(5, 1, "Tarptautinė darbo diena")]
        [DataRow(5, 5, "Motinos diena")] // Moving holiday
        [DataRow(6, 2, "Tėvo diena")] // Moving holiday
        public void TestLithuaniaHolidays2024(int month, int day, string name)
        {
            var holiday = new DateTime(2024, month, day);
            var holidayCalendar = new LithuaniaPublicHoliday();

            var actual = holidayCalendar.IsPublicHoliday(holiday);

            Assert.IsTrue(actual, $"{holiday:D} is not a holiday - should be {name}");
        }

        /// <summary>
        /// Before 2000 Assumption Day was not a public holiday.
        /// </summary>
        [TestMethod]
        public void TestLithuaniaHolidays1999List()
        {
            var holiday = new DateTime(1999, 8, 15);
            var holidayCalendar = new LithuaniaPublicHoliday();
            var holidays = holidayCalendar.PublicHolidayNames(1999);

            Assert.AreEqual(15, holidays.Count, "Should be 15 holidays in 1999");
            Assert.IsFalse(holidays.ContainsKey(holiday));
        }
        
        /// <summary>
        /// After 2000 Assumption Day is a public holiday.
        /// </summary>
        [TestMethod]
        public void TestLithuaniaHolidays2000List()
        {
            var holiday = new DateTime(2000, 8, 15);
            var holidayCalendar = new LithuaniaPublicHoliday();
            var holidays = holidayCalendar.PublicHolidayNames(2000);

            Assert.AreEqual(16, holidays.Count, "Should be 16 holidays in 2000");
            Assert.IsTrue(holidays.ContainsKey(holiday));
        }

        [DataTestMethod]
        [DataRow(2022, 8, 13)]
        [DataRow(2022, 8, 14)]
        [DataRow(2022, 8, 15)]
        public void TestLithuaniaHolidaysIsWorkingDay(int year, int month, int day)
        {
            var holiday = new DateTime(year, month, day);
            var holidayCalendar = new LithuaniaPublicHoliday();
            var holidays = holidayCalendar.IsWorkingDay(holiday);

            Assert.IsFalse(holidays);
        }
        
        [DataTestMethod]
        [DataRow(2022, 8, 13)]
        [DataRow(2022, 8, 14)]
        [DataRow(2022, 8, 15)]
        public void TestLithuaniaHolidaysNextWorkingDayNotSameDay(int year, int month, int day)
        {
            var holiday = new DateTime(year, month, day);
            var holidayCalendar = new LithuaniaPublicHoliday();
            var holidays = holidayCalendar.NextWorkingDayNotSameDay(holiday);

            Assert.AreEqual(new DateTime(2022, 08, 16), holidays);
        }
    }
}