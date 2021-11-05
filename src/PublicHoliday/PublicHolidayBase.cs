using System;
using System.Collections.Generic;
using System.Linq;

#if NETSTANDARD1_0_OR_GREATER || NET40_OR_GREATER || NETCOREAPP1_0_OR_GREATER
using System.Collections.Concurrent;
#endif

namespace PublicHoliday
{

    /// <summary>
    /// Public Holiday operations
    /// </summary>
    /// <seealso cref="PublicHoliday.IPublicHolidays" />
    public abstract class PublicHolidayBase : IPublicHolidays
    {
        /// <summary>
        /// Determines whether to use the cache if available
        /// </summary>
        public bool UseCachingHolidays { get; set; } = false;

#if NETSTANDARD1_0_OR_GREATER || NET40_OR_GREATER || NETCOREAPP1_0_OR_GREATER
        /// <summary>
        /// Cache by year of holidays for performance.
        /// </summary>
        internal static readonly ConcurrentDictionary<int, IList<Holiday>> _cacheHolidays = new ConcurrentDictionary<int, IList<Holiday>>();
#endif

        /// <summary>
        /// Returns whether todays date is a working day
        /// </summary>
        /// <returns>A boolean of whether today is a working day</returns>
        public virtual bool IsWorkingDay()
        {
            return IsWorkingDay(DateTime.Now);
        }

        /// <summary>
        /// Returns whether the specified date is a working day
        /// </summary>
        /// <param name="dt">The date to be checked</param>
        /// <returns>Returns a boolean of whether the specified date is a working day</returns>
        public virtual bool IsWorkingDay(DateTime dt)
        {
            return HolidayCalculator.IsWorkingDay(this, dt);
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public abstract IList<DateTime> PublicHolidays(int year);

        /// <summary>
        /// Returns observed and holiday dates for all holidays
        /// </summary>
        /// <param name="year">The current year</param>
        /// <returns>A list of observed holidays</returns>
        public virtual IList<Holiday> PublicHolidaysInformation(int year)
        {
            return PublicHolidays(year).Select(d => new Holiday(d, d)).ToList();
        }

        /// <summary>
        /// Get a list of dates with names for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Dictionary of bank holidays
        /// </returns>
        public abstract IDictionary<DateTime, string> PublicHolidayNames(int year);

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        public virtual DateTime NextWorkingDay(DateTime dt)
        {
            return HolidayCalculator.NextWorkingDay(this, dt);
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after the specified date (not the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        public virtual DateTime NextWorkingDayNotSameDay(DateTime dt)
        {
            return HolidayCalculator.NextWorkingDay(this, dt, false);
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after x day of the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDayAdd">The number of open day to add</param>
        /// <returns>A date that is a working day</returns>
        public DateTime NextWorkingDay(DateTime dt, int openDayAdd)
        {
            return HolidayCalculator.NextWorkingDay(this, dt, openDayAdd);
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after x day of the specified date (not the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDayAdd">The number of open day to add</param>
        /// <returns>A date that is a working day</returns>
        public DateTime NextWorkingDayNotSameDay(DateTime dt, int openDayAdd)
        {
            return HolidayCalculator.NextWorkingDay(this, dt, openDayAdd, false);
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        public virtual DateTime PreviousWorkingDay(DateTime dt)
        {
            return HolidayCalculator.PreviousWorkingDay(this, dt);
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before the specified date (not the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        public virtual DateTime PreviousWorkingDayNotSameDay(DateTime dt)
        {
            return HolidayCalculator.PreviousWorkingDay(this, dt, false);
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before x day of the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDaySubstract">The number of open day to substract</param>
        /// <returns>A date that is a working day</returns>
        public DateTime PreviousWorkingDay(DateTime dt, int openDaySubstract)
        {
            return HolidayCalculator.PreviousWorkingDay(this, dt, openDaySubstract);
        }

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before x day of the specified date (not the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <param name="openDaySubstract">The number of open day to substract</param>
        /// <returns>A date that is a working day</returns>
        public DateTime PreviousWorkingDayNotSameDay(DateTime dt, int openDaySubstract)
        {
            return HolidayCalculator.PreviousWorkingDay(this, dt, openDaySubstract, false);
        }

        /// <summary>
        /// Gets Holidays between two date times.
        /// </summary>
        /// <param name="startDate">The beginning of the date range</param>
        /// <param name="endDate">The end of the date range</param>
        /// <returns>A list of holidays between the two dates</returns>
        public IList<Holiday> GetHolidaysInDateRange(DateTime startDate, DateTime endDate)
        {
            var holidays = new List<Holiday>();
            for (var year = startDate.Year; year <= endDate.Year; year++)
            {
                holidays.AddRange(PublicHolidaysInformation(year)
                                      .Where(d => d.ObservedDate >= startDate && d.ObservedDate <= endDate ||
                                                  d.HolidayDate >= startDate && d.HolidayDate <= endDate));
            }
            return holidays;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the <see cref="PublicHolidays" /> list is more efficient for repeated checks
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>
        /// True if date is a public holiday (excluding weekends)
        /// </returns>
        public abstract bool IsPublicHoliday(DateTime dt);

    }
}
