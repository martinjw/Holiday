using System;
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
            var expected = new DateTime(2006, 4, 17);
            var actual = UKBankHoliday.EasterMonday(2006);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Spring with Golden Jubilee variation
        /// </summary>
        [TestMethod]
        public void TestSpring()
        {
            var expected = new DateTime(2002, 6, 4);
            var actual = UKBankHoliday.Spring(2002);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test May Day
        /// </summary>
        [TestMethod]
        public void TestMayDayPre78()
        {
            var actual = UKBankHoliday.MayDay(1977);
            Assert.IsNull(actual);
        }

        /// <summary>
        /// Test May Day (on Monday)
        /// </summary>
        [TestMethod]
        public void TestMayDayPost78()
        {
            var expected = new DateTime(1978, 5, 1);
            var actual = UKBankHoliday.MayDay(1978);
            Assert.AreEqual(expected, actual.Value);
        }

        /// <summary>
        /// Test May Day (on Tuesday)
        /// </summary>
        [TestMethod]
        public void TestMayDay79()
        {
            var expected = new DateTime(1979, 5, 7);
            var actual = UKBankHoliday.MayDay(1979);
            Assert.AreEqual(expected, actual.Value);
        }

        /// <summary>
        /// Test May Day in 2020 (Moved to the 8th/May)
        /// </summary>
        [TestMethod]
        public void TestMayDay2020()
        {
            var expected = new DateTime(2020, 5, 8);
            var actual = UKBankHoliday.MayDay(2020);
            Assert.AreEqual(expected, actual.Value);
        }

        /// <summary>
        /// Test May Day in 2020 (Moved to the 8th/May)
        /// </summary>
        [TestMethod]
        public void TestMayDay2020IsNotMonday()
        {
            var veDay = UKBankHoliday.MayDay(2020).GetValueOrDefault();
            Assert.IsTrue(new UKBankHoliday().IsBankHoliday(veDay));
        }

        /// <summary>
        /// New Year is a Sunday, so bank holiday is Monday
        /// </summary>
        [TestMethod]
        public void TestWeekendNotHoliday()
        {
            Assert.IsFalse(new UKBankHoliday().IsBankHoliday(new DateTime(2006, 1, 1)));
        }

        /// <summary>
        /// New Year is a Sunday, so bank holiday is Monday
        /// </summary>
        [TestMethod]
        public void TestHolidayInLieu()
        {
            Assert.IsTrue(new UKBankHoliday().IsBankHoliday(new DateTime(2006, 1, 2)));
        }

        /// <summary>
        /// New Year is a Sunday, so bank holiday is Monday and day after is normal day
        /// </summary>
        [TestMethod]
        public void TestAfterHolidayInLieu()
        {
            Assert.IsFalse(new UKBankHoliday().IsBankHoliday(new DateTime(2006, 1, 3)));
        }

        /// <summary>
        /// Sat, no hols
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySat()
        {
            var expected = new DateTime(2006, 12, 18);
            var actual = new UKBankHoliday().NextWorkingDay(new DateTime(2006, 12, 16));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Sun before bhol
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDaySunday()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new UKBankHoliday().NextWorkingDay(new DateTime(2006, 12, 24));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// bhol with another following
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayXmas()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new UKBankHoliday().NextWorkingDay(new DateTime(2006, 12, 25));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayBoxingDay()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new UKBankHoliday().NextWorkingDay(new DateTime(2006, 12, 26));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Working Day after Holiday
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayAfterHoliday()
        {
            var expected = new DateTime(2006, 12, 27);
            var actual = new UKBankHoliday().NextWorkingDay(new DateTime(2006, 12, 27));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Sat before bhol
        /// </summary>
        [TestMethod]
        public void TestNextWorkingDayOverNewYear()
        {
            var expected = new DateTime(2007, 1, 2);
            var actual = new UKBankHoliday().NextWorkingDay(new DateTime(2006, 12, 30));
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// There are 8 bank holidays
        /// </summary>
        [TestMethod]
        public void TestHolidayCount()
        {
            var bankHolidays = UKBankHoliday.BankHolidays(2006);
            Assert.AreEqual(bankHolidays.Count, 8);
        }

        /// <summary>
        /// There are 9 bank holidays in 2002
        /// </summary>
        [TestMethod]
        public void TestHolidayCount2002()
        {
            var bankHolidays = UKBankHoliday.BankHolidays(2002);
            Assert.AreEqual(bankHolidays.Count, 9);
        }

        /// <summary>
        /// There are 7 bank holidays in 1977
        /// </summary>
        [TestMethod]
        public void TestHolidayCount1977()
        {
            var bankHolidays = UKBankHoliday.BankHolidays(1977);
            Assert.AreEqual(bankHolidays.Count, 7);
        }

        [TestMethod]
        public void TestRoyalWedding2011()
        {
            var isWeddingHoliday = new UKBankHoliday().IsBankHoliday(new DateTime(2011, 4, 29));
            Assert.IsTrue(isWeddingHoliday);
        }


        [TestMethod]
        public void TestNextWorkingDayAfterRoyalWedding2011()
        {
            var royalWedding = new DateTime(2011, 4, 29);
            var nextWorkingDay = new UKBankHoliday().NextWorkingDay(royalWedding);
            //next working day is Tuesday 3rd May (Monday 2nd is MayDay)
            var expected = new DateTime(2011, 5, 3);
            Assert.AreEqual(expected, nextWorkingDay);
        }

        [TestMethod]
        public void TestSummer2015()
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

        [TestMethod]
        public void TestSpringLastDayOfMonthIsAMonday()
        {
            var dt = UKBankHoliday.Spring(2021);
            var expected = new DateTime(2021, 5, 31);
            Assert.AreEqual(dt, expected);
        }


        /// <summary>
        /// Sat before bhol
        /// </summary>
        [TestMethod]
        public void TestPreviousWorkingDayOverNewYear()
        {
            var actual = new UKBankHoliday().PreviousWorkingDay(new DateTime(2016, 1, 1)); //Friday
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);

            actual = new UKBankHoliday().PreviousWorkingDay(new DateTime(2016, 1, 2)); //Sat
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);

            actual = new UKBankHoliday().PreviousWorkingDay(new DateTime(2016, 1, 3)); //Sun
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);

            actual = new UKBankHoliday().PreviousWorkingDay(new DateTime(2016, 1, 4)); //Mon
            Assert.AreEqual(new DateTime(2016, 1, 4), actual); //is a working day

            actual = new UKBankHoliday().PreviousWorkingDay(new DateTime(2016, 1, 3, 11, 31, 0, 0)); //Sun with date
            Assert.AreEqual(new DateTime(2015, 12, 31), actual);
        }
    }
}
