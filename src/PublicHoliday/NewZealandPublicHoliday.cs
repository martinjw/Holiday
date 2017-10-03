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
