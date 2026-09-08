using System;
using System.Globalization;

namespace PublicHoliday
{
    /// <summary>
    /// A single occurrence of a holiday: its actual and observed dates, identity, and
    /// culture-aware name resolution.
    /// </summary>
    public interface IHoliday
    {
        /// <summary>
        /// Date of the holiday itself.
        /// </summary>
        DateTime HolidayDate { get; }

        /// <summary>
        /// The date the holiday is actually observed on (differs from <see cref="HolidayDate"/>
        /// after a weekend shift).
        /// </summary>
        DateTime ObservedDate { get; }

        /// <summary>
        /// The name in the language of the calendar that produced this holiday - what that country
        /// calls it ("Kerstmis" from a Belgian calendar). Falls back to <see cref="EnglishName"/>.
        /// Use <see cref="GetName(CultureInfo)"/> to ask for a particular language instead.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// English name of the holiday.
        /// </summary>
        string EnglishName { get; }

        /// <summary>
        /// Stable identity / localization key of the holiday (e.g. "NewYear", "BelgianNationalDay").
        /// </summary>
        string HolidayKey { get; }

        /// <summary>
        /// Whether the holiday applies to the whole country (false = region-only, see <see cref="Regions"/>).
        /// </summary>
        bool IsPublic { get; }

        /// <summary>
        /// Names of the regions of the country where this holiday exists (null = everywhere).
        /// </summary>
        string[] Regions { get; }

        /// <summary>
        /// Localized name for the given culture; never empty when a name exists anywhere.
        /// </summary>
        string GetName(CultureInfo culture);

        /// <summary>
        /// Localized name for the given culture name (e.g. "fr-BE").
        /// </summary>
        string GetName(string culture);
    }
}
