using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Poland
    /// </summary>
    public class PolandPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// New Year's Day (1st January)
        /// </summary>
        public static DateTime NewYear(int year) => new DateTime(year, 1, 1);

        /// <summary>
        /// Epiphany (6th January)
        /// </summary>
        public static DateTime Epiphany(int year) => new DateTime(year, 1, 6);

        /// <summary>
        /// Easter Sunday (calculated dynamically)
        /// </summary>
        public static DateTime EasterSunday(int year) => HolidayCalculator.GetEaster(year);

        /// <summary>
        /// Easter Monday (day after Easter Sunday)
        /// </summary>
        public static DateTime EasterMonday(int year) => EasterSunday(year).AddDays(1);

        /// <summary>
        /// Labour Day (1st May)
        /// </summary>
        public static DateTime LabourDay(int year) => new DateTime(year, 5, 1);

        /// <summary>
        /// Constitution Day (3rd May)
        /// </summary>
        public static DateTime ConstitutionDay(int year) => new DateTime(year, 5, 3);

        /// <summary>
        /// Pentecost (49 days after Easter Sunday)
        /// </summary>
        public static DateTime Pentecost(int year) => EasterSunday(year).AddDays(49);

        /// <summary>
        /// Corpus Christi (60 days after Easter Sunday)
        /// </summary>
        public static DateTime CorpusChristi(int year) => EasterSunday(year).AddDays(60);

        /// <summary>
        /// Assumption of Mary (15th August)
        /// </summary>
        public static DateTime Assumption(int year) => new DateTime(year, 8, 15);

        /// <summary>
        /// All Saints (1st November)
        /// </summary>
        public static DateTime AllSaints(int year) => new DateTime(year, 11, 1);

        /// <summary>
        /// Independence Day (11th November)
        /// </summary>
        public static DateTime IndependenceDay(int year) => new DateTime(year, 11, 11);

        /// <summary>
        /// Christmas Eve (24th December) - public holiday from 2025 onwards
        /// </summary>
        public static DateTime? ChristmasEve(int year)
        {
            if (year >= 2025) return new DateTime(year, 12, 24);
            return null;
        }

        /// <summary>
        /// Christmas Day (25th December)
        /// </summary>
        public static DateTime Christmas(int year) => new DateTime(year, 12, 25);

        /// <summary>
        /// St. Stephen's Day (26th December)
        /// </summary>
        public static DateTime StStephen(int year) => new DateTime(year, 12, 26);

        #endregion

        #region Public Holiday List

        /// <summary>
        /// Get a list of all public holidays in a given year.
        /// </summary>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Select(x => x.Key).OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Get a dictionary of public holidays with their names in English.
        /// </summary>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var holidays = new Dictionary<DateTime, string>
            {
                { NewYear(year), "New Year" },
                { Epiphany(year), "Epiphany" },
                { EasterSunday(year), "Easter Sunday" },
                { EasterMonday(year), "Easter Monday" },
                { LabourDay(year), "Labour Day" },
                { ConstitutionDay(year), "Constitution Day" },
                { Pentecost(year), "Pentecost" },
                { CorpusChristi(year), "Corpus Christi" },
                { Assumption(year), "Assumption" },
                { AllSaints(year), "All Saints" },
                { IndependenceDay(year), "Independence Day" }
            };

            var christmasEve = ChristmasEve(year);
            if (christmasEve.HasValue)
            {
                holidays.Add(christmasEve.Value, "Christmas Eve");
            }

            holidays.Add(Christmas(year), "Christmas");
            holidays.Add(StStephen(year), "St Stephen's Day");

            return holidays;
        }

        #endregion

        #region Public Holiday Check

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        public override bool IsPublicHoliday(DateTime date)
        {
            return PublicHolidays(date.Year).Contains(date.Date);
        }

        #endregion
    }
}
