using System;
using System.Collections.Generic;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.Base
{
    /// <summary>
    /// A holiday on the first given weekday on or after a fixed month/day (e.g. Sweden's
    /// Midsummer Day = the Saturday on or after 20 June; Finland's All Saints = the Saturday on
    /// or after 31 October).
    /// </summary>
    public abstract class WeekdayOnOrAfterHoliday : HolidayDefinition
    {
        /// <summary>
        /// Creates a first-weekday-on-or-after holiday definition.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key.</param>
        /// <param name="englishName">Default English display name.</param>
        /// <param name="month">Month of the earliest possible date (1-12).</param>
        /// <param name="day">Day of the earliest possible date.</param>
        /// <param name="dayOfWeek">The weekday the holiday falls on.</param>
        protected WeekdayOnOrAfterHoliday(string holidayKey, string englishName, int month, int day, DayOfWeek dayOfWeek)
            : base(holidayKey, englishName)
        {
            Month = month;
            Day = day;
            DayOfWeek = dayOfWeek;
        }

        /// <summary>
        /// Month of the earliest possible date (1-12).
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// Day of the earliest possible date.
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// The weekday the holiday falls on.
        /// </summary>
        public DayOfWeek DayOfWeek { get; }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            yield return HolidayCalculator.FindNext(new DateTime(year, Month, Day), DayOfWeek);
        }
    }
}
