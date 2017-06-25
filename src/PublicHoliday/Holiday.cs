using System;

namespace PublicHoliday
{
    /// <summary>
    /// A holiday
    /// </summary>
    public class Holiday
    {
        /// <summary>
        /// Constructs the holiday
        /// </summary>
        /// <param name="date">The date of the current holiday</param>
        /// <param name="observedDate">The date the current holiday is obesrved on</param>
        public Holiday(DateTime date, DateTime observedDate)
        {
            HolidayDate = date;
            ObservedDate = observedDate;
        }

        /// <summary>
        /// The date the Holiday is actually observed on
        /// </summary>
        public DateTime ObservedDate { get; set; }

        /// <summary>
        /// Date for the current holiday
        /// </summary>
        public DateTime HolidayDate { get; set; }

        /// <summary>
        /// Implicitly casts a holiday as its observed date
        /// </summary>
        /// <param name="h">The holiday</param>
        public static implicit operator DateTime(Holiday h)
        {
            return h.ObservedDate;
        }
    }
}