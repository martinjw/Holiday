using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Luxembourg;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Luxembourg
    /// </summary>
    public class LuxembourgPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Luxembourgish.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("lb-LU", "lb");
        #region Individual Holidays

        /// <summary>
        /// Neijoerschdag - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Ouschterméindeg - Easter Monday
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
        /// Dag vun der Aarbecht - Labour Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Christi Himmelfaar - Ascension
        /// </summary>

        public static DateTime Ascension(int year)
        {
            return EasterCalculator.AscensionDay(EasterCalculator.GetEaster(year));
        }

        private static DateTime Ascension(DateTime easter)
        {
            return EasterCalculator.AscensionDay(easter);
        }

        /// <summary>
        /// Europadag - Europe Day, since 2019
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime EuropeDay(int year)
        {
            return new DateTime(year, 5, 9);
        }

        /// <summary>
        /// Whether <see cref="EuropeDay"/> is applied (introduced in 2019)
        /// </summary>
        /// <param name="year">The year</param>
        public static bool HasEuropeDay(int year)
        {
            return year >= 2019;
        }

        /// <summary>
        /// Nationalfeierdag - National Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 6, 23);
        }

        /// <summary>
        /// Péngschtméindeg - Pentecost
        /// </summary>
        public static DateTime PentecostMonday(int year)
        {
            return EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));
        }

        private static DateTime PentecostMonday(DateTime easter)
        {
            return EasterCalculator.WhitMonday(easter);
        }

        /// <summary>
        /// Mariä Himmelfaart - Assumption of Mary
        /// </summary>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Allerhellgen - All Saints
        /// </summary>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Chrëschtdag - Christmas
        /// </summary>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Stiefesdag - St Stephen's Day
        /// </summary>
        public static DateTime StStephen(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion Individual Holidays

        //Ascension can fall on May Day (1 May) or Europe Day (9 May, e.g. 2024);
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.EasterMonday(),
            new Common.LabourDay(),
            new Christian.Ascension(),
            new Christian.WhitMonday(),
            new Local.EuropeDay(),
            new Local.NationalDay(),
            new Christian.Assumption(),
            new Christian.AllSaints(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
        };

        /// <summary>
        /// All Luxembourg public holidays for the year (names in Lëtzebuergesch).
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