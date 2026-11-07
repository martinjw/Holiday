using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Poland
{
    /// <summary>Constitution Day - 3 May.</summary>
    public class ConstitutionDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ConstitutionDay() : base(HolidayKeys.ConstitutionDayPL, "Constitution Day", 5, 3) { }
    }

    /// <summary>Independence Day - 11 November.</summary>
    public class IndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceDay() : base(HolidayKeys.IndependenceDayPL, "Independence Day", 11, 11) { }
    }
}
