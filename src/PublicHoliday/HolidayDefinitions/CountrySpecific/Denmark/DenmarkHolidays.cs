using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Denmark
{
    /// <summary>Constitution Day - 5 June.</summary>
    public class ConstitutionDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ConstitutionDay() : base(HolidayKeys.ConstitutionDayDK, "Constitution Day", 6, 5) { }
    }

    /// <summary>
    /// Store Bededag (General Prayer Day) - the 4th Friday after Easter (easter + 26 days).
    /// Abolished as a public holiday from 2024.
    /// </summary>
    public class GeneralPrayerDay : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public GeneralPrayerDay() : base(HolidayKeys.GeneralPrayerDayDK, "General Prayer Day", 26)
        {
            AppliesInYear = Until2023;
        }

        private static bool Until2023(int year)
        {
            return year < 2024;
        }
    }

    /// <summary>The day after Ascension (a bank holiday when opted in) - easter + 40 days.</summary>
    public class DayAfterAscension : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DayAfterAscension() : base(HolidayKeys.DayAfterAscensionDK, "Day after Ascension", 40) { }
    }
}
