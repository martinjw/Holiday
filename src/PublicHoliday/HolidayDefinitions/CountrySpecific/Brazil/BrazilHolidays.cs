using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Christian;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Brazil
{
    /// <summary>Carnival Monday - 48 days before Easter.</summary>
    public class CarnivalMonday : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CarnivalMonday() : base(HolidayKeys.CarnivalBR1, "Carnival Monday", -48) { }
    }

    /// <summary>Carnival Tuesday (Mardi Gras) - 47 days before Easter.</summary>
    public class CarnivalTuesday : EasterRelativeHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CarnivalTuesday() : base(HolidayKeys.CarnivalBR2, "Carnival Tuesday", -47) { }
    }

    /// <summary>Tiradentes Day - 21 April.</summary>
    public class Tiradentes : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Tiradentes() : base(HolidayKeys.TiradentesBR, "Tiradentes Day", 4, 21) { }
    }

    /// <summary>Independence Day - 7 September.</summary>
    public class IndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceDay() : base(HolidayKeys.IndependenceDayBR, "Independence Day", 9, 7) { }
    }

    /// <summary>Our Lady of Aparecida - 12 October.</summary>
    public class OurLadyAparecida : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public OurLadyAparecida() : base(HolidayKeys.OurLadyAparecidaBR, "Our Lady of Aparecida", 10, 12) { }
    }

    /// <summary>All Souls' Day - 2 November.</summary>
    public class AllSoulsDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AllSoulsDay() : base(HolidayKeys.AllSouls, "All Souls' Day", 11, 2) { }
    }

    /// <summary>Republic Day - 15 November.</summary>
    public class RepublicDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public RepublicDay() : base(HolidayKeys.RepublicDayBR, "Republic Day", 11, 15) { }
    }
}
