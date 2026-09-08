using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Norway
{
    /// <summary>Constitution Day - 17 May.</summary>
    public class ConstitutionDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ConstitutionDay() : base(HolidayKeys.ConstitutionDayNO, "Constitution Day", 5, 17) { }
    }
}
