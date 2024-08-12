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
        //https://www.bmi.bund.de/DE/themen/verfassung/staatliche-symbole/nationale-feiertage/nationale-feiertage-node.html
        //1 Jan	Sat	New Year's Day 	National
        //6 Jan	Thu	Epiphany 	BW, BY & ST
        //8 Mar	Tue	International Women's Day 	BE
        //15 Apr	Fri	Good Friday 	National
        //17 Apr	Sun	Easter Sunday 	BB
        //18 Apr	Mon	Easter Monday 	National
        //1 May	Sun	Labour Day 	National
        //26 May	Thu	Ascension Day 	National
        //5 Jun	Sun	Whit Sunday 	BB
        //6 Jun	Mon	Whit Monday 	National
        //16 Jun	Thu	Corpus Christi 	BW, BY, HE, NW, RP, SL, SN & TH
        //15 Aug	Mon	Assumption Day 	BY & SL
        //3 Oct	Mon	Day of German Unity 	National
        //31 Oct	Mon	Reformation Day 	BB, HH, MV, NI, SH, SN, ST & TH
        //1 Nov	Tue	All Saints' Day 	BW, BY, NW, RP & SL
        //16 Nov	Wed	Repentance Day 	SN
        //25 Dec	Sun	Christmas Day 	National
        //26 Dec	Mon	2nd Day of Christmas 	National
        public void TestHolidays2022()
        {
            var nov16 = new DateTime(2022, 11, 16);
            //Saxony
            var holidayCalendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.SN };
            Assert.IsTrue(holidayCalendar.IsPublicHoliday(nov16));
            var list = holidayCalendar.PublicHolidays(2022);
            Assert.IsTrue(list.Contains(nov16), "Repentance Day");
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
            Assert.IsTrue(14 == hols.Count, "Should be 14 holidays in 2017 - 500th anniversary Reformation");
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

        [TestMethod]
        public void TestMecklenburgVorpommernWomansDay()
        {
            var calendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.MV };
            //did not have official holiday in 2022
            Assert.IsFalse(calendar.HasWomensDay(2022));
            Assert.IsFalse(calendar.PublicHolidays(2022).Contains(new DateTime(2022, 3, 8)));
            
            //introduced official holiday in 2023
            Assert.IsTrue(calendar.HasWomensDay(2023));
            Assert.IsTrue(calendar.PublicHolidays(2023).Contains(new DateTime(2023, 3, 8)));
            
            Assert.IsTrue(calendar.HasWomensDay(2024));
            Assert.IsTrue(calendar.PublicHolidays(2024).Contains(new DateTime(2024, 3, 8)));
        }

        [TestMethod]
        public void TestBrandenbugSundayHolidays()
        {
            var calendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.BB };

            // Easter sunday
            Assert.IsTrue(calendar.PublicHolidays(2023).Contains(new DateTime(2023, 4, 9)));

            // Pentecost sunday
            Assert.IsTrue(calendar.PublicHolidays(2023).Contains(new DateTime(2023, 5, 28)));
        }

        [TestMethod]
        public void TestBavariaAssumption()
        {
            var assumption = GermanPublicHoliday.Assumption(2024);
            //assumption is 15/08/2024
            var calendar = new GermanPublicHoliday { State = GermanPublicHoliday.States.BY };
            var isHoliday = calendar.IsPublicHoliday(assumption); //true
            Assert.IsTrue(isHoliday);

            var hasAssumption = calendar.HasAssumption; //true
            Assert.IsTrue(hasAssumption);
            //override the default - it should be false
            calendar.HasAssumption = false;
            isHoliday = calendar.IsPublicHoliday(assumption); //false
            Assert.IsFalse(isHoliday);

        }
    }
}