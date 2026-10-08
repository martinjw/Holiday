using System;
using System.Collections.Generic;
using System.Linq;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Romania;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Romanian. Source https://en.wikipedia.org/wiki/Public_holidays_in_Romania
    /// </summary>
    public class RomanianPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Romanian.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("ro-RO", "ro");
        //Orthodox Easter/Easter Monday can fall on 1 May (e.g. 2016) and Whit Sunday/Monday on
        //1 June (Children's Day); same-day holidays stay distinct entries (names aggregated by
        //the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Common.DayAfterNewYear(),
            new Christian.Epiphany { HolidayKey = HolidayKeys.EpiphanyRO,  AppliesInYear = From2024 },
            new Local.SaintJohnBaptistDay(),
            new Local.UnificationDay(),
            new Christian.GoodFriday { Orthodox = true },
            new Christian.EasterSunday { Orthodox = true },
            new Christian.EasterMonday { Orthodox = true },
            new Common.LabourDay(),
            new Local.ChildrensDay(),
            new Christian.WhitSunday { Orthodox = true },
            new Christian.WhitMonday { Orthodox = true },
            new Christian.Assumption(),
            new Local.SaintAndrewDay(),
            new Local.NationalDay(),
            new Christian.Christmas(),
            new Christian.SaintStephensDay(),
        };

        private static bool From2024(int year) => year >= 2024;

        /// <summary>
        /// All Romanian public holidays for the year (names in Romanian).
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


        #region private

        /// <summary>
        /// New Year (Anul nou)
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Dates of given year</returns>
        public static IEnumerable<DateTime> NewYear(int year)
            => new[] { new DateTime(year, 1, 1), new DateTime(year, 1, 2) };

        /// <summary>
        /// Epiphany (Bobotează). Public holiday starting with 2024
        /// </summary>
        private static DateTime? Epiphany(int year)
        {
            if (year >= 2024) return new DateTime(year, 1, 6);

            return null;
        }

        /// <summary>
        /// Saint John the Baptist (Sfântul Ion). Public holiday starting with 2024
        /// </summary>
        private static DateTime? SaintJohnTheBaptist(int year)
        {
            if (year >= 2024) return new DateTime(year, 1, 7);

            return null;
        }

        /// <summary>
        /// Day of the Unification of the Romanian Principalities (Unirea Principatelor Române)
        /// </summary>
        public static DateTime UnificationOfPrincipalities(int year)
            => new DateTime(year, 1, 24);

        /// <summary>
        /// Easter Orthodox Good Friday (Vinerea Mare)
        /// </summary>
        /// <param name="easter">The easter date</param>
        public static DateTime EasterFriday(DateTime easter)
            => EasterCalculator.GoodFriday(easter);

        /// <summary>
        /// Easter Monday
        /// </summary>
        /// <param name="easter">The easter date</param>
        public static DateTime EasterMonday(DateTime easter)
            => EasterCalculator.EasterMonday(easter);

        /// <summary>
        /// International Labour Day (Ziua Muncii)
        /// </summary>
        public static DateTime LabourDay(int year)
            => new DateTime(year, 5, 1);

        /// <summary>
        /// Children Day (Ziua Copilului). Public holiday starting with 2017
        /// </summary>
        public static DateTime? ChildrenDay(int year)
        {
            if (year >= 2017) return new DateTime(year, 6, 1);

            return null;
        }

        /// <summary>
        /// Easter Whit Monday (Rusaliile). 49 - Sunday (Descent of the Holy Spirit), 50 - Monday
        /// </summary>
        public static IEnumerable<DateTime> WhitMonday(DateTime easter)
            => new[] { EasterCalculator.WhitSunday(easter), EasterCalculator.WhitMonday(easter) };

        /// <summary>
        /// St Mary's Day (Adormirea Maicii Domnului/Sfânta Maria Mare)
        /// </summary>
        public static DateTime SaintMaryDay(int year)
            => new DateTime(year, 8, 15);

        /// <summary>
        /// St. Andrew's Day (Sfântul Andrei)
        /// </summary>
        public static DateTime SaintAndrewDay(int year)
            => new DateTime(year, 11, 30);

        /// <summary>
        /// National Day of Romania (Ziua Națională a României)
        /// </summary>
        public static DateTime NationalDay(int year)
            => new DateTime(year, 12, 1);

        /// <summary>
        /// Christmas Day (Crăciunul)
        /// </summary>
        public static IEnumerable<DateTime> ChristmasDay(int year)
            => new[] { new DateTime(year, 12, 25), new DateTime(year, 12, 26) };

        #endregion
    }
}
