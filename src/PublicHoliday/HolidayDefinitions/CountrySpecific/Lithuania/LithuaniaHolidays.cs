using System;
using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Lithuania
{
    /// <summary>Day of Restoration of the State of Lithuania - 16 February.</summary>
    public class RestorationOfStateDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RestorationOfStateDay() : base(HolidayKeys.RestorationOfStateLT, "Day of Restoration of the State of Lithuania", 2, 16) { }
    }

    /// <summary>Day of Restoration of Independence of Lithuania - 11 March.</summary>
    public class RestorationOfIndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RestorationOfIndependenceDay() : base(HolidayKeys.RestorationOfIndependenceLT, "Day of Restoration of Independence of Lithuania", 3, 11) { }
    }

    /// <summary>Mother's Day - first Sunday of May.</summary>
    public class MothersDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MothersDay() : base(HolidayKeys.MothersDayLT, "Mother's Day", 5, DayOfWeek.Sunday, 1) { }
    }

    /// <summary>Father's Day - first Sunday of June.</summary>
    public class FathersDay : NthWeekdayHoliday
    {
        /// <summary>Creates the definition.</summary>
        public FathersDay() : base(HolidayKeys.FathersDayLT, "Father's Day", 6, DayOfWeek.Sunday, 1) { }
    }

    /// <summary>St John's Day / Midsummer - 24 June.</summary>
    public class StJohnsDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StJohnsDay() : base(HolidayKeys.MidsummerDayLT, "St John's Day", 6, 24) { }
    }

    /// <summary>Statehood Day - 6 July.</summary>
    public class StatehoodDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StatehoodDay() : base(HolidayKeys.StatehoodDayLT, "Statehood Day", 7, 6) { }
    }

    /// <summary>All Souls' Day - 2 November.</summary>
    public class AllSoulsDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AllSoulsDay() : base(HolidayKeys.AllSouls, "All Souls' Day", 11, 2) { }
    }
}
