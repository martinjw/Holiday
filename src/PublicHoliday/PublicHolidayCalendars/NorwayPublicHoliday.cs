using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Norway;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Norway
    /// </summary>
    /// <seealso cref="PublicHolidayBase" />
    public class NorwayPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Norwegian Bokmal.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("nb-NO", "no");

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
        /// Maundy Thursday - Thursday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime MaundyThursday(int year)
        {
            return EasterCalculator.MaundyThursday(EasterCalculator.GetEaster(year));
        }

        private static DateTime MaundyThursday(DateTime easter)
        {
            return EasterCalculator.MaundyThursday(easter);
        }

        /// <summary>
        /// Good Friday - Friday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
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
            return EasterCalculator.GetEaster(year);
        }

        /// <summary>
        /// Easter Monday 1st Monday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return EasterCalculator.EasterMonday(easter);
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
        /// Constitution Day - Mai 17th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ConstitutionDay(int year)
        {
            return new DateTime(year, 5, 17);
        }

        /// <summary>
        /// Ascension 6th Thursday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Ascension(int year)
        {
            return EasterCalculator.AscensionDay(EasterCalculator.GetEaster(year));
        }

        private static DateTime Ascension(DateTime easter)
        {
            return EasterCalculator.AscensionDay(easter);
        }

        /// <summary>
        /// Whit Monday - 7th Sunday after Easter
        /// </summary>
        public static DateTime WhitSunday(int year)
        {
            return EasterCalculator.WhitSunday(EasterCalculator.GetEaster(year));
        }

        private static DateTime WhitSunday(DateTime easter)
        {
            return EasterCalculator.WhitSunday(easter);
        }

        /// <summary>
        /// Whit Monday - 7th Monday after Easter
        /// </summary>
        public static DateTime WhitMonday(int year)
        {
            return EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));
        }

        private static DateTime WhitMonday(DateTime easter)
        {
            return EasterCalculator.WhitMonday(easter);
        }

        /// <summary>
        /// Christmas - December 25
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Boxing Day - December 26
        /// </summary>
        public static DateTime BoxingDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion

        /// <summary>
        /// All Norwegian public holidays for the year (names in Norwegian).
        /// </summary>
        //Ascension/Whit Sunday/Whit Monday can fall on Constitution Day (17 May, e.g. 2012);
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.MaundyThursday(),
            new Christian.GoodFriday(),
            new Christian.EasterSunday(),
            new Christian.EasterMonday(),
            new Common.LabourDay(),
            new Local.ConstitutionDay(),
            new Christian.Ascension(),
            new Christian.WhitSunday(),
            new Christian.WhitMonday(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
        };

        /// <summary>
        /// All Norwegian public holidays for the year (names in Norwegian).
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
