using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    public abstract class PublicHolidayBase : IPublicHolidays
    {
        public abstract IList<DateTime> PublicHolidays(int year);
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

        public abstract bool IsPublicHoliday(DateTime dt);
    }
}
