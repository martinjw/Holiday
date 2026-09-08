using System;
using System.Collections.Generic;
using System.Globalization;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Canada;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Localization;
using PublicHoliday.Dates;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Governement of Quebec (statutory) Holidays. Adjusted for weekends.
    /// <description>
    /// Governement of Quebec regulated workers are entitled to thirteen paid statutory holidays every year.
    /// <para>When New Year’s Day or Christmas fall on a Saturday or Sunday that are not normal work days, workers are entitled to a holiday with pay on the working day immediately after the holiday</para>
    /// <para>When National Holiday or Canada Day fall on a Saturday or Sunday that are not normal work days, workers are entitled to a holiday with pay on the working day immediately before for saturday or immediately after for the sunday the holiday</para>
    /// </description>
    /// </summary>
    /// <remarks>
    /// Holiday lists are cached per instance/year automatically - no action needed.
    /// </remarks>
    public class CanadaQuebecGovClosingDay : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Canadian French.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("fr-CA", "fr");

        #region Individual Holidays

        /// <summary>
        /// Date of New Year bank holiday.
        /// </summary>
        /// <remarks>If weekend, after.</remarks>
        public static Holiday NewYear(int year)
        {
            var hol = new DateTime(year, 1, 1);
            return new Holiday(hol, HolidayCalculator.FixWeekend(hol), HolidayKeys.NewYear);
        }

        /// <summary>
        /// Day After New Year
        /// </summary>
        public static Holiday DayAfterNewYear(int year)
        {
            var hol = new DateTime(year, 1, 2);
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayAfter(hol), HolidayKeys.DayAfterNewYear);
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        public static Holiday GoodFriday(int year)
        {
            var hol = EasterCalculator.GoodFriday(EasterCalculator.GetEaster(year));
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayAfter(hol), HolidayKeys.GoodFriday);
        }

        /// <summary>
        /// Easter Monday (Monday after Easter)
        /// </summary>
        public static Holiday EasterMonday(int year)
        {
            var hol = EasterCalculator.EasterMonday(EasterCalculator.GetEaster(year));
            return new Holiday(hol, hol, HolidayKeys.EasterMonday);
        }

        /// <summary>
        /// Private overloads of GoodFriday and EasterMonday reusing Easter calculation
        /// </summary>
        private static Holiday GoodFriday(DateTime easter)
        {
            var hol = EasterCalculator.GoodFriday(easter);
            return new Holiday(hol, hol, HolidayKeys.GoodFriday);
        }
        private static Holiday EasterMonday(DateTime easter)
        {
            var hol = EasterCalculator.EasterMonday(easter);
            return new Holiday(hol, hol, HolidayKeys.EasterMonday);
        }

        /// <summary>
        /// Monday on or before May 24
        /// </summary>
        /// <remarks>Before 2003 DollardDay.</remarks>
        public static Holiday NationalPatriotDay(int year)
        {
            var idText = year > 2002 ? HolidayKeys.NationalPatriotDay : HolidayKeys.DollardDay;

            var hol = new DateTime(year, 5, 24);
            //skip back to previous Monday
            while (hol.DayOfWeek != DayOfWeek.Monday)
            {
                hol = hol.AddDays(-1);
            }
            return new Holiday(hol, hol, idText);
        }

        /// <summary>
        /// National holiday (June 24)
        /// </summary>
        public static Holiday NationalHoliday(int year)
        {
            var hol = new DateTime(year, 6, 24);
            return new Holiday(hol, HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(hol), HolidayKeys.NationalHolidayQuebec);
        }

        /// <summary>
        /// Canada day, 1 July or following Monday 
        /// </summary>
        public static Holiday CanadaDay(int year)
        {
            var idText = year > 1981 ? HolidayKeys.CanadaDay : HolidayKeys.DominionDay;
            var hol = new DateTime(year, 7, 1);
            return new Holiday(hol, HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(hol), idText);
        }

        /// <summary>
        /// First Monday in September
        /// </summary>
        public static Holiday LabourDay(int year)
        {
            var hol = new DateTime(year, 9, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, HolidayKeys.LabourDay);
        }

        /// <summary>
        /// Second Monday in October
        /// </summary>
        public static Holiday Thanksgiving(int year)
        {
            var hol = new DateTime(year, 10, 8);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, HolidayKeys.Thanksgiving);
        }

        /// <summary>
        /// Day Before Christmas
        /// </summary>
        public static Holiday DayBeforeChristmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 24);
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayBefore(hol), HolidayKeys.DayBeforeChristmas);
        }

        /// <summary>
        /// Christmas day
        /// </summary>
        public static Holiday Christmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 25);
            return new Holiday(hol, HolidayCalculator.FixWeekend(hol), HolidayKeys.Christmas);
        }

        /// <summary>
        /// Day After Christmas
        /// </summary>
        public static Holiday DayAfterChristmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 26);
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayAfter(hol), HolidayKeys.DayAfterChristmas);
        }


        /// <summary>
        /// Day Before Christmas
        /// </summary>
        public static Holiday DayBeforeNewYear(int year)
        {
            DateTime hol = new DateTime(year, 12, 31);
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayBefore(hol), HolidayKeys.DayBeforeNewYear);
        }

        #endregion

        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear { ObservedDateRule = HolidayCalculator.FixWeekend },
            new Local.QuebecDayAfterNewYear(),
            new Christian.GoodFriday(),
            new Christian.EasterMonday(),
            new Local.NationalPatriotDay(),
            new Local.QuebecNationalHoliday(),
            new Local.QuebecCanadaDay(),
            new Local.LabourDay(),
            new Local.Thanksgiving(),
            new Local.DayBeforeChristmas(),
            new Local.ChristmasDay(),
            new Local.DayAfterChristmas(),
            new Local.DayBeforeNewYear(),
        };

        /// <summary>
        /// Gets a list of public holidays with their observed and actual date
        /// </summary>
        /// <param name="year">The given year</param>
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

