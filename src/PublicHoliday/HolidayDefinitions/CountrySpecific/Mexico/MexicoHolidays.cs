using System;
using System.Collections.Generic;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Mexico
{
    /// <summary>Constitution Day - first Monday of February.</summary>
    public class ConstitutionDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ConstitutionDay() : base(HolidayKeys.ConstitutionDayMX, "Constitution Day", 2, DayOfWeek.Monday, 1) { }
    }

    /// <summary>Benito Juárez's Birthday - third Monday of March.</summary>
    public class BenitoJuarezBirthday : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public BenitoJuarezBirthday() : base(HolidayKeys.BenitoJuarezBirthdayMX, "Benito Juárez's Birthday", 3, DayOfWeek.Monday, 3) { }
    }

    /// <summary>Independence Day - 16 September.</summary>
    public class IndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceDay() : base(HolidayKeys.IndependenceDayMX, "Independence Day", 9, 16) { }
    }

    /// <summary>
    /// Presidential Inauguration Holiday - 1 October in inauguration years (every 6 years
    /// starting 2024).
    /// </summary>
    public class PresidentialInauguration : FixedDateHoliday
    {
        private const int StartYear = 2024;

        /// <summary>Creates the definition.</summary>
        public PresidentialInauguration() : base(HolidayKeys.PresidentialInaugurationMX, "Presidential Inauguration Holiday", 10, 1)
        {
            AppliesInYear = IsInaugurationYear;
        }

        private static bool IsInaugurationYear(int year)
        {
            return year >= StartYear && (year - StartYear) % 6 == 0;
        }
    }

    /// <summary>Mexican Revolution Day - third Monday of November.</summary>
    public class RevolutionDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RevolutionDay() : base(HolidayKeys.RevolutionDayMX, "Revolution Day", 11, DayOfWeek.Monday, 3) { }
    }
}
