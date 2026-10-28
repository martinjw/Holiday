using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Public holidays in Latvia.
    /// Sources used:
    ///  * https://likumi.lv/ta/id/72608-par-svetku-atceres-un-atzimejamam-dienam (law "Par svētku, atceres un atzīmējamām dienām", article 1)
    ///  * https://en.wikipedia.org/wiki/Public_holidays_in_Latvia
    /// </summary>
    public class LatviaPublicHoliday : PublicHolidayBase
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
        /// Public holiday names in Latvian.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var holidayNames = new Dictionary<DateTime, string>
            {
                {new DateTime(year, 1, 1), "Jaungada diena"}, // New Year's Day
                {new DateTime(year, 5, 1), "Darba svētki, Latvijas Republikas Satversmes sapulces sasaukšanas diena"}, // Labour Day, Convocation of the Constituent Assembly
                {new DateTime(year, 6, 23), "Līgo diena"}, // Midsummer Eve
                {new DateTime(year, 6, 24), "Jāņu diena"}, // Midsummer Day
                {new DateTime(year, 11, 18), "Latvijas Republikas Proklamēšanas diena"}, // Proclamation Day
                {new DateTime(year, 12, 25), "Pirmie Ziemassvētki"}, // Christmas Day
                {new DateTime(year, 12, 26), "Otrie Ziemassvētki"}, // Second Day of Christmas
                {new DateTime(year, 12, 31), "Vecgada diena"}, // New Year's Eve
                {HolidayCalculator.FindOccurrenceOfDayOfWeek(new DateTime(year, 5, 1), DayOfWeek.Sunday, 2), "Mātes diena"} // Mother's Day, second Sunday of May
            };

            var easter = HolidayCalculator.GetEaster(year);

            holidayNames.Add(easter.AddDays(-2), "Lielā Piektdiena"); // Good Friday
            holidayNames.Add(easter, "Pirmās Lieldienas"); // Easter Sunday
            holidayNames.Add(easter.AddDays(1), "Otrās Lieldienas"); // Easter Monday

            // Pentecost and Mother's Day can fall on the same Sunday (e.g. 2008)
            var pentecost = easter.AddDays(49);
            if (holidayNames.ContainsKey(pentecost))
                holidayNames[pentecost] = "Mātes diena, Vasarsvētki"; // Mother's Day, Pentecost
            else
                holidayNames.Add(pentecost, "Vasarsvētki"); // Pentecost

            if (year >= 2002)
                holidayNames.Add(new DateTime(year, 5, 4), "Latvijas Republikas Neatkarības atjaunošanas diena"); // Restoration of Independence Day

            if (year >= 2007)
            {
                holidayNames.Add(new DateTime(year, 12, 24), "Ziemassvētku vakars"); // Christmas Eve

                // 4 May and 18 November on a weekend move the day off to the next working day ("pārceltā brīvdiena" = transferred day off)
                AddTransferredHoliday(holidayNames, new DateTime(year, 5, 4), "Latvijas Republikas Neatkarības atjaunošanas diena (pārceltā brīvdiena)");
                AddTransferredHoliday(holidayNames, new DateTime(year, 11, 18), "Latvijas Republikas Proklamēšanas diena (pārceltā brīvdiena)");
            }

            // Song and Dance Festival closing day ("Vispārējo latviešu Dziesmu un deju svētku noslēguma diena"), a holiday since 2014;
            // the date is set per festival, and on a weekend the day off moves to Monday
            if (year == 2018)
            {
                holidayNames.Add(new DateTime(2018, 7, 8), "Vispārējo latviešu Dziesmu un deju svētku noslēguma diena");
                holidayNames.Add(new DateTime(2018, 7, 9), "Vispārējo latviešu Dziesmu un deju svētku noslēguma diena (pārceltā brīvdiena)");
            }

            if (year == 2023)
            {
                holidayNames.Add(new DateTime(2023, 5, 29), "Latvijas hokeja izlases bronzas medaļas izcīnīšanas diena"); // Ice hockey World Championship bronze medal
                holidayNames.Add(new DateTime(2023, 7, 9), "Vispārējo latviešu Dziesmu un deju svētku noslēguma diena");
                holidayNames.Add(new DateTime(2023, 7, 10), "Vispārējo latviešu Dziesmu un deju svētku noslēguma diena (pārceltā brīvdiena)");
            }

            return holidayNames;
        }

        private static void AddTransferredHoliday(IDictionary<DateTime, string> holidayNames, DateTime holiday, string name)
        {
            var transferred = HolidayCalculator.FixWeekend(holiday);
            if (transferred != holiday)
                holidayNames.Add(transferred, name);
        }

        /// <summary>
        /// Check if a specific date is a public holiday.
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a public holiday</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            return PublicHolidays(dt.Year).Contains(dt.Date);
        }
    }
}
