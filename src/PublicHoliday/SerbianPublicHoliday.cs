using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Serbia
    /// Taken from official government page https://neradni-dani.com/kalendar-2023-srb.php
    /// </summary>
    /// <seealso cref="PublicHoliday.PublicHolidayBase" />
    public class SerbianPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// New Year's Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearFirst(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// New Year's Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearSecond(int year)
        {
            return new DateTime(year, 1, 2);
        }

        /// <summary>
        /// Christmas.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 1, 7);
        }

        /// <summary>
        /// National Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDayFirst(int year)
        {
            return new DateTime(year, 2, 15);
        }
        
        /// <summary>
        /// National Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDaySecond(int year)
        {
            return new DateTime(year, 2, 16);
        }
        
        /// <summary>
        /// Good Friday - Friday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        /// <summary>
        /// Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Easter(int year)
        {
            return HolidayCalculator.GetEaster(year);
        }

        /// <summary>
        /// Easter Monday 1st Monday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return easter.AddDays(1);
        }
        
        /// <summary>
        /// Labor Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDayFirst(int year)
        {
            return new DateTime(year, 5, 1);
        }
        
        /// <summary>
        /// Labour Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDaySecond(int year)
        {
            return new DateTime(year, 5, 2);
        }

        /// <summary>
        /// Armistice Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ArmisticeDay(int year)
        {
            return new DateTime(year, 11, 11);
        }
        
        #endregion
        
        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            var easter = HolidayCalculator.GetEaster(year);
            return new List<DateTime>
            {
                NewYearFirst(year),
                NewYearSecond(year),
                Christmas(year),
                NationalDayFirst(year),
                NationalDaySecond(year),
                GoodFriday(easter),
                easter,
                EasterMonday(easter),
                LabourDayFirst(year),
                LabourDaySecond(year),
                ArmisticeDay(year)
            };
        }

        /// <summary>
        /// Public holiday names in Serbia.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var easter = HolidayCalculator.GetEaster(year);
            return new Dictionary<DateTime, string>
            {
                {NewYearFirst(year), "Нова година"},
                {NewYearSecond(year), "Нова година"},
                {Christmas(year), "Божић"},
                {NationalDayFirst(year), "Дан државности Србије"},
                {NationalDaySecond(year), "Дан државности Србије"},
                {GoodFriday(easter), "Велики петак"},
                {easter, "Васкрс"},
                {EasterMonday(easter), "Васкрсни понедељак"},
                {LabourDayFirst(year), "Празник рада"},
                {LabourDaySecond(year), "Празник рада"},
                {ArmisticeDay(year), "Дан примирја"}
            };
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the PublicHoliday list is more efficient for repeated checks
        /// Note holidays can fall on weekends and there is no fixed moving of such dates.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            var year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if (NewYearFirst(year) == date || NewYearSecond(year) == date || Christmas(year) == date) return true;
                    break;
                case 2:
                    if (NationalDayFirst(year) == date || NationalDaySecond(year) == date) return true;
                    break;
                case 3:
                case 4:
                    if (EasterMonday(year) == date || Easter(year) == date || GoodFriday(year) == date) return true;
                    break;
                case 5:
                    if (LabourDayFirst(year) == date || LabourDaySecond(year) == date) return true;
                    break;
                case 11:
                    if (ArmisticeDay(year) == date) return true;
                    break;
            }

            return false;
        }
    }
}