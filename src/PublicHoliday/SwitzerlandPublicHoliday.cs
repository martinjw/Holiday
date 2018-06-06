using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{

    /// <summary>
    /// Switzerland's holiday calendar. Oliver Fritz, May 2018.
    /// </summary>
    public class SwitzerlandPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// New Year's Day January 1
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// January 2, Berchtoldstag
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of this holiday in given year</returns>
        public static DateTime SecondJanuary(int year)
        {
            return new DateTime(year, 1, 2);
        }

        /// <summary>
        /// Epiphany - 13 days after christmas
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Good Friday - Friday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        /// <summary>
        /// Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Easter(int year)
        {
            return HolidayCalculator.GetEaster(year);
        }

        /// <summary>
        /// Easter Monday 1st Monday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return easter.AddDays(1);
        }

        /// <summary>
        /// Labour Day - Mai 1st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Ascension 6th Thursday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Ascension(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(4 + (7 * 5));
            return hol;
        }

        private static DateTime Ascension(DateTime easter)
        {
            return easter.AddDays(4 + (7 * 5));
        }

        /// <summary>
        /// Whit Sunday - 7th Sunday after Easter
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime WhitSunday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(7 * 7);
            return hol;
        }

        private static DateTime WhitSunday(DateTime easter)
        {
            return easter.AddDays(7 * 7);
        }

        /// <summary>
        /// Whit Monday - Monday after Whit Sunday
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime WhitMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(7 * 7 + 1);
            return hol;
        }

        private static DateTime WhitMonday(DateTime easter)
        {
            return easter.AddDays(7 * 7 + 1);
        }

        /// <summary>
        /// Fronleichnam - Corpus Christi
        /// </summary>
        /// <param name="year"></param>
        public static DateTime CorpusChristi(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            //first Thursday after Trinity Sunday (Pentecost + 1 week)
            hol = hol.AddDays((7 * 8) + 4);
            return hol;
        }

        /// <summary>
        /// Fronleichnam - Corpus Christi
        /// </summary>
        /// <param name="easter"></param>
        /// <returns></returns>
        public static DateTime CorpusChristi(DateTime easter)
        {
            return easter.AddDays((7 * 8) + 4);
        }

        /// <summary>
        /// National Day - August 1st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 8, 1);
        }

        /// <summary>
        /// All saints day, day after all saints eve
        /// First saturday after Oct. 31
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime AllSaintsDay(int year)
        {
            return GetAllSaintsDay(year);
        }

        private static DateTime GetAllSaintsDay(int year)
        {
            DateTime dt = new DateTime(year, 10, 31);
            for (int i = 0; i < 7; i++)
            {
                if (dt.AddDays(i).DayOfWeek == DayOfWeek.Saturday)
                    return dt.AddDays(i);
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// Christmas Eve - December 24
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime ChristmasEve(int year)
        {
            return new DateTime(year, 12, 24);
        }

        /// <summary>
        /// Christmas - December 25
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Boxing Day - December 26
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime BoxingDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        /// <summary>
        /// New Years Eve - December 31
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYearsEve(int year)
        {
            return new DateTime(year, 12, 31);
        }

        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Select(x => x.Key).OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Public holiday names in German.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            DateTime easter = HolidayCalculator.GetEaster(year);

            var bHols = new Dictionary<DateTime, string>
            {
                {NewYear(year), "Neujahrstag"},
                {GoodFriday(easter), "Karfreitag"},
                {easter, "Ostern"},
                {EasterMonday(easter), "Ostermontag"},
                {Ascension(easter), "Auffahrt"},
                {WhitSunday(easter), "Pingsten"},
                {WhitMonday(easter), "Pingstmontag"},
                {NationalDay(year), "Bundesfeier"},
                {Christmas(year), "Weihnachten"},
                {BoxingDay(year), "Stephanstag"},
            };
            if (_hasSecondJanuary) bHols.Add(SecondJanuary(year), "Berchtoldstag");
            if (_hasLaborDay) bHols.Add(LabourDay(year), "Tag der Arbeit");
            if (_hasCorpusChristi) bHols.Add(CorpusChristi(easter), "Fronleichnam");
            if (_hasChristmasEve) bHols.Add(ChristmasEve(year), "Heiligabend");
            if (_hasNewYearsEve) bHols.Add(NewYearsEve(year), "Silvester");

            return bHols;
        }


        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the PublicHoliday list is more efficient for repeated checks
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            return PublicHolidays(dt.Year).Contains(dt.Date);
        }


        // For constructor
        private bool _hasSecondJanuary = false;
        private bool _hasLaborDay = false;
        private bool _hasCorpusChristi = false;
        private bool _hasChristmasEve = false;
        private bool _hasNewYearsEve = false;

        /// <summary>
        /// Constructor for two major Swiss variants: 
        /// </summary>
        /// <param name="hasSecondJanuary"></param>
        /// <param name="hasLaborDay"></param>
        /// <param name="hasCorpusChristi"></param>
        /// <param name="hasChristmasEve"></param>
        /// <param name="hasNewYearsEve"></param>
        public SwitzerlandPublicHoliday(
            bool hasSecondJanuary = false,
            bool hasLaborDay = false,
            bool hasCorpusChristi = false,
            bool hasChristmasEve = false,
            bool hasNewYearsEve = false)
        {
            _hasSecondJanuary = hasSecondJanuary;
            _hasLaborDay = hasLaborDay;
            _hasCorpusChristi = hasCorpusChristi;
            _hasChristmasEve = hasChristmasEve;
            _hasNewYearsEve = hasNewYearsEve;
        }
    }
}
