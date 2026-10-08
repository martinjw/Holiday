using System;

namespace PublicHoliday.Dates
{
    /// <summary>
    /// Weekend-shift rules and day-of-week finders. No holiday knowledge: Easter and the movable feasts
    /// are in HolidayDefinitions/Christian/EasterCalculator.
    /// </summary>
    static class HolidayCalculator
    {
        /// <summary>
        /// Fix weekend to monday.
        /// </summary>
        public static DateTime FixWeekend(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            else if (hol.DayOfWeek == DayOfWeek.Saturday)
                hol = hol.AddDays(2);
            return hol;
        }

        /// <summary>
        /// Fix weekend with saturday to friday and the sunday to monday.
        /// </summary>
        public static DateTime FixWeekendSaturdayBeforeSundayAfter(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            else if (hol.DayOfWeek == DayOfWeek.Saturday)
                hol = hol.AddDays(-1);
            return hol;
        }

        /// <summary>
        /// Fix weekend with only sunday to monday.
        /// </summary>
        public static DateTime FixWeekendSundayAfter(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            return hol;
        }

        /// <summary>
        /// Fix Weekend for the after of two holiday consecutive with standard FixWeekend to monday.
        /// </summary>
        public static DateTime FixWeekendTwoHolidayAfter(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Monday)
                hol = hol.AddDays(1);
            else if (hol.DayOfWeek == DayOfWeek.Saturday || hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(2);
            return hol;
        }

        /// <summary>
        /// Fix Weekend for the before with two holiday consecutive with standard FixWeekend to monday
        /// </summary>
        public static DateTime FixWeekendTwoHolidayBefore(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Saturday)
                hol = hol.AddDays(-1);
            else if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(-2);
            return hol;
        }

        /// <summary>
        /// Finds the N-th occurrence of a day of the week, on or after the given date.
        /// </summary>
        public static DateTime FindOccurrenceOfDayOfWeek(DateTime hol, DayOfWeek day, short occurence)
        {
            while (hol.DayOfWeek != day)
                hol = hol.AddDays(1);

            hol = hol.AddDays(7 * (occurence - 1));

            return hol;
        }

        /// <summary>
        /// Finds the nearest given day of the week (before or after the given date).
        /// </summary>
        public static DateTime FindNearestDayOfWeek(DateTime hol, DayOfWeek day)
        {
            int advance = 0;
            while (((int)hol.DayOfWeek + advance) % 7 != (int)day)
                advance++;

            if (advance > 3)
                return hol.AddDays(advance - 7);
            else return hol.AddDays(advance);
        }

        /// <summary>
        /// Finds the first Monday on or after the given date.
        /// </summary>
        public static DateTime FindFirstMonday(DateTime hol)
        {
            return FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Monday, 1);
        }

        /// <summary>
        /// Finds the first Friday on or before the given date.
        /// </summary>
        public static DateTime GetFirstFridayBeforeDate(DateTime date)
        {
            // Calculate the difference in days between the target day (Friday) and the current day of the week
            int daysToSubtract = ((int)date.DayOfWeek - (int)DayOfWeek.Friday + 7) % 7;

            // Subtract the calculated number of days from the input date
            DateTime resultDate = date.AddDays(-daysToSubtract);

            return resultDate;
        }

        /// <summary>
        /// Finds the given day of the week, on or before the given date.
        /// </summary>
        public static DateTime FindPrevious(DateTime hol, DayOfWeek day)
        {
            while (hol.DayOfWeek != day)
                hol = hol.AddDays(-1);

            return hol;
        }

        /// <summary>
        /// Finds the given day of the week, on or after the given date.
        /// </summary>
        public static DateTime FindNext(DateTime hol, DayOfWeek day)
        {
            while (hol.DayOfWeek != day)
                hol = hol.AddDays(1);

            return hol;
        }

        /// <summary>
        /// Returns the N-th occurrence of a specific day of the week in a given week/month/year.
        /// </summary>
        public static DateTime GetDayOfWeekInMonth(int year, int month, DayOfWeek dayOfWeek, int week)
        {
            if (week < 1 || week > 5)
                throw new ArgumentOutOfRangeException(nameof(week), "Week must be between 1 and 5");

            // First day of the month
            DateTime date = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Local);

            // Move forward until we find the desired day of the week
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(1);
            }

            // Add (week - 1) * 7 days to get the correct occurrence
            DateTime result = date.AddDays((week - 1) * 7);

            return result;
        }
    }
}
