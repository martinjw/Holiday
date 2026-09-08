using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Romania
{
    /// <summary>Saint John the Baptist - 7 January, public holiday since 2024.</summary>
    public class SaintJohnBaptistDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SaintJohnBaptistDay() : base(HolidayKeys.SaintJohnBaptistRO, "Saint John the Baptist", 1, 7)
        {
            AppliesInYear = From2024;
        }

        private static bool From2024(int year)
        {
            return year >= 2024;
        }
    }

    /// <summary>Day of the Unification of the Romanian Principalities - 24 January.</summary>
    public class UnificationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public UnificationDay() : base(HolidayKeys.UnificationDayRO, "Day of the Unification of the Romanian Principalities", 1, 24) { }
    }

    /// <summary>Children's Day - 1 June, public holiday since 2017.</summary>
    public class ChildrensDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ChildrensDay() : base(HolidayKeys.ChildrensDayRO, "Children's Day", 6, 1)
        {
            AppliesInYear = From2017;
        }

        private static bool From2017(int year)
        {
            return year >= 2017;
        }
    }

    /// <summary>St Andrew's Day - 30 November.</summary>
    public class SaintAndrewDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SaintAndrewDay() : base(HolidayKeys.SaintAndrewDayRO, "St Andrew's Day", 11, 30) { }
    }

    /// <summary>National Day - 1 December.</summary>
    public class NationalDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalDay() : base(HolidayKeys.NationalDayRO, "National Day", 12, 1) { }
    }
}
