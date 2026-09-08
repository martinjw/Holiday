using System;
using System.Collections.Generic;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.Base
{
    /// <summary>
    /// A holiday on the N-th occurrence of a weekday in a month (e.g. Thanksgiving = 4th Thursday
    /// of November, Martin Luther King Day = 3rd Monday of January).
    /// </summary>
    public abstract class NthWeekdayHoliday : HolidayDefinition
    {
        /// <summary>
        /// Creates an N-th-weekday-of-month holiday definition.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key.</param>
        /// <param name="englishName">Default English display name.</param>
        /// <param name="month">Month (1-12).</param>
        /// <param name="dayOfWeek">The day of the week.</param>
        /// <param name="occurrence">Which occurrence within the month (1-5).</param>
        protected NthWeekdayHoliday(string holidayKey, string englishName, int month, DayOfWeek dayOfWeek, int occurrence)
            : base(holidayKey, englishName)
        {
            Month = month;
            DayOfWeek = dayOfWeek;
            Occurrence = occurrence;
        }

        /// <summary>
        /// Month of the holiday (1-12).
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// The day of the week of the holiday.
        /// </summary>
        public DayOfWeek DayOfWeek { get; }

        /// <summary>
        /// Which occurrence of <see cref="DayOfWeek"/> within the month (1-5).
        /// </summary>
        public int Occurrence { get; }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            yield return HolidayCalculator.GetDayOfWeekInMonth(year, Month, DayOfWeek, Occurrence);
        }
    }
}
