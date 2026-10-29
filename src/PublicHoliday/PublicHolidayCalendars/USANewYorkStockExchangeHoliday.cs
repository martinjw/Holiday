using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.USA;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Similar to Federal Holidays in the US
    /// If a holiday falls on a Saturday it is celebrated the preceding Friday;
    /// if a holiday falls on a Sunday it is celebrated the following Monday.
    /// https://www.nyse.com/markets/hours-calendars
    /// Note that this may not be historically accurate prior to 2022. 
    /// This only captures what the current holiday set is and may not reflect historical holidays.
    /// </summary>
    /// <remarks>
    /// Holiday lists are cached per instance/year automatically - no action needed.
    /// </remarks>
    public class USANewYorkStockExchangeHoliday : PublicHolidayBase
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
        /// Good Friday (Friday before Easter) Viernes Santo
        /// </summary>
        public static Holiday GoodFriday(int year)
        {
            DateTime hol = EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
            return new Holiday(hol, hol, HolidayKeys.GoodFriday);
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

        /// <summary>
        /// Gets a list of public holidays with their observed and actual date
        /// </summary>
        private static readonly HolidayDefinition[] Definitions =
        {
            new Local.NewYearsDay(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
            new Local.MartinLutherKingDay(),
            new Local.PresidentsDay(),
            new Christian.GoodFriday(),
            new Local.MemorialDay(),
            new Local.Juneteenth(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter, fromYear: 2022),
            new Local.IndependenceDay(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
            new Local.LaborDay(),
            new Local.Thanksgiving(),
            new Local.ChristmasDay(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
            //New Year's Day observed on 31 December of the previous year when 1 January falls on
            //a Saturday - belongs to this year's list
            new Local.NewYearSpillover(HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter),
        };

        /// <summary>
        /// Gets a list of public holidays with their observed and actual date
        /// </summary>
        /// <param name="year">The given year</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var bHols = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                bHols.AddRange(definition.Build(year));
            }

            return bHols;
        }

    }
}
