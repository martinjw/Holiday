using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Norway
    /// </summary>
    /// <seealso cref="PublicHoliday.PublicHolidayBase" />
    public class NorwayPublicHoliday : PublicHolidayBase
    {

        #region Individual Holidays

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
        /// Maundy Thursday - Thursday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime MaundyThursday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-3);
            return hol;
        }

        private static DateTime MaundyThursday(DateTime easter)
        {
            return easter.AddDays(-3);
        }

        /// <summary>
        /// Good Friday - Friday before Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        private static DateTime GoodFriday(DateTime easter)
        {
            return easter.AddDays(-2);
        }

        /// <summary>
        /// Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Easter(int year)
        {
            return HolidayCalculator.GetEaster(year);
        }

        /// <summary>
        /// Easter Monday 1st Monday after Easter
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
        /// Labour Day - Mai 1st
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Constitution Day - Mai 17th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime ConstitutionDay(int year)
        {
            return new DateTime(year, 5, 17);
        }

        /// <summary>
        /// Ascension 6th Thursday after Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Ascension(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(4 + (7 * 5));
            return hol;
        }

        private static DateTime Ascension(DateTime easter)
        {
            return easter.AddDays(4 + (7 * 5));
        }

        /// <summary>
        /// Whit Monday - 7th Sunday after Easter
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime WhitSunday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(7 * 7);
            return hol;
        }

        private static DateTime WhitSunday(DateTime easter)
        {
            return easter.AddDays(7 * 7);
        }

        /// <summary>
        /// Whit Monday - 7th Monday after Easter
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime WhitMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays((7 * 7) + 1);
            return hol;
        }

        private static DateTime WhitMonday(DateTime easter)
        {
            return easter.AddDays(1 + (7 * 7));
        }

        /// <summary>
        /// Christmas - December 25
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Boxing Day - December 26
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime BoxingDay(int year)
        {
            return new DateTime(year, 12, 26);
        }

        #endregion

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
        /// Public holiday names in Norwegian.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            DateTime easter = HolidayCalculator.GetEaster(year);

            var bHols = new Dictionary<DateTime, string>
            {
                {NewYear(year), "Første nyttårsdag"},
                {MaundyThursday(easter), "Skjærtorsdag"},
                {GoodFriday(easter), "Langfredag"},
                {easter, "Første påskedag"},
                {EasterMonday(easter), "Andre påskedag"},
                {LabourDay(year), "Første mai"},
                {ConstitutionDay(year), "Grunnlovsdagen"},
            };
            var ascension = Ascension(easter);
            if (!bHols.ContainsKey(ascension))
            {
                //Ascension in 2012 is 17 May - same as Consitition Day
                bHols.Add(ascension, "Kristi himmelfartsdag");
            }
            var whitSunday = WhitSunday(easter);
            if (!bHols.ContainsKey(whitSunday))
            {
                bHols.Add(whitSunday, "Første pinsedag");
            }
            bHols.Add(WhitMonday(easter), "Andre pinsedag");
            bHols.Add(Christmas(year), "Første juledag");
            bHols.Add(BoxingDay(year), "Andre juledag");
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
                    break;
                case 3:
                case 4:
                    if (MaundyThursday(year) == date)
                        return true;
                    if (GoodFriday(year) == date)
                        return true;
                    if (HolidayCalculator.GetEaster(year) == date)
                        return true;
                    if (EasterMonday(year) == date)
                        return true;
                    if (Ascension(year) == date)
                        return true;
                    break;
                case 5:
                    if (LabourDay(year) == date)
                        return true;
                    if (ConstitutionDay(year) == date)
                        return true;
                    if (Ascension(year) == date)
                        return true;
                    if (WhitSunday(year) == date)
                        return true;
                    if (WhitMonday(year) == date)
                        return true;
                    break;
                case 6:
                    if (Ascension(year) == date)
                        return true;
                    if (WhitSunday(year) == date)
                        return true;
                    if (WhitMonday(year) == date)
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
