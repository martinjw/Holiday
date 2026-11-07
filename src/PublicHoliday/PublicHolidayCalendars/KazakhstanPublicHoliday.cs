using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Kazakhstan;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Represents holidays in the Kazakhstan
    /// </summary>
    public class KazakhstanPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Russian, the language of this calendar's holiday names.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("ru-KZ", "ru");
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
        /// Day after New Year's Day January 2
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime DayAfterNewYear(int year)
        {
            return new DateTime(year, 1, 2);
        }

        /// <summary>
        /// Christmas January 7
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 1, 7);
        }

        /// <summary>
        /// Womans Day - March 8th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime WomansDay(int year)
        {
            return new DateTime(year, 3, 8);
        }

        /// <summary>
        /// First day of Nauryz - March 21th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NauryzFirstDay(int year)
        {
            return new DateTime(year, 3, 21);
        }

        /// <summary>
        /// First day of Nauryz - March 22th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NauryzSecondDay(int year)
        {
            return new DateTime(year, 3, 22);
        }

        /// <summary>
        /// First day of Nauryz - March 23th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NauryzThirdDay(int year)
        {
            return new DateTime(year, 3, 23);
        }

        /// <summary>
        /// Nation unity Day - Mai 1st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationUnityDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Homeland protector Day - Mai 7st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime HomelandProtectorDay(int year)
        {
            return new DateTime(year, 5, 7);
        }

        /// <summary>
        /// Victory Day - Mai 9st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime VictoryDay(int year)
        {
            return new DateTime(year, 5, 9);
        }

        /// <summary>
        /// Capital Day - July 6th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime CapitalDay(int year)
        {
            return new DateTime(year, 7, 6);
        }

        /// <summary>
        /// Constitution Day - August 30th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ConstitutionDay(int year)
        {
            return new DateTime(year, 8, 30);
        }

        /// <summary>
        /// Kurban Ait - September 1th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime KurbanAitDay(int year)
        {
            return new DateTime(year, 9, 1);
        }

        /// <summary>
        /// First president day - December 1th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime FirstPresidentDay(int year)
        {
            return new DateTime(year, 12, 1);
        }

        /// <summary>
        /// Independence day - December 16th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependenceDay(int year)
        {
            return new DateTime(year, 12, 16);
        }

        /// <summary>
        /// Second day of independence - December 17th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependenceSecondDay(int year)
        {
            return new DateTime(year, 12, 17);
        }

        /// <summary>
        /// All Kazakhstan public holidays for the year (names in Russian).
        /// </summary>
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Common.DayAfterNewYear(),
            new Christian.OrthodoxChristmas(),
            new Common.WomensDay(),
            new Local.NauryzFirstDay(),
            new Local.NauryzSecondDay(),
            new Local.NauryzThirdDay(),
            new Local.NationUnityDay(),
            new Local.DefenderDay(),
            new Local.VictoryDay(),
            new Local.CapitalDay(),
            new Local.ConstitutionDay(),
            new Local.KurbanAitDay(),
            new Local.FirstPresidentDay(),
            new Local.IndependenceDay(),
            new Local.IndependenceDaySecond(),
        };

        /// <summary>
        /// All Kazakh public holidays for the year (names in Russian).
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
