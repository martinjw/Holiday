using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Hungary
{
    /// <summary>1848 Revolution Memorial Day - 15 March.</summary>
    public class NationalDay1848 : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalDay1848() : base(HolidayKeys.NationalDay1848HU, "1848 Revolution Memorial Day", 3, 15) { }
    }

    /// <summary>State Foundation Day - 20 August.</summary>
    public class StateFoundationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StateFoundationDay() : base(HolidayKeys.StateFoundationDayHU, "State Foundation Day", 8, 20) { }
    }

    /// <summary>1956 Revolution Memorial Day - 23 October.</summary>
    public class Revolution1956Day : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Revolution1956Day() : base(HolidayKeys.Revolution1956DayHU, "1956 Revolution Memorial Day", 10, 23) { }
    }
}
