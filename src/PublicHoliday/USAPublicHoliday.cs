using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Federal Holidays in the US
    /// If a holiday falls on a Saturday it is celebrated the preceding Friday;
    /// if a holiday falls on a Sunday it is celebrated the following Monday.
    /// </summary>
    public class USAPublicHoliday : IPublicHolidays
    {
        #region Holiday Adjustments
        private static DateTime FixWeekend(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            else if (hol.DayOfWeek == DayOfWeek.Saturday)
                hol = hol.AddDays(-1);
            return hol;
        }
        #endregion

        #region Individual Holidays

        /// <summary>
        /// New Years Day. Note in 1999 and 2005 it was 31st December
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            return FixWeekend(new DateTime(year, 1, 1));
        }

        /// <summary>
        /// Third Monday in January
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime MartinLutherKing(int year)
        {
            var hol = new DateTime(year, 1, 15);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Washington's Birthday aka Presidents Day. Third Monday in February
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime PresidentsDay(int year)
        {
            var hol = new DateTime(year, 2, 15);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Last Monday in May
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime MemorialDay(int year)
        {
            var hol = new DateTime(year, 5, 25);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Independence Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime IndependenceDay(int year)
        {
            var hol = new DateTime(year, 7, 4);
            hol = FixWeekend(hol);
            return hol;
        }

        /// <summary>
        /// First Monday in September
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime LaborDay(int year)
        {
            var hol = new DateTime(year, 9, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Second Monday in October
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime ColumbusDay(int year)
        {
            var hol = new DateTime(year, 10, 8);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// 11 November
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime VeteransDay(int year)
        {
            return FixWeekend(new DateTime(year, 11, 11));
        }

        /// <summary>
        /// Thanksgiving - Fourth Thursday in November
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime Thanksgiving(int year)
        {
            var hol = new DateTime(year, 11, 23);
            while (hol.DayOfWeek != DayOfWeek.Thursday)
            {
                hol = hol.AddDays(1);
            }
            return hol;
        }

        /// <summary>
        /// Christmas Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return FixWeekend(new DateTime(year, 12, 25));
        }
        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public virtual IList<DateTime> PublicHolidays(int year)
        {
            var bHols = new List<DateTime>();
            bHols.Add(NewYear(year)); //1st January
            bHols.Add(MartinLutherKing(year)); // Third Monday in January
            bHols.Add(PresidentsDay(year)); //Third Monday in February
            bHols.Add(MemorialDay(year)); //Last Monday in May
            bHols.Add(IndependenceDay(year)); //4 July
            bHols.Add(LaborDay(year)); //First Monday in September
            bHols.Add(ColumbusDay(year)); //Second Monday in October
            bHols.Add(VeteransDay(year)); //11 November
            bHols.Add(Thanksgiving(year)); //Fourth Thursday in November
            bHols.Add(Christmas(year)); //25 December
            return bHols;
        }

        /// <summary>
        /// Get a list of dates with names for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public virtual IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "New Year"); //1st January
            bHols.Add(MartinLutherKing(year), "Martin Luther King Day"); // Third Monday in January
            bHols.Add(PresidentsDay(year), "President's Day"); //Third Monday in February
            bHols.Add(MemorialDay(year), "Memorial Day"); //Last Monday in May
            bHols.Add(IndependenceDay(year), "Independence Day"); //4 July
            bHols.Add(LaborDay(year), "Labor Day"); //First Monday in September
            bHols.Add(ColumbusDay(year), "Columbus Day"); //Second Monday in October
            bHols.Add(VeteransDay(year), "Veteran's Day"); //11 November
            bHols.Add(Thanksgiving(year), "Thanksgiving"); //Fourth Thursday in November
            bHols.Add(Christmas(year), "Christmas"); //25 December
            return bHols;
        }
        /// <summary>
        /// Check if a specific date is a federal holiday.
        /// Obviously the PublicHoliday list is more efficient for repeated checks
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a federal holiday (excluding weekends)</returns>
        public virtual bool IsPublicHoliday(DateTime dt)
        {
            int year = dt.Year;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == dt)
                        return true;
                    if (MartinLutherKing(year) == dt)
                        return true;
                    break;
                case 2:
                    if (PresidentsDay(year) == dt)
                        return true;
                    break;
                case 5:
                    if (MemorialDay(year) == dt)
                        return true;
                    break;
                case 7:
                    if (IndependenceDay(year) == dt)
                        return true;
                    break;
                case 9:
                    if (LaborDay(year) == dt)
                        return true;
                    break;
                case 10:
                    if (ColumbusDay(year) == dt)
                        return true;
                    break;
                case 11:
                    if (VeteransDay(year) == dt)
                        return true;
                    if (Thanksgiving(year) == dt)
                        return true;
                    break;
                case 12:
                    if (Christmas(year) == dt)
                        return true;
                    if (NewYear(year + 1) == dt)
                        return true; //31st December if New Year is Saturday
                    break;
            }
            return false;
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
    }
}
