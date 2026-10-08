using PublicHoliday.HolidayDefinitions.Base;

namespace PublicHoliday.HolidayDefinitions.CountrySpecific.Greece
{
    /// <summary>Greek Independence Day (also the Annunciation of the Virgin Mary) - 25 March.</summary>
    public class GreekIndependenceDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public GreekIndependenceDay() : base(HolidayKeys.GreekIndependenceDay, "Independence Day", 3, 25) { }
    }

    /// <summary>Ochi Day ("No" Day, anniversary of the 1940 refusal of the Italian ultimatum) - 28 October.</summary>
    public class OchiDay : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public OchiDay() : base(HolidayKeys.OchiDayGR, "Ochi Day", 10, 28) { }
    }

    /// <summary>Synaxis of the Mother of God - 26 December.</summary>
    public class SynaxisOfTheMotherOfGod : FixedDateHoliday
    {
        /// <summary>Creates the definition.</summary>
        public SynaxisOfTheMotherOfGod() : base(HolidayKeys.SynaxisMotherOfGodGR, "Glorifying Mother of God", 12, 26) { }
    }
}
