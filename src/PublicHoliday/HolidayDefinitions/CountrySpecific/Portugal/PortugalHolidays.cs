using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Portugal
{
    /// <summary>Carnival (Shrove Tuesday) - 47 days before Easter.</summary>
    public class Carnival : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Carnival() : base(HolidayKeys.CarnivalPT, "Carnival", -47) { }
    }

    /// <summary>Freedom Day - 25 April.</summary>
    public class FreedomDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public FreedomDay() : base(HolidayKeys.FreedomDayPT, "Freedom Day", 4, 25) { }
    }

    /// <summary>Azores Day - Whit Monday (Azores only).</summary>
    public class AzoresDay : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AzoresDay() : base(HolidayKeys.AzoresDayPT, "Azores Day", 50)
        {
            Regions = new[] { "Açores" };
        }
    }

    /// <summary>Portugal Day (Dia de Portugal, de Camões e das Comunidades Portuguesas) - 10 June.</summary>
    public class PortugalDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public PortugalDay() : base(HolidayKeys.PortugalDayPT, "Portugal Day", 6, 10) { }
    }

    /// <summary>Madeira Autonomy Day - 1 July (Madeira only).</summary>
    public class MadeiraAutonomyDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public MadeiraAutonomyDay() : base(HolidayKeys.MadeiraAutonomyDayPT, "Madeira Autonomy Day", 7, 1)
        {
            Regions = new[] { "Madeira" };
        }
    }

    /// <summary>Republic Day - 5 October.</summary>
    public class RepublicDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RepublicDay() : base(HolidayKeys.RepublicDayPT, "Republic Day", 10, 5) { }
    }

    /// <summary>Independence Restoration Day - 1 December.</summary>
    public class IndependenceRestorationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceRestorationDay() : base(HolidayKeys.IndependenceRestorationDayPT, "Independence Restoration Day", 12, 1) { }
    }

    /// <summary>First Octave Day - 26 December (Madeira only, since 2002).</summary>
    public class FirstOctaveDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public FirstOctaveDay() : base(HolidayKeys.FirstOctavePT, "First Octave", 12, 26)
        {
            Regions = new[] { "Madeira" };
            AppliesInYear = From2002;
        }

        private static bool From2002(int year)
        {
            return year >= 2002;
        }
    }
}
