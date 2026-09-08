using System.Globalization;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// Supplies holiday names from outside the library. Register one with <see cref="HolidayNameProviders.Add"/>
    /// to add a language the library does not ship, or to override a name it does.
    /// </summary>
    /// <remarks>
    /// Asked for one exact culture at a time (nl-BE, then nl, then invariant), providers before the library's
    /// own resources at each. So do NOT fall back to another culture yourself: answering "nl-BE" with a
    /// culture-neutral name would beat the library's real nl-BE one.
    /// </remarks>
    public interface IHolidayNameProvider
    {
        /// <summary>
        /// The name for a holiday in exactly the given culture, if this provider has one.
        /// </summary>
        /// <param name="holidayKey">The holiday's stable id - <see cref="IHoliday.HolidayKey"/>,
        /// e.g. "Christmas", "BelgianNationalDay". Never null or empty when the library calls.</param>
        /// <param name="culture">The culture to answer for, exactly.</param>
        /// <param name="name">The name found, or null.</param>
        /// <returns>True when this provider has a name for that key and culture.</returns>
        bool TryGetName(string holidayKey, CultureInfo culture, out string name);
    }
}
