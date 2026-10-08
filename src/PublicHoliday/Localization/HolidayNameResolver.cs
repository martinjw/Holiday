using System;
using System.Globalization;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// Works out a holiday's name - as the calendar itself would say it, or in a language you name. Backs
    /// <see cref="Holiday.Name"/> and <see cref="Holiday.GetName(CultureInfo)"/> respectively.
    /// </summary>
    internal static class HolidayNameResolver
    {
        /// <summary>
        /// The holiday's name, in <paramref name="asked"/> when a culture is given and the calendar's own
        /// language otherwise. Each source is tried in the order written; the last one always answers.
        /// </summary>
        internal static string Name(Holiday holiday, CultureInfo asked = null)
        {
            var name =
                Translated(holiday, asked)                          // the language asked for
                ?? (IsEnglish(asked) ? NullIfEmpty(holiday.EnglishName) : null)        // English asked for
                ?? NullIfEmpty(holiday.LocalName)                                      // a name set in code
                ?? Translated(holiday, holiday.Culture)             // the calendar's language
                ?? NullIfEmpty(holiday.EnglishName)                                    // the floor
                ?? "";

            return WithDayNumber(name, holiday.DayNumber, asked ?? holiday.Culture);
        }

        /// <summary>
        /// Fills in which day of a multi-day holiday this is, so the days of Eid al-Fitr need one row
        /// ("Ramazan Bayramı {0}. Gün") rather than one per day. A name without "{0}" is left alone, which
        /// is every name but a handful.
        /// </summary>
        private static string WithDayNumber(string name, int dayNumber, CultureInfo culture)
        {
            if (dayNumber <= 0 || name.IndexOf("{0}", StringComparison.Ordinal) < 0) return name;

            return string.Format(culture ?? CultureInfo.InvariantCulture, name, dayNumber);
        }

        /// <summary>
        /// The name in a culture or, failing that, in the cultures it falls back to: nl-BE, then nl, then
        /// invariant. Null when nothing has it, or when no culture is given.
        /// </summary>
        private static string Translated(Holiday holiday, CultureInfo culture)
        {
            if (culture == null) return null;

            foreach (var candidate in CultureFallback.For(culture))
            {
                var found = TranslatedExactly(holiday, candidate);
                if (found != null) return found;
            }
            return null;
        }

        /// <summary>
        /// The name in one culture and no other: registered providers first, so a consumer overrides a
        /// shipped name for that culture, then the library's own resources. Providers are asked culture by
        /// culture rather than all at once, so a broad name of theirs cannot beat a closer one of ours.
        /// </summary>
        private static string TranslatedExactly(Holiday holiday, CultureInfo culture)
        {
            var providers = HolidayNameProviders.Snapshot;
            for (var i = 0; i < providers.Length; i++)
            {
                string supplied;
                if (providers[i].TryGetName(holiday.HolidayKey, culture, out supplied) && !string.IsNullOrEmpty(supplied))
                {
                    return supplied;
                }
            }

            return NameResources.Find(holiday.HolidayKey, culture, holiday.CalendarId);
        }

        /// <summary>
        /// English is never in the resource files - it is the definition's own EnglishName.
        /// </summary>
        private static bool IsEnglish(CultureInfo culture)
        {
            return culture != null
                && (string.IsNullOrEmpty(culture.Name)
                    || string.Equals(culture.TwoLetterISOLanguageName, "en", StringComparison.OrdinalIgnoreCase));
        }

        private static string NullIfEmpty(string value)
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
