using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestSouthAfricaPublicHoliday
    {
        [TestMethod]
        [DataRow(1, 2, "New year - observed on Monday")]
        [DataRow(3, 21, "Human Rights Day")]
        [DataRow(4, 14, "Good Friday")]
        [DataRow(4, 17, "Family Day")]
        [DataRow(4, 27, "Freedom Day")]
        [DataRow(5, 1, "Workers' Day")]
        [DataRow(6, 16, "Youth Day")]
        [DataRow(8, 9, "National Women's Day")]
        [DataRow(9, 25, "Heritage Day")]
        [DataRow(12, 25, "christmas")]
        [DataRow(12, 26, "boxing day")]
        public void TestHolidays2017(int month, int day, string name)
        {
            var holiday = new DateTime(2017, month, day);
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        public void TestHolidays2017Lists()
        {
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2017);
            var holNames = holidayCalendar.PublicHolidayNames(2017);
            Assert.IsTrue(12 == hols.Count, "Should be 12 holidays in 2017");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }


        [TestMethod]
        [DataRow(3, 22, "Human Rights Day - Observed on Monday")]
        [DataRow(4, 2, "Good Friday")]
        [DataRow(4, 5, "Family Day")]
        [DataRow(4, 27, "Freedom Day")]
        [DataRow(5, 1, "Workers' Day")]
        [DataRow(6, 16, "Youth Day")]
        [DataRow(8, 9, "National Women's Day")]
        [DataRow(9, 24, "Heritage Day")]
        [DataRow(12, 16, "Day of reconciliation")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 27, "Boxing day - Observed on Monday")]
        public void TestHolidays2021(int month, int day, string name)
        {
            var holiday = new DateTime(2021, month, day);
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        public void TestHolidays2021Lists()
        {
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2021);
            var holNames = holidayCalendar.PublicHolidayNames(2021);
            Assert.IsTrue(12 == hols.Count, "Should be 12 holidays in 2021");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestChristmasAndBoxingDay2021()
        {
            var christmasDay = SouthAfricaPublicHoliday.Christmas(2021);
            var boxingDay = SouthAfricaPublicHoliday.BoxingDay(2021);

            Assert.AreNotEqual(new DateTime(2021, 12, 26), christmasDay, "Christmas day cannot move to Monday because Boxing day falls on Monday ");
            Assert.AreEqual(new DateTime(2021, 12, 27), boxingDay, "Boxing day should be observed on Monday 27 Dec 2021");
        }

        [TestMethod]
        [DataRow(3, 21, "Human Rights Day")]
        [DataRow(4, 15, "Good Friday")]
        [DataRow(4, 18, "Family Day")]
        [DataRow(4, 27, "Freedom Day")]
        [DataRow(5, 2, "Workers' Day - Observed on Monday")]
        [DataRow(6, 16, "Youth Day")]
        [DataRow(8, 9, "National Women's Day")]
        [DataRow(9, 24, "Heritage Day")]
        [DataRow(12, 16, "Day of reconciliation")]
        [DataRow(12, 26, "Christmas")]
        [DataRow(12, 27, "Boxing day")]
        public void TestHolidays2022(int month, int day, string name)
        {
            var holiday = new DateTime(2022, month, day);
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        public void TestHolidays2022Lists()
        {
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2022);
            var holNames = holidayCalendar.PublicHolidayNames(2022);
            Assert.IsTrue(12 == hols.Count, "Should be 12 holidays in 2022");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestChristmasAndBoxingDay2022()
        {
            var christmasDay = SouthAfricaPublicHoliday.Christmas(2022);
            var boxingDay = SouthAfricaPublicHoliday.BoxingDay(2022);

            Assert.AreEqual(new DateTime(2022, 12, 26), christmasDay, "Christmas day moved to Monday for 2022 as per presidential announcement");
            Assert.AreEqual(new DateTime(2022, 12, 27), boxingDay, "Boxing day should be observed on Tuesday 27 Dec 2022 as per presidential announcement");
        }



        [TestMethod]
        [DataRow(1, 2, "New Years Day - Observed on Monday")]
        [DataRow(3, 21, "Human Rights Day")]
        [DataRow(4, 7, "Good Friday")]
        [DataRow(4, 10, "Family Day")]
        [DataRow(4, 27, "Freedom Day")]
        [DataRow(5, 1, "Workers' Day")]
        [DataRow(6, 16, "Youth Day")]
        [DataRow(8, 9, "National Women's Day")]
        [DataRow(9, 25, "Heritage Day - Observed on Monday")]
        [DataRow(12, 15, "Rugby World Cup Win Public Holiday")]
        [DataRow(12, 16, "Day of reconciliation")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 26, "Boxing day")]
        public void TestHolidays2023(int month, int day, string name)
        {
            var holiday = new DateTime(2023, month, day);
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }

        [TestMethod]
        [DataRow(1, 1, "New Years Day")]
        [DataRow(3, 21, "Human Rights Day")]
        [DataRow(3, 29, "Good Friday")]
        [DataRow(4, 1, "Family Day")]
        [DataRow(4, 27, "Freedom Day")]
        [DataRow(5, 1, "Workers' Day")]
        [DataRow(5, 29, "Election Day")]
        [DataRow(6, 17, "Youth Day - Observed on Monday")]
        [DataRow(8, 9, "National Women's Day")]
        [DataRow(9, 24, "Heritage Day")]
        [DataRow(12, 16, "Day of reconciliation")]
        [DataRow(12, 25, "Christmas")]
        [DataRow(12, 26, "Boxing day")]
        public void TestHolidays2024(int month, int day, string name)
        {
            var x = SouthAfricaPublicHoliday.GoodFriday(2024);
            var holiday = new DateTime(2024, month, day);
            var holidayCalendar = new SouthAfricaPublicHoliday();
            var actual = holidayCalendar.IsPublicHoliday(holiday);
            Assert.IsTrue(actual, $"{holiday.ToString("D")} is not a holiday -{name}");
        }
    }
}
