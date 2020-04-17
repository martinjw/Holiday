using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Austria
    /// </summary>
    public class AustriaPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Neujahr - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Heilige Drei Könige Epiphany January 6
        /// </summary>
        /// <param name="year"></param>

        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Ostermontag - Easter Monday
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
        /// Staatsfeiertag - Labour Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Christi Himmelfahrt - Ascension
        /// </summary>
        /// <param name="year"></param>

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
        /// Pfingstmontag - Pentecost
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
        /// Fronleichnam - CorpusChristi
        /// </summary>
        /// <param name="year"></param>

        public static DateTime CorpusChristi(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            //first Thursday after Trinity Sunday (Pentecost + 1 week)
            hol = hol.AddDays((7 * 8) + 4);
            return hol;
        }

        /// <summary>
        /// Mariä Himmelfahrt - Assumption of Mary
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Nationalfeiertag - National Day
        /// </summary>
        /// <param name="year"></param>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 10, 26);
        }
        /// <summary>
        /// Allerheiligen - All Saints
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }
        /// <summary>
        /// Mariä Empfängnis - Immaculate Conception
        /// </summary>
        /// <param name="year"></param>

        public static DateTime ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }

        /// <summary>
        /// Christtag - Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Stefanitag - St Stephen's Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime StStephen(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion Individual Holidays

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Select(x => x.Key.Date).OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Public holiday names in German.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string> {
                { NewYear(year), "Neujahr" },
                { Epiphany(year), "Heilige Drei Könige" } };
            DateTime easter = HolidayCalculator.GetEaster(year);
            bHols.Add(EasterMonday(easter), "Ostermontag");
            var mayday = LabourDay(year);
            bHols.Add(mayday, "Staatsfeiertag");
            var ascension = Ascension(easter);
            if (ascension == mayday) ascension = ascension.AddSeconds(1); //ascension can fall on Mayday
            bHols.Add(ascension, "Christi Himmelfahrt");
            bHols.Add(PentecostMonday(easter), "Pfingstmontag");
            bHols.Add(CorpusChristi(year), "Fronleichnam");
            bHols.Add(Assumption(year), "Mariä Himmelfahrt");
            bHols.Add(NationalDay(year), "Nationalfeiertag");
            bHols.Add(AllSaints(year), "Allerheiligen");
            bHols.Add(ImmaculateConception(year), "Mariä Empfängnis");
            bHols.Add(Christmas(year), "Christtag");
            bHols.Add(StStephen(year), "Stefanitag");
            return bHols;
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
                    if (NewYear(year) == date)
                        return true;
                    if (Epiphany(year) == date)
                        return true;
                    break;

                case 3:
                case 4:
                    if (EasterMonday(year) == date)
                        return true;
                    break;

                case 5:
                case 6:
                    if (LabourDay(year) == date)
                        return true;
                    if (Ascension(year) == date)
                        return true; // usually in May (may 25, 2006)
                    if (PentecostMonday(year) == date)
                        return true; // May 20 2004
                    if (CorpusChristi(year) == date)
                        return true;
                    break;

                case 8:
                    if (Assumption(year) == date)
                        return true;
                    break;

                case 10:
                    if (NationalDay(year) == date)
                        return true;
                    break;

                case 11:
                    if (AllSaints(year) == date)
                        return true;
                    break;

                case 12:
                    if (ImmaculateConception(year) == date)
                        return true;
                    if (Christmas(year) == date)
                        return true;
                    if (StStephen(year) == date)
                        return true;
                    break;
            }

            return false;
        }
    }
}