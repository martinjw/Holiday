using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using Christian = PublicHoliday.HolidayDefinitions.Christian;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Finland;
using PublicHoliday.HolidayDefinitions.Base;
using System.Globalization;
using PublicHoliday.Localization;
// ReSharper disable StringLiteralTypo

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays in Finland.
    /// <br />
    /// Typically the large holidays are already celebrated on the Eve. These can be added in constructor.
    /// <br />
    /// Public holiday dates have had minor alterations. Current implementation should be quite accurate back to 1774.
    /// <br />
    /// Sources used:
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Finland
    /// https://fi.wikipedia.org/wiki/Pyh%C3%A4p%C3%A4iv%C3%A4
    /// </summary>
    public class FinlandPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Finnish.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("fi-FI", "fi");
        /// <summary>
        /// Include days that are considered holiday in some labor agreements. Relevant as some businesses
        /// are partly or fully closed and public transport runs on special holiday schedule.
        /// </summary>
        private readonly bool _includeNonOfficialHolidays;

        /// <summary>
        /// Public holidays of Finland
        /// </summary>
        /// <param name="includeNonOfficialHolidays">
        /// Midsummer Eve and Christmas Eve are non-official holidays. They are considered
        /// holiday in some labor agreements</param>
        public FinlandPublicHoliday(bool includeNonOfficialHolidays = false)
        {
            _includeNonOfficialHolidays = includeNonOfficialHolidays;
        }

        private IEnumerable<HolidayDefinition> GetDefinitions()
        {
            yield return new Common.NewYear();
            yield return new Christian.Epiphany();
            yield return new Christian.GoodFriday();
            yield return new Christian.EasterSunday();
            yield return new Christian.EasterMonday();
            //Ascension - some years overlaps with May Day (vappu); both stay distinct entries
            yield return new Common.LabourDay();
            yield return new Christian.Ascension();
            yield return new Christian.WhitSunday();
            yield return new Local.MidsummerDay();
            yield return new Local.AllSaintsDay();
            yield return new Local.IndependenceDay();
            if (_includeNonOfficialHolidays)
            {
                yield return new Local.MidsummerEve();
                yield return new Christian.ChristmasEve();
            }
            yield return new Christian.Christmas();
            yield return new Christian.SaintStephensDay();
        }

        /// <summary>
        /// All Finnish public holidays for the year (names in Finnish).
        /// </summary>
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
