using PublicHoliday.HolidayDefinitions;
using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Kazakhstan
{
    /// <summary>Nauryz, first day - 21 March.</summary>
    public class NauryzFirstDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NauryzFirstDay() : base(HolidayKeys.NauryzKZ1, "Nauryz", 3, 21) { }
    }

    /// <summary>Nauryz, second day - 22 March.</summary>
    public class NauryzSecondDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NauryzSecondDay() : base(HolidayKeys.NauryzKZ2, "Nauryz Holiday", 3, 22) { }
    }

    /// <summary>Nauryz, third day - 23 March.</summary>
    public class NauryzThirdDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NauryzThirdDay() : base(HolidayKeys.NauryzKZ3, "Nauryz Holiday", 3, 23) { }
    }

    /// <summary>Kazakhstan People's Unity Day - 1 May.</summary>
    public class NationUnityDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public NationUnityDay() : base(HolidayKeys.NationUnityDayKZ, "Kazakhstan People's Unity Day", 5, 1) { }
    }

    /// <summary>Defender of the Fatherland Day - 7 May.</summary>
    public class DefenderDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public DefenderDay() : base(HolidayKeys.DefenderDayKZ, "Defender of the Fatherland Day", 5, 7) { }
    }

    /// <summary>Victory Day - 9 May.</summary>
    public class VictoryDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public VictoryDay() : base(HolidayKeys.VictoryDayKZ, "Victory Day", 5, 9) { }
    }

    /// <summary>Capital Day - 6 July.</summary>
    public class CapitalDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public CapitalDay() : base(HolidayKeys.CapitalDayKZ, "Capital Day", 7, 6) { }
    }

    /// <summary>Constitution Day - 30 August.</summary>
    public class ConstitutionDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ConstitutionDay() : base(HolidayKeys.ConstitutionDayKZ, "Constitution Day", 8, 30) { }
    }

    /// <summary>
    /// Kurban Ait (Eid al-Adha).
    /// TODO (pre-existing inaccuracy carried forward verbatim): hardcoded to 1 September rather
    /// than the actual Islamic-calendar date; should eventually use
    /// <see cref="Islamic.EidAlAdha"/>. Do not silently change - it alters published behavior.
    /// </summary>
    public class KurbanAitDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public KurbanAitDay() : base(HolidayKeys.KurbanAitKZ, "Kurban Ait", 9, 1) { }
    }

    /// <summary>First President Day - 1 December.</summary>
    public class FirstPresidentDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public FirstPresidentDay() : base(HolidayKeys.FirstPresidentDayKZ, "First President Day", 12, 1) { }
    }

    /// <summary>Independence Day - 16 December.</summary>
    public class IndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceDay() : base(HolidayKeys.IndependenceDayKZ, "Independence Day", 12, 16) { }
    }

    /// <summary>Independence Day holiday (second day) - 17 December.</summary>
    public class IndependenceDaySecond : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public IndependenceDaySecond() : base(HolidayKeys.IndependenceDaySecondKZ, "Independence Day Holiday", 12, 17) { }
    }
}
