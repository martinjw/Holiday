using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Islamic;
using Common = PublicHoliday.HolidayDefinitions.Common;
using Local = PublicHoliday.HolidayDefinitions.CountrySpecific.Turkey;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Localization;


namespace PublicHoliday
{
    /// <summary>
    /// Represents holidays in the Turkey
    /// </summary>
    public class TurkeyPublicHoliday : PublicHolidayBase
    {

        /// <summary>
        /// Culture whose language this calendar's holiday names are in: Turkish.
        /// Used by <see cref="Holiday.GetName(CultureInfo)"/> when the requested
        /// culture has no translation.
        /// </summary>
        protected override CultureInfo CountryCulture => _defaultCulture;

        private static readonly CultureInfo _defaultCulture = SafeCulture.Get("tr-TR", "tr");
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
        /// <returns>Date of in the given year.</returns>
        public static DateTime NationalSovereigntyAndChildrensDay(int year)
        {
            return new DateTime(year, 4, 23);
        }

        /// <summary>
        /// Labour and Solidarity - Day May 1
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime LabourDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Ramadan Holiday - 1st Day
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> RamadanFirstDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            var hijriYears = IslamicHolidayDefinition.HijriYearsOverlapping(year);
            foreach (var hijriYear in hijriYears)
            {
                // Ramadan Bayram (Eid al-Fitr) is on Shawwal 1 — Shawwal is the 10th month in the Hijri calendar
                var dateTime = hijriCalendar.ToDateTime(hijriYear, 10, 1, 0, 0, 0, 0);
                if (dateTime.Year != year)
                    continue;

                yield return dateTime;
            }
        }

        /// <summary>
        /// Ramadan Holiday - 2nd Day
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> RamadanSecondDay(int year)
        {
            return RamadanFirstDay(year).Select(x=> x.AddDays(1));
        }

        /// <summary>
        ///  Ramadan Holiday - 3rd Day
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> RamadanThirdDay(int year)
        {
            return RamadanFirstDay(year).Select(x => x.AddDays(2));
        }

        /// <summary>
        ///  Youth And Sports Day - May 19
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime YouthAndSportsDay(int year)
        {
            return new DateTime(year, 5, 19);
        }

        /// <summary>
        ///  Feast of Sacrifice First Day
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> FeastOfSacrificesFirstDay(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            var hijriYears = IslamicHolidayDefinition.HijriYearsOverlapping(year);
            foreach (var hijriYear in hijriYears)
            {
                var dateTime = hijriCalendar.ToDateTime(hijriYear, 12, 10, 0, 0, 0, 0);
                if (dateTime.Year != year)
                    continue;

                yield return dateTime;
            }
        }

        /// <summary>
        ///  Feast of Sacrifice Second Day
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> FeastOfSacrificesSecondDay(int year)
        {
            return FeastOfSacrificesFirstDay(year).Select(x => x.AddDays(1));
        }

        /// <summary>
        ///  Feast of Sacrifice Third Day
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> FeastOfSacrificesThirdDay(int year)
        {
            return FeastOfSacrificesFirstDay(year).Select(x => x.AddDays(2));
        }

        /// <summary>
        ///  Feast of Sacrifice Fourth Day
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static IEnumerable<DateTime> FeastOfSacrificesFourthdDay(int year)
        {
            return FeastOfSacrificesFirstDay(year).Select(x => x.AddDays(3));
        }


        /// <summary>
        /// Democracy and National Unity Day - Jul 15
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime DemocracyAndNationalUnityDay(int year)
        {
            return new DateTime(year, 7, 15);
        }

        /// <summary>
        /// Victory Day - Aug 30
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime VictoryDay(int year)
        {
            return new DateTime(year, 8, 30);
        }

        /// <summary>
        /// Republic Day - Oct 29
        /// </summary>
        /// <returns>Date of in the given year.</returns>
        public static DateTime RepublicDay(int year)
        {
            return new DateTime(year, 10, 29);
        }

        /// <summary>
        /// All Turkish public holidays for the year (names in Turkish).
        /// The Islamic-calendar holidays (Ramazan Bayramı 3 days, Kurban Bayramı 4 days) are
        /// computed from the algorithmic UmAlQura calendar and can straddle a Gregorian year
        /// boundary; a fixed and an Islamic holiday landing on the same day stay distinct
        /// entries (names aggregated by the base class, matching the previous comma-merge).
        /// </summary>
        /// <param name="year">The year.</param>
        protected override IList<Holiday> PublicHolidaysComplete(int year)
        {
            var list = new List<Holiday>();
            foreach (var definition in Definitions)
            {
                list.AddRange(definition.Build(year));
            }
            return list;
        }

        private static readonly HolidayDefinition[] Definitions =
        {
            new Common.NewYear(),
            new Local.NationalSovereigntyAndChildrensDay(),
            new Common.LabourDay(),
            //the two feasts run several days, each named for its day number - the wording is one row per
            //feast in Names.tr.resx, with a "{0}" the day is substituted into
            new EidAlFitr(),
            new Local.YouthAndSportsDay(),
            new EidAlAdha(),
            new Local.DemocracyAndNationalUnityDay(),
            new Local.VictoryDay(),
            new Local.RepublicDay(),
        };
    }
}
