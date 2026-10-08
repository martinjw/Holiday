using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Montenegro
{
    /// <summary>Independence Day - 21 May.</summary>
    public class IndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceDay() : base(HolidayKeys.IndependenceDayME, "Independence Day", 5, 21) { }
    }

    /// <summary>Independence Day holiday (second day) - 22 May.</summary>
    public class IndependenceDaySecond : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceDaySecond() : base(HolidayKeys.IndependenceDaySecondME, "Independence Day Holiday", 5, 22) { }
    }

    /// <summary>Statehood Day - 13 July.</summary>
    public class StatehoodDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StatehoodDay() : base(HolidayKeys.StatehoodDayME, "Statehood Day", 7, 13) { }
    }

    /// <summary>Statehood Day holiday (second day) - 14 July.</summary>
    public class StatehoodDaySecond : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StatehoodDaySecond() : base(HolidayKeys.StatehoodDaySecondME, "Statehood Day Holiday", 7, 14) { }
    }

    /// <summary>Njegoš Day - 13 November.</summary>
    public class NegoshevDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NegoshevDay() : base(HolidayKeys.NegoshevDayME, "Njegoš Day", 11, 13) { }
    }
}
