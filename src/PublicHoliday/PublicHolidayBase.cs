using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    using System.Linq;

    /// <summary>
    /// Public Holiday operations
    /// </summary>
    /// <seealso cref="PublicHoliday.IPublicHolidays" />
    public abstract class PublicHolidayBase : IPublicHolidays
    {
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
