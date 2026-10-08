using PublicHoliday.HolidayDefinitions.Christian;
using System;
using System.Collections.Generic;
using System.Linq;
using PublicHoliday.HolidayDefinitions;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Denmark;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Denmark
    /// </summary>
    /// <seealso cref="PublicHolidayBase" />
    public class DenmarkPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Danish.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("da-DK", "da");
        private readonly bool _includeConstitutionDay = true;
        private readonly bool _includeLabourDay = true;
        private readonly bool _includeDayAfterAscension = false;
        private readonly bool _includeChristmasEve = false;
        private readonly bool _includeNewYearsEve = false;

        /// <summary>
        /// Default- includes Constitution Day and Labour Day
        /// </summary>
        public DenmarkPublicHoliday()
        {
        }

        /// <summary>
        /// A Danish calendar including the days that are widely, but not universally, taken off work.
        /// </summary>
        /// <param name="includeConstitutionDay">Set true if Constitution Day (5 June) should be a holiday</param>
        /// <param name="includeLabourDay">Set true if Labour Day (1 May) should be a holiday</param>
        /// <param name="includeDayAfterAscension">Set true if day after Ascension should be considered a holiday</param>
        /// <param name="includeChristmasEve">Set true if Christmas Eve should be considered a holiday</param>
        /// <param name="includeNewYearsEve">Set true if New Year's Eve should be considered a holiday</param>
		public DenmarkPublicHoliday(bool includeConstitutionDay, bool includeLabourDay, bool includeDayAfterAscension = false, bool includeChristmasEve = false, bool includeNewYearsEve = false)
        {
            _includeConstitutionDay = includeConstitutionDay;
            _includeLabourDay = includeLabourDay;
            _includeDayAfterAscension = includeDayAfterAscension;
            _includeChristmasEve = includeChristmasEve;
            _includeNewYearsEve = includeNewYearsEve;
        }

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

        /// <summary>
        /// Good Friday - Friday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
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
        /// Constitution Day - June 5th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ConstitutionDay(int year)
        {
            return new DateTime(year, 6, 5);
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

        ///<summary>
        /// The day after Ascension is a Bankholiday
        ///</summary>
        ///<param name="year"> year of query</param>
        ///
        public DateTime? DayAfterAscension(int year)
        {
            return _includeDayAfterAscension ? Ascension(year).AddDays(1) : (DateTime?)null;
        }

        /// <summary>
        /// Store bededag, General Prayer Day 4th Friday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime? GeneralPrayerDay(int year)
        {
            var easter = EasterCalculator.GetEaster(year);
            // No longer a public holiday from 2024
            if (easter.Year >= 2024)
                return null;
            return GeneralPrayerDay(easter);
        }

        private static DateTime? GeneralPrayerDay(DateTime easter)
        {
            // No longer a public holiday from 2024
            if (easter.Year >= 2024)
                return null;
            return easter.AddDays(5 + (7 * 3));
        }

        /// <summary>
        /// Whit Monday - 7th Sunday after Easter
        /// </summary>
        public static DateTime WhitSunday(int year)
        {
            return EasterCalculator.WhitSunday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// Whit Monday - 7th Monday after Easter
        /// </summary>
        public static DateTime WhitMonday(int year)
        {
            return EasterCalculator.WhitMonday(EasterCalculator.GetEaster(year));
        }

        /// <summary>
        /// ChristmasEve - December 24 - is a Bankholiday
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
        /// NewYearsEve - December 31 - is a Bankholiday
        /// </summary>
        public static DateTime NewYearsEve(int year)
        {
            return new DateTime(year, 12, 31);
        }

        #endregion Individual Holidays

        private IEnumerable<HolidayDefinition> GetDefinitions()
        {
            yield return new Common.NewYear();
            yield return new Christian.MaundyThursday();
            yield return new Christian.GoodFriday();
            yield return new Christian.EasterSunday();
            yield return new Christian.EasterMonday();
            if (_includeLabourDay)
                yield return new Common.LabourDay();
            yield return new Local.GeneralPrayerDay();
            yield return new Christian.Ascension();
            if (_includeDayAfterAscension)
                yield return new Local.DayAfterAscension();
            yield return new Christian.WhitSunday();
            yield return new Christian.WhitMonday();
            if (_includeConstitutionDay)
                yield return new Local.ConstitutionDay();
            if (_includeChristmasEve)
                yield return new Christian.ChristmasEve();
            yield return new Christian.Christmas();
            yield return new Christian.SaintStephensDay();
            if (_includeNewYearsEve)
                yield return new Common.NewYearsEve();
        }

        /// <summary>
        /// All Danish public holidays for the year (names in Danish). Where two holidays fall on
        /// the same day (e.g. Whit Sunday and Constitution Day) both remain distinct entries and
        /// the names dictionary shows them comma-separated.
        /// </summary>
        /// <param name="year">The year.</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in GetDefinitions())
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }
    }
}
