using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Estonia;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays in Estonia.
    /// Sources used:
    ///  * https://et.wikipedia.org/wiki/Eesti_riigip%C3%BChad
    ///  * https://en.wikipedia.org/wiki/Public_holidays_in_Estonia
    ///  * https://riigipühad.ee/
    /// </summary>
    public class EstoniaPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Estonian.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("et-EE", "et");
        private static readonly HolidayDefinition[] Definitions =
        {
            new NewYear(),
            new Local.IndependenceDay(),
            new GoodFriday(),
            new EasterSunday(),
            new LabourDay(),
            new WhitSunday(),
            new Local.VictoryDay(),
            new Local.MidsummerDay(),
            new Local.RestorationOfIndependenceDay(),
            new ChristmasEve { AppliesInYear = YearFrom2005 },
            new Christmas(),
            new SaintStephensDay(),
        };

        private static bool YearFrom2005(int year)
        {
            return year >= 2005;
        }

        /// <summary>
        /// All Estonian public holidays for the year (names in Estonian).
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
    }
}
