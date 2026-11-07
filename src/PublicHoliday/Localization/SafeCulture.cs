using System;
using System.Globalization;

namespace PublicHoliday.Localization
{
    /// <summary>
    /// Creates a <see cref="CultureInfo"/> without ever throwing. Calendars hold their culture in a static
    /// field, so an unknown culture name would surface as a TypeInitializationException and break the whole
    /// calendar rather than one name lookup - and region-specific names (sr-Latn-ME, ru-KZ, lb-LU) are not
    /// known to every target framework or platform.
    /// </summary>
    internal static class SafeCulture
    {
        /// <summary>
        /// The culture for <paramref name="name"/>, else for <paramref name="fallbackLanguage"/>, else English.
        /// </summary>
        internal static CultureInfo Get(string name, string fallbackLanguage)
        {
            return TryGet(name) ?? TryGet(fallbackLanguage) ?? new CultureInfo("en");
        }

        private static CultureInfo TryGet(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            try
            {
                return new CultureInfo(name);
            }
            catch (ArgumentException)
            {
                //CultureNotFoundException derives from ArgumentException, and IS one on net35
                return null;
            }
        }
    }
}
