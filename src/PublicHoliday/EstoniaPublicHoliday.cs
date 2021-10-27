using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays in Estonia.
    /// Sources used:
    ///  * https://et.wikipedia.org/wiki/Eesti_riigip%C3%BChad
    ///  * https://en.wikipedia.org/wiki/Public_holidays_in_Estonia
    ///  * https://riigipühad.ee/
    /// </summary>
    public class EstoniaPublicHoliday : PublicHolidayBase
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
        /// Public holiday names in Estonian.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var holidayNames = new Dictionary<DateTime, string>
            {
                {new DateTime(year, 1, 1), "Uusaasta"},
                {new DateTime(year, 2, 24), "Iseseisvumispäev"},
                {new DateTime(year, 5, 1), "Kevadpüha"},
                {new DateTime(year, 6, 23), "Võidupüha"},
                {new DateTime(year, 6, 24), "Jaanipäev"},
                {new DateTime(year, 8, 20), "Taasiseseisvumispäev"},
                {new DateTime(year, 12, 25), "Esimene jõulupüha"},
                {new DateTime(year, 12, 26), "Teine jõulupüha"}
            };

            if (year >= 2005)
                holidayNames.Add(new DateTime(year, 12, 24), "Jõululaupäev");

            var easter = HolidayCalculator.GetEaster(year);
            
            holidayNames.Add(easter.AddDays(-2), "Suur reede");
            holidayNames.Add(easter, "Ülestõusmispühade 1. püha");
            holidayNames.Add(easter.AddDays(49), "Nelipühade 1. püha");
            
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