using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.Christian
{
    /// <summary>Christmas Day - 25 December.</summary>
    public class Christmas : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Christmas() : base(HolidayKeys.Christmas, "Christmas", 12, 25) { }
    }

    /// <summary>Christmas Eve - 24 December.</summary>
    public class ChristmasEve : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ChristmasEve() : base(HolidayKeys.ChristmasEve, "Christmas Eve", 12, 24) { }
    }

    /// <summary>St Stephen's Day / Boxing Day / Second Christmas Day - 26 December.</summary>
    public class SaintStephensDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SaintStephensDay() : base(HolidayKeys.SaintStephensDay, "St Stephen's Day", 12, 26) { }
    }

    /// <summary>Epiphany - 6 January.</summary>
    public class Epiphany : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Epiphany() : base(HolidayKeys.Epiphany, "Epiphany", 1, 6) { }
    }

    /// <summary>Assumption of Mary - 15 August.</summary>
    public class Assumption : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public Assumption() : base(HolidayKeys.Assumption, "Assumption", 8, 15) { }
    }

    /// <summary>All Saints' Day - 1 November.</summary>
    public class AllSaints : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public AllSaints() : base(HolidayKeys.AllSaints, "All Saints", 11, 1) { }
    }

    /// <summary>Immaculate Conception - 8 December.</summary>
    public class ImmaculateConception : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ImmaculateConception() : base(HolidayKeys.ImmaculateConception, "Immaculate Conception", 12, 8) { }
    }

    /// <summary>Reformation Day - 31 October (Germany, Slovenia).</summary>
    public class ReformationDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public ReformationDay() : base(HolidayKeys.ReformationDay, "Reformation Day", 10, 31) { }
    }

    /// <summary>Orthodox Christmas Day - 7 January (Julian-calendar churches: Serbia, Montenegro).</summary>
    public class OrthodoxChristmas : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public OrthodoxChristmas() : base(HolidayKeys.Christmas, "Christmas (Orthodox)", 1, 7) { }
    }

    /// <summary>Orthodox Christmas Eve - 6 January (Julian-calendar churches: Montenegro).</summary>
    public class OrthodoxChristmasEve : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public OrthodoxChristmasEve() : base(HolidayKeys.ChristmasEve, "Christmas Eve (Orthodox)", 1, 6) { }
    }

    /// <summary>St Patrick's Day - 17 March (Ireland, Northern Ireland, Canada NL).</summary>
    public class StPatricksDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public StPatricksDay() : base(HolidayKeys.StPatricksDay, "St Patrick's Day", 3, 17) { }
    }

    /// <summary>Feast of Saints Peter and Paul - 29 June (historical Czech/Czechoslovak holiday).</summary>
    public class SaintPeterAndPaul : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SaintPeterAndPaul() : base(HolidayKeys.SaintPeterAndPaul, "Feast of Saints Peter and Paul", 6, 29) { }
    }
}
