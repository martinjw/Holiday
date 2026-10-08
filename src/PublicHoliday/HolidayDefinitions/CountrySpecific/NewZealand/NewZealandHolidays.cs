using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.NewZealand
{
    /// <summary>
    /// Day after New Year's Day - 2 January; cascades behind the observed New Year's Day
    /// (both can shift over a weekend, occupying Monday and Tuesday).
    /// </summary>
    public class DayAfterNewYear : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DayAfterNewYear() : base(HolidayKeys.DayAfterNewYear, "Day After New Year", 1, 2)
        {
            ObservedDateRule = Observed;
        }

        private static DateTime Observed(DateTime date)
        {
            var newYear = HolidayCalculator.FixWeekend(new DateTime(date.Year, 1, 1));
            return HolidayCalculator.FixWeekend(newYear.AddDays(1));
        }
    }

    /// <summary>Waitangi Day - 6 February (weekend shifts to Monday).</summary>
    public class WaitangiDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public WaitangiDay() : base(HolidayKeys.WaitangiDayNZ, "Waitangi Day", 2, 6)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>ANZAC Day - 25 April; Mondayised (weekend shifts) only since 2015.</summary>
    public class AnzacDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AnzacDay() : base(HolidayKeys.AnzacDay, "ANZAC Day", 4, 25)
        {
            ObservedDateRule = Observed;
        }

        private static DateTime Observed(DateTime date)
        {
            return date.Year >= 2015 ? HolidayCalculator.FixWeekend(date) : date;
        }
    }

    /// <summary>
    /// The Monarch's Birthday - first Monday of June. Queen's Birthday until 2022, King's
    /// Birthday from 2023 (the key and name follow the year).
    /// </summary>
    public class MonarchsBirthday : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MonarchsBirthday() : base(HolidayKeys.KingsBirthdayNZ, "King's Birthday", 6, DayOfWeek.Monday, 1) { }

        /// <inheritdoc />
        protected override string LocalNameFor(int year, int index, int count)
        {
            return year < 2023 ? "Queen's Birthday" : "King's Birthday";
        }

        /// <inheritdoc />
        protected override string HolidayKeyFor(int year, int index, int count)
        {
            return year < 2023 ? HolidayKeys.QueensBirthdayNZ : HolidayKeys.KingsBirthdayNZ;
        }
    }

    /// <summary>Labour Day - fourth Monday of October.</summary>
    public class LabourDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LabourDay() : base(HolidayKeys.LabourDay, "Labour Day", 10, DayOfWeek.Monday, 4) { }
    }

    /// <summary>Christmas Day - 25 December (weekend shifts to Monday).</summary>
    public class ChristmasDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ChristmasDay() : base(HolidayKeys.Christmas, "Christmas Day", 12, 25)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>
    /// Boxing Day - 26 December; cascades behind the observed Christmas Day (both can shift
    /// over a weekend, occupying Monday and Tuesday).
    /// </summary>
    public class BoxingDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BoxingDay() : base(HolidayKeys.BoxingDay, "Boxing Day", 12, 26)
        {
            ObservedDateRule = Observed;
        }

        private static DateTime Observed(DateTime date)
        {
            var christmas = HolidayCalculator.FixWeekend(new DateTime(date.Year, 12, 25));
            return HolidayCalculator.FixWeekend(christmas.AddDays(1));
        }
    }

    /// <summary>
    /// Matariki - officially announced dates 2022-2052 (2035 not yet announced).
    /// https://www.beehive.govt.nz/release/matariki-holiday-dates-next-thirty-years-announced
    /// </summary>
    public class Matariki : LookupTableHoliday
    {
        internal static readonly IDictionary<int, DateTime> Dates = new Dictionary<int, DateTime>
        {
            {2022, new DateTime(2022, 6, 24)},
            {2023, new DateTime(2023, 7, 14)},
            {2024, new DateTime(2024, 6, 28)},
            {2025, new DateTime(2025, 6, 20)},
            {2026, new DateTime(2026, 7, 10)},
            {2027, new DateTime(2027, 6, 25)},
            {2028, new DateTime(2028, 7, 14)},
            {2029, new DateTime(2029, 7, 6)},
            {2030, new DateTime(2030, 6, 21)},
            {2031, new DateTime(2031, 7, 11)},
            {2032, new DateTime(2032, 7, 2)},
            {2033, new DateTime(2033, 6, 24)},
            {2034, new DateTime(2034, 7, 7)},
            {2036, new DateTime(2036, 7, 18)},
            {2037, new DateTime(2037, 7, 10)},
            {2038, new DateTime(2038, 6, 25)},
            {2039, new DateTime(2039, 7, 15)},
            {2040, new DateTime(2040, 7, 6)},
            {2041, new DateTime(2041, 7, 19)},
            {2042, new DateTime(2042, 7, 11)},
            {2043, new DateTime(2043, 7, 3)},
            {2044, new DateTime(2044, 6, 24)},
            {2045, new DateTime(2045, 7, 7)},
            {2046, new DateTime(2046, 6, 29)},
            {2047, new DateTime(2047, 7, 19)},
            {2048, new DateTime(2048, 7, 3)},
            {2049, new DateTime(2049, 6, 25)},
            {2050, new DateTime(2050, 7, 15)},
            {2051, new DateTime(2051, 6, 30)},
            {2052, new DateTime(2052, 6, 21)},
        };

        /// <summary>Creates the definition.</summary>
        public Matariki() : base(HolidayKeys.MatarikiNZ, "Matariki", Dates) { }
    }

    /// <summary>Queen Elizabeth II Memorial Day - one-off, 26 September 2022.</summary>
    public class QueenElizabethMemorialDay : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public QueenElizabethMemorialDay() : base(HolidayKeys.QueenElizabethMemorialDayNZ2022, "Queen Elizabeth II Memorial Day", new DateTime(2022, 9, 26)) { }
    }
}
