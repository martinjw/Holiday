using System;
using System.Collections.Generic;
using System.Globalization;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.Islamic
{
    /// <summary>
    /// A holiday on a fixed day of the Islamic (Hijri) calendar, computed from the algorithmic
    /// <see cref="UmAlQuraCalendar"/>. Deliberately predicts future dates; historically observed
    /// dates may differ by a day. Emits <see cref="DayCount"/> consecutive days, and correctly
    /// handles the Hijri year straddling a Gregorian year boundary.
    /// Language-agnostic: the days are numbered (see
    /// <see cref="HolidayDefinition.DayNumberFor"/>) and the wording comes from the resource files, where
    /// one row per holiday carries a "{0}" for the day - <c>"Ramazan Bayramı {0}. Gün"</c>.
    /// </summary>
    public abstract class IslamicHolidayDefinition : HolidayDefinition
    {
        /// <summary>
        /// Creates an Islamic-calendar holiday definition.
        /// </summary>
        /// <param name="holidayKey">Stable identity / localization key.</param>
        /// <param name="englishName">Default English display name.</param>
        /// <param name="hijriMonth">Month in the Hijri calendar (1-12).</param>
        /// <param name="hijriDay">Day of the Hijri month.</param>
        /// <param name="dayCount">Number of consecutive holiday days.</param>
        protected IslamicHolidayDefinition(string holidayKey, string englishName, int hijriMonth, int hijriDay, int dayCount)
            : base(holidayKey, englishName)
        {
            HijriMonth = hijriMonth;
            HijriDay = hijriDay;
            DayCount = dayCount;
        }

        /// <summary>
        /// Month in the Hijri calendar (1-12).
        /// </summary>
        public int HijriMonth { get; }

        /// <summary>
        /// Day of the Hijri month.
        /// </summary>
        public int HijriDay { get; }

        /// <summary>
        /// Number of consecutive holiday days.
        /// </summary>
        public int DayCount { get; set; }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var hijriCalendar = new UmAlQuraCalendar();
            foreach (var hijriYear in HijriYearsOverlapping(year))
            {
                var start = hijriCalendar.ToDateTime(hijriYear, HijriMonth, HijriDay, 0, 0, 0, 0);
                if (start.Year != year)
                    continue;
                for (int i = 0; i < DayCount; i++)
                {
                    yield return start.AddDays(i);
                }
            }
        }

        /// <inheritdoc />
        protected override int DayNumberFor(int year, int index, int count)
        {
            //a multi-day block numbers its own days, not the year's occurrences of the holiday
            return (index % DayCount) + 1;
        }

        /// <summary>
        /// The Hijri years that can overlap the given Gregorian year.
        /// </summary>
        public static IEnumerable<int> HijriYearsOverlapping(int gregorianYear)
        {
            var diff = gregorianYear - 621;
            var hijriYear = Convert.ToInt32(Math.Round(diff + decimal.Divide(diff, 33)
#if NET6_0_OR_GREATER
                , MidpointRounding.ToZero
#endif
                ));
            return new List<int> { hijriYear, hijriYear + 1 }.AsReadOnly();
        }
    }

    /// <summary>Eid al-Fitr (end of Ramadan) - Shawwal 1, typically a 3-day holiday.</summary>
    public class EidAlFitr : IslamicHolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        /// <param name="dayCount">Number of consecutive holiday days (default 3).</param>
        public EidAlFitr(int dayCount = 3) : base(HolidayKeys.EidAlFitr, "Eid al-Fitr", 10, 1, dayCount) { }
    }

    /// <summary>Eid al-Adha (Feast of Sacrifice) - Dhu al-Hijjah 10, typically a 4-day holiday.</summary>
    public class EidAlAdha : IslamicHolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        /// <param name="dayCount">Number of consecutive holiday days (default 4).</param>
        public EidAlAdha(int dayCount = 4) : base(HolidayKeys.EidAlAdha, "Eid al-Adha", 12, 10, dayCount) { }
    }
}
