using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Governement of Quebec (statutory) Holidays. Adjusted for weekends.
    /// <description>
    /// Governement of Quebec regulated workers are entitled to thirteen paid statutory holidays every year.
    /// <para>When New Year’s Day or Christmas fall on a Saturday or Sunday that are not normal work days, workers are entitled to a holiday with pay on the working day immediately after the holiday</para>
    /// <para>When National Holiday or Canada Day fall on a Saturday or Sunday that are not normal work days, workers are entitled to a holiday with pay on the working day immediately before for saturday or immediately after for the sunday the holiday</para>
    /// </description>
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class CanadaQuebecGovClosingDay : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Date of New Year bank holiday.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <remarks>If weekend, after.</remarks>
        public static Holiday NewYear(int year)
        {
            var hol = new DateTime(year, 1, 1);
            return new Holiday(hol, HolidayCalculator.FixWeekend(hol), "NewYear");
        }

        /// <summary>
        /// Day After New Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday DayAfterNewYear(int year)
        {
            var hol = new DateTime(year, 1, 2);
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayAfter(hol), "DayAfterNewYear");
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayAfter(hol), "GoodFriday"); 
        }

        /// <summary>
        /// Easter Monday (Monday after Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday EasterMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return new Holiday(hol, hol, "EasterMonday");
        }

        /// <summary>
        /// Private overloads of GoodFriday and EasterMonday reusing Easter calculation
        /// </summary>
        private static Holiday GoodFriday(DateTime easter)
        {
            var hol = easter.AddDays(-2);
            return new Holiday(hol, hol, "GoodFriday");
        }
        private static Holiday EasterMonday(DateTime easter)
        {
            var hol = easter.AddDays(1);
            return new Holiday(hol, hol, "EasterMonday");
        }

        /// <summary>
        /// Monday on or before May 24
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday NationalPatriotDay(int year)
        {
            var hol = new DateTime(year, 5, 24);
            //skip back to previous Monday
            while (hol.DayOfWeek != DayOfWeek.Monday)
            {
                hol = hol.AddDays(-1);
            }
            return new Holiday(hol, hol, "NationalPatriotDay"); 
        }

        /// <summary>
        /// National holiday (June 24)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday NationalHoliday(int year)
        {
            var hol = new DateTime(year, 6, 24);
            return new Holiday(hol, HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(hol), "NationalHoliday"); 
        }

        /// <summary>
        /// Canada day, 1 July or following Monday 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday CanadaDay(int year)
        {
            var hol = new DateTime(year, 7, 1);
            return new Holiday(hol, HolidayCalculator.FixWeekendSaturdayBeforeSundayAfter(hol), "CanadaDay");
        }

        /// <summary>
        /// First Monday in September
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday LabourDay(int year)
        {
            var hol = new DateTime(year, 9, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, "LabourDay");
        }

        /// <summary>
        /// Second Monday in October
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday Thanksgiving(int year)
        {
            var hol = new DateTime(year, 10, 8);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, "Thanksgiving");
        }

        /// <summary>
        /// Day Before Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday DayBeforeChristmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 24);
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayBefore(hol), "DayBeforeChristmas");
        }

        /// <summary>
        /// Christmas day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday Christmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 25);
            return new Holiday(hol, HolidayCalculator.FixWeekend(hol), "Christmas");
        }

        /// <summary>
        /// Day After Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday DayAfterChristmas(int year)
        {
            DateTime hol = new DateTime(year, 12, 26);
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayAfter(hol), "DayAfterChristmas");
        }


        /// <summary>
        /// Day Before Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Holiday DayBeforeNewYear(int year)
        {
            DateTime hol = new DateTime(year, 12, 31);
            return new Holiday(hol, HolidayCalculator.FixWeekendTwoHolidayBefore(hol), "DayBeforeNewYear");
        }

        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of bank holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            var bHols = new List<DateTime>();

            foreach (Holiday localholiday in PublicHolidaysInformation(year))
            {
                bHols.Add(localholiday);

            }

            return bHols;
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Dictionary of bank holidays</returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();

            foreach (Holiday localholiday in PublicHolidaysInformation(year))
            {
                bHols.Add(localholiday, localholiday.GetName());

            }

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

            var easter = HolidayCalculator.GetEaster(year);

            bHols.Add(NewYear(year));
            bHols.Add(DayAfterNewYear(year));
            bHols.Add(GoodFriday(easter));
            bHols.Add(EasterMonday(easter));
            bHols.Add(NationalPatriotDay(year));
            bHols.Add(NationalHoliday(year));
            bHols.Add(CanadaDay(year));
            bHols.Add(LabourDay(year));
            bHols.Add(Thanksgiving(year));
            bHols.Add(DayBeforeChristmas(year));
            bHols.Add(Christmas(year));
            bHols.Add(DayAfterChristmas(year));
            bHols.Add(DayBeforeNewYear(year));

            return bHols;

        }

        /// <summary>
        /// Gets a list of public holidays with their observed and actual date with names
        /// </summary>
        /// <param name="year">The given year</param>
        /// <returns></returns>
        [ObsoleteAttribute("This method is obsolete. Call PublicHolidaysInformation instead and use getName with or without CultureInfo.", false)]
        public IDictionary<Holiday, string> PublicHolidaysInformationWithNames(int year)
        {
            var bHols = new Dictionary<Holiday, string>();

            foreach (Holiday localholiday in PublicHolidaysInformation(year))
            {
                bHols.Add(localholiday, localholiday.GetName());

            }

            return bHols;

        }


        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>
        /// True if date is a bank holiday (excluding weekends)
        /// </returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            int year = dt.Year;
            var date = dt.Date;

            return PublicHolidays(year).Contains(date);
        }

    }
}

