using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Montenegro;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Montenegro
    /// https://www.gov.me/en/documents/927f23a3-db4e-4f65-9f29-ce3c9dde0c90
    /// </summary>
    /// <seealso cref="PublicHolidayBase" />
    public class MontenegroPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Montenegrin (Serbian, Latin script).
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("sr-Latn-ME", "sr");
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
        /// Christmas Eve
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasEve(int year)
        {
            return new DateTime(year, 1, 6);
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
        /// Independence Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependenceDayFirst(int year)
        {
            return new DateTime(year, 5, 21);
        }

        /// <summary>
        /// Independence Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependenceDaySecond(int year)
        {
            return new DateTime(year, 5, 22);
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

        /// <summary>
        /// Easter Monday 1st Monday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetOrthodoxEaster(year));
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
        /// Statehood Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StatehoodDayFirst(int year)
        {
            return new DateTime(year, 7, 13);
        }

        /// <summary>
        /// Statehood Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StatehoodDaySecond(int year)
        {
            return new DateTime(year, 7, 14);
        }

        /// <summary>
        /// Negoshev Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NegoshevDay(int year)
        {
            return new DateTime(year, 11, 13);
        }


        #endregion

        //Orthodox Good Friday/Easter Monday can fall on a fixed holiday;
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Common.DayAfterNewYear(),
            new Christian.OrthodoxChristmasEve(),
            new Christian.OrthodoxChristmas(),
            new Common.LabourDay(),
            new Common.DayAfterLabourDay { HolidayKey = HolidayKeys.LabourDaySecondME },
            new Local.IndependenceDay(),
            new Local.IndependenceDaySecond(),
            new Local.StatehoodDay(),
            new Local.StatehoodDaySecond(),
            new Local.NegoshevDay(),
            new Christian.GoodFriday { Orthodox = true },
            new Christian.EasterMonday { Orthodox = true },
        };

        /// <summary>
        /// All Montenegrin public holidays for the year.
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
