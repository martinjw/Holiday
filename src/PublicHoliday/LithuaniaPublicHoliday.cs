using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays in Lithuania.
    /// Sources used:
    ///  * https://en.wikipedia.org/wiki/Public_holidays_in_Lithuania
    /// </summary>
    public class LithuaniaPublicHoliday : PublicHolidayBase
    {
        #region Individual Holidays
        /// <summary>
        /// Motinos diena - Mother's Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime MothersDay(int year)
        {
            var hol = new DateTime(year, 5, 1);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Sunday, 1);
            return hol;
        }

        /// <summary>
        /// Tėvo diena - Father's Day
        /// </summary>
        /// <param name="year">The year.</param>
        public static DateTime FathersDay(int year)
        {
            var hol = new DateTime(year, 6, 1);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Sunday, 1);
            return hol;
        }

        /// <summary>
        /// Šv. Velykos - Easter
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime Easter(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            return hol;
        }

        /// <summary>
        /// Antroji šv. Velykų diena - Easter Monday
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime EasterMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }

        #endregion

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
        /// Public holiday names in Lithuania.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var holidayNames = new Dictionary<DateTime, string>
            {
                {new DateTime(year, 1, 1), "Naujųjų metų diena"},
                {new DateTime(year, 2, 16), "Lietuvos valstybės atkūrimo diena"},
                {new DateTime(year, 3, 11), "Lietuvos nepriklausomybės atkūrimo diena"},
                {Easter(year), "Šv. Velykos"},
                {EasterMonday(year), "Antroji šv. Velykų diena"},
                {new DateTime(year, 5, 1), "Tarptautinė darbo diena"},
                {FathersDay(year), "Tėvo diena"},
                {new DateTime(year, 6, 24), "Rasos ir Joninių diena"},
                {new DateTime(year, 7, 6), "Valstybės (Lietuvos karaliaus Mindaugo karūnavimo) ir Tautiškos giesmės diena"},
                {new DateTime(year, 11, 1), "Visų šventųjų diena"},
                {new DateTime(year, 11, 2), "Mirusiųjų atminimo (Vėlinių) diena"},
                {new DateTime(year, 12, 24), "Šv. Kūčios"},
                {new DateTime(year, 12, 25), "Šv. Kalėdos"},
                {new DateTime(year, 12, 26), "Šv. Kalėdos"}
            };

            var mothersDayDate = MothersDay(year);
            if (holidayNames.ContainsKey(mothersDayDate))
            {
                holidayNames[mothersDayDate] = "Tarptautinė darbo diena ir Motinos diena";
            }
            else
            {
                holidayNames.Add(mothersDayDate, "Motinos diena");
            }

            if (year >= 2000)
                holidayNames.Add(new DateTime(year, 8, 15), "Žolinė (Švč. Mergelės Marijos ėmimo į dangų diena)");

            return holidayNames;
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            return PublicHolidays(dt.Year).Contains(dt);
        }
    }
}