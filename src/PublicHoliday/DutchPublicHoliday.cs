using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    public class DutchPublicHoliday : IPublicHolidays
    {

        #region Individual Holidays

        /// <summary>
        /// New Year's Day January 1 - Nieuwjaarsdag
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Easter Monday 1st Monday after Easter - Paasmaandag
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
        /// Kingsday/Queensday - Koningsdag/Koninginnendag
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime KingsDay(int year)
        {
            var date = new DateTime(year, 4, 27);
            if (year < 1949)
            {
                date = new DateTime(year, 8, 31);
            }
            else if (year < 2014)
            {
                date = new DateTime(year, 4, 30);
            }

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(-1);
            }

            return date;
        }

        /// <summary>
        /// Liberation Day May 5 - Bevrijdingsdag
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime? LiberationDay(int year)
        {
            if (year % 5 == 0)
            {
                return new DateTime(year, 5, 5);
            }
            
            return null;
        }

        /// <summary>
        /// Ascension 6th Thursday after Easter - Hemelvaartsdag
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Ascension(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(4 + (7 * 5));
            return hol;
        }

        private static DateTime Ascension(DateTime easter)
        {
            return easter.AddDays(4 + (7 * 5));
        }

        /// <summary>
        /// Whit Monday - Pentecost Monday 7th Monday after Easter - Pinkstermaandag
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime PentecostMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays((7 * 7) + 1);
            return hol;
        }

        private static DateTime PentecostMonday(DateTime easter)
        {
            return easter.AddDays(1 + (7 * 7));
        }

        /// <summary>
        /// Christmas - December 25 - Eerste Kerstdag
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Boxing Day - December 26 - Tweede Kerstdag
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime BoxingDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public virtual IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Select(x => x.Key).OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Public holiday names in Dutch.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public virtual IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "Nieuwjaar");
            DateTime easter = HolidayCalculator.GetEaster(year);
            bHols.Add(EasterMonday(easter), "Paasmaandag");
            bHols.Add(KingsDay(year), "Koningsdag");
            var liberationDay = LiberationDay(year);
            if (liberationDay != null)
            {
                bHols.Add(liberationDay.Value, "Bevrijdingsdag");
            }
            bHols.Add(Ascension(easter), "Hemelvaartsdag");
            bHols.Add(PentecostMonday(easter), "Pinkstermaandag");
            bHols.Add(Christmas(year), "Eerste Kerstdag");
            bHols.Add(BoxingDay(year), "Tweede Kerstdag");
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
        /// Obviously the PublicHoliday list is more efficient for repeated checks
        /// Note holidays can fall on weekends and there is no fixed moving of such dates.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public virtual bool IsPublicHoliday(DateTime dt)
        {
            var year = dt.Year;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == dt)
                        return true;
                    break;
                case 3:
                case 4:
                case 8:
                    if (EasterMonday(year) == dt)
                        return true;
                    if (KingsDay(year) == dt) // Usually April 27, but historically also in August
                        return true;
                    break;
                case 5:
                    if (LiberationDay(year) == dt)
                        return true;
                    if (Ascension(year) == dt)
                        return true; // usually in May (may 25, 2006)
                    if (PentecostMonday(year) == dt)
                        return true; // May 20 2004
                    break;
                case 6:
                    if (Ascension(year) == dt)
                        return true; // Ascension was June 1 2000
                    if (PentecostMonday(year) == dt)
                        return true; // June 12 2006
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
