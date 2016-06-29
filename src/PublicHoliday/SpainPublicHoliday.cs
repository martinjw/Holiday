using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// Finds Spanish public holidays.
    /// Public holidays on Sundays are not deferred to following weekday automatically-
    /// they may be taken at an arbitary date.
    /// </summary>
    /// <remarks>
    /// - We don't infer bridge days for holidays on Tues/Thurs.
    /// - We don't have regional holidays
    /// </remarks>
    public class SpainPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// New Year's Day January 1 Año Nuevo
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Epiphany January 6 	Día de Reyes / Epifanía del Señor
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Good Friday (Friday before Easter) Viernes Santo
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GoodFriday(int year)
        {
            DateTime hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        /// <summary>
        /// Labor Day May 1 Día del Trabajador.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Assumption of Mary August 15- Asunción
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// National day, October 12 Fiesta Nacional de España
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 10, 12);
        }

        /// <summary>
        /// All Saints November 1 Día de todos los Santos
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Constitution day, Dec 6 Día de la Constitución
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime ConstitutionDay(int year)
        {
            return new DateTime(year, 12, 6);
        }

        /// <summary>
        /// Immaculate Conception, Dec 8 - Inmaculada Concepción
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static DateTime ImmaculateConception(int year)
        {
            return new DateTime(year, 12, 8);
        }

        /// <summary>
        /// Christmas December 25  Navidad
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        #endregion Individual Holidays

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            var bHols = new List<DateTime>();
            bHols.Add(NewYear(year));
            bHols.Add(Epiphany(year));
            bHols.Add(GoodFriday(year));
            bHols.Add(MayDay(year));
            bHols.Add(Assumption(year));
            bHols.Add(NationalDay(year));
            bHols.Add(AllSaints(year));
            bHols.Add(ConstitutionDay(year));
            bHols.Add(ImmaculateConception(year));
            bHols.Add(Christmas(year));
            return bHols;
        }

        /// <summary>
        /// Public holiday names in Spanish.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "Año Nuevo");
            bHols.Add(Epiphany(year), "Epifanía");
            bHols.Add(GoodFriday(year), "Viernes Santo");
            bHols.Add(MayDay(year), "Día del Trabajador");
            bHols.Add(Assumption(year), "Asunción");
            bHols.Add(NationalDay(year), "Fiesta Nacional de España");
            bHols.Add(AllSaints(year), "Día de todos los Santos");
            bHols.Add(ConstitutionDay(year), "Día de la Constitución");
            bHols.Add(ImmaculateConception(year), "Inmaculada Concepción");
            bHols.Add(Christmas(year), "Navidad");
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
                    if (GoodFriday(year) == date)
                        return true;
                    break;

                case 5:
                    if (MayDay(year) == date)
                        return true;
                    break;

                case 8:
                    if (Assumption(year) == date)
                        return true; //August 15, fixed
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
                    if (ConstitutionDay(year) == date)
                        return true;
                    if (ImmaculateConception(year) == date)
                        return true;
                    if (Christmas(year) == date)
                        return true;
                    break;
            }
            return false;
        }
    }
}