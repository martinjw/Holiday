using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Italy
{
    /// <summary>Liberation Day - 25 April.</summary>
    public class LiberationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public LiberationDay() : base(HolidayKeys.LiberationDayIT, "Liberation Day", 4, 25) { }
    }

    /// <summary>Republic Day - 2 June.</summary>
    public class RepublicDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RepublicDay() : base(HolidayKeys.RepublicDayIT, "Republic Day", 6, 2) { }
    }
}
