using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.USA;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Federal Reserve Holidays in the US
    /// <br />
    /// If a holiday falls on a Saturday the Federal Reserve is open the preceding Friday, this differs from how <see cref="USAPublicHoliday"></see> treats Fridays preceding a Saturday holiday.
    /// <br />
    /// If a holiday falls on a Sunday the Federal Reserve is closed following Monday.
    /// https://www.federalreserve.gov/aboutthefed/k8.htm
    /// </summary>
    public class USAFederalReserveHoliday : PublicHolidayBase
    {
        #region Holiday Adjustments
        private static DateTime FixWeekend(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            return hol;
        }
        #endregion

        #region Individual Holidays

        /// <summary>
        /// New Years Day. Note in 1999 and 2005 it was 31st December
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday NewYear(int year)
        {
            var holiday = new DateTime(year, 1, 1);
            return new Holiday(holiday, FixWeekend(holiday), HolidayKeys.NewYear);
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
            var observed = FixWeekend(hol);
            return new Holiday(hol, observed, HolidayKeys.Juneteenth);
        }

        /// <summary>
        /// Independence Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static Holiday IndependenceDay(int year)
        {
            var hol = new DateTime(year, 7, 4);
            var observed = FixWeekend(hol);
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
            return new Holiday(hol, FixWeekend(hol), HolidayKeys.VeteransDay);
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
            return new Holiday(hol, FixWeekend(hol), HolidayKeys.Christmas);
        }
        #endregion

        /// <summary>
        /// Gets a list of public holidays with their observed and actual date
        /// </summary>
        //Federal Reserve weekend rule: only a Sunday holiday shifts (to Monday);
        //Saturday holidays are not observed on another day
        private static readonly HolidayDefinition[] Definitions =
        {
            new Local.NewYearsDay(HolidayCalculator.FixWeekendSundayAfter),
            new Local.MartinLutherKingDay(),
            new Local.PresidentsDay(),
            new Local.MemorialDay(),
            new Local.Juneteenth(HolidayCalculator.FixWeekendSundayAfter),
            new Local.IndependenceDay(HolidayCalculator.FixWeekendSundayAfter),
            new Local.LaborDay(),
            new Local.ColumbusDay(),
            new Local.VeteransDay(HolidayCalculator.FixWeekendSundayAfter),
            new Local.Thanksgiving(),
            new Local.ChristmasDay(HolidayCalculator.FixWeekendSundayAfter),
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
