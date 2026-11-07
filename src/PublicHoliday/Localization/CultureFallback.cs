using System.Collections.Generic;
using System.Globalization;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// The cultures a name lookup tries, most specific first: nl-BE, nl, then the invariant
    /// culture. A country's own wording therefore beats the generic translation of its language.
    /// </summary>
    internal static class CultureFallback
    {
        /// <summary>
        /// <paramref name="culture"/>, then each of its parents, ending with the invariant culture.
        /// </summary>
        internal static IEnumerable<CultureInfo> For(CultureInfo culture)
        {
            for (var current = culture; current != null; current = current.Parent)
            {
                yield return current;

                //the invariant culture is its own parent
                if (string.IsNullOrEmpty(current.Name)) break;
            }
        }
    }
}
