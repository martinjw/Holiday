using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Finds UK Bank (public) Holidays. Adjusted for weekends.
    /// <description>
    /// UK Bank Holidays since 1971 Banking and Financial Dealings Act with additions and variations.
    /// See http://www.dti.gov.uk/employment/bank-public-holidays/index.html
    /// <para>Additions: 1974 New Years Day and 1978 May Day</para>
    /// <para>Variations: 1995 VE Day May Day, 2002 Golden Jubilee, 2011 Royal Wedding, 2012 Diamond Jubilee</para>
    /// <para>You can call by IsBankHoliday(date), get the specific holiday name
    /// ( <see cref="Christmas"/>), or a list of dates for the year (<see cref="BankHolidays"/>)</para>
    /// </description>
    /// <example>
    /// listBox1.DataSource = UKBankHoliday.BankHolidays(2006);
    /// //fills listbox with 8 dates- 02/01, 14/04, 17/04, 01/05, 29/05, 28/08, 25/12, 26/12
    ///</example>
    /// </summary>
    public static class UKBankHoliday
    {
        #region Holiday Adjustments
        private static DateTime FixWeekend(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            else if (hol.DayOfWeek == DayOfWeek.Saturday)
                hol = hol.AddDays(2);
            return hol;
        }
        private static DateTime FindFirstMonday(DateTime hol)
        {
            while (hol.DayOfWeek != DayOfWeek.Monday)
            {
                hol = hol.AddDays(1);
            }
            return hol;
        }
        #endregion

        #region Individual Holidays
        /// <summary>
        /// Christmas day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 25);
            hol = FixWeekend(hol);
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
            hol = FixWeekend(hol);
            if (isSundayOrMonday)
                hol = hol.AddDays(1);
            return hol;
        }

        /// <summary>
        /// Date of New Year bank holiday. This is 1974 on only but will return pre 1974 dates.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            //since 1974 only
            DateTime hol = new DateTime(year, 1, 1);
            hol = FixWeekend(hol);
            return hol;
        }
        /// <summary>
        /// Returns "Early Spring"/"May Day" holiday (first Monday in May). Created in 1978.
        /// </summary>
        /// <param name="year"></param>
        /// <returns>(Nullable)date for Early May Bank Holiday (null before 1978)</returns>
        public static DateTime? MayDay(int year)
        {
            //warning- should be null for < 1977
            if (year < 1978) return null;
            if (year == 1995)
                return new DateTime(1995, 5, 8); //1995 moved for 50th anniversary of VE day
            DateTime hol = new DateTime(year, 5, 1);
            hol = FindFirstMonday(hol);
            return hol;
        }
        /// <summary>
        /// The Spring/Last Monday in May holiday (replaced variable Whit Monday in 1971)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Spring(int year)
        {
            if (year == 2002) return new DateTime(2002, 6, 4); //Golden Jubilee of Elizabeth II
            if (year == 2012) return new DateTime(2012, 6, 4); //Queen's Diamond Jubilee
            DateTime hol = new DateTime(year, 5, 24);
            hol = FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Summer bank holiday (last Monday in August)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Summer(int year)
        {
            DateTime hol = new DateTime(year, 8, 25);
            hol = FindFirstMonday(hol);
            return hol;
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GoodFriday(int year)
        {
            DateTime hol = GetEaster(year);
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
            DateTime hol = GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }
        /// <summary>
        /// Private overloads of GoodFriday and EasterMonday reusing Easter calculation
        /// </summary>
        private static DateTime GoodFriday(DateTime easter)
        {
            DateTime hol = easter.AddDays(-2);
            return hol;
        }
        private static DateTime EasterMonday(DateTime easter)
        {
            DateTime hol = easter.AddDays(1);
            return hol;
        }
        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of bank holidays</returns>
        public static IList<DateTime> BankHolidays(int year)
        {
            List<DateTime> bHols = new List<DateTime>();
            if (year > 1973)
                bHols.Add(NewYear(year)); //New Year only in 1974

            DateTime easter = GetEaster(year);
            bHols.Add(GoodFriday(easter));
            bHols.Add(EasterMonday(easter));

            DateTime? dt = MayDay(year);
            if (dt.HasValue)
                bHols.Add(dt.Value);
            bHols.Add(Spring(year));

            if (year == 2002)
                bHols.Add(new DateTime(2002, 6, 3)); //Golden Jubilee of Elizabeth II
            if (year == 2011)
                bHols.Add(new DateTime(2012, 4, 29)); //Royal Wedding
            if (year == 2012)
                bHols.Add(new DateTime(2012, 6, 5)); //Queen's Diamond Jubilee

            bHols.Add(Summer(year));
            bHols.Add(Christmas(year));
            bHols.Add(BoxingDay(year));
            return bHols;
        }
        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Dictionary of bank holidays</returns>
        public static IDictionary<DateTime, string> BankHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            if (year > 1973)
                bHols.Add(NewYear(year), "New Year"); //New Year only in 1974

            DateTime easter = GetEaster(year);
            bHols.Add(GoodFriday(easter), "Good Friday");
            bHols.Add(EasterMonday(easter), "Easter Monday");

            if (year == 2011)
                bHols.Add(new DateTime(2011, 4, 29), "Royal Wedding"); //Royal Wedding

            DateTime? dt = MayDay(year);
            if (dt.HasValue)
                bHols.Add(dt.Value, "Early May");
            bHols.Add(Spring(year), "Spring");

            if (year == 2002)
                bHols.Add(new DateTime(2002, 6, 3), "Golden Jubilee"); //Golden Jubilee of Elizabeth II
            if (year == 2012)
                bHols.Add(new DateTime(2012, 6, 5), "Queen's Diamond Jubilee"); //Queen's Diamond Jubilee

            bHols.Add(Summer(year), "Summer");
            bHols.Add(Christmas(year), "Christmas");
            bHols.Add(BoxingDay(year), "Boxing Day");
            return bHols;
        }

        /// <summary>
        /// Returns the next working day (Mon-Fri, not bank holiday)
        /// after the specified date (or the same date)
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>A date that is a working day</returns>
        public static DateTime NextWorkingDay(DateTime dt)
        {
            bool isWorkingDay = false;
            //loops through
            //(not ideal as a March/April date that hits Easter Friday
            //will have to calculate Easter three times-
            // first for the Friday, then for Easter Monday, then again to clear the Tuesday.
            // Easter Monday will calculate twice.
            // To avoid the recalculation, make these methods non-static and cache the date)
            while (isWorkingDay == false)
            {
                //Mon-Fri and not bank holiday, it's okay
                if (dt.DayOfWeek != DayOfWeek.Saturday &&
                    dt.DayOfWeek != DayOfWeek.Sunday &&
                    !IsBankHoliday(dt))
                    isWorkingDay = true;
                //it's Saturday, so skip to Monday
                else if (dt.DayOfWeek == DayOfWeek.Saturday)
                    dt = dt.AddDays(2);
                //it's Sunday, so skip to Monday
                else if (dt.DayOfWeek == DayOfWeek.Sunday)
                    dt = dt.AddDays(1);
                //it's Friday (bank holiday), so skip to Monday
                else if (dt.DayOfWeek == DayOfWeek.Friday)
                    dt = dt.AddDays(3);
                //it's Mon-Thu (bank holiday), so next day
                else
                    dt = dt.AddDays(1);
                //any of the addDays should now loop and retest
                //only Good Friday and Christmas Day should loop twice
                //(2 adjacent bank holidays)
            }
            return dt;
        }

        /// <summary>
        /// Check if a specific date is a bank holiday.
        /// Obviously the BankHoliday list is more efficient for repeated checks
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a bank holiday (excluding weekends)</returns>
        public static bool IsBankHoliday(DateTime dt)
        {
            int year = dt.Year;

            switch (dt.Month)
            {
                case 1:
                    if ((year > 1973) && (NewYear(year) == dt))
                        return true;
                    break;
                case 3:
                case 4:
                    //only Mondays and Fridays are bank holidays
                    if (dt.DayOfWeek != DayOfWeek.Monday &&
                        dt.DayOfWeek != DayOfWeek.Friday)
                        return false;
                    //easter can be in March or April
                    DateTime easter = GetEaster(year);
                    if (GoodFriday(easter) == dt)
                        return true;
                    if (EasterMonday(easter) == dt)
                        return true;
                    break;
                case 5:
                    if (dt.DayOfWeek != DayOfWeek.Monday)
                        return false;
                    if (MayDay(year) == dt)
                        return true;
                    if (Spring(year) == dt)
                        return true;
                    break;
                case 8:
                    if (dt.DayOfWeek != DayOfWeek.Monday)
                        return false;
                    if (Summer(year) == dt)
                        return true;
                    break;
                case 12:
                    if (Christmas(year) == dt)
                        return true;
                    if (BoxingDay(year) == dt)
                        return true;
                    break;
            }
            if ((year == 2002) &&
               (dt.Month == 6) &&
               ((dt.Day == 3) || (dt.Day == 4)))
                return true; //Golden Jubilee of Elizabeth II
            if ((year == 2011) &&
               (dt.Month == 4) &&
               ((dt.Day == 29)))
                return true; //Royal Wedding
            if ((year == 2012) &&
               (dt.Month == 6) &&
               ((dt.Day == 5)))
                return true; //Queen's Diamond Jubilee

            return false;
        }

        /// <summary>
        /// Work out the date for Easter Sunday for specified year
        /// </summary>
        /// <param name="year">The year as an integer</param>
        /// <returns>Returns a datetime of Easter Sunday.</returns>
        private static DateTime GetEaster(int year)
        {
            //should be
            //Easter Monday  28 Mar 2005  17 Apr 2006  9 Apr 2007  24 Mar 2008

            //Oudin's Algorithm - http://www.smart.net/~mmontes/oudin.html
            int g = year % 19;
            int c = year / 100;
            int h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            int i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));
            int j = (year + year / 4 + i + 2 - c + c / 4) % 7;
            int p = i - j;
            int easterDay = 1 + (p + 27 + (p + 6) / 40) % 31;
            int easterMonth = 3 + (p + 26) / 30;

            return new DateTime(year, easterMonth, easterDay);
        }
    }
}
 
