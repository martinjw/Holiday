using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Greece;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Public Holidays in Greece. Based on https://en.wikipedia.org/wiki/Public_holidays_in_Greece
    /// </summary>
    /// <remarks>
    /// NB: Legally every Sunday of the year is a public holiday. This only includes the 6 fixed holidays and 3 non-fixed.
    /// Greek names are resolved through the localization keys: <c>GetName(new CultureInfo("el"))</c>.
    /// </remarks>
    public class GreecePublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Greek.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("el-GR", "el");
        /// <summary>
        /// Clean Monday (Ash Monday, first day of Lent)
        /// </summary>
        public static DateTime CleanMonday(int year)
        {
            return EasterCalculator.GetOrthodoxEaster(year).AddDays(-48);
        }

        /// <summary>
        /// Greek Independence Day (also, Annunciation of the Virgin Mary)
        /// </summary>
        public static DateTime IndependenceDay(int year)
        {
            return new DateTime(year, 3, 25);
        }

        /// <summary>
        /// Great Friday
        /// </summary>
        public static DateTime GreatFriday(int year)
        {
            return EasterCalculator.GoodFriday(EasterCalculator.GetOrthodoxEaster(year));
        }

        /// <summary>
        /// Easter Monday
        /// </summary>
        public static DateTime EasterMonday(int year)
        {
            return EasterCalculator.EasterMonday(EasterCalculator.GetOrthodoxEaster(year));
        }

        /// <summary>
        /// Whit Monday (Pentecost Monday)
        /// </summary>
        public static DateTime WhitMonday(int year)
        {
            return EasterCalculator.WhitMonday(EasterCalculator.GetOrthodoxEaster(year));
        }

        //Easter Monday (2000) or Great Friday (2043) can fall on Labour Day (1 May);
        //same-day holidays stay distinct entries (names aggregated by the base class)
        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear { EnglishName = "New Year's Day" },
            new Christian.Epiphany(),
            new Christian.CleanMonday(),
            new Local.GreekIndependenceDay(),
            new Christian.GoodFriday { EnglishName = "Great Friday", Orthodox = true },
            new Christian.EasterMonday { Orthodox = true },
            new Common.LabourDay(),
            new Christian.WhitMonday { Orthodox = true },
            new Christian.Assumption { EnglishName = "Dormition of the Mother of God" },
            new Local.OchiDay(),
            new Christian.Christmas { EnglishName = "Christmas Day" },
            new Local.SynaxisOfTheMotherOfGod(),
        };

        /// <summary>
        /// All Greek public holidays for the year (English names; Greek via the localization keys).
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
