using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Serbia
{
    /// <summary>Statehood Day - 15 February.</summary>
    public class StatehoodDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StatehoodDay() : base(HolidayKeys.NationalDayRS1, "Statehood Day", 2, 15) { }
    }

    /// <summary>Statehood Day holiday (second day) - 16 February.</summary>
    public class StatehoodDaySecond : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StatehoodDaySecond() : base(HolidayKeys.NationalDayRS2, "Statehood Day Holiday", 2, 16) { }
    }
}
