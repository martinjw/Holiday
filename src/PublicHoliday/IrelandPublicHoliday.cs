using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Ireland/Eire
    /// </summary>
    public class IrelandPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays

        /// <summary>
        /// Lá Caille - New Year's Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NewYear(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 1, 1));
        }

        /// <summary>
        /// Lá Fhéile Pádraig - St Patrick's Day March 17
        /// </summary>
        /// <param name="year"></param>

        public static DateTime StPatricksDay(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 3, 17));
        }

        /// <summary>
        /// Luan Cásca - Easter Monday
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
        /// Lá Bealtaine - May Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime MayDay(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 5, 1));
        }

        /// <summary>
        /// Lá Saoire i mí an Mheithimh - June Holiday
        /// </summary>
        /// <param name="year"></param>
        public static DateTime JuneHoliday(int year)
        {
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 6, 1));
        }

        /// <summary>
        /// Lá Saoire i mí Lúnasa - August Holiday
        /// </summary>
        /// <param name="year"></param>
        public static DateTime AugustHoliday(int year)
        {
            return HolidayCalculator.FindFirstMonday(new DateTime(year, 8, 1));
        }

        /// <summary>
        /// Lá Saoire i mí Dheireadh Fómhair - October Holiday
        /// </summary>
        /// <param name="year"></param>

        public static DateTime OctoberHoliday(int year)
        {
            return HolidayCalculator.FindPrevious(new DateTime(year, 10, 31), DayOfWeek.Monday);
        }

        /// <summary>
        /// Lá Nollag - Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return HolidayCalculator.FixWeekend(new DateTime(year, 12, 25));
        }

        /// <summary>
        /// Lá Fhéile Stiofáin - St Stephen's Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime StStephen(int year)
        {
            var hol = new DateTime(year, 12, 26);
            bool isSundayOrMonday =
                hol.DayOfWeek == DayOfWeek.Sunday ||
                hol.DayOfWeek == DayOfWeek.Monday;
            hol = HolidayCalculator.FixWeekend(hol);
            if (isSundayOrMonday)
                hol = hol.AddDays(1);
            return hol;
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
        /// Public holiday names in Irish Gaelic.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string> {
                { NewYear(year), "Lá Caille" },
                { StPatricksDay(year), "Lá Fhéile Pádraig" } };
            DateTime easter = HolidayCalculator.GetEaster(year);
            bHols.Add(EasterMonday(easter), "Luan Cásca");
            bHols.Add(MayDay(year), "Lá Bealtaine");
            bHols.Add(JuneHoliday(year), "Lá Saoire i mí an Mheithimh");
            bHols.Add(AugustHoliday(year), "Lá Saoire i mí Lúnasa");
            bHols.Add(OctoberHoliday(year), "Lá Saoire i mí Dheireadh Fómhair");
            bHols.Add(Christmas(year), "Lá Nollag");
            bHols.Add(StStephen(year), "Lá Fhéile Stiofáin");
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
                case 4:
                    if (StPatricksDay(year) == date)
                        return true;
                    if (EasterMonday(year) == date)
                        return true;
                    break;

                case 5:
                    if (MayDay(year) == date)
                        return true;
                    break;

                case 6:
                    if (JuneHoliday(year) == date)
                        return true;
                    break;

                case 8:
                    if (AugustHoliday(year) == date)
                        return true;
                    break;

                case 10:
                    if (OctoberHoliday(year) == date)
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