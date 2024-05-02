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
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// National Sovereignty and Children's Day - April 23
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalSovereigntyAndChildrensDay(int year)
        {
            return new DateTime(year, 4, 23);
        }

        /// <summary>
        /// Labour and Solidarity - Day May 1
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Ramadan Holiday - 1st Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> RamadanFirstDay(int year)
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

                yield return dateTime;
            }
        }

        /// <summary>
        /// Ramadan Holiday - 2nd Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> RamadanSecondDay(int year)
        {
            return RamadanFirstDay(year).Select(x=> x.AddDays(1));
        }

        /// <summary>
        ///  Ramadan Holiday - 3rd Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> RamadanThirdDay(int year)
        {
            return RamadanFirstDay(year).Select(x => x.AddDays(2));
        }

        /// <summary>
        ///  Youth And Sports Day - May 19
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime YouthAndSportsDay(int year)
        {
            return new DateTime(year, 5, 19);
        }

        /// <summary>
        ///  Feast of Sacrifice First Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> FeastOfSacrificesFirstDay(int year)
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

                yield return dateTime;
            }
        }

        /// <summary>
        ///  Feast of Sacrifice Second Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> FeastOfSacrificesSecondDay(int year)
        {
            return FeastOfSacrificesFirstDay(year).Select(x => x.AddDays(1));
        }

        /// <summary>
        ///  Feast of Sacrifice Third Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> FeastOfSacrificesThirdDay(int year)
        {
            return FeastOfSacrificesFirstDay(year).Select(x => x.AddDays(2));
        }

        /// <summary>
        ///  Feast of Sacrifice Fourth Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> FeastOfSacrificesFourthdDay(int year)
        {
            return FeastOfSacrificesFirstDay(year).Select(x => x.AddDays(3));
        }


        /// <summary>
        /// Democracy and National Unity Day - Jul 15
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime DemocracyAndNationalUnityDay(int year)
        {
            return new DateTime(year, 7, 15);
        }

        /// <summary>
        /// Victory Day - Aug 30
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime VictoryDay(int year)
        {
            return new DateTime(year, 8, 30);
        }

        /// <summary>
        /// Republic Day - Oct 29
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of in the given year.</returns>
        public static DateTime RepublicDay(int year)
        {
            return new DateTime(year, 10, 29);
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
        /// Public holiday names in Turkey.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var holidayNames = new Dictionary<DateTime, string>();
            var values = new List<KeyValuePair<DateTime, string>>()
            {
                new KeyValuePair<DateTime, string>(NewYear(year), "Yılbaşı Tatili"),
                new KeyValuePair<DateTime, string>(NationalSovereigntyAndChildrensDay(year), "Ulusal Egemenlik ve Çocuk Bayramı"),
                new KeyValuePair<DateTime, string>(LabourDay(year), "Emek ve Dayanışma Günü"),
                new KeyValuePair<DateTime, string>(YouthAndSportsDay(year), "Atatürk’ü Anma, Gençlik ve Spor Bayramı"),
                new KeyValuePair<DateTime, string>(VictoryDay(year), "Zafer Bayramı"),
                new KeyValuePair<DateTime, string>(RepublicDay(year), "Cumhuriyet Bayramı"),
            };
            foreach (var ramadan in RamadanFirstDay(year))
            {
                values.Add(new KeyValuePair<DateTime, string>(ramadan, "Ramazan Bayramı 1. Gün"));
                values.Add(new KeyValuePair<DateTime, string>(ramadan.AddDays(1), "Ramazan Bayramı 2. Gün"));
                values.Add(new KeyValuePair<DateTime, string>(ramadan.AddDays(2), "Ramazan Bayramı 3. Gün"));
            }

            foreach (var dateTime in FeastOfSacrificesFirstDay(year))
            {
                values.Add(new KeyValuePair<DateTime, string>(dateTime,
                    "Kurban Bayramı 1. Gün"));
                values.Add(new KeyValuePair<DateTime, string>(dateTime.AddDays(1),
                    "Kurban Bayramı 2. Gün"));
                values.Add(new KeyValuePair<DateTime, string>(dateTime.AddDays(2),
                    "Kurban Bayramı 3. Gün"));
                values.Add(new KeyValuePair<DateTime, string>(dateTime.AddDays(3),
                    "Kurban Bayramı 4. Gün"));

            }

            if (year >= 2017)
            {
                values.Add(new KeyValuePair<DateTime, string>(DemocracyAndNationalUnityDay(year), "Demokrasi ve Milli Birlik Günü"));
            }

            foreach (var valueItem in values.OrderBy(x=> x.Key))
            {
                KeyValuePair<DateTime, string> holidayName = holidayNames.FirstOrDefault(item => item.Key == valueItem.Key);
                if (holidayName.Value != null)
                {
                    holidayNames[valueItem.Key] = $"{holidayNames[valueItem.Key]}, {valueItem.Value}";
                    continue;
                }

                holidayNames.Add(valueItem.Key, valueItem.Value);
            }

            return holidayNames;
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
