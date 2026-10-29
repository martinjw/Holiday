using System;
using System.Collections.Generic;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.Base
{
    /// <summary>
    /// A holiday observed on the weekday nearest to a fixed month/day (e.g. Canada NL's
    /// St Patrick's Day = the Monday nearest to 17 March).
    /// </summary>
    public abstract class NearestWeekdayHoliday : HolidayDefinition
    {
        /// <summary>
        /// Creates a nearest-weekday holiday definition.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key.</param>
        /// <param name="englishName">Default English display name.</param>
        /// <param name="month">Month of the nominal date (1-12).</param>
        /// <param name="day">Day of the nominal date.</param>
        /// <param name="dayOfWeek">The weekday the holiday is observed on.</param>
        protected NearestWeekdayHoliday(string holidayKey, string englishName, int month, int day, DayOfWeek dayOfWeek)
            : base(holidayKey, englishName)
        {
            Month = month;
            Day = day;
            DayOfWeek = dayOfWeek;
        }

        /// <summary>
        /// Month of the nominal date (1-12).
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// Day of the nominal date.
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// The weekday the holiday is observed on.
        /// </summary>
        public DayOfWeek DayOfWeek { get; }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            yield return HolidayCalculator.FindNearestDayOfWeek(new DateTime(year, Month, Day), DayOfWeek);
        }
    }
}
