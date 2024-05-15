using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestFrancePublicHoliday
    {

        [TestMethod]
        public void TestAscension()
        {
            var ascension = FrancePublicHoliday.Ascension(2006);
            Assert.AreEqual(new DateTime(2006, 5, 25), ascension);
        }

        [TestMethod]
        public void TestPentecost()
        {
            var pentecost = FrancePublicHoliday.PentecostMonday(2006);
            Assert.AreEqual(new DateTime(2006, 6, 5), pentecost);
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new FrancePublicHoliday().IsPublicHoliday(new DateTime(2006, 5, 8));

            Assert.IsTrue(isPublicHoliday, "Monday 8th May 2006 is Victory In Europe day");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new FrancePublicHoliday().IsPublicHoliday(new DateTime(2006, 5, 9));

            Assert.IsFalse(isPublicHoliday, "Tuesday 9th May 2006 is not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new FrancePublicHoliday().NextWorkingDay(new DateTime(2006, 05, 25));
            Assert.AreEqual(new DateTime(2006, 05, 26), result);
        }

        [TestMethod]
        public void TestPublicHolidays()
        {
            var ascension = new DateTime(2006, 05, 25);
            var result = new FrancePublicHoliday().PublicHolidayNames(2006);
            Assert.AreEqual(11, result.Count);
            Assert.IsTrue(result.ContainsKey(ascension));
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteCount2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);
            Assert.IsTrue(25 == hols.Count, "Should be 25 holidays");
        }


        [TestMethod]
        public void TestOnlyPublicHolidaysCompleteCount2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            int counter = 0;
            foreach (var h in hols)
            {
               if (h.IsPublic) counter++;
            }

            Assert.IsTrue(counter == 11, "Should be 11");
        }


        [TestMethod]
        public void TestHolidays2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.IsTrue(11 == hols.Count, "Should be 11 holidays");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidays2024Martinique()
        {
            var holidayCalendar = new FrancePublicHoliday { Region = FrancePublicHoliday.Regions.Martinique };
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.IsTrue(14 == hols.Count, "Should be 14 holidays");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteNewYear2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[0].IsPublic == true);
            Assert.IsTrue(hols[0].HolidayDate == new DateTime(2024, 1, 1));
            Assert.IsTrue(hols[0].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteGoodFriday2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[1].IsPublic == false);
            Assert.IsTrue(hols[1].HolidayDate == new DateTime(2024, 3, 29));
            Assert.IsTrue(hols[1].Regions.Length == 4);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteEasterMonday2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[2].IsPublic == true);
            Assert.IsTrue(hols[2].HolidayDate == new DateTime(2024, 4, 1));
            Assert.IsTrue(hols[2].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteMayotteAbolitionSlavery2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[3].IsPublic == false);
            Assert.IsTrue(hols[3].HolidayDate == new DateTime(2024, 4, 27));
            Assert.IsTrue(hols[3].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompletePeterChanel2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[4].IsPublic == false);
            Assert.IsTrue(hols[4].HolidayDate == new DateTime(2024, 4, 28));
            Assert.IsTrue(hols[4].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteLabourDay2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[5].IsPublic == true);
            Assert.IsTrue(hols[5].HolidayDate == new DateTime(2024, 5, 1));
            Assert.IsTrue(hols[5].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteVictoryInEuropeDay2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[6].IsPublic == true);
            Assert.IsTrue(hols[6].HolidayDate == new DateTime(2024, 5, 8));
            Assert.IsTrue(hols[6].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteMartiniqueAbolitionSlavery2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[7].IsPublic == false);
            Assert.IsTrue(hols[7].HolidayDate == new DateTime(2024, 5, 22));
            Assert.IsTrue(hols[7].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteGuadeloupeAbolitionSlavery2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[8].IsPublic == false);
            Assert.IsTrue(hols[8].HolidayDate == new DateTime(2024, 5, 27));
            Assert.IsTrue(hols[8].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteSaintMartinAbolitionSlavery2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[9].IsPublic == false);
            Assert.IsTrue(hols[9].HolidayDate == new DateTime(2024, 5, 28));
            Assert.IsTrue(hols[9].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteAscension2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[10].IsPublic == true);
            Assert.IsTrue(hols[10].HolidayDate == new DateTime(2024, 5, 9));
            Assert.IsTrue(hols[10].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompletePentecostMonday2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[11].IsPublic == true);
            Assert.IsTrue(hols[11].HolidayDate == new DateTime(2024, 5, 20));
            Assert.IsTrue(hols[11].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteGuyaneAbolitionSlavery2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[12].IsPublic == false);
            Assert.IsTrue(hols[12].HolidayDate == new DateTime(2024, 6, 10));
            Assert.IsTrue(hols[12].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteAutonomyDay2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[13].IsPublic == false);
            Assert.IsTrue(hols[13].HolidayDate == new DateTime(2024, 6, 29));
            Assert.IsTrue(hols[13].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteBastilleDay2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[14].IsPublic == true);
            Assert.IsTrue(hols[14].HolidayDate == new DateTime(2024, 7, 14));
            Assert.IsTrue(hols[14].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteVictorSchoelcherDay2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[15].IsPublic == false);
            Assert.IsTrue(hols[15].HolidayDate == new DateTime(2024, 7, 21));
            Assert.IsTrue(hols[15].Regions.Length == 2);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteTerritoryFestivalDay2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[16].IsPublic == false);
            Assert.IsTrue(hols[16].HolidayDate == new DateTime(2024, 7, 29));
            Assert.IsTrue(hols[16].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteAssumption2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[17].IsPublic == true);
            Assert.IsTrue(hols[17].HolidayDate == new DateTime(2024, 8, 15));
            Assert.IsTrue(hols[17].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteCitizenshipDay2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[18].IsPublic == false);
            Assert.IsTrue(hols[18].HolidayDate == new DateTime(2024, 9, 24));
            Assert.IsTrue(hols[18].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteSaintBarthelemyAbolitionSlavery2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[19].IsPublic == false);
            Assert.IsTrue(hols[19].HolidayDate == new DateTime(2024, 10, 9));
            Assert.IsTrue(hols[19].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteAllSaints2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[20].IsPublic == true);
            Assert.IsTrue(hols[20].HolidayDate == new DateTime(2024, 11, 1));
            Assert.IsTrue(hols[20].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteArmistice2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[21].IsPublic == true);
            Assert.IsTrue(hols[21].HolidayDate == new DateTime(2024, 11, 11));
            Assert.IsTrue(hols[21].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteLaReunionAbolitionSlavery2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[22].IsPublic == false);
            Assert.IsTrue(hols[22].HolidayDate == new DateTime(2024, 12, 20));
            Assert.IsTrue(hols[22].Regions.Length == 1);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteChristmas2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[23].IsPublic == true);
            Assert.IsTrue(hols[23].HolidayDate == new DateTime(2024, 12, 25));
            Assert.IsTrue(hols[23].Regions is null);
        }

        [TestMethod]
        public void TestPublicHolidaysCompleteSaintStephenDay2024()
        {
            var holidayCalendar = new FrancePublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysComplete(2024);

            Assert.IsTrue(hols[24].IsPublic == false);
            Assert.IsTrue(hols[24].HolidayDate == new DateTime(2024, 12, 26));
            Assert.IsTrue(hols[24].Regions.Length == 1);
        }
    }
}
