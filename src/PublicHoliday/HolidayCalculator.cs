﻿using System;

#if NETSTANDARD1_0_OR_GREATER || NET40_OR_GREATER || NETCOREAPP1_0_OR_GREATER
using System.Collections.Concurrent;
#endif

namespace PublicHoliday
{
    /// <summary>
    /// Work out the date for Easter Sunday for specified year
    /// </summary>
    static class HolidayCalculator
    {

#if NETSTANDARD1_0_OR_GREATER || NET40_OR_GREATER || NETCOREAPP1_0_OR_GREATER
        private static readonly ConcurrentDictionary<int, DateTime> _cache = new ConcurrentDictionary<int, DateTime>();
#endif

        /// <summary>
        /// Work out the date for Easter Sunday for specified year
        /// </summary>
        /// <param name="year">The year as an integer</param>
        /// <returns>Returns a datetime of Easter Sunday.</returns>
        public static DateTime GetEaster(int year)
        {

#if NETSTANDARD1_3_OR_GREATER || NET40_OR_GREATER
            return _cache.GetOrAdd(year, y =>
            {
                return GetEasterPrivate(year);
            });

#else
                return GetEasterPrivate(year);
#endif

        }

        /// <summary>
        /// Work out the date for Easter Sunday for specified year
        /// </summary>
        /// <param name="year">The year as an integer</param>
        /// <returns>Returns a datetime of Easter Sunday.</returns>
        private static DateTime GetEasterPrivate(int year)
        {
            //should be
            //Easter Monday  28 Mar 2005  17 Apr 2006  9 Apr 2007  24 Mar 2008

            //Oudin's Algorithm - http://www.smart.net/~mmontes/oudin.html

            var g = year % 19;
            var c = year / 100;
            var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));
            var j = (year + year / 4 + i + 2 - c + c / 4) % 7;
            var p = i - j;
            var easterDay = 1 + (p + 27 + (p + 6) / 40) % 31;
            var easterMonth = 3 + (p + 26) / 30;

            return new DateTime(year, easterMonth, easterDay);
        }

        /// <summary>
        /// Work out the date for Orthodox Easter Sunday for specified year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GetOrthodoxEaster(int year)
        {
            // credits https://gist.github.com/georgekosmidis/7f2cbabbd57ef879e95d990f0c356106#file-getorthodoxeaster-cs
            var a = year % 19;
            var b = year % 7;
            var c = year % 4;

            var d = (19 * a + 16) % 30;
            var e = (2 * c + 4 * b + 6 * d) % 7;
            var f = (19 * a + 16) % 30;

            var key = f + e + 3;
            var month = (key > 30) ? 5 : 4;
            var day = (key > 30) ? key - 30 : key;

            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Fix weekend to monday.
        /// </summary>
        /// <param name="hol"></param>
        /// <returns></returns>
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
        /// <param name="hol"></param>
        /// <returns></returns>
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
        /// <param name="hol"></param>
        /// <returns></returns>
        public static DateTime FixWeekendSundayAfter(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            return hol;
        }

        /// <summary>
        /// Fix Weekend for the after of two holiday consecutive with standard FixWeekend to monday.
        /// </summary>
        /// <param name="hol"></param>
        /// <returns></returns>
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
        /// <param name="hol"></param>
        /// <returns></returns>
        public static DateTime FixWeekendTwoHolidayBefore(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Saturday)
                hol = hol.AddDays(-1);
            else if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(-2);
            return hol;
        }

        public static DateTime FindOccurrenceOfDayOfWeek(DateTime hol, DayOfWeek day, short occurance)
        {
            while (hol.DayOfWeek != day)
                hol = hol.AddDays(1);

            hol = hol.AddDays(7 * (occurance - 1));

            return hol;
        }

        public static DateTime FindNearestDayOfWeek(DateTime hol, DayOfWeek day)
        {
            int advance = 0;
            while (((int)hol.DayOfWeek + advance) % 7 != (int)day)
                advance++;

            if (advance > 3)
                return hol.AddDays(advance - 7);
            else return hol.AddDays(advance);
        }

        public static DateTime FindFirstMonday(DateTime hol)
        {
            return FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Monday, 1);
        }
        public static DateTime GetFirstFridayBeforeDate(DateTime date)
        {
            // Calculate the difference in days between the target day (Friday) and the current day of the week
            int daysToSubtract = ((int)date.DayOfWeek - (int)DayOfWeek.Friday + 7) % 7;

            // Subtract the calculated number of days from the input date
            DateTime resultDate = date.AddDays(-daysToSubtract);

            return resultDate;
        }

        public static DateTime FindPrevious(DateTime hol, DayOfWeek day)
        {
            while (hol.DayOfWeek != day)
                hol = hol.AddDays(-1);

            return hol;
        }

        public static DateTime FindNext(DateTime hol, DayOfWeek day)
        {
            while (hol.DayOfWeek != day)
                hol = hol.AddDays(1);

            return hol;
        }

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

            //loops through opendaysubstract
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
                if (IsWorkingDay(holidayCalendar, dt)  && openDaySubstract != currentSubstractDay)
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

    }
}
