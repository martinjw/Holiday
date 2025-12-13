using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHolidayTests
{
    [TestClass]
    public class TestPortugalPublicHoliday
    {
        [TestMethod]
        [DataRow(PortugalPublicHoliday.Regions.OnlyOfficial)]
        [DataRow(PortugalPublicHoliday.Regions.Acores)]
        [DataRow(PortugalPublicHoliday.Regions.Madeira)]
        public void NamesMatch(PortugalPublicHoliday.Regions region)
        {
            var portugalPublicHoliday = new PortugalPublicHoliday();
            var holidayNames = portugalPublicHoliday.PublicHolidayNames(2024);
            var allHolidays = portugalPublicHoliday.PublicHolidaysInformation(2024);
            foreach (var name in holidayNames)
            {
                var holidayName = allHolidays.SingleOrDefault(x => x.HolidayDate == name.Key)?.Name;
                Assert.AreEqual(name.Value, holidayName);
            }
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var isPublicHoliday = new PortugalPublicHoliday().IsPublicHoliday(new DateTime(2024, 5, 30));

            Assert.IsTrue(isPublicHoliday, "Thursday 30th May 2024 is Corpo de Deus");
        }

        [TestMethod]
        public void TestIsNotPublicHoliday()
        {
            var isPublicHoliday = new PortugalPublicHoliday().IsPublicHoliday(new DateTime(2024, 5, 29));

            Assert.IsFalse(isPublicHoliday, "Wednesday 29th May 2024 is not a holiday");
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var result = new PortugalPublicHoliday().NextWorkingDay(new DateTime(2024, 05, 30));
            Assert.AreEqual(new DateTime(2024, 05, 31), result);
        }

        [TestMethod]
        public void TestPublicHolidays()
        {
            var corpusChristi = new DateTime(2024, 05, 30);
            var result = new PortugalPublicHoliday().PublicHolidayNames(2024);
            Assert.AreEqual(14, result.Count);
            Assert.IsTrue(result.ContainsKey(corpusChristi));
        }

        [TestMethod]
        public void TestPublicHolidaysInformationCount2024()
        {
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);
            Assert.AreEqual(17, hols.Count, "Should be 17 holidays");
        }


        [TestMethod]
        public void TestOnlyPublicHolidaysInformationCount2024()
        {
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            int counter = 0;
            foreach (var h in hols)
            {
                if (h.IsPublic) counter++;
            }

            Assert.AreEqual(14, counter, "Should be 14");
        }


        [TestMethod]
        public void TestHolidays2024()
        {
            var holidayCalendar = new PortugalPublicHoliday();
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.AreEqual(14, hols.Count, "Should be 14 holidays");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidays2024Acores()
        {
            var holidayCalendar = new PortugalPublicHoliday { Region = PortugalPublicHoliday.Regions.Acores };
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.AreEqual(15, hols.Count, "Should be 15 holidays");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        [TestMethod]
        public void TestHolidays2024Madeira()
        {
            var holidayCalendar = new PortugalPublicHoliday { Region = PortugalPublicHoliday.Regions.Madeira };
            var hols = holidayCalendar.PublicHolidays(2024);
            var holNames = holidayCalendar.PublicHolidayNames(2024);
            Assert.AreEqual(16, hols.Count, "Should be 16 holidays");
            Assert.IsTrue(holNames.Count == hols.Count, "Names and holiday list are same");
        }

        #region Holidays



        [TestMethod]
        public void TestPublicHolidaysInformationNewYear2024()
        {
            var date = PortugalPublicHoliday.NewYear(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "NewYear should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 1, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationCarnival2024()
        {
            var date = PortugalPublicHoliday.Carnival(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Carnival should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 2, 13));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationGoodFriday2024()
        {
            var date = PortugalPublicHoliday.GoodFriday(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "GoodFriday should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 3, 29));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationEaster2024()
        {
            var date = PortugalPublicHoliday.Easter(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Easter should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 3, 31));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationFreedomDay2024()
        {
            var date = PortugalPublicHoliday.FreedomDay(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "FreedomDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 4, 25));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationLabourDay2024()
        {
            var date = PortugalPublicHoliday.LabourDay(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "LabourDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 5, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAzoresDay2024()
        {
            var date = PortugalPublicHoliday.AzoresDay(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "AzoresDay should be reported in the complete list of holidays");

            Assert.IsFalse(holiday.IsPublic, "Holiday should not be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 5, 20));
            Assert.AreEqual(holiday.Regions.Single(), "Açores");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationCorpusChristi2024()
        {
            var date = PortugalPublicHoliday.CorpusChristi(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "CorpusChristi should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 5, 30));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationMadeiraAutonomyDay2024()
        {
            var date = PortugalPublicHoliday.MadeiraAutonomyDay(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "MadeiraAutonomyDay should be reported in the complete list of holidays");

            Assert.IsFalse(holiday.IsPublic, "Holiday should not be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 7, 1));
            Assert.AreEqual(holiday.Regions.Single(), "Madeira");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationPortugalDay2024()
        {
            var date = PortugalPublicHoliday.PortugalDay(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "PortugalDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 6, 10));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAssumption2024()
        {
            var date = PortugalPublicHoliday.Assumption(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Assumption should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 8, 15));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationRepublicDay2024()
        {
            var date = PortugalPublicHoliday.RepublicDay(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "RepublicDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 10, 5));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAllSaints2024()
        {
            var date = PortugalPublicHoliday.AllSaints(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "AllSaints should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 11, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationIndependenceRestorationDay2024()
        {
            var date = PortugalPublicHoliday.IndependenceRestorationDay(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "IndependenceRestorationDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 12, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationImmaculateConception2024()
        {
            var date = PortugalPublicHoliday.ImmaculateConception(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "ImmaculateConception should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 12, 8));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationChristmas2024()
        {
            var date = PortugalPublicHoliday.Christmas(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Christmas should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 12, 25));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationFirstOctaveDay2024()
        {
            var date = PortugalPublicHoliday.FirstOctaveDay(2024);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2024);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "FirstOctaveDay should be reported in the complete list of holidays");

            Assert.IsFalse(holiday.IsPublic, "Holiday should not be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2024, 12, 26));
            Assert.AreEqual(holiday.Regions.Single(), "Madeira");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationNewYear2025()
        {
            var date = PortugalPublicHoliday.NewYear(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "NewYear should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 1, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationCarnival2025()
        {
            var date = PortugalPublicHoliday.Carnival(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Carnival should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 3, 4));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationGoodFriday2025()
        {
            var date = PortugalPublicHoliday.GoodFriday(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "GoodFriday should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 4, 18));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationEaster2025()
        {
            var date = PortugalPublicHoliday.Easter(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Easter should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 4, 20));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationFreedomDay2025()
        {
            var date = PortugalPublicHoliday.FreedomDay(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "FreedomDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 4, 25));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationLabourDay2025()
        {
            var date = PortugalPublicHoliday.LabourDay(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "LabourDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 5, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAzoresDay2025()
        {
            var date = PortugalPublicHoliday.AzoresDay(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "AzoresDay should be reported in the complete list of holidays");

            Assert.IsFalse(holiday.IsPublic, "Holiday should not be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 6, 9));
            Assert.AreEqual(holiday.Regions.Single(), "Açores");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationCorpusChristi2025()
        {
            var date = PortugalPublicHoliday.CorpusChristi(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "CorpusChristi should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 6, 19));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationMadeiraAutonomyDay2025()
        {
            var date = PortugalPublicHoliday.MadeiraAutonomyDay(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "MadeiraAutonomyDay should be reported in the complete list of holidays");

            Assert.IsFalse(holiday.IsPublic, "Holiday should not be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 7, 1));
            Assert.AreEqual(holiday.Regions.Single(), "Madeira");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationPortugalDay2025()
        {
            var date = PortugalPublicHoliday.PortugalDay(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "PortugalDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 6, 10));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAssumption2025()
        {
            var date = PortugalPublicHoliday.Assumption(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Assumption should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 8, 15));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationRepublicDay2025()
        {
            var date = PortugalPublicHoliday.RepublicDay(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "RepublicDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 10, 5));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAllSaints2025()
        {
            var date = PortugalPublicHoliday.AllSaints(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "AllSaints should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 11, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationIndependenceRestorationDay2025()
        {
            var date = PortugalPublicHoliday.IndependenceRestorationDay(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "IndependenceRestorationDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 12, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationImmaculateConception2025()
        {
            var date = PortugalPublicHoliday.ImmaculateConception(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "ImmaculateConception should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 12, 8));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationChristmas2025()
        {
            var date = PortugalPublicHoliday.Christmas(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Christmas should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 12, 25));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationFirstOctaveDay2025()
        {
            var date = PortugalPublicHoliday.FirstOctaveDay(2025);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2025);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "FirstOctaveDay should be reported in the complete list of holidays");

            Assert.IsFalse(holiday.IsPublic, "Holiday should not be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2025, 12, 26));
            Assert.AreEqual(holiday.Regions.Single(), "Madeira");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationNewYear2026()
        {
            var date = PortugalPublicHoliday.NewYear(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "NewYear should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 1, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationCarnival2026()
        {
            var date = PortugalPublicHoliday.Carnival(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Carnival should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 2, 17));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationGoodFriday2026()
        {
            var date = PortugalPublicHoliday.GoodFriday(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "GoodFriday should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 4, 3));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationEaster2026()
        {
            var date = PortugalPublicHoliday.Easter(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Easter should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 4, 5));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationFreedomDay2026()
        {
            var date = PortugalPublicHoliday.FreedomDay(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "FreedomDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 4, 25));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationLabourDay2026()
        {
            var date = PortugalPublicHoliday.LabourDay(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "LabourDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 5, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAzoresDay2026()
        {
            var date = PortugalPublicHoliday.AzoresDay(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "AzoresDay should be reported in the complete list of holidays");

            Assert.IsFalse(holiday.IsPublic, "Holiday should not be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 5, 25));
            Assert.AreEqual(holiday.Regions.Single(), "Açores");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationCorpusChristi2026()
        {
            var date = PortugalPublicHoliday.CorpusChristi(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "CorpusChristi should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 6, 4));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationMadeiraAutonomyDay2026()
        {
            var date = PortugalPublicHoliday.MadeiraAutonomyDay(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "MadeiraAutonomyDay should be reported in the complete list of holidays");

            Assert.IsFalse(holiday.IsPublic, "Holiday should not be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 7, 1));
            Assert.AreEqual(holiday.Regions.Single(), "Madeira");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationPortugalDay2026()
        {
            var date = PortugalPublicHoliday.PortugalDay(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "PortugalDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 6, 10));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAssumption2026()
        {
            var date = PortugalPublicHoliday.Assumption(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Assumption should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 8, 15));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationRepublicDay2026()
        {
            var date = PortugalPublicHoliday.RepublicDay(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "RepublicDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 10, 5));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationAllSaints2026()
        {
            var date = PortugalPublicHoliday.AllSaints(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "AllSaints should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 11, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationIndependenceRestorationDay2026()
        {
            var date = PortugalPublicHoliday.IndependenceRestorationDay(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "IndependenceRestorationDay should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 12, 1));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationImmaculateConception2026()
        {
            var date = PortugalPublicHoliday.ImmaculateConception(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "ImmaculateConception should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 12, 8));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationChristmas2026()
        {
            var date = PortugalPublicHoliday.Christmas(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "Christmas should be reported in the complete list of holidays");

            Assert.IsTrue(holiday.IsPublic, "Holiday should be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 12, 25));
            Assert.IsNull(holiday.Regions, "Regions should be null");
        }

        [TestMethod]
        public void TestPublicHolidaysInformationFirstOctaveDay2026()
        {
            var date = PortugalPublicHoliday.FirstOctaveDay(2026);
            var holidayCalendar = new PortugalPublicHoliday();
            IList<Holiday> hols = holidayCalendar.PublicHolidaysInformation(2026);

            var holiday = hols.SingleOrDefault(h => h.HolidayDate == date);
            Assert.IsNotNull(holiday, "FirstOctaveDay should be reported in the complete list of holidays");

            Assert.IsFalse(holiday.IsPublic, "Holiday should not be public");
            Assert.AreEqual(holiday.HolidayDate, new DateTime(2026, 12, 26));
            Assert.AreEqual(holiday.Regions.Single(), "Madeira");
        }

        #endregion
    }
}
