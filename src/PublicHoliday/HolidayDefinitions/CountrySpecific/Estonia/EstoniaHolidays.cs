using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Estonia
{
    /// <summary>Independence Day - 24 February.</summary>
    public class IndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceDay() : base(HolidayKeys.IndependenceDayEE, "Independence Day", 2, 24) { }
    }

    /// <summary>Victory Day - 23 June.</summary>
    public class VictoryDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public VictoryDay() : base(HolidayKeys.VictoryDayEE, "Victory Day", 6, 23) { }
    }

    /// <summary>Midsummer Day - 24 June.</summary>
    public class MidsummerDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MidsummerDay() : base(HolidayKeys.MidsummerDayEE, "Midsummer Day", 6, 24) { }
    }

    /// <summary>Day of Restoration of Independence - 20 August.</summary>
    public class RestorationOfIndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RestorationOfIndependenceDay() : base(HolidayKeys.RestorationOfIndependenceDayEE, "Day of Restoration of Independence", 8, 20) { }
    }
}
