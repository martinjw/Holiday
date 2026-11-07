using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.USA;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Federal Holidays in the US
    /// If a holiday falls on a Saturday it is celebrated the preceding Friday;
    /// if a holiday falls on a Sunday it is celebrated the following Monday.
    /// </summary>
    /// <remarks>
    /// Holiday lists are cached per instance/year automatically - no action needed.
    /// </remarks>
    public class USAPublicHoliday : PublicHolidayBase
    {

        #region Individual Holidays

        /// <summary>
        /// New Years Day. Note in 1999 and 2005 it was 31st December
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday NewYear(int year)
        {
            var holiday = new DateTime(year, 1, 1);
            return new Holiday(holiday, HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(holiday), HolidayKeys.NewYear);
        }

        /// <summary>
        /// Third Monday in January
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday MartinLutherKing(int year)
        {
            var hol = new DateTime(year, 1, 15);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, HolidayKeys.MartinLutherKing);
        }

        /// <summary>
        /// Washington's Birthday aka Presidents Day. Third Monday in February
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday PresidentsDay(int year)
        {
            var hol = new DateTime(year, 2, 15);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, HolidayKeys.PresidentsDay);
        }

        /// <summary>
        /// Last Monday in May
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday MemorialDay(int year)
        {
            var hol = new DateTime(year, 5, 25);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, HolidayKeys.MemorialDay);
        }

        /// <summary>
        /// 19th June
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday Juneteenth(int year)
        {
            var hol = new DateTime(year, 6, 19);
            var observed = HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(hol);
            return new Holiday(hol, observed, HolidayKeys.Juneteenth);
        }

        /// <summary>
        /// Independence Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday IndependenceDay(int year)
        {
            var hol = new DateTime(year, 7, 4);
            var observed = HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(hol);
            return new Holiday(hol, observed, HolidayKeys.IndependenceDay);
        }

        /// <summary>
        /// First Monday in September
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday LaborDay(int year)
        {
            var hol = new DateTime(year, 9, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, HolidayKeys.LaborDay);
        }

        /// <summary>
        /// Second Monday in October
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday ColumbusDay(int year)
        {
            var hol = new DateTime(year, 10, 8);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, HolidayKeys.ColumbusDay);
        }

        /// <summary>
        /// 11 November
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday VeteransDay(int year)
        {
            var hol = new DateTime(year, 11, 11);
            return new Holiday(hol, HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(hol), HolidayKeys.VeteransDay);
        }

        /// <summary>
        /// Thanksgiving - Fourth Thursday in November
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday Thanksgiving(int year)
        {
            var hol = new DateTime(year, 11, 22);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Thursday, 1);
            return new Holiday(hol, hol, HolidayKeys.Thanksgiving);
        }

        /// <summary>
        /// Christmas Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday Christmas(int year)
        {
            var hol = new DateTime(year, 12, 25);
            return new Holiday(hol, HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(hol), HolidayKeys.Christmas);
        }
        #endregion

        //federal weekend rule: Saturday observed the Friday before, Sunday the Monday after
        private static readonly HolidayDefinition[] Definitions =
        {
            new Local.NewYearsDay(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
            new Local.MartinLutherKingDay(),
            new Local.PresidentsDay(),
            new Local.MemorialDay(),
            new Local.Juneteenth(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
            new Local.IndependenceDay(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
            new Local.LaborDay(),
            new Local.ColumbusDay(),
            new Local.VeteransDay(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
            new Local.Thanksgiving(),
            new Local.ChristmasDay(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
            //New Year's Day observed on 31 December of the previous year when 1 January falls
            //on a Saturday (e.g. 2005, 2011, 2022) - belongs to this year's list
            new Local.NewYearSpillover(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
        };

        /// <summary>
        /// Gets a list of public holidays with their observed and actual date
        /// </summary>
        /// <param name="year">The given year</param>
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
