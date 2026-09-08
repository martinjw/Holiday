using System;
using System.Collections.Generic;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.Base
{
    /// <summary>
    /// A holiday on the last given weekday on or before a fixed month/day (e.g. Ireland's
    /// October Holiday = the Monday on or before 31 October).
    /// </summary>
    public abstract class WeekdayOnOrBeforeHoliday : HolidayDefinition
    {
        /// <summary>
        /// Creates a last-weekday-on-or-before holiday definition.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key.</param>
        /// <param name="englishName">Default English display name.</param>
        /// <param name="month">Month of the latest possible date (1-12).</param>
        /// <param name="day">Day of the latest possible date.</param>
        /// <param name="dayOfWeek">The weekday the holiday falls on.</param>
        protected WeekdayOnOrBeforeHoliday(string holidayKey, string englishName, int month, int day, DayOfWeek dayOfWeek)
            : base(holidayKey, englishName)
        {
            Month = month;
            Day = day;
            DayOfWeek = dayOfWeek;
        }

        /// <summary>
        /// Month of the latest possible date (1-12).
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// Day of the latest possible date.
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// The weekday the holiday falls on.
        /// </summary>
        public DayOfWeek DayOfWeek { get; }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            yield return HolidayCalculator.FindPrevious(new DateTime(year, Month, Day), DayOfWeek);
        }
    }
}
