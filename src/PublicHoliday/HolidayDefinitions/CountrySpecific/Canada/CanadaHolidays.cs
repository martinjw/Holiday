using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;
using PublicHoliday.Dates;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Canada
{
    /// <summary>
    /// Family Day: third Monday of February (second Monday in BC before 2019).
    /// </summary>
    public class FamilyDay : HolidayDefinition
    {
        private readonly string _province;

        /// <summary>Creates the definition for the given province.</summary>
        public FamilyDay(string province) : base(HolidayKeys.FamilyDayCA, "Family Day")
        {
            _province = province;
        }

        /// <inheritdoc />
        protected override IEnumerable<DateTime> GetDates(int year)
        {
            var occurrence = _province == "BC" && year < 2019 ? 2 : 3;
            yield return HolidayCalculator.GetDayOfWeekInMonth(year, 2, DayOfWeek.Monday, occurrence);
        }
    }

    /// <summary>St Patrick's Day (NL) - the Monday nearest to 17 March.</summary>
    public class StPatricksDay : NearestWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StPatricksDay() : base(HolidayKeys.StPatricksDay, "St. Patrick's Day", 3, 17, DayOfWeek.Monday) { }
    }

    /// <summary>Saint George's Day (NL) - 23 April (weekend shifts to Monday).</summary>
    public class StGeorgesDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StGeorgesDay() : base(HolidayKeys.StGeorgesDayCA, "Saint George's Day", 4, 23)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>Victoria Day - the Monday on or before 24 May.</summary>
    public class VictoriaDay : WeekdayOnOrBeforeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public VictoriaDay() : base(HolidayKeys.VictoriaDayCA, "Victoria Day", 5, 24, DayOfWeek.Monday) { }
    }

    /// <summary>National Aboriginal Day (NT) - 21 June (weekend shifts to Monday).</summary>
    public class AboriginalDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AboriginalDay() : base(HolidayKeys.AboriginalDayCA, "Aboriginal Day", 6, 21)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>National Holiday / St-Jean-Baptiste (NL, QC, YT) - 24 June (weekend shifts to Monday).</summary>
    public class NationalHoliday : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalHoliday() : base(HolidayKeys.NationalHolidayCA, "National Holiday", 6, 24)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>Canada Day - 1 July (weekend shifts to Monday).</summary>
    public class CanadaDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CanadaDay() : base(HolidayKeys.CanadaDay, "Canada Day", 7, 1)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
    }

    /// <summary>Orangemen's Day (NL) - the Monday nearest to 12 July.</summary>
    public class OrangemensDay : NearestWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public OrangemensDay() : base(HolidayKeys.OrangemensDayCA, "Orangemen's Day", 7, 12, DayOfWeek.Monday) { }
    }

    /// <summary>Civic Holiday - first Monday of August (various provincial names).</summary>
    public class CivicHoliday : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CivicHoliday() : base(HolidayKeys.CivicHolidayCA, "Civic Holiday", 8, DayOfWeek.Monday, 1) { }
    }

    /// <summary>Gold Cup Parade Day (PE) - third Friday of August.</summary>
    public class GoldCupParadeDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public GoldCupParadeDay() : base(HolidayKeys.GoldCupParadeDayCA, "Gold Cup Parade Day", 8, DayOfWeek.Friday, 3) { }
    }

    /// <summary>Discovery Day (YT) - third Monday of August.</summary>
    public class DiscoveryDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DiscoveryDay() : base(HolidayKeys.DiscoveryDayCA, "Discovery Day", 8, DayOfWeek.Monday, 3) { }
    }

    /// <summary>Labour Day - first Monday of September.</summary>
    public class LabourDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LabourDay() : base(HolidayKeys.LabourDay, "Labour Day", 9, DayOfWeek.Monday, 1) { }
    }

    /// <summary>National Day for Truth and Reconciliation - 30 September since 2021 (weekend shifts to Monday).</summary>
    public class TruthAndReconciliationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public TruthAndReconciliationDay() : base(HolidayKeys.TruthReconciliationDayCA, "National Day For Truth And Reconciliation", 9, 30)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
            AppliesInYear = From2021;
        }

        private static bool From2021(int year)
        {
            return year >= 2021;
        }
    }

    /// <summary>Thanksgiving - second Monday of October.</summary>
    public class Thanksgiving : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Thanksgiving() : base(HolidayKeys.Thanksgiving, "Thanksgiving Day", 10, DayOfWeek.Monday, 2) { }
    }

    /// <summary>Remembrance Day - 11 November (weekend shifts to Monday).</summary>
    public class RemembranceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RemembranceDay() : base(HolidayKeys.RemembranceDayCA, "Remembrance Day", 11, 11)
        {
            ObservedDateRule = HolidayCalculator.FixWeekend;
        }
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

    /// <summary>Boxing Day - 26 December (not shifted; observed Christmas may land on the same day).</summary>
    public class BoxingDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BoxingDay() : base(HolidayKeys.BoxingDay, "Boxing Day", 12, 26) { }
    }

    /// <summary>State Funeral of Queen Elizabeth II - one-off, 19 September 2022.</summary>
    public class QueenElizabethFuneral : OneOffHoliday
    {
        /// <summary>Creates the definition.</summary>
        public QueenElizabethFuneral() : base(HolidayKeys.QueenElizabethFuneral, "State Funeral of Queen Elizabeth II", new DateTime(2022, 9, 19)) { }
    }
}
