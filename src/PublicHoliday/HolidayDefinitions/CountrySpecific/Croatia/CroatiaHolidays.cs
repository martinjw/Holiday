using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Croatia
{
    /// <summary>National Day - 30 May.</summary>
    public class NationalDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalDay() : base(HolidayKeys.NationalDayHR, "National Day", 5, 30) { }
    }

    /// <summary>Anti-Fascist Struggle Day - 22 June.</summary>
    public class AntiFascistStruggleDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AntiFascistStruggleDay() : base(HolidayKeys.AntiFascistStruggleDayHR, "Anti-Fascist Struggle Day", 6, 22) { }
    }

    /// <summary>Victory and Homeland Thanksgiving Day - 5 August.</summary>
    public class VictoryDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public VictoryDay() : base(HolidayKeys.VictoryDayHR, "Victory and Homeland Thanksgiving Day", 8, 5) { }
    }

    /// <summary>Remembrance Day - 18 November.</summary>
    public class RemembranceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RemembranceDay() : base(HolidayKeys.RemembranceDayHR, "Remembrance Day", 11, 18) { }
    }
}
