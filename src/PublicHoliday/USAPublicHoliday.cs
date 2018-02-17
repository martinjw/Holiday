using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Federal Holidays in the US
    /// If a holiday falls on a Saturday it is celebrated the preceding Friday;
    /// if a holiday falls on a Sunday it is celebrated the following Monday.
    /// </summary>
    public class USAPublicHoliday : PublicHolidayBase
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
        public static Holiday NewYear(int year)
        {
            var holiday = new DateTime(year, 1, 1);
            return new Holiday(holiday, FixWeekend(holiday));
        }

        /// <summary>
        /// Third Monday in January
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday MartinLutherKing(int year)
        {
            var hol = new DateTime(year, 1, 15);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol);
        }

        /// <summary>
        /// Washington's Birthday aka Presidents Day. Third Monday in February
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday PresidentsDay(int year)
        {
            var hol = new DateTime(year, 2, 15);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol);
        }

        /// <summary>
        /// Last Monday in May
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday MemorialDay(int year)
        {
            var hol = new DateTime(year, 5, 25);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol);
        }

        /// <summary>
        /// Independence Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday IndependenceDay(int year)
        {
            var hol = new DateTime(year, 7, 4);
            var observed = FixWeekend(hol);
            return new Holiday(hol, observed);
        }

        /// <summary>
        /// First Monday in September
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday LaborDay(int year)
        {
            var hol = new DateTime(year, 9, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol);
        }

        /// <summary>
        /// Second Monday in October
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday ColumbusDay(int year)
        {
            var hol = new DateTime(year, 10, 8);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol);
        }

        /// <summary>
        /// 11 November
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday VeteransDay(int year)
        {
            var hol = new DateTime(year, 11, 11);
            return new Holiday(hol, FixWeekend(hol));
        }

        /// <summary>
        /// Thanksgiving - Fourth Thursday in November
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday Thanksgiving(int year)
        {
            var hol = new DateTime(year, 11, 22);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Thursday, 1);
            return new Holiday(hol, hol);
        }

        /// <summary>
        /// Christmas Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday Christmas(int year)
        {
            var hol = new DateTime(year, 12, 25);
            return new Holiday(hol, FixWeekend(hol));
        }
        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IList<DateTime> PublicHolidays(int year)
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
        /// Gets a list of public holidays with their observed and actual date
        /// </summary>
        /// <param name="year">The given year</param>
        /// <returns></returns>
        public override IList<Holiday> PublicHolidaysInformation(int year)
        {
            var bHols = new List<Holiday>();
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
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
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
        public override bool IsPublicHoliday(DateTime dt)
        {
            int year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == date)
                        return true;
                    if (MartinLutherKing(year) == date)
                        return true;
                    break;
                case 2:
                    if (PresidentsDay(year) == date)
                        return true;
                    break;
                case 5:
                    if (MemorialDay(year) == date)
                        return true;
                    break;
                case 7:
                    if (IndependenceDay(year) == date)
                        return true;
                    break;
                case 9:
                    if (LaborDay(year) == date)
                        return true;
                    break;
                case 10:
                    if (ColumbusDay(year) == date)
                        return true;
                    break;
                case 11:
                    if (VeteransDay(year) == date)
                        return true;
                    if (Thanksgiving(year) == date)
                        return true;
                    break;
                case 12:
                    if (Christmas(year) == date)
                        return true;
                    if (NewYear(year + 1) == date)
                        return true; //31st December if New Year is Saturday
                    break;
            }
            return false;
        }
    }
}
