using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    /// <summary>
    /// Test the UK Bank Holidays
    /// </summary>
    [TestClass]
    public class TestUKBankHoliday
    {

        /// <summary>
        /// Test Easter
        /// </summary>
        [TestMethod]
        public void TestEasterMonday()
        {
            DateTime expected = new DateTime(2006, 4, 17);
            DateTime actual = UKBankHoliday.EasterMonday(2006);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Spring with Golden Jubilee variation
        /// </summary>
        [TestMethod]
        public void TestSpring()
        {
            DateTime expected = new DateTime(2002, 6, 4);
            DateTime actual = UKBankHoliday.Spring(2002);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test May Day
        /// </summary>
        [TestMethod]
        public void TestMayDayPre78()
        {
            DateTime? actual = UKBankHoliday.MayDay(1977);
            Assert.IsNull(actual);
        }

        /// <summary>
        /// Test May Day (on Monday)
        /// </summary>
        [TestMethod]
        public void TestMayDayPost78()
        {
            DateTime expected = new DateTime(1978, 5, 1);
            DateTime? actual = UKBankHoliday.MayDay(1978);
            Assert.AreEqual(expected, actual.Value);
        }

        /// <summary>
        /// Test May Day (on Tuesday)
        /// </summary>
        [TestMethod]
        public void TestMayDay79()
        {
            DateTime expected = new DateTime(1979, 5, 7);
            DateTime? actual = UKBankHoliday.MayDay(1979);
            Assert.AreEqual(expected, actual.Value);
        }

        /// <summary>
        /// New Year is a Sunday, so bank holiday is Monday
        /// </summary>
        [TestMethod]
        public void TestWeekendNotHoliday()
        {
            Assert.IsFalse(UKBankHoliday.IsBankHoliday(new DateTime(2006, 1, 1)));
        }

        /// <summary>
        /// New Year is a Sunday, so bank holiday is Monday
        /// </summary>
        [TestMethod]
        public void TestHolidayInLieu()
        {
            Assert.IsTrue(UKBankHoliday.IsBankHoliday(new DateTime(2006, 1, 2)));
        }

        /// <summary>
        /// New Year is a Sunday, so bank holiday is Monday and day after is normal day
        /// </summary>
        [TestMethod]
        public void TestAfterHolidayInLieu()
        {
            Assert.IsFalse(UKBankHoliday.IsBankHoliday(new DateTime(2006, 1, 3)));
        }

        /// <summary>
        /// Sat, no hols
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySat()
        {
            DateTime expected = new DateTime(2006, 12, 18);
            DateTime actual = UKBankHoliday.NextWorkingDay(new DateTime(2006, 12, 16));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Sun before bhol
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySunday()
        {
            DateTime expected = new DateTime(2006, 12, 27);
            DateTime actual = UKBankHoliday.NextWorkingDay(new DateTime(2006, 12, 24));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// bhol with another following
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayXmas()
        {
            DateTime expected = new DateTime(2006, 12, 27);
            DateTime actual = UKBankHoliday.NextWorkingDay(new DateTime(2006, 12, 25));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayBoxingDay()
        {
            DateTime expected = new DateTime(2006, 12, 27);
            DateTime actual = UKBankHoliday.NextWorkingDay(new DateTime(2006, 12, 26));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Working Day after Holiday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayAfterHoliday()
        {
            DateTime expected = new DateTime(2006, 12, 27);
            DateTime actual = UKBankHoliday.NextWorkingDay(new DateTime(2006, 12, 27));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Sat before bhol
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayOverNewYear()
        {
            DateTime expected = new DateTime(2007, 1, 2);
            DateTime actual = UKBankHoliday.NextWorkingDay(new DateTime(2006, 12, 30));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// There are 8 bank holidays
        /// </summary>
        [TestMethod]
        public void TestHolidayCount()
        {
            IList<DateTime> bankHolidays = UKBankHoliday.BankHolidays(2006);
            Assert.AreEqual(bankHolidays.Count, 8);
        }

        /// <summary>
        /// There are 9 bank holidays in 2002
        /// </summary>
        [TestMethod]
        public void TestHolidayCount2002()
        {
            IList<DateTime> bankHolidays = UKBankHoliday.BankHolidays(2002);
            Assert.AreEqual(bankHolidays.Count, 9);
        }

        /// <summary>
        /// There are 7 bank holidays in 1977
        /// </summary>
        [TestMethod]
        public void TestHolidayCount1977()
        {
            IList<DateTime> bankHolidays = UKBankHoliday.BankHolidays(1977);
            Assert.AreEqual(bankHolidays.Count, 7);
        }

        [TestMethod]
        public void TestRoyalWedding2011()
        {
            bool isWeddingHoliday = UKBankHoliday.IsBankHoliday(new DateTime(2011, 4, 29));
            Assert.IsTrue(isWeddingHoliday);
        }


        [TestMethod]
        public void TestNextWorkingDayAfterRoyalWedding2011()
        {
            var royalWedding = new DateTime(2011, 4, 29);
            DateTime nextWorkingDay = UKBankHoliday.NextWorkingDay(royalWedding);
            //next working day is Tuesday 3rd May (Monday 2nd is MayDay)
            DateTime expected = new DateTime(2011, 5, 3);
            Assert.AreEqual(expected, nextWorkingDay);
        }

        [TestMethod]
        public void Test2015()
        {
            var dt = UKBankHoliday.Summer(2015);
            Assert.AreEqual(31, dt.Day);
        }

        [TestMethod]
        public void TestBoxingDay2015()
        {
            var dt = UKBankHoliday.BoxingDay(2015);
            Assert.AreEqual(28, dt.Day);
        }
    }
}
