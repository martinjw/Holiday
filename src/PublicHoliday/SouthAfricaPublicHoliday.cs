using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in South Africa https://www.gov.za/about-sa/public-holidays
    /// </summary>
    /// <remarks>
    /// Missing because no fixed date: 
    /// </remarks>
    public class SouthAfricaPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 1, 1));
        }

        /// <summary>
        /// Human Rights Day March 21
        /// </summary>
        /// <param name="year"></param>

        public static DateTime HumanRightsDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 3, 21));
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
        /// Easter Monday/Family Day
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
        /// Freedom Day April 27
        /// </summary>
        /// <param name="year"></param>

        public static DateTime FreedomDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 4, 27));
        }


        /// <summary>
        /// International Labour Day/Workers' Day May 1
        /// </summary>
        /// <param name="year">The year.</param>
        /// 
        public static DateTime LabourDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 5, 1));
        }

        /// <summary>
        /// Soweto Day/Youth Day June 16
        /// </summary>
        /// <param name="year"></param>

        public static DateTime YouthDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 6, 16));
        }

        /// <summary>
        /// National Women's Day August 9
        /// </summary>
        /// <param name="year"></param>

        public static DateTime NationalWomensDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 8, 9));
        }

        /// <summary>
        /// Heritage Day September 24
        /// </summary>
        /// <param name="year"></param>

        public static DateTime HeritageDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 9, 24));
        }

        /// <summary>
        /// Day of Reconciliation September 24
        /// </summary>
        /// <param name="year"></param>

        public static DateTime ReconciliationDay(int year)
        {
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 12, 16));
        }

        /// <summary>
        /// Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            //South African president announced that Christmas day will be observed 26 Dec 2022 and Boxing day will be observed 27 Dec 2022 due to christmas falling on a Sunday
            //Source: https://twitter.com/PresidencyZA/status/1600748006986452994?ref_src=twsrc%5Etfw
            if (year == 2022)
            {
                return new DateTime(year, 12, 26);
            }

            //Christmas does not shift when it falls on a Sunday due to boxing day being on the Monday then.
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Boxing Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime BoxingDay(int year)
        {
            //South African president announced that Christmas day will be observed 26 Dec 2022 and Boxing day will be observed 27 Dec 2022 due to christmas falling on a Sunday
            //Source: https://twitter.com/PresidencyZA/status/1600748006986452994?ref_src=twsrc%5Etfw
            if (year == 2022)
            {
                return new DateTime(year, 12, 27);
            }
            return HolidayCalculator.FixWeekendSundayAfter(new DateTime(year, 12, 26));
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
        /// Public holiday names in Lëtzebuergesch.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            //sorted dictionary as these may not be in order...
            var bHols = new SortedDictionary<DateTime, string>
            {
                {NewYear(year), "New Year"},
                {HumanRightsDay(year), "Human Rights Day" }
            };
            var easter = HolidayCalculator.GetEaster(year);
            var goodFriday = GoodFriday(easter);
            //can be same day as Human Rights Day
            if (bHols.ContainsKey(goodFriday)) goodFriday = goodFriday.AddSeconds(1);
            bHols.Add(goodFriday, "Good Friday");
            bHols.Add(EasterMonday(easter), "Family Day");
            bHols.Add(FreedomDay(year), "Freedom Day");
            bHols.Add(LabourDay(year), "Workers' Day");
            bHols.Add(YouthDay(year), "Youth Day");
            bHols.Add(NationalWomensDay(year), "National Women's Day");
            bHols.Add(HeritageDay(year), "Heritage Day");
            bHols.Add(ReconciliationDay(year), "Day of Reconciliation");
            bHols.Add(Christmas(year), "Christmas Day");
            bHols.Add(BoxingDay(year), "Day of Goodwill");
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
                    if (HumanRightsDay(year) == date)
                        return true;
                    if (GoodFriday(year) == date)
                        return true;
                    if (EasterMonday(year) == date)
                        return true;
                    break;

                case 4:
                    if (GoodFriday(year) == date)
                        return true;
                    if (EasterMonday(year) == date)
                        return true;
                    if (FreedomDay(year) == date)
                        return true;
                    break;

                case 5:
                    if (LabourDay(year) == date)
                        return true;
                    break;

                case 6:
                    if (YouthDay(year) == date)
                        return true;
                    break;

                case 8:
                    if (NationalWomensDay(year) == date)
                        return true;
                    break;

                case 9:
                    if (HeritageDay(year) == date)
                        return true;
                    break;

                case 10:
                    break;

                case 11:
                    break;

                case 12:
                    if (ReconciliationDay(year) == date)
                        return true;
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
