using System.Collections.Generic;
using System.Globalization;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Localization;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Latvia;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays in Latvia, as listed in Article 1 of the law "Par svētku, atceres un
    /// atzīmējamām dienām" (On Holidays, Remembrance Days and Celebration Days).
    /// Sources used:
    ///  * https://likumi.lv/ta/id/72608-par-svetku-atceres-un-atzimejamam-dienam
    ///  * https://en.wikipedia.org/wiki/Public_holidays_in_Latvia
    /// </summary>
    public class LatviaPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Latvian.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("lv-LV", "lv");

        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Christian.GoodFriday(),
            new Christian.EasterSunday(),
            new Christian.EasterMonday(),
            new Common.LabourDay(),
            new Local.RestorationOfIndependenceDay(),
            new Local.MothersDay(),
            new Christian.WhitSunday(),
            new Local.BronzeMedalDay(),
            new Local.LigoDay(),
            new Local.MidsummerDay(),
            new Local.SongAndDanceFestivalClosingDay(),
            new Local.PopeFrancisVisitDay(),
            new Local.ProclamationDay(),
            new Christian.ChristmasEve { AppliesInYear = YearFrom2007 },
            new Christian.Christmas(),
            new Local.SecondChristmasDay(),
            new Common.NewYearsEve(),
        };

        /// <summary>
        /// Christmas Eve became a holiday with the 2007 amendment to the holidays law, which also
        /// introduced the weekend rule (see <see cref="Local.LatviaWeekendRule"/>).
        /// </summary>
        private static bool YearFrom2007(int year)
        {
            return year >= 2007;
        }

        /// <summary>
        /// All Latvian public holidays for the year (names in Latvian).
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
