using System;
using System.Collections.Generic;

namespace PublicHoliday.HolidayDefinitions.Base
{
    /// <summary>
    /// A holiday whose officially-announced dates are known per year rather than computed
    /// (e.g. New Zealand's Matariki). Years outside the table produce no occurrence.
    /// </summary>
    public abstract class LookupTableHoliday : HolidayDefinition
    {
        private readonly IDictionary<int, DateTime> _datesByYear;

        /// <summary>
        /// Creates a lookup-table holiday definition.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key.</param>
        /// <param name="englishName">Default English display name.</param>
        /// <param name="datesByYear">The officially-announced date per year.</param>
        protected LookupTableHoliday(string holidayKey, string englishName, IDictionary<int, DateTime> datesByYear)
            : base(holidayKey, englishName)
        {
            _datesByYear = datesByYear;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            DateTime date;
            if (_datesByYear.TryGetValue(year, out date))
            {
                yield return date;
            }
        }
    }
}
