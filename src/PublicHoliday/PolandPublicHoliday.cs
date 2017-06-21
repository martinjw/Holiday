using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Poland
    /// </summary>
    public class PolandPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Nowy Rok - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Swieto Trzech Króli - Epiphany January 6
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Poniedzialek Wielkanocny - Easter Monday
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
        /// Swieto Panstwowe - Labour Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Swieto Narodowe Trzeciego Maja - Constitution Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ConstitutionDay(int year)
        {
            return new DateTime(year, 5, 3);
        }

        /// <summary>
        /// dzien Bozego Ciala - CorpusChristi
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
        /// Wniebowziecie Najswietszej Maryi Panny - Assumption of Mary
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Wszystkich Swietych - All Saints
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Narodowe Swieto Niepodleglosci - Independence Day
        /// </summary>
        /// <param name="year"></param>

        public static DateTime IndependenceDay(int year)
        {
            return new DateTime(year, 11, 11);
        }

        /// <summary>
        /// pierwszy dzien Bozego Narodzenia - 1st day of Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// drugi dzien Bozego Narodzenia - 2nd day of Christmas
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
        /// Public holiday names in Polish.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string> {
                { NewYear(year), "Nowy Rok" },
                { Epiphany(year), "Swieto Trzech Króli" } };
            DateTime easter = HolidayCalculator.GetEaster(year);
            bHols.Add(EasterMonday(easter), "Poniedzialek Wielkanocny");
            bHols.Add(LabourDay(year), "Swieto Panstwowe");
            bHols.Add(ConstitutionDay(year), "Swieto Narodowe Trzeciego Maja");
            bHols.Add(CorpusChristi(year),"dzien Bozego Ciala");
            bHols.Add(Assumption(year), "Wniebowziecie Najswietszej Maryi Panny");
            bHols.Add(AllSaints(year), "Wszystkich Swietych");
            bHols.Add(IndependenceDay(year), "Narodowe Swieto Niepodleglosci");
            bHols.Add(Christmas(year), "pierwszy dzien Bozego Narodzenia");
            bHols.Add(StStephen(year), "drugi dzien Bozego Narodzenia");
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
                    if (ConstitutionDay(year) == date)
                        return true;
                    if (CorpusChristi(year) == date)
                        return true;
                    break;

                case 8:
                    if (Assumption(year) == date)
                        return true;
                    break;

                case 11:
                    if (AllSaints(year) == date)
                        return true;
                    if (IndependenceDay(year) == date)
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