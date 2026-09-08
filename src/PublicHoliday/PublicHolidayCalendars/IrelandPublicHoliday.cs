using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Ireland;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Ireland/Eire
    /// </summary>
    public class IrelandPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Irish.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("ga-IE", "ga");
        #region Individual Holidays

        /// <summary>
        /// Lá Caille - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Imbolc  - Saint Brigid's Day (from 2023)
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime? StBrigid(int year)
        {
            if (year < 2023) return null;
            var firstOfFebruary = new DateTime(year, 2, 1);
            return firstOfFebruary.DayOfWeek == DayOfWeek.Friday
                ? firstOfFebruary
                : HolidayCalculator.FindFirstMonday(new DateTime(year, 2, 1));
        }

        /// <summary>
        /// Lá Fhéile Pádraig - St Patrick's Day March 17
        /// </summary>

        public static DateTime StPatricksDay(int year)
        {
            return new DateTime(year, 3, 17);
        }

        /// <summary>
        /// Luan Cásca - Easter Monday
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
        /// Lá Bealtaine - May Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime MayDay(int year)
        {
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 5, 1));
        }

        /// <summary>
        /// Lá Saoire i mí an Mheithimh - June Holiday
        /// </summary>
        public static DateTime JuneHoliday(int year)
        {
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 6, 1));
        }

        /// <summary>
        /// Lá Saoire i mí Lúnasa - August Holiday
        /// </summary>
        public static DateTime AugustHoliday(int year)
        {
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 8, 1));
        }

        /// <summary>
        /// Lá Saoire i mí Dheireadh Fómhair - October Holiday
        /// </summary>

        public static DateTime OctoberHoliday(int year)
        {
            return HolidayCalculator.FindPrevious(new DateTime(year, 10, 31), DayOfWeek.Monday);
        }

        /// <summary>
        /// Lá Nollag - Christmas
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Lá Fhéile Stiofáin - St Stephen's Day
        /// </summary>
        public static DateTime StStephen(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion Individual Holidays

        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Local.StBrigidsDay(),
            new Christian.StPatricksDay(),
            new Local.Covid19Commemoration(),
            new Christian.EasterMonday(),
            new Local.MayDay(),
            new Local.JuneHoliday(),
            new Local.AugustHoliday(),
            new Local.OctoberHoliday(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
            new Local.Millennium(),
        };

        /// <summary>
        /// All Irish public holidays for the year (names in Irish Gaelic).
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