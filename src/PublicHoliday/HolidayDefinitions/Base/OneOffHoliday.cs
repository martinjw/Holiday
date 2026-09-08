using System;
using System.Collections.Generic;

namespace PublicHoliday.HolidayDefinitions.Base
{
    /// <summary>
    /// A holiday that occurred exactly once on a specific date (royal weddings, jubilees, state
    /// funerals, national days of mourning, one-off commemorations).
    /// </summary>
    public abstract class OneOffHoliday : HolidayDefinition
    {
        private readonly DateTime _date;

        /// <summary>
        /// Creates a one-off holiday definition.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key.</param>
        /// <param name="englishName">Default English display name.</param>
        /// <param name="date">The single date the holiday occurred on.</param>
        protected OneOffHoliday(string holidayKey, string englishName, DateTime date)
            : base(holidayKey, englishName)
        {
            _date = date;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            if (year == _date.Year)
            {
                yield return _date;
            }
        }
    }
}
