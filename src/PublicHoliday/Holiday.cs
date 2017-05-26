using System;
using System.Collections.Generic;
using System.Text;

namespace PublicHoliday
{
    /// <summary>
    /// A holiday
    /// </summary>
    public class Holiday
    {
        private IPublicHolidays holidayCalendar;

        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="holidayCalendar">A holiday calendar object</param>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="name">The name of the current holiday</param>
        public Holiday(IPublicHolidays holidayCalendar, DateTime date, string name)
        {
            this.holidayCalendar = holidayCalendar;
            this.HolidayDate = date;
            this.Name = name;
        }

        /// <summary>
        /// The previous working day for the holiday
        /// </summary>
        public DateTime PreviousWorkingDay
        {
            get { return holidayCalendar.PreviousWorkingDay(HolidayDate); }
        }

        /// <summary>
        /// The next working day after the holiday
        /// </summary>
        public DateTime NextWorkingDay
        {
            get { return holidayCalendar.NextWorkingDay(HolidayDate); }
        }

        /// <summary>
        /// Date for the current holiday
        /// </summary>
        public DateTime HolidayDate { get; set; }

        /// <summary>
        /// Name of the current holiday
        /// </summary>
        public string Name { get; set; }
    }
}
