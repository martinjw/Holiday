using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Sweden;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Swedish public holidays
    /// </summary>
    public class SwedenPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Swedish.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("sv-SE", "sv");
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
        /// Whit Sunday - 7th Sunday after Easter
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
        /// National Day - June 6th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 6, 6);
        }

        /// <summary>
        /// Midsummer eve, first friday after June 19th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime MidsummerEve(int year)
        {
            return GetMidsummer(year);
        }

        /// <summary>
        /// Midsummer day, day after midsummer eve
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime MidsummerDay(int year)
        {
            return GetMidsummer(year).AddDays(1);
        }

        private static DateTime GetMidsummer(int year)
        {
            DateTime dt = new DateTime(year, 6, 19);
            for (int i = 0; i < 7; i++)
            {
                if (dt.AddDays(i).DayOfWeek == DayOfWeek.Friday)
                    return dt.AddDays(i);
            }
            return DateTime.MinValue;
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
        public static DateTime ChristmasEve(int year)
        {
            return new DateTime(year, 12, 24);
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

        /// <summary>
        /// New Years Eve - December 31
        /// </summary>
        public static DateTime NewYearsEve(int year)
        {
            return new DateTime(year, 12, 31);
        }

        #endregion Individual Holidays

        /// <summary>
        /// All Swedish public holidays for the year (names in Swedish).
        /// </summary>
        //Ascension can fall on May Day (1 May) and Whit Sunday on National Day (6 June);
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.Epiphany(),
            new Christian.GoodFriday(),
            new Christian.EasterSunday(),
            new Christian.EasterMonday(),
            new Common.LabourDay(),
            new Christian.Ascension(),
            new Christian.WhitSunday(),
            new Local.NationalDay(),
            new Local.MidsummerEve(),
            new Local.MidsummerDay(),
            new Local.AllSaintsDay(),
            new Christian.ChristmasEve(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
            new Common.NewYearsEve(),
        };

        /// <summary>
        /// All Swedish public holidays for the year (names in Swedish).
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