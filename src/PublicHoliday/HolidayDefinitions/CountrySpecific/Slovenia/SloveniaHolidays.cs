using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Slovenia
{
    /// <summary>Prešeren Day (Slovenian Cultural Holiday) - 8 February.</summary>
    public class PreserenDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public PreserenDay() : base(HolidayKeys.PreserenDaySI, "Prešeren Day", 2, 8) { }
    }

    /// <summary>Day of Uprising Against Occupation - 27 April.</summary>
    public class ResistanceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ResistanceDay() : base(HolidayKeys.ResistanceDaySI, "Day of Uprising Against Occupation", 4, 27) { }
    }

    /// <summary>Statehood Day - 25 June.</summary>
    public class StatehoodDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StatehoodDay() : base(HolidayKeys.NationalDaySI, "Statehood Day", 6, 25) { }
    }

    /// <summary>Day of Sovereignty and Unity - 26 December.</summary>
    public class UnityDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public UnityDay() : base(HolidayKeys.UnityDaySI, "Day of Sovereignty and Unity", 12, 26) { }
    }
}
