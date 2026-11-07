using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Czechoslovakia
{
    // Holidays of the former Czechoslovakia, shared by the Czech Republic and Slovakia
    // (each calendar applies its own year gating and local-language name).

    /// <summary>
    /// Day of liberation of Czechoslovakia by the Soviet Army - 9 May, communist era 1952-1991
    /// (in Moscow time the WWII capitulation fell on 9 May).
    /// </summary>
    public class SovietLiberationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SovietLiberationDay() : base(HolidayKeys.SovietLiberationDayCS, "Day of Liberation of Czechoslovakia by the Soviet Army", 5, 9)
        {
            AppliesInYear = CommunistEra;
        }

        private static bool CommunistEra(int year)
        {
            return year >= 1952 && year <= 1991;
        }
    }

    /// <summary>St Cyril and Methodius Day - 5 July.</summary>
    public class CyrilAndMethodiusDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CyrilAndMethodiusDay() : base(HolidayKeys.CyrilAndMethodiusDay, "St Cyril and Methodius Day", 7, 5) { }
    }

    /// <summary>Nationalization Day - 28 October, communist era 1952-1974.</summary>
    public class NationalizationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationalizationDay() : base(HolidayKeys.NationalizationDayCS, "Nationalization Day", 10, 28)
        {
            AppliesInYear = Between1952And1974;
        }

        private static bool Between1952And1974(int year)
        {
            return year >= 1952 && year <= 1974;
        }
    }

    /// <summary>Day of the Establishment of the Independent Czecho-Slovak State - 28 October (introduced 1988).</summary>
    public class IndependentCzechoslovakStateDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependentCzechoslovakStateDay() : base(HolidayKeys.IndependentCzechoslovakStateDayCS, "Day of the Establishment of the Independent Czecho-Slovak State", 10, 28) { }
    }

    /// <summary>Struggle for Freedom and Democracy Day - 17 November (Velvet Revolution).</summary>
    public class FreedomAndDemocracyDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public FreedomAndDemocracyDay() : base(HolidayKeys.FreedomAndDemocracyDayCS, "Struggle for Freedom and Democracy Day", 11, 17) { }
    }
}
