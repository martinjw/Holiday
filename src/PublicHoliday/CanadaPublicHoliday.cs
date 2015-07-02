using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Canada federal public (statutory) Holidays. Adjusted for weekends.
    /// <description>
    /// Federally regulated workers are entitled to nine paid statutory holidays every year –
    /// New Year’s Day, Good Friday, Victoria Day, Canada Day, Labour Day, Thanksgiving Day, Remembrance Day, Christmas Day, and Boxing Day.
    /// See http://www.hrsdc.gc.ca/eng/labour/overviews/employment_standards/holidays.shtml
    /// <para>When New Year’s Day, Canada Day, Remembrance Day, Christmas Day or Boxing Day fall on a Saturday or Sunday that are not normal work days, workers are entitled to a holiday with pay on the working day immediately before or after the holiday</para>
    /// <para>There are additional regional and provincal dates, and not all federal holidays may be observed by private businesses. Banks follow the federal holidays, however.</para>
    /// </description>
    /// </summary>
    /// <remarks>
    /// Federal nation-wide holidays only. Provincal holidays (eg Family Day in Feb) are excluded and are not observed by Federal employees.
    /// </remarks>
    public class CanadaPublicHoliday : IPublicHolidays
    {
        #region Individual Holidays
        /// <summary>
        /// Christmas day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 25);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime BoxingDay(int year)
        {
            DateTime hol = new DateTime(year, 12, 26);
            //if Xmas=Sun, it's shifted to Mon and 26 also gets shifted
            bool isSundayOrMonday =
                hol.DayOfWeek == DayOfWeek.Sunday ||
                hol.DayOfWeek == DayOfWeek.Monday;
            hol = HolidayCalculator.FixWeekend(hol);
            if (isSundayOrMonday)
                hol = hol.AddDays(1);
            return hol;
        }

        /// <summary>
        /// Date of New Year bank holiday.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            var hol = new DateTime(year, 1, 1);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Canada day, 1 July or following Monday 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime CanadaDay(int year)
        {
            var hol = new DateTime(year, 7, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }
        /// <summary>
        /// Monday on or before May 24
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime VictoriaDay(int year)
        {
            var hol = new DateTime(year, 5, 24);
            //skip back to previous Monday
            while (hol.DayOfWeek != DayOfWeek.Monday)
            {
                hol = hol.AddDays(-1);
            }
            return hol;
        }

        /// <summary>
        /// First Monday in August. Only available in certain provinces, under different names- Saskatchewan day,  Regatta Day 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime CivicHoliday(int year)
        {
            var hol = new DateTime(year, 8, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// First Monday in September
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime LabourDay(int year)
        {
            var hol = new DateTime(year, 9, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Second Monday in October
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Thanksgiving(int year)
        {
            var hol = new DateTime(year, 10, 8);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// November 11
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime RemembranceDay(int year)
        {
            var hol = new DateTime(year, 11, 11);
            hol = HolidayCalculator.FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        /// <summary>
        /// Easter Monday (Monday after Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime EasterMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }
        /// <summary>
        /// Private overloads of GoodFriday and EasterMonday reusing Easter calculation
        /// </summary>
        private static DateTime GoodFriday(DateTime easter)
        {
            var hol = easter.AddDays(-2);
            return hol;
        }
        private static DateTime EasterMonday(DateTime easter)
        {
            var hol = easter.AddDays(1);
            return hol;
        }
        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of bank holidays</returns>
        public virtual IList<DateTime> PublicHolidays(int year)
        {
            var bHols = new List<DateTime>();
            bHols.Add(NewYear(year));

            var easter = HolidayCalculator.GetEaster(year);
            bHols.Add(GoodFriday(easter));
            bHols.Add(EasterMonday(easter));
            bHols.Add(VictoriaDay(year));
            bHols.Add(CanadaDay(year));
            bHols.Add(LabourDay(year));
            bHols.Add(Thanksgiving(year));
            bHols.Add(RemembranceDay(year));
            bHols.Add(Christmas(year));
            bHols.Add(BoxingDay(year));
            return bHols;
        }
        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Dictionary of bank holidays</returns>
        public virtual IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "New Year");

            var easter = HolidayCalculator.GetEaster(year);
            bHols.Add(GoodFriday(easter), "Good Friday");
            bHols.Add(EasterMonday(easter), "Easter Monday");
            bHols.Add(VictoriaDay(year), "Victoria Day");
            bHols.Add(CanadaDay(year), "Canada Day");
            bHols.Add(LabourDay(year), "Labour Day");
            bHols.Add(Thanksgiving(year), "Thanksgiving");
            bHols.Add(RemembranceDay(year), "Remembrance Day");
            bHols.Add(Christmas(year), "Christmas");
            bHols.Add(BoxingDay(year), "Boxing Day");
            return bHols;
        }

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
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>
        /// True if date is a bank holiday (excluding weekends)
        /// </returns>
        public virtual bool IsPublicHoliday(DateTime dt)
        {
            return IsPublicHoliday(dt, null);
        }

        private static bool IsPublicHoliday(DateTime dt, DateTime? easter)
        {
            int year = dt.Year;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == dt)
                        return true;
                    break;
                case 3:
                case 4:
                    //only Mondays and Fridays are bank holidays
                    if (dt.DayOfWeek != DayOfWeek.Monday &&
                        dt.DayOfWeek != DayOfWeek.Friday)
                        return false;
                    //easter can be in March or April
                    var easterDate = !easter.HasValue ? HolidayCalculator.GetEaster(year) : easter.Value;
                    if (GoodFriday(easterDate) == dt)
                        return true;
                    if (EasterMonday(easterDate) == dt)
                        return true;
                    break;
                case 5:
                    if (dt.DayOfWeek != DayOfWeek.Monday) 
                        return false;
                    if (VictoriaDay(year) == dt)
                        return true;
                    break;
                case 7:
                    if (CanadaDay(year) == dt)
                        return true;
                    break;
                case 9:
                    if (dt.DayOfWeek != DayOfWeek.Monday) 
                        return false;
                    if (LabourDay(year) == dt)
                        return true;
                    break;
                case 10:
                    if (dt.DayOfWeek != DayOfWeek.Monday) 
                        return false;
                    if (Thanksgiving(year) == dt)
                        return true;
                    break;
                case 11:
                    if (RemembranceDay(year) == dt)
                        return true;
                    break;
                case 12:
                    if (Christmas(year) == dt)
                        return true;
                    if (BoxingDay(year) == dt)
                        return true;
                    break;
            }

            return false;
        }
    }
}

