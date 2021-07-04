using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// New Zealand Public Holidays: https://www.govt.nz/browse/work/public-holidays-and-work-2/public-holidays-and-anniversary-dates/
    /// </summary>
    public class NewZealandPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 1, 1));
        }

        /// <summary>
        /// Day After New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime DayAfterNewYear(int year)
        {
            var ny = NewYear(year); //may be shifted to Monday, so we have to add a day
            return HolidayCalculator.FixWeekend(ny.AddDays(1));
        }

        /// <summary>
        /// Waitangi Day - 6th February
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime WaitangiDay(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 2, 6));
        }

        /// <summary>
        /// Good Friday (Friday before Easter)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime GoodFriday(int year)
        {
            var easter = HolidayCalculator.GetEaster(year);
            return GoodFriday(easter);
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        /// <summary>
        /// Easter Monday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            var easter = HolidayCalculator.GetEaster(year);
            return EasterMonday(easter);
        }

        private static DateTime EasterMonday(DateTime easter)
        {
            return easter.AddDays(1);
        }

        /// <summary>
        /// ANZAC day, 25th April. 
        /// Unless it falls on a weekend and then it becomes a Monday holiday.
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AnzacDay(int year)
        {
            var anzac = new DateTime(year, 4, 25);
            return year >= 2015 ? HolidayCalculator.FixWeekend(anzac) : anzac;
        }

        /// <summary>
        /// Queen's Birthday - first Monday in June
        /// </summary>
        /// <param name="year">The year.</param>

        public static DateTime QueenBirthday(int year)
        {
            return HolidayCalculator.FindNext(new DateTime(year, 6, 1), DayOfWeek.Monday);
        }

        /// <summary>
        /// Labour Day - 4th Monday in October
        /// </summary>
        /// <param name="year">The year.</param>

        public static DateTime LabourDay(int year)
        {
            return HolidayCalculator.FindNext(new DateTime(year, 10, 1), DayOfWeek.Monday).AddDays(7 * 3);
        }

        /// <summary>
        /// Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 12, 25));
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        /// <remarks>
        /// If boxing day lands on a Sunday then the public holiday must be observed on the following Tuesday.
        /// So xmas and boxing days can be both Saturday and Sunday, followed by public holidays for both Monday and Tuesday.
        /// </remarks>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime BoxingDay(int year)
        {
            var xmas = Christmas(year); // May be shifted to Monday, so we have to add a day.
            return HolidayCalculator.FixWeekend(xmas.AddDays(1));
        }

        /// <summary>
        /// Matariki - https://www.beehive.govt.nz/release/matariki-holiday-dates-next-thirty-years-announced
        /// </summary>
        /// <param name="year">The year to check</param>
        /// <returns>The date of Matariki, if there is one defined</returns>
        public static DateTime? Matariki(int year)
        {
            // First occurrence is in 2022
            if (year < 2022) return null;

            var dates = new Dictionary<int, DateTime>
            {
                {2022, new DateTime(2022, 6, 24)},
                {2023, new DateTime(2023, 7, 14)},
                {2024, new DateTime(2024, 6, 28)},
                {2025, new DateTime(2025, 6, 20)},
                {2026, new DateTime(2026, 7, 10)},
                {2027, new DateTime(2027, 6, 25)},
                {2028, new DateTime(2028, 7, 14)},
                {2029, new DateTime(2029, 7, 6)},
                {2030, new DateTime(2030, 6, 21)},
                {2031, new DateTime(2031, 7, 11)},
                {2032, new DateTime(2032, 7, 2)},
                {2033, new DateTime(2033, 6, 24)},
                {2034, new DateTime(2034, 7, 7)},
                {2036, new DateTime(2036, 7, 18)},
                {2037, new DateTime(2037, 7, 10)},
                {2038, new DateTime(2038, 6, 25)},
                {2039, new DateTime(2039, 7, 15)},
                {2040, new DateTime(2040, 7, 6)},
                {2041, new DateTime(2041, 7, 19)},
                {2042, new DateTime(2042, 7, 11)},
                {2043, new DateTime(2043, 7, 3)},
                {2044, new DateTime(2044, 6, 24)},
                {2045, new DateTime(2045, 7, 7)},
                {2046, new DateTime(2046, 6, 29)},
                {2047, new DateTime(2047, 7, 19)},
                {2048, new DateTime(2048, 7, 3)},
                {2049, new DateTime(2049, 6, 25)},
                {2050, new DateTime(2050, 7, 15)},
                {2051, new DateTime(2051, 6, 30)},
                {2052, new DateTime(2052, 6, 21)}
            };
            
            return dates.ContainsKey(year) ? dates[year] : (DateTime?)null;
        }

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            return PublicHolidayNames(year).Select(x => x.Key).OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Get a list of dates with names for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Dictionary of bank holidays
        /// </returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>
            {
                {NewYear(year), "New Year"},
                {DayAfterNewYear(year), "Day After New Year"},
                {WaitangiDay(year), "Waitangi Day"}
            };
            var easter = HolidayCalculator.GetEaster(year);
            bHols.Add(GoodFriday(easter), "Good Friday");
            bHols.Add(EasterMonday(easter), "Easter Monday");
            bHols.Add(AnzacDay(year), "Anzac Day");
            bHols.Add(QueenBirthday(year), "Queen's Birthday");
            bHols.Add(LabourDay(year), "Labour Day");
            bHols.Add(Christmas(year), "Christmas Day");
            bHols.Add(BoxingDay(year), "Boxing Day");

            var matariki = Matariki(year);
            if (matariki.HasValue)
            {
                bHols.Add(matariki.Value, "Matariki");
            }
            return bHols;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// Obviously the <see cref="PublicHolidays" /> list is more efficient for repeated checks
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>
        /// True if date is a public holiday (excluding weekends)
        /// </returns>
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
                    break;
                case 2:
                    if (WaitangiDay(year) == date)
                        return true;
                    break;
                case 3:
                case 4:
                    if (GoodFriday(year) == date)
                        return true;
                    if (EasterMonday(year) == date)
                        return true;
                    if (AnzacDay(year) == date)
                        return true;
                    break;
                case 6:
                    if (QueenBirthday(year) == date)
                        return true;
                    if (Matariki(year) == date)
                        return true;
                    break;
                case 7:
                    if (Matariki(year) == date)
                        return true;
                    break;
                case 10:
                    if (LabourDay(year) == date)
                        return true;
                    break;
                case 12:
                    if (Christmas(year) == date)
                        return true;
                    if (BoxingDay(year) == date)
                        return true;
                    break;
            }
            return false;
        }
    }
}
