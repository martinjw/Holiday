using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Lithuania;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays in Lithuania.
    /// Sources used:
    ///  * https://en.wikipedia.org/wiki/Public_holidays_in_Lithuania
    /// </summary>
    public class LithuaniaPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Lithuanian.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("lt-LT", "lt");
        #region Individual Holidays
        /// <summary>
        /// Motinos diena - Mother's Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime MothersDay(int year)
        {
            var hol = new DateTime(year, 5, 1);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Sunday, 1);
            return hol;
        }

        /// <summary>
        /// Tėvo diena - Father's Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime FathersDay(int year)
        {
            var hol = new DateTime(year, 6, 1);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Sunday, 1);
            return hol;
        }

        /// <summary>
        /// Šv. Velykos - Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Easter(int year)
        {
            var hol = EasterCalculator.GetEaster(year);
            return hol;
        }

        /// <summary>
        /// Antroji šv. Velykų diena - Easter Monday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        #endregion

        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Local.RestorationOfStateDay(),
            new Local.RestorationOfIndependenceDay(),
            new Christian.EasterSunday(),
            new Christian.EasterMonday(),
            new Common.LabourDay(),
            new Local.MothersDay(),
            new Local.FathersDay(),
            new Local.StJohnsDay(),
            new Local.StatehoodDay(),
            new Christian.Assumption { AppliesInYear = AssumptionFrom2000 },
            new Christian.AllSaints(),
            new Local.AllSoulsDay(),
            new Christian.ChristmasEve(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
        };

        private static bool AssumptionFrom2000(int year)
        {
            return year >= 2000;
        }

        /// <summary>
        /// All Lithuanian public holidays for the year (names in Lithuanian). Where Mother's Day
        /// falls on Labour Day both names are shown on the day (aggregated by the base class).
        /// </summary>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }
    }
}
