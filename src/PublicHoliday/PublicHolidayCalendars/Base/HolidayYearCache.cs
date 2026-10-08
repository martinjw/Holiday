using System;
using System.Collections.Generic;
using System.Globalization;

namespace PublicHoliday
{
    /// <summary>
    /// One calendar's holidays, kept per year. Not thread-safe: a calendar instance is single-threaded, as
    /// elsewhere in this library.
    /// </summary>
    internal sealed class HolidayYearCache
    {
        private readonly Dictionary<int, IList<Holiday>> _byYear = new Dictionary<int, IList<Holiday>>();

        /// <summary>
        /// The year's holidays, built on first request and stamped with what their names resolve through.
        /// </summary>
        public IList<Holiday> GetOrAdd(int year, Func<int, IList<Holiday>> build, CultureInfo culture, string calendarId)
        {
            IList<Holiday> cached;
            if (_byYear.TryGetValue(year, out cached))
            {
                return cached;
            }

            var built = build(year) ?? new List<Holiday>();
            foreach (var holiday in built)
            {
                if (holiday.Culture == null)
                {
                    holiday.Culture = culture;
                }
                holiday.CalendarId = calendarId;
            }
            _byYear[year] = built;
            return built;
        }

        /// <summary>
        /// Discards all cached years.
        /// </summary>
        public void Clear()
        {
            _byYear.Clear();
        }
    }
}
