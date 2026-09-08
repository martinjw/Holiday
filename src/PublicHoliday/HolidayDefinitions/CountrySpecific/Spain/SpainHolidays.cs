using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Spain
{
    /// <summary>National Day of Spain - 12 October.</summary>
    public class NationalDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalDay() : base(HolidayKeys.NationalDayES, "National Day", 10, 12) { }
    }

    /// <summary>Constitution Day - 6 December.</summary>
    public class ConstitutionDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ConstitutionDay() : base(HolidayKeys.ConstitutionDayES, "Constitution Day", 12, 6) { }
    }
}
