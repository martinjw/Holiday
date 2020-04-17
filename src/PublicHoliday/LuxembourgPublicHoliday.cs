using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Luxembourg
    /// </summary>
    public class LuxembourgPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Neijoerschdag - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Ouschterméindeg - Easter Monday
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
        /// Dag vun der Aarbecht - Labour Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Christi Himmelfaar - Ascension
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
        /// Nationalfeierdag - National Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 6, 23);
        }

        /// <summary>
        /// Péngschtméindeg - Pentecost
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
        /// Mariä Himmelfaart - Assumption of Mary
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Allerhellgen - All Saints
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Chrëschtdag - Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Stiefesdag - St Stephen's Day
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
        /// Public holiday names in Lëtzebuergesch.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string> { { NewYear(year), "Neijoerschdag" } };
            DateTime easter = HolidayCalculator.GetEaster(year);
            var labourDay = LabourDay(year);
            var ascension = Ascension(easter);
            if (ascension == labourDay) ascension = ascension.AddSeconds(1); //ascension can fall on Mayday
            bHols.Add(EasterMonday(easter), "Ouschterméindeg");
            bHols.Add(labourDay, "Dag vun der Aarbecht");
            bHols.Add(ascension, "Christi Himmelfaar");
            bHols.Add(PentecostMonday(easter), "Péngschtméindeg");
            bHols.Add(NationalDay(year), "Nationalfeierdag");
            bHols.Add(Assumption(year), "Mariä Himmelfaart");
            bHols.Add(AllSaints(year), "Allerhellgen");
            bHols.Add(Christmas(year), "Chrëschtdag");
            bHols.Add(StStephen(year), "Stiefesdag");
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
                    break;

                case 3:
                case 4:
                    if (EasterMonday(year) == date)
                        return true;
                    break;

                case 5:
                    if (LabourDay(year) == date)
                        return true;
                    if (Ascension(year) == date)
                        return true; // usually in May (may 25, 2006)
                    if (PentecostMonday(year) == date)
                        return true; // May 20 2004
                    break;

                case 6:
                    if (Ascension(year) == date)
                        return true; // Ascension was June 1 2000
                    if (PentecostMonday(year) == date)
                        return true; // June 12 2006
                    if (date.Day == 23) //Nationalfeierdag
                        return true;
                    break;

                case 8:
                    if (Assumption(year) == date)
                        return true;
                    break;

                case 11:
                    if (AllSaints(year) == date)
                        return true;
                    break;

                case 12:
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