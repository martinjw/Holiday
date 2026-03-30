using PublicHoliday;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Hungary
    /// Based on Hungarian Labor Code (Munka törvénykönyve)
    /// </summary>
    public class HungaryPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Újév - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year) => new DateTime(year, 1, 1);

        /// <summary>
        /// 1848-as forradalom ünnepe - National Day
        /// Commemorates the Hungarian Revolution of 1848. 
        /// It was reinstated as an official state holiday after the fall of communism.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDay1848(int year) => new DateTime(year, 3, 15);

        /// <summary>
        /// Nagypéntek - Good Friday
        /// Introduced as a public holiday in Hungary since 2017
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year) => HolidayCalculator.GetEaster(year).AddDays(-2);

        /// <summary>
        /// Húsvéthétfő - Easter Monday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year) => HolidayCalculator.GetEaster(year).AddDays(1);

        /// <summary>
        /// Munka ünnepe - International Workers' Day
        /// Valid throughout the modern era.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime WorkersDay(int year) => new DateTime(year, 5, 1);

        /// <summary>
        /// Pünkösdhétfő - Pentecost Monday
        /// Re-introduced as a public holiday after the political changes in the early 1990s.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime PentecostMonday(int year) => HolidayCalculator.GetEaster(year).AddDays(50);

        /// <summary>
        /// Államalapítás ünnepe - State Foundation Day
        /// Commemorates Saint Stephen I, the first King of Hungary. 
        /// During the communist era (1950-1989), it was celebrated as the Day of the Constitution or Day of the New Bread.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime SaintStephenDay(int year) => new DateTime(year, 8, 20);

        /// <summary>
        /// 1956-os forradalom ünnepe - National Day
        /// Commemorates the Revolution of 1956 and the proclamation of the Republic of Hungary in 1989.
        /// Official holiday since 1991.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Revolution1956Day(int year) => new DateTime(year, 10, 23);

        /// <summary>
        /// Mindenszentek - All Saints' Day
        /// Reinstated as a public holiday in 2000.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime AllSaints(int year) => new DateTime(year, 11, 1);

        /// <summary>
        /// Karácsony - Christmas Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ChristmasDay(int year) => new DateTime(year, 12, 25);

        /// <summary>
        /// Karácsony másnapja - Second Day of Christmas
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime StStephenDay(int year) => new DateTime(year, 12, 26);

        #endregion Individual Holidays

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>List of public holidays</returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Keys.OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Public holiday names in Hungarian.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Dictionary of holiday dates and names</returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var dictionary = new Dictionary<DateTime, string>();

            // Fixed dates
            dictionary.Add(NewYear(year), "Újév");
            dictionary.Add(NationalDay1848(year), "1848-as forradalom ünnepe");
            dictionary.Add(WorkersDay(year), "Munka ünnepe");
            dictionary.Add(SaintStephenDay(year), "Államalapítás ünnepe");
            dictionary.Add(Revolution1956Day(year), "1956-os forradalom ünnepe");
            dictionary.Add(AllSaints(year), "Mindenszentek");
            dictionary.Add(ChristmasDay(year), "Karácsony");
            dictionary.Add(StStephenDay(year), "Karácsony másnapja");

            // Easter based holidays
            DateTime easter = HolidayCalculator.GetEaster(year);
            dictionary.Add(easter.AddDays(1), "Húsvéthétfő");
            dictionary.Add(easter.AddDays(50), "Pünkösdhétfő");

            // Good Friday was introduced as a public holiday in 2017
            if (year >= 2017)
            {
                dictionary.Add(easter.AddDays(-2), "Nagypéntek");
            }

            return dictionary;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            int year = dt.Year;
            DateTime date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    return NewYear(year) == date;
                case 3:
                    if (NationalDay1848(year) == date) return true;
                    // Check Good Friday / Easter Monday if they fall in March
                    if (year >= 2017 && GoodFriday(year) == date) return true;
                    if (EasterMonday(year) == date) return true;
                    break;
                case 4:
                    if (year >= 2017 && GoodFriday(year) == date) return true;
                    if (EasterMonday(year) == date) return true;
                    break;
                case 5:
                    if (WorkersDay(year) == date) return true;
                    if (PentecostMonday(year) == date) return true;
                    break;
                case 6:
                    if (PentecostMonday(year) == date) return true;
                    break;
                case 8:
                    return SaintStephenDay(year) == date;
                case 10:
                    return Revolution1956Day(year) == date;
                case 11:
                    return AllSaints(year) == date;
                case 12:
                    if (ChristmasDay(year) == date) return true;
                    if (StStephenDay(year) == date) return true;
                    break;
            }

            return false;
        }
    }
}