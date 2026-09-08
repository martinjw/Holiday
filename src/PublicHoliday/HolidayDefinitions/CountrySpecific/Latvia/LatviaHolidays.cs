using System;
using System.Collections.Generic;
using PublicHoliday.Dates;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Latvia
{
    /// <summary>
    /// Latvia's rule for a holiday falling on a weekend: the next working day is a day off
    /// (brīvdiena). Introduced by the 2007 amendment to the holidays law, and only for the three
    /// holidays the law names - see <see cref="RestorationOfIndependenceDay"/>,
    /// <see cref="SongAndDanceFestivalClosingDay"/> and <see cref="ProclamationDay"/>. Christmas
    /// and New Year are deliberately not shifted.
    /// </summary>
    internal static class LatviaWeekendRule
    {
        public static DateTime NextWorkingDaySince2007(DateTime holiday)
        {
            return holiday.Year >= 2007 ? HolidayCalculator.FixWeekend(holiday) : holiday;
        }
    }

    /// <summary>Restoration of Independence Day - 4 May (1990 declaration).</summary>
    public class RestorationOfIndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RestorationOfIndependenceDay()
            : base(HolidayKeys.RestorationOfIndependenceDayLV, "Restoration of Independence Day", 5, 4)
        {
            ObservedDateRule = LatviaWeekendRule.NextWorkingDaySince2007;
        }
    }

    /// <summary>Mother's Day - second Sunday of May.</summary>
    public class MothersDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MothersDay() : base(HolidayKeys.MothersDayLV, "Mother's Day", 5, DayOfWeek.Sunday, 2) { }
    }

    /// <summary>Midsummer Eve (Līgo Day) - 23 June.</summary>
    public class LigoDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LigoDay() : base(HolidayKeys.LigoDayLV, "Midsummer Eve", 6, 23) { }
    }

    /// <summary>Midsummer Day (Jāņi) - 24 June.</summary>
    public class MidsummerDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MidsummerDay() : base(HolidayKeys.MidsummerDayLV, "Midsummer Day", 6, 24) { }
    }

    /// <summary>
    /// Closing day of the Latvian Song and Dance Festival, a holiday since the 2017 amendment.
    /// The festival is held roughly every five years on dates announced per festival, so the
    /// dates are a table rather than a formula; it has always closed on a Sunday, which the
    /// weekend rule then moves to the Monday.
    /// </summary>
    public class SongAndDanceFestivalClosingDay : LookupTableHoliday
    {
        private static readonly IDictionary<int, DateTime> Dates = new Dictionary<int, DateTime>
        {
            { 2018, new DateTime(2018, 7, 8) },
            { 2023, new DateTime(2023, 7, 9) },
        };

        /// <summary>Creates the definition.</summary>
        public SongAndDanceFestivalClosingDay()
            : base(HolidayKeys.SongAndDanceFestivalLV, "Song and Dance Festival Closing Day", Dates)
        {
            ObservedDateRule = LatviaWeekendRule.NextWorkingDaySince2007;
        }
    }

    /// <summary>Proclamation Day of the Republic of Latvia - 18 November (1918).</summary>
    public class ProclamationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ProclamationDay()
            : base(HolidayKeys.ProclamationDayLV, "Proclamation of the Republic of Latvia", 11, 18)
        {
            ObservedDateRule = LatviaWeekendRule.NextWorkingDaySince2007;
        }
    }

    /// <summary>
    /// Second Day of Christmas - 26 December. Latvia numbers its Christmas days rather than
    /// naming the day after St Stephen, so it has its own key.
    /// </summary>
    public class SecondChristmasDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SecondChristmasDay() : base(HolidayKeys.SecondChristmasDayLV, "Second Day of Christmas", 12, 26) { }
    }

    /// <summary>Pastoral visit of Pope Francis - 24 September 2018, a one-off holiday.</summary>
    public class PopeFrancisVisitDay : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public PopeFrancisVisitDay()
            : base(HolidayKeys.PopeFrancisVisitLV, "Pastoral Visit of Pope Francis", new DateTime(2018, 9, 24)) { }
    }

    /// <summary>
    /// Day of the bronze medal won by the Latvian ice hockey team at the 2023 World Championship -
    /// 29 May 2023, declared by the Saeima the evening before.
    /// </summary>
    public class BronzeMedalDay : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BronzeMedalDay()
            : base(HolidayKeys.BronzeMedalDayLV, "Day of the Bronze Medal Win", new DateTime(2023, 5, 29)) { }
    }
}
