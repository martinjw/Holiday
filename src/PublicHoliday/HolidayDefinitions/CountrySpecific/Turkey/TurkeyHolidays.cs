using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Turkey
{
    /// <summary>National Sovereignty and Children's Day - 23 April.</summary>
    public class NationalSovereigntyAndChildrensDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalSovereigntyAndChildrensDay() : base(HolidayKeys.NationalSovereigntyChildrensDayTR, "National Sovereignty and Children's Day", 4, 23) { }
    }

    /// <summary>Commemoration of Atatürk, Youth and Sports Day - 19 May.</summary>
    public class YouthAndSportsDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public YouthAndSportsDay() : base(HolidayKeys.YouthAndSportsDayTR, "Youth and Sports Day", 5, 19) { }
    }

    /// <summary>Democracy and National Unity Day - 15 July, since 2017 (commemorates the failed 2016 coup attempt).</summary>
    public class DemocracyAndNationalUnityDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DemocracyAndNationalUnityDay() : base(HolidayKeys.DemocracyNationalUnityDayTR, "Democracy and National Unity Day", 7, 15)
        {
            AppliesInYear = Since2017;
        }

        private static bool Since2017(int year)
        {
            return year >= 2017;
        }
    }

    /// <summary>Victory Day - 30 August.</summary>
    public class VictoryDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public VictoryDay() : base(HolidayKeys.VictoryDayTR, "Victory Day", 8, 30) { }
    }

    /// <summary>Republic Day - 29 October.</summary>
    public class RepublicDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RepublicDay() : base(HolidayKeys.RepublicDayTR, "Republic Day", 10, 29) { }
    }
}
