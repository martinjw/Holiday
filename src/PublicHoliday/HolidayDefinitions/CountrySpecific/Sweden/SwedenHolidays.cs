using System;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Sweden
{
    /// <summary>National Day - 6 June.</summary>
    public class NationalDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalDay() : base(HolidayKeys.NationalDaySE, "National Day", 6, 6) { }
    }

    /// <summary>Midsummer Eve - the Friday on or after 19 June.</summary>
    public class MidsummerEve : WeekdayOnOrAfterHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MidsummerEve() : base(HolidayKeys.MidsummerEveSE, "Midsummer Eve", 6, 19, DayOfWeek.Friday) { }
    }

    /// <summary>Midsummer Day - the Saturday on or after 20 June.</summary>
    public class MidsummerDay : WeekdayOnOrAfterHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MidsummerDay() : base(HolidayKeys.MidsummerDaySE, "Midsummer Day", 6, 20, DayOfWeek.Saturday) { }
    }

    /// <summary>All Saints' Day, Swedish rule - the Saturday on or after 31 October.</summary>
    public class AllSaintsDay : WeekdayOnOrAfterHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AllSaintsDay() : base(HolidayKeys.AllSaints, "All Saints' Day", 10, 31, DayOfWeek.Saturday) { }
    }
}
