using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// Represents holidays in the Turkey
    /// </summary>
    public class TurkeyPublicHoliday : PublicHolidayBase
    {
        private static IEnumerable<int> GetHijriYears(int year)
        {
            var diff = year - 621;
            var hijriYear = Convert.ToInt32(Math.Round(diff + decimal.Divide(diff, 33)
#if NET6_0_OR_GREATER
            
                , MidpointRounding.ToZero
#endif
                ));
            return new List<int> { hijriYear, hijriYear + 1 }.AsReadOnly();
        }

        /// <summary>
        /// New Year's Day - January 1
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Date of in the given year.</returns>
        public static Holiday NewYear(int year)
        {
            return new Holiday(new DateTime(year, 1, 1), "New Year", "Yılbaşı");
        }

        /// <summary>
        /// National Sovereignty and Children's Day - April 23
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static Holiday NationalSovereigntyAndChildrensDay(int year)
        {
            return new Holiday(new DateTime(year, 4, 23), "National Sovereignty and Children's Day", "Ulusal Egemenlik ve Çocuk Bayramı");
        }

        /// <summary>
        /// Labour and Solidarity - Day May 1
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static Holiday LabourDay(int year)
        {
            return new Holiday(new DateTime(year, 5, 1), "Labour and Solidarity Day", "Emek ve Dayanışma Günü");
        }

        /// <summary>
        /// Ramadan Holiday - 1st Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<Holiday> RamadanFirstDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            var hijriYears = GetHijriYears(year);
            foreach (var hijriYear in hijriYears)
            {
                var dateTime = hijriCalendar.ToDateTime(hijriYear, 10, 1, 0, 0, 0, 0);
                if (dateTime.Year != year)
                {
                    continue;
                }

                yield return new Holiday(dateTime, "Ramadan", "Ramazan Bayramı 1. Günı");
            }
        }

        /// <summary>
        /// Ramadan Holiday - 2nd Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<Holiday> RamadanSecondDay(int year)
        {
            return RamadanFirstDay(year).Select(x=> new Holiday(x.HolidayDate.AddDays(1), "Ramadan", "Ramazan Bayramı 2. Gün"));
        }

        /// <summary>
        ///  Ramadan Holiday - 3rd Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<Holiday> RamadanThirdDay(int year)
        {
            return RamadanFirstDay(year).Select(x => new Holiday(x.HolidayDate.AddDays(2), "Ramadan", "Ramazan Bayramı 3. Gün"));
        }

        /// <summary>
        ///  Youth And Sports Day - May 19
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static Holiday YouthAndSportsDay(int year)
        {
            return new Holiday(new DateTime(year, 5, 19), "Youth and Sports Day", "Gençlik ve Spor Bayramı");
        }

        /// <summary>
        ///  Feast of Sacrifice First Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<Holiday> FeastOfSacrificesFirstDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            var hijriYears = GetHijriYears(year);
            foreach (var hijriYear in hijriYears)
            {
                var dateTime = hijriCalendar.ToDateTime(hijriYear, 12, 10, 0, 0, 0, 0);
                if (dateTime.Year != year)
                {
                    continue;
                }

                yield return new Holiday(dateTime, "Feast of Sacrifice", "Kurban Bayramı 1. Gün");
            }
        }

        /// <summary>
        ///  Feast of Sacrifice Second Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<Holiday> FeastOfSacrificesSecondDay(int year)
        {
            return FeastOfSacrificesFirstDay(year).Select(x => new Holiday(x.HolidayDate.AddDays(1), "Feast of Sacrifice", "Kurban Bayramı 2. Gün"));
        }

        /// <summary>
        ///  Feast of Sacrifice Third Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<Holiday> FeastOfSacrificesThirdDay(int year)
        {
            return FeastOfSacrificesFirstDay(year).Select(x => new Holiday(x.HolidayDate.AddDays(2), "Feast of Sacrifice", "Kurban Bayramı 3. Gün"));
        }

        /// <summary>
        ///  Feast of Sacrifice Fourth Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<Holiday> FeastOfSacrificesFourthdDay(int year)
        {
            return FeastOfSacrificesFirstDay(year).Select(x => new Holiday(x.HolidayDate.AddDays(3), "Feast of Sacrifice", "Kurban Bayramı 4. Gün"));
        }


        /// <summary>
        /// Democracy and National Unity Day - Jul 15
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static Holiday DemocracyAndNationalUnityDay(int year)
        {
            return new Holiday(new DateTime(year, 7, 15), "Democracy and National Unity Day", "Demokrasi ve Millî Birlik Günü");
        }

        /// <summary>
        /// Victory Day - Aug 30
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static Holiday VictoryDay(int year)
        {
            return new Holiday(new DateTime(year, 8, 30), "Victory Day", "Zafer Bayramı");
        }

        /// <summary>
        /// Republic Day - Oct 29
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static Holiday RepublicDay(int year)
        {
            return new Holiday(new DateTime(year, 10, 29), "Republic Day", "Cumhuriyet Bayramı");
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

        /// <summary>
        /// Public holiday information
        /// </summary>
        /// <param name="year">Specify the year</param>
        /// <returns>A list of holiday with names</returns>
        public override IList<Holiday> PublicHolidaysInformation(int year)
        {
            var list = new List<Holiday>
            {
                NewYear(year),
                NationalSovereigntyAndChildrensDay(year),
                LabourDay(year),
                YouthAndSportsDay(year),
                VictoryDay(year),
                RepublicDay(year)
            };
            if (year >= 2017)
            {
                list.Add(DemocracyAndNationalUnityDay(year));
            }

            foreach (var ramadan in RamadanFirstDay(year))
            {
                list.Add(ramadan);
                list.Add(new Holiday(ramadan.HolidayDate.AddDays(1), ramadan.EnglishName, "Ramazan Bayramı 2. Gün"));
                list.Add(new Holiday(ramadan.HolidayDate.AddDays(2), ramadan.EnglishName, "Ramazan Bayramı 3. Gün"));
            }
            foreach (var feast in FeastOfSacrificesFirstDay(year))
            {
                list.Add(feast);
                list.Add(new Holiday(feast.HolidayDate.AddDays(1), feast.EnglishName, "Kurban Bayramı 2. Gün"));
                list.Add(new Holiday(feast.HolidayDate.AddDays(2), feast.EnglishName, "Kurban Bayramı 3. Gün"));
                list.Add(new Holiday(feast.HolidayDate.AddDays(3), feast.EnglishName, "Kurban Bayramı 4. Gün"));
            }

            return list.OrderBy(x=> x.HolidayDate).ToList();
        }

        /// <summary>
        /// Public holiday names in Turkey.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            //distinctBy as there can be 2 holidays on the same day
            var holidays = PublicHolidaysInformation(year).DistinctBy(h => h.HolidayDate);

            return holidays.ToDictionary(holiday => holiday.HolidayDate, holiday => holiday.Name);
        }

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
    }
}
