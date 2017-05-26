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
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public abstract IList<DateTime> PublicHolidays(int year);

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
        public DateTime PreviousWorkingDay(DateTime dt)
        {
            return HolidayCalculator.PreviousWorkingDay(this, dt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IList<Holiday> GetHolidaysInDateRange(DateTime startDate, DateTime endDate)
        {
            IList<Holiday> holidaysInDateRange = new List<Holiday>();
            for (int year = startDate.Year; year <= endDate.Year; year++)
            {
                var yearsHolidaysInRange = PublicHolidayNames(year).Where(d => d.Key >= startDate && d.Key <= endDate);
                foreach (var kvp in yearsHolidaysInRange)
                {
                    holidaysInDateRange.Add(new Holiday(this, kvp.Key, kvp.Value));
                }
            }
            return holidaysInDateRange;
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