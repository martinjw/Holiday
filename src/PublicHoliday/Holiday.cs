using System;

namespace PublicHoliday
{
    /// <summary>
    /// A holiday
    /// </summary>
    public class Holiday
    {
        private readonly IPublicHolidays _holidayCalendar;

        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="holidayCalendar">A holiday calendar object</param>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="name">The name of the current holiday</param>
        public Holiday(IPublicHolidays holidayCalendar, DateTime date, string name)
        {
            this._holidayCalendar = holidayCalendar;
            this.HolidayDate = date;
            this.Name = name;
        }

        /// <summary>
        /// The previous working day for the holiday
        /// </summary>
        public DateTime PreviousWorkingDay
        {
            get { return _holidayCalendar.PreviousWorkingDay(HolidayDate); }
        }

        /// <summary>
        /// The next working day after the holiday
        /// </summary>
        public DateTime NextWorkingDay
        {
            get { return _holidayCalendar.NextWorkingDay(HolidayDate); }
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
