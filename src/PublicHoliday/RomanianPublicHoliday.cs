using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Holidays in Romanian. Source https://en.wikipedia.org/wiki/Public_holidays_in_Romania
    /// </summary>
    public class RomanianPublicHoliday : PublicHolidayBase
    {
        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IList<DateTime> PublicHolidays(int year)
            => PublicHolidayNames(year)
                .Select(x => x.Key.Date)
                .OrderBy(x => x)
                .ToList();

        /// <summary>
        /// Public holiday names in Romanian.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var holidayNames = new Dictionary<DateTime, string>();

            var newYear = NewYear(year).ToArray();
            holidayNames.Add(newYear[0], "Anul nou");
            holidayNames.Add(newYear[1], "Anul nou");

            var epiphany = Epiphany(year);
            if (epiphany.HasValue)
                holidayNames.Add(epiphany.Value, "Bobotează");

            var saintJohnTheBaptist = SaintJohnTheBaptist(year);
            if (saintJohnTheBaptist.HasValue)
                holidayNames.Add(saintJohnTheBaptist.Value, "Sfântul Ion");

            holidayNames.Add(UnificationOfPrincipalities(year), "Unirea Principatelor Române");

            var easter = HolidayCalculator.GetOrthodoxEaster(year).AddHours(1).AddMinutes(1); // to avoid duplicate key

            holidayNames.Add(EasterFriday(easter), "Vinerea Mare");
            holidayNames.Add(easter, "Paștele");
            holidayNames.Add(EasterMonday(easter), "Paștele");

            holidayNames.Add(LabourDay(year), "Ziua Muncii");

            var childrenDay = ChildrenDay(year);
            if (childrenDay.HasValue)
                holidayNames.Add(childrenDay.Value, "Ziua Copilului");

            var whitMonday = WhitMonday(easter).ToArray();
            holidayNames.Add(whitMonday[0], "Rusaliile");
            holidayNames.Add(whitMonday[1], "Rusaliile");

            holidayNames.Add(SaintMaryDay(year), "Sfânta Maria Mare");

            holidayNames.Add(SaintAndrewDay(year), "Sfântul Andrei");

            holidayNames.Add(NationalDay(year), "Ziua Națională a României");

            var christmas = ChristmasDay(year).ToArray();
            holidayNames.Add(christmas[0], "Crăciunul");
            holidayNames.Add(christmas[1], "Crăciunul");

            return holidayNames;
        }

        /// <summary>
        /// Check if a specific date is a public holiday
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            var year = dt.Year;
            var date = dt.Date;

            var holidays = PublicHolidays(year);

            foreach (var holiday in holidays)
            {
                if (holiday == date) return true;
            }

            return false;
        }

        #region private

        /// <summary>
        /// New Year (Anul nou)
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>Dates of given year</returns>
        public static IEnumerable<DateTime> NewYear(int year)
            => new[] { new DateTime(year, 1, 1), new DateTime(year, 1, 2) };

        /// <summary>
        /// Epiphany (Bobotează). Public holiday starting with 2024
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static DateTime? Epiphany(int year)
        {
            if (year >= 2024) return new DateTime(year, 1, 6);

            return null;
        }

        /// <summary>
        /// Saint John the Baptist (Sfântul Ion). Public holiday starting with 2024
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static DateTime? SaintJohnTheBaptist(int year)
        {
            if (year >= 2024) return new DateTime(year, 1, 7);

            return null;
        }

        /// <summary>
        /// Day of the Unification of the Romanian Principalities (Unirea Principatelor Române)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime UnificationOfPrincipalities(int year)
            => new DateTime(year, 1, 24);

        /// <summary>
        /// Easter Orthodox Good Friday (Vinerea Mare)
        /// </summary>
        /// <param name="easter">The easter date</param>
        /// <returns></returns>
        public static DateTime EasterFriday(DateTime easter)
            => easter.AddDays(-2);

        /// <summary>
        /// Easter Monday
        /// </summary>
        /// <param name="easter">The easter date</param>
        /// <returns></returns>
        public static DateTime EasterMonday(DateTime easter)
            => easter.AddDays(1);

        /// <summary>
        /// International Labour Day (Ziua Muncii)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime LabourDay(int year)
            => new DateTime(year, 5, 1);

        /// <summary>
        /// Children Day (Ziua Copilului). Public holiday starting with 2017
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime? ChildrenDay(int year)
        {
            if (year >= 2017) return new DateTime(year, 6, 1);

            return null;
        }

        /// <summary>
        /// Easter Whit Monday (Rusaliile). 49 - Sunday (Descent of the Holy Spirit), 50 - Monday
        /// </summary>
        /// <param name="easter"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> WhitMonday(DateTime easter)
            => new[] { easter.AddDays(49), easter.AddDays(50) };

        /// <summary>
        /// St Mary's Day (Adormirea Maicii Domnului/Sfânta Maria Mare)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SaintMaryDay(int year)
            => new DateTime(year, 8, 15);

        /// <summary>
        /// St. Andrew's Day (Sfântul Andrei)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SaintAndrewDay(int year)
            => new DateTime(year, 11, 30);

        /// <summary>
        /// National Day of Romania (Ziua Națională a României)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime NationalDay(int year)
            => new DateTime(year, 12, 1);

        /// <summary>
        /// Christmas Day (Crăciunul)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> ChristmasDay(int year)
            => new[] { new DateTime(year, 12, 25), new DateTime(year, 12, 26) };

        #endregion
    }
}
