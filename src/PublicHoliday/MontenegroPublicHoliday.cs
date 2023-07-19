using System.Collections.Generic;
using System;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Montenegro
    /// https://www.gov.me/en/documents/927f23a3-db4e-4f65-9f29-ce3c9dde0c90
    /// </summary>
    /// <seealso cref="PublicHoliday.PublicHolidayBase" />
    public class MontenegroPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// New Year's Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearFirst(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// New Year's Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYearSecond(int year)
        {
            return new DateTime(year, 1, 2);
        }

        /// <summary>
        /// Christmas Eve
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasEve(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Christmas.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 1, 7);
        }

        /// <summary>
        /// Independence Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependenceDayFirst(int year)
        {
            return new DateTime(year, 5, 21);
        }

        /// <summary>
        /// Independence Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime IndependenceDaySecond(int year)
        {
            return new DateTime(year, 5, 22);
        }

        /// <summary>
        /// Good Friday - Friday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetOrthodoxEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }       

        /// <summary>
        /// Easter Monday 1st Monday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            var hol = HolidayCalculator.GetOrthodoxEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return easter.AddDays(1);
        }

        /// <summary>
        /// Labor Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDayFirst(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Labour Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDaySecond(int year)
        {
            return new DateTime(year, 5, 2);
        }

        /// <summary>
        /// Statehood Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StatehoodDayFirst(int year)
        {
            return new DateTime(year, 7, 13);
        }

        /// <summary>
        /// Statehood Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StatehoodDaySecond(int year)
        {
            return new DateTime(year, 7, 14);
        }

        /// <summary>
        /// Negoshev Day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NegoshevDay(int year)
        {
            return new DateTime(year, 11, 13);
        }


        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            var easter = HolidayCalculator.GetOrthodoxEaster(year);
            return new List<DateTime>
            {
                NewYearFirst(year),
                NewYearSecond(year),
                ChristmasEve(year),
                Christmas(year),             
                GoodFriday(easter),            
                EasterMonday(easter),            
                LabourDayFirst(year),
                LabourDaySecond(year),
                IndependenceDayFirst(year),
                IndependenceDaySecond(year),
                StatehoodDayFirst(year),
                StatehoodDaySecond(year),
                NegoshevDay(year)
            };
        }

        /// <summary>
        /// Public holiday names in Montenegro.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var dict = new Dictionary<DateTime, string> ()
            {
                { NewYearFirst(year), "Nova godina"},
                { NewYearSecond(year), "Nova godina" },
                { ChristmasEve(year), "Badnji dan" },
                { Christmas(year), "Božić" } ,              
                { LabourDayFirst(year), "Praznik rada" },
                { LabourDaySecond(year), "Praznik rada" },
                { IndependenceDayFirst(year), "Dan nezavisnosti" },
                { IndependenceDaySecond(year), "Dan nezavisnosti" },
                { StatehoodDayFirst(year), "Dan državnostia" },
                { StatehoodDaySecond(year), "Dan državnosti" },
                { NegoshevDay(year), "Njegosev Dan" },
            };
            if (!dict.ContainsKey(GoodFriday(year)))
            {
                dict.Add(GoodFriday(year), "Veliki petak");
            }
            if (!dict.ContainsKey(EasterMonday(year)))
            {
                dict.Add(EasterMonday(year), "Uskrsni ponedeljak");
            }
            return dict;
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
                    if (NewYearFirst(year) == date || NewYearSecond(year) == date || 
                        ChristmasEve(year) == date || Christmas(year) == date) return true;
                    break;          
                case 3:
                case 4:               
                    if (EasterMonday(year) == date || GoodFriday(year) == date) return true;
                    break;
                case 5:
                    if (EasterMonday(year) == date || GoodFriday(year) == date) return true;                   
                    if (LabourDayFirst(year) == date || LabourDaySecond(year) == date) return true;
                    if (IndependenceDayFirst(year) == date || IndependenceDaySecond(year) == date) return true;
                    break;
                case 7:
                    if (StatehoodDayFirst(year) == date || StatehoodDaySecond(year) == date) return true;
                    break;
                case 11:
                    if (NegoshevDay(year) == date) return true;
                    break;
            }

            return false;
        }
    }
}
