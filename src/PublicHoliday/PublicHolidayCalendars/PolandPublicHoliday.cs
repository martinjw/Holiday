using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Poland;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Poland
    /// </summary>
    public class PolandPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Polish.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("pl-PL", "pl");
        #region Individual Holidays

        /// <summary>
        /// New Year's Day (1st January)
        /// </summary>
        public static DateTime NewYear(int year) => new DateTime(year, 1, 1);

        /// <summary>
        /// Epiphany (6th January)
        /// </summary>
        public static DateTime Epiphany(int year) => new DateTime(year, 1, 6);

        /// <summary>
        /// Easter Sunday (calculated dynamically)
        /// </summary>
        public static DateTime EasterSunday(int year) => EasterCalculator.GetEaster(year);

        /// <summary>
        /// Easter Monday (day after Easter Sunday)
        /// </summary>
        public static DateTime EasterMonday(int year) => EasterCalculator.EasterMonday(EasterSunday(year));

        /// <summary>
        /// Labour Day (1st May)
        /// </summary>
        public static DateTime LabourDay(int year) => new DateTime(year, 5, 1);

        /// <summary>
        /// Constitution Day (3rd May)
        /// </summary>
        public static DateTime ConstitutionDay(int year) => new DateTime(year, 5, 3);

        /// <summary>
        /// Pentecost (49 days after Easter Sunday)
        /// </summary>
        public static DateTime Pentecost(int year) => EasterCalculator.WhitSunday(EasterSunday(year));

        /// <summary>
        /// Corpus Christi (60 days after Easter Sunday)
        /// </summary>
        public static DateTime CorpusChristi(int year) => EasterCalculator.CorpusChristi(EasterSunday(year));

        /// <summary>
        /// Assumption of Mary (15th August)
        /// </summary>
        public static DateTime Assumption(int year) => new DateTime(year, 8, 15);

        /// <summary>
        /// All Saints (1st November)
        /// </summary>
        public static DateTime AllSaints(int year) => new DateTime(year, 11, 1);

        /// <summary>
        /// Independence Day (11th November)
        /// </summary>
        public static DateTime IndependenceDay(int year) => new DateTime(year, 11, 11);

        /// <summary>
        /// Christmas Eve (24th December) - public holiday from 2025 onwards
        /// </summary>
        public static DateTime? ChristmasEve(int year)
        {
            if (year >= 2025) return new DateTime(year, 12, 24);
            return null;
        }

        /// <summary>
        /// Christmas Day (25th December)
        /// </summary>
        public static DateTime Christmas(int year) => new DateTime(year, 12, 25);

        /// <summary>
        /// St. Stephen's Day (26th December)
        /// </summary>
        public static DateTime StStephen(int year) => new DateTime(year, 12, 26);

        #endregion

        #region Public Holiday List

        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.Epiphany(),
            new Christian.EasterSunday { EnglishName = "Easter Sunday" },
            new Christian.EasterMonday(),
            new Common.LabourDay(),
            new Local.ConstitutionDay(),
            new Christian.WhitSunday { EnglishName = "Pentecost" },
            new Christian.CorpusChristi(),
            new Christian.Assumption(),
            new Christian.AllSaints(),
            new Local.IndependenceDay(),
            new Christian.ChristmasEve { AppliesInYear = ChristmasEveIsPublic },
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
        };

        //public holiday from 2025 onwards
        private static bool ChristmasEveIsPublic(int year) => year >= 2025;

        /// <summary>
        /// All Polish public holidays for the year.
        /// </summary>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }

        #endregion

    }
}
