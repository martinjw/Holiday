using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays
    /// </summary>
    public interface IPublicHolidays
    {
        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        IList<DateTime> PublicHolidays(int year);

        /// <summary>
        /// Returns observed and holiday dates for all holidays
        /// </summary>
        /// <param name="year">The current year</param>
        /// <returns>A list of observed holidays</returns>
        IList<Holiday> PublicHolidaysInformation(int year);

        /// <summary>
        /// Get a list of dates with names for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Dictionary of bank holidays</returns>
        IDictionary<DateTime, string> PublicHolidayNames(int year);

        /// <summary>
        /// Returns the next working day (Mon-Fri, not public holiday)
        /// after the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        DateTime NextWorkingDay(DateTime dt);

        /// <summary>
        /// Returns the previous working day (Mon-Fri, not public holiday)
        /// before the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        DateTime PreviousWorkingDay(DateTime dt);

        /// <summary>
        /// Gets Holidays between two date times.
        /// </summary>
        /// <param name="startDate">The beginning of the date range</param>
        /// <param name="endDate">The end of the date range</param>
        /// <returns>A list of holidays</returns>
        IList<Holiday> GetHolidaysInDateRange(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the <see cref="PublicHolidays"/> list is more efficient for repeated checks
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday (excluding weekends)</returns>
        bool IsPublicHoliday(DateTime dt);
    }
}
