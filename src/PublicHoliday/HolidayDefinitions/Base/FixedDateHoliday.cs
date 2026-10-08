using System;
using System.Collections.Generic;

namespace PublicHoliday.HolidayDefinitions.Base
{
    /// <summary>
    /// A holiday on a fixed month/day every year (e.g. a national day). Country-unique fixed-date
    /// holidays that need no bespoke computation get their own named subclass in
    /// CountrySpecific/{Country}Holidays.cs.
    /// </summary>
    public abstract class FixedDateHoliday : HolidayDefinition
    {
        /// <summary>
        /// Creates a fixed-date holiday definition.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key.</param>
        /// <param name="englishName">Default English display name.</param>
        /// <param name="month">Month (1-12).</param>
        /// <param name="day">Day of month.</param>
        protected FixedDateHoliday(string holidayKey, string englishName, int month, int day)
            : base(holidayKey, englishName)
        {
            Month = month;
            Day = day;
        }

        /// <summary>
        /// Month of the holiday (1-12).
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// Day of the month of the holiday.
        /// </summary>
        public int Day { get; }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            yield return new DateTime(year, Month, Day);
        }
    }
}
