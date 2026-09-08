using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Serbia;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Serbia
    /// Taken from official government page https://neradni-dani.com/kalendar-2023-srb.php
    /// </summary>
    /// <seealso cref="PublicHolidayBase" />
    public class SerbianPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Serbian (Cyrillic script).
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("sr-Cyrl-RS", "sr");
        #region Individual Holidays

        /// <summary>
        /// New Year's Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearFirst(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// New Year's Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearSecond(int year)
        {
            return new DateTime(year, 1, 2);
        }

        /// <summary>
        /// Christmas.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 1, 7);
        }

        /// <summary>
        /// National Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDayFirst(int year)
        {
            return new DateTime(year, 2, 15);
        }
        
        /// <summary>
        /// National Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDaySecond(int year)
        {
            return new DateTime(year, 2, 16);
        }
        
        /// <summary>
        /// Good Friday - Friday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetOrthodoxEaster(year));
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return EasterCalculator.GoodFriday(easter);
        }

        /// <summary>
        /// Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Easter(int year)
        {
            return EasterCalculator.GetOrthodoxEaster(year);
        }

        /// <summary>
        /// Easter Monday 1st Monday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetOrthodoxEaster(year));
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return EasterCalculator.EasterMonday(easter);
        }
        
        /// <summary>
        /// Labor Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDayFirst(int year)
        {
            return new DateTime(year, 5, 1);
        }
        
        /// <summary>
        /// Labour Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDaySecond(int year)
        {
            return new DateTime(year, 5, 2);
        }

        /// <summary>
        /// Armistice Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ArmisticeDay(int year)
        {
            return new DateTime(year, 11, 11);
        }
        
        #endregion
        
        /// <summary>
        /// All Serbian public holidays for the year (Orthodox Easter; names in Serbian).
        /// </summary>
        //Orthodox Easter days can fall on a fixed holiday (e.g. Labour Day);
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Common.DayAfterNewYear(),
            new Christian.OrthodoxChristmas(),
            new Local.StatehoodDay(),
            new Local.StatehoodDaySecond(),
            new Christian.GoodFriday { Orthodox = true },
            new Christian.EasterSunday { Orthodox = true },
            new Christian.EasterMonday { Orthodox = true },
            new Common.LabourDay(),
            new Common.DayAfterLabourDay { HolidayKey = HolidayKeys.LabourDaySecondRS },
            new Common.Armistice(),
        };

        /// <summary>
        /// All Serbian public holidays for the year.
        /// </summary>
        /// <param name="year">The year.</param>
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