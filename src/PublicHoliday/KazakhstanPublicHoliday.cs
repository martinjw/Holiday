using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Represents holidays in the Kazakhstan
    /// </summary>
    public class KazakhstanPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// New Year's Day January 1
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Day after New Year's Day January 2
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime DayAfterNewYear(int year)
        {
            return new DateTime(year, 1, 2);
        }

        /// <summary>
        /// Christmas January 7
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 1, 7);
        }

        /// <summary>
        /// Womans Day - March 8th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime WomansDay(int year)
        {
            return new DateTime(year, 3, 8);
        }

        /// <summary>
        /// First day of Nauryz - March 21th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NauryzFirstDay(int year)
        {
            return new DateTime(year, 3, 21);
        }

        /// <summary>
        /// First day of Nauryz - March 22th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NauryzSecondDay(int year)
        {
            return new DateTime(year, 3, 22);
        }

        /// <summary>
        /// First day of Nauryz - March 23th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NauryzThirdDay(int year)
        {
            return new DateTime(year, 3, 23);
        }

        /// <summary>
        /// Nation unity Day - Mai 1st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationUnityDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Homeland protector Day - Mai 7st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime HomelandProtectorDay(int year)
        {
            return new DateTime(year, 5, 7);
        }

        /// <summary>
        /// Victory Day - Mai 9st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime VictoryDay(int year)
        {
            return new DateTime(year, 5, 9);
        }

        /// <summary>
        /// Capital Day - July 6th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime CapitalDay(int year)
        {
            return new DateTime(year, 7, 6);
        }

        /// <summary>
        /// Constitution Day - August 30th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ConstitutionDay(int year)
        {
            return new DateTime(year, 8, 30);
        }

        /// <summary>
        /// Kurban Ait - September 1th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime KurbanAitDay(int year)
        {
            return new DateTime(year, 9, 1);
        }

        /// <summary>
        /// First president day - December 1th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime FirstPresidentDay(int year)
        {
            return new DateTime(year, 12, 1);
        }

        /// <summary>
        /// Independence day - December 16th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependenceDay(int year)
        {
            return new DateTime(year, 12, 16);
        }

        /// <summary>
        /// Second day of independence - December 17th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependenceSecondDay(int year)
        {
            return new DateTime(year, 12, 17);
        }

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
        /// Public holiday names in Russian.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>
            {
                { NewYear(year), "Новый год" },
                { DayAfterNewYear(year), "Второй день нового года" },
                { Christmas(year), "Рождество Христово" },
                { WomansDay(year), "Международный женский день" },
                { NauryzFirstDay(year), "Наурыз мейрамы" },
                { NauryzSecondDay(year), "Наурыз мейрамы" },
                { NauryzThirdDay(year), "Наурыз мейрамы" },
                { NationUnityDay(year), "Праздник единства народа Казахстана" },
                { HomelandProtectorDay(year), "День Защитника Отечества" },
                { VictoryDay(year), "День Победы" },
                { CapitalDay(year), "День столицы" },
                { ConstitutionDay(year), "День Конституции" },
                { KurbanAitDay(year), "Курбан Айт" },
                { FirstPresidentDay(year), "День Первого Президента"},
                { IndependenceDay(year), "День Независимости Казахстана"},
                { IndependenceSecondDay(year), "День Независимости Казахстана" }
            };
            return bHols;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the PublicHoliday list is more efficient for repeated checks
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
                    if (DayAfterNewYear(year) == date)
                        return true;
                    if (Christmas(year) == date)
                        return true;
                    break;
                case 3:
                case 4:
                    if (WomansDay(year) == date)
                        return true;
                    if (NauryzFirstDay(year) == date)
                        return true;
                    if (NauryzSecondDay(year) == date)
                        return true;
                    if (NauryzThirdDay(year) == date)
                        return true;
                    break;
                case 5:
                    if (NationUnityDay(year) == date)
                        return true;
                    if (HomelandProtectorDay(year) == date)
                        return true;
                    if (VictoryDay(year) == date)
                        return true;
                    break;
                case 7:
                    if (CapitalDay(year) == date)
                        return true;
                    break;
                case 8:
                    if (ConstitutionDay(year) == date)
                        return true;
                    break;
                case 9:
                    if (KurbanAitDay(year) == date)
                        return true;
                    break;
                case 12:
                    if (FirstPresidentDay(year) == date)
                        return true;
                    if (IndependenceDay(year) == date)
                        return true;
                    if (IndependenceSecondDay(year) == date)
                        return true;
                    break;
            }

            return false;
        }
    }
}
