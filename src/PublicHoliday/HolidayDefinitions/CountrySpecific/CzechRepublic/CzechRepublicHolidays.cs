using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.CzechRepublic
{
    /// <summary>
    /// Day of the Establishment of the Independent Czech State - 1 January (law 245/2000; the
    /// same date remains New Year's Day).
    /// </summary>
    public class CzechStateEstablishmentDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CzechStateEstablishmentDay() : base(HolidayKeys.CzechEstablishmentDay, "Day of the Establishment of the Independent Czech State", 1, 1) { }
    }

    /// <summary>Jan Hus Day (burning at the stake of Jan Hus) - 6 July (since 2001).</summary>
    public class JanHusDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public JanHusDay() : base(HolidayKeys.JanHusDayCZ, "Jan Hus Day", 7, 6) { }
    }

    /// <summary>Czech Statehood Day (St Wenceslas) - 28 September (law 245/2000).</summary>
    public class CzechStatehoodDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CzechStatehoodDay() : base(HolidayKeys.CzechStatehoodDay, "Czech Statehood Day", 9, 28) { }
    }
}
