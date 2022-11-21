using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Slovenia
    /// Taken from official government page https://www.gov.si/teme/drzavni-prazniki-in-dela-prosti-dnevi/
    /// </summary>
    public class SloveniaPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Novo leto (1. januar) - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearFirst(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Novo leto (2. januar) - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearSecond(int year)
        {
            return new DateTime(year, 1, 2);
        }

        /// <summary>
        /// Prešernov dan - Cultural holiday
        /// </summary>
        /// <param name="year"></param>
        public static DateTime PreserenDay(int year)
        {
            return new DateTime(year, 2, 8);
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
        /// Resistance against the occupation
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime ResistanceAgainstOccupation(int year)
        {
            return new DateTime(year, 4, 27);
        }

        /// <summary>
        /// Praznik dela 1.maj - Labour Day 1. may
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDayFirst(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Praznik dela 2.maj - Labour Day 2. may
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime LabourDaySecond(int year)
        {
            return new DateTime(year, 5, 2);
        }

        /// <summary>
        /// Dan državnosti - National day
        /// </summary>
        /// <param name="year"></param>
        public static DateTime NationalDay(int year)
        {
            return new DateTime(year, 6, 25);
        }

        /// <summary>
        /// Marijino vnebovzetje - Assumption of Mary
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Dan reformacije - Reformation day
        /// </summary>
        /// <param name="year"></param>
        public static DateTime ReformationDay(int year)
        {
            return new DateTime(year, 10, 31);
        }

        /// <summary>
        /// Dan spomina na mrtve (Vsi sveti) - All Saints
        /// </summary>
        /// <param name="year"></param>
        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Božič - Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Dan samostojnosti in enotnosti - Day of sovereignity and unity
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime UnityDay(int year)
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
            var bHols = new Dictionary<DateTime, string>
            {
                { NewYearFirst(year), "Novo leto, prvi januar" },
                { NewYearSecond(year), "Novo leto, drugi januar" },
            };

            DateTime easter = HolidayCalculator.GetEaster(year);
            bHols.Add(PreserenDay(year), "Prešernov dan");
            bHols.Add(EasterMonday(easter), "Velikonočni ponedeljek");
            bHols.Add(ResistanceAgainstOccupation(year), "Dan upora proti okupatorju");
            bHols.Add(LabourDayFirst(year), "Dan dela 1.maj");
            bHols.Add(LabourDaySecond(year), "Dan dela 1.maj");
            bHols.Add(Assumption(year), "Marijino vnebovzetje");
            bHols.Add(NationalDay(year), "Dan državnosti");
            bHols.Add(AllSaints(year), "Dan spomina na mrtve");
            bHols.Add(UnityDay(year), "Day suverenosti in enotnosti");
            bHols.Add(ReformationDay(year), "Dan reformacije");
            bHols.Add(Christmas(year), "Božič");
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
                    if (NewYearFirst(year) == date || NewYearSecond(year) == date) return true;
                    break;
                case 2:
                    if (PreserenDay(year) == date) return true;
                    break;
                case 4:
                    if (EasterMonday(year) == date || ResistanceAgainstOccupation(year) == date) return true;
                    break;
                case 5:
                    if (LabourDayFirst(year) == date || LabourDaySecond(year) == date) return true;
                    break;
                case 6:
                    if (NationalDay(year) == date) return true;
                    break;
                case 8:
                    if (Assumption(year) == date) return true;
                    break;
                case 10:
                    if (ReformationDay(year) == date) return true;
                    break;
                case 11:
                    if (AllSaints(year) == date) return true;
                    break;
                case 12:
                    if (Christmas(year) == date || UnityDay(year) == date) return true;
                    break;
            }

            return false;
        }
    }
}