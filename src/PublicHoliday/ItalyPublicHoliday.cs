using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Italy
    /// </summary>
    public class ItalyPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Capodanno - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Epifania - Epiphany January 6
        /// </summary>
        /// <param name="year"></param>

        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Pasquetta - Easter Monday
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
        /// Festa della Liberazione- Liberation Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LiberationDay(int year)
        {
            return new DateTime(year, 4, 25);
        }

        /// <summary>
        /// Festa del Lavoro - Labour Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Festa della Repubblica - Republic Day
        /// </summary>
        /// <param name="year"></param>
        public static DateTime RepublicDay(int year)
        {
            return new DateTime(year, 6, 2);
        }

        /// <summary>
        /// Ferragosto - Assumption of Mary
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }


        /// <summary>
        /// Tutti i santi - All Saints
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }
        /// <summary>
        /// Immacolata Concezione - Immaculate Conception
        /// </summary>
        /// <param name="year"></param>

        public static DateTime ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }

        /// <summary>
        /// Natale - Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Santo Stefano - St Stephen's Day
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
            return PublicHolidayNames(year).Select(x => x.Key).OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Public holiday names in Italian.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string> {
                { NewYear(year), "Capodanno" },
                { Epiphany(year), "Epifania" } };
            DateTime easter = HolidayCalculator.GetEaster(year);
            bHols.Add(EasterMonday(easter), "Pasquetta");
            var liberationDay = LiberationDay(year);
            if (!bHols.ContainsKey(liberationDay))
            {
                //in 2011, Liberation Day was 25th April, the same day as Easter Monday
                bHols.Add(liberationDay, "Festa della Liberazione");
            }
            bHols.Add(LabourDay(year), "Festa del Lavoro");
            bHols.Add(RepublicDay(year), "Festa della Repubblica");
            bHols.Add(Assumption(year), "Ferragosto");
            bHols.Add(AllSaints(year), "Tutti i santi");
            bHols.Add(ImmaculateConception(year), "Immacolata Concezione");
            bHols.Add(Christmas(year), "Natale");
            bHols.Add(StStephen(year), "Santo Stefano");
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
                    if (date.Day == 25) //liberation
                        return true;
                    break;

                case 5:
                    if (LabourDay(year) == date)
                        return true;
                    break;

                case 6:
                    if (RepublicDay(year) == date)
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