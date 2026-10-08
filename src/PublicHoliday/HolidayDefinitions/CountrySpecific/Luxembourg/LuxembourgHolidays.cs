using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Luxembourg
{
    /// <summary>Europe Day - 9 May, public holiday since 2019.</summary>
    public class EuropeDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public EuropeDay() : base(HolidayKeys.EuropeDayLU, "Europe Day", 5, 9)
        {
            AppliesInYear = From2019;
        }

        private static bool From2019(int year)
        {
            return year >= 2019;
        }
    }

    /// <summary>National Day - 23 June.</summary>
    public class NationalDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalDay() : base(HolidayKeys.NationalDayLU, "National Day", 6, 23) { }
    }
}
