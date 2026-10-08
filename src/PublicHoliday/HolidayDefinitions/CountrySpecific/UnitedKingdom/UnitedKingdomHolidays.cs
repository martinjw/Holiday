using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.UnitedKingdom
{
    /// <summary>
    /// New Year Holiday (Scotland) - 2 January; cascades behind the observed New Year's Day
    /// over a weekend.
    /// </summary>
    public class NewYearHolidayScotland : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NewYearHolidayScotland() : base(HolidayKeys.NewYearHolidayScotland, "New Year Holiday", 1, 2)
        {
            ObservedDateRule = Observed;
        }

        private static DateTime Observed(DateTime date)
        {
            bool isSundayOrMonday = date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Monday;
            var observed = HolidayCalculator.FixWeekend(date);
            return isSundayOrMonday ? observed.AddDays(1) : observed;
        }
    }

    /// <summary>
    /// Early May Bank Holiday - first Monday of May, created in 1978; moved to 8 May in 1995
    /// and 2020 for VE Day anniversaries.
    /// </summary>
    public class EarlyMayBankHoliday : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public EarlyMayBankHoliday() : base(HolidayKeys.EarlyMayUK, "Early May")
        {
            AppliesInYear = From1978;
        }

        private static bool From1978(int year)
        {
            return year >= 1978;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            if (year == 1995) { yield return new DateTime(1995, 5, 8); yield break; }
            if (year == 2020) { yield return new DateTime(2020, 5, 8); yield break; }
            yield return HolidayCalculator.FindFirstMonday(new DateTime(year, 5, 1));
        }
    }

    /// <summary>
    /// Spring Bank Holiday - last Monday of May (replaced Whit Monday in 1971); moved for the
    /// Golden (2002), Diamond (2012) and Platinum (2022) Jubilees.
    /// </summary>
    public class SpringBankHoliday : HolidayDefinition
    {
        /// <summary>Creates the definition.</summary>
        public SpringBankHoliday() : base(HolidayKeys.SpringUK, "Spring") { }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            if (year == 2002) { yield return new DateTime(2002, 6, 4); yield break; }
            if (year == 2012) { yield return new DateTime(2012, 6, 4); yield break; }
            if (year == 2022) { yield return new DateTime(2022, 6, 2); yield break; }
            yield return HolidayCalculator.FindPrevious(new DateTime(year, 5, 31), DayOfWeek.Monday);
        }
    }

    /// <summary>Battle of the Boyne / Orangemen's Day (Northern Ireland) - 12 July (weekend shifts to Monday).</summary>
    public class BattleOfTheBoyne : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BattleOfTheBoyne() : base(HolidayKeys.BattleOfTheBoyneUK, "Battle of the Boyne", 7, 12)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>Summer Bank Holiday (Scotland) - first Monday of August.</summary>
    public class SummerBankHolidayScotland : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SummerBankHolidayScotland() : base(HolidayKeys.SummerUK, "Summer Holiday", 8, DayOfWeek.Monday, 1) { }
    }

    /// <summary>Summer Bank Holiday (England, Wales, Northern Ireland) - last Monday of August.</summary>
    public class SummerBankHoliday : WeekdayOnOrAfterHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SummerBankHoliday() : base(HolidayKeys.SummerUK, "Summer", 8, 25, DayOfWeek.Monday) { }
    }

    /// <summary>St Andrew's Day (Scotland) - 30 November (weekend shifts to Monday).</summary>
    public class StAndrewsDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StAndrewsDay() : base(HolidayKeys.StAndrewsDayUK, "St Andrew's Day", 11, 30)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>
    /// Boxing Day - 26 December; a Saturday or Sunday date is observed two days later
    /// (Monday/Tuesday, behind the observed Christmas Day).
    /// </summary>
    public class BoxingDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BoxingDay() : base(HolidayKeys.BoxingDay, "Boxing Day", 12, 26)
        {
            ObservedDateRule = UnitedKingdomWeekendRule.SaturdayOrSundayPlusTwo;
        }
    }

    /// <summary>
    /// The UK Christmas/Boxing Day weekend rule: a Saturday or Sunday date is observed two days
    /// later, so the observed pair never collides (Christmas on Sunday → Tuesday, behind Boxing
    /// Day's Monday).
    /// </summary>
    internal static class UnitedKingdomWeekendRule
    {
        internal static DateTime SaturdayOrSundayPlusTwo(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday
                ? date.AddDays(2)
                : date;
        }
    }

    /// <summary>Golden Jubilee of Elizabeth II - one-off, 3 June 2002.</summary>
    public class GoldenJubilee : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public GoldenJubilee() : base(HolidayKeys.GoldenJubileeUK, "Golden Jubilee", new DateTime(2002, 6, 3)) { }
    }

    /// <summary>Royal Wedding of Prince William - one-off, 29 April 2011.</summary>
    public class RoyalWedding2011 : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RoyalWedding2011() : base(HolidayKeys.RoyalWeddingUK2011, "Royal Wedding", new DateTime(2011, 4, 29)) { }
    }

    /// <summary>Queen's Diamond Jubilee - one-off, 5 June 2012.</summary>
    public class DiamondJubilee : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DiamondJubilee() : base(HolidayKeys.DiamondJubileeUK, "Queen's Diamond Jubilee", new DateTime(2012, 6, 5)) { }
    }

    /// <summary>Queen's Platinum Jubilee - one-off, 3 June 2022.</summary>
    public class PlatinumJubilee : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public PlatinumJubilee() : base(HolidayKeys.PlatinumJubileeUK, "Queen's Platinum Jubilee", new DateTime(2022, 6, 3)) { }
    }

    /// <summary>State Funeral of Queen Elizabeth II - one-off, 19 September 2022.</summary>
    public class QueenElizabethFuneral : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public QueenElizabethFuneral() : base(HolidayKeys.QueenElizabethFuneral, "State Funeral of Queen Elizabeth II", new DateTime(2022, 9, 19)) { }
    }

    /// <summary>Coronation of King Charles III - one-off, 8 May 2023.</summary>
    public class CoronationCharlesIII : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CoronationCharlesIII() : base(HolidayKeys.CoronationUK2023, "Coronation of King Charles III", new DateTime(2023, 5, 8)) { }
    }

    /// <summary>Scotland's 2026 World Cup holiday - one-off, 15 June 2026.</summary>
    public class WorldCup2026Scotland : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public WorldCup2026Scotland() : base(HolidayKeys.WorldCupUK2026, "World Cup", new DateTime(2026, 6, 15)) { }
    }
}
