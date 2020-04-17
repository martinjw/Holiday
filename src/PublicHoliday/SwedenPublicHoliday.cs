using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Swedish public holidays
    /// </summary>
    public class SwedenPublicHoliday : PublicHolidayBase
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
        /// Epiphany - 13 days after christmas
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Epiphany(int year) {
            return new DateTime(year, 1, 6);
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
        /// Whit Sunday - 7th Sunday after Easter
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
        /// National Day - June 6th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalDay(int year) {
            return new DateTime(year, 6, 6);
        }

        /// <summary>
        /// Midsummer eve, first friday after June 19th
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime MidsummerEve(int year) {
            return GetMidsummer(year);
        }

        /// <summary>
        /// Midsummer day, day after midsummer eve
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime MidsummerDay(int year) {
            return GetMidsummer(year).AddDays(1);
        }

        private static DateTime GetMidsummer(int year) {
            DateTime dt = new DateTime(year, 6, 19);
            for (int i = 0; i < 7; i++) {
                if (dt.AddDays(i).DayOfWeek == DayOfWeek.Friday)
                    return dt.AddDays(i);
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// All saints day, day after all saints eve
        /// First saturday after Oct. 31
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime AllSaintsDay(int year) {
            return GetAllSaintsDay(year);
        }

        private static DateTime GetAllSaintsDay(int year) {
            DateTime dt = new DateTime(year, 10, 31);
            for (int i = 0; i < 7; i++) {
                if (dt.AddDays(i).DayOfWeek == DayOfWeek.Saturday)
                    return dt.AddDays(i);
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// Christmas Eve - December 24
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime ChristmasEve(int year) {
            return new DateTime(year, 12, 24);
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

        /// <summary>
        /// New Years Eve - December 31
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NewYearsEve(int year) {
            return new DateTime(year, 12, 31);
        }
        
        #endregion

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
        /// Public holiday names in Swedish.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var easter = HolidayCalculator.GetEaster(year);

            var labourDay = LabourDay(year);
            var ascension = Ascension(easter);
            if (ascension == labourDay) ascension = ascension.AddSeconds(1); //ascension can fall on Mayday
            var bHols = new Dictionary<DateTime, string>
            {
                {NewYear(year), "Nyårsdagen"},
                {Epiphany(year), "Trettondag jul"},
                {GoodFriday(easter), "Långfredag"},
                { easter, "Påskdagen"},
                {EasterMonday(easter), "Annandag påsk"},
                { labourDay, "Första maj"},
                {ascension, "Kristi himmelfärds dag"},
                {WhitSunday(easter), "Pingstdagen"},
                {NationalDay(year), "Nationaldagen"},
                {MidsummerEve(year), "Midsommarafton"},
                {MidsummerDay(year), "Midsommardagen"},
                {AllSaintsDay(year), "Alla helgons dag" },
                {ChristmasEve(year), "Julafton"},
                {Christmas(year), "Juldagen"},
                {BoxingDay(year), "Annandag jul"},
                {NewYearsEve(year), "Nyårsafton" }
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
                    if (Epiphany(year) == date)
                        return true;
                    break;
                case 3:
                case 4:
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
                    if (Ascension(year) == date)
                        return true;
                    if (WhitSunday(year) == date)
                        return true;
                    break;
                case 6:
                    if (Ascension(year) == date)
                        return true;
                    if (WhitSunday(year) == date)
                        return true;
                    if (NationalDay(year) == date)
                        return true;
                    if (MidsummerEve(year) == date)
                        return true;
                    if (MidsummerDay(year) == date)
                        return true;
                    break;
                case 11:
                    if (AllSaintsDay(year) == date)
                        return true;
                    break;
                case 12:
                    if (ChristmasEve(year) == date)
                        return true;
                    if (Christmas(year) == date)
                        return true;
                    if (BoxingDay(year) == date)
                        return true;
                    if (NewYearsEve(year) == date) 
                        return true;
                    break;
            }

            return false;
        }

    }
}
