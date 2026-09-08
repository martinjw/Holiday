using System;

namespace PublicHoliday.Dates
{
    /// <summary>
    /// Walks an <see cref="IPublicHolidays"/> calendar day by day: the engines behind NextWorkingDay,
    /// BusinessDaysAdd and friends.
    /// </summary>
    internal static class WorkingDayCalculator
    {
        /// <summary>
        /// Returns whether the specified date is a working day
        /// </summary>
        /// <param name="holidayCalendar">The holiday calendar.</param>
        /// <param name="dt">The date to be checked</param>
        /// <returns>Returns a boolean of whether the specified date is a working day</returns>
        public static bool IsWorkingDay(IPublicHolidays holidayCalendar, DateTime dt)
        {
            return dt.DayOfWeek != DayOfWeek.Saturday &&
                dt.DayOfWeek != DayOfWeek.Sunday &&
                !holidayCalendar.IsPublicHoliday(dt);
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after the specified date (or the same date)
        /// </summary>
        /// <param name="holidayCalendar">The holiday calendar.</param>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="sameDay">If we can return same date</param>
        /// <returns>
        /// A date that is a working day without time
        /// </returns>
        public static DateTime NextWorkingDay(IPublicHolidays holidayCalendar, DateTime dt, bool sameDay = true)
        {
            return NextWorkingDay(holidayCalendar, dt, 0, sameDay);
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after x day of the specified date (or the same date)
        /// </summary>
        /// <param name="holidayCalendar">The holiday calendar.</param>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDayAdd">The number of open day to add</param>
        /// <param name="sameDay">If we can return same date</param>
        /// <returns>
        /// A date that is a working day without time
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">openDayAdd - negative number</exception>
        public static DateTime NextWorkingDay(IPublicHolidays holidayCalendar, DateTime dt, int openDayAdd, bool sameDay = true)
        {
            if (openDayAdd < 0)
            {
                throw new ArgumentOutOfRangeException("openDayAdd - negative number");
            }

            dt = dt.Date; //we don't care about time part
            int currentAddDay = 0;

            if (!sameDay)
            {
                dt = dt.AddDays(1);
            }

            //loops through opendaysubtract
            while (openDayAdd >= currentAddDay)
            {
                //Mon-Fri and not bank holiday and not the final day
                if (IsWorkingDay(holidayCalendar, dt) && openDayAdd != currentAddDay)
                {
                    dt = dt.AddDays(1);
                    currentAddDay++;
                }
                //Mon-Fri and not bank holiday and the final day
                else if (IsWorkingDay(holidayCalendar, dt))
                    currentAddDay++;
                //it's Saturday, so skip to Monday
                else if (dt.DayOfWeek == DayOfWeek.Saturday)
                    dt = dt.AddDays(2);
                //it's Sunday, so skip to Monday
                else if (dt.DayOfWeek == DayOfWeek.Sunday)
                    dt = dt.AddDays(1);
                //it's Friday (bank holiday), so skip to Monday
                else if (dt.DayOfWeek == DayOfWeek.Friday)
                    dt = dt.AddDays(3);
                //it's Mon-Thu (bank holiday), so next day
                else
                    dt = dt.AddDays(1);
                //any of the addDays should now loop and retest
            }
            return dt;
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before the specified date (or the same date)
        /// </summary>
        /// <param name="holidayCalendar">The holiday calendar.</param>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="sameDay">If we can return same date</param>
        /// <returns>
        /// A date that is a working day without time
        /// </returns>
        public static DateTime PreviousWorkingDay(IPublicHolidays holidayCalendar, DateTime dt, bool sameDay = true)
        {
            return PreviousWorkingDay(holidayCalendar, dt, 0, sameDay);
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before x day of the specified date (or the same date)
        /// </summary>
        /// <param name="holidayCalendar">The holiday calendar.</param>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDaySubstract">The number of open day to substract</param>
        /// <param name="sameDay">If we can return same date</param>
        /// <returns>
        /// A date that is a working day without time
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">opendaysubstract - negative number</exception>
        public static DateTime PreviousWorkingDay(IPublicHolidays holidayCalendar, DateTime dt, int openDaySubstract, bool sameDay = true)
        {
            if (openDaySubstract < 0)
            {
                throw new ArgumentOutOfRangeException("openDaySubstract - negative number");
            }

            dt = dt.Date; //we don't care about time part
            int currentSubstractDay = 0;

            if (!sameDay)
            {
                dt = dt.AddDays(-1);
            }

            //loops through opendaysubstract
            while (openDaySubstract >= currentSubstractDay)
            {
                //Mon-Fri and not bank holiday and not the final day
                if (IsWorkingDay(holidayCalendar, dt) && openDaySubstract != currentSubstractDay)
                {
                    dt = dt.AddDays(-1);
                    currentSubstractDay++;
                }
                //Mon-Fri and not bank holiday and the final day
                else if (IsWorkingDay(holidayCalendar, dt))
                    currentSubstractDay++;
                //it's Sunday, so skip to Friday
                else if (dt.DayOfWeek == DayOfWeek.Sunday)
                    dt = dt.AddDays(-2);
                //it's Saturday, so skip to Friday
                else if (dt.DayOfWeek == DayOfWeek.Saturday)
                    dt = dt.AddDays(-1);
                //it's Monday (bank holiday), so skip to Friday
                else if (dt.DayOfWeek == DayOfWeek.Monday)
                    dt = dt.AddDays(-3);
                //it's Thi-Fr (bank holiday), so previous day
                else
                    dt = dt.AddDays(-1);
            }

            return dt;
        }

        /// <summary>
        /// Adds the given number of business days (initial date not inclusive).
        /// </summary>
        public static DateTime BusinessDaysAdd(IPublicHolidays holidayCalendar, DateTime dt, int businessDays)
        {
            if (businessDays <= 0) return dt;
            var count = 0;
            //initial date is not inclusive, so add 1 day
            dt = dt.AddDays(1);
            while (businessDays > count)
            {
                if (IsWorkingDay(holidayCalendar, dt))
                {
                    count++;
                    if (count == businessDays) break;
                }
                if (dt.DayOfWeek == DayOfWeek.Saturday)
                    dt = dt.AddDays(2);
                else if (dt.DayOfWeek == DayOfWeek.Sunday)
                    dt = dt.AddDays(1);
                else if (dt.DayOfWeek == DayOfWeek.Friday)
                    dt = dt.AddDays(3);
                else
                    dt = dt.AddDays(1);
            }
            return dt;
        }

        /// <summary>
        /// Counts the business days between two dates (inclusive).
        /// </summary>
        public static int BusinessDaysBetween(IPublicHolidays holidayCalendar, DateTime start, DateTime end)
        {
            if (end <= start) return 0;
            var count = 0;
            var dt = start;

            while (dt <= end)
            {
                if (IsWorkingDay(holidayCalendar, dt))
                {
                    count++;
                }
                if (dt.DayOfWeek == DayOfWeek.Saturday)
                    dt = dt.AddDays(2);
                else if (dt.DayOfWeek == DayOfWeek.Sunday)
                    dt = dt.AddDays(1);
                else if (dt.DayOfWeek == DayOfWeek.Friday)
                    dt = dt.AddDays(3);
                else
                    dt = dt.AddDays(1);
            }

            return count;
        }
    }
}
